using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mainSample
{

    public class Companies
    {
        //for instantation
        public Companies(string getName, int getHoldings,double getValues) 
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
        public String Name 
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
        public void addValues(int holdingsAdd, double valuesAdd)
        {
            values = Math.Round(((holdings * values) + (holdingsAdd * valuesAdd)) / (holdings + holdingsAdd),2);
        }
    }

    public class Orders
    {
        //the order company name
        private string name;

        //holdings ordered
        private int holdings;

        //price of each holding ordered
        private double price;

        //for sell  orders in case you cancel the order/expires, you need to recover the original value
        private double originalPrice = 0;

        //remembers its date to set an expired date
        private DateTime expiredDate;

        //for instantation
        public Orders(string GetName, int GetHoldings, double GetPrice, DateTime GetDate, double GetOriginalPrice = 0)
        {
            name = GetName;
            holdings = GetHoldings;
            price = GetPrice;
            originalPrice = GetOriginalPrice;
            expiredDate = GetDate;
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
        public DateTime ExpiredDate
        {
            get { return expiredDate; }
            set { expiredDate = value; }
        }

        //set a average value
        public void addValues(int holdingsAdd, double valuesAdd)
        {
            Price = Math.Round(((holdings * Price) + (holdingsAdd * valuesAdd)) / (holdings + holdingsAdd), 2);
        }
    }
}
