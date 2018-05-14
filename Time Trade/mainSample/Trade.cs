using System; //For main commands
using System.Collections.Generic; //For Lists
using System.Drawing; //For Point, Color, ForeColor
using System.Threading;
using System.Windows.Forms; //For Windows Controls

namespace mainSample
{
    public partial class Trade : Form
    {
        //▲ ▼//  Samples
        PictureBox p = new PictureBox
        {
            Size = new Size(975, 600),
            Location = new Point(0, 0),
            BackColor = Color.FromArgb(0,238,255),
        };

        public Trade()
        {
            InitializeComponent();
            Location = new Point(225, 70);
            Controls.Add(p);
            p.SendToBack();
        }

        private void OnLoad(object sender, EventArgs e)
        {
            for(int i=0;i<Globals.companies.Count;i++)
            {
                Searcher.Items.Add(Globals.companies[i]+" ("+Globals.stockInfo[i,0]+")");
            }
            displayedCompany.Text = Globals.displayedCompany;
            Searcher.Text = Globals.displayedCompany + " ("+Globals.stockInfo[Globals.GetIndexOfCompany(Globals.displayedCompany),0]+")";
            label_balance.Text = Globals.moneyBalance.ToString();
        }

        void RefreshCanvas(object sender, EventArgs e)
        {
            ((Control)sender).BackgroundImage = Properties.Resources.BOTON_APRETADO_2;
            Searcher.Enabled = false;
            btnPlaceOrder.Enabled = false;
            btnAdvanceInTime.Enabled = false;
            Globals.main.AllowInput(false);
            canvas.Controls.Clear();
            companyPrices.Text = null;
            makingTransition = true;
            //Disable all buttons and form switching
            Thread transition = new Thread(() => CanvasMovement(Convert.ToInt32(WeeksToAdd.Value)*7)); transition.Start();
        }

        bool makingTransition=false;
        void CanvasMovement(int days)
        {
            if (!IsDisposed)
            {
                Invoke((MethodInvoker)delegate { EffectivizeOrders(Globals.d); }); //We check the orders
                for (int i = 0; i < days; i++) //For each day
                {
                    Globals.d = Globals.d.AddDays(1); //We add the day
                    Invoke((MethodInvoker)delegate //We invoke UI commands
                    {
                        Globals.sideWatchlist.UpdateCalendar(Globals.d); //We update the calendar
                        canvas.Refresh(); //We refresh the graphics
                    });
                    if (Globals.d == new DateTime(day: 31, month: 12, year: 2009)) //If it is the last day we scope out
                    {
                        break;
                    }
                    if (i != days - 1) //If it is the last day we do not sleep
                    {
                        Thread.Sleep(Convert.ToInt32((7.00 / Convert.ToDouble(days)) * 1000)); //Else we sleep
                    }
                }
                makingTransition = false; //We end the transition
                Invoke((MethodInvoker)delegate { canvas.Refresh(); });
                
                if (Globals.d == new DateTime(day: 31, month: 12, year: 2009)) //If it is the last day
                {
                    EndGame(); //We end the game, server receives savedata as a newPlay
                    return;
                }
                //If it is not the last day we refresh UI and allow interaction (we can't allow interaction in the last day)
                Invoke((MethodInvoker)delegate //We Invoke UI commands
                {
                    btnAdvanceInTime.BackgroundImage = Properties.Resources.BOTON_NORMAL_2;
                    Searcher.Enabled = true;
                    btnPlaceOrder.Enabled = true;
                    btnAdvanceInTime.Enabled = true;
                    Globals.main.AllowInput(true);
                    Globals.watchlist.ExternalCanvasRefresh(this, null); //Refresh graphics
                    Globals.account.Reload_panel(); //Refresh graphics
                    Globals.stock.UpdateCompanyData(); //Refreshes data
                    Focus();
                });
            }
        }

