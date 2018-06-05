namespace mainSample
{
    partial class Trade
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
            this.canvas = new System.Windows.Forms.Panel();
            this.orderLimit = new System.Windows.Forms.NumericUpDown();
            this.orderCount = new System.Windows.Forms.NumericUpDown();
            this.btnPlaceOrder = new System.Windows.Forms.Button();
            this.btnMarketSelected = new System.Windows.Forms.Button();
            this.btnLimitSelected = new System.Windows.Forms.Button();
            this.btnBuySelected = new System.Windows.Forms.Button();
            this.btnSellSelected = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.orderLimit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.orderCount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // canvas
            // 
            this.canvas.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(49)))), ((int)(((byte)(66)))));
            this.canvas.Location = new System.Drawing.Point(0, 10);
            this.canvas.Name = "canvas";
            this.canvas.Size = new System.Drawing.Size(975, 400);
            this.canvas.TabIndex = 5;
            this.canvas.Paint += new System.Windows.Forms.PaintEventHandler(this.CanvasPaint);
            // 
            // orderLimit
            // 
            this.orderLimit.Enabled = false;
            this.orderLimit.Location = new System.Drawing.Point(407, 495);
            this.orderLimit.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.orderLimit.Name = "orderLimit";
            this.orderLimit.Size = new System.Drawing.Size(278, 20);
            this.orderLimit.TabIndex = 54;
            this.orderLimit.TabStop = false;
            this.orderLimit.ThousandsSeparator = true;
            // 
            // orderCount
            // 
            this.orderCount.Location = new System.Drawing.Point(66, 494);
            this.orderCount.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.orderCount.Name = "orderCount";
            this.orderCount.Size = new System.Drawing.Size(278, 20);
            this.orderCount.TabIndex = 51;
            this.orderCount.TabStop = false;
            this.orderCount.ThousandsSeparator = true;
            // 
            // btnPlaceOrder
            // 
            this.btnPlaceOrder.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnPlaceOrder.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(131)))), ((int)(((byte)(84)))));
            this.btnPlaceOrder.FlatAppearance.BorderSize = 0;
            this.btnPlaceOrder.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPlaceOrder.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.btnPlaceOrder.ForeColor = System.Drawing.Color.White;
            this.btnPlaceOrder.Location = new System.Drawing.Point(751, 444);
            this.btnPlaceOrder.Name = "btnPlaceOrder";
            this.btnPlaceOrder.Size = new System.Drawing.Size(134, 117);
            this.btnPlaceOrder.TabIndex = 55;
            this.btnPlaceOrder.TabStop = false;
            this.btnPlaceOrder.Text = "PLACE";
            this.btnPlaceOrder.UseVisualStyleBackColor = false;
            this.btnPlaceOrder.Click += new System.EventHandler(this.PlaceOrder);
            // 
            // btnMarketSelected
            // 
            this.btnMarketSelected.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(191)))), ((int)(((byte)(191)))));
            this.btnMarketSelected.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnMarketSelected.Enabled = false;
            this.btnMarketSelected.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(131)))), ((int)(((byte)(84)))));
            this.btnMarketSelected.FlatAppearance.BorderSize = 0;
            this.btnMarketSelected.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMarketSelected.Location = new System.Drawing.Point(408, 521);
            this.btnMarketSelected.Name = "btnMarketSelected";
            this.btnMarketSelected.Size = new System.Drawing.Size(133, 23);
            this.btnMarketSelected.TabIndex = 53;
            this.btnMarketSelected.TabStop = false;
            this.btnMarketSelected.Text = "MARKET";
            this.btnMarketSelected.UseVisualStyleBackColor = false;
            this.btnMarketSelected.Click += new System.EventHandler(this.OrderSelection);
            // 
            // btnLimitSelected
            // 
            this.btnLimitSelected.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnLimitSelected.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(131)))), ((int)(((byte)(84)))));
            this.btnLimitSelected.FlatAppearance.BorderSize = 0;
            this.btnLimitSelected.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLimitSelected.ForeColor = System.Drawing.Color.White;
            this.btnLimitSelected.Location = new System.Drawing.Point(550, 521);
            this.btnLimitSelected.Name = "btnLimitSelected";
            this.btnLimitSelected.Size = new System.Drawing.Size(135, 23);
            this.btnLimitSelected.TabIndex = 52;
            this.btnLimitSelected.TabStop = false;
            this.btnLimitSelected.Text = "LIMIT";
            this.btnLimitSelected.UseVisualStyleBackColor = false;
            this.btnLimitSelected.Click += new System.EventHandler(this.OrderSelection);
            // 
            // btnBuySelected
            // 
            this.btnBuySelected.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(191)))), ((int)(((byte)(191)))));
            this.btnBuySelected.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnBuySelected.Enabled = false;
            this.btnBuySelected.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(131)))), ((int)(((byte)(84)))));
            this.btnBuySelected.FlatAppearance.BorderSize = 0;
            this.btnBuySelected.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBuySelected.Location = new System.Drawing.Point(66, 521);
            this.btnBuySelected.Name = "btnBuySelected";
            this.btnBuySelected.Size = new System.Drawing.Size(135, 23);
            this.btnBuySelected.TabIndex = 18;
            this.btnBuySelected.TabStop = false;
            this.btnBuySelected.Text = "BUY";
            this.btnBuySelected.UseVisualStyleBackColor = false;
            this.btnBuySelected.Click += new System.EventHandler(this.OrderSelection);
            // 
            // btnSellSelected
            // 
            this.btnSellSelected.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnSellSelected.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(131)))), ((int)(((byte)(84)))));
            this.btnSellSelected.FlatAppearance.BorderSize = 0;
            this.btnSellSelected.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSellSelected.ForeColor = System.Drawing.Color.White;
            this.btnSellSelected.Location = new System.Drawing.Point(209, 521);
            this.btnSellSelected.Name = "btnSellSelected";
            this.btnSellSelected.Size = new System.Drawing.Size(135, 23);
            this.btnSellSelected.TabIndex = 17;
            this.btnSellSelected.TabStop = false;
            this.btnSellSelected.Text = "SELL";
            this.btnSellSelected.UseVisualStyleBackColor = false;
            this.btnSellSelected.Click += new System.EventHandler(this.OrderSelection);
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(158)))), ((int)(((byte)(86)))), ((int)(((byte)(55)))));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(238)))), ((int)(((byte)(238)))));
            this.label1.Location = new System.Drawing.Point(70, 466);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(270, 20);
            this.label1.TabIndex = 56;
            this.label1.Text = "TRANSACTIONS";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(158)))), ((int)(((byte)(86)))), ((int)(((byte)(55)))));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(238)))), ((int)(((byte)(238)))));
            this.label2.Location = new System.Drawing.Point(410, 466);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(270, 20);
            this.label2.TabIndex = 57;
            this.label2.Text = "ORDERS";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(66, 462);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(278, 27);
            this.pictureBox1.TabIndex = 58;
            this.pictureBox1.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Location = new System.Drawing.Point(407, 462);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(278, 27);
            this.pictureBox2.TabIndex = 59;
            this.pictureBox2.TabStop = false;
            // 
            // Trade
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(131)))), ((int)(((byte)(84)))));
            this.ClientSize = new System.Drawing.Size(975, 585);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnPlaceOrder);
            this.Controls.Add(this.orderLimit);
            this.Controls.Add(this.btnMarketSelected);
            this.Controls.Add(this.btnLimitSelected);
            this.Controls.Add(this.orderCount);
            this.Controls.Add(this.btnBuySelected);
            this.Controls.Add(this.btnSellSelected);
            this.Controls.Add(this.canvas);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.pictureBox2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Trade";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Trade";
            this.Load += new System.EventHandler(this.OnLoad);
            ((System.ComponentModel.ISupportInitialize)(this.orderLimit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.orderCount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button btnBuySelected;
        private System.Windows.Forms.Button btnSellSelected;
        private System.Windows.Forms.Button btnPlaceOrder;
        private System.Windows.Forms.NumericUpDown orderLimit;
        private System.Windows.Forms.Button btnMarketSelected;
        private System.Windows.Forms.Button btnLimitSelected;
        private System.Windows.Forms.NumericUpDown orderCount;
        public System.Windows.Forms.Panel canvas;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
    }
}