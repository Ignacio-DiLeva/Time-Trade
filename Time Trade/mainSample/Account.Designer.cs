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
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.portfolioLabels = new System.Windows.Forms.Panel();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.buypriceLabel = new System.Windows.Forms.Label();
            this.costLabel = new System.Windows.Forms.Label();
            this.priceLabel = new System.Windows.Forms.Label();
            this.sharesLabel = new System.Windows.Forms.Label();
            this.nameLabel = new System.Windows.Forms.Label();
            this.showPortfolio = new System.Windows.Forms.Button();
            this.showBuyorders = new System.Windows.Forms.Button();
            this.showSellorders = new System.Windows.Forms.Button();
            this.panel_portfolio.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.portfolioLabels.SuspendLayout();
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
            this.panel_sellOrders.Location = new System.Drawing.Point(960, 12);
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
            this.panel_portfolio.Location = new System.Drawing.Point(960, 415);
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
            this.panel_buyOrders.Location = new System.Drawing.Point(960, 214);
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
            // pictureBox2
            // 
            this.pictureBox2.Location = new System.Drawing.Point(45, 79);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(884, 459);
            this.pictureBox2.TabIndex = 16;
            this.pictureBox2.TabStop = false;
            // 
            // portfolioLabels
            // 
            this.portfolioLabels.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(49)))), ((int)(((byte)(66)))));
            this.portfolioLabels.Controls.Add(this.label6);
            this.portfolioLabels.Controls.Add(this.label5);
            this.portfolioLabels.Controls.Add(this.buypriceLabel);
            this.portfolioLabels.Controls.Add(this.costLabel);
            this.portfolioLabels.Controls.Add(this.priceLabel);
            this.portfolioLabels.Controls.Add(this.sharesLabel);
            this.portfolioLabels.Controls.Add(this.nameLabel);
            this.portfolioLabels.Location = new System.Drawing.Point(45, 79);
            this.portfolioLabels.Name = "portfolioLabels";
            this.portfolioLabels.Size = new System.Drawing.Size(884, 49);
            this.portfolioLabels.TabIndex = 19;
            // 
            // label6
            // 
            this.label6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(49)))), ((int)(((byte)(66)))));
            this.label6.Font = new System.Drawing.Font("Arial", 13F);
            this.label6.ForeColor = System.Drawing.Color.White;
            this.label6.Location = new System.Drawing.Point(725, 13);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(130, 23);
            this.label6.TabIndex = 16;
            this.label6.Text = "Gain/Loss(%)";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label5
            // 
            this.label5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(49)))), ((int)(((byte)(66)))));
            this.label5.Font = new System.Drawing.Font("Arial", 13F);
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(588, 13);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(120, 23);
            this.label5.TabIndex = 15;
            this.label5.Text = "Gain/Loss($)";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // buypriceLabel
            // 
            this.buypriceLabel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(49)))), ((int)(((byte)(66)))));
            this.buypriceLabel.Font = new System.Drawing.Font("Arial", 13F);
            this.buypriceLabel.ForeColor = System.Drawing.Color.White;
            this.buypriceLabel.Location = new System.Drawing.Point(472, 13);
            this.buypriceLabel.Name = "buypriceLabel";
            this.buypriceLabel.Size = new System.Drawing.Size(88, 23);
            this.buypriceLabel.TabIndex = 14;
            this.buypriceLabel.Text = "Buy Price";
            this.buypriceLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // costLabel
            // 
            this.costLabel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(49)))), ((int)(((byte)(66)))));
            this.costLabel.Font = new System.Drawing.Font("Arial", 13F);
            this.costLabel.ForeColor = System.Drawing.Color.White;
            this.costLabel.Location = new System.Drawing.Point(365, 13);
            this.costLabel.Name = "costLabel";
            this.costLabel.Size = new System.Drawing.Size(67, 23);
            this.costLabel.TabIndex = 13;
            this.costLabel.Text = "Cost";
            this.costLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // priceLabel
            // 
            this.priceLabel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(49)))), ((int)(((byte)(66)))));
            this.priceLabel.Font = new System.Drawing.Font("Arial", 13F);
            this.priceLabel.ForeColor = System.Drawing.Color.White;
            this.priceLabel.Location = new System.Drawing.Point(260, 13);
            this.priceLabel.Name = "priceLabel";
            this.priceLabel.Size = new System.Drawing.Size(67, 23);
            this.priceLabel.TabIndex = 12;
            this.priceLabel.Text = "Price";
            this.priceLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // sharesLabel
            // 
            this.sharesLabel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(49)))), ((int)(((byte)(66)))));
            this.sharesLabel.Font = new System.Drawing.Font("Arial", 13F);
            this.sharesLabel.ForeColor = System.Drawing.Color.White;
            this.sharesLabel.Location = new System.Drawing.Point(146, 13);
            this.sharesLabel.Name = "sharesLabel";
            this.sharesLabel.Size = new System.Drawing.Size(83, 23);
            this.sharesLabel.TabIndex = 11;
            this.sharesLabel.Text = "Holding";
            this.sharesLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // nameLabel
            // 
            this.nameLabel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(49)))), ((int)(((byte)(66)))));
            this.nameLabel.Font = new System.Drawing.Font("Arial", 13F);
            this.nameLabel.ForeColor = System.Drawing.Color.White;
            this.nameLabel.Location = new System.Drawing.Point(12, 14);
            this.nameLabel.Name = "nameLabel";
            this.nameLabel.Size = new System.Drawing.Size(88, 23);
            this.nameLabel.TabIndex = 10;
            this.nameLabel.Text = "Name";
            this.nameLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // showPortfolio
            // 
            this.showPortfolio.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(131)))), ((int)(((byte)(84)))));
            this.showPortfolio.FlatAppearance.BorderSize = 0;
            this.showPortfolio.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.showPortfolio.Font = new System.Drawing.Font("Arial", 10F);
            this.showPortfolio.ForeColor = System.Drawing.Color.White;
            this.showPortfolio.Location = new System.Drawing.Point(37, 48);
            this.showPortfolio.Name = "showPortfolio";
            this.showPortfolio.Size = new System.Drawing.Size(108, 23);
            this.showPortfolio.TabIndex = 20;
            this.showPortfolio.Text = "Portfolio";
            this.showPortfolio.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            this.showPortfolio.UseVisualStyleBackColor = false;
            this.showPortfolio.Click += new System.EventHandler(this.ShowPortfolio);
            // 
            // showBuyorders
            // 
            this.showBuyorders.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(217)))), ((int)(((byte)(217)))), ((int)(((byte)(217)))));
            this.showBuyorders.FlatAppearance.BorderSize = 0;
            this.showBuyorders.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.showBuyorders.Font = new System.Drawing.Font("Arial", 10F);
            this.showBuyorders.ForeColor = System.Drawing.Color.Black;
            this.showBuyorders.Location = new System.Drawing.Point(145, 48);
            this.showBuyorders.Name = "showBuyorders";
            this.showBuyorders.Size = new System.Drawing.Size(108, 23);
            this.showBuyorders.TabIndex = 21;
            this.showBuyorders.Text = "Buy orders";
            this.showBuyorders.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            this.showBuyorders.UseVisualStyleBackColor = false;
            this.showBuyorders.Click += new System.EventHandler(this.ShowBuyOrders);
            // 
            // showSellorders
            // 
            this.showSellorders.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(217)))), ((int)(((byte)(217)))), ((int)(((byte)(217)))));
            this.showSellorders.FlatAppearance.BorderSize = 0;
            this.showSellorders.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.showSellorders.Font = new System.Drawing.Font("Arial", 10F);
            this.showSellorders.ForeColor = System.Drawing.Color.Black;
            this.showSellorders.Location = new System.Drawing.Point(253, 48);
            this.showSellorders.Name = "showSellorders";
            this.showSellorders.Size = new System.Drawing.Size(108, 23);
            this.showSellorders.TabIndex = 22;
            this.showSellorders.Text = "Sell orders";
            this.showSellorders.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            this.showSellorders.UseVisualStyleBackColor = false;
            this.showSellorders.Click += new System.EventHandler(this.ShowSellOrders);
            // 
            // Account
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(79)))), ((int)(((byte)(93)))), ((int)(((byte)(117)))));
            this.ClientSize = new System.Drawing.Size(975, 585);
            this.Controls.Add(this.showSellorders);
            this.Controls.Add(this.showBuyorders);
            this.Controls.Add(this.showPortfolio);
            this.Controls.Add(this.portfolioLabels);
            this.Controls.Add(this.panel_sellOrders);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
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
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.portfolioLabels.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel panel_sellOrders;
        private System.Windows.Forms.Label label2;
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
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Panel portfolioLabels;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label buypriceLabel;
        private System.Windows.Forms.Label costLabel;
        private System.Windows.Forms.Label priceLabel;
        private System.Windows.Forms.Label sharesLabel;
        private System.Windows.Forms.Label nameLabel;
        private System.Windows.Forms.Button showPortfolio;
        private System.Windows.Forms.Button showBuyorders;
        private System.Windows.Forms.Button showSellorders;
    }
}