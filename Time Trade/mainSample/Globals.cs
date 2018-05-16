using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace mainSample
{
    public static class Globals
    {
        /*
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
        */

        public static List<Companies> portfolio_companies = new List<Companies>(); //list of companies in portfolio
        public static List<Orders> buyOrders = new List<Orders>(); //list of buy orders
        public static List<Orders> sellOrders = new List<Orders>(); //list of sell orders


        //DI LEVA --- SAVEDATA
        public static string displayedCompany; //Companie being shown on trade tab
        public static double moneyBalance;//Total balance
        public static DateTime d; //Current day
        public static string[,] watchlistData = new string[13, 2]; //Watchlist
        public static List<string> wlAvailableCompanies = new List<string>(); //Available companies for watchlist

        //FORM REFERENCE
        public static Trade trade;     //We still do not initialize, we still need the mainForm Location to give as parameter (OnLoad)
        public static Stock stock;     //We still do not initialize, we still need the mainForm Location to give as parameter (OnLoad)
        public static Account account;   //We still do not initialize, we still need the mainForm Location to give as parameter (OnLoad)
        public static Watchlist watchlist; //We still do not initialize, we still need the mainForm Location to give as parameter (OnLoad)
        public static SideWatchlist sideWatchlist; //We still do not initialize, we still need the mainForm Location to give as parameter (OnLoad)
        public static Main main; //We still do not initialize, we still need the username and SESSID
    }
}
