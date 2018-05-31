using System;
using System.Drawing;
using System.Windows.Forms;
using System.Collections.Generic;

namespace mainSample
{
    public partial class Stock : Form
    {

        List<Image> logos = new List<Image>();
        

        PictureBox p = new PictureBox
        {
            Size = new Size(975,585),
            Location = new Point(0, 0),
            BackColor = Constants.controlGray,
        };
        public Stock()
        {
            InitializeComponent();
            Location = new Point(0, 90);
            Controls.Add(p);
            p.SendToBack();
            Searcher.Parent = p;
            companyCompleteName.Parent = p;
            companyData.Parent = p;
            stockInfoDisplayer.Parent = p;
        }


        private void OnLoad(object sender, EventArgs e)
        {
            logos.Add(Image.FromFile("Logos/Apple.png"));
            logos.Add(Image.FromFile("Logos/Amazon.png"));
            logos.Add(Image.FromFile("Logos/Boeing.png"));
            logos.Add(Image.FromFile("Logos/Blockbuster.png"));
            logos.Add(Image.FromFile("Logos/Bestbuy.png"));
            logos.Add(Image.FromFile("Logos/BP.png"));
            logos.Add(Image.FromFile("Logos/CityGroup.png"));
            logos.Add(Image.FromFile("Logos/Cat.png"));
            logos.Add(Image.FromFile("Logos/Daimler.png"));
            logos.Add(Image.FromFile("Logos/Ford.png"));
            logos.Add(Image.FromFile("Logos/Intel.png"));
            logos.Add(Image.FromFile("Logos/JPMorgan.png"));
            logos.Add(Image.FromFile("Logos/CocaCola.png"));
            logos.Add(Image.FromFile("Logos/LehmanBros.png"));
            logos.Add(Image.FromFile("Logos/GeneralMotors.png"));
            logos.Add(Image.FromFile("Logos/Motorola.png"));
            logos.Add(Image.FromFile("Logos/Sprint.png"));
            logos.Add(Image.FromFile("Logos/Starbucks.png"));
            logos.Add(Image.FromFile("Logos/AT&T.png"));
            logos.Add(Image.FromFile("Logos/Trump.png"));
            

            for (int i = 0; i < Constants.companies.Count; i++)
            {
                Searcher.Items.Add(Constants.companies[i] + " (" + Constants.stockInfo[i, 0] + ")");
            }
            Searcher.SelectedItem = 0;
            companyData.Tag = "AAPL";
            UpdateCompanyData();
            
            companyData.Font = new Font("Arial", 14);
            companyCompleteName.Font = new Font("Arial", 20, FontStyle.Bold);
            companyCompleteName.TextAlign = ContentAlignment.MiddleLeft;

            stockInfoDisplayer.Font = new Font("Arial", 14);
            stockInfoDisplayer.ForeColor = Color.White;
            companyData.ForeColor = Color.White;
            companyCompleteName.ForeColor = Color.White;

           
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


            Image toDisplay = logos[Utilities.GetIndexOfCompany(company)];
            DisplayedLogo.Image = toDisplay;
            //DisplayedLogo.Size
        }

        private void ExternalRefreshCompanyData(object sender, EventArgs e)
        {
            companyData.Tag = ((Control)sender).Text.Split(' ')[0];
            UpdateCompanyData();
        }

        private void RedirectToTrade(object sender, EventArgs e)
        {
            Globals.sideWatchlist.Searcher.SelectedIndex = Utilities.GetIndexOfCompany(companyData.Tag.ToString());
            Globals.main.ShowForm(Globals.main.TradeBtn,null);
            Hide();
            Globals.main.currentForm = "Trade";
            Globals.main.showLogo.Tag = Globals.main.currentForm;
        }
    }
}