        public void EndGame()
        {
            double SumOfTotal = Globals.moneyBalance;
            for (int i = 0; i < Globals.company_name.Count; i++)
            {
                SumOfTotal += Globals.holdings[i] * Globals.ReadInfo(Globals.company_name[i], Globals.d);
            }

            for (int i = 0; i < Globals.sell_company.Count; i++)
            {
                SumOfTotal += Globals.sell_holdings[i] * Globals.ReadInfo(Globals.sell_company[i], Globals.d);
            }
            MessageBox.Show("Your final Balance is " + SumOfTotal);
            Thread sendEndMoney = new Thread(() => Globals.main.SendEndGame(Globals.main.username, Globals.main.sessid,SumOfTotal));
            sendEndMoney.Start(); sendEndMoney.Join();
            string newPlay = "AAPL:10000:1:6:2007#Empty:Empty:Empty:Empty:Empty:Empty:Empty:Empty:Empty:Empty:AAPL:AMZN:BA#AAPL:AMZN:BA:BBI:BBY:BP:C:CAT:DDAIF:F:INTC:JPM:KO:LEHMQ:MOT:MTLQQ.PK:S:SBUX:T:TRMP#############";
            Thread endGame = new Thread(() => Globals.main.SendSavedata(newPlay));
            endGame.Start();
        }

        public void EffectivizeOrders(DateTime date)
        {
            for (int i = 0; i < Globals.sell_company.Count; i++)
            {
                if (Globals.ReadInfo(Globals.sell_company[i], date) >= Globals.sell_price[i])
                {
                    Globals.moneyBalance += Math.Round(Globals.ReadInfo(Globals.sell_company[i], date) * Globals.sell_holdings[i], 2);

                    Globals.sell_company.RemoveAt(i);
                    Globals.sell_holdings.RemoveAt(i);
                    Globals.sell_price.RemoveAt(i);
                    Globals.original_price.RemoveAt(i);
                    label_balance.Text = Globals.moneyBalance.ToString();
                    Invoke((MethodInvoker)delegate { Globals.account.Reload_sell(); });
                    i--;
                    continue;
                }
                int indice = -1;

                for (int a = 0; a < Globals.company_name.Count; a++)
                {
                    if (Globals.company_name[a] == Globals.sell_company[i])
                    {
                        indice = a;
                    }
                }

                if (Globals.ExpireDateSell[i].AddDays(28) == date)
                {

                    if (indice != -1)
                    {
                        Globals.holdings[indice] += Globals.sell_holdings[i];
                    }
                    else
                    {
                        Globals.company_name.Add(Globals.sell_company[i]);
                        Globals.money_investedtotal.Add(Globals.original_price[i]);
                        Globals.holdings.Add(Globals.sell_holdings[i]);
                    }
                    Globals.sell_company.RemoveAt(i);
                    Globals.sell_holdings.RemoveAt(i);
                    Globals.sell_price.RemoveAt(i);
                    Invoke((MethodInvoker)delegate { Globals.account.Reload_sell(); });
                }

            }
            for (int i = 0; i < Globals.buy_company.Count; i++)
            {
                if (Globals.ReadInfo(Globals.buy_company[i], date) <= Globals.buy_price[i] && Globals.moneyBalance - Globals.ReadInfo(Globals.buy_company[i], date) * Globals.buy_holdings[i] >= 0)
                {
                    Globals.moneyBalance -= Math.Round(Globals.ReadInfo(Globals.buy_company[i], date) * Globals.buy_holdings[i]);

                    if (CheckIndex(Globals.buy_company[i], Globals.company_name) == -1)
                    {
                        Globals.company_name.Add(Globals.buy_company[i]);
                        Globals.holdings.Add(Globals.buy_holdings[i]);
                        Globals.money_investedtotal.Add(Globals.buy_holdings[i] * Globals.ReadInfo(Globals.buy_company[i], date));
                    }
                    else
                    {
                        Globals.holdings[CheckIndex(Globals.buy_company[i], Globals.company_name)] += Globals.buy_holdings[i];
                        Globals.money_investedtotal[CheckIndex(Globals.buy_company[i], Globals.company_name)] += Globals.buy_holdings[i] * Globals.ReadInfo(Globals.buy_company[i], date);
                    }

                    Globals.buy_company.RemoveAt(i);
                    Globals.buy_holdings.RemoveAt(i);
                    Globals.buy_price.RemoveAt(i);
                    Invoke((MethodInvoker)delegate { Globals.account.Reload_buy(); });

                }

                if (Globals.ExpireDateBuy[i].AddDays(28) == date)
                {
                    Globals.buy_company.RemoveAt(i);
                    Globals.buy_holdings.RemoveAt(i);
                    Globals.buy_price.RemoveAt(i);

                    Invoke((MethodInvoker)delegate { Globals.account.Reload_buy(); });
                }
            }
        }

        public void ExternalCanvasRefresh(object sender, EventArgs e)
        {
            Globals.displayedCompany = displayedCompany.Text;
            if (!makingTransition)
            {
                canvas.Refresh();
                Globals.account.Update_portfolio();
            }
            
        }

