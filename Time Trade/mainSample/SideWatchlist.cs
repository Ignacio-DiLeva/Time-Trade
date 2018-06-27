using System;
using System.Drawing;
using System.Windows.Forms;
using System.Threading;
using System.Linq;

namespace mainSample
{
    public partial class SideWatchlist : Form
    {
        public SideWatchlist()
        {
            InitializeComponent();
            Location = new Point(975, 20);
            calendarLabel.TextChanged += Globals.main.HandleUpdateInfo;
        }

        private void OnLoad(object sender, EventArgs e)
        {
            addingToWatchlist = false;
            for (int i = 0; i < Constants.companies.Count; i++)
            {
                Searcher.Items.Add(Constants.companies[i]);
            }
            Globals.main.displayedCompany.Text = Globals.displayedCompany;
            Searcher.Text = Globals.displayedCompany;
            UpdateCalendar(Globals.today);
            UpdateWatchlistData();
            UpdateBalance();
        }

        ComboBox cb; //ComboBox to be displayed when adding a company to the watchlist
        bool addingToWatchlist; //Evades replication of companies in the watchlist
        private void RequestAdditionIntoWatchlist(object sender, EventArgs e)
        {
            if (Globals.watchlistData[Int32.Parse(((Control)sender).Name.ToString()[9].ToString()), 0] == "Empty" && !addingToWatchlist)
            {
                cb = new ComboBox
                {
                    Location = ((Control)sender).Location,
                    Size = ((Control)sender).Size,
                    AutoCompleteMode = AutoCompleteMode.SuggestAppend,
                    AutoCompleteSource = AutoCompleteSource.ListItems,
                    Tag = Int32.Parse(((Control)sender).Name.ToString()[9].ToString())
                };
                foreach (string str in Globals.wlAvailableCompanies)
                {
                    cb.Items.Add(str);
                }
                cb.SelectedIndexChanged += WatchlistAddSelection;
                Controls.Add(cb);
                cb.BringToFront();
                cb.Focus();
                addingToWatchlist = true;
            }
        }

        private void WatchlistAddSelection(object sender, EventArgs e)
        {
            Globals.wlAvailableCompanies.Remove(((ComboBox)sender).SelectedItem.ToString());
            addingToWatchlist = false;
            Globals.watchlistData[Convert.ToInt32(((Control)sender).Tag),0] = ((ComboBox)sender).SelectedItem.ToString();
            Controls.Remove(cb);
            UpdateWatchlistData();
        }

        private void RemoveFromWatchlist(object sender, EventArgs e)
        {
            int pos = Int32.Parse(((Control)sender).Name[5].ToString());
            Globals.wlAvailableCompanies.Add(Globals.watchlistData[pos,0]);
            Globals.wlAvailableCompanies.Sort();
            Globals.watchlistData[pos,0] = "Empty";
            UpdateWatchlistData();
        }

        public void UpdateWatchlistData() //Updates the side-watchlist
        {
            for(int i = 0; i < 10; i++) //Foreach label
            {
                if (Globals.watchlistData[i,0] == "Empty") //If empty
                {
                    Globals.watchlistData[i, 1] = "+"; //We put '+'
                }
                else //If not empty, we put the data of the date for the specific company
                {
                    //We read the data
                    Globals.watchlistData[i, 1] = Globals.watchlistData[i,0]+" $"+
                    Utilities.ReadInfo(Globals.watchlistData[i,0],Globals.today);
                }
            }
            //Foreach label
            watchlist0.Text = Globals.watchlistData[0, 1]; //We put the data
            close0.Visible=  watchlist0.Text != "+"; //If not '+' it can be closed

            watchlist1.Text = Globals.watchlistData[1, 1]; //We put the data
            close1.Visible = watchlist1.Text != "+"; //If not '+' it can be closed
            watchlist2.Text = Globals.watchlistData[2, 1]; //We put the data
            close2.Visible = watchlist2.Text != "+"; //If not '+' it can be closed
            watchlist3.Text = Globals.watchlistData[3, 1]; //We put the data
            close3.Visible = watchlist3.Text != "+"; //If not '+' it can be closed
            watchlist4.Text = Globals.watchlistData[4, 1]; //We put the data
            close4.Visible = watchlist4.Text != "+"; //If not '+' it can be closed
            watchlist5.Text = Globals.watchlistData[5, 1]; //We put the data
            close5.Visible = watchlist5.Text != "+"; //If not '+' it can be closed
            watchlist6.Text = Globals.watchlistData[6, 1]; //We put the data
            close6.Visible = watchlist6.Text != "+"; //If not '+' it can be closed
            watchlist7.Text = Globals.watchlistData[7, 1]; //We put the data
            close7.Visible = watchlist7.Text != "+"; //If not '+' it can be closed
            watchlist8.Text = Globals.watchlistData[8, 1]; //We put the data
            close8.Visible = watchlist8.Text != "+"; //If not '+' it can be closed
            watchlist9.Text = Globals.watchlistData[9, 1]; //We put the data
            close9.Visible = watchlist9.Text != "+"; //If not '+' it can be closed
        }

