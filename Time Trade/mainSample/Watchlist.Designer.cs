namespace mainSample
{
    partial class Watchlist
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.canvas1 = new System.Windows.Forms.Panel();
            this.canvas2 = new System.Windows.Forms.Panel();
            this.canvas3 = new System.Windows.Forms.Panel();
            this.Watchlist1 = new System.Windows.Forms.ComboBox();
            this.company1 = new System.Windows.Forms.Label();
            this.company2 = new System.Windows.Forms.Label();
            this.Watchlist2 = new System.Windows.Forms.ComboBox();
            this.company3 = new System.Windows.Forms.Label();
            this.Watchlist3 = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // canvas1
            // 
            this.canvas1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(49)))), ((int)(((byte)(66)))));
            this.canvas1.Location = new System.Drawing.Point(0, 45);
            this.canvas1.Name = "canvas1";
            this.canvas1.Size = new System.Drawing.Size(975, 150);
            this.canvas1.TabIndex = 0;
            this.canvas1.Paint += new System.Windows.Forms.PaintEventHandler(this.CanvasPaint);
            // 
            // canvas2
            // 
            this.canvas2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(49)))), ((int)(((byte)(66)))));
            this.canvas2.Location = new System.Drawing.Point(0, 240);
            this.canvas2.Name = "canvas2";
            this.canvas2.Size = new System.Drawing.Size(975, 150);
            this.canvas2.TabIndex = 1;
            this.canvas2.Paint += new System.Windows.Forms.PaintEventHandler(this.CanvasPaint);
            // 
            // canvas3
            // 
            this.canvas3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(49)))), ((int)(((byte)(66)))));
            this.canvas3.Location = new System.Drawing.Point(0, 435);
            this.canvas3.Name = "canvas3";
            this.canvas3.Size = new System.Drawing.Size(975, 150);
            this.canvas3.TabIndex = 2;
            this.canvas3.Paint += new System.Windows.Forms.PaintEventHandler(this.CanvasPaint);
            // 
            // Watchlist1
            // 
            this.Watchlist1.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.Watchlist1.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.Watchlist1.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.Watchlist1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.Watchlist1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Watchlist1.FormattingEnabled = true;
            this.Watchlist1.Location = new System.Drawing.Point(21, 11);
            this.Watchlist1.Name = "Watchlist1";
            this.Watchlist1.Size = new System.Drawing.Size(208, 21);
            this.Watchlist1.TabIndex = 4;
            this.Watchlist1.TabStop = false;
            this.Watchlist1.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.ItemDrawing);
            this.Watchlist1.SelectedIndexChanged += new System.EventHandler(this.ExternalCanvasRefresh);
            this.Watchlist1.SelectedValueChanged += new System.EventHandler(this.ExternalCanvasRefresh);
            // 
            // company1
            // 
            this.company1.AutoSize = true;
            this.company1.BackColor = System.Drawing.Color.Transparent;
            this.company1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.company1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(238)))), ((int)(((byte)(238)))));
            this.company1.Location = new System.Drawing.Point(245, 12);
            this.company1.Name = "company1";
            this.company1.Size = new System.Drawing.Size(91, 18);
            this.company1.TabIndex = 5;
            this.company1.Text = "COMPANY1";
            this.company1.DoubleClick += new System.EventHandler(this.RedirectToTrade);
            // 
            // company2
            // 
            this.company2.AutoSize = true;
            this.company2.BackColor = System.Drawing.Color.Transparent;
            this.company2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.company2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(238)))), ((int)(((byte)(238)))));
            this.company2.Location = new System.Drawing.Point(245, 209);
            this.company2.Name = "company2";
            this.company2.Size = new System.Drawing.Size(91, 18);
            this.company2.TabIndex = 7;
            this.company2.Text = "COMPANY2";
            this.company2.DoubleClick += new System.EventHandler(this.RedirectToTrade);
            // 
            // Watchlist2
            // 
            this.Watchlist2.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.Watchlist2.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.Watchlist2.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.Watchlist2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.Watchlist2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Watchlist2.FormattingEnabled = true;
            this.Watchlist2.Location = new System.Drawing.Point(21, 206);
            this.Watchlist2.Name = "Watchlist2";
            this.Watchlist2.Size = new System.Drawing.Size(208, 21);
            this.Watchlist2.TabIndex = 6;
            this.Watchlist2.TabStop = false;
            this.Watchlist2.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.ItemDrawing);
            this.Watchlist2.SelectedIndexChanged += new System.EventHandler(this.ExternalCanvasRefresh);
            this.Watchlist2.SelectedValueChanged += new System.EventHandler(this.ExternalCanvasRefresh);
            // 
            // company3
            // 
            this.company3.AutoSize = true;
            this.company3.BackColor = System.Drawing.Color.Transparent;
            this.company3.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.company3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(238)))), ((int)(((byte)(238)))));
            this.company3.Location = new System.Drawing.Point(245, 404);
            this.company3.Name = "company3";
            this.company3.Size = new System.Drawing.Size(91, 18);
            this.company3.TabIndex = 9;
            this.company3.Text = "COMPANY3";
            this.company3.DoubleClick += new System.EventHandler(this.RedirectToTrade);
            // 
            // Watchlist3
            // 
            this.Watchlist3.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.Watchlist3.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.Watchlist3.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.Watchlist3.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.Watchlist3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Watchlist3.FormattingEnabled = true;
            this.Watchlist3.Location = new System.Drawing.Point(21, 402);
            this.Watchlist3.Name = "Watchlist3";
            this.Watchlist3.Size = new System.Drawing.Size(208, 21);
            this.Watchlist3.TabIndex = 8;
            this.Watchlist3.TabStop = false;
            this.Watchlist3.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.ItemDrawing);
            this.Watchlist3.SelectedIndexChanged += new System.EventHandler(this.ExternalCanvasRefresh);
            this.Watchlist3.SelectedValueChanged += new System.EventHandler(this.ExternalCanvasRefresh);
            // 
            // Watchlist
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(131)))), ((int)(((byte)(84)))));
            this.ClientSize = new System.Drawing.Size(975, 585);
            this.Controls.Add(this.company3);
            this.Controls.Add(this.Watchlist3);
            this.Controls.Add(this.company2);
            this.Controls.Add(this.Watchlist2);
            this.Controls.Add(this.company1);
            this.Controls.Add(this.Watchlist1);
            this.Controls.Add(this.canvas3);
            this.Controls.Add(this.canvas2);
            this.Controls.Add(this.canvas1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(975, 664);
            this.MinimizeBox = false;
            this.Name = "Watchlist";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Watchlist";
            this.Load += new System.EventHandler(this.OnLoad);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel canvas1;
        private System.Windows.Forms.Panel canvas2;
        private System.Windows.Forms.Panel canvas3;
        private System.Windows.Forms.ComboBox Watchlist1;
        private System.Windows.Forms.Label company1;
        private System.Windows.Forms.Label company2;
        private System.Windows.Forms.ComboBox Watchlist2;
        private System.Windows.Forms.Label company3;
        private System.Windows.Forms.ComboBox Watchlist3;
    }
}