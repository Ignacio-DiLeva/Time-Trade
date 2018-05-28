using System;
using System.Collections.Generic;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;

namespace mainSample
{
    public partial class Account : Form
    {
        Font balance_font = new Font("Lucida Calligraphy", 14);
        Color foreColor = Color.White;

        Color backcolor = Color.FromArgb(79, 93, 117);
        Font general_balance = new Font("Garamond", 12);
        Font portfolio_fonts = new Font("Times New Roman", 9);
        Color penColor = Color.White;


        PictureBox p = new PictureBox
        {
            Size = new Size(975, 585),
            Location = new Point(0, 0),
            BackColor = Color.FromArgb(79, 93, 117)
        };
        public Account()
        {
            InitializeComponent();
            Location = new Point(0, 90);
            Controls.Add(p);
            p.SendToBack();
        }

        //labels of buy and sell so we can delete them later when cancelled
        List<PictureBox> cancel_buy = new List<PictureBox>();
        List<Label> company_buy = new List<Label>();
        List<Label> price_buy = new List<Label>();
        List<Label> amount_buy = new List<Label>();
        List<string> buy_labels = new List<string>();

        List<PictureBox> cancel_sell = new List<PictureBox>();
        List<Label> company_sell = new List<Label>();
        List<Label> price_sell = new List<Label>();
        List<Label> amount_sell = new List<Label>();
        List<string> sell_labels = new List<string>();

        public void Reload_panel()
        {
            //label showing balance
            account_money.Text = "Money: $" + Math.Round(Globals.moneyBalance, 2).ToString(); 

            //Adds the balance value of both stocks and money
            double stocks_balanceValue = 0;

            //loops through all the stocks and adds the value
            foreach(Company c in Globals.portfolio_companies)
            {
                stocks_balanceValue += Utilities.ReadInfo(c.Name, Globals.today) * c.Holdings;
            }
            
            //loops through all the orders and adds the value (these are your holdings put on sell)
            foreach(Order o in Globals.sellOrders)
            {
                stocks_balanceValue += Utilities.ReadInfo(o.Name, Globals.today) * o.Holdings;
            }

            //updates the label of your stock values
            stocks_balance.Text = "Stocks: $" + Math.Round(stocks_balanceValue, 2);

            //adds the total value of your money and your stocks
            double totalvalue = Math.Round(Globals.moneyBalance, 2) + stocks_balanceValue;

            //updates the label
            total_balance.Text = "Total: $" + totalvalue;

            //puts the portfolio label text changing as secondary task and changes 
            Thread addHoldings = new Thread(Add_holdings); addHoldings.Start(); 
        }

        //when you click the label, you are redirected to trade
        private void RedirectToTrade(object sender, EventArgs e)
        {
            Globals.trade.Searcher.Text = ((Control)sender).Text;
            Globals.main.ShowForm("Trade");
            Hide();
            Globals.main.currentForm = "Trade";
            Globals.main.showLogo.Tag = Globals.main.currentForm;
        }

        public void Reload_sell()
        {
            //clears all the labels
            panel_sellOrders.Controls.Clear();
            cancel_sell.Clear(); 
            company_sell.Clear();
            price_sell.Clear();
            amount_sell.Clear();
            sell_labels.Clear();

            //declares cancel picturebox
            PictureBox cancel; 

            int i = 0;
            //loop to show all the orders you have
            foreach (Order o in Globals.sellOrders) 
            {
                //creates a label with the order company name
                company_sell.Add(Return_label(0, i + 1, o.Name, "label_company"));
                //adds name to panel
                panel_sellOrders.Controls.Add(company_sell[i]);
                //this helps to cancel order
                sell_labels.Add(company_sell[i].Tag.ToString()); 

                //creates a label with the holdings of that order
                amount_sell.Add(Return_label(60, i + 1, Convert.ToString(o.Holdings), "label_amount"));

                //adds the amount of shares you order
                panel_sellOrders.Controls.Add(amount_sell[i]); 

                //adds the price of that order
                price_sell.Add(Return_label(130, i + 1, Convert.ToString(o.Price), "label_price"));
                //adds the price of shares you order
                panel_sellOrders.Controls.Add(price_sell[i]);

                //cancel picturebox
                cancel = new PictureBox 
                {
                    Name = "cancel_" + (i + 1),
                    Size = new Size(15, 15),
                    Location = new Point(193, 27 * (i + 1)), //location depending on which line you are
                    Image = Properties.Resources.buttonx_j,
                    SizeMode = PictureBoxSizeMode.StretchImage,
                    Tag = "object_" + (i + 1),
                };
                //adds the CancelMethod to the click action
                cancel.Click += CancelMethodSell;
                //adds top list
                cancel_sell.Add(cancel);
                //adds to panel
                panel_sellOrders.Controls.Add(cancel_sell[i]);

                i++; //next order

            }
        }


