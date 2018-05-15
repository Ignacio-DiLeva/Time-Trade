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
        Color backcolor = Color.FromArgb(0, 238, 255);
        Font general_balance = new Font("Garamond", 12);
        Font portfolio_fonts = new Font("Times New Roman", 9);

        PictureBox p = new PictureBox
        {
            Size = new Size(975, 600),
            Location = new Point(0, 0),
            BackColor = Color.FromArgb(0, 238, 255)
        };
        public Account()
        {
            InitializeComponent();
            Location = new Point(225, 70);
            Controls.Add(p);
            p.SendToBack();
        }

        //labels of buy and sell so we can delete them later when cancelled
        List<PictureBox> cancel_buy = new List<PictureBox>();
        List<Label> company_buy = new List<Label>();
        List<Label> price_buy = new List<Label>();
        List<Label> amount_buy = new List<Label>();
        List<Control> buy_labels = new List<Control>();

        List<PictureBox> cancel_sell = new List<PictureBox>();
        List<Label> company_sell = new List<Label>();
        List<Label> price_sell = new List<Label>();
        List<Label> amount_sell = new List<Label>();
        List<Control> sell_labels = new List<Control>();

        public void Reload_panel()
        {            
            account_money.Text = "Money: $" + Math.Round(Globals.moneyBalance, 2).ToString(); //label showing balance
            account_money.Font = balance_font;
            account_money.BackColor = backcolor;

            double stocks_balanceValue = 0;
            foreach(Companies c in Globals.portfolio_companies)
            {
                stocks_balanceValue += Globals.ReadInfo(c.Name, Globals.d) * c.Holdings;
            }
            
            stocks_balance.Text = "Stocks: $" + Math.Round(stocks_balanceValue, 2);
            stocks_balance.Font = balance_font;
            stocks_balance.BackColor = backcolor;

            double totalvalue = Math.Round(Globals.moneyBalance, 2) + stocks_balanceValue;

            total_balance.Text = "Total: $" + totalvalue;
            total_balance.Font = balance_font;
            total_balance.BackColor = backcolor;

            Thread addHoldings = new Thread(Add_holdings); addHoldings.Start(); //puts the label text changing as secondary task and changes
        }
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
            panel_sellOrders.Controls.Clear();
            cancel_sell.Clear(); //clears to reload
            company_sell.Clear();
            price_sell.Clear();
            amount_sell.Clear();
            sell_labels.Clear();

            PictureBox cancel; //declares cancel picturebox

            int i = 0;
            foreach (Orders o in Globals.sellOrders) //loop to show all the orders you have
            {
                //creates a label with the order company name
                company_sell.Add(Return_label(0, i + 1, o.Name, "label_company"));
                //adds name to panel
                panel_sellOrders.Controls.Add(company_sell[i]);
                //this helps to cancel order
                sell_labels.Add(company_sell[i]); 

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

            PictureBox cancel; //declares cancel picturebox

            int i = 0;
            foreach (Orders o in Globals.buyOrders) //loop to show all the orders you have
            {
                //creates a label and adds to a list
                company_buy.Add(Return_label(0, i + 1, Globals.buyOrders[i].Name, "label_company"));

                //adds name to panel
                panel_buyOrders.Controls.Add(company_buy[i]);

                //this helps to cancel order
                buy_labels.Add(company_buy[i]); 

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
            Reload_panel();
            Reload_buy();
            Reload_sell();

            Balance_label.Text = "Balance";
            Balance_label.Font = general_balance;
            Balance_label.Location = new Point(68, 81-60);
            Balance_label.BackColor = backcolor;

            Font fonts = portfolio_fonts;

            int x = 0;
            int y = 0;
            for (int i = 0; i < 141; i++)
            {
                Label label = new Label
                {
                    Text = "",
                    Font = fonts,
                    Name = x + "_name",
                    Tag = "tag",
                    AutoSize = true
                };

                switch (x)
                {
                    case 0:
                        label.Location = new Point(symbol_label.Location.X - 3, (symbol_label.Location.Y + 40) + 22 * y);
                        label.Name = y + "name";
                        label.DoubleClick += RedirectToTrade;
                        break;
                    case 1:
                        label.Location = new Point(Shares_label.Location.X, (Shares_label.Location.Y + 40) + 22 * y);
                        label.Name = y + "shares";
                        break;
                    case 2:
                        label.Location = new Point(price_label.Location.X, (price_label.Location.Y + 40) + 22 * y);
                        label.Name = y + "current";
                        break;
                    case 3:
                        label.Location = new Point(Cost_label.Location.X, (Cost_label.Location.Y + 40) + 22 * y);
                        label.Name = y + "cost";
                        break;
                    case 4:
                        label.Location = new Point(buyprice_label.Location.X, (buyprice_label.Location.Y + 40) + 22 * y);
                        label.Name = y + "bp";
                        break;
                    case 5:
                        label.Location = new Point(gainloss1_label.Location.X, (gainloss1_label.Location.Y + 40) + 22 * y);
                        label.Name = y + "glone";
                        break;
                    case 6:
                        label.Location = new Point(gainloss2_label.Location.X, (gainloss2_label.Location.Y + 40) + 22 * y);
                        label.Name = y + "gltwo";
                        break;
                }

                label.Tag = y;
                panel_portfolio.Controls.Add(label);

                x++;
                if (x == 7)
                {
                    x = 0;
                    y++;
                }
            }
            Add_holdings();
        }
        private void Add_holdings()
        {
            DateTime dates = Globals.d; 
            Font fonts = portfolio_fonts;

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
            if (Globals.portfolio_companies.Count != 0)
            {
                int y = 0;

                foreach (Companies cm in Globals.portfolio_companies)
                {
                    string close_Value = Globals.ReadInfo(cm.Name, dates).ToString();

                    foreach (Control ctl in panel_portfolio.Controls)
                    {
                        try
                        {
                            if (ctl.Tag.ToString() == y.ToString())
                            {
                                string name = "";
                                foreach (char c in ctl.Name)
                                {
                                    try
                                    {
                                        Int32.Parse(c.ToString());
                                    }
                                    catch (Exception)
                                    {
                                        name += c.ToString();
                                    }
                                }

                                double total_Cost = cm.Values * cm.Holdings;
                                double gainloss_Cost = Convert.ToDouble(close_Value) - cm.Values;
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
                                            
                                            ctl.Text = ((gainloss_Cost * cm.Holdings)<0 ? "-1":"") + "$" + Math.Round(Math.Abs((gainloss_Cost)*cm.Holdings), 2).ToString(); });
                                        break;

                                    case "gltwo":
                                        Invoke((MethodInvoker)delegate { ctl.Text = Math.Round((gainloss_Cost) / cm.Values * 100, 2).ToString() + "%"; });
                                        break;
                                }
                            }
                        }
                        catch (Exception) { }
                    }
                    y++;
                }

            }
        }

        public void Update_portfolio()
        {
            Reload_buy();
            Reload_sell();
            Reload_panel();
        }

        private void Paint_portfolio(object sender, PaintEventArgs e) //paints the portfolio chart
        {
            foreach (Control ctl in panel_portfolio.Controls) //draws the vertical lines of the chart
            {
                if (ctl.Tag.ToString() == "initial_label") //only draws on the initial labels
                {
                    Pen bp = new Pen(Color.Black, 1); //declares pen
                    Point p1 = new Point(ctl.Location.X - 5, ctl.Location.Y); //declares point 1
                    Point p2 = new Point(ctl.Location.X - 5, (gainloss2_label.Location.Y + 56) + 19 * 22); //declares point 2
                    e.Graphics.DrawLine(bp, p1, p2); //draws line
                }

            }

            //draws the last line
            Pen blackPen = new Pen(Color.Black, 1);
            Point point1 = new Point(gainloss2_label.Location.X + 77, gainloss2_label.Location.Y);
            Point point2 = new Point(gainloss2_label.Location.X + 77, (gainloss2_label.Location.Y + 56) + 19 * 22);
            e.Graphics.DrawLine(blackPen, point1, point2);
            //draws the first horizontal line
            Pen blapckPen = new Pen(Color.Black, 1);
            Point ppoint1 = new Point(gainloss2_label.Location.X + 77, gainloss2_label.Location.Y + 37);
            Point ppoint2 = new Point(symbol_label.Location.X - 5, gainloss2_label.Location.Y + 37);
            e.Graphics.DrawLine(blapckPen, ppoint1, ppoint2);

            for (int i = 0; i <= 21; i++) //draws the extra horizontal lines
            {
                Pen bPen = new Pen(Color.Black, 1);
                Point p1 = new Point(gainloss2_label.Location.X + 77, (gainloss2_label.Location.Y + 56) + i * 22);
                Point p2 = new Point(symbol_label.Location.X - 5, (gainloss2_label.Location.Y + 56) + i * 22);
                e.Graphics.DrawLine(bPen, p1, p2);
            }
        }

        private void Paint_table(object sender, PaintEventArgs e)
        {
            for (int i = 0; i < 4; i++)
            {
                Pen blackPen = new Pen(Color.Black, 1);
                Point point1 = new Point(10 + 60 * i, 0);
                Point point2 = new Point(10 + 60 * i, 25 * 6);
                e.Graphics.DrawLine(blackPen, point1, point2);

            }
            Pen blackPn = new Pen(Color.Black, 1);
            Point poin1 = new Point(10 + 180 + 20, 0);
            Point poit2 = new Point(10 + 180 + 20, 25 * 6);
            e.Graphics.DrawLine(blackPn, poin1, poit2);

            for (int i = 0; i < 6; i++)
            {
                Pen bp = new Pen(Color.Black, 1);
                Point p1 = new Point(10, 25 * (i + 1));
                Point p2 = new Point(210, 25 * (i + 1));
                e.Graphics.DrawLine(bp, p1, p2);
            }
            panel_buyOrders.Controls.Add(Return_label(0, 0, "Symbol", "company_name")); //shows labels that
            panel_buyOrders.Controls.Add(Return_label(60, 0, "Shares", "company_name")); //form the chart
            panel_buyOrders.Controls.Add(Return_label(125, 0, "Price", "company_name"));

            panel_sellOrders.Controls.Add(Return_label(0, 0, "Symbol", "company_name")); //shows labels that
            panel_sellOrders.Controls.Add(Return_label(60, 0, "Shares", "company_name")); //form the chart
            panel_sellOrders.Controls.Add(Return_label(125, 0, "Price", "company_name"));
        }

        Label Return_label(int locationx, int i, string text, string tag)
        {
            return new Label
            {
                Location = new Point(12 + locationx, 27 * (i)),
                Text = text,
                Font = new Font("Times New Roman", 9),
                Name = tag + i,
                Tag = "object_" + i,
                AutoSize = true
            };
        }

        private void CancelMethodBuy(object sender, EventArgs e)
        {
            RemoveOrderBuy(((Control)sender).Tag.ToString());

            Reload_buy();
        }

        private void CancelMethodSell(object sender, EventArgs e)
        {
            RemoveOrderSell(((Control)sender).Tag.ToString());

            Reload_panel();
            Reload_sell();

        }

        void RemoveOrderSell(string company)
        {
            int a = -1;

            for (int i = 0; i < sell_labels.Count; i++)
            {
                if (sell_labels[i].Tag.ToString() == company)
                {
                    a = i;
                }
            }
            if (a != -1)
            {
                panel_sellOrders.Controls.Remove(amount_sell[a]);
                panel_sellOrders.Controls.Remove(company_sell[a]);
                panel_sellOrders.Controls.Remove(price_sell[a]);
                panel_sellOrders.Controls.Remove(cancel_sell[a]);
                sell_labels.RemoveAt(a);
                amount_sell.RemoveAt(a);
                company_sell.RemoveAt(a);
                price_sell.RemoveAt(a);
                cancel_sell.RemoveAt(a);

                int index = -1;
                for (int i = 0; i < Globals.portfolio_companies.Count; i++)
                {
                    if (Globals.portfolio_companies[i].Name == Globals.sellOrders[a].Name)
                    {
                        index = i;
                    }

                }
                if (index != -1)
                {
                    Globals.portfolio_companies[index].Holdings += Globals.sellOrders[a].Holdings;
                    Globals.portfolio_companies[index].addValues(Globals.sellOrders[a].Holdings, Globals.sellOrders[a].OriginalPrice); 
                }
                else
                {
                    Globals.portfolio_companies.Add(
                        new Companies(Globals.sellOrders[a].Name, Globals.sellOrders[a].Holdings,Globals.sellOrders[a].OriginalPrice));
                }

                Globals.sellOrders.RemoveAt(a);
            }
        }

        void RemoveOrderBuy(string company)
        {
            int a = -1;

            for (int i = 0; i < buy_labels.Count; i++)
            {
                if (buy_labels[i].Tag.ToString() == company)
                {
                    a = i;

                }
            }
            if (a != -1)
            {
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