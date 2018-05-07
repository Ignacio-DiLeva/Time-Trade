using System;
using System.Drawing;
using System.Windows.Forms;
using MaterialSkin.Controls;

namespace mainSample
{
    public partial class Stock : MaterialForm
    {
        PictureBox p = new PictureBox
        {
            Size = new Size(975,664),
            Location = new Point(0, 0),
            BackColor = Color.FromArgb(0, 238, 255),
        };
        public Stock(Point getLocation)
        {
            InitializeComponent();
            getLocation.X += 225;
            getLocation.Y += 125 - 64;
            Location = getLocation;
            Controls.Add(p);
            p.SendToBack();
            Searcher.Parent = p;
            companyCompleteName.Parent = p;
            companyData.Parent = p;
            stockInfoDisplayer.Parent = p;
        }

        private void OnLoad(object sender, EventArgs e)
        {
            for (int i = 0; i < Globals.companies.Count; i++)
            {
                Searcher.Items.Add(Globals.companies[i] + " (" + Globals.stockInfo[i, 0] + ")");
            }
            Searcher.SelectedItem = 0;
            companyData.Tag = "AAPL";
            UpdateCompanyData();
        }

        public void UpdateCompanyData()
        {
            string company = companyData.Tag.ToString();
            companyData.Text ="$ "
                + Globals.ReadInfo(company, Globals.d).ToString() +"  HIGH: "
                +Globals.ReadInfo(company,Globals.d,"HIGH").ToString() 
                +"  LOW: "+Globals.ReadInfo(company,Globals.d,"LOW").ToString();
            companyCompleteName.Text= Globals.stockInfo[Globals.GetIndexOfCompany(company),0];
            stockInfoDisplayer.Text = Globals.stockInfo[Globals.GetIndexOfCompany(company),1];
        }

        private void ExternalRefreshCompanyData(object sender, EventArgs e)
        {
            companyData.Tag = ((Control)sender).Text.Split(' ')[0];
            UpdateCompanyData();
        }

        private void RedirectToTrade(object sender, EventArgs e)
        {
            Globals.trade.Searcher.Text = companyData.Tag.ToString();
            Globals.main.ShowForm("Trade");
            Hide();
            Globals.main.currentForm = "Trade";
            Globals.main.showLogo.Tag = Globals.main.currentForm;
        }
    }
}
