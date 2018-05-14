using System;
using System.Windows.Forms;
using MaterialSkin.Controls;

namespace Custom_savedata_for_Time_Trade
{
    public partial class Data : MaterialForm
    {
        public Data()
        {
            InitializeComponent();
        }

        private void CheckData(object sender, EventArgs e)
        {
            ((Control)sender).Enabled = false;
            int initMoney = Convert.ToInt32(numericMoney.Value);
            initMoney = Math.Abs(initMoney);
            DateTime d = new DateTime(2007,6,1);
            try
            {
                d = new DateTime(Convert.ToInt32(numericYear.Value), Convert.ToInt32(numericMonth.Value), Convert.ToInt32(numericDay.Value));
            }
            catch (Exception) { MessageBox.Show("Invalid date"); ((Control)sender).Enabled = true; return; }
            if(!(d<new DateTime(2007, 3, 1))&&!(d>new DateTime(2009,12,30)))
            {
                if (!String.IsNullOrEmpty(profileField.Text))
                {
                    Portfolio p = new Portfolio(initMoney, d, profileField.Text);
                    Invoke((MethodInvoker)delegate
                    {
                        p.Show();
                        Hide();
                    });
                    return;
                }
                else
                {
                    MessageBox.Show("Profile name can not be null"); ((Control)sender).Enabled = true; return;
                }
            }
            MessageBox.Show("Date must be between 2/3/2007 and 30/12/2009"); ((Control)sender).Enabled = true; return;
        }

        private void OnClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
    }
}
