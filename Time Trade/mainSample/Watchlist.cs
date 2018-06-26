using System;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;

namespace mainSample
{
    public partial class Watchlist : Form
    {
        public Watchlist()
        {
            InitializeComponent();
            Location = new Point(0, 90);
            /*
            Controls.Add(p);
            p.SendToBack();
            company1.Parent = p;
            company2.Parent = p;
            company3.Parent = p;
            canvas1.Parent = p;
            canvas2.Parent = p;
            canvas3.Parent = p;
            Watchlist1.Parent = p;
            Watchlist2.Parent = p;
            Watchlist3.Parent = p;
            */
        }

        private void OnLoad(object sender, EventArgs e)
        {
            for (int i = 0; i < Constants.companies.Count; i++)
            {
                Watchlist1.Items.Add(Constants.companies[i] + " (" + Constants.stockInfo[i, 0] + ")");
                Watchlist2.Items.Add(Constants.companies[i] + " (" + Constants.stockInfo[i, 0] + ")");
                Watchlist3.Items.Add(Constants.companies[i] + " (" + Constants.stockInfo[i, 0] + ")");
            }
            Watchlist1.SelectedIndex = Utilities.GetIndexOfCompany(Globals.watchlistData[10, 0]);
            Watchlist2.SelectedIndex = Utilities.GetIndexOfCompany(Globals.watchlistData[11, 0]);
            Watchlist3.SelectedIndex = Utilities.GetIndexOfCompany(Globals.watchlistData[12, 0]);
            try
            {
                UpdateLabels();
            }
            catch (Exception) { }
            RefreshCanvas(1);
            RefreshCanvas(2);
            RefreshCanvas(3);
        }

        private void UpdateLabels()
        {
            company1.Text = Watchlist1.SelectedItem.ToString().Split(' ')[0] + " $" + Utilities.ReadInfo(Watchlist1.SelectedItem.ToString().Split(' ')[0], Globals.today);
            company2.Text = Watchlist2.SelectedItem.ToString().Split(' ')[0] + " $" + Utilities.ReadInfo(Watchlist2.SelectedItem.ToString().Split(' ')[0], Globals.today);
            company3.Text = Watchlist3.SelectedItem.ToString().Split(' ')[0] + " $" + Utilities.ReadInfo(Watchlist3.SelectedItem.ToString().Split(' ')[0], Globals.today);
            Globals.watchlistData[10, 0] = Watchlist1.SelectedItem.ToString().Split(' ')[0];
            Globals.watchlistData[11, 0] = Watchlist2.SelectedItem.ToString().Split(' ')[0];
            Globals.watchlistData[12, 0] = Watchlist3.SelectedItem.ToString().Split(' ')[0];
        }

        public void RefreshCanvas(int self)
        {
            if (self == 1) { canvas1.Refresh(); return; }
            if (self == 2) { canvas2.Refresh(); return; }
            if (self == 3) { canvas3.Refresh(); return; }
        }

        void AddReferenceToCanvas(int priceReference, double render, int self)
        {
            if (self == 1) { renderingLabels1 = true; }
            else if (self == 2) { renderingLabels2 = true; }
            else if (self == 3) { renderingLabels3 = true; }

            if (self == 1) { Invoke((MethodInvoker)delegate { canvas1.Controls.Clear(); }); }
            else if (self == 2) { Invoke((MethodInvoker)delegate { canvas2.Controls.Clear(); }); }
            else if (self == 3) { Invoke((MethodInvoker)delegate { canvas3.Controls.Clear(); }); }
            int pixel = 0;
            double price = 1;
            int lastPixel = -20;
            for (; ; pixel++)
            {
                if (price >= 1)
                {
                    if (pixel - 20 >= lastPixel)
                    {
                        Label l = new Label()
                        {
                            Name = "R" + priceReference,
                            Location = new Point(0, 115 - pixel),
                            Font = new Font("Microsoft Sans Serif", emSize: 8),
                            TextAlign = ContentAlignment.MiddleRight,
                            AutoSize = false,
                            Size = new Size(50, 20),
                            Text = "$" + priceReference,
                            ForeColor = Constants.lightGray
                        };
                        if (self == 1) { l.BackColor = canvas1.BackColor; }
                        else if (self == 2) { l.BackColor = canvas2.BackColor; }
                        else if (self == 3) { l.BackColor = canvas3.BackColor; }
                        //l.Resize += RefreshCanvas;

                        if (self == 1) { Invoke((MethodInvoker)delegate { canvas1.Controls.Add(l); }); }
                        else if (self == 2) { Invoke((MethodInvoker)delegate { canvas2.Controls.Add(l); }); }
                        else if (self == 3) { Invoke((MethodInvoker)delegate { canvas3.Controls.Add(l); }); }
                        Invoke((MethodInvoker)delegate { l.BringToFront(); });
                        lastPixel = pixel;
                        if (lastPixel >= 90)
                        {
                            break;
                        }
                    }
                    priceReference++;
                    price--;
                }
                price += render;
            }
            Invoke((MethodInvoker)delegate 
            {
                if (self == 1) { canvas1.Refresh(); }
                else if (self == 2) { canvas2.Refresh(); }
                else if (self == 3) { canvas3.Refresh(); }
            });
            
            if (self == 1) { renderingLabels1 = false; }
            else if (self == 2) { renderingLabels2 = false; }
            else if (self == 3) { renderingLabels3 = false; }
        }