        public void Reload_buy()
        {
            //clears to reload
            panel_buyOrders.Controls.Clear();
            cancel_buy.Clear(); 
            company_buy.Clear();
            price_buy.Clear();
            amount_buy.Clear();
            buy_labels.Clear();

            //declares cancel picturebox
            PictureBox cancel; 

            int i = 0;
            //loop to show all the orders you have
            foreach (Order o in Globals.buyOrders) 
            {
                //creates a label and adds to a list
                company_buy.Add(Return_label(0, i + 1, Globals.buyOrders[i].Name, "label_company"));

                //adds name to panel
                panel_buyOrders.Controls.Add(company_buy[i]);

                //this helps to cancel order
                buy_labels.Add(company_buy[i].Tag.ToString()); 

                //adds the holdings label to the amount buy list
                amount_buy.Add(Return_label(60, i + 1, Convert.ToString(o.Holdings), "label_amount"));

                //adds the amount of shares you order to the panel
                panel_buyOrders.Controls.Add(amount_buy[i]); 

                //creates a price label and adds to list
                price_buy.Add(Return_label(130, i + 1, Convert.ToString(o.Price), "label_price"));

                //adds the price of shares you order to the panel
                panel_buyOrders.Controls.Add(price_buy[i]); 



                cancel = new PictureBox //cancel picturebox
                {
                    Name = "cancel_" + (i + 1),
                    Size = new Size(15, 15),
                    Location = new Point(195, 26 * (i + 1)), //location depending on which line you are
                    Image = Properties.Resources.buttonx_j,
                    SizeMode = PictureBoxSizeMode.StretchImage,
                    Tag = "object_" + (i + 1),
                };

                //adds the CancelMethod to the click action 
                cancel.Click += CancelMethodBuy;
                //adds to list
                cancel_buy.Add(cancel);
                //adds to panel
                panel_buyOrders.Controls.Add(cancel_buy[i]);

                i++;
            }
        }


