using System;
using System.Windows.Forms;
using System.Drawing;
using MaterialSkin.Controls;
using System.Data.OleDb;
using System.Data;
using System.IO;
using System.Collections.Generic;

namespace Custom_savedata_for_Time_Trade
{
    public partial class Portfolio : MaterialForm
    {
        public Portfolio(int getInitialMoney,DateTime getDate ,string getProfileName)
        {
            InitializeComponent();
            Date = getDate;
            desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            profileName = getProfileName;
            savedata = "AAPL:" + getInitialMoney + ":" + getDate.Day + ":" + getDate.Month + ":" + getDate.Year 
                + "#Empty:Empty:Empty:Empty:Empty:Empty:Empty:Empty:Empty:Empty:AAPL:AMZN:BA#AAPL:AMZN:BA:BBI:BBY:BP:C:CAT:DDAIF:F:INTC:JPM:KO:LEHMQ:MOT:MTLQQ.PK:S:SBUX:T:TRMP#";
        }
        string profileName;
        string savedata;
        DateTime Date;
        string desktopPath;
        DataTable dt = new DataTable();
        string [] companies = new string[20];
        OleDbConnection con;
        private void OnLoad(object sender, EventArgs e)
        {
            con = new OleDbConnection //Connection
            (@" 
                Provider= Microsoft.ACE.OLEDB.12.0;
                Data Source= COMPANIES.accdb;
                Persist Security Info = False;
            ");
            con.Open(); //Opens connection
            DateTimePicker dtp = new DateTimePicker() //For ording by date
            {
                CustomFormat = "dd/mm/yyyy", //Format
                Format = DateTimePickerFormat.Custom //Set the use of custom
            };
            OleDbCommand cmd = con.CreateCommand(); //New command
            cmd.CommandType = CommandType.Text; //Command is text
            cmd.CommandText = "Select DISTINCT [COMPANY] FROM [COMPANIES]"; //All information, ordered
            cmd.ExecuteNonQuery(); //Executes the command
            OleDbDataAdapter da = new OleDbDataAdapter(cmd); //We adapt the information
            da.Fill(dt); //We insert the information in the table
            for(int i = 0; i < companies.Length; i++)
            {
                companies[i] = dt.Rows[i][0].ToString();
                Label l = new Label()
                {
                    AutoSize = false,
                    Size = new Size(100, 20),
                    BackColor = Color.White,
                    Location = new Point(0,64+i*20),
                    Text = companies[i],
                    TextAlign = ContentAlignment.MiddleCenter,
                };
                Controls.Add(l);
            }
        }

        private void SaveProfile(object sender, EventArgs e)
        {
            name = new List<string>();
            cHoldings = new List<int>();
            investedMoney = new List<double>();
            foreach (Control ctl in Controls)
            {
                try
                {
                    if (((NumericUpDown)ctl).Value != 0) { AddToSavedata((ctl.Location.Y - 64) / 20, Convert.ToInt32(((NumericUpDown)ctl).Value)); }
                }
                catch (Exception) { }
            }
            string listName = null;
            string listHoldings = null;
            string listInvested = null;
            if (name.Count > 0)
            {
                listName += name[0];
                listHoldings += cHoldings[0].ToString();
                listInvested += investedMoney[0].ToString();
            }
            for(int i = 1; i < name.Count; i++)
            {
                listName += ":" + name[i];
                listHoldings += ":" + cHoldings[i].ToString();
                listInvested += ":" + investedMoney[i].ToString();
            }
            savedata += listName + "#" + listHoldings + "#" + listInvested + "#";
            savedata += "#########";
            File.WriteAllText(desktopPath+"\\"+profileName+".ttp", savedata);
            Clipboard.SetText(savedata);
            MessageBox.Show("Saved in desktop and copied to clipboard");
            Data dt = new Data();
            Invoke((MethodInvoker)delegate
            {
                dt.Show();
                Hide();
            });
        }

        private void OnClosing(object sender, FormClosingEventArgs e)
        {
            con.Close();
            Application.Exit();
        }
        List<string> name;
        List<int> cHoldings;
        List<double> investedMoney;

        private void AddToSavedata(int indexCompany,int holdings)
        {
            name.Add(companies[indexCompany]);
            cHoldings.Add(holdings);
            OleDbCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "SELECT [CLOSE] FROM [COMPANIES] WHERE [COMPANY] = '" + companies[indexCompany] + "' AND [OPENDATE] =#"+Date.Month+"/"+Date.Day+"/"+Date.Year+"#";
            cmd.ExecuteNonQuery();
            OleDbDataAdapter da = new OleDbDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            investedMoney.Add(Math.Round(Convert.ToDouble(dt.Rows[0][0]), 2)*holdings);
        }
    }
}