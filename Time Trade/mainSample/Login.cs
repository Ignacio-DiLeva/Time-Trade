using System; //For main commands
using System.Diagnostics; //For priority level
using System.Collections; //For RSA algorithm
using System.Collections.Generic; //For list and blocks
using System.Text; //For encoding and decoding
using System.Threading; //For background tasks
using System.Security.Cryptography; //For encryption and decryption
using System.Net; //For IP
using System.Net.Sockets; //For connections
using System.IO;
using MaterialSkin.Controls; //For Form
using System.Windows.Forms; //For controls

namespace mainSample
{
    public partial class Login : MaterialForm
    {
        private void AllowMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                //We capture the mouse movement and send it to the OS
                //Windows itself will handle the location of the form
                Utilities.ReleaseCapture();
                Utilities.SendMessage(Handle, Utilities.WM_NCLBUTTONDOWN, Utilities.HT_CAPTION, 0);
            }
        }

        public Login()
        {
            InitializeComponent();
            {
                serverPublicKey = "<RSAKeyValue><Modulus>5o/lCLnwUxnxIEuoAEXquFp3HQLjwDLtwegnmkW46DNBT0FwEVMk1BMi2/lyhy+775YL7pNt34iy+0d7ephlBQPZi+tfgfmoBrGrExIuZTGLO41dvdIoB4AHogkrthz0LoHjuZINZNyRxY9mAS8f0L76+PVShgMtlnNOKGI+KTwzlJgw2uk60ZFf3b3vu6GPz3Gmh28m9lyM0jTBIRJIWlVOC3U3OLC+rUzrEFX2oFlqidLksiFsIB0XsOeE13RsiWsjGUV8/siC8IyAlVNKkkiJQQr/akGAkshCApRVgJJXuIOJiCCAL/a7bjjGpTNd0qOQB1OqYTITSzOYhRBbFw==</Modulus><Exponent>AQAB</Exponent></RSAKeyValue>";
            }
        }
        readonly string serverPublicKey; //SERVER PUBLIC KEY
        string ip; //OWN IP
        string serverIP=null; //SERVER IP
        string username=null;
        string sessid=null;
        RSACryptoServiceProvider rsa = new RSACryptoServiceProvider(2048); //WILL GENERATE A PAIR OF KEYS
        Socket recv = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        private void GetServerIP()
        {
            try
            {
                recv.ReceiveTimeout = 20000;
                recv.Bind(new IPEndPoint(IPAddress.Parse(ip), 3000));
                var Client = new UdpClient
                {
                    EnableBroadcast = true
                };
                byte[] data = Encoding.Default.GetBytes(rsa.ToXmlString(false) + ip);
                Client.Send(data, data.Length, new IPEndPoint(IPAddress.Broadcast, 2999));
                recv.Listen(0);
                Socket acc = recv.Accept();
                byte[] buffer = new byte[4096];
                int rec = acc.Receive(buffer, 0, buffer.Length, 0);
                Array.Resize(ref buffer, rec);
                serverIP = Utilities.DecryptString(Encoding.ASCII.GetString(buffer), 2048, rsa.ToXmlString(true));
            }
            catch (SocketException) //Socket exception
            {
                if (!btnMain.Enabled) //Graceful exit requested by offline mode
                {
                    return; //Scope out
                }
                //Unexpected socket exception
                MessageBox.Show("Unable to retrieve server IP, exiting..."); Application.Exit();
            }
            catch (ThreadAbortException) { }
            catch (Exception) { MessageBox.Show("Unable to retrieve server IP, exiting..."); Application.Exit(); }
            //Unexpected exception
        }

        Thread getServerIP;
        private void OnLoad(object sender, EventArgs e)
        {
            Process myProcess = Process.GetCurrentProcess();
            if (Constants.stableBuild)
            {
                btnLogin.Enabled = false;
                btnRegister.Enabled = false;
            }
            else
            {
                getServerIP = new Thread(() => GetServerIP());
                myProcess.PriorityClass = ProcessPriorityClass.RealTime;
                var host = Dns.GetHostEntry(Dns.GetHostName()); //List of IPs
                foreach (var IP in host.AddressList) //Foreach ip
                {
                    if (IP.AddressFamily == AddressFamily.InterNetwork) //We choose IPV4
                    {
                        ip = IP.ToString(); //We store it in the string
                    }
                }
                getServerIP.Start();
            }

            string nums = File.ReadAllText("numbers.txt");
            string[] numbers = nums.Split(new char[] { ' ' });
            string com = File.ReadAllText("companies.txt");
            string[] companies = com.Split(new char[] { '\n' });
            
            for (int i = 0; i <21920; i++) //For all the rows
            {
                for(int k = 0; k < 5; k++) //For all the data in the i-th line
                {
                    Constants.values[i / 1096, i % 1096, k] = Math.Round(Convert.ToDouble(numbers[i*5+k],Constants.numberFormat),2); //We add it to the 3d Array
                }
            }
            for (int i = 0; i < 20; i++)
            {
                Constants.stockInfo[i, 0] = companies[i * 2];
                Constants.stockInfo[i, 1] = companies[i * 2 + 1];
            }
        }

        private void Connection(object sender, EventArgs e)
        {
            btnLogin.Enabled = false;
            btnRegister.Enabled = false;
            btnMain.Enabled = false;
            if (username == null)
            {
                Thread connect = new Thread(() => Send(((Control)sender).Text)); connect.Start();
            }
        }

        private string GetSalt(string username)
        {
            Socket recv = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            recv.Bind(new IPEndPoint(IPAddress.Parse(ip), 2001));
            recv.Listen(0);
            string magicHeader = "8D2BC2FBE298146F51C4A1F00B9DE57A"; //32 bytes of EE
            byte[] data = Encoding.Default.GetBytes(magicHeader + ";" + "SALT" + ";" + username + ";" + ip);
            byte[] key = Encoding.Default.GetBytes(rsa.ToXmlString(false));
            byte[] sendData = Utilities.Combine(key, data);
            string rawData = Encoding.ASCII.GetString(sendData);
            List<string> blocks = new List<string>();
            int k = 0;
            for (; (k + 256) < rawData.Length; k += 256)
            {
                blocks.Add(rawData.Substring(k, 256));
            }
            try
            {
                blocks.Add(rawData.Substring(k));
            }
            catch (Exception) { }
            string encryptedFinal = null;
            for (int i = 0; i < blocks.Count; i++)
            {
                encryptedFinal += Utilities.EncryptString(blocks[i], 2048, serverPublicKey) + "<DATA>";
            }
            encryptedFinal = encryptedFinal.Substring(0, encryptedFinal.Length - 6);
            sendData = Encoding.Default.GetBytes(encryptedFinal);
            Socket sck = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            sck.Connect(serverIP, 1999);
            sck.Send(sendData, 0, sendData.Length, 0);
            sck.Close();
            Socket acc = recv.Accept();
            byte[] buffer = new byte[4096];
            int rec = acc.Receive(buffer, 0, buffer.Length, 0);
            Array.Resize(ref buffer, rec);
            string rData = Encoding.ASCII.GetString(buffer);
            rData = Utilities.DecryptString(rData, 2048, rsa.ToXmlString(true)); //We know its max length is 32 bytes, so is only 1 block
            return rData;
        }

        void Send(string text)
        {
            try
            {
                if (usernameField.Text.Length >= 3 && passwordField.Text.Length >= 8 && usernameField.Text.ToUpper()!="NEW")
                {
                    string magicHeader = "8D2BC2FBE298146F51C4A1F00B9DE57A"; //32 bytes of EE
                    string order = text;
                    reception = new Thread(Receive);
                    reception.Start();
                    string salt;
                    if (order == "REGISTER")
                    {
                        salt = GetSalt("NEW");
                    }
                    else
                    {
                        salt = GetSalt(usernameField.Text); //We receive the salt from the server
                    }
                    string username = usernameField.Text; //MAX 32 bytes
                    username = username.ToUpper();
                    foreach(char c in username)
                    {
                        if (c == '?')
                        {
                            MessageBox.Show("Username may be alphanumerical", caption: "", buttons: MessageBoxButtons.OK, icon: MessageBoxIcon.Exclamation);
                            btnRegister.Enabled = true;
                            btnLogin.Enabled = true;
                            btnMain.Enabled = true;
                            return;
                        }
                    }
                    username = username.Replace('Ñ', '?');
                    this.username=username; //Copies the username to global field
                    string password = passwordField.Text; //MAX 32 bytes
                    var hash = SHA512.Create(); //We create the hash gegerator
                    byte[] salt1 = Encoding.Default.GetBytes(salt.Substring(0, 16)); //First part of salt
                    byte[] salt2 = Encoding.Default.GetBytes(salt.Substring(16, 16)); //Second part of salt
                    byte[] combined = Utilities.Combine(salt1, Encoding.Default.GetBytes(password)); //We join the salt
                    combined = Utilities.Combine(combined, salt2); //We join the salt
                    hash.ComputeHash(combined); //We compute the hash
                    string delimitedHexHash = BitConverter.ToString(hash.Hash); //We get the hash in HEX
                    string completedHash = delimitedHexHash.Replace("-", ""); //We delete the '-' generated
                    //Socket data
                    byte[] data = Encoding.Default.GetBytes(magicHeader + ";" + order + ";" + username + ";" 
                                                                + completedHash + ";" + salt + ";" + ip);
                    byte[] key = Encoding.Default.GetBytes(rsa.ToXmlString(false)); //RSA public key
                    byte[] sendData = Utilities.Combine(key, data); //We combine the data and the key
                    string rawData = Encoding.ASCII.GetString(sendData); //Concateneted non-encrypted string
                    List<string> blocks = new List<string>(); //We will divide the message into 256 bytes blocks 
                    int k = 0;
                    for (; (k+256) < rawData.Length; k += 256) //While there are more than 256 characters left
                    {
                        blocks.Add(rawData.Substring(k, 256)); //We generate a new block
                    }
                    try
                    {
                        blocks.Add(rawData.Substring(k)); //We generate the last block
                    }
                    catch (Exception) { }
                    string encryptedFinal = null; //Final string
                    for (int i = 0; i < blocks.Count; i++) //For all blocks we add them encrypted with a separator
                    {
                        encryptedFinal += Utilities.EncryptString(blocks[i], 2048, serverPublicKey)+"<DATA>";
                    }
                    encryptedFinal = encryptedFinal.Substring(0, encryptedFinal.Length - 6); //We cut last <DATA>
                    sendData = Encoding.Default.GetBytes(encryptedFinal); //We encode the data into ASCII
                    Socket sck = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                    sck.Connect(serverIP, 1999); //We connect to the server through port 1999
                    sck.Send(sendData, 0, sendData.Length, 0); //We send the encrypted message
                    sck.Close(); //We close the connection (We will receive through 2000)
                }
                else
                {
                    Invoke((MethodInvoker)delegate
                    {
                        MessageBox.Show("Username must include at least 3 characters, password must include at least 8 characters" + "\r\n\r\n" + "Username can not be 'NEW'");
                        btnLogin.Enabled = true;
                        btnRegister.Enabled = true;
                        btnMain.Enabled = true;
                    });
                }
            }
            catch (Exception ex)
            {
                try
                {
                    reception.Abort();
                    reception = new Thread(Receive);
                    reception.Start();
                }
                catch (Exception) { }
                MessageBox.Show(ex.ToString());
                Invoke((MethodInvoker)delegate
                {
                    btnLogin.Enabled = true;
                    btnRegister.Enabled = true;
                    btnMain.Enabled = true;
                });
            }
        }

        Thread reception;
        Socket sck; //Reception socket
        void Receive()
        {
            sck = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp); //Socket
            sck.Bind(new IPEndPoint(IPAddress.Parse(ip), 2000)); //We bind the socket to the port 2000
            try
            {
                sck.Listen(0); //We start listening, awaiting for the server
                Socket acc = sck.Accept(); //We accept the connection incoming from the server
                byte[] buffer = new byte[Convert.ToInt32(Math.Pow(2, 15))]; //We will store the message here
                int rec = acc.Receive(buffer, 0, buffer.Length, 0); //We get the real lenght of the message
                Array.Resize(ref buffer, rec); //We resize the message
                string data = Encoding.ASCII.GetString(buffer); //We decode from ASCII to a string
                string[] blocks = data.Split(new string[] { "<DATA>" }, StringSplitOptions.None); //We separate the blocks
                data = null; //Formated message is stored here
                for (int i = 0; i < blocks.Length; i++) //Foreach blcok
                {
                    data += Utilities.DecryptString(blocks[i], 2048, rsa.ToXmlString(true)); //We add the decrypted block into the data
                }
                if (NotAnErrorCode(data)) //If it is not an error code
                {
                    string[] sessidAndSavedata = data.Split(new string[] { "<SAVEDATA>" }, StringSplitOptions.RemoveEmptyEntries);
                    sessid = sessidAndSavedata[0]; //We get the SESSID
                    string savedata = sessidAndSavedata[1]; //We generate the savedata generator
                    Utilities.LoadData(savedata); //We generate the context, and launch the application
                    Invoke((MethodInvoker)delegate
                    {
                        Hide();
                        Globals.main = new Main(username, sessid, serverIP,ip);
                        Globals.main.Show();
                    });
                }
                else
                {
                    username = null; //If there is an error code, the username and SESSID are null
                    sessid = null; //If there is an error code, the username and SESSID are null
                }
                sck.Close(); //We close the connection with the server
            }
            catch (Exception ex)
            {
                MessageBox.Show("COULDN'T RETRIEVE DATA"+"\r\n\r\n"+ex.ToString());
                Invoke((MethodInvoker)delegate
                {
                    btnLogin.Enabled = true;
                    btnRegister.Enabled = true;
                    btnMain.Enabled = true;
                });
            }
        }

        private bool NotAnErrorCode(string data)
        {
            if (data[0] != '#') //No error
            {
                return true;
            }
            if(data == "#BADPARAMETERS") //Invalid username
            {
                MessageBox.Show("Username may be alphanumerical",caption:"",buttons:MessageBoxButtons.OK, icon:MessageBoxIcon.Exclamation);
            }
            if(data == "#INCORRECTPASSWORD") //Invalidad password
            {
                MessageBox.Show("Incorrect password. Passwords are case-sensitive", caption: "INCORRECT PASSWORD", buttons: MessageBoxButtons.OK, icon:MessageBoxIcon.Warning);
            }
            if(data == "#UNEXPECTED") //Unexpected (CATCH)
            {
                MessageBox.Show("An unexpected error has been encountered. Please try again later", caption: "UNEXPECTED ERROR", buttons: MessageBoxButtons.OK,icon:MessageBoxIcon.Information);
            }
            if(data == "#USERALREADYREGISTERED") //User already exists and it is tried to be registered again
            {
                MessageBox.Show("Username already taken, please change the username", caption: "USER ALREADY REGISTERED", buttons: MessageBoxButtons.OK, icon: MessageBoxIcon.Exclamation);
            }
            if(data == "#USERNOTFOUND") //Tried to log in with an unknown username
            {
                MessageBox.Show("The username is not registered", caption: "USER DOES NOT EXISTS", buttons: MessageBoxButtons.OK, icon: MessageBoxIcon.Warning);
            }
            Invoke((MethodInvoker)delegate 
            {
                btnLogin.Enabled = true;
                btnRegister.Enabled = true;
                btnMain.Enabled = true;
            });
            return false;
        }

        private void OnClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void BtnLaunchMain(object sender, EventArgs e)
        {
            btnMain.Enabled = false;
            if (!Constants.stableBuild)
            {
                if (getServerIP.IsAlive) { recv.Close(); } //We need to kill the thread so the app terminates properly
            }
            btnLogin.Enabled = false;
            btnRegister.Enabled = false;
            if (!(string.IsNullOrEmpty(SeedField.Text)))
            {
                Utilities.LoadData(SeedField.Text);
            }
            else
            {
                Utilities.LoadData(Constants.newPlay);
            }
            if (Globals.wlAvailableCompanies.Count != 0)
            {
                Invoke((MethodInvoker)delegate
                {
                    Hide();
                    Globals.main = new Main(username, sessid, serverIP, ip);
                    Globals.main.Show();
                });
            }
            else //TODO UNDERSTAND WHY I WRITE THIS
            {
                Invoke((MethodInvoker)delegate
                {
                    btnLogin.Enabled = true;
                    btnRegister.Enabled = true;
                    btnMain.Enabled = true;
                });
            }
        }
    }
}