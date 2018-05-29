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
            Size = new Size(975, 585),
            Location = new Point(0, 0),
            BackColor = Color.FromArgb(0,238,255),
        };

        public Trade()
        {
            InitializeComponent();
            Location = new Point(0, 90);
            Controls.Add(p);
            p.SendToBack();
        }

        private void OnLoad(object sender, EventArgs e)
        {
            label_balance.Text = Globals.moneyBalance.ToString();
        }

        void RefreshCanvas(object sender, EventArgs e)
        {
            Globals.sideWatchlist.Searcher.Enabled = false;
            btnPlaceOrder.Enabled = false;
            btnAdvanceInTime.Enabled = false;
            Globals.main.AllowInput(false);
            canvas.Controls.Clear();
            companyPrices.Text = null;
            makingTransition = true;
            //Disable all buttons and form switching
            Thread transition = new Thread(() => CanvasMovement(Convert.ToInt32(WeeksToAdd.Value)*7)); transition.Start();
        }

        public bool makingTransition=false;
        void CanvasMovement(int days)
        {
            if (!IsDisposed)
            {
                Invoke((MethodInvoker)delegate { EffectivizeOrders(Globals.today); }); //We check the orders
                for (int i = 0; i < days; i++) //For each day
                {
                    Invoke((MethodInvoker)delegate { Globals.sideWatchlist.UpdateBalance(); });
                    Globals.today = Globals.today.AddDays(1); //We add the day
                    Invoke((MethodInvoker)delegate //We invoke UI commands
                    {
                        Globals.sideWatchlist.UpdateCalendar(Globals.today); //We update the calendar
                        canvas.Refresh(); //We refresh the graphics
                    });
                    if (Globals.today == new DateTime(day: 31, month: 12, year: 2009)) //If it is the last day we scope out
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
                Invoke((MethodInvoker)delegate { Globals.sideWatchlist.UpdateBalance(); });

                if (Globals.today == new DateTime(day: 31, month: 12, year: 2009)) //If it is the last day
                {
                    EndGame(); //We end the game, server receives savedata as a newPlay
                    return;
                }
                //If it is not the last day we refresh UI and allow interaction (we can't allow interaction in the last day)
                Invoke((MethodInvoker)delegate //We Invoke UI commands
                {
                    btnAdvanceInTime.BackgroundImage = Properties.Resources.BOTON_NORMAL_2;
                    Globals.sideWatchlist.Searcher.Enabled = true;
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
            for (int i = 0; i < Globals.portfolio_companies.Count; i++)
            {
                SumOfTotal += Globals.portfolio_companies[i].Holdings * Utilities.ReadInfo(Globals.portfolio_companies[i].Name, Globals.today);
            }

            for (int i = 0; i < Globals.sellOrders.Count; i++)
            {
                SumOfTotal += Globals.sellOrders[i].Holdings * Utilities.ReadInfo(Globals.sellOrders[i].Name, Globals.today);
            }
            MessageBox.Show("Your final Balance is " + SumOfTotal);
            Thread sendEndMoney = new Thread(() => Globals.main.SendEndGame(Globals.main.username, Globals.main.sessid,SumOfTotal));
            sendEndMoney.Start(); sendEndMoney.Join();
            string newPlay = "AAPL:10000:1:6:2007#Empty:Empty:Empty:Empty:Empty:Empty:Empty:Empty:Empty:Empty:AAPL:AMZN:BA#AAPL:AMZN:BA:BBI:BBY:BP:C:CAT:DDAIF:F:INTC:JPM:KO:LEHMQ:MOT:MTLQQ.PK:S:SBUX:T:TRMP#############";
            Thread endGame = new Thread(() => Globals.main.SendSavedata(newPlay));
            endGame.Start();
        }

        public void EffectivizeOrders(DateTime date) //effectivizes every LIMIT ORDER by looping through each list
        {
            for (int i = 0; i < Globals.sellOrders.Count; i++) //loop through all the sell orders
            {

                int indice = -1; //default index

                for (int a = 0; a < Globals.portfolio_companies.Count; a++) //loops through companies
                {
                    if (Globals.portfolio_companies[a].Name == Globals.sellOrders[i].Name) //checks if the company is already in portfolio
                    {
                        indice = a; //gets the index of that company in portfolio
                    }
                }

                if (Globals.sellOrders[i].Date.AddDays(28) <= date) //if the company's order is already expired
                {

                    if (indice != -1) //if the company is already in the portfolio 
                    {
                        Globals.portfolio_companies[indice].Holdings += Globals.sellOrders[i].Holdings; //adds holdings
                        Globals.portfolio_companies[indice].AddValues(Globals.sellOrders[i].Holdings, Globals.sellOrders[i].OriginalPrice); //updates value of your holdings
                    }
                    else
                    {
                        Company cm = new Company(Globals.sellOrders[i].Name, Globals.sellOrders[i].Holdings, Globals.sellOrders[i].OriginalPrice); //creates a new company with the order's characteristics
                        Globals.portfolio_companies.Add(cm); //adds the company
                    }
                    Globals.sellOrders.RemoveAt(i); // removes the order
                    Invoke((MethodInvoker)delegate { Globals.account.Reload_sell(); }); //reloads the form
                }

                try
                {
                    double currentValue = Utilities.ReadInfo(Globals.sellOrders[i].Name, date); //the current value using the date time and company name
                    if (currentValue >= Globals.sellOrders[i].Price) //checks if the current value is higher than what you set the limit at
                    {
                        Globals.moneyBalance += Math.Round(currentValue * Globals.sellOrders[i].Holdings, 2); //adds the money you got to your balance multiplying the amount and the current value

                        Globals.sellOrders.RemoveAt(i); //removes the order
                        label_balance.Text = Globals.moneyBalance.ToString(); //changes the money balance
                        Invoke((MethodInvoker)delegate { Globals.account.Reload_sell(); }); //invokes another thread to reload the form
                        i--; //deleted the order, so we have to go back a index
                        continue;
                    }
                }
                catch (Exception)
                {
                    i--;
                }
            }
            for (int i = 0; i < Globals.buyOrders.Count; i++) //loops through the buy Orders
            {
                if (Globals.buyOrders[i].Date.AddDays(28) <= date) //checks if the order is expired
                {
                    Globals.buyOrders.RemoveAt(i); //removes the order

                    Invoke((MethodInvoker)delegate { Globals.account.Reload_buy(); }); //updates form
                }
                try
                {
                    double currentValue = Utilities.ReadInfo(Globals.buyOrders[i].Name, date);//value of that company

                    if (currentValue <= Globals.buyOrders[i].Price && Globals.moneyBalance - currentValue * Globals.buyOrders[i].Holdings >= 0) // checks if the price is below of the price you set and checks if you have enough money to buy
                    {
                        Globals.moneyBalance -= Math.Round(currentValue * Globals.buyOrders[i].Holdings); //subtracts the order from the balance

                        if (CheckIndex(Globals.buyOrders[i].Name, Globals.portfolio_companies) == -1) //checks if the company is already in portfolio
                        {
                            //if it's not in portfolio
                            Globals.portfolio_companies.Add(new Company(Globals.buyOrders[i].Name, Globals.buyOrders[i].Holdings, currentValue)); //adds the company with its name, the holdings and its current value
                        }
                        else //if it is in the portfolio
                        {
                            Globals.portfolio_companies[i].Holdings += Globals.buyOrders[i].Holdings; //adds the order holdings to  the portfolio in that index
                            Globals.portfolio_companies[i].AddValues(Globals.buyOrders[i].Holdings, currentValue); //updates values
                        }

                        Globals.buyOrders.RemoveAt(i); //removes the order
                        Invoke((MethodInvoker)delegate { Globals.account.Reload_buy(); }); //updates form

                    }
                }
                catch (Exception) //if it already expired
                {
                    i--; //go back a index because its deleted
                }
            }
        }

        public void ExternalCanvasRefresh(object sender, EventArgs e)
        {
            canvas.Refresh();
        }

        void AddReferenceToCanvas(int priceReference, double render)
        {
            Invoke((MethodInvoker)delegate 
            {
                companyPrices.Text = "$" 
                + Utilities.ReadInfo(Globals.displayedCompany, Globals.today) 
                + "     HIGH: $" + Utilities.ReadInfo(Globals.displayedCompany, Globals.today, "HIGH") 
                + "     LOW: $" + Utilities.ReadInfo(Globals.displayedCompany, Globals.today, "LOW");
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

                double[] getValues = new double[Constants.displayedDays];
                for (int i = 0; i < getValues.Length; i++)
                {
                    getValues[i] = Utilities.ReadInfo(Globals.displayedCompany, Globals.today.AddDays(-Constants.displayedDays + 1 + i));
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
                    e.Graphics.DrawLine(pen, 75 + i * (900 / Constants.displayedDays), rendered[i], 75 + (i + 1) * (900 / Constants.displayedDays), rendered[i + 1]);
                }
                int max = 0;
                for(int i = 0; i < 60; i++)
                {
                    if (Utilities.ReadInfo(Globals.displayedCompany, Globals.today.AddDays(-60 + i + 1), "VOLUME") > max) 
                    {
                        max = Convert.ToInt32(Math.Floor(Utilities.ReadInfo(Globals.displayedCompany, Globals.today.AddDays(-60 + i + 1), "VOLUME"))); //We get the volume maximum
                    }
                }
                for(int i = 0; i < getValues.Length; i++) //Foreach day
                {
                    e.Graphics.FillRectangle(new SolidBrush(Color.Gray), new Rectangle(new Point(70 + i * (900 / Constants.displayedDays), //We fill a rectangle

                    400-Convert.ToInt32(Math.Floor(Utilities.ReadInfo(Globals.displayedCompany,Globals.today.AddDays(-60+i+1),"VOLUME"))) //Location.Y
                    /(max/60)),

                    new Size(10, 400-Convert.ToInt32(Math.Floor(Utilities.ReadInfo(Globals.displayedCompany, Globals.today.AddDays(-60+i+1), "VOLUME"))) //Size
                    / (max / 60))));
                }
            }
            catch(Exception) {  }
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
            int Index_Stocks = CheckIndex(Globals.displayedCompany, Globals.portfolio_companies); //returns the index of the company selected in portfolio
            if (btnMarketSelected.Enabled == false && CheckConditions())  //Check if you want to do market or place limit
            {
                double currentValue = Utilities.ReadInfo(Globals.displayedCompany, Globals.today);
                if (btnBuySelected.Enabled == false) //check if you want to buy or sell
                {
                    if (Globals.moneyBalance - Convert.ToInt32(orderCount.Value) * currentValue >= 0) //check if you have the money to buy the amount of holdings
                    {
                        if (Index_Stocks == -1) //check if you have stocks of the company you want to buy
                        {
                            //adds a new company since you don't have stocks in it
                            Globals.portfolio_companies.Add(new Company(Globals.displayedCompany, Convert.ToInt32(orderCount.Value), currentValue));
                        }

                        else if (Index_Stocks != -1)
                        { 
                            //if you have stocks of the company
                            //returns position in list, adds amount of holdings bought
                            Globals.portfolio_companies[Index_Stocks].Holdings += Convert.ToInt32(orderCount.Value);

                            //updates value of holdings
                            Globals.portfolio_companies[Index_Stocks].AddValues(Convert.ToInt32(orderCount.Value), currentValue);
                        }
                        //subtract from balance
                        Globals.moneyBalance -= Convert.ToInt32(orderCount.Value) * currentValue; 
                        //update text
                        label_balance.Text = Convert.ToString(Globals.moneyBalance);
                        MessageBox.Show("Transaction complete");

                        Globals.account.Reload_panel(); //reloads the account panel
                    }
                    else { MessageBox.Show("You don't have enough money"); }

                }
                else if (btnSellSelected.Enabled == false) //when you want to sell
                {
                    //checks if you have holdings in that company
                    if (CheckIndex(Globals.displayedCompany, Globals.portfolio_companies) != -1)
                    {
                        //checks if you have enough holdings to sell
                        if (Convert.ToInt32(orderCount.Value) <= Globals.portfolio_companies[Index_Stocks].Holdings)
                        {
                            // adds to balance the value of stocks multiplied by the amount of stocks
                            Globals.moneyBalance += Convert.ToInt32(orderCount.Value) * Convert.ToDouble(currentValue);

                            //changes label
                            label_balance.Text = Convert.ToString(Globals.moneyBalance);

                            //subtracts amount of holdings
                            Globals.portfolio_companies[Index_Stocks].Holdings -= Convert.ToInt32(orderCount.Value); 
                            MessageBox.Show("Transaction complete");

                            //deletes if holdings get to 0
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
                    //check if the company is in the limit orders or not
                    int Index_BuyOrders = CheckIndex(Globals.displayedCompany, Globals.buyOrders); 
                    //limited to only 5 orders
                    if (Globals.buyOrders.Count < 5)
                    {
                        //if the company is in the list and the option is BUY, in other words, it updates the order
                        if (Index_BuyOrders != -1)  
                        {
                            //updates amount of holdings
                            Globals.buyOrders[Index_BuyOrders].Holdings = Convert.ToInt32(orderCount.Value);
                            
                            //updates value of holdings
                            Globals.buyOrders[Index_BuyOrders].Price = Convert.ToInt32(orderLimit.Value);

                            //updates date of order
                            Globals.buyOrders[Index_BuyOrders].Date = Globals.today;
                        }
                        else //if the company isn't inside of the limit orders
                        {
                            //adds a new company order
                            Globals.buyOrders.Add(new Order(Globals.displayedCompany, Convert.ToInt32(orderCount.Value), Convert.ToInt32(orderLimit.Value), Globals.today));
                        }
                        MessageBox.Show("Order placed");
                        Globals.account.Reload_buy();
                    
                    }
                    else MessageBox.Show("You have exceeded the amount of orders placeable");
                }
                //if you want to sell
                else if (btnSellSelected.Enabled == false) 
                {
                    //check if the company is in the limit orders or not
                    int IndexSell_Orders = CheckIndex(Globals.displayedCompany, Globals.sellOrders); 

                    //limited to 5 orders
                    if (Globals.sellOrders.Count < 5)
                    {
                        //checks if you have stocks in this company or else you can't put those stocks in sell order, 
                        //Index stocks checks if the selected company is in the portfolio
                        if (Index_Stocks != -1) 
                        {
                            //if the company is on the orders list and the buy option is SELL, update company
                            if (IndexSell_Orders != -1)  
                            {
                                //amount of holdings reservered to limit
                                int difference = Globals.portfolio_companies[Index_Stocks].Holdings - Convert.ToInt32(orderCount.Value);
                                //if you have enough holdings to place in limit, its the reserved holdings plus the holdings you have in hand
                                if (difference + Globals.sellOrders[IndexSell_Orders].Holdings >= 0) 
                                {
                                    //updates value of holdings
                                    Globals.sellOrders[Index_Stocks].AddValues(Globals.sellOrders[IndexSell_Orders].Holdings,Globals.portfolio_companies[Index_Stocks].Values);
                                    
                                    //adds the original holdings back to your amount of holdings and reserves some of them to limit
                                    Globals.portfolio_companies[Index_Stocks].Holdings += Globals.sellOrders[IndexSell_Orders].Holdings - Convert.ToInt32(orderCount.Value);

                                    //updates amount of holdings ordered
                                    Globals.sellOrders[IndexSell_Orders].Holdings = Convert.ToInt32(orderCount.Value);

                                    //updates prices of each holding
                                    Globals.sellOrders[IndexSell_Orders].Price = Convert.ToInt32(orderLimit.Value);

                                    //updates expiring date
                                    Globals.sellOrders[IndexSell_Orders].Date = Globals.today; 

                                    //removes index if holdings is 0
                                    Delete_index(Index_Stocks);

                                    MessageBox.Show("Order placed");

                                    //reloads panel
                                    Globals.account.Reload_sell();
                                    Globals.account.Reload_panel();
                                }
                                else
                                {
                                    MessageBox.Show("You don't have enough holdings to place as order");
                                }

                            }
                            //if the company isn't in the list of orders
                            else if (IndexSell_Orders == -1) 
                            {
                                //checks if you have enough holdings in that company
                                if (Globals.portfolio_companies[Index_Stocks].Holdings - Convert.ToInt32(orderCount.Value) >= 0) 
                                {
                                    //reserves these holdings to orders
                                    Globals.portfolio_companies[Index_Stocks].Holdings -= Convert.ToInt32(orderCount.Value);

                                    //adds the name, the amount of holdings to sell, the price of each holding, the date it was bought,
                                    // and the original value it had.
                                    Globals.sellOrders.Add(
                                        new Order(
                                            Globals.displayedCompany, 
                                            Convert.ToInt32(orderCount.Value), 
                                            Convert.ToInt32(orderLimit.Value),
                                            Globals.today, 
                                            Globals.portfolio_companies[Index_Stocks].Values)
                                            );
                                    
                                    //removes from portfolio if it doesn't have any holdings
                                    Delete_index(Index_Stocks);
                                    MessageBox.Show("Order placed");

                                    //reloads the panel
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
            Globals.sideWatchlist.UpdateBalance();
            ((Control)sender).BackgroundImage = Properties.Resources.BOTON_NORMAL_2;
            Focus();
        }
    

        void Delete_index(int index)
        {
            if (Globals.portfolio_companies[index].Holdings == 0) //if you don't have any holdings in this company, delete from list
            {
                Globals.portfolio_companies.RemoveAt(index);
            }
        }

        int CheckIndex(string company, List<Company> list) //Returns position of company in the list
        {
            if (list.Count != 0)
            {
                for (int i = 0; i < list.Count; i++)
                {
                    if (company == list[i].Name)
                    {
                        return i;
                    }
                }
            }
            return -1;
        }

        int CheckIndex(string company, List<Order> list) //Returns position of company in the list
        {
            if (list.Count != 0)
            {
                for (int i = 0; i < list.Count; i++)
                {
                    if (company == list[i].Name)
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