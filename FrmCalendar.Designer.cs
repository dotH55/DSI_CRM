namespace DSI_CRM
{
    partial class FrmCalendar
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmCalendar));
            this.Top_Pn = new System.Windows.Forms.Panel();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.Close_Bt = new System.Windows.Forms.Button();
            this.flowLayoutPanel2 = new System.Windows.Forms.FlowLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.Banner_Pn = new System.Windows.Forms.Panel();
            this.flowLayoutPanel5 = new System.Windows.Forms.FlowLayoutPanel();
            this.Next_Bt = new System.Windows.Forms.Button();
            this.Today_Bt = new System.Windows.Forms.Button();
            this.Previous_Bt = new System.Windows.Forms.Button();
            this.Current_Date_Lb = new System.Windows.Forms.Label();
            this.flowLayoutPanel4 = new System.Windows.Forms.FlowLayoutPanel();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.FPDays = new System.Windows.Forms.FlowLayoutPanel();
            this.Top_Pn.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.flowLayoutPanel2.SuspendLayout();
            this.Banner_Pn.SuspendLayout();
            this.flowLayoutPanel5.SuspendLayout();
            this.flowLayoutPanel4.SuspendLayout();
            this.SuspendLayout();
            // 
            // Top_Pn
            // 
            this.Top_Pn.BackColor = System.Drawing.Color.Black;
            this.Top_Pn.Controls.Add(this.flowLayoutPanel1);
            this.Top_Pn.Controls.Add(this.flowLayoutPanel2);
            this.Top_Pn.Dock = System.Windows.Forms.DockStyle.Top;
            this.Top_Pn.Location = new System.Drawing.Point(0, 0);
            this.Top_Pn.Name = "Top_Pn";
            this.Top_Pn.Size = new System.Drawing.Size(949, 30);
            this.Top_Pn.TabIndex = 1;
            this.Top_Pn.Paint += new System.Windows.Forms.PaintEventHandler(this.Top_Pn_Paint);
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.Close_Bt);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Right;
            this.flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(868, 0);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.flowLayoutPanel1.Size = new System.Drawing.Size(81, 30);
            this.flowLayoutPanel1.TabIndex = 1;
            // 
            // Close_Bt
            // 
            this.Close_Bt.BackColor = System.Drawing.Color.Transparent;
            this.Close_Bt.FlatAppearance.BorderSize = 0;
            this.Close_Bt.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(219)))), ((int)(((byte)(6)))), ((int)(((byte)(44)))));
            this.Close_Bt.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.Close_Bt.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Close_Bt.Image = global::DSI_CRM.Properties.Resources.New_Close_Bt;
            this.Close_Bt.Location = new System.Drawing.Point(41, 3);
            this.Close_Bt.Name = "Close_Bt";
            this.Close_Bt.Size = new System.Drawing.Size(32, 24);
            this.Close_Bt.TabIndex = 1;
            this.Close_Bt.UseVisualStyleBackColor = false;
            this.Close_Bt.Click += new System.EventHandler(this.Close_Bt_Click_1);
            // 
            // flowLayoutPanel2
            // 
            this.flowLayoutPanel2.Controls.Add(this.label1);
            this.flowLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Left;
            this.flowLayoutPanel2.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanel2.Name = "flowLayoutPanel2";
            this.flowLayoutPanel2.Padding = new System.Windows.Forms.Padding(5);
            this.flowLayoutPanel2.Size = new System.Drawing.Size(114, 30);
            this.flowLayoutPanel2.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(8, 5);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(82, 19);
            this.label1.TabIndex = 1;
            this.label1.Text = "Calendar";
            // 
            // Banner_Pn
            // 
            this.Banner_Pn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(53)))), ((int)(((byte)(53)))));
            this.Banner_Pn.Controls.Add(this.flowLayoutPanel5);
            this.Banner_Pn.Controls.Add(this.Current_Date_Lb);
            this.Banner_Pn.Dock = System.Windows.Forms.DockStyle.Top;
            this.Banner_Pn.Location = new System.Drawing.Point(0, 30);
            this.Banner_Pn.Name = "Banner_Pn";
            this.Banner_Pn.Size = new System.Drawing.Size(949, 63);
            this.Banner_Pn.TabIndex = 2;
            // 
            // flowLayoutPanel5
            // 
            this.flowLayoutPanel5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(53)))), ((int)(((byte)(53)))));
            this.flowLayoutPanel5.Controls.Add(this.Next_Bt);
            this.flowLayoutPanel5.Controls.Add(this.Today_Bt);
            this.flowLayoutPanel5.Controls.Add(this.Previous_Bt);
            this.flowLayoutPanel5.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.flowLayoutPanel5.Location = new System.Drawing.Point(690, 18);
            this.flowLayoutPanel5.Name = "flowLayoutPanel5";
            this.flowLayoutPanel5.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.flowLayoutPanel5.Size = new System.Drawing.Size(250, 35);
            this.flowLayoutPanel5.TabIndex = 5;
            // 
            // Next_Bt
            // 
            this.Next_Bt.BackColor = System.Drawing.Color.Transparent;
            this.Next_Bt.FlatAppearance.BorderSize = 0;
            this.Next_Bt.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.Next_Bt.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.Next_Bt.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Next_Bt.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Next_Bt.Image = global::DSI_CRM.Properties.Resources.icons8_Right_Button_24px_1;
            this.Next_Bt.Location = new System.Drawing.Point(178, 3);
            this.Next_Bt.Name = "Next_Bt";
            this.Next_Bt.Size = new System.Drawing.Size(64, 29);
            this.Next_Bt.TabIndex = 11;
            this.Next_Bt.UseVisualStyleBackColor = false;
            this.Next_Bt.Click += new System.EventHandler(this.Next_Bt_Click_2);
            // 
            // Today_Bt
            // 
            this.Today_Bt.BackColor = System.Drawing.Color.Transparent;
            this.Today_Bt.FlatAppearance.BorderSize = 0;
            this.Today_Bt.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.Today_Bt.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.Today_Bt.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Today_Bt.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Today_Bt.Image = global::DSI_CRM.Properties.Resources.icons8_Today_24px;
            this.Today_Bt.Location = new System.Drawing.Point(108, 3);
            this.Today_Bt.Name = "Today_Bt";
            this.Today_Bt.Size = new System.Drawing.Size(64, 29);
            this.Today_Bt.TabIndex = 10;
            this.Today_Bt.UseVisualStyleBackColor = false;
            this.Today_Bt.Click += new System.EventHandler(this.Today_Bt_Click_2);
            // 
            // Previous_Bt
            // 
            this.Previous_Bt.BackColor = System.Drawing.Color.Transparent;
            this.Previous_Bt.FlatAppearance.BorderSize = 0;
            this.Previous_Bt.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.Previous_Bt.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.Previous_Bt.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Previous_Bt.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Previous_Bt.Image = global::DSI_CRM.Properties.Resources.icons8_Prev_24px_1;
            this.Previous_Bt.Location = new System.Drawing.Point(38, 3);
            this.Previous_Bt.Name = "Previous_Bt";
            this.Previous_Bt.Size = new System.Drawing.Size(64, 29);
            this.Previous_Bt.TabIndex = 9;
            this.Previous_Bt.UseVisualStyleBackColor = false;
            this.Previous_Bt.Click += new System.EventHandler(this.Previous_Bt_Click_1);
            // 
            // Current_Date_Lb
            // 
            this.Current_Date_Lb.AutoSize = true;
            this.Current_Date_Lb.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Current_Date_Lb.ForeColor = System.Drawing.Color.White;
            this.Current_Date_Lb.Location = new System.Drawing.Point(12, 18);
            this.Current_Date_Lb.Name = "Current_Date_Lb";
            this.Current_Date_Lb.Size = new System.Drawing.Size(349, 37);
            this.Current_Date_Lb.TabIndex = 2;
            this.Current_Date_Lb.Text = "Friday, September 18th";
            // 
            // flowLayoutPanel4
            // 
            this.flowLayoutPanel4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(53)))), ((int)(((byte)(53)))));
            this.flowLayoutPanel4.Controls.Add(this.label7);
            this.flowLayoutPanel4.Controls.Add(this.label6);
            this.flowLayoutPanel4.Controls.Add(this.label5);
            this.flowLayoutPanel4.Controls.Add(this.label4);
            this.flowLayoutPanel4.Controls.Add(this.label3);
            this.flowLayoutPanel4.Controls.Add(this.label2);
            this.flowLayoutPanel4.Controls.Add(this.label8);
            this.flowLayoutPanel4.Dock = System.Windows.Forms.DockStyle.Top;
            this.flowLayoutPanel4.Location = new System.Drawing.Point(0, 93);
            this.flowLayoutPanel4.Name = "flowLayoutPanel4";
            this.flowLayoutPanel4.Padding = new System.Windows.Forms.Padding(5);
            this.flowLayoutPanel4.Size = new System.Drawing.Size(949, 44);
            this.flowLayoutPanel4.TabIndex = 5;
            // 
            // label7
            // 
            this.label7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(8, 5);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(128, 32);
            this.label7.TabIndex = 13;
            this.label7.Text = "Sunday";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label6
            // 
            this.label6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(142, 5);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(128, 32);
            this.label6.TabIndex = 12;
            this.label6.Text = "Monday";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label6.Click += new System.EventHandler(this.label6_Click);
            // 
            // label5
            // 
            this.label5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(276, 5);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(128, 32);
            this.label5.TabIndex = 11;
            this.label5.Text = "Tuesday";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label4
            // 
            this.label4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(410, 5);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(128, 32);
            this.label4.TabIndex = 10;
            this.label4.Text = "Wednesday";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(544, 5);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(128, 32);
            this.label3.TabIndex = 9;
            this.label3.Text = "Thursday";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(678, 5);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(128, 32);
            this.label2.TabIndex = 8;
            this.label2.Text = "Friday";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label8
            // 
            this.label8.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(812, 5);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(128, 32);
            this.label8.TabIndex = 7;
            this.label8.Text = "Saturday";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // FPDays
            // 
            this.FPDays.BackColor = System.Drawing.Color.White;
            this.FPDays.Dock = System.Windows.Forms.DockStyle.Fill;
            this.FPDays.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FPDays.Location = new System.Drawing.Point(0, 137);
            this.FPDays.Name = "FPDays";
            this.FPDays.Padding = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.FPDays.Size = new System.Drawing.Size(949, 673);
            this.FPDays.TabIndex = 6;
            // 
            // FrmCalendar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(949, 810);
            this.Controls.Add(this.FPDays);
            this.Controls.Add(this.flowLayoutPanel4);
            this.Controls.Add(this.Banner_Pn);
            this.Controls.Add(this.Top_Pn);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FrmCalendar";
            this.Text = "Calendar";
            this.Load += new System.EventHandler(this.FrmCalendar_Load);
            this.Top_Pn.ResumeLayout(false);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel2.ResumeLayout(false);
            this.flowLayoutPanel2.PerformLayout();
            this.Banner_Pn.ResumeLayout(false);
            this.Banner_Pn.PerformLayout();
            this.flowLayoutPanel5.ResumeLayout(false);
            this.flowLayoutPanel4.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel Top_Pn;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Button Close_Bt;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel Banner_Pn;
        private System.Windows.Forms.Label Current_Date_Lb;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel4;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.FlowLayoutPanel FPDays;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel5;
        private System.Windows.Forms.Button Next_Bt;
        private System.Windows.Forms.Button Today_Bt;
        private System.Windows.Forms.Button Previous_Bt;
    }
}