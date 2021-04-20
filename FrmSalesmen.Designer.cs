namespace DSI_CRM
{
    partial class FrmSalesmen
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmSalesmen));
            this.label3 = new System.Windows.Forms.Label();
            this.Salesman_Pn = new System.Windows.Forms.FlowLayoutPanel();
            this.Close_Page_Bt = new System.Windows.Forms.Button();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.flp_Pn = new System.Windows.Forms.FlowLayoutPanel();
            this.All_Cb = new System.Windows.Forms.CheckBox();
            this.checkBox2 = new System.Windows.Forms.CheckBox();
            this.checkBox4 = new System.Windows.Forms.CheckBox();
            this.checkBox5 = new System.Windows.Forms.CheckBox();
            this.checkBox3 = new System.Windows.Forms.CheckBox();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.checkBox6 = new System.Windows.Forms.CheckBox();
            this.checkBox7 = new System.Windows.Forms.CheckBox();
            this.checkBox8 = new System.Windows.Forms.CheckBox();
            this.Salesman_Pn.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.flp_Pn.SuspendLayout();
            this.SuspendLayout();
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(13, 5);
            this.label3.Margin = new System.Windows.Forms.Padding(3, 0, 75, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(87, 19);
            this.label3.TabIndex = 0;
            this.label3.Text = "Salesman";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // Salesman_Pn
            // 
            this.Salesman_Pn.BackColor = System.Drawing.Color.Black;
            this.Salesman_Pn.Controls.Add(this.label3);
            this.Salesman_Pn.Controls.Add(this.Close_Page_Bt);
            this.Salesman_Pn.Dock = System.Windows.Forms.DockStyle.Top;
            this.Salesman_Pn.Location = new System.Drawing.Point(0, 0);
            this.Salesman_Pn.Name = "Salesman_Pn";
            this.Salesman_Pn.Padding = new System.Windows.Forms.Padding(10, 5, 5, 5);
            this.Salesman_Pn.Size = new System.Drawing.Size(219, 30);
            this.Salesman_Pn.TabIndex = 8;
            this.Salesman_Pn.Paint += new System.Windows.Forms.PaintEventHandler(this.Salesman_Pn_Paint);
            // 
            // Close_Page_Bt
            // 
            this.Close_Page_Bt.BackColor = System.Drawing.Color.Transparent;
            this.Close_Page_Bt.FlatAppearance.BorderSize = 0;
            this.Close_Page_Bt.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.Close_Page_Bt.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Close_Page_Bt.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Close_Page_Bt.ForeColor = System.Drawing.Color.Transparent;
            this.Close_Page_Bt.Image = global::DSI_CRM.Properties.Resources.New_Close_Bt;
            this.Close_Page_Bt.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.Close_Page_Bt.Location = new System.Drawing.Point(178, 8);
            this.Close_Page_Bt.Name = "Close_Page_Bt";
            this.Close_Page_Bt.Size = new System.Drawing.Size(32, 16);
            this.Close_Page_Bt.TabIndex = 20;
            this.Close_Page_Bt.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.Close_Page_Bt.UseVisualStyleBackColor = false;
            this.Close_Page_Bt.Click += new System.EventHandler(this.Close_Page_Bt_Click);
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.BackColor = System.Drawing.Color.Black;
            this.flowLayoutPanel1.Controls.Add(this.flp_Pn);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 30);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.flowLayoutPanel1.Size = new System.Drawing.Size(219, 313);
            this.flowLayoutPanel1.TabIndex = 9;
            // 
            // flp_Pn
            // 
            this.flp_Pn.AutoScroll = true;
            this.flp_Pn.BackColor = System.Drawing.Color.White;
            this.flp_Pn.Controls.Add(this.All_Cb);
            this.flp_Pn.Controls.Add(this.checkBox2);
            this.flp_Pn.Controls.Add(this.checkBox4);
            this.flp_Pn.Controls.Add(this.checkBox5);
            this.flp_Pn.Controls.Add(this.checkBox3);
            this.flp_Pn.Controls.Add(this.checkBox1);
            this.flp_Pn.Controls.Add(this.checkBox6);
            this.flp_Pn.Controls.Add(this.checkBox7);
            this.flp_Pn.Controls.Add(this.checkBox8);
            this.flp_Pn.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.flp_Pn.Location = new System.Drawing.Point(8, 3);
            this.flp_Pn.Name = "flp_Pn";
            this.flp_Pn.Padding = new System.Windows.Forms.Padding(5);
            this.flp_Pn.Size = new System.Drawing.Size(203, 298);
            this.flp_Pn.TabIndex = 10;
            // 
            // All_Cb
            // 
            this.All_Cb.AutoSize = true;
            this.All_Cb.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.All_Cb.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.All_Cb.ForeColor = System.Drawing.Color.Black;
            this.All_Cb.Location = new System.Drawing.Point(8, 8);
            this.All_Cb.Name = "All_Cb";
            this.All_Cb.Size = new System.Drawing.Size(45, 27);
            this.All_Cb.TabIndex = 7;
            this.All_Cb.Text = "All";
            this.All_Cb.UseVisualStyleBackColor = true;
            // 
            // checkBox2
            // 
            this.checkBox2.AutoSize = true;
            this.checkBox2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.checkBox2.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBox2.ForeColor = System.Drawing.Color.Black;
            this.checkBox2.Location = new System.Drawing.Point(59, 8);
            this.checkBox2.Name = "checkBox2";
            this.checkBox2.Size = new System.Drawing.Size(127, 27);
            this.checkBox2.TabIndex = 2;
            this.checkBox2.Tag = "JEB";
            this.checkBox2.Text = "John Bellotti";
            this.checkBox2.UseVisualStyleBackColor = true;
            // 
            // checkBox4
            // 
            this.checkBox4.AutoSize = true;
            this.checkBox4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.checkBox4.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBox4.ForeColor = System.Drawing.Color.Black;
            this.checkBox4.Location = new System.Drawing.Point(8, 41);
            this.checkBox4.Name = "checkBox4";
            this.checkBox4.Size = new System.Drawing.Size(135, 27);
            this.checkBox4.TabIndex = 4;
            this.checkBox4.Tag = "BD";
            this.checkBox4.Text = "Brian Daniels";
            this.checkBox4.UseVisualStyleBackColor = true;
            // 
            // checkBox5
            // 
            this.checkBox5.AutoSize = true;
            this.checkBox5.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.checkBox5.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBox5.ForeColor = System.Drawing.Color.Black;
            this.checkBox5.Location = new System.Drawing.Point(8, 74);
            this.checkBox5.Name = "checkBox5";
            this.checkBox5.Size = new System.Drawing.Size(110, 27);
            this.checkBox5.TabIndex = 5;
            this.checkBox5.Tag = "TH_";
            this.checkBox5.Text = "Ty Harper";
            this.checkBox5.UseVisualStyleBackColor = true;
            // 
            // checkBox3
            // 
            this.checkBox3.AutoSize = true;
            this.checkBox3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.checkBox3.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBox3.ForeColor = System.Drawing.Color.Black;
            this.checkBox3.Location = new System.Drawing.Point(8, 107);
            this.checkBox3.Name = "checkBox3";
            this.checkBox3.Size = new System.Drawing.Size(171, 27);
            this.checkBox3.TabIndex = 3;
            this.checkBox3.Tag = "JJ_";
            this.checkBox3.Text = "Jack E. Jones, III";
            this.checkBox3.UseVisualStyleBackColor = true;
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.checkBox1.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBox1.ForeColor = System.Drawing.Color.Black;
            this.checkBox1.Location = new System.Drawing.Point(8, 140);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(134, 27);
            this.checkBox1.TabIndex = 1;
            this.checkBox1.Tag = "DPM";
            this.checkBox1.Text = "David Mayne";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // checkBox6
            // 
            this.checkBox6.AutoSize = true;
            this.checkBox6.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.checkBox6.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBox6.ForeColor = System.Drawing.Color.Black;
            this.checkBox6.Location = new System.Drawing.Point(8, 173);
            this.checkBox6.Name = "checkBox6";
            this.checkBox6.Size = new System.Drawing.Size(112, 27);
            this.checkBox6.TabIndex = 6;
            this.checkBox6.Tag = "BS";
            this.checkBox6.Text = "Ben Smith";
            this.checkBox6.UseVisualStyleBackColor = true;
            // 
            // checkBox7
            // 
            this.checkBox7.AutoSize = true;
            this.checkBox7.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.checkBox7.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBox7.ForeColor = System.Drawing.Color.Black;
            this.checkBox7.Location = new System.Drawing.Point(8, 206);
            this.checkBox7.Name = "checkBox7";
            this.checkBox7.Size = new System.Drawing.Size(125, 27);
            this.checkBox7.TabIndex = 8;
            this.checkBox7.Tag = "kws";
            this.checkBox7.Text = "Ken Scoville";
            this.checkBox7.UseVisualStyleBackColor = true;
            // 
            // checkBox8
            // 
            this.checkBox8.AutoSize = true;
            this.checkBox8.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.checkBox8.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBox8.ForeColor = System.Drawing.Color.Black;
            this.checkBox8.Location = new System.Drawing.Point(8, 239);
            this.checkBox8.Name = "checkBox8";
            this.checkBox8.Size = new System.Drawing.Size(64, 27);
            this.checkBox8.TabIndex = 9;
            this.checkBox8.Tag = "hab";
            this.checkBox8.Text = "Habi";
            this.checkBox8.UseVisualStyleBackColor = true;
            // 
            // FrmSalesmen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(53)))), ((int)(((byte)(53)))));
            this.ClientSize = new System.Drawing.Size(219, 343);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.Salesman_Pn);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FrmSalesmen";
            this.Text = "Salesmen";
            this.Load += new System.EventHandler(this.FrmFilter_Load);
            this.Salesman_Pn.ResumeLayout(false);
            this.Salesman_Pn.PerformLayout();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flp_Pn.ResumeLayout(false);
            this.flp_Pn.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.FlowLayoutPanel Salesman_Pn;
        private System.Windows.Forms.Button Close_Page_Bt;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.FlowLayoutPanel flp_Pn;
        private System.Windows.Forms.CheckBox All_Cb;
        private System.Windows.Forms.CheckBox checkBox2;
        private System.Windows.Forms.CheckBox checkBox4;
        private System.Windows.Forms.CheckBox checkBox5;
        private System.Windows.Forms.CheckBox checkBox3;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.CheckBox checkBox6;
        private System.Windows.Forms.CheckBox checkBox7;
        private System.Windows.Forms.CheckBox checkBox8;
    }
}