        private void RequestWatchlistChange(object sender, EventArgs e)
        {
            if (((Control)sender).Name[0] == 'u')
            {
                MoveUpWatchlist(Convert.ToInt32(((Control)sender).Name[2]) - 48);
                return;
            }
            MoveDownWatchlist(Convert.ToInt32(((Control)sender).Name[4]) - 48);
        }

        private void MoveUpWatchlist(int pos) //For moving up
        {
            string t;
            t = Globals.watchlistData[pos, 0]; //We save the selected label
            Globals.watchlistData[pos, 0] = Globals.watchlistData[pos - 1, 0]; //We replace it with the one above
            Globals.watchlistData[pos - 1, 0] = t; //The one above is replaced with the saved one
            UpdateWatchlistData(); //We update UI
        }

        private void MoveDownWatchlist(int pos) //For moving down
        {
            string t;
            t = Globals.watchlistData[pos, 0]; //We save the selected label
            Globals.watchlistData[pos, 0] = Globals.watchlistData[pos + 1, 0]; // We replace it with the one below
            Globals.watchlistData[pos + 1, 0] = t; //We replace the one below with the saved one
            UpdateWatchlistData(); //We update UI
        }

        public void UpdateCalendar(DateTime date)
        {
            string text = String.Empty;
            string dm = null;
            int day = date.Day;
            int month = date.Month;
            if (day < 10)
            {
                dm += "0";
            }
            dm += day.ToString()+"/";
            if (month < 10)
            {
                dm += "0";
            }
            dm += month.ToString();
            text += System.Globalization.CultureInfo.InvariantCulture.DateTimeFormat.GetAbbreviatedMonthName(month) + " ";
            text += day+", "+date.Year;
            calendarLabel.Text = text;
        }

        private void RedirectToTrade(object sender, EventArgs e)
        {
            if (!addingToWatchlist && ((Control)sender).Text != "+")
            {
                Globals.sideWatchlist.Searcher.SelectedIndex = Utilities.GetIndexOfCompany(Globals.watchlistData[Int32.Parse(((Control)sender).Name[9].ToString()),0]);
                Globals.main.ShowForm(Globals.main.TradeBtn,null);
                if (Globals.main.currentForm != "Trade")
                {
                    Globals.main.HideForm(Globals.main.currentForm);
                }
            }
        }
        private void CheckChangeOnSearcher(object sender, EventArgs e)
        {
            this.ActiveControl = null;
            
            Globals.displayedCompany = ((Control)sender).Text;
            //     Globals.main.displayedCompany.Tag = Utilities.GetIndexOfCompany(Globals.displayedCompany);
            Globals.main.UpdateInfo();
            Globals.trade.ExternalCanvasRefresh(this, null);
            
           
        }

        public void UpdateBalance()
        {
            double money = Globals.moneyBalance;
            double stock = 0;

            //loops through all the stocks and adds the value
            foreach (Company c in Globals.portfolio_companies)
            {
                stock += Utilities.ReadInfo(c.Name, Globals.today) * c.Holdings;
            }

            //loops through all the orders and adds the value (these are your holdings put on sell)
            foreach (Order o in Globals.sellOrders)
            {
                stock += Utilities.ReadInfo(o.Name, Globals.today) * o.Holdings;
            }
            money = Math.Round(money, 2);
            stock = Math.Round(stock, 2);
            double total = money + stock;
            moneyLabel.Text = moneyLabel.Tag.ToString() + money.ToString();
            stockLabel.Text = stockLabel.Tag.ToString() + stock.ToString();
            TotalLabel.Text = TotalLabel.Tag.ToString() + total.ToString();
        }

