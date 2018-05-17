using System;

namespace mainSample
{

    public class Company
    {
        //for instantation
        public Company(string getName, int getHoldings,double getValues) 
        {
            name = getName;
            holdings = getHoldings;
            values = getValues;
        }

        //name of company
        private string name;
        //its holdings
        private int holdings;
        //the value of each holding
        private double values;

        //for read and write
        public string Name 
        {
            get { return name; }
            set { name = value; }
        }

        //for read and write
        public int Holdings
        {
            get { return holdings; }
            set { holdings = value; }
        }

        //for read and write
        public double Values
        {
            get { return values; }
            set { values = value; }
        }

        //makes an weighted mean between the previous value and the inserted value to make a correct aproximated value
        public void AddValues(int holdingsAdd, double valuesAdd)
        {
            Values = Math.Round(((Holdings * Values) + (holdingsAdd * valuesAdd)) / (Holdings + holdingsAdd),2);
        }

        public override string ToString()
        {
            return name + 
                Constants.dataSeparator + 
                Convert.ToString(holdings, Constants.numberFormat) + 
                Constants.dataSeparator + 
                Convert.ToString(values,Constants.numberFormat);
        }

        public static Company FromString(string company)
        {
            string[] data = company.Split(new char[] { Constants.dataSeparator }, StringSplitOptions.None);
            return new Company(
                data[0], 
                Convert.ToInt32(data[1], Constants.numberFormat), 
                Convert.ToDouble(data[2], Constants.numberFormat));
        }
    }

    public class Order
    {
        //the order company name
        private string name;

        //holdings ordered
        private int holdings;

        //price of each holding ordered
        private double price;

        //remembers its date to set an expired date
        private DateTime date;

        //for sell orders in case you cancel the order/expires, you need to recover the original value
        private double originalPrice = 0;

        //for instantation
        public Order(string GetName, int GetHoldings, double GetPrice, DateTime GetDate, double GetOriginalPrice = 0)
        {
            name = GetName;
            holdings = GetHoldings;
            price = GetPrice;
            originalPrice = GetOriginalPrice;
            date = GetDate;
        }

        //read and write
        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        //read and write
        public int Holdings
        {
            get { return holdings; }
            set { holdings = value; }
        }

        //read and write
        public double Price
        {
            get { return price; }
            set { price = value; }
        }

        //read and write
        public double OriginalPrice
        {
            get { return originalPrice; }
            set { originalPrice = value; }
        }

        //read and write
        public DateTime Date
        {
            get { return date; }
            set { date = value; }
        }

        //set a average value
        public void AddValues(int holdingsAdd, double valuesAdd)
        {
            Price = Math.Round(((holdings * Price) + (holdingsAdd * valuesAdd)) / (holdings + holdingsAdd), 2);
        }

        public override string ToString()
        {
            return name +
                Constants.dataSeparator +
                Convert.ToString(holdings, Constants.numberFormat) +
                Constants.dataSeparator +
                Convert.ToString(price, Constants.numberFormat) + 
                Constants.dataSeparator +
                Utilities.ShortDateTimeString(date) +
                Constants.dataSeparator +
                Convert.ToString(originalPrice, Constants.numberFormat);
        }

        public static Order FromString(string order)
        {
            string[] data = order.Split(new char[] { Constants.dataSeparator }, StringSplitOptions.None);
            return new Order(
                data[0],
                Convert.ToInt32(data[1], Constants.numberFormat),
                Convert.ToDouble(data[2], Constants.numberFormat),
                Utilities.ToDateTime(data[3]),
                Convert.ToDouble(data[4], Constants.numberFormat));
        }
    }
}
