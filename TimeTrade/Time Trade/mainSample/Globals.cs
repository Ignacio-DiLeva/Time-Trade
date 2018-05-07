using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace mainSample
{
    public static class Globals
    {
        //Portfolio
        public static List<string> company_name = new List<string>();        //Name of the respective company
        public static List<int> holdings = new List<int>();                  //Amount of holdings
        public static List<double> money_investedtotal = new List<double>(); //Total money invested

        //Orders
        public static List<string> buy_company = new List<string>(); //Company ordered
        public static List<int> buy_holdings = new List<int>();      //Amount of holdings in order
        public static List<int> buy_price = new List<int>();         //Price of holdings in order

        public static List<string> sell_company = new List<string>();
        public static List<int> sell_holdings = new List<int>();
        public static List<int> sell_price = new List<int>(); //Price of holdings in order

        public static List<double> original_price = new List<double>(); //original price of each order
        public static List<DateTime> ExpireDateBuy = new List<DateTime>();
        public static List<DateTime> ExpireDateSell = new List<DateTime>();

        //DI LEVA --- SAVEDATA
        public static string displayedCompany; //Companie being shown on trade tab
        public static double moneyBalance;//Total balance
        public static DateTime d; //Current day
        public static string[,] watchlistData = new string[13, 2]; //Watchlist
        public static List<string> wlAvailableCompanies = new List<string>(); //Available companies for watchlist

        //DATA
        public static readonly int displayedDays = 60; //Days to be displayed
        public static readonly List<string> companies = new List<string>() //All companies
        { "AAPL","AMZN","BA","BBI","BBY","BP","C","CAT","DDAIF","F","INTC","JPM","KO","LEHMQ","MOT","MTLQQ.PK","S","SBUX",
          "T","TRMP"
        }; //Company SYMBOLS
        public static readonly double[,,] values = new double[20, 1096, 5];      //Values obtained from database
        public static readonly string[,] stockInfo = new string[20, 2]; //Information of the companies

        //METHODS
        public static double ReadInfo(string getCompany, DateTime getDate, string getQuery = "CLOSE") //Adapter for 3d array
        {
            getCompany = getCompany.ToUpper(); //We set to upper the data
            getQuery = getQuery.ToUpper(); //We set to upper the data
            int index0 = GetIndexOfCompany(getCompany); //We obtain the index
            int index1 = GetIndexOfDay(getDate); //We obtain the index
            int index2 = GetIndexOfQuery(getQuery); //We obtain the index
            return values[index0, index1, index2]; //We return the value in the specific index
        }
        public static int GetIndexOfCompany(string company)
        {
            for (int i = 0; i < 20; i++) //For each company
            {
                if (companies[i] == company) //If it is the company we want
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
        public static void LoadData(string str)
        {
            try
            {
                int c = 0; //Char reader
                string company = null;
                while (str[c] != ':')
                {
                    company += str[c];
                    c++;
                }
                c++;
                displayedCompany = company;
                string money = null;
                while (str[c] != ':')
                {
                    money += str[c];
                    c++;
                }
                c++;
                moneyBalance = Convert.ToDouble(money);
                string day = null, month = null, year = null;
                while (str[c] != ':')
                {
                    day += str[c];
                    c++;
                }
                c++;
                while (str[c] != ':')
                {
                    month += str[c];
                    c++;
                }
                c++;
                while (str[c] != '#')
                {
                    year += str[c];
                    c++;
                }
                c++;
                d = new DateTime(day: Int32.Parse(day), month: Int32.Parse(month), year: Int32.Parse(year));
                string wl = null;
                while (str[c] != '#')
                {
                    wl += str[c];
                    c++;
                }
                c++;
                if (wl != null)
                {
                    string[] wlD = wl.Split(new string[] { ":" }, StringSplitOptions.RemoveEmptyEntries);
                    for (int i = 0; i < wlD.Length; i++)
                    {
                        watchlistData[i, 0] = wlD[i];
                    }
                }
                string wlA = null;
                while (str[c] != '#')
                {
                    wlA += str[c];
                    c++;
                }
                c++;
                if (wlA != null)
                {
                    string[] wlAD = wlA.Split(new string[] { ":" }, StringSplitOptions.RemoveEmptyEntries);
                    foreach (string strA in wlAD)
                    {
                        wlAvailableCompanies.Add(strA);
                    }
                }
                string CN = null;
                while (str[c] != '#')
                {
                    CN += str[c];
                    c++;
                }
                c++;
                if (CN != null)
                {
                    string[] CNL = CN.Split(new string[] { ":" }, StringSplitOptions.RemoveEmptyEntries);
                    foreach (string cn in CNL)
                    {
                        company_name.Add(cn);
                    }
                }
                string H = null; //Holdings
                while (str[c] != '#') //While it is not the end of list
                {
                    H += str[c]; //We add the character
                    c++; //We add the character that will be read
                }
                c++; //We add again because we are on the '#'
                if (H != null) //If there is at least one holding
                {
                    string[] HL = H.Split(new string[] { ":" }, StringSplitOptions.RemoveEmptyEntries);
                    //We split the holdings
                    foreach (string h in HL) //Foreach holding
                    {
                        holdings.Add(Convert.ToInt32(h)); //We add it to the list (casting as int)
                    }
                }
                string MI = null;
                while (str[c] != '#')
                {
                    MI += str[c];
                    c++;
                }
                c++;
                if (MI != null)
                {
                    string[] MIL = MI.Split(new string[] { ":" }, StringSplitOptions.RemoveEmptyEntries);
                    foreach (string mi in MIL)
                    {
                        money_investedtotal.Add(Convert.ToDouble(mi));
                    }
                }
                string BC = null;
                while (str[c] != '#')
                {
                    BC += str[c];
                    c++;
                }
                c++;
                if (BC != null)
                {
                    string[] BCL = BC.Split(new string[] { ":" }, StringSplitOptions.RemoveEmptyEntries);
                    foreach (string bc in BCL)
                    {
                        buy_company.Add(bc);
                    }

                }
                string BH = null;
                while (str[c] != '#')
                {
                    BH += str[c];
                    c++;
                }
                c++;
                if (BH != null)
                {
                    string[] BHL = BH.Split(new string[] { ":" }, StringSplitOptions.RemoveEmptyEntries);
                    foreach (string bh in BHL)
                    {
                        buy_holdings.Add(Convert.ToInt32(bh));
                    }
                }
                string BP = null;
                while (str[c] != '#')
                {
                    BP += str[c];
                    c++;
                }
                c++;
                if (BP != null)
                {
                    string[] BPL = BP.Split(new string[] { ":" }, StringSplitOptions.RemoveEmptyEntries);
                    foreach (string bp in BPL)
                    {
                        buy_price.Add(Convert.ToInt32(bp));
                    }
                }
                string SC = null;
                while (str[c] != '#')
                {
                    SC += str[c];
                    c++;
                }
                c++;
                if (SC != null)
                {
                    string[] SCL = SC.Split(new string[] { ":" }, StringSplitOptions.RemoveEmptyEntries);
                    foreach (string sc in SCL)
                    {
                        sell_company.Add(sc);
                    }
                }
                string SH = null;
                while (str[c] != '#')
                {
                    SH += str[c];
                    c++;
                }
                c++;
                if (SH != null)
                {
                    string[] SHL = SH.Split(new string[] { ":" }, StringSplitOptions.RemoveEmptyEntries);
                    foreach (string sh in SHL)
                    {
                        sell_holdings.Add(Convert.ToInt32(sh));
                    }
                }
                string SP = null;
                while (str[c] != '#')
                {
                    SP += str[c];
                    c++;
                }
                c++;
                if (SP != null)
                {
                    string[] SPL = SP.Split(new string[] { ":" }, StringSplitOptions.RemoveEmptyEntries);
                    foreach (string sp in SPL)
                    {
                        sell_price.Add(Convert.ToInt32(sp));
                    }
                }
                string OP = null;
                while (str[c] != '#')
                {
                    OP += str[c];
                    c++;
                }
                c++;
                if (OP != null)
                {
                    string[] OPL = OP.Split(new string[] { ":" }, StringSplitOptions.RemoveEmptyEntries);
                    foreach (string op in OPL)
                    {
                        original_price.Add(Convert.ToDouble(op));
                    }
                }
                string DB = null;
                while (str[c] != '#')
                {
                    DB += str[c];
                    c++;
                }
                c++;
                if (DB != null)
                {
                    string[] DBL = DB.Split(new string[] { ":" }, StringSplitOptions.RemoveEmptyEntries);
                    foreach (string db in DBL)
                    {
                        ExpireDateBuy.Add(Convert.ToDateTime(db));
                    }
                }
                string DS = null;
                while (str[c] != '#')
                {
                    DS += str[c];
                    c++;
                }
                c++;
                if (DS != null)
                {
                    string[] DSL = DS.Split(new string[] { ":" }, StringSplitOptions.RemoveEmptyEntries);
                    foreach (string ds in DSL)
                    {
                        ExpireDateSell.Add(Convert.ToDateTime(ds));
                    }
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Invalid seed");
                company_name = new List<string>();        //Name of the respective company
                holdings = new List<int>();                  //Amount of holdings
                money_investedtotal = new List<double>(); //Total money invested
                buy_company = new List<string>(); //Company ordered
                buy_holdings = new List<int>();      //Amount of holdings in order
                buy_price = new List<int>();         //Price of holdings in orde
                sell_company = new List<string>();
                sell_holdings = new List<int>();
                sell_price = new List<int>(); //Price of holdings in order
                original_price = new List<double>(); //original price of each order
                ExpireDateBuy = new List<DateTime>();
                ExpireDateSell = new List<DateTime>();
                wlAvailableCompanies = new List<string>(); //Available companies for watchlist
            }
        }
        //FORM REFERENCE
        public static Trade trade;     //We still do not initialize, we still need the mainForm Location to give as parameter (OnLoad)
        public static Stock stock;     //We still do not initialize, we still need the mainForm Location to give as parameter (OnLoad)
        public static Account account;   //We still do not initialize, we still need the mainForm Location to give as parameter (OnLoad)
        public static Watchlist watchlist; //We still do not initialize, we still need the mainForm Location to give as parameter (OnLoad)
        public static SideWatchlist sideWatchlist; //We still do not initialize, we still need the mainForm Location to give as parameter (OnLoad)
        public static Main main; //We still do not initialize, we still need the username and SESSID
    }
}