        public void OnLoad(object sender, EventArgs e)
        {
            //defines fonts for the balance labels
            stocks_balance.Font = balance_font;
            stocks_balance.BackColor = backcolor;
            stocks_balance.ForeColor = foreColor;

            total_balance.Font = balance_font;
            total_balance.BackColor = backcolor;
            total_balance.ForeColor = foreColor;

            account_money.Font = balance_font;
            account_money.BackColor = backcolor;
            account_money.ForeColor = foreColor;

            //reloads all panels to check changes
            Reload_panel(); 
            Reload_buy();
            Reload_sell();

            //update the balance label
            Balance_label.Text = "Balance";
            Balance_label.Font = general_balance;
            Balance_label.Location = new Point(68, 81-60);
            Balance_label.BackColor = backcolor;
            Balance_label.ForeColor = foreColor;

            //defines the font
            Font fonts = portfolio_fonts;

            
            int x = 0;
            int y = 0;

            //creates once all the labels of the portfolio
            for (int i = 0; i < 141; i++)
            {
                //creates a sample label
                Label label = new Label
                {
                    Text = "",
                    Font = fonts,
                    Name = x + "_name",
                    Tag = "tag",
                    AutoSize = true
                };

                switch (x) //depending on which label columnn you are, it creates a different type of label
                {
                    case 0: //name of the company
                        label.Location = new Point(symbol_label.Location.X - 3, (symbol_label.Location.Y + 40) + 22 * y);
                        label.Name = y + "name";
                        label.DoubleClick += RedirectToTrade;
                        break;
                    case 1: //shares of that company
                        label.Location = new Point(Shares_label.Location.X, (Shares_label.Location.Y + 40) + 22 * y);
                        label.Name = y + "shares";
                        break;
                    case 2: //current price of that company
                        label.Location = new Point(price_label.Location.X, (price_label.Location.Y + 40) + 22 * y);
                        label.Name = y + "current";
                        break;
                    case 3: //the cost of each share
                        label.Location = new Point(Cost_label.Location.X, (Cost_label.Location.Y + 40) + 22 * y);
                        label.Name = y + "cost";
                        break;
                    case 4: //how much you bought that share
                        label.Location = new Point(buyprice_label.Location.X, (buyprice_label.Location.Y + 40) + 22 * y);
                        label.Name = y + "bp";
                        break;
                    case 5: //the gainloss in raw value
                        label.Location = new Point(gainloss1_label.Location.X, (gainloss1_label.Location.Y + 40) + 22 * y);
                        label.Name = y + "glone";
                        break;
                    case 6: //gainloss in percentage
                        label.Location = new Point(gainloss2_label.Location.X, (gainloss2_label.Location.Y + 40) + 22 * y);
                        label.Name = y + "gltwo";
                        break;
                }

                label.Tag = y; //define its tag depending on the line. It will be used later
                panel_portfolio.Controls.Add(label); //adds the label

                x++; //iterates through the 7 types of labels
                if (x == 7) //when it creates a line, passes to the next line
                {
                    x = 0;
                    y++;
                }
            }
            //updates the values of each label
            Add_holdings();
        }

        //method that updates the information of the portfolio
        private void Add_holdings()
        {
            //defines the current day
            DateTime dates = Globals.today; 
            //defines fonts
            Font fonts = portfolio_fonts;

            //clears all labels that are not the ones that are the title
            foreach (Control ctl in panel_portfolio.Controls)
            {
                if (ctl.Tag.ToString() != "initial_label")
                {
                    if (ctl.Text == null)
                    {
                        break;
                    }
                    Invoke((MethodInvoker)delegate { ctl.Text = null; });

                }
            }
            //checks if you have any companies
            if (Globals.portfolio_companies.Count != 0)
            {
                int y = 0;

                //iterates through each company
                foreach (Company cm in Globals.portfolio_companies)
                {
                    //defines the value in which the company closes
                    string close_Value = Utilities.ReadInfo(cm.Name, dates).ToString();

                    //iterates through the controls in the panel, in other words, the labels
                    foreach (Control ctl in panel_portfolio.Controls)
                    {
                        //the tag defines the column of the label. Checks if the control has the iteration of y
                        if (ctl.Tag.ToString() == y.ToString())
                        {

                            string name = "";

                            //obtains the column of the label
                            foreach (char c in ctl.Name)
                            {
                                if (!Char.IsDigit(c))
                                {
                                    name += c;
                                }   
                            }

                            //the cost of all the holdings
                            double total_Cost = cm.Values * cm.Holdings;

                            //the raw gainloss
                            double gainloss_Cost = Convert.ToDouble(close_Value) - cm.Values;

                            //depending of which column
                            switch (name)
                            {
                                case "name":
                                    Invoke((MethodInvoker)delegate { ctl.Text = cm.Name; });
                                    break;
                                case "shares":
                                    Invoke((MethodInvoker)delegate { ctl.Text = cm.Holdings.ToString(); });
                                    break;

                                case "current":
                                    Invoke((MethodInvoker)delegate { ctl.Text = close_Value; });
                                    break;

                                case "cost":
                                    Invoke((MethodInvoker)delegate { ctl.Text = "$" + Math.Round(total_Cost, 2).ToString(); });
                                    break;

                                case "bp":
                                    Invoke((MethodInvoker)delegate { ctl.Text = "$" + Math.Round(cm.Values, 2).ToString(); });
                                    break;

                                case "glone":
                                    Invoke((MethodInvoker)delegate {

                                        ctl.Text = ((gainloss_Cost * cm.Holdings) < 0 ? "-1" : "") + "$" + Math.Round(Math.Abs((gainloss_Cost) * cm.Holdings), 2).ToString();
                                    });
                                    break;

                                case "gltwo":
                                    Invoke((MethodInvoker)delegate { ctl.Text = Math.Round((gainloss_Cost) / cm.Values * 100, 2).ToString() + "%"; });
                                    break;
                            }
                        }
                    }
                    y++;
                }

            }
        }

