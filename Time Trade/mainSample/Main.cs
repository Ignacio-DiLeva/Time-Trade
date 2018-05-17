using System; //Main commands
using System.Collections.Generic; //For Lists
using System.Drawing; //For the Location Point
using System.Windows.Forms; //Althought we use the MaterialForm, we need it for the buttons
using System.Security.Cryptography; //For RSA and SHA
using System.Text; //For encoding and decoding
using System.Net; //For internet
using System.Net.Sockets; //For server connections
using System.Collections; //For Array (RSA and SHA algorithm)
using System.Threading; //For secondary task

namespace mainSample //Namespace
{
    public partial class Main : Form //This form inherits from MaterialForm rather than a Windows Form
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

        public Main(string username, string sessid, string serverIP, string ownIP) //Main form
        {
            InitializeComponent(); //Starts the form
            this.username = username;
            this.sessid = sessid;
            this.serverIP = serverIP;
            this.ownIP = ownIP;
            showLogo.BringToFront();
            RestartPB.BringToFront();
            temporal_min.BringToFront();
            temporal_close.BringToFront();
            //Dock = DockStyle.Fill;
        }
        public string username;
        public string sessid;
        string serverIP;
        public string currentForm; //Saves the secondary form displayed
        string ownIP;

        public void OnLoad(object sender, EventArgs e) //Main form loading
        {
            for (int i = 0; i < 4; i++) //5 buttons (Trade, Stock, Account, Watchlist, Compare)
            {
                Button b = new Button //New button
                {
                    Size = new Size(225, 60), //Size
                    Location = new Point(150 + i * 225, 10), //Location
                    TabStop = false,
                    FlatStyle = FlatStyle.Flat
                };
                b.FlatAppearance.BorderColor = Color.FromArgb(0,238,255);
                if (i == 0) { b.Text = "Trade"; b.Click += ShowForm; b.Tag = b.Text; b.BackgroundImage = Properties.Resources.BOTON_APRETADO_2; } //Trade section (DEFAULT)
                if (i == 1) { b.Text = "Stock"; b.Click += ShowForm; b.Tag = b.Text; b.BackgroundImage = Properties.Resources.BOTON_APRETADO_2; } //Stock section
                if (i == 2) { b.Text = "Account"; b.Click += ShowForm; b.Tag = b.Text; b.BackgroundImage = Properties.Resources.BOTON_APRETADO_2; } //Portfolio
                if (i == 3) { b.Text = "Watchlist"; b.Click += ShowForm; b.Tag = b.Text; b.BackgroundImage = Properties.Resources.BOTON_APRETADO_2; } //WatchList
                Controls.Add(b); //We add it to Controls
                b.BringToFront();
            }
            currentForm = "Trade"; //Default secondaryForm
            showLogo.Tag = currentForm; //That box will return to the current form
            Location = new Point(Screen.PrimaryScreen.Bounds.Width / 2 - (Width / 2), 0); //Center X, TopScreen
            //We load the forms
            Globals.trade = new Trade();
            Globals.stock = new Stock();
            Globals.account = new Account();
            Globals.watchlist = new Watchlist();
            Globals.sideWatchlist = new SideWatchlist();
            //Now we set topLevel, and add them as controls
            Globals.trade.TopLevel = false; Controls.Add(Globals.trade);
            Globals.stock.TopLevel = false; Controls.Add(Globals.stock);
            Globals.account.TopLevel = false; Controls.Add(Globals.account);
            Globals.watchlist.TopLevel = false; Controls.Add(Globals.watchlist);
            Globals.sideWatchlist.TopLevel = false; Controls.Add(Globals.sideWatchlist);
            //We show and hide them so they are included in the OpenForms collection
            Globals.stock.Show(); Globals.stock.Hide();
            Globals.account.Show(); Globals.account.Hide();
            Globals.watchlist.Show(); Globals.watchlist.Hide();
            Globals.trade.Show(); //Default secondary form, so we load
            Globals.sideWatchlist.UpdateCalendar(Globals.today);
            Globals.sideWatchlist.Show(); //We show the secondary Watchlist
            Globals.trade.Focus(); //We focus this default secondary form
        }

