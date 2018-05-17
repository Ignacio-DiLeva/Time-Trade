using System;
using System.Collections.Generic; //For list
using System.Globalization; //For number provider

namespace mainSample
{
    public static class Constants
    {
        public static char dataSeparator = ',';
        public static char variableSeparator = ';';
        public static char listSeparator = '#';
        public static NumberFormatInfo numberFormat = CultureInfo.InvariantCulture.NumberFormat;
        public static readonly int displayedDays = 60; //Days to be displayed
        public static readonly List<string> companies = new List<string>()
        { "AAPL","AMZN","BA","BBI","BBY","BP","C","CAT","DDAIF","F","INTC","JPM","KO","LEHMQ","MOT","MTLQQ.PK","S","SBUX",
          "T","TRMP"
        }; //Company SYMBOLS
        public static readonly double[,,] values = new double[20, 1096, 5];      //Values obtained from database
        public static readonly string[,] stockInfo = new string[20, 2]; //Information of the companies
        public static readonly bool stableBuild = true;
        public static readonly string newPlay = "AAPL;10000;2007-6-1####AAPL;AMZN;BA;BBI;BBY;BP;C;CAT;DDAIF;F;INTC;JPM;KO;LEHMQ;MOT;MTLQQ.PK;S;SBUX;T;TRMP#Empty;Empty;Empty;Empty;Empty;Empty;Empty;Empty;Empty;Empty;AAPL;AMZN;BA";
    }
}