        //method to update the portfolio from another form
        public void Update_portfolio()
        {
            Reload_buy();
            Reload_sell();
            Reload_panel();
        }

        //draws the lines of the portfolio
        private void Paint_portfolio(object sender, PaintEventArgs e) //paints the portfolio chart
        {

            Pen blackPen = new Pen(penColor, 1);
            Point p1;
            Point p2;

            foreach (Control ctl in panel_portfolio.Controls) //draws the vertical lines of the chart
            {
                if (ctl.Tag.ToString() == "initial_label") //only draws on the initial labels
                {
                    p1 = new Point(ctl.Location.X - 5, ctl.Location.Y); //declares point 1
                    p2 = new Point(ctl.Location.X - 5, (gainloss2_label.Location.Y + 56) + 19 * 22); //declares point 2
                    e.Graphics.DrawLine(blackPen, p1, p2);
                }

            }

            //draws the second vertical line
            p1 = new Point(gainloss2_label.Location.X + 77, gainloss2_label.Location.Y);
            p2 = new Point(gainloss2_label.Location.X + 77, (gainloss2_label.Location.Y + 56) + 19 * 22);
            e.Graphics.DrawLine(blackPen, p1, p2);
            //draws the first horizontal line
            p1 = new Point(gainloss2_label.Location.X + 77, gainloss2_label.Location.Y + 37);
            p2 = new Point(symbol_label.Location.X - 5, gainloss2_label.Location.Y + 37);
            e.Graphics.DrawLine(blackPen, p1, p2);

            p1 = new Point(gainloss2_label.Location.X + 77, gainloss2_label.Location.Y-2);
            p2 = new Point(symbol_label.Location.X - 5, gainloss2_label.Location.Y-2);
            e.Graphics.DrawLine(blackPen, p1, p2);

            for (int i = 0; i <= 21; i++) //draws the extra horizontal lines
            {
                p1 = new Point(gainloss2_label.Location.X + 77, (gainloss2_label.Location.Y + 56) + i * 22);
                p2 = new Point(symbol_label.Location.X - 5, (gainloss2_label.Location.Y + 56) + i * 22);
                e.Graphics.DrawLine(blackPen, p1, p2);
            }
        }


        //draw the lines of the orders panel
        private void Paint_table(object sender, PaintEventArgs e)
        {
            Pen bp = new Pen(penColor, 1);
            Point p1;
            Point p2;

            for (int i = 0; i < 4; i++)
            {
                p1= new Point(10 + 60 * i, 0);
                p2 = new Point(10 + 60 * i, 25 * 6);
                e.Graphics.DrawLine(bp,p1, p2);
            }

            p1 = new Point(10 + 180 + 20, 0);
            p2 = new Point(10 + 180 + 20, 25 * 6);
            e.Graphics.DrawLine(bp, p1, p2);

            for (int i = 0; i < 6; i++)
            {
                p1 = new Point(10, 25 * (i + 1));
                p2 = new Point(210, 25 * (i + 1));
                e.Graphics.DrawLine(bp, p1, p2);
            }

            //adds the lables to the panel
            panel_buyOrders.Controls.Add(Return_label(0, 0, "Symbol", "company_name")); //shows labels that
            panel_buyOrders.Controls.Add(Return_label(60, 0, "Shares", "company_name")); //form the chart
            panel_buyOrders.Controls.Add(Return_label(125, 0, "Price", "company_name"));

            panel_sellOrders.Controls.Add(Return_label(0, 0, "Symbol", "company_name")); //shows labels that
            panel_sellOrders.Controls.Add(Return_label(60, 0, "Shares", "company_name")); //form the chart
            panel_sellOrders.Controls.Add(Return_label(125, 0, "Price", "company_name"));
        }

