using System;
using System.Collections.Generic; //For list
using System.Drawing; //For Color
using System.Globalization; //For number provider

namespace mainSample
{
    public static class Constants
    {
        public static readonly char dataSeparator = ',';
        public static readonly char variableSeparator = ';';
        public static readonly char listSeparator = '#';
        public static readonly NumberFormatInfo numberFormat = CultureInfo.InvariantCulture.NumberFormat;
        public static readonly int displayedDays = 60; //Days to be displayed
        public static readonly List<string> companies = new List<string>()
        { "AAPL","AMZN","BA","BBI","BBY","BP","C","CAT","DDAIF","F","INTC","JPM","KO","LEHMQ","MOT","MTLQQ.PK","S","SBUX",
          "T","TRMP"
        }; //Company SYMBOLS
        public static readonly double[,,] values = new double[20, 1096, 5];      //Values obtained from database
        public static readonly string[,] stockInfo = new string[20, 2]; //Information of the companies
        public static readonly bool stableBuild = true;
        public static readonly string newPlay = "AAPL;10000;2007-6-1####AAPL;AMZN;BA;BBI;BBY;BP;C;CAT;DDAIF;F;INTC;JPM;KO;LEHMQ;MOT;MTLQQ.PK;S;SBUX;T;TRMP#Empty;Empty;Empty;Empty;Empty;Empty;Empty;Empty;Empty;Empty;AAPL;AMZN;BA";
        public static readonly Color dark = Color.FromArgb(0x2D, 0x31, 0x42);
        public static readonly Color brown = Color.FromArgb(0x9E, 0x56, 0x37);
        public static readonly Color orange = Color.FromArgb(0xEF, 0x83, 0x54);
        public static readonly Color white = Color.FromArgb(0xEE, 0xEE, 0xEE);
        public static readonly Color lightGray = Color.FromArgb(0xBF, 0xC0, 0xC0);
        public static readonly Color darkGray = Color.FromArgb(0x4F, 0x5D, 0x75);
        public static readonly Color black = Color.Black;
    }
}
