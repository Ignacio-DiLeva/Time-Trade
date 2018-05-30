using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace mainSample
{
    public partial class PortfolioAccount : Form
    {
        Font portfolio_fonts = new Font("Arial", 9);
        public PortfolioAccount()
        {
            InitializeComponent();

        }

        private void RedirectToTrade(object sender, EventArgs e)
        {
            Globals.sideWatchlist.Searcher.SelectedIndex = Utilities.GetIndexOfCompany(((Control)sender).Text);
            Globals.main.ShowForm(Globals.main.TradeBtn, null);
            Hide();
            Globals.main.currentForm = "Trade";
            Globals.main.showLogo.Tag = Globals.main.currentForm;
        }

        public void OnLoad(object sender, EventArgs e)
        {
            int x = 0;
            int y = 0;

            for (int i = 0; i < 141; i++)
            {
                //creates a sample label
                Label label = new Label
                {
                    Text = "",
                    Font = new Font("Arial", 12),
                    ForeColor = Color.White,
                    Name = x + "_name",
                    Tag = "tag",
                    AutoSize = false,
                    Size = new Size(80, 30),
                    TextAlign = ContentAlignment.MiddleRight,
            };

                switch (x) //depending on which label columnn you are, it creates a different type of label
                {
                    case 0: //name of the company
                        label.Location = new Point(12, 5 + 40 * y);
                        label.Size = new Size(140, 30);
                        label.Name = y + "name";
                        label.DoubleClick += RedirectToTrade;
                        label.TextAlign = ContentAlignment.MiddleLeft;

                        break;
                    case 1: //shares of that company
                        label.Location = new Point(170, 5+40*y);
                        label.Name = y + "shares";
                        break;
                    case 2: //current price of that company
                        label.Location = new Point(285, 5 + 40 * y);
                        label.Name = y + "current";

                        break;
                    case 3: //the cost of each share
                        label.Location = new Point(370, 5 + 40 * y);
                        label.Name = y + "cost";
                        break;
                    case 4: //how much you bought that share
                        label.Location = new Point(495, 5 + 40 * y);
                        label.Name = y + "bp";

                        break;
                    case 5: //the gainloss in raw value
                        label.Location = new Point(640, 5 + 40 * y);
                        label.Name = y + "glone";

                        break;
                    case 6: //gainloss in percentage
                        label.Location = new Point(780, 5 + 40 * y);
                        label.Name = y + "gltwo";
                        break;
                }

                label.Tag = y; //define its tag depending on the line. It will be used later
                portfolioPanel.Controls.Add(label); //adds the label

                x++; //iterates through the 7 types of labels
                if (x == 7) //when it creates a line, passes to the next line
                {
                    x = 0;
                    y++;
                }
            }
            RedrawPanels();
        }

        public void RedrawPanels()
        {
            foreach (Control ctl in portfolioPanel.Controls)
            {
                if (ctl.Text == null)
                {
                    break;
                }
                Invoke((MethodInvoker)delegate { ctl.Text = null; });

            }
            if (Globals.portfolio_companies.Count != 0)
            {
                int y = 0;

                //iterates through each company
                foreach (Company cm in Globals.portfolio_companies)
                {
                    //defines the value in which the company closes
                    string close_Value = Utilities.ReadInfo(cm.Name, Globals.today).ToString();

                    //iterates through the controls in the panel, in other words, the labels
                    foreach (Control ctl in portfolioPanel.Controls)
                    {
                        //the tag defines the column of the label. Checks if the control has the iteration of y
                        if (ctl.Tag.ToString() == y.ToString())
                        {

                            string name = "";

                            //obtains the column of the label
                            foreach (char c in ctl.Name)
                            {
                                if (!Char.IsDigit(c))
                                {
                                    name += c;
                                }
                            }

                            //the cost of all the holdings
                            double total_Cost = cm.Values * cm.Holdings;

                            //the raw gainloss
                            double gainloss_Cost = Convert.ToDouble(close_Value) - cm.Values;

                            //depending of which column
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

                                        ctl.Text = ((gainloss_Cost * cm.Holdings) < 0 ? "-1" : "") + "$" + Math.Round(Math.Abs((gainloss_Cost) * cm.Holdings), 2).ToString();
                                    });
                                    break;

                                case "gltwo":
                                    Invoke((MethodInvoker)delegate { ctl.Text = Math.Round((gainloss_Cost) / cm.Values * 100, 2).ToString() + "%"; });
                                    break;
                            }
                        }
                    }
                    y++;
                }

            }
        }

        private void Paint_portfolio(object sender, PaintEventArgs e)
        {

            Pen blackPen = new Pen(Constants.black, 1);
            Point p1;
            Point p2;

            for (int i = 0; i < 21; i++) //draws the extra horizontal lines
            {
                p1 = new Point(0, 40 + i * 40);
                p2 = new Point(865, 40+ i * 40);
                e.Graphics.DrawLine(blackPen, p1, p2);
            }
        }


    }
}