        //default label creating method
        Label Return_label(int locationx, int i, string text, string tag)
        {
            return new Label
            {
                Location = new Point(12 + locationx, 27 * (i)),
                Text = text,
                Font = new Font("Times New Roman", 9),
                Name = tag + i,
                Tag = "object_" + i,
                AutoSize = true,
                ForeColor = foreColor,
                BackColor = backcolor
                
            };
        }

        //when cancelling the buyorder
        private void CancelMethodBuy(object sender, EventArgs e)
        {
            RemoveOrderBuy(((Control)sender).Tag.ToString());

            Reload_buy();
        }

        //when cancelling the sellorder
        private void CancelMethodSell(object sender, EventArgs e)
        {
            RemoveOrderSell(((Control)sender).Tag.ToString());

            Reload_panel();
            Reload_sell();

        }

        //when removing the sell order
        void RemoveOrderSell(string company)
        {
            int a = -1;

            //checks if the company in which you cancel the order is in your sell labels
            for (int i = 0; i < sell_labels.Count; i++)
            {
                if (sell_labels[i].ToString() == company)
                {
                    a = i;
                }
            }
            //if it is in your sell labels
            if (a != -1)
            {
                //removes from controls all labels related to that oder
                panel_sellOrders.Controls.Remove(amount_sell[a]);
                panel_sellOrders.Controls.Remove(company_sell[a]);
                panel_sellOrders.Controls.Remove(price_sell[a]);
                panel_sellOrders.Controls.Remove(cancel_sell[a]);

                //removes it from the lists
                sell_labels.RemoveAt(a);
                amount_sell.RemoveAt(a);
                company_sell.RemoveAt(a);
                price_sell.RemoveAt(a);
                cancel_sell.RemoveAt(a);

                int index = -1;

                //checks if the country is already in your portfolio. The shares you put to sell are actually your shares, so when you cancel it the shares go back to you
                for (int i = 0; i < Globals.portfolio_companies.Count; i++)
                {
                    if (Globals.portfolio_companies[i].Name == Globals.sellOrders[a].Name)
                    {
                        //if the company whose order are cancelling already has shares in your portfolio
                        index = i;
                    }

                }

                //if it is in your portfolio
                if (index != -1)
                {
                    //updates holdings
                    Globals.portfolio_companies[index].Holdings += Globals.sellOrders[a].Holdings;

                    //updates values
                    Globals.portfolio_companies[index].AddValues(Globals.sellOrders[a].Holdings, Globals.sellOrders[a].OriginalPrice); 
                }
                else
                {
                    //creates a brand new portfolio company
                    Globals.portfolio_companies.Add(
                        new Company(Globals.sellOrders[a].Name, Globals.sellOrders[a].Holdings,Globals.sellOrders[a].OriginalPrice));
                }

                //removes the order from sell orders
                Globals.sellOrders.RemoveAt(a);
            }
        }

        //when removing the labels from buy orders
        void RemoveOrderBuy(string company)
        {
            int a = -1;

            //checks the index of the buy order
            for (int i = 0; i < buy_labels.Count; i++)
            {
                if (buy_labels[i].ToString() == company)
                {
                    a = i;

                }
            }
            if (a != -1)
            {

                //removes all orders whose index is the one above.
                panel_buyOrders.Controls.Remove(amount_buy[a]);
                panel_buyOrders.Controls.Remove(company_buy[a]);
                panel_buyOrders.Controls.Remove(price_buy[a]);
                panel_buyOrders.Controls.Remove(cancel_buy[a]);
                buy_labels.RemoveAt(a);
                amount_buy.RemoveAt(a);
                company_buy.RemoveAt(a);
                price_buy.RemoveAt(a);
                cancel_buy.RemoveAt(a);
                Globals.buyOrders.RemoveAt(a);
            }
        }
    }
}