        bool renderingLabels1 = false;
        bool renderingLabels2 = false;
        bool renderingLabels3 = false;
        private void CanvasPaint(object sender, PaintEventArgs e)
        {
            try
            {
                UpdateLabels();
            }
            catch (Exception) { }
            e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            Pen pen = new Pen(Constants.white, 1);
            //START MATH FOR GRAPH

            double[] getValues = new double[Constants.displayedDays];
            int omit = 0;
            string company = "AAPL";
            int self = Int32.Parse(((Control)sender).Name[6].ToString());
            if (self == 1) { company = Watchlist1.SelectedItem.ToString().Split(' ')[0]; }
            if (self == 2) { company = Watchlist2.SelectedItem.ToString().Split(' ')[0]; }
            if (self == 3) { company = Watchlist3.SelectedItem.ToString().Split(' ')[0]; }
            for (int i = 0; i < getValues.Length; i++)
            {
                getValues[i] = Utilities.ReadInfo(company, Globals.today.AddDays(-Constants.displayedDays + 1 + i + omit));
            }
            double tempMin = 100, tempMax = 0;
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
            double render = (maximum - minimum) / Convert.ToDouble(100);
            if ((self == 1 && !renderingLabels1) || (self == 2 && !renderingLabels2) || (self == 3 && !renderingLabels3))
            {
                Thread references = new Thread(() => AddReferenceToCanvas(minimum, render, self)); references.Start();
            }

            int[] rendered = new int[getValues.Length];
            for (int i = 0; i < rendered.Length; i++)
            {
                double doubledMinimum = minimum;
                int count = 125;
                double value = getValues[i];
                while (doubledMinimum + render <= value)
                {
                    count--;
                    doubledMinimum += render;

                }
                rendered[i] = count;
            }
            //END MATH FOR GRAPH

            //We draw the lines obtained at the rendering process
            foreach (Control ctl in ((Panel)sender).Controls)
            {
                Pen gPen = new Pen(Constants.lightGray, 1);
                e.Graphics.DrawLine(gPen, new Point(50, ctl.Location.Y + 10), new Point(975, ctl.Location.Y + 10));
            }
            for (int i = 0; i < getValues.Length - 1; i++)
            {
                e.Graphics.DrawLine(pen, 135 + i * (840 / Constants.displayedDays), rendered[i], 135 + (i + 1) * (840 / Constants.displayedDays), rendered[i + 1]);
            }
        }

        public void ExternalCanvasRefresh(object sender, EventArgs e)
        {
            this.ActiveControl = null;
            try
            {
                try
                {
                    UpdateLabels();
                }
                catch (Exception) { }
                if (company1.Text.ToString().StartsWith(Watchlist1.SelectedItem.ToString().Split(' ')[0]))
                {
                    canvas1.Refresh();
                }
                if (company2.Text.ToString().StartsWith(Watchlist2.SelectedItem.ToString().Split(' ')[0]))
                {
                    canvas2.Refresh();
                }
                if (company3.Text.ToString().StartsWith(Watchlist3.SelectedItem.ToString().Split(' ')[0]))
                {
                    canvas3.Refresh();
                }
            }
            catch (Exception) { }
        }

        private void RedirectToTrade(object sender, EventArgs e)
        {
            Globals.sideWatchlist.Searcher.SelectedIndex = Utilities.GetIndexOfCompany(Globals.watchlistData[Int32.Parse(((Control)sender).Name[7].ToString())+9, 0]);
            Globals.main.ShowForm(Globals.main.TradeBtn,null);
            Hide();
            Globals.main.currentForm = "Trade";
            Globals.main.showLogo.Tag = Globals.main.currentForm;
        }

        private void ItemDrawing(object sender, DrawItemEventArgs e)
        {
            // By using Sender, one method could handle multiple ComboBoxes
            ComboBox cbx;
            try
            {
                cbx=((ComboBox)sender);
            }
            catch(Exception){
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