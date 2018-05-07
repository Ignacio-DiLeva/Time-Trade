using System;
using System.Diagnostics;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using System.Security.Cryptography;
using System.Net;
using System.Net.Sockets;
using MaterialSkin.Controls;
using System.Collections;
using System.Collections.Generic;
using System.Data.OleDb;

namespace TimeTradeServer
{
    public partial class TimeTradeServer : MaterialForm
    {
        public TimeTradeServer()
        {
            InitializeComponent();
        }

        OleDbConnection con;

        string serverIP = null;
        const string serverPrivateKey = "<RSAKeyValue><Modulus>5o/lCLnwUxnxIEuoAEXquFp3HQLjwDLtwegnmkW46DNBT0FwEVMk1BMi2/lyhy+775YL7pNt34iy+0d7ephlBQPZi+tfgfmoBrGrExIuZTGLO41dvdIoB4AHogkrthz0LoHjuZINZNyRxY9mAS8f0L76+PVShgMtlnNOKGI+KTwzlJgw2uk60ZFf3b3vu6GPz3Gmh28m9lyM0jTBIRJIWlVOC3U3OLC+rUzrEFX2oFlqidLksiFsIB0XsOeE13RsiWsjGUV8/siC8IyAlVNKkkiJQQr/akGAkshCApRVgJJXuIOJiCCAL/a7bjjGpTNd0qOQB1OqYTITSzOYhRBbFw==</Modulus><Exponent>AQAB</Exponent><P>6H34cGGN0txJvwf4BBDks64bz9AKq1KYLwz9pIIWSmXdNebtuMbVlaHwc0bgPXEs17W5m4ylDNJaIu9I05TVp+7QANeZVmaQh+8nGI/DiH/doEn3U6684jfUXDBxqMSluoqU5JZJ1og4Y8Qn+3bBJN2k4GP2Y/ES3p374O6/Cg0=</P><Q>/d/3gIHefOTeQmGHh7DA6XH/Nj8ovNO7YfpQcctQugiZX8n7hTZZJTYQgFcN/nmDSJEs3b15XwKnrLiymkOkgQ0y9jvHNpyD47in4KzaISZXEVzVHAAPQRITig+IkBWnyQvwwk4466C35qGo+Z8+J9F5PTPxhiK9e5C3fjg8pLM=</Q><DP>TBcWXWmAKjfQpwXrpSEGSMw96/ix1Tp19kgxJ0swEm9eQ8rtmKDyvENA1+mlcFZ/D6Y5NfCFADpEJ9Tap+y5NHoTd4MYe0+cE/EwgXhjzWPT3Cb5HFk/FmahSP7N5Cdf+jpq2plZVy5EDlrfnwxR0Ef+MzZkKHd47oUUL5zTx20=</DP><DQ>BMe8z0yitdNRZAqWFLX9S+f7mDfkOnn6I0QlU58ya+5RhP42oDF/yDWWZfQ9rTb4g9tH7vzsVh+krJnlswXnCQ8IkJ5bh+m2igkmEBLxIIKqTQdkc9yEbQM8HvNf7OabfCufYuk6JSWnkM4mclzPPMyy7bYWrCHnU3ZMHjJM4gU=</DQ><InverseQ>2SxIkLKcdSWcwb+WOZY+6HGMnwi+oUIPP5oBk5dP0SH9Os/reyeM0DnDQHa7NEbdwyMoHlqk5wAa7r7XMcUT004ID2+RBYU6qz0lKD74i0b6V50Q67HD6qk3nbOPcwziuiYqOLU+1CPxsNvXC/2yS69Yc5mZiuzQsCa7SlbOExQ=</InverseQ><D>Hz9NORuKGJkhdtEKGc9f+lA4aHQlzbyZQHhoNZ5RaxbXORiTSaXNDfjx9oIeJXgwrk3VnCXa9DqglzGe6ISS3FUjPLVPolvli9K0bsc+BnTqe82y8LD0v994KVu40tultE/iPxouOocyMmY22t46H55igS8uWf9ARG2oIA0Ag7HlGQ1Abhg9+2FsbbCu+AhPYbgJ04G1YJh3F46fhERn1iW/MnZZ9tiuEFBVXun0Af7Jk7xa6iPN/F/cKWllzHS6hwWhQcM/SwujRDZ7i2hCQPyHcd4cuLk1RVUy2nLsgxQ888Zm2uncATO8SflYC2JxGDFTywn9a/9ciSJPpBKFMQ==</D></RSAKeyValue>";
        const string newPlay = "AAPL:10000:1:6:2007#Empty:Empty:Empty:Empty:Empty:Empty:Empty:Empty:Empty:Empty:AAPL:AMZN:BA#AAPL:AMZN:BA:BBI:BBY:BP:C:CAT:DDAIF:F:INTC:JPM:KO:LEHMQ:MOT:MTLQQ.PK:S:SBUX:T:TRMP#############";

