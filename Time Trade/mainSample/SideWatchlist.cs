using System;
using System.Drawing;
using System.Windows.Forms;

namespace mainSample
{
    public partial class SideWatchlist : Form
    {
        public SideWatchlist()
        {
            InitializeComponent();
            Location = new Point(975, 20);
        }

        private void OnLoad(object sender, EventArgs e)
        {
            addingToWatchlist = false;
            for (int i = 0; i < Constants.companies.Count; i++)
            {
                Searcher.Items.Add(Constants.companies[i] + " (" + Constants.stockInfo[i, 0] + ")");
            }
            //displayedCompany.Text = Globals.displayedCompany; TODO
            Searcher.Text = Globals.displayedCompany + " (" + Constants.stockInfo[Utilities.GetIndexOfCompany(Globals.displayedCompany), 0] + ")";
            UpdateWatchlistData();
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
            DayMonth.Text = dm;
            Year.Text = date.Year.ToString();
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
                Globals.main.currentForm = "Trade";
                Globals.main.showLogo.Tag = Globals.main.currentForm;
            }
        }
        private void CheckChangeOnSearcher(object sender, EventArgs e)
        {
            Globals.main.displayedCompany.Text = ((Control)sender).Text.Split(' ')[0];
            Globals.displayedCompany = Globals.main.displayedCompany.Text;
            Globals.main.displayedCompany.Tag = Utilities.GetIndexOfCompany(Globals.displayedCompany);
            Globals.trade.ExternalCanvasRefresh(this, null);
        }
    }
}