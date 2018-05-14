using System;
using System.Collections.Generic;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;
using MaterialSkin.Controls;

namespace mainSample
{
    public partial class Account : MaterialForm
    {
        PictureBox p = new PictureBox
        {
            Size = new Size(975, 600),
            Location = new Point(0, 64),
            BackColor = Color.FromArgb(0, 238, 255)
        };
        public Account(Point getLocation)
        {
            InitializeComponent();
            getLocation.X += 225;
            getLocation.Y += 125 - 64;
            Location = getLocation;
            Controls.Add(p);
            p.SendToBack();
        }

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
            Font balance_font = new Font("Lucida Calligraphy", 14);
            account_money.Text = "Money: $" + Math.Round(Globals.moneyBalance, 2).ToString(); //label showing balance
            account_money.Font = balance_font;
            account_money.BackColor = Color.FromArgb(0, 238, 255);

            double stocks_balanceValue = 0;
            for (int i = 0; i < Globals.company_name.Count; i++)
            {
                stocks_balanceValue += Globals.ReadInfo(Globals.company_name[i], Globals.d) * Globals.holdings[i];
            }
            stocks_balance.Text = "Stocks: $" + Math.Round(stocks_balanceValue, 2);
            stocks_balance.Font = balance_font;
            stocks_balance.BackColor = Color.FromArgb(0, 238, 255);

            double totalvalue = Math.Round(Globals.moneyBalance, 2) + stocks_balanceValue;
            total_balance.Text = "Total: $" + totalvalue;
            total_balance.Font = balance_font;
            total_balance.BackColor = Color.FromArgb(0, 238, 255);

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
            for (int i = 0; i < Globals.sell_company.Count; i++) //loop to show all the orders you have
            {
                company_sell.Add(Return_label(0, i + 1, Globals.sell_company[i], "label_company"));

                panel_sellOrders.Controls.Add(company_sell[i]); //adds name to panel

                sell_labels.Add(company_sell[i]); //this helps to cancel order

                amount_sell.Add(Return_label(60, i + 1, Convert.ToString(Globals.sell_holdings[i]), "label_amount"));

                panel_sellOrders.Controls.Add(amount_sell[i]); //adds the amount of shares you order

                price_sell.Add(Return_label(130, i + 1, Convert.ToString(Globals.sell_price[i]), "label_price"));

                panel_sellOrders.Controls.Add(price_sell[i]); //adds the price of shares you order

                cancel = new PictureBox //cancel picturebox
                {

                    Name = "cancel_" + (i + 1),
                    Size = new Size(15, 15),
                    Location = new Point(193, 27 * (i + 1)), //location depending on which line you are
                    Image = Properties.Resources.buttonx_j,
                    SizeMode = PictureBoxSizeMode.StretchImage,
                    Tag = "object_" + (i + 1),
                };

                cancel.Click += CancelMethodSell; //adds the CancelMethod to the click action 

                cancel_sell.Add(cancel); //adds top list
                panel_sellOrders.Controls.Add(cancel_sell[i]); //adds to panel

            }
        }


        public void Reload_buy()
        {
            panel_buyOrders.Controls.Clear();
            cancel_buy.Clear(); //clears to reload
            company_buy.Clear();
            price_buy.Clear();
            amount_buy.Clear();
            buy_labels.Clear();

            PictureBox cancel; //declares cancel picturebox


            for (int i = 0; i < Globals.buy_company.Count; i++) //loop to show all the orders you have
            {
                company_buy.Add(Return_label(0, i + 1, Globals.buy_company[i], "label_company"));

                panel_buyOrders.Controls.Add(company_buy[i]); //adds name to panel

                buy_labels.Add(company_buy[i]); //this helps to cancel order

                amount_buy.Add(Return_label(60, i + 1, Convert.ToString(Globals.buy_holdings[i]), "label_amount"));

                panel_buyOrders.Controls.Add(amount_buy[i]); //adds the amount of shares you order

                price_buy.Add(Return_label(130, i + 1, Convert.ToString(Globals.buy_price[i]), "label_price"));

                panel_buyOrders.Controls.Add(price_buy[i]); //adds the price of shares you order



                cancel = new PictureBox //cancel picturebox
                {
                    Name = "cancel_" + (i + 1),
                    Size = new Size(15, 15),
                    Location = new Point(195, 26 * (i + 1)), //location depending on which line you are
                    Image = Properties.Resources.buttonx_j,
                    SizeMode = PictureBoxSizeMode.StretchImage,
                    Tag = "object_" + (i + 1),
                };

                cancel.Click += CancelMethodBuy; //adds the CancelMethod to the click action 

                cancel_buy.Add(cancel); //adds top list
                panel_buyOrders.Controls.Add(cancel_buy[i]); //adds to panel

            }
        }