        private void RedirectToAccount(object sender, EventArgs e)
        {
            Globals.main.ShowForm(Globals.main.AccountBtn, null);
        }

        private void AdvanceInTime(object sender, EventArgs e)
        {
            Globals.trade.GotFocus += GetHandler;
            Globals.main.ShowForm(Globals.main.TradeBtn,null);
        }

        public void Movement()
        {
            int days = Convert.ToInt32(WeeksToAdd.Value) * 7;
            Globals.trade.makingTransition = true;
            if (!IsDisposed)
            {
                Globals.main.AllowInput(false);
                Invoke((MethodInvoker)delegate { Globals.trade.canvas.Controls.Clear(); });
                for (int i = 0; i < days; i++) //For each day
                {
                    if (i == days - 1)
                    {
                        Globals.trade.makingTransition = false; //We end the transition
                    }
                    Globals.today = Globals.today.AddDays(1); //We add the day
                    Invoke((MethodInvoker)delegate { Globals.trade.EffectivizeOrders(Globals.today); }); //We check the orders
                    Invoke((MethodInvoker)delegate { Globals.sideWatchlist.UpdateBalance(); });
                    Invoke((MethodInvoker)delegate //We invoke UI commands
                    {
                        Globals.sideWatchlist.UpdateCalendar(Globals.today); //We update the calendar
                        Globals.trade.ExternalCanvasRefresh(this, null); //We refresh the graphics
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
                //Invoke((MethodInvoker)delegate { Globals.sideWatchlist.UpdateBalance(); });
                Globals.main.AllowInput(true);
                if (Globals.today == new DateTime(day: 31, month: 12, year: 2009)) //If it is the last day
                {
                    Globals.trade.EndGame(); //We end the game, server receives savedata as a newPlay
                    return;
                }
                //If it is not the last day we refresh UI and allow interaction (we can't allow interaction in the last day)
                Invoke((MethodInvoker)delegate //We Invoke UI commands
                {
                    string msg=String.Empty;
                    if (Globals.messages.Count > 0)
                    {
                        msg += Globals.messages[0];
                    }
                    for (int i = 1; i < Globals.messages.Count; i++)
                    {
                        msg += Environment.NewLine + Environment.NewLine + Globals.messages[i];
                    }
                    if (msg != String.Empty)
                    {
                        MessageBox.Show(msg);
                    }
                    Globals.messages.Clear();
                    Globals.account.Update_portfolio();
                    Globals.account.Reload_panel(); //Refresh graphics

                    Globals.stock.UpdateCompanyData(); //Refreshes data
                    Globals.trade.Focus();
                });
            }
        }

        public void GetHandler(object sender, EventArgs e)
        {
            Globals.trade.GotFocus -= GetHandler;
            Thread mov = new Thread(Movement);mov.Start();
        }

        private void ItemDrawing(object sender, DrawItemEventArgs e)
        {
            // By using Sender, one method could handle multiple ComboBoxes
            ComboBox cbx;
            try
            {
                cbx = ((ComboBox)sender);
            }
            catch (Exception)
            {
                return;
            }
            if (true)
            {
                // Always draw the background
                e.DrawBackground();

                // Drawing one of the items?
                if (e.Index >= 0)
                {
                    // Set the string alignment.  Choices are Center, Near and Far
                    StringFormat sf = new StringFormat
                    {
                        LineAlignment = StringAlignment.Center,
                        Alignment = StringAlignment.Center
                    };

                    // Set the Brush to ComboBox ForeColor to maintain any ComboBox color settings
                    // Assumes Brush is solid
                    Brush brush = new SolidBrush(cbx.ForeColor);

                    // If drawing highlighted selection, change brush
                    if ((e.State & DrawItemState.Selected) == DrawItemState.Selected)
                        brush = SystemBrushes.HighlightText;

                    // Draw the string
                    e.Graphics.DrawString(cbx.Items[e.Index].ToString(), cbx.Font, brush, e.Bounds, sf);
                }
            }
        }
    }
}