        private void OnLoad(object sender, EventArgs e)
        {
            Process myProcess = Process.GetCurrentProcess();
            myProcess.PriorityClass = ProcessPriorityClass.High;
            var host = Dns.GetHostEntry(Dns.GetHostName()); //List of IPs
            foreach (var IP in host.AddressList) //Foreach ip
            {
                if (IP.AddressFamily == AddressFamily.InterNetwork) //We choose IPV4
                {
                    serverIP = IP.ToString();
                }
            }
            Text += serverIP;
            con = new OleDbConnection //Connection
                (@" 
                    Provider= Microsoft.ACE.OLEDB.12.0;
                    Data Source= USERS.accdb;
                    Persist Security Info = False;
                ");

            con.Open(); //Opens connection to database
            Thread returnIP = new Thread(() => ReturnSelfData(serverIP)); returnIP.Start(); //Start receiving connection requests
            Thread reception = new Thread(Receive); reception.Start(); //Starts receiving client orders
        }

        void Receive()
        {
            Socket sck = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            sck.Bind(new IPEndPoint(IPAddress.Parse(serverIP), 1999));
            while (true)
            {
                try
                {
                    sck.Listen(0);
                    Socket acc = sck.Accept();
                    byte[] buffer = new byte[Convert.ToInt32(Math.Pow(2, 15))];
                    int rec = acc.Receive(buffer, 0, buffer.Length, 0);
                    Array.Resize(ref buffer, rec);
                    Thread order = new Thread(() => Interpreter(buffer)); order.Start();
                }
                catch (Exception ex) { MessageBox.Show(ex.ToString()); }
            }
        }

        void Interpreter(byte[] dataB)
        {
            try
            {
                string data = Encoding.ASCII.GetString(dataB);
                string[] blocks = data.Split(new string[] { "<DATA>" }, StringSplitOptions.RemoveEmptyEntries);
                data = null;
                for (int i = 0; i < blocks.Length; i++)
                {
                    data += DecryptString(blocks[i], 2048, serverPrivateKey);
                }
                string[] keyAndData = data.Split(new string[] { "</RSAKeyValue>" }, StringSplitOptions.RemoveEmptyEntries);
                keyAndData[0] += "</RSAKeyValue>";
                string[] values = keyAndData[1].Split(new string[] { ";" }, StringSplitOptions.RemoveEmptyEntries);
                if (values[0] == "8D2BC2FBE298146F51C4A1F00B9DE57A")
                {
                    if (values[1] == "REGISTER")
                    {
                        values[2]=values[2].Replace('?', 'Ñ');
                        values[2] = values[2].ToUpperInvariant();
                        string code = Register(values[2], values[3], values[4]);
                        Send(IPAddress.Parse(values[5]), Encoding.Default.GetBytes(EncryptString(code, 2048, keyAndData[0])));
                    }
                    else if (values[1] == "LOGIN")
                    {
                        values[2] = values[2].Replace('?', 'Ñ');
                        values[2] = values[2].ToUpperInvariant();
                        string code = Login(values[2], values[3], values[4]);
                        Send(IPAddress.Parse(values[5]), Encoding.Default.GetBytes(EncryptString(code, 2048, keyAndData[0])));
                    }
                    else if (values[1] == "SALT")
                    {
                        values[2] = values[2].Replace('?', 'Ñ');
                        values[2] = values[2].ToUpperInvariant();
                        string salt;
                        if (values[2] == "NEW")
                        {
                            salt = NewUnique32Bytes("Salt");
                        }
                        else
                        {
                            salt = GetSalt(values[2]);
                        }
                        Send(IPAddress.Parse(values[3]), Encoding.Default.GetBytes(EncryptString(salt, 2048, keyAndData[0])), 2001);
                    }
                    else if (values[1] == "SAVEDATA")
                    {
                        values[2] = values[2].Replace('?', 'Ñ');
                        values[2] = values[2].ToUpperInvariant();
                        SaveData(values[2], values[3], values[4]);
                    }
                    else if (values[1] == "ENDGAME")
                    {
                        values[2] = values[2].Replace('?', 'Ñ');
                        values[2] = values[2].ToUpperInvariant();
                        EndGame(values[2], values[3],Convert.ToDouble(values[4]));
                    }
                    else if (values[1] == "LEADERBOARD")
                    {
                        Send(IPAddress.Parse(values[2]), GetLeaderboard(keyAndData[0]));
                    }
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message + "\r\n" + ex.ToString()+"\r\n"+Encoding.Default.GetString(dataB)); }
        }

        private byte[] GetLeaderboard(string key)
        {
            OleDbCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "SELECT * FROM [ENDEDGAMES] ORDER BY [MONEY] DESC";
            cmd.ExecuteNonQuery();
            OleDbDataAdapter da = new OleDbDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            string str=null;
            for(int i=0;(i<10) && (i < dt.Rows.Count); i++)
            {
                str += (i+1)+")  "+dt.Rows[i][0] + ": $" + dt.Rows[i][1]+";";
            }
            if (str == null) { str = "NO REGISTERED GAMES"; }
            List<string> blocks = new List<string>();
            int k = 0;
            for (; (k + 256) < str.Length; k += 256)
            {
                blocks.Add(str.Substring(k, 256));
            }
            try
            {
                blocks.Add(str.Substring(k));
            }
            catch (Exception) { }
            string encryptedFinal = null;
            for (int i = 0; i < blocks.Count; i++)
            {
                encryptedFinal += EncryptString(blocks[i], 2048, key) + "<DATA>";
            }
            encryptedFinal = encryptedFinal.Substring(0, encryptedFinal.Length - 6);
            return Encoding.Default.GetBytes(encryptedFinal);
        }

        private void EndGame(string username, string sessid, double money)
        {
            if (DataIntegrityVerified(username, eMin: 3, eMax: 32, allowedChars: new List<char>() { 'Ñ',' ' }) && DataIntegrityVerified(sessid,eSize:32) && DataIntegrityVerified(money.ToString(), allowedChars: new List<char>() { ',', '.' },eMin:1))
            {
                OleDbCommand cmdC = con.CreateCommand();
                cmdC.CommandType = CommandType.Text;
                cmdC.CommandText = "SELECT [SESSID] FROM USERS WHERE [Username] = '" + username + "'";
                cmdC.ExecuteNonQuery();
                OleDbDataAdapter da = new OleDbDataAdapter(cmdC);
                DataTable dt = new DataTable();
                da.Fill(dt);
                if(dt.Rows.Count>0 && dt.Rows[0][0].ToString() == sessid)
                {
                    OleDbCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "INSERT INTO [ENDEDGAMES] VALUES('" + username + "', '" + money + "')";
                    cmd.ExecuteNonQuery();
                }
            }
        }

        private void SaveData(string username, string sessid, string savedata)
        {
            if (DataIntegrityVerified(username, eMin: 3, eMax: 32, allowedChars: new List<char>() { 'Ñ', ' ' }) && DataIntegrityVerified(sessid,eSize:32) && DataIntegrityVerified(savedata, allowedChars: new List<char>() {':','/',',','#','.'},eMin:1))
            {
                OleDbCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "UPDATE [USERS] SET [SAVEDATA] = '" + savedata + "' WHERE [Username] = '" + username + "' AND [SESSID] = '" + sessid + "'";
                cmd.ExecuteNonQuery();
                OleDbCommand cmd2 = con.CreateCommand();
                cmd2.CommandType = CommandType.Text;
                cmd2.CommandText = "UPDATE [USERS] SET [SESSID] = '" + "" + "' WHERE [Username] = '" + username + "'";
                cmd2.ExecuteNonQuery();
            }
        }

        void Send(IPAddress ip, byte[] sendData, int port = 2000)
        {
            Socket sck = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            sck.Connect(ip, port);
            sck.Send(sendData, 0, sendData.Length, 0);
            sck.Close();
        }

        string Register(string username, string password, string salt) //Register
        {
            try
            {
                if (DataIntegrityVerified(username, eMin: 3, eMax: 32, allowedChars: new List<char>() { 'Ñ', ' ' }) && DataIntegrityVerified(password,eSize:128,
                    whiteList:new List<char>() {'0','1','2','3','4','5','6','7','8','9','A','B','C','D','E','F' }) 
                    && DataIntegrityVerified(salt,eSize:32)) //Checks for no injection
                {
                    if (NewUser(username)) //If username does not exist
                    {
                        string sessid = NewUnique32Bytes(); //Random SESSID
                        OleDbCommand cmd = con.CreateCommand();
                        cmd.CommandType = CommandType.Text;
                        //We insert the new username
                        cmd.CommandText = "INSERT INTO [USERS] VALUES ('"
                            + username + "', '" + salt + "', '" + password + "', '"
                            + sessid + "', '" + newPlay + "')";
                        cmd.ExecuteNonQuery();
                        //We return the SESSID and a new savedata
                        return sessid + "<SAVEDATA>" + newPlay;
                    }
                    else
                    {
                        return "#USERALREADYREGISTERED"; //User already exists
                    }
                }
                return "#BADPARAMETERS"; //Invalid username
            }
            catch (Exception)
            {
                return "#UNEXPECTED"; //Unexpected
            }
        }

        string Login(string username, string password, string salt) //Login
        {
            try
            {
                //Checks for no injection
                if (DataIntegrityVerified(username, eMin: 3, eMax: 32, allowedChars: new List<char>() { 'Ñ', ' ' }) && DataIntegrityVerified(password, eSize: 128,
                    whiteList: new List<char>() { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9', 'A', 'B', 'C', 'D', 'E', 'F' }) 
                    && DataIntegrityVerified(salt,eSize:32))
                {
                    OleDbCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    //We get the username data
                    cmd.CommandText = "SELECT * FROM [USERS] WHERE [Username] ='" + username + "'";
                    cmd.ExecuteNonQuery();
                    OleDbDataAdapter da = new OleDbDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    if (dt.Rows.Count == 0) //If no rows are returned, username does not exists
                    {
                        return "#USERNOTFOUND"; //User is not found
                    }
                    if (password != dt.Rows[0][2].ToString()) //We check for the password
                    {
                        return "#INCORRECTPASSWORD"; //If wrong we return as incorrect password
                    }
                    string sessid = NewUnique32Bytes();
                    OleDbCommand cmd2 = con.CreateCommand();
                    cmd2.CommandType = CommandType.Text;
                    //We update the SESSID
                    cmd2.CommandText = "UPDATE [USERS] SET [SESSID] = '"
                        + sessid + "' WHERE [Username] = '" + username + "'";
                    cmd2.ExecuteNonQuery();
                    //We return the SESSID and the savedata
                    return sessid + "<SAVEDATA>" + dt.Rows[0][4];
                }
                return "#BADPARAMETERS"; //Invalid username
            }
            catch (Exception)
            {
                return "#UNEXPECTED"; //Unexpected
            }
        }

        private string NewUnique32Bytes(string column = "SESSID")
        {
            OleDbCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "SELECT [" + column + "] FROM [USERS]";
            cmd.ExecuteNonQuery();
            OleDbDataAdapter da = new OleDbDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            bool isUnique = false;
            while (!isUnique)
            {
                isUnique = true;
                string chars = "0123456789ABCDEF";
                Random rnd = new Random();
                string unique = null;
                for (int i = 0; i < 32; i++)
                {
                    unique += chars[rnd.Next(chars.Length)];
                }
                foreach (DataRow dr in dt.Rows)
                {
                    if (dr[0].ToString() == unique)
                    {
                        isUnique = false;
                    }
                }
                if (isUnique)
                {
                    return unique;
                }
            }
            return null;
        }

        bool DataIntegrityVerified
        (
        string data, 
        List<char> allowedChars = null, 
        int eSize= -1,
        int eMin = -1,
        int eMax = -1,
        List<char>whiteList=null
        )
        {
            if(eSize!=-1 && data.Length != eSize) { return false; }
            if(eMin!=-1 && data.Length < eMin) { return false; }
            if(eMax!=-1 && data.Length > eMax) { return false; }
            if (whiteList != null)
            {
                for(int c = 0; c < data.Length; c++)
                {
                    for(int i = 0; i < whiteList.Count; i++)
                    {
                        if (data[c] == whiteList[i])
                        {
                            break;
                        }
                        if (i == whiteList.Count - 1)
                        {
                            return false;
                        }
                    }
                }
                return true;
            }
            foreach (char c in data)
            {
                if (!Char.IsLetterOrDigit(c))
                {
                    if (allowedChars != null)
                    {
                        for(int i = 0; i < allowedChars.Count; i++)
                        {
                            if (c == allowedChars[i]) { break;}
                            if (i == allowedChars.Count - 1) { return false; }
                        }
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        bool NewUser(string username)
        {
            if (DataIntegrityVerified(username, eMin: 3, eMax: 32, allowedChars: new List<char>() { 'Ñ', ' ' }))
            {
                OleDbCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "SELECT [Username] FROM [USERS]";
                cmd.ExecuteNonQuery();
                OleDbDataAdapter da = new OleDbDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                foreach (DataRow dr in dt.Rows)
                {
                    if (dr[0].ToString() == username)
                    {
                        return false;
                    }
                }
                return true;
            }
            return false;
        }

        public byte[] Combine(byte[] first, byte[] second)
        {
            byte[] ret = new byte[first.Length + second.Length];
            Buffer.BlockCopy(first, 0, ret, 0, first.Length);
            Buffer.BlockCopy(second, 0, ret, first.Length, second.Length);
            return ret;
        }

        private void OnClosing(object sender, FormClosingEventArgs e)
        {
            con.Close();
            Dispose();
            Environment.Exit(0);
        }

        public string EncryptString(string inputString, int dwKeySize, string xmlString)
        {
            // TODO: Add Proper Exception Handlers
            RSACryptoServiceProvider rsaCryptoServiceProvider = new RSACryptoServiceProvider(dwKeySize);
            rsaCryptoServiceProvider.FromXmlString(xmlString);
            int keySize = dwKeySize / 8;
            byte[] bytes = Encoding.UTF32.GetBytes(inputString);
            // The hash function in use by the .NET RSACryptoServiceProvider here 
            // is SHA1
            // int maxLength = ( keySize ) - 2 - 
            //              ( 2 * SHA1.Create().ComputeHash( rawBytes ).Length );
            int maxLength = keySize - 42;
            int dataLength = bytes.Length;
            int iterations = dataLength / maxLength;
            StringBuilder stringBuilder = new StringBuilder();
            for (int i = 0; i <= iterations; i++)
            {
                byte[] tempBytes = new byte[
                        (dataLength - maxLength * i > maxLength) ? maxLength :
                                                      dataLength - maxLength * i];
                Buffer.BlockCopy(bytes, maxLength * i, tempBytes, 0,
                                  tempBytes.Length);
                byte[] encryptedBytes = rsaCryptoServiceProvider.Encrypt(tempBytes,
                                                                          true);
                // Be aware the RSACryptoServiceProvider reverses the order of 
                // encrypted bytes. It does this after encryption and before 
                // decryption. If you do not require compatibility with Microsoft 
                // Cryptographic API (CAPI) and/or other vendors. Comment out the 
                // next line and the corresponding one in the DecryptString function.
                Array.Reverse(encryptedBytes);
                // Why convert to base 64?
                // Because it is the largest power-of-two base printable using only 
                // ASCII characters
                stringBuilder.Append(Convert.ToBase64String(encryptedBytes));
            }
            return stringBuilder.ToString();
        }

        public string DecryptString(string inputString, int dwKeySize, string xmlString)
        {
            // TODO: Add Proper Exception Handlers
            RSACryptoServiceProvider rsaCryptoServiceProvider = new RSACryptoServiceProvider(dwKeySize);
            rsaCryptoServiceProvider.FromXmlString(xmlString);
            int base64BlockSize = ((dwKeySize / 8) % 3 != 0) ?
              (((dwKeySize / 8) / 3) * 4) + 4 : ((dwKeySize / 8) / 3) * 4;
            int iterations = inputString.Length / base64BlockSize;
            ArrayList arrayList = new ArrayList();
            for (int i = 0; i < iterations; i++)
            {
                byte[] encryptedBytes = Convert.FromBase64String(
                     inputString.Substring(base64BlockSize * i, base64BlockSize));
                // Be aware the RSACryptoServiceProvider reverses the order of 
                // encrypted bytes after encryption and before decryption.
                // If you do not require compatibility with Microsoft Cryptographic 
                // API (CAPI) and/or other vendors.
                // Comment out the next line and the corresponding one in the 
                // EncryptString function.
                Array.Reverse(encryptedBytes);
                arrayList.AddRange(rsaCryptoServiceProvider.Decrypt(
                                    encryptedBytes, true));
            }
            return Encoding.UTF32.GetString(arrayList.ToArray(
                                      Type.GetType("System.Byte")) as byte[]);
        }

        string GetSalt(string username)
        {
            if (!DataIntegrityVerified(username, eMin: 3, eMax: 32, allowedChars: new List<char>() { 'Ñ', ' ' })) { return NewUnique32Bytes("Salt"); }
            OleDbCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            if (!DataIntegrityVerified(username)) { return NewUnique32Bytes("Salt"); }
            cmd.CommandText = "SELECT [Salt] FROM [USERS] WHERE [Username] = '"+username+"'";
            cmd.ExecuteNonQuery();
            OleDbDataAdapter da = new OleDbDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            if (dt.Rows.Count == 0)
            {
                return NewUnique32Bytes("Salt");
            }
            return dt.Rows[0][0].ToString();
        }

        private void ReturnSelfData(string serverIP)
        {
            UdpClient Server = new UdpClient(2999);
            string response = serverIP;
            while (true)
            {
                try
                {
                    IPEndPoint ClientEp = new IPEndPoint(IPAddress.Any, 0);
                    byte[] ClientRequestData = Server.Receive(ref ClientEp);
                    string ClientRequest = Encoding.ASCII.GetString(ClientRequestData);
                    string[] keyAndData = ClientRequest.Split(new string[] { "</RSAKeyValue>" }, StringSplitOptions.None);
                    keyAndData[0] += "</RSAKeyValue>";
                    byte[] send = Encoding.Default.GetBytes(EncryptString(response, 2048, keyAndData[0]));
                    Send(IPAddress.Parse(keyAndData[1]), send, 3000);
                }
                catch (Exception) { }
            }
        }
    }
}