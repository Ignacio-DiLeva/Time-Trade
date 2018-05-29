namespace mainSample
{
    partial class Main
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
            this.showLogo = new System.Windows.Forms.PictureBox();
            this.TradeBtn = new System.Windows.Forms.Button();
            this.StockBtn = new System.Windows.Forms.Button();
            this.AccountBtn = new System.Windows.Forms.Button();
            this.WatchlistBtn = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.displayedCompany = new System.Windows.Forms.Label();
            this.highPrice = new System.Windows.Forms.Label();
            this.nowPrice = new System.Windows.Forms.Label();
            this.lowPrice = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.showLogo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            this.SuspendLayout();
            // 
            // showLogo
            // 
            this.showLogo.BackColor = System.Drawing.Color.Blue;
            this.showLogo.Image = global::mainSample.Properties.Resources.Time_Trade_Logo;
            this.showLogo.Location = new System.Drawing.Point(0, 20);
            this.showLogo.Name = "showLogo";
            this.showLogo.Size = new System.Drawing.Size(80, 70);
            this.showLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.showLogo.TabIndex = 0;
            this.showLogo.TabStop = false;
            this.showLogo.Click += new System.EventHandler(this.ShowForm);
            // 
            // TradeBtn
            // 
            this.TradeBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(131)))), ((int)(((byte)(84)))));
            this.TradeBtn.FlatAppearance.BorderSize = 0;
            this.TradeBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.TradeBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 35F);
            this.TradeBtn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(238)))), ((int)(((byte)(238)))));
            this.TradeBtn.Location = new System.Drawing.Point(80, 20);
            this.TradeBtn.Name = "TradeBtn";
            this.TradeBtn.Size = new System.Drawing.Size(165, 70);
            this.TradeBtn.TabIndex = 1;
            this.TradeBtn.Tag = "Trade";
            this.TradeBtn.Text = "Trade";
            this.TradeBtn.UseVisualStyleBackColor = false;
            this.TradeBtn.Click += new System.EventHandler(this.ShowForm);
            // 
            // StockBtn
            // 
            this.StockBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(238)))), ((int)(((byte)(238)))));
            this.StockBtn.FlatAppearance.BorderSize = 0;
            this.StockBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.StockBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 35F);
            this.StockBtn.ForeColor = System.Drawing.Color.Black;
            this.StockBtn.Location = new System.Drawing.Point(245, 20);
            this.StockBtn.Name = "StockBtn";
            this.StockBtn.Size = new System.Drawing.Size(165, 70);
            this.StockBtn.TabIndex = 2;
            this.StockBtn.Tag = "Stock";
            this.StockBtn.Text = "Stock";
            this.StockBtn.UseVisualStyleBackColor = false;
            this.StockBtn.Click += new System.EventHandler(this.ShowForm);
            // 
            // AccountBtn
            // 
            this.AccountBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(238)))), ((int)(((byte)(238)))));
            this.AccountBtn.FlatAppearance.BorderSize = 0;
            this.AccountBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.AccountBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 28F);
            this.AccountBtn.ForeColor = System.Drawing.Color.Black;
            this.AccountBtn.Location = new System.Drawing.Point(410, 20);
            this.AccountBtn.Name = "AccountBtn";
            this.AccountBtn.Size = new System.Drawing.Size(165, 70);
            this.AccountBtn.TabIndex = 3;
            this.AccountBtn.Tag = "Account";
            this.AccountBtn.Text = "Account";
            this.AccountBtn.UseVisualStyleBackColor = false;
            this.AccountBtn.Click += new System.EventHandler(this.ShowForm);
            // 
            // WatchlistBtn
            // 
            this.WatchlistBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(238)))), ((int)(((byte)(238)))));
            this.WatchlistBtn.FlatAppearance.BorderSize = 0;
            this.WatchlistBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.WatchlistBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 25F);
            this.WatchlistBtn.ForeColor = System.Drawing.Color.Black;
            this.WatchlistBtn.Location = new System.Drawing.Point(575, 20);
            this.WatchlistBtn.Name = "WatchlistBtn";
            this.WatchlistBtn.Size = new System.Drawing.Size(165, 70);
            this.WatchlistBtn.TabIndex = 4;
            this.WatchlistBtn.Tag = "Watchlist";
            this.WatchlistBtn.Text = "Watchlist";
            this.WatchlistBtn.UseVisualStyleBackColor = false;
            this.WatchlistBtn.Click += new System.EventHandler(this.ShowForm);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(79)))), ((int)(((byte)(93)))), ((int)(((byte)(117)))));
            this.pictureBox1.Location = new System.Drawing.Point(740, 20);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(235, 70);
            this.pictureBox1.TabIndex = 5;
            this.pictureBox1.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.Color.Red;
            this.pictureBox2.Location = new System.Drawing.Point(0, 0);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(20, 20);
            this.pictureBox2.TabIndex = 6;
            this.pictureBox2.TabStop = false;
            this.pictureBox2.Click += new System.EventHandler(this.TempClose);
            // 
            // pictureBox3
            // 
            this.pictureBox3.BackColor = System.Drawing.Color.Red;
            this.pictureBox3.Location = new System.Drawing.Point(30, 0);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(20, 20);
            this.pictureBox3.TabIndex = 7;
            this.pictureBox3.TabStop = false;
            this.pictureBox3.Click += new System.EventHandler(this.TempMinimize);
            // 
            // pictureBox4
            // 
            this.pictureBox4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(244)))), ((int)(((byte)(244)))));
            this.pictureBox4.Location = new System.Drawing.Point(20, 0);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(10, 20);
            this.pictureBox4.TabIndex = 8;
            this.pictureBox4.TabStop = false;
            // 
            // displayedCompany
            // 
            this.displayedCompany.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(131)))), ((int)(((byte)(84)))));
            this.displayedCompany.Font = new System.Drawing.Font("Arial", 10F);
            this.displayedCompany.ForeColor = System.Drawing.Color.White;
            this.displayedCompany.Location = new System.Drawing.Point(758, 31);
            this.displayedCompany.Name = "displayedCompany";
            this.displayedCompany.Size = new System.Drawing.Size(83, 23);
            this.displayedCompany.TabIndex = 9;
            this.displayedCompany.Text = "AAPL";
            this.displayedCompany.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.displayedCompany.TextChanged += new System.EventHandler(this.HandleUpdateInfo);
            // 
            // highPrice
            // 
            this.highPrice.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(49)))), ((int)(((byte)(66)))));
            this.highPrice.Font = new System.Drawing.Font("Arial", 9.75F);
            this.highPrice.ForeColor = System.Drawing.Color.White;
            this.highPrice.Location = new System.Drawing.Point(863, 28);
            this.highPrice.Name = "highPrice";
            this.highPrice.Size = new System.Drawing.Size(95, 26);
            this.highPrice.TabIndex = 10;
            this.highPrice.Text = "label1";
            this.highPrice.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // nowPrice
            // 
            this.nowPrice.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(49)))), ((int)(((byte)(66)))));
            this.nowPrice.Font = new System.Drawing.Font("Arial", 9.75F);
            this.nowPrice.ForeColor = System.Drawing.Color.White;
            this.nowPrice.Location = new System.Drawing.Point(759, 61);
            this.nowPrice.Name = "nowPrice";
            this.nowPrice.Size = new System.Drawing.Size(82, 23);
            this.nowPrice.TabIndex = 11;
            this.nowPrice.Text = "label2";
            this.nowPrice.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lowPrice
            // 
            this.lowPrice.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(49)))), ((int)(((byte)(66)))));
            this.lowPrice.Font = new System.Drawing.Font("Arial", 9.75F);
            this.lowPrice.ForeColor = System.Drawing.Color.White;
            this.lowPrice.Location = new System.Drawing.Point(863, 61);
            this.lowPrice.Name = "lowPrice";
            this.lowPrice.Size = new System.Drawing.Size(95, 23);
            this.lowPrice.TabIndex = 12;
            this.lowPrice.Text = "label3";
            this.lowPrice.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(244)))), ((int)(((byte)(244)))));
            this.ClientSize = new System.Drawing.Size(1200, 675);
            this.Controls.Add(this.lowPrice);
            this.Controls.Add(this.nowPrice);
            this.Controls.Add(this.highPrice);
            this.Controls.Add(this.displayedCompany);
            this.Controls.Add(this.pictureBox4);
            this.Controls.Add(this.pictureBox3);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.WatchlistBtn);
            this.Controls.Add(this.AccountBtn);
            this.Controls.Add(this.StockBtn);
            this.Controls.Add(this.TradeBtn);
            this.Controls.Add(this.showLogo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Location = new System.Drawing.Point(500, 200);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Main";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Time Trade";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.OnClosing);
            this.Load += new System.EventHandler(this.OnLoad);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.AllowMove);
            ((System.ComponentModel.ISupportInitialize)(this.showLogo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        public System.Windows.Forms.PictureBox showLogo;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.PictureBox pictureBox4;
        public System.Windows.Forms.Label displayedCompany;
        public System.Windows.Forms.Button TradeBtn;
        public System.Windows.Forms.Button StockBtn;
        public System.Windows.Forms.Button AccountBtn;
        public System.Windows.Forms.Button WatchlistBtn;
        private System.Windows.Forms.Label highPrice;
        private System.Windows.Forms.Label nowPrice;
        private System.Windows.Forms.Label lowPrice;
    }
}

