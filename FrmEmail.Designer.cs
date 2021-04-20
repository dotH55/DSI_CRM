
namespace DSI_CRM
{
    partial class FrmEmail
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
            this.Top_Pn = new System.Windows.Forms.Panel();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.Close_Bt = new System.Windows.Forms.Button();
            this.flowLayoutPanel2 = new System.Windows.Forms.FlowLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.First_Name_Lb = new System.Windows.Forms.Label();
            this.Email_Tb = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.Password_Tb = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.Attach_Count_Lb = new System.Windows.Forms.Label();
            this.Attachment_Flp = new System.Windows.Forms.FlowLayoutPanel();
            this.Attach_Bt = new System.Windows.Forms.Button();
            this.Send_Bt = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.Body_Tb = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.Subject_Tb = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.Recipient_Tb = new System.Windows.Forms.TextBox();
            this.Top_Pn.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.flowLayoutPanel2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
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
            this.Top_Pn.Size = new System.Drawing.Size(941, 30);
            this.Top_Pn.TabIndex = 2;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.Close_Bt);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Right;
            this.flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(861, 0);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.flowLayoutPanel1.Size = new System.Drawing.Size(80, 30);
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
            this.Close_Bt.Location = new System.Drawing.Point(40, 3);
            this.Close_Bt.Name = "Close_Bt";
            this.Close_Bt.Size = new System.Drawing.Size(32, 24);
            this.Close_Bt.TabIndex = 1;
            this.Close_Bt.UseVisualStyleBackColor = false;
            this.Close_Bt.Click += new System.EventHandler(this.Close_Bt_Click);
            // 
            // flowLayoutPanel2
            // 
            this.flowLayoutPanel2.Controls.Add(this.label1);
            this.flowLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Left;
            this.flowLayoutPanel2.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanel2.Name = "flowLayoutPanel2";
            this.flowLayoutPanel2.Padding = new System.Windows.Forms.Padding(5);
            this.flowLayoutPanel2.Size = new System.Drawing.Size(108, 30);
            this.flowLayoutPanel2.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(8, 5);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(83, 19);
            this.label1.TabIndex = 1;
            this.label1.Text = "Compose";
            // 
            // First_Name_Lb
            // 
            this.First_Name_Lb.AutoSize = true;
            this.First_Name_Lb.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.First_Name_Lb.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.First_Name_Lb.Location = new System.Drawing.Point(6, 17);
            this.First_Name_Lb.Name = "First_Name_Lb";
            this.First_Name_Lb.Size = new System.Drawing.Size(53, 23);
            this.First_Name_Lb.TabIndex = 57;
            this.First_Name_Lb.Text = "From";
            this.First_Name_Lb.Click += new System.EventHandler(this.First_Name_Lb_Click);
            // 
            // Email_Tb
            // 
            this.Email_Tb.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.Email_Tb.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Email_Tb.Location = new System.Drawing.Point(102, 17);
            this.Email_Tb.Name = "Email_Tb";
            this.Email_Tb.Size = new System.Drawing.Size(622, 23);
            this.Email_Tb.TabIndex = 56;
            this.Email_Tb.Tag = "Email";
            this.Email_Tb.Text = "Email";
            this.Email_Tb.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.Email_Tb.TextChanged += new System.EventHandler(this.First_Name_Tb_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label2.Location = new System.Drawing.Point(6, 46);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(88, 23);
            this.label2.TabIndex = 59;
            this.label2.Text = "Password";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // Password_Tb
            // 
            this.Password_Tb.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.Password_Tb.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Password_Tb.Location = new System.Drawing.Point(102, 46);
            this.Password_Tb.Name = "Password_Tb";
            this.Password_Tb.PasswordChar = '*';
            this.Password_Tb.Size = new System.Drawing.Size(622, 23);
            this.Password_Tb.TabIndex = 58;
            this.Password_Tb.Tag = "";
            this.Password_Tb.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.Password_Tb.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.Email_Tb);
            this.groupBox1.Controls.Add(this.First_Name_Lb);
            this.groupBox1.Controls.Add(this.Password_Tb);
            this.groupBox1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.groupBox1.Location = new System.Drawing.Point(105, 36);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(736, 75);
            this.groupBox1.TabIndex = 69;
            this.groupBox1.TabStop = false;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.Attach_Count_Lb);
            this.groupBox2.Controls.Add(this.Attachment_Flp);
            this.groupBox2.Controls.Add(this.Attach_Bt);
            this.groupBox2.Controls.Add(this.Send_Bt);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.Body_Tb);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.Subject_Tb);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.Recipient_Tb);
            this.groupBox2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.groupBox2.Location = new System.Drawing.Point(105, 111);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(736, 356);
            this.groupBox2.TabIndex = 70;
            this.groupBox2.TabStop = false;
            // 
            // Attach_Count_Lb
            // 
            this.Attach_Count_Lb.AutoSize = true;
            this.Attach_Count_Lb.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Attach_Count_Lb.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.Attach_Count_Lb.Location = new System.Drawing.Point(704, 271);
            this.Attach_Count_Lb.Name = "Attach_Count_Lb";
            this.Attach_Count_Lb.Size = new System.Drawing.Size(20, 23);
            this.Attach_Count_Lb.TabIndex = 60;
            this.Attach_Count_Lb.Text = "0";
            this.Attach_Count_Lb.Click += new System.EventHandler(this.label6_Click);
            // 
            // Attachment_Flp
            // 
            this.Attachment_Flp.AutoScroll = true;
            this.Attachment_Flp.Location = new System.Drawing.Point(303, 269);
            this.Attachment_Flp.Margin = new System.Windows.Forms.Padding(5);
            this.Attachment_Flp.Name = "Attachment_Flp";
            this.Attachment_Flp.Padding = new System.Windows.Forms.Padding(5);
            this.Attachment_Flp.Size = new System.Drawing.Size(376, 79);
            this.Attachment_Flp.TabIndex = 77;
            // 
            // Attach_Bt
            // 
            this.Attach_Bt.BackColor = System.Drawing.Color.White;
            this.Attach_Bt.FlatAppearance.BorderSize = 0;
            this.Attach_Bt.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Black;
            this.Attach_Bt.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Attach_Bt.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Attach_Bt.Image = global::DSI_CRM.Properties.Resources.icons8_Attach_24px;
            this.Attach_Bt.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.Attach_Bt.Location = new System.Drawing.Point(204, 269);
            this.Attach_Bt.Name = "Attach_Bt";
            this.Attach_Bt.Size = new System.Drawing.Size(96, 29);
            this.Attach_Bt.TabIndex = 76;
            this.Attach_Bt.Text = "Attach";
            this.Attach_Bt.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.Attach_Bt.UseVisualStyleBackColor = false;
            this.Attach_Bt.Click += new System.EventHandler(this.Attach_Bt_Click);
            // 
            // Send_Bt
            // 
            this.Send_Bt.BackColor = System.Drawing.Color.White;
            this.Send_Bt.FlatAppearance.BorderSize = 0;
            this.Send_Bt.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Black;
            this.Send_Bt.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Send_Bt.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Send_Bt.Image = global::DSI_CRM.Properties.Resources.icons8_Send_24px;
            this.Send_Bt.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.Send_Bt.Location = new System.Drawing.Point(102, 269);
            this.Send_Bt.Name = "Send_Bt";
            this.Send_Bt.Size = new System.Drawing.Size(96, 29);
            this.Send_Bt.TabIndex = 75;
            this.Send_Bt.Text = "Send";
            this.Send_Bt.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.Send_Bt.UseVisualStyleBackColor = false;
            this.Send_Bt.Click += new System.EventHandler(this.Send_Bt_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label5.Location = new System.Drawing.Point(6, 75);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(51, 23);
            this.label5.TabIndex = 74;
            this.label5.Text = "Body";
            // 
            // Body_Tb
            // 
            this.Body_Tb.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.Body_Tb.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Body_Tb.Location = new System.Drawing.Point(102, 75);
            this.Body_Tb.Multiline = true;
            this.Body_Tb.Name = "Body_Tb";
            this.Body_Tb.Size = new System.Drawing.Size(622, 188);
            this.Body_Tb.TabIndex = 73;
            this.Body_Tb.Tag = "";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label4.Location = new System.Drawing.Point(6, 46);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(73, 23);
            this.label4.TabIndex = 72;
            this.label4.Text = "Subject";
            // 
            // Subject_Tb
            // 
            this.Subject_Tb.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.Subject_Tb.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Subject_Tb.Location = new System.Drawing.Point(102, 46);
            this.Subject_Tb.Name = "Subject_Tb";
            this.Subject_Tb.Size = new System.Drawing.Size(622, 23);
            this.Subject_Tb.TabIndex = 71;
            this.Subject_Tb.Tag = "Subject";
            this.Subject_Tb.Text = "Subject";
            this.Subject_Tb.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label3.Location = new System.Drawing.Point(6, 17);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(31, 23);
            this.label3.TabIndex = 70;
            this.label3.Text = "To";
            // 
            // Recipient_Tb
            // 
            this.Recipient_Tb.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.Recipient_Tb.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Recipient_Tb.Location = new System.Drawing.Point(102, 17);
            this.Recipient_Tb.Name = "Recipient_Tb";
            this.Recipient_Tb.Size = new System.Drawing.Size(622, 23);
            this.Recipient_Tb.TabIndex = 69;
            this.Recipient_Tb.Tag = "Recipient";
            this.Recipient_Tb.Text = "Recipient";
            this.Recipient_Tb.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // FrmEmail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(941, 483);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.Top_Pn);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "FrmEmail";
            this.Text = "FrmEmail";
            this.Top_Pn.ResumeLayout(false);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel2.ResumeLayout(false);
            this.flowLayoutPanel2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel Top_Pn;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Button Close_Bt;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label First_Name_Lb;
        private System.Windows.Forms.TextBox Email_Tb;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox Password_Tb;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.FlowLayoutPanel Attachment_Flp;
        private System.Windows.Forms.Button Attach_Bt;
        private System.Windows.Forms.Button Send_Bt;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox Body_Tb;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox Subject_Tb;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox Recipient_Tb;
        private System.Windows.Forms.Label Attach_Count_Lb;
    }
}