        void AddReferenceToCanvas(int priceReference, double render)
        {
            Invoke((MethodInvoker)delegate 
            {
                companyPrices.Text = "$" 
                + Globals.ReadInfo(displayedCompany.Text, Globals.d) 
                + "     HIGH: $" + Globals.ReadInfo(displayedCompany.Text, Globals.d, "HIGH") 
                + "     LOW: $" + Globals.ReadInfo(displayedCompany.Text, Globals.d, "LOW");
            });
            renderingLabels = true;
            Invoke((MethodInvoker)delegate { canvas.Controls.Clear(); });
            int pixel = 0; //Pixel to be check (needs label or not)
            double price = 1; //The price between the last pixel and the actual pixel
            int lastPixel = -20; //Last pixel (starts at -20 so first pixel gets labeled)
            for (;;pixel++) //Foreach pixel
            {
                if (price >=1) //If we completed a whole integer 
                {
                    if(pixel - 20 >= lastPixel) //If we are far enough from the last label
                    {
                        Label l = new Label() //We create a new label
                        {
                            Name = "R" + priceReference,
                            Location = new Point(0, 315 - pixel),
                            Font = new Font("Microsoft Sans Serif", emSize: 8),
                            AutoSize = false,
                            Size = new Size(75, 20),
                            Text = "$" + priceReference, //Label reference
                            BackColor = canvas.BackColor,
                            TextAlign = ContentAlignment.MiddleRight
                        };
                        l.Resize += RefreshCanvas; //We give it a handler so it doesn't get lost
                        Invoke((MethodInvoker)delegate { canvas.Controls.Add(l); }); //We add it
                        Invoke((MethodInvoker)delegate { l.BringToFront(); }); //Weshow it
                        lastPixel = pixel; //We update the last pixel
                        if (lastPixel >= 290) //If we are up enough we break
                        {
                            break;
                        }
                    }
                    priceReference++; //Next reference will be +$1
                    price--; //When we get the integer difference we add label and substract 1
                }
                price += render; //We add the reference to the price difference between labels
            }
            Invoke((MethodInvoker)delegate { canvas.Refresh(); });
            renderingLabels = false;
        }

        bool renderingLabels = false;
        private void CanvasPaint(object sender, PaintEventArgs e)
        {
            try
            {
                Globals.sideWatchlist.UpdateWatchlistData();
                e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
                Pen pen = new Pen(Color.Black, 1);
                //START MATH FOR GRAPH

                double[] getValues = new double[Globals.displayedDays];
                for (int i = 0; i < getValues.Length; i++)
                {
                    getValues[i] = Globals.ReadInfo(displayedCompany.Text, Globals.d.AddDays(-Globals.displayedDays + 1 + i));
                }
                double tempMin = 400, tempMax = 0;
                for (int i = 0; i < getValues.Length; i++)
                {
                    if (getValues[i] < tempMin && getValues[i] != -1)
                    {
                        tempMin = getValues[i];
                    }
                    if (getValues[i] > tempMax && getValues[i] != -1)
                    {
                        tempMax = getValues[i];
                    }
                }
                int minimum = Convert.ToInt32(Math.Floor(tempMin));
                int maximum = Convert.ToInt32(Math.Ceiling(tempMax));
                double render = (maximum - minimum) / Convert.ToDouble(300);
                if (!renderingLabels && !makingTransition)
                {
                    Thread references = new Thread(() => AddReferenceToCanvas(minimum, render)); references.Start();
                }

                int[] rendered = new int[getValues.Length];
                for (int i = 0; i < rendered.Length; i++) //Foreach value within 60 days
                {
                    double doubledMinimum = minimum; //We get the minimum
                    int count = 325; //We count from 325 
                    double value = getValues[i]; //We get the i-th day
                    while (doubledMinimum + render <= value) //While value < price
                    {
                        count--; //We add 1 to the pixel location
                        doubledMinimum += render; //We close the value to the actual price

                    }
                    rendered[i] = count; //Value is rendered within the 60 days (Location.Y)
                }

                //We draw the lines obtained at the rendering process
                foreach (Control ctl in ((Panel)sender).Controls) //Foreach indicator
                {
                    Pen gPen = new Pen(Color.Gray, 1);
                    e.Graphics.DrawLine(gPen, new Point(50, ctl.Location.Y+10), new Point(975, ctl.Location.Y+10)); //We draw a line that indicates the Label location
                }
                for (int i = 0; i < getValues.Length - 1; i++) //Foreach value within 60 days
                { //We connect it with the next one
                    e.Graphics.DrawLine(pen, 75 + i * (900 / Globals.displayedDays), rendered[i], 75 + (i + 1) * (900 / Globals.displayedDays), rendered[i + 1]);
                }
                int max = 0;
                for(int i = 0; i < 60; i++)
                {
                    if (Globals.ReadInfo(displayedCompany.Text, Globals.d.AddDays(-60 + i + 1), "VOLUME") > max) 
                    {
                        max = Convert.ToInt32(Math.Floor(Globals.ReadInfo(displayedCompany.Text, Globals.d.AddDays(-60 + i + 1), "VOLUME"))); //We get the volume maximum
                    }
                }
                for(int i = 0; i < getValues.Length; i++) //Foreach day
                {
                    e.Graphics.FillRectangle(new SolidBrush(Color.Gray), new Rectangle(new Point(70 + i * (900 / Globals.displayedDays), //We fill a rectangle

                    400-Convert.ToInt32(Math.Floor(Globals.ReadInfo(displayedCompany.Text,Globals.d.AddDays(-60+i+1),"VOLUME"))) //Location.Y
                    /(max/60)),

                    new Size(10, 400-Convert.ToInt32(Math.Floor(Globals.ReadInfo(displayedCompany.Text, Globals.d.AddDays(-60+i+1), "VOLUME"))) //Size
                    / (max / 60))));
                }
            }
            catch(Exception) {  }
        }

        private void CheckChangeOnSearcher(object sender, EventArgs e)
        {
            displayedCompany.Text = ((Control)sender).Text.Split(' ')[0];
            displayedCompany.Tag = Globals.GetIndexOfCompany(displayedCompany.Text);
        }

        private void OrderSelection(object sender, EventArgs e)
        {
            string btn = ((Button)sender).Text;
            if (btn == "BUY")
            {
                btnBuySelected.Enabled = false;
                btnBuySelected.BackgroundImage = Properties.Resources.BOTON_APRETADO_2;
                btnSellSelected.Enabled = true;
                btnSellSelected.BackgroundImage = Properties.Resources.BOTON_NORMAL_2;
                Focus();
                return;
            }
            if (btn == "SELL")
            {
                btnBuySelected.Enabled = true;
                btnBuySelected.BackgroundImage = Properties.Resources.BOTON_NORMAL_2;
                btnSellSelected.Enabled = false;
                btnSellSelected.BackgroundImage = Properties.Resources.BOTON_APRETADO_2;
                Focus();
                return;
            }
            if (btn == "MARKET")
            {
                btnMarketSelected.Enabled = false;
                btnMarketSelected.BackgroundImage = Properties.Resources.BOTON_APRETADO_2;
                btnLimitSelected.Enabled = true;
                btnLimitSelected.BackgroundImage = Properties.Resources.BOTON_NORMAL_2;
                orderLimit.Value = 0;
                orderLimit.Enabled = false;
                Focus();
                return;
            }
            if (btn == "LIMIT")
            {
                btnMarketSelected.Enabled = true;
                btnMarketSelected.BackgroundImage = Properties.Resources.BOTON_NORMAL_2;
                btnLimitSelected.Enabled = false;
                btnLimitSelected.BackgroundImage = Properties.Resources.BOTON_APRETADO_2;
                orderLimit.Enabled = true;
                Focus();
                return;
            }
        }
        private void PlaceOrder(object sender, EventArgs e) //For placing orders
        {
            ((Control)sender).BackgroundImage = Properties.Resources.BOTON_APRETADO_2;
            int Index_Stocks = CheckIndex(displayedCompany.Text, Globals.company_name);
            if (btnMarketSelected.Enabled == false && CheckConditions())  //Check if you want to do market or place limit
            {
                if (btnBuySelected.Enabled == false) //check if you want to buy or sell
                {
                    if (Globals.moneyBalance - Convert.ToInt32(orderCount.Value) * Convert.ToDouble(Globals.ReadInfo(displayedCompany.Text, Globals.d)) >= 0) //check if you have the money to buy the amount of holdings
                    {
                        if (Index_Stocks == -1) //check if you have stocks of the company you want to buy
                        {
                            // if you don't have stocks of this company
                            Globals.company_name.Add(displayedCompany.Text); //add name of company
                            Globals.holdings.Add(Convert.ToInt32(orderCount.Value)); //add amount of holdings
                            Globals.money_investedtotal.Add(Convert.ToInt32(orderCount.Value) * Convert.ToDouble(Globals.ReadInfo(displayedCompany.Text, Globals.d))); //add amount of money invested

                        }
                        else if (Index_Stocks != -1)
                        { //if you have stocks of the company
                            Globals.holdings[Index_Stocks] += Convert.ToInt32(orderCount.Value); //returns position in list, adds amount of holdings bought
                            Globals.money_investedtotal[Index_Stocks] += Convert.ToInt32(orderCount.Value) * Convert.ToDouble(Globals.ReadInfo(displayedCompany.Text, Globals.d)); //returns position in list, adds amount of money invested
                        }
                        Globals.moneyBalance -= Convert.ToInt32(orderCount.Value) * Convert.ToDouble(Globals.ReadInfo(displayedCompany.Text, Globals.d));//subtract from balance
                        label_balance.Text = Convert.ToString(Globals.moneyBalance);
                        MessageBox.Show("Transaction complete");

                        Globals.account.Reload_panel();
                    }
                    else { MessageBox.Show("You don't have enough money"); }

                }
                else if (btnSellSelected.Enabled == false) //when you want to sell
                {

                    if (CheckIndex(displayedCompany.Text, Globals.company_name) != -1) //checks if you have holdings in that company
                    {
                        if (Convert.ToInt32(orderCount.Value) <= Globals.holdings[Index_Stocks])//checks if you have enough holdings to sell
                        {
                            Globals.moneyBalance += Convert.ToInt32(orderCount.Value) * Convert.ToDouble(Globals.ReadInfo(displayedCompany.Text, Globals.d)); // adds the value of the stocks multiplied by the amount of stocks
                            Globals.money_investedtotal[Index_Stocks] -= (Convert.ToDouble(orderCount.Value) * Convert.ToDouble(Globals.money_investedtotal[Index_Stocks] / Convert.ToDouble(Globals.holdings[Index_Stocks]))); //subtracts the money invested
                            label_balance.Text = Convert.ToString(Globals.moneyBalance);//changes label
                            Globals.holdings[Index_Stocks] -= Convert.ToInt32(orderCount.Value); //subtracts amount of holdings
                            MessageBox.Show("Transaction complete");

                            Delete_index(Index_Stocks);

                            Globals.account.Reload_panel();

                        }
                        else { MessageBox.Show("You don't have enough holdings"); }
                    }
                    else { MessageBox.Show("You don't have holdings in this company"); }


                }
            }
            else if (btnLimitSelected.Enabled == false && CheckConditions(Convert.ToInt32(orderLimit.Value)))
            {
                //check if the company is in the
                if (btnBuySelected.Enabled == false) //if the buy option for limit is clicked
                {
                    int Index_BuyOrders = CheckIndex(displayedCompany.Text, Globals.buy_company); //check if the company is in the limit orders or not
                    if (Globals.buy_company.Count < 5)
                    {
                        if (Index_BuyOrders != -1)  //if the company is in the list and the option is BUY, in other words, it updates the order
                        {
                            Globals.buy_holdings[Index_BuyOrders] = Convert.ToInt32(orderCount.Value); //changes value and amount of holdings 
                            Globals.buy_price[Index_BuyOrders] = Convert.ToInt32(orderLimit.Value); //""
                            Globals.ExpireDateBuy[Index_BuyOrders] = Globals.d;
                        }
                        else //if the company isn't inside of the limit orders
                        {
                            Globals.buy_holdings.Add(Convert.ToInt32(orderCount.Value)); //adds amount of holdings wanted
                            Globals.buy_price.Add(Convert.ToInt32(orderLimit.Value)); //adds price of the holding
                            Globals.buy_company.Add(displayedCompany.Text); //adds company name
                            Globals.ExpireDateBuy.Add(Globals.d);
                        }
                        MessageBox.Show("Order placed");
                        Globals.account.Reload_buy();
                    }
                    else MessageBox.Show("You have exceeded the amount of orders placeable");
                }
                else if (btnSellSelected.Enabled == false) //if you want to sell
                {

                    int IndexSell_Orders = CheckIndex(displayedCompany.Text, Globals.sell_company); //check if the company is in the limit orders or not
                    if (Globals.sell_company.Count < 5)
                    {
                        if (Index_Stocks != -1) //checks if you have stocks in this company
                        {
                            if (IndexSell_Orders != -1)  //if the company is on the list and the buy option is SELL, update company
                            {
                                int difference = Globals.holdings[Index_Stocks] - Convert.ToInt32(orderCount.Value); //amount of holdings reservered to limit
                                if (difference + Globals.sell_holdings[IndexSell_Orders] >= 0) //if you have enough holdings to place in limit
                                {
                                    Globals.money_investedtotal[Index_Stocks] += Globals.original_price[IndexSell_Orders];
                                    Globals.money_investedtotal[Index_Stocks] -= Math.Round(Globals.money_investedtotal[Index_Stocks], 2) / Globals.holdings[Index_Stocks] * Convert.ToInt32(orderCount.Value);
                                    Globals.original_price[IndexSell_Orders] = Math.Round(Globals.money_investedtotal[Index_Stocks], 2) / Globals.holdings[Index_Stocks] * Convert.ToInt32(orderCount.Value);
                                    Globals.holdings[Index_Stocks] += Globals.sell_holdings[IndexSell_Orders] - Convert.ToInt32(orderCount.Value); //adds the original holdings back to your amount of holdings and reserves some of them to limit
                                    Globals.sell_holdings[IndexSell_Orders] = Convert.ToInt32(orderCount.Value); //updates amount of holdings ordered
                                    Globals.sell_price[IndexSell_Orders] = Convert.ToInt32(orderLimit.Value);//updates prices of each holding
                                    Globals.ExpireDateSell[IndexSell_Orders] = Globals.d; //updates expiring date
                                    Delete_index(Index_Stocks);

                                    MessageBox.Show("Order placed");
                                    Globals.account.Reload_sell();
                                    Globals.account.Reload_panel();
                                }
                                else
                                {
                                    MessageBox.Show("You don't have enough holdings to place as order");
                                }
                                // }
                                // else MessageBox.Show("You don't have holdings in this company");

                            }
                            else if (IndexSell_Orders == -1) //if the company isn't in the list
                            {

                                if (Globals.holdings[Index_Stocks] - Convert.ToInt32(orderCount.Value) >= 0) //if you have enough holdings to sell
                                {
                                    Globals.money_investedtotal[Index_Stocks] -= Math.Round(Globals.money_investedtotal[Index_Stocks], 2) / Globals.holdings[Index_Stocks] * Convert.ToInt32(orderCount.Value);
                                    Globals.original_price.Add(Math.Round(Globals.money_investedtotal[Index_Stocks], 2) / Globals.holdings[Index_Stocks] * Convert.ToInt32(orderCount.Value));
                                    Globals.holdings[Index_Stocks] -= Convert.ToInt32(orderCount.Value); //reserves these holdings to orders
                                    Globals.sell_holdings.Add(Convert.ToInt32(orderCount.Value)); //adds amount of holdings
                                    Globals.sell_price.Add(Convert.ToInt32(orderLimit.Value));//adds price of each holding
                                    Globals.sell_company.Add(displayedCompany.Text); //adds company name
                                    Globals.ExpireDateSell.Add(Globals.d); //adds expired date
                                    Delete_index(Index_Stocks);
                                    MessageBox.Show("Order placed");
                                    Globals.account.Reload_sell();
                                    Globals.account.Reload_panel();
                                }
                                else MessageBox.Show("You don't have enough holdings to sell");

                            }
                        }
                        else MessageBox.Show("You don't have holdings in this company");
                    }
                    else MessageBox.Show("You have exceeded the amount of orders placeable");
                }
            }
            ((Control)sender).BackgroundImage = Properties.Resources.BOTON_NORMAL_2;
            Focus();
        }
    

        void Delete_index(int index)
        {
            if (Globals.holdings[index] == 0) //if you don't have any holdings in this company, delete from list
            {
                Globals.holdings.RemoveAt(index);
                Globals.company_name.RemoveAt(index);
                Globals.money_investedtotal.RemoveAt(index);
            }
        }

        int CheckIndex(string company, List<string> list) //Returns position of company in the list
        {
            if (list.Count != 0)
            {
                for (int i = 0; i < list.Count; i++)
                {
                    if (company == list[i])
                    {
                        return i;
                    }
                }
            }
            return -1;
        }

        bool CheckConditions(int b = 1) //Checks if ComboBoxes have non-zero values
        {
            if (Convert.ToInt32(orderCount.Value) != 0 && b != 0)
            {
                return true;
            }
            return false;
        }

        private void RequestBestPlayers(object sender, EventArgs e)
        {
            ((Control)sender).Enabled = false;
            Thread request = new Thread(() => Globals.main.GetBestPlayers());
            request.Start();
        }
    }
}