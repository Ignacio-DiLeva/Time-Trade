﻿using System;
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
        Font portfolio_fonts = new Font("Times New Roman", 9);


        Pen pencolor = new Pen(Constants.black, 1);



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

        List<string> buy_labels = new List<string>();

        List<string> sell_labels = new List<string>();

        public void Reload_panel()
        {
            PA.RedrawPanels();
        }

        //TO BE REMOVED
        private void RedirectToTrade(object sender, EventArgs e)
        {
            Globals.sideWatchlist.Searcher.SelectedIndex = Utilities.GetIndexOfCompany(((Control)sender).Text);
            Globals.main.ShowForm(Globals.main.TradeBtn,null);
            Hide();
            Globals.main.currentForm = "Trade";
            Globals.main.showLogo.Tag = Globals.main.currentForm;
        }

        public void Reload_sell()
        {
            //clears all the labels
            panel_sellOrders.Controls.Clear();
            sell_labels.Clear();

            //declares cancel picturebox
            PictureBox cancel; 

            int i = 0;
            //loop to show all the orders you have
            foreach (Order o in Globals.sellOrders) 
            {

                //adds name to panel
                panel_sellOrders.Controls.Add(Return_label(i, new Point(12, 30+ i*82), o.Name, "label_company"));
                //this helps to cancel order
                sell_labels.Add(Return_label(i, new Point(12, 30+i*82), o.Name, "label_company").Tag.ToString()); 

                //adds the amount of shares you order
                panel_sellOrders.Controls.Add(Return_label(i, new Point(302, 30 + i * 82), Convert.ToString(o.Holdings), "label_amount")); 

                //adds the price of shares you order
                panel_sellOrders.Controls.Add(Return_label(i, new Point(634, 30 + i * 82), "$" + Convert.ToString(o.Price), "label_price"));

                //cancel picturebox
                cancel = new PictureBox 
                {
                    Name = "cancel_" + (i),
                    Size = new Size(50, 50),
                    Location = new Point(818, 25 +82*i), //location depending on which line you are
                    Image = Properties.Resources.buttonx,
                    SizeMode = PictureBoxSizeMode.StretchImage,
                    Tag = "object_" + (i),
                };
                //adds the CancelMethod to the click action
                cancel.Click += CancelMethodSell;

                //adds to panel
                panel_sellOrders.Controls.Add(cancel);

                i++; //next order

            }
        }


        public void Reload_buy()
        {
            //clears to reload
            panel_buyOrders.Controls.Clear();

            buy_labels.Clear();

            //declares cancel picturebox
            PictureBox cancel; 

            int i = 0;
            //loop to show all the orders you have
            foreach (Order o in Globals.buyOrders) 
            {
                //adds name to panel
                //adds name to panel
                panel_buyOrders.Controls.Add(Return_label(i, new Point(12, 30 + i * 82), o.Name, "label_company"));
                //this helps to cancel order
                buy_labels.Add(Return_label(i, new Point(12, 30 + i * 82), o.Name, "label_company").Tag.ToString());

                //adds the amount of shares you order
                panel_buyOrders.Controls.Add(Return_label(i, new Point(302, 30 + i * 82), Convert.ToString(o.Holdings), "label_amount"));

                //adds the price of shares you order
                panel_buyOrders.Controls.Add(Return_label(i, new Point(634, 30 + i * 82),"$"+ Convert.ToString(o.Price), "label_price"));


                cancel = new PictureBox //cancel picturebox
                {
                    Name = "cancel_" + (i),
                    Size = new Size(50, 50),
                    Location = new Point(818, 25 + 82 * i), //location depending on which line you are                    
                    Image = Properties.Resources.buttonx,
                    SizeMode = PictureBoxSizeMode.StretchImage,
                    Tag = "object_" + (i),
                };

                //adds the CancelMethod to the click action 
                cancel.Click += CancelMethodBuy;

                //adds to panel
                panel_buyOrders.Controls.Add(cancel);

                i++;
            }
        }

        PortfolioAccount PA = new PortfolioAccount();

        public void OnLoad(object sender, EventArgs e)
        {
            PA.TopLevel = false;
            PA.Location = new Point(45, 128);
            Controls.Add(PA);
            PA.Show();
            PA.BringToFront();
            panel_buyOrders.Visible = false;
            panel_sellOrders.Visible = false;
            ordersHead.Visible = false;

            //reloads all panels to check changes
            Update_portfolio();

        }


        //method to update the portfolio from another form
        public void Update_portfolio()
        {
            Reload_buy();
            Reload_sell();
            Reload_panel();
        }


        //draw the lines of the orders panel
        private void Paint_table(object sender, PaintEventArgs e)
        {
            Pen bp = pencolor;
            Point p1;
            Point p2;


            for (int i = 0; i < 6; i++)
            {
                p1 = new Point(0, 82+ 82*i);
                p2 = new Point(884, 82+ 82*i);
                e.Graphics.DrawLine(bp, p1, p2);
            }

        }

        //default label creating method
        Label Return_label(int iteration, Point p, string text, string name)
        {
            return new Label
            {
                Location = p,
                Text = text,
                Font = new Font("Arial", 20),
                Name = name + iteration,
                Tag = "object_" + iteration,
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

                //removes it from the lists
                sell_labels.RemoveAt(a);


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

                buy_labels.RemoveAt(a);
                Globals.buyOrders.RemoveAt(a);
            }
        }

        public void ShowPortfolio(object sender, EventArgs e)
        {
            portfolioLabels.Visible = true;
            PA.Show();
            panel_buyOrders.Visible = false;
            panel_sellOrders.Visible = false;
            ordersHead.Visible = false;

            HighlightButton(sender);
            DehighButton(showBuyorders);
            DehighButton(showSellorders);


        }

        private void ShowBuyOrders(object sender, EventArgs e)
        {
            portfolioLabels.Visible = false;
            PA.Hide();
            panel_buyOrders.Visible = true;
            panel_sellOrders.Visible = false;
            ordersHead.Visible = true;

            HighlightButton(sender);
            DehighButton(showPortfolio);
            DehighButton(showSellorders);
        }

        private void ShowSellOrders(object sender, EventArgs e)
        {
            portfolioLabels.Visible = false;
            PA.Hide();
            panel_buyOrders.Visible = false;
            panel_sellOrders.Visible = true;
            ordersHead.Visible = true;

            HighlightButton(sender);
            DehighButton(showBuyorders);
            DehighButton(showPortfolio);
        }

        private void HighlightButton(object sender)
        {
            ((Control)sender).ForeColor = Color.White;
            ((Control)sender).BackColor = Constants.orange;
        }

        private void DehighButton(object sender)
        {
            ((Control)sender).ForeColor = Color.Black;
            ((Control)sender).BackColor = Constants.white;
        }



    }
}