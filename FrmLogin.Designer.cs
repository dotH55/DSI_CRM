namespace DSI_CRM
{
    partial class FrmLogin
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmLogin));
            this.Top_Pn = new System.Windows.Forms.FlowLayoutPanel();
            this.label2 = new System.Windows.Forms.Label();
            this.Error_Lb = new System.Windows.Forms.Label();
            this.flowLayoutPanel2 = new System.Windows.Forms.FlowLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.Save_Credentials = new System.Windows.Forms.CheckBox();
            this.Terminate_Bt = new System.Windows.Forms.Button();
            this.Login_Bt = new System.Windows.Forms.Button();
            this.Password_Tb = new System.Windows.Forms.TextBox();
            this.Username_Tb = new System.Windows.Forms.TextBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.Top_Pn.SuspendLayout();
            this.flowLayoutPanel2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // Top_Pn
            // 
            this.Top_Pn.Controls.Add(this.label2);
            this.Top_Pn.Controls.Add(this.Error_Lb);
            this.Top_Pn.Dock = System.Windows.Forms.DockStyle.Top;
            this.Top_Pn.Location = new System.Drawing.Point(0, 0);
            this.Top_Pn.Name = "Top_Pn";
            this.Top_Pn.Padding = new System.Windows.Forms.Padding(10);
            this.Top_Pn.Size = new System.Drawing.Size(407, 33);
            this.Top_Pn.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(13, 10);
            this.label2.Margin = new System.Windows.Forms.Padding(3, 0, 40, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(85, 19);
            this.label2.TabIndex = 4;
            this.label2.Text = "DSI_CRM";
            // 
            // Error_Lb
            // 
            this.Error_Lb.AutoSize = true;
            this.Error_Lb.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Error_Lb.ForeColor = System.Drawing.Color.Crimson;
            this.Error_Lb.Location = new System.Drawing.Point(141, 10);
            this.Error_Lb.Name = "Error_Lb";
            this.Error_Lb.Size = new System.Drawing.Size(208, 19);
            this.Error_Lb.TabIndex = 5;
            this.Error_Lb.Text = "*Error: Network Connection";
            this.Error_Lb.Visible = false;
            // 
            // flowLayoutPanel2
            // 
            this.flowLayoutPanel2.Controls.Add(this.panel1);
            this.flowLayoutPanel2.Controls.Add(this.panel3);
            this.flowLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel2.Location = new System.Drawing.Point(0, 33);
            this.flowLayoutPanel2.Name = "flowLayoutPanel2";
            this.flowLayoutPanel2.Size = new System.Drawing.Size(407, 145);
            this.flowLayoutPanel2.TabIndex = 1;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.Save_Credentials);
            this.panel1.Controls.Add(this.Terminate_Bt);
            this.panel1.Controls.Add(this.Login_Bt);
            this.panel1.Controls.Add(this.Password_Tb);
            this.panel1.Controls.Add(this.Username_Tb);
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(404, 140);
            this.panel1.TabIndex = 0;
            // 
            // Save_Credentials
            // 
            this.Save_Credentials.AutoSize = true;
            this.Save_Credentials.ForeColor = System.Drawing.Color.White;
            this.Save_Credentials.Location = new System.Drawing.Point(212, 3);
            this.Save_Credentials.Name = "Save_Credentials";
            this.Save_Credentials.Size = new System.Drawing.Size(107, 17);
            this.Save_Credentials.TabIndex = 26;
            this.Save_Credentials.Text = "Save Credentials";
            this.Save_Credentials.UseVisualStyleBackColor = true;
            // 
            // Terminate_Bt
            // 
            this.Terminate_Bt.BackColor = System.Drawing.Color.Black;
            this.Terminate_Bt.FlatAppearance.BorderSize = 0;
            this.Terminate_Bt.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.Terminate_Bt.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Terminate_Bt.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Terminate_Bt.ForeColor = System.Drawing.Color.White;
            this.Terminate_Bt.Image = global::DSI_CRM.Properties.Resources.icons8_Esc_Mac_32px;
            this.Terminate_Bt.Location = new System.Drawing.Point(237, 94);
            this.Terminate_Bt.Name = "Terminate_Bt";
            this.Terminate_Bt.Size = new System.Drawing.Size(82, 29);
            this.Terminate_Bt.TabIndex = 24;
            this.Terminate_Bt.UseVisualStyleBackColor = false;
            this.Terminate_Bt.Click += new System.EventHandler(this.Terminate_Bt_Click);
            // 
            // Login_Bt
            // 
            this.Login_Bt.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(219)))), ((int)(((byte)(6)))), ((int)(((byte)(44)))));
            this.Login_Bt.FlatAppearance.BorderSize = 0;
            this.Login_Bt.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.Login_Bt.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Login_Bt.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Login_Bt.ForeColor = System.Drawing.Color.White;
            this.Login_Bt.Image = global::DSI_CRM.Properties.Resources.icons8_Enter_32px;
            this.Login_Bt.Location = new System.Drawing.Point(83, 94);
            this.Login_Bt.Name = "Login_Bt";
            this.Login_Bt.Size = new System.Drawing.Size(148, 29);
            this.Login_Bt.TabIndex = 23;
            this.Login_Bt.UseVisualStyleBackColor = false;
            this.Login_Bt.Click += new System.EventHandler(this.Login_Bt_Click);
            // 
            // Password_Tb
            // 
            this.Password_Tb.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.Password_Tb.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Password_Tb.Location = new System.Drawing.Point(83, 60);
            this.Password_Tb.Name = "Password_Tb";
            this.Password_Tb.PasswordChar = '*';
            this.Password_Tb.Size = new System.Drawing.Size(236, 28);
            this.Password_Tb.TabIndex = 22;
            // 
            // Username_Tb
            // 
            this.Username_Tb.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.Username_Tb.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Username_Tb.Location = new System.Drawing.Point(83, 26);
            this.Username_Tb.Name = "Username_Tb";
            this.Username_Tb.Size = new System.Drawing.Size(236, 28);
            this.Username_Tb.TabIndex = 21;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.pictureBox1);
            this.panel3.Location = new System.Drawing.Point(3, 149);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(404, 140);
            this.panel3.TabIndex = 2;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::DSI_CRM.Properties.Resources.Infinity_1s_200px;
            this.pictureBox1.Location = new System.Drawing.Point(100, -35);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(246, 160);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // backgroundWorker1
            // 
            this.backgroundWorker1.WorkerReportsProgress = true;
            this.backgroundWorker1.WorkerSupportsCancellation = true;
            this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
            //this.backgroundWorker1.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.backgroundWorker1_ProgressChanged);
            this.backgroundWorker1.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker1_RunWorkerCompleted);
            // 
            // FrmLogin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(35)))), ((int)(((byte)(35)))));
            this.ClientSize = new System.Drawing.Size(407, 178);
            this.Controls.Add(this.flowLayoutPanel2);
            this.Controls.Add(this.Top_Pn);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FrmLogin";
            this.Text = "Login";
            this.Top_Pn.ResumeLayout(false);
            this.Top_Pn.PerformLayout();
            this.flowLayoutPanel2.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel Top_Pn;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button Terminate_Bt;
        private System.Windows.Forms.Button Login_Bt;
        private System.Windows.Forms.TextBox Password_Tb;
        private System.Windows.Forms.TextBox Username_Tb;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox Save_Credentials;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.Label Error_Lb;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}