        public void ShowForm(object sender, EventArgs e) //Secondary Forms displayer
        {
            string desiredForm = ((Control)sender).Tag.ToString(); //We get the desired form
            if(desiredForm== "DeleteSaveData")
            {
                DialogResult r = MessageBox.Show("Are you sure you want to restart?","RESTART",MessageBoxButtons.YesNo,MessageBoxIcon.Warning);
                if (r == DialogResult.Yes)
                {
                    string newPlay;
                    {
                        newPlay = "AAPL:10000:1:6:2007#Empty:Empty:Empty:Empty:Empty:Empty:Empty:Empty:Empty:Empty:AAPL:AMZN:BA#AAPL:AMZN:BA:BBI:BBY:BP:C:CAT:DDAIF:F:INTC:JPM:KO:LEHMQ:MOT:MTLQQ.PK:S:SBUX:T:TRMP#############";
                    }
                    Enabled = false;
                    Thread end = new Thread(()=>SendSavedata(newPlay));end.Start();
                    return; // We scope out of the function
                }
            }
            else if (desiredForm != currentForm) //If it is a different one
            {
                ShowForm(desiredForm); //We show it
                HideForm(currentForm); //We hide the previous form
                currentForm = desiredForm; //We update the current form
                showLogo.Tag = currentForm; //We update the current form on the logo picture
                return; //We scope out of the function
            }
            ShowForm(currentForm); //If already shown we show it again, so it is not blocked by another apps
        }

        internal void SendEndGame(string getUsername,string sessid,double sumOfTotal)
        {
            string serverPublicKey = "<RSAKeyValue><Modulus>5o/lCLnwUxnxIEuoAEXquFp3HQLjwDLtwegnmkW46DNBT0FwEVMk1BMi2/lyhy+775YL7pNt34iy+0d7ephlBQPZi+tfgfmoBrGrExIuZTGLO41dvdIoB4AHogkrthz0LoHjuZINZNyRxY9mAS8f0L76+PVShgMtlnNOKGI+KTwzlJgw2uk60ZFf3b3vu6GPz3Gmh28m9lyM0jTBIRJIWlVOC3U3OLC+rUzrEFX2oFlqidLksiFsIB0XsOeE13RsiWsjGUV8/siC8IyAlVNKkkiJQQr/akGAkshCApRVgJJXuIOJiCCAL/a7bjjGpTNd0qOQB1OqYTITSzOYhRBbFw==</Modulus><Exponent>AQAB</Exponent></RSAKeyValue>";
            string magicHeader = "8D2BC2FBE298146F51C4A1F00B9DE57A"; //32 bytes of EE
            Socket sck = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            RSACryptoServiceProvider rsa = new RSACryptoServiceProvider(2048);
            byte[] data = Encoding.Default.GetBytes(magicHeader + ";" +"ENDGAME"+";"+ getUsername + ";" + sessid+";"+sumOfTotal);
            byte[] key = Encoding.Default.GetBytes(rsa.ToXmlString(false));
            byte[] sendData = Combine(key, data);
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
                encryptedFinal += EncryptString(blocks[i], 2048, serverPublicKey) + "<DATA>";
            }
            encryptedFinal = encryptedFinal.Substring(0, encryptedFinal.Length - 6);
            sendData = Encoding.Default.GetBytes(encryptedFinal);
            sck.Connect(serverIP, 1999);
            sck.Send(sendData, 0, sendData.Length, 0);
            sck.Close();
        }

        public void ShowForm(string desired)  //Shows desired form
        {
            if (desired == "Trade")
            {
                Globals.trade.Show();
                Globals.sideWatchlist.Show();
                Globals.sideWatchlist.Focus();
                Globals.trade.Focus();
                Globals.trade.ExternalCanvasRefresh(this, null);
                return;
            }
            if (desired == "Stock")
            {
                Globals.stock.Show();
                Globals.sideWatchlist.Show();
                Globals.sideWatchlist.Focus();
                Globals.stock.Focus();
                return;
            }
            if (desired == "Account")
            {
                Globals.account.Show();
                Globals.sideWatchlist.Show();
                Globals.sideWatchlist.Focus();
                Globals.account.Focus();
                return;
            }
            if (desired == "Watchlist")
            {
                Globals.watchlist.Show();
                Globals.sideWatchlist.Show();
                Globals.sideWatchlist.Focus();
                Globals.watchlist.Focus();
                return;
            }
        }

        public void HideForm(string unwanted) //Hides unwanted form
        {
            if (unwanted == "Trade")
            {
                Globals.trade.Hide();
                return;
            }
            if (unwanted == "Account")
            {
                Globals.account.Hide();
                return;
            }
            if (unwanted == "Watchlist")
            {
                Globals.watchlist.Hide();
                return;
            }
            if (unwanted == "Stock")
            {
                Globals.stock.Hide();
                return;
            }
        }

        
        private void OnClosing(object sender, FormClosingEventArgs e)
        {
            Utilities.SaveData(Globals.main,null);
        }

        public void SendSavedata(string savedata)
        {
            if (username != null)
            {
                RSACryptoServiceProvider rsa = new RSACryptoServiceProvider(2048);
                string magicHeader = "8D2BC2FBE298146F51C4A1F00B9DE57A"; //32 bytes of EE
                string order = "SAVEDATA";
                string keyP = rsa.ToXmlString(false);
                byte[] data = Encoding.Default.GetBytes(magicHeader+";"+order+";"+username+";"+sessid+";"+savedata);
                byte[] key = Encoding.Default.GetBytes(keyP);
                byte[] sendData = Combine(key, data);
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
                string serverPublicKey; //SERVER PUBLIC KEY
                {
                    serverPublicKey = "<RSAKeyValue><Modulus>5o/lCLnwUxnxIEuoAEXquFp3HQLjwDLtwegnmkW46DNBT0FwEVMk1BMi2/lyhy+775YL7pNt34iy+0d7ephlBQPZi+tfgfmoBrGrExIuZTGLO41dvdIoB4AHogkrthz0LoHjuZINZNyRxY9mAS8f0L76+PVShgMtlnNOKGI+KTwzlJgw2uk60ZFf3b3vu6GPz3Gmh28m9lyM0jTBIRJIWlVOC3U3OLC+rUzrEFX2oFlqidLksiFsIB0XsOeE13RsiWsjGUV8/siC8IyAlVNKkkiJQQr/akGAkshCApRVgJJXuIOJiCCAL/a7bjjGpTNd0qOQB1OqYTITSzOYhRBbFw==</Modulus><Exponent>AQAB</Exponent></RSAKeyValue>";
                }
                for (int i = 0; i < blocks.Count; i++)
                {
                    encryptedFinal += EncryptString(blocks[i], 2048, serverPublicKey) + "<DATA>";
                }

                encryptedFinal = encryptedFinal.Substring(0, encryptedFinal.Length - 6);
                sendData = Encoding.Default.GetBytes(encryptedFinal);
                Socket sck = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                try
                {
                    sck.Connect(serverIP, 1999);
                    sck.Send(sendData, 0, sendData.Length, 0);
                }
                catch (Exception) { }
                sck.Close();
            }
            
            try
            {
                Invoke((MethodInvoker)delegate
                {
                    Globals.trade.Visible = false;
                    Globals.stock.Visible = false;
                    Globals.account.Visible = false;
                    Globals.watchlist.Visible = false;
                    Globals.sideWatchlist.Visible = false;
                    Visible = false;
                });
            }
            catch (InvalidOperationException) { }
            catch (Exception ex) { MessageBox.Show(ex.ToString()); }
            try
            {
                Invoke((MethodInvoker)delegate { Application.Exit(); });
            }
            catch (Exception) { Environment.Exit(0); }
        }

        public byte[] Combine(byte[] first, byte[] second)
        {
            byte[] ret = new byte[first.Length + second.Length];
            Buffer.BlockCopy(first, 0, ret, 0, first.Length);
            Buffer.BlockCopy(second, 0, ret, first.Length, second.Length);
            return ret;
        }

        public string EncryptString(string inputString, int dwKeySize, string xmlString)
        {
            // TODO: Add Proper Exception Handlers
            RSACryptoServiceProvider rsaCryptoServiceProvider =
                                          new RSACryptoServiceProvider(dwKeySize);
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
            RSACryptoServiceProvider rsaCryptoServiceProvider
                                     = new RSACryptoServiceProvider(dwKeySize);
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
            return Encoding.UTF32.GetString(arrayList.ToArray(Type.GetType("System.Byte")) as byte[]);
        }

        public void AllowInput(bool status)
        {
            if (status)
            {
                Enabled = true;
                return;
            }
            Enabled = false;
        }

        public void GetBestPlayers()
        {
            if (username != null)
            {
                Socket recv = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp); //Socket
                recv.Bind(new IPEndPoint(IPAddress.Parse(ownIP), 2000)); //We bind the socket to the port 2000
                string serverPublicKey = "<RSAKeyValue><Modulus>5o/lCLnwUxnxIEuoAEXquFp3HQLjwDLtwegnmkW46DNBT0FwEVMk1BMi2/lyhy+775YL7pNt34iy+0d7ephlBQPZi+tfgfmoBrGrExIuZTGLO41dvdIoB4AHogkrthz0LoHjuZINZNyRxY9mAS8f0L76+PVShgMtlnNOKGI+KTwzlJgw2uk60ZFf3b3vu6GPz3Gmh28m9lyM0jTBIRJIWlVOC3U3OLC+rUzrEFX2oFlqidLksiFsIB0XsOeE13RsiWsjGUV8/siC8IyAlVNKkkiJQQr/akGAkshCApRVgJJXuIOJiCCAL/a7bjjGpTNd0qOQB1OqYTITSzOYhRBbFw==</Modulus><Exponent>AQAB</Exponent></RSAKeyValue>";
                string magicHeader = "8D2BC2FBE298146F51C4A1F00B9DE57A"; //32 bytes of EE
                Socket sck = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                RSACryptoServiceProvider rsa = new RSACryptoServiceProvider(2048);
                byte[] data = Encoding.Default.GetBytes(magicHeader + ";" + "LEADERBOARD" + ";" + ownIP);
                byte[] key = Encoding.Default.GetBytes(rsa.ToXmlString(false));
                byte[] sendData = Combine(key, data);
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
                    encryptedFinal += EncryptString(blocks[i], 2048, serverPublicKey) + "<DATA>";
                }
                encryptedFinal = encryptedFinal.Substring(0, encryptedFinal.Length - 6);
                sendData = Encoding.Default.GetBytes(encryptedFinal);
                sck.Connect(serverIP, 1999);
                sck.Send(sendData, 0, sendData.Length, 0);
                sck.Close();
                recv.Listen(0); //We start listening, awaiting for the server
                Socket acc = recv.Accept(); //We accept the connection incoming from the server
                byte[] buffer = new byte[Convert.ToInt32(Math.Pow(2, 15))]; //We will store the message here
                int rec = acc.Receive(buffer, 0, buffer.Length, 0); //We get the real lenght of the message
                Array.Resize(ref buffer, rec); //We resize the message
                string received = Encoding.ASCII.GetString(buffer); //We decode from ASCII to a string
                string[] blocksR = received.Split(new string[] { "<DATA>" }, StringSplitOptions.None); //We separate the blocks
                string dataR = null;
                for (int i = 0; i < blocksR.Length; i++) //Foreach block
                {
                    dataR += DecryptString(blocksR[i], 2048, rsa.ToXmlString(true)); //We add the decrypted block into the data
                }
                dataR = dataR.Replace(";", "\r\n");
                MessageBox.Show(dataR);
                recv.Close();
            }
            Invoke((MethodInvoker)delegate
            {
                Globals.trade.btnRequestBest.Enabled = true;
            });
        }

        private void TemporalMin(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void TemporalClose(object sender, EventArgs e)
        {
            Close();
        }
    }
}