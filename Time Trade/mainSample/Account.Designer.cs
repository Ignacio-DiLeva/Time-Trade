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
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.ordersHead = new System.Windows.Forms.Panel();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.portfolioLabels.SuspendLayout();
            this.ordersHead.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
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
            this.panel_sellOrders.Location = new System.Drawing.Point(45, 128);
            this.panel_sellOrders.Name = "panel_sellOrders";
            this.panel_sellOrders.Size = new System.Drawing.Size(884, 410);
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
            // panel_buyOrders
            // 
            this.panel_buyOrders.AutoScroll = true;
            this.panel_buyOrders.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(79)))), ((int)(((byte)(93)))), ((int)(((byte)(117)))));
            this.panel_buyOrders.Location = new System.Drawing.Point(45, 128);
            this.panel_buyOrders.Name = "panel_buyOrders";
            this.panel_buyOrders.Size = new System.Drawing.Size(884, 410);
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
            this.label6.Location = new System.Drawing.Point(750, 13);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(119, 23);
            this.label6.TabIndex = 16;
            this.label6.Text = "Gain/Loss(%)";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label5
            // 
            this.label5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(49)))), ((int)(((byte)(66)))));
            this.label5.Font = new System.Drawing.Font("Arial", 13F);
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(610, 13);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(116, 23);
            this.label5.TabIndex = 15;
            this.label5.Text = "Gain/Loss($)";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // buypriceLabel
            // 
            this.buypriceLabel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(49)))), ((int)(((byte)(66)))));
            this.buypriceLabel.Font = new System.Drawing.Font("Arial", 13F);
            this.buypriceLabel.ForeColor = System.Drawing.Color.White;
            this.buypriceLabel.Location = new System.Drawing.Point(490, 14);
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
            this.costLabel.Location = new System.Drawing.Point(405, 14);
            this.costLabel.Name = "costLabel";
            this.costLabel.Size = new System.Drawing.Size(49, 23);
            this.costLabel.TabIndex = 13;
            this.costLabel.Text = "Cost";
            this.costLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // priceLabel
            // 
            this.priceLabel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(49)))), ((int)(((byte)(66)))));
            this.priceLabel.Font = new System.Drawing.Font("Arial", 13F);
            this.priceLabel.ForeColor = System.Drawing.Color.White;
            this.priceLabel.Location = new System.Drawing.Point(315, 14);
            this.priceLabel.Name = "priceLabel";
            this.priceLabel.Size = new System.Drawing.Size(52, 23);
            this.priceLabel.TabIndex = 12;
            this.priceLabel.Text = "Price";
            this.priceLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // sharesLabel
            // 
            this.sharesLabel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(49)))), ((int)(((byte)(66)))));
            this.sharesLabel.Font = new System.Drawing.Font("Arial", 13F);
            this.sharesLabel.ForeColor = System.Drawing.Color.White;
            this.sharesLabel.Location = new System.Drawing.Point(175, 14);
            this.sharesLabel.Name = "sharesLabel";
            this.sharesLabel.Size = new System.Drawing.Size(80, 23);
            this.sharesLabel.TabIndex = 11;
            this.sharesLabel.Text = "Holdings";
            this.sharesLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // nameLabel
            // 
            this.nameLabel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(49)))), ((int)(((byte)(66)))));
            this.nameLabel.Font = new System.Drawing.Font("Arial", 13F);
            this.nameLabel.ForeColor = System.Drawing.Color.White;
            this.nameLabel.Location = new System.Drawing.Point(12, 14);
            this.nameLabel.Name = "nameLabel";
            this.nameLabel.Size = new System.Drawing.Size(99, 23);
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
            // label11
            // 
            this.label11.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(49)))), ((int)(((byte)(66)))));
            this.label11.Font = new System.Drawing.Font("Arial", 13F);
            this.label11.ForeColor = System.Drawing.Color.White;
            this.label11.Location = new System.Drawing.Point(12, 14);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(99, 23);
            this.label11.TabIndex = 10;
            this.label11.Text = "Name";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label10
            // 
            this.label10.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(49)))), ((int)(((byte)(66)))));
            this.label10.Font = new System.Drawing.Font("Arial", 13F);
            this.label10.ForeColor = System.Drawing.Color.White;
            this.label10.Location = new System.Drawing.Point(302, 14);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(80, 23);
            this.label10.TabIndex = 11;
            this.label10.Text = "Holdings";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label9
            // 
            this.label9.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(49)))), ((int)(((byte)(66)))));
            this.label9.Font = new System.Drawing.Font("Arial", 13F);
            this.label9.ForeColor = System.Drawing.Color.White;
            this.label9.Location = new System.Drawing.Point(634, 14);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(52, 23);
            this.label9.TabIndex = 12;
            this.label9.Text = "Price";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // ordersHead
            // 
            this.ordersHead.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(49)))), ((int)(((byte)(66)))));
            this.ordersHead.Controls.Add(this.label9);
            this.ordersHead.Controls.Add(this.label10);
            this.ordersHead.Controls.Add(this.label11);
            this.ordersHead.Location = new System.Drawing.Point(45, 79);
            this.ordersHead.Name = "ordersHead";
            this.ordersHead.Size = new System.Drawing.Size(884, 49);
            this.ordersHead.TabIndex = 20;
            // 
            // pictureBox3
            // 
            this.pictureBox3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(131)))), ((int)(((byte)(84)))));
            this.pictureBox3.Location = new System.Drawing.Point(0, 0);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(975, 10);
            this.pictureBox3.TabIndex = 23;
            this.pictureBox3.TabStop = false;
            // 
            // Account
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(79)))), ((int)(((byte)(93)))), ((int)(((byte)(117)))));
            this.ClientSize = new System.Drawing.Size(975, 585);
            this.Controls.Add(this.pictureBox3);
            this.Controls.Add(this.panel_sellOrders);
            this.Controls.Add(this.ordersHead);
            this.Controls.Add(this.panel_buyOrders);
            this.Controls.Add(this.showSellorders);
            this.Controls.Add(this.showBuyorders);
            this.Controls.Add(this.showPortfolio);
            this.Controls.Add(this.portfolioLabels);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
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
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.portfolioLabels.ResumeLayout(false);
            this.ordersHead.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel panel_sellOrders;
        private System.Windows.Forms.Label label2;
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
        private System.Windows.Forms.Panel ordersHead;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.PictureBox pictureBox3;
    }
}