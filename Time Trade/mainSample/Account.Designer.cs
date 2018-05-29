namespace mainSample
{
    partial class Account
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
            this.label3 = new System.Windows.Forms.Label();
            this.panel_sellOrders = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panel_portfolio = new System.Windows.Forms.Panel();
            this.gainloss2_label = new System.Windows.Forms.Label();
            this.gainloss1_label = new System.Windows.Forms.Label();
            this.buyprice_label = new System.Windows.Forms.Label();
            this.Cost_label = new System.Windows.Forms.Label();
            this.price_label = new System.Windows.Forms.Label();
            this.Shares_label = new System.Windows.Forms.Label();
            this.symbol_label = new System.Windows.Forms.Label();
            this.panel_buyOrders = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panel_portfolio.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(79)))), ((int)(((byte)(93)))), ((int)(((byte)(117)))));
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(64, 362);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(173, 33);
            this.label3.TabIndex = 13;
            this.label3.Text = "Sell Orders";
            this.label3.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // panel_sellOrders
            // 
            this.panel_sellOrders.AutoScroll = true;
            this.panel_sellOrders.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(79)))), ((int)(((byte)(93)))), ((int)(((byte)(117)))));
            this.panel_sellOrders.Location = new System.Drawing.Point(55, 383);
            this.panel_sellOrders.Name = "panel_sellOrders";
            this.panel_sellOrders.Size = new System.Drawing.Size(259, 186);
            this.panel_sellOrders.TabIndex = 9;
            this.panel_sellOrders.Paint += new System.Windows.Forms.PaintEventHandler(this.Paint_table);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(79)))), ((int)(((byte)(93)))), ((int)(((byte)(117)))));
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(64, 141);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(173, 33);
            this.label2.TabIndex = 12;
            this.label2.Text = "Buy Orders";
            this.label2.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(79)))), ((int)(((byte)(93)))), ((int)(((byte)(117)))));
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(548, 2);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(208, 55);
            this.label1.TabIndex = 10;
            this.label1.Text = "Portfolio";
            // 
            // panel_portfolio
            // 
            this.panel_portfolio.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(79)))), ((int)(((byte)(93)))), ((int)(((byte)(117)))));
            this.panel_portfolio.Controls.Add(this.gainloss2_label);
            this.panel_portfolio.Controls.Add(this.gainloss1_label);
            this.panel_portfolio.Controls.Add(this.buyprice_label);
            this.panel_portfolio.Controls.Add(this.Cost_label);
            this.panel_portfolio.Controls.Add(this.price_label);
            this.panel_portfolio.Controls.Add(this.Shares_label);
            this.panel_portfolio.Controls.Add(this.symbol_label);
            this.panel_portfolio.ForeColor = System.Drawing.Color.White;
            this.panel_portfolio.Location = new System.Drawing.Point(339, 71);
            this.panel_portfolio.Name = "panel_portfolio";
            this.panel_portfolio.Size = new System.Drawing.Size(598, 498);
            this.panel_portfolio.TabIndex = 11;
            this.panel_portfolio.Paint += new System.Windows.Forms.PaintEventHandler(this.Paint_portfolio);
            // 
            // gainloss2_label
            // 
            this.gainloss2_label.AutoSize = true;
            this.gainloss2_label.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.gainloss2_label.ForeColor = System.Drawing.Color.White;
            this.gainloss2_label.Location = new System.Drawing.Point(509, 21);
            this.gainloss2_label.Name = "gainloss2_label";
            this.gainloss2_label.Size = new System.Drawing.Size(62, 30);
            this.gainloss2_label.TabIndex = 6;
            this.gainloss2_label.Tag = "initial_label";
            this.gainloss2_label.Text = "Gain/Loss\r\n      (%)";
            // 
            // gainloss1_label
            // 
            this.gainloss1_label.AutoSize = true;
            this.gainloss1_label.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.gainloss1_label.ForeColor = System.Drawing.Color.White;
            this.gainloss1_label.Location = new System.Drawing.Point(417, 21);
            this.gainloss1_label.Name = "gainloss1_label";
            this.gainloss1_label.Size = new System.Drawing.Size(65, 30);
            this.gainloss1_label.TabIndex = 5;
            this.gainloss1_label.Tag = "initial_label";
            this.gainloss1_label.Text = "Gain/Loss \r\n      ($)";
            // 
            // buyprice_label
            // 
            this.buyprice_label.AutoSize = true;
            this.buyprice_label.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.buyprice_label.ForeColor = System.Drawing.Color.White;
            this.buyprice_label.Location = new System.Drawing.Point(329, 21);
            this.buyprice_label.Name = "buyprice_label";
            this.buyprice_label.Size = new System.Drawing.Size(57, 15);
            this.buyprice_label.TabIndex = 4;
            this.buyprice_label.Tag = "initial_label";
            this.buyprice_label.Text = "Buy price";
            // 
            // Cost_label
            // 
            this.Cost_label.AutoSize = true;
            this.Cost_label.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.Cost_label.ForeColor = System.Drawing.Color.White;
            this.Cost_label.Location = new System.Drawing.Point(251, 21);
            this.Cost_label.Name = "Cost_label";
            this.Cost_label.Size = new System.Drawing.Size(31, 15);
            this.Cost_label.TabIndex = 3;
            this.Cost_label.Tag = "initial_label";
            this.Cost_label.Text = "Cost";
            // 
            // price_label
            // 
            this.price_label.AutoSize = true;
            this.price_label.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.price_label.ForeColor = System.Drawing.Color.White;
            this.price_label.Location = new System.Drawing.Point(172, 21);
            this.price_label.Name = "price_label";
            this.price_label.Size = new System.Drawing.Size(47, 30);
            this.price_label.TabIndex = 2;
            this.price_label.Tag = "initial_label";
            this.price_label.Text = "Current\r\nprice";
            // 
            // Shares_label
            // 
            this.Shares_label.AutoSize = true;
            this.Shares_label.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.Shares_label.ForeColor = System.Drawing.Color.White;
            this.Shares_label.Location = new System.Drawing.Point(94, 21);
            this.Shares_label.Name = "Shares_label";
            this.Shares_label.Size = new System.Drawing.Size(46, 15);
            this.Shares_label.TabIndex = 1;
            this.Shares_label.Tag = "initial_label";
            this.Shares_label.Text = "Shares";
            // 
            // symbol_label
            // 
            this.symbol_label.AutoSize = true;
            this.symbol_label.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.symbol_label.ForeColor = System.Drawing.Color.White;
            this.symbol_label.Location = new System.Drawing.Point(20, 21);
            this.symbol_label.Name = "symbol_label";
            this.symbol_label.Size = new System.Drawing.Size(48, 15);
            this.symbol_label.TabIndex = 0;
            this.symbol_label.Tag = "initial_label";
            this.symbol_label.Text = "Symbol";
            // 
            // panel_buyOrders
            // 
            this.panel_buyOrders.AutoScroll = true;
            this.panel_buyOrders.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(79)))), ((int)(((byte)(93)))), ((int)(((byte)(117)))));
            this.panel_buyOrders.Location = new System.Drawing.Point(54, 192);
            this.panel_buyOrders.Name = "panel_buyOrders";
            this.panel_buyOrders.Size = new System.Drawing.Size(259, 167);
            this.panel_buyOrders.TabIndex = 8;
            this.panel_buyOrders.Paint += new System.Windows.Forms.PaintEventHandler(this.Paint_table);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(131)))), ((int)(((byte)(84)))));
            this.pictureBox1.Location = new System.Drawing.Point(37, 71);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(900, 475);
            this.pictureBox1.TabIndex = 15;
            this.pictureBox1.TabStop = false;
            // 
            // Account
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(79)))), ((int)(((byte)(93)))), ((int)(((byte)(117)))));
            this.ClientSize = new System.Drawing.Size(975, 585);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.panel_sellOrders);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.panel_portfolio);
            this.Controls.Add(this.panel_buyOrders);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(1200, 664);
            this.MinimizeBox = false;
            this.Name = "Account";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Account";
            this.TransparencyKey = System.Drawing.Color.Lime;
            this.Load += new System.EventHandler(this.OnLoad);
            this.panel_portfolio.ResumeLayout(false);
            this.panel_portfolio.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel panel_sellOrders;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel_portfolio;
        private System.Windows.Forms.Label gainloss2_label;
        private System.Windows.Forms.Label gainloss1_label;
        private System.Windows.Forms.Label buyprice_label;
        private System.Windows.Forms.Label Cost_label;
        private System.Windows.Forms.Label price_label;
        private System.Windows.Forms.Label Shares_label;
        private System.Windows.Forms.Label symbol_label;
        private System.Windows.Forms.Panel panel_buyOrders;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}