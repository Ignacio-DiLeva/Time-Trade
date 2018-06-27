using System;
using System.Security.Cryptography;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Linq;
using System.Threading;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace mainSample
{
    class Utilities
    {
        //BEGIN HOOKS CODE
        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;

        [System.Runtime.InteropServices.DllImportAttribute("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [System.Runtime.InteropServices.DllImportAttribute("user32.dll")]
        public static extern bool ReleaseCapture();
        //END HOOKS CODE

        //METHODS
        public static double ReadInfo(string getCompany, DateTime getDate, string getQuery = "CLOSE") //Adapter for 3d array
        {
            getCompany = getCompany.ToUpper(); //We set to upper the data
            getQuery = getQuery.ToUpper(); //We set to upper the data
            int index0 = GetIndexOfCompany(getCompany); //We obtain the index
            int index1 = GetIndexOfDay(getDate); //We obtain the index
            int index2 = GetIndexOfQuery(getQuery); //We obtain the index
            return Constants.values[index0, index1, index2]; //We return the value in the specific index
        }
        public static int GetIndexOfCompany(string company)
        {
            for (int i = 0; i < 20; i++) //For each company
            {
                if (Constants.companies[i] == company) //If it is the company we want
                {
                    return i; //We return index
                }
            }
            return -1; //Should not happen, will throw an ArrayOutOfBoundsException
        }
        public static int GetIndexOfDay(DateTime date)
        {
            return (date - new DateTime(2007, 1, 1)).Days;
            //End - Start with DateTime operator - returns the difference between two dates
        }
        public static int GetIndexOfQuery(string query)
        {
            if (query == "CLOSE") //If it is the close value
            {
                return 3;
            }
            if (query == "VOLUME") //If it is the volume value
            {
                return 4;
            }
            if (query == "OPEN") //If it is the open value
            {
                return 0;
            }
            if (query == "HIGH") //If it is the high value
            {
                return 1;
            }
            if (query == "LOW") //If it is the low value
            {
                return 2;
            }
            return 3; //If error, we return close value
        }

        public static string ShortDateTimeString(DateTime date)
        {
            return date.Year.ToString() + '-' + date.Month.ToString() + '-' + date.Day.ToString();
        }

        public static DateTime ToDateTime(string date)
        {
            string[] data = date.Split(new char[] { '-' });
            return new DateTime(year: Convert.ToInt32(data[0]), month: Convert.ToInt32(data[1]), day: Convert.ToInt32(data[2]));
        }

        public static void LoadData(string str)
        {
            try
            {
                string[] lists = str.Split(new char[] { Constants.listSeparator }, StringSplitOptions.None);
                for (int i = 0; i < lists.Length; i++)
                {
                    string[] variables = lists[i].Split(new char[] { Constants.variableSeparator }, StringSplitOptions.RemoveEmptyEntries);
                    if (i == 0)
                    {
                        Globals.displayedCompany = variables[0];
                        Globals.moneyBalance = Convert.ToDouble(variables[1], Constants.numberFormat);
                        Globals.today = Utilities.ToDateTime(variables[2]);
                        continue;
                    }
                    if (i == 1)
                    {
                        foreach (string company in variables)
                        {
                            Globals.portfolio_companies.Add(Company.FromString(company));
                        }
                        continue;
                    }
                    if (i == 2)
                    {
                        foreach (string buyOrder in variables)
                        {
                            Globals.buyOrders.Add(Order.FromString(buyOrder));
                        }
                        continue;
                    }
                    if (i == 3)
                    {
                        foreach (string sellOrder in variables)
                        {
                            Globals.sellOrders.Add(Order.FromString(sellOrder));
                        }
                        continue;
                    }
                    if (i == 4)
                    {
                        foreach (string company in variables)
                        {
                            Globals.wlAvailableCompanies.Add(company);
                        }
                        continue;
                    }
                    if (i == 5)
                    {
                        for (int k = 0; k < variables.Length; k++)
                        {
                            Globals.watchlistData[k, 0] = variables[k];
                        }
                        continue;
                    }
                }
                Globals.wlAvailableCompanies.Sort();
            }
            catch (Exception ex)
            {
                Globals.portfolio_companies.Clear();
                Globals.buyOrders.Clear();
                Globals.sellOrders.Clear();
                Globals.wlAvailableCompanies.Clear();
                for(int i = 0; i < Globals.watchlistData.GetLength(0); i++)
                {
                    Globals.watchlistData[i, 0] = null;
                }
                throw ex;
            }
        }

        public static void SaveData(object sender, FormClosingEventArgs e)
        {
            /*
            public static string displayedCompany; //Company being shown on trade tab
            public static double moneyBalance;//Total balance
            public static DateTime today; //Current day

            public static List<Company> portfolio_companies = new List<Company>(); //list of companies in portfolio

            public static List<Order> buyOrders = new List<Order>(); //list of buy orders

            public static List<Order> sellOrders = new List<Order>(); //list of sell orders

            public static List<string> wlAvailableCompanies = new List<string>(); //Available companies for watchlist

            public static string[,] watchlistData = new string[13, 2]; //Watchlist (Treated as list in savedata, only first)
            */
            Globals.main.Invoke((MethodInvoker)delegate
            {
                Globals.main.Visible = false;
            });
            string savedata = "";
            savedata += Globals.displayedCompany + Constants.variableSeparator;
            savedata += Convert.ToString(Globals.moneyBalance, Constants.numberFormat) + Constants.variableSeparator;
            savedata += ShortDateTimeString(Globals.today);
            savedata += Constants.listSeparator;
            for (int i = 0; i < Globals.portfolio_companies.Count; i++)
            {
                if (i > 0)
                {
                    savedata += Constants.variableSeparator;
                }
                savedata += Globals.portfolio_companies[i].ToString();
            }
            savedata += Constants.listSeparator;
            for (int i = 0; i < Globals.buyOrders.Count; i++)
            {
                if (i > 0)
                {
                    savedata += Constants.variableSeparator;
                }
                savedata += Globals.buyOrders[i].ToString();
            }
            savedata += Constants.listSeparator;
            for (int i = 0; i < Globals.sellOrders.Count; i++)
            {
                if (i > 0)
                {
                    savedata += Constants.variableSeparator;
                }
                savedata += Globals.sellOrders[i].ToString();
            }
            savedata += Constants.listSeparator;
            for (int i = 0; i < Globals.wlAvailableCompanies.Count; i++)
            {
                if (i > 0)
                {
                    savedata += Constants.variableSeparator;
                }
                savedata += Globals.wlAvailableCompanies[i].ToString();
            }
            savedata += Constants.listSeparator;
            for (int i = 0; i < Globals.watchlistData.GetLength(0); i++)
            {
                if (i > 0)
                {
                    savedata += Constants.variableSeparator;
                }
                savedata += Globals.watchlistData[i, 0];
            }
            if (Globals.main.username ==null)
            {
                Clipboard.SetText(savedata);
                try
                {
                    Environment.Exit(0);
                }
                catch (Exception) { Environment.FailFast("TIME TRADE ABORT"); }
                
            }
            else
            {
                Thread connect = new Thread(() => Globals.main.SendSavedata(savedata)); connect.Start();
                try
                {
                    Environment.Exit(0);
                }
                catch (Exception) { Environment.FailFast("TIME TRADE ABORT"); }
            }
        }

        public static byte[] Combine(byte[] first, byte[] second)
        {
            byte[] ret = new byte[first.Length + second.Length];
            Buffer.BlockCopy(first, 0, ret, 0, first.Length);
            Buffer.BlockCopy(second, 0, ret, first.Length, second.Length);
            return ret;
        }

        public static string EncryptString(string inputString, int dwKeySize, string xmlString)
        {
            RSACryptoServiceProvider rsaCryptoServiceProvider =
            new RSACryptoServiceProvider(dwKeySize);
            rsaCryptoServiceProvider.FromXmlString(xmlString);
            int keySize = dwKeySize / 8;
            byte[] bytes = Encoding.UTF32.GetBytes(inputString);
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
                Array.Reverse(encryptedBytes);
                stringBuilder.Append(Convert.ToBase64String(encryptedBytes));
            }
            return stringBuilder.ToString();
        }

        public static string DecryptString(string inputString, int dwKeySize, string xmlString)
        {
            RSACryptoServiceProvider rsaCryptoServiceProvider =
            new RSACryptoServiceProvider(dwKeySize);
            rsaCryptoServiceProvider.FromXmlString(xmlString);
            int base64BlockSize = ((dwKeySize / 8) % 3 != 0) ?
              (((dwKeySize / 8) / 3) * 4) + 4 : ((dwKeySize / 8) / 3) * 4;
            int iterations = inputString.Length / base64BlockSize;
            ArrayList arrayList = new ArrayList();
            for (int i = 0; i < iterations; i++)
            {
                byte[] encryptedBytes = Convert.FromBase64String(
                     inputString.Substring(base64BlockSize * i, base64BlockSize));
                Array.Reverse(encryptedBytes);
                arrayList.AddRange(rsaCryptoServiceProvider.Decrypt(
                                    encryptedBytes, true));
            }
            return Encoding.UTF32.GetString(arrayList.ToArray
                (Type.GetType("System.Byte")) as byte[]);
        }
    }
}