        public void OnLoad(object sender, EventArgs e)
        {
            Reload_panel();
            Reload_buy();
            Reload_sell();

            Balance_label.Text = "Balance";
            Balance_label.Font = new Font("Garamond", 24);
            Balance_label.Location = new Point(68, 81);
            Balance_label.BackColor = Color.FromArgb(0, 238, 255);

            Font fonts = new Font("Times New Roman", 9);

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
        /*
                public void reload_price()
                {
                    DateTime dates = new DateTime(2007, 1, 5); //CHANGE WHEN GLOBAL DATE IS HERE
                    if (Globals.holdings.Count != 0)
                    {
                        for (int i = 0; i < Globals.holdings.Count; i++)
                        {
                            //checks the current value of each company
                            string close_Value = Globals.ReadInfo(Globals.company_name[i], dates).ToString();
                            Label current = new Label
                            {

                                Location = new Point(price_label.Location.X, (price_label.Location.Y + 40) + 30 * i),
                                Text = "$" + close_Value,
                                Font = new Font("Times New Roman", 9),
                                Name = i + "_close",
                                Tag = "tag",
                                AutoSize = true
                            };
                            panel_portfolio.Controls.Add(current); //adds the label of the actual price
                        }
                    }
                }
         * */

        private void Add_holdings()
        {
            DateTime dates = Globals.d; //CHANGE WHEN GLOBAL DATE IS HERE
            Font fonts = new Font("Times New Roman", 9);

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
            if (Globals.company_name.Count != 0)
            {
                int y = 0;

                for (int i = 0; i < Globals.company_name.Count; i++)
                {

                    string close_Value = Globals.ReadInfo(Globals.company_name[i], dates).ToString();

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

                                switch (name)
                                {
                                    case "name":
                                        Invoke((MethodInvoker)delegate { ctl.Text = Globals.company_name[i]; });
                                        break;
                                    case "shares":
                                        Invoke((MethodInvoker)delegate { ctl.Text = Globals.holdings[i].ToString(); });
                                        break;

                                    case "current":
                                        Invoke((MethodInvoker)delegate { ctl.Text = close_Value; });
                                        break;

                                    case "cost":
                                        Invoke((MethodInvoker)delegate { ctl.Text = "$" + Math.Round(Globals.money_investedtotal[i], 2).ToString(); });
                                        break;

                                    case "bp":
                                        Invoke((MethodInvoker)delegate { ctl.Text = "$" + Math.Round((Globals.money_investedtotal[i] / Globals.holdings[i]), 2).ToString(); });
                                        break;

                                    case "glone":
                                        Invoke((MethodInvoker)delegate { ctl.Text = "$" + Math.Round(((Convert.ToDouble(close_Value) * Globals.holdings[i] - Globals.money_investedtotal[i])), 2).ToString(); });
                                        break;

                                    case "gltwo":
                                        Invoke((MethodInvoker)delegate { ctl.Text = Math.Round(((Convert.ToDouble(close_Value) * Globals.holdings[i] - Globals.money_investedtotal[i])) / Globals.money_investedtotal[i] * 100, 2).ToString() + "%"; });
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
                for (int i = 0; i < Globals.company_name.Count; i++)
                {
                    if (Globals.company_name[i] == Globals.sell_company[a])
                    {
                        index = i;
                    }

                }
                if (index != -1)
                {
                    Globals.holdings[index] += Globals.sell_holdings[a];
                    Globals.money_investedtotal[index] += Globals.original_price[a];
                }
                else
                {
                    Globals.company_name.Add(Globals.sell_company[a]);
                    Globals.money_investedtotal.Add(Globals.original_price[a]);
                    Globals.holdings.Add(Globals.sell_holdings[a]);
                }

                Globals.sell_company.RemoveAt(a);
                Globals.sell_holdings.RemoveAt(a);
                Globals.sell_price.RemoveAt(a);
                Globals.ExpireDateSell.RemoveAt(a);
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
                Globals.buy_company.RemoveAt(a);
                Globals.buy_holdings.RemoveAt(a);
                Globals.buy_price.RemoveAt(a);
                Globals.ExpireDateBuy.RemoveAt(a);
            }
        }
    }
}