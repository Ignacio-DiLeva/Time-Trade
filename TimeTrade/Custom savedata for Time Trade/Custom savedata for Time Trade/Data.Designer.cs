namespace Custom_savedata_for_Time_Trade
{
    partial class Data
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.numericDay = new System.Windows.Forms.NumericUpDown();
            this.numericYear = new System.Windows.Forms.NumericUpDown();
            this.numericMonth = new System.Windows.Forms.NumericUpDown();
            this.button1 = new System.Windows.Forms.Button();
            this.numericMoney = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.profileField = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.numericDay)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericYear)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericMonth)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericMoney)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.White;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label1.Location = new System.Drawing.Point(100, 66);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Initial money:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.White;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label2.Location = new System.Drawing.Point(97, 119);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(100, 20);
            this.label2.TabIndex = 3;
            this.label2.Text = "Initial year:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.Color.White;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label3.Location = new System.Drawing.Point(100, 172);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(100, 20);
            this.label3.TabIndex = 4;
            this.label3.Text = "Initial month:";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label4
            // 
            this.label4.BackColor = System.Drawing.Color.White;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label4.Location = new System.Drawing.Point(97, 220);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(100, 20);
            this.label4.TabIndex = 5;
            this.label4.Text = "Initial day:";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // numericDay
            // 
            this.numericDay.Location = new System.Drawing.Point(89, 243);
            this.numericDay.Maximum = new decimal(new int[] {
            31,
            0,
            0,
            0});
            this.numericDay.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericDay.Name = "numericDay";
            this.numericDay.Size = new System.Drawing.Size(120, 20);
            this.numericDay.TabIndex = 7;
            this.numericDay.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.numericDay.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // numericYear
            // 
            this.numericYear.Location = new System.Drawing.Point(90, 140);
            this.numericYear.Maximum = new decimal(new int[] {
            2009,
            0,
            0,
            0});
            this.numericYear.Minimum = new decimal(new int[] {
            2007,
            0,
            0,
            0});
            this.numericYear.Name = "numericYear";
            this.numericYear.Size = new System.Drawing.Size(120, 20);
            this.numericYear.TabIndex = 9;
            this.numericYear.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.numericYear.Value = new decimal(new int[] {
            2007,
            0,
            0,
            0});
            // 
            // numericMonth
            // 
            this.numericMonth.Location = new System.Drawing.Point(89, 195);
            this.numericMonth.Maximum = new decimal(new int[] {
            12,
            0,
            0,
            0});
            this.numericMonth.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericMonth.Name = "numericMonth";
            this.numericMonth.Size = new System.Drawing.Size(120, 20);
            this.numericMonth.TabIndex = 10;
            this.numericMonth.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.numericMonth.Value = new decimal(new int[] {
            6,
            0,
            0,
            0});
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(107, 315);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 11;
            this.button1.Text = "NEXT";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.CheckData);
            // 
            // numericMoney
            // 
            this.numericMoney.Increment = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.numericMoney.Location = new System.Drawing.Point(89, 89);
            this.numericMoney.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.numericMoney.Minimum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.numericMoney.Name = "numericMoney";
            this.numericMoney.Size = new System.Drawing.Size(120, 20);
            this.numericMoney.TabIndex = 12;
            this.numericMoney.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.numericMoney.Value = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            // 
            // label5
            // 
            this.label5.BackColor = System.Drawing.Color.White;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label5.Location = new System.Drawing.Point(97, 270);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(100, 20);
            this.label5.TabIndex = 13;
            this.label5.Text = "Profile Name:";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // profileField
            // 
            this.profileField.Location = new System.Drawing.Point(90, 289);
            this.profileField.Name = "profileField";
            this.profileField.Size = new System.Drawing.Size(120, 20);
            this.profileField.TabIndex = 14;
            this.profileField.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // Data
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(300, 346);
            this.Controls.Add(this.profileField);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.numericMoney);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.numericMonth);
            this.Controls.Add(this.numericYear);
            this.Controls.Add(this.numericDay);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "Data";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.OnClosing);
            ((System.ComponentModel.ISupportInitialize)(this.numericDay)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericYear)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericMonth)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericMoney)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown numericDay;
        private System.Windows.Forms.NumericUpDown numericYear;
        private System.Windows.Forms.NumericUpDown numericMonth;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.NumericUpDown numericMoney;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox profileField;
    }
}

