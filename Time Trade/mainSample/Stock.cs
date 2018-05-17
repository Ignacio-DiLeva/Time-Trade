using System;
using System.Drawing;
using System.Windows.Forms;

namespace mainSample
{
    public partial class Stock : Form
    {
        PictureBox p = new PictureBox
        {
            Size = new Size(975,600),
            Location = new Point(0, 0),
            BackColor = Color.FromArgb(0, 238, 255),
        };
        public Stock()
        {
            InitializeComponent();
            Location = new Point(225, 70);
            Controls.Add(p);
            p.SendToBack();
            Searcher.Parent = p;
            companyCompleteName.Parent = p;
            companyData.Parent = p;
            stockInfoDisplayer.Parent = p;
        }

        private void OnLoad(object sender, EventArgs e)
        {
            for (int i = 0; i < Constants.companies.Count; i++)
            {
                Searcher.Items.Add(Constants.companies[i] + " (" + Constants.stockInfo[i, 0] + ")");
            }
            Searcher.SelectedItem = 0;
            companyData.Tag = "AAPL";
            UpdateCompanyData();
        }

        public void UpdateCompanyData()
        {
            string company = companyData.Tag.ToString();
            companyData.Text ="$ "
                + Utilities.ReadInfo(company, Globals.today).ToString() +"  HIGH: "
                + Utilities.ReadInfo(company,Globals.today,"HIGH").ToString() 
                +"  LOW: "+ Utilities.ReadInfo(company,Globals.today,"LOW").ToString();
            companyCompleteName.Text= Constants.stockInfo[Utilities.GetIndexOfCompany(company),0];
            stockInfoDisplayer.Text = Constants.stockInfo[Utilities.GetIndexOfCompany(company),1];
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
