namespace DSI_CRM
{
    partial class FrmAlert
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmAlert));
            this.Top_Pn = new System.Windows.Forms.FlowLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.flowLayoutPanel2 = new System.Windows.Forms.FlowLayoutPanel();
            this.Message_Lb = new System.Windows.Forms.Label();
            this.flowLayoutPanel3 = new System.Windows.Forms.FlowLayoutPanel();
            this.Cancel_Bt = new System.Windows.Forms.Button();
            this.Ok_Bt = new System.Windows.Forms.Button();
            this.Top_Pn.SuspendLayout();
            this.flowLayoutPanel2.SuspendLayout();
            this.flowLayoutPanel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // Top_Pn
            // 
            this.Top_Pn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(35)))), ((int)(((byte)(35)))));
            this.Top_Pn.Controls.Add(this.label1);
            this.Top_Pn.Dock = System.Windows.Forms.DockStyle.Top;
            this.Top_Pn.Location = new System.Drawing.Point(0, 0);
            this.Top_Pn.Name = "Top_Pn";
            this.Top_Pn.Padding = new System.Windows.Forms.Padding(5);
            this.Top_Pn.Size = new System.Drawing.Size(322, 30);
            this.Top_Pn.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(8, 5);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(85, 19);
            this.label1.TabIndex = 0;
            this.label1.Text = "DSI_CRM";
            this.label1.Visible = false;
            // 
            // flowLayoutPanel2
            // 
            this.flowLayoutPanel2.AutoScroll = true;
            this.flowLayoutPanel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(35)))), ((int)(((byte)(35)))));
            this.flowLayoutPanel2.Controls.Add(this.Message_Lb);
            this.flowLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.flowLayoutPanel2.Location = new System.Drawing.Point(0, 30);
            this.flowLayoutPanel2.Name = "flowLayoutPanel2";
            this.flowLayoutPanel2.Padding = new System.Windows.Forms.Padding(5, 10, 5, 5);
            this.flowLayoutPanel2.Size = new System.Drawing.Size(322, 56);
            this.flowLayoutPanel2.TabIndex = 1;
            // 
            // Message_Lb
            // 
            this.Message_Lb.AutoSize = true;
            this.Message_Lb.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Message_Lb.ForeColor = System.Drawing.Color.White;
            this.Message_Lb.Location = new System.Drawing.Point(8, 10);
            this.Message_Lb.Name = "Message_Lb";
            this.Message_Lb.Size = new System.Drawing.Size(73, 18);
            this.Message_Lb.TabIndex = 0;
            this.Message_Lb.Text = "Message";
            // 
            // flowLayoutPanel3
            // 
            this.flowLayoutPanel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(35)))), ((int)(((byte)(35)))));
            this.flowLayoutPanel3.Controls.Add(this.Cancel_Bt);
            this.flowLayoutPanel3.Controls.Add(this.Ok_Bt);
            this.flowLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.flowLayoutPanel3.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.flowLayoutPanel3.Location = new System.Drawing.Point(0, 86);
            this.flowLayoutPanel3.Name = "flowLayoutPanel3";
            this.flowLayoutPanel3.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.flowLayoutPanel3.Size = new System.Drawing.Size(322, 41);
            this.flowLayoutPanel3.TabIndex = 2;
            // 
            // Cancel_Bt
            // 
            this.Cancel_Bt.BackColor = System.Drawing.Color.Transparent;
            this.Cancel_Bt.FlatAppearance.BorderSize = 0;
            this.Cancel_Bt.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Crimson;
            this.Cancel_Bt.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.Cancel_Bt.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Cancel_Bt.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Cancel_Bt.ForeColor = System.Drawing.Color.Black;
            this.Cancel_Bt.Image = global::DSI_CRM.Properties.Resources.icons8_dfgsdfgsrfgsdfgbCancel_24px_2;
            this.Cancel_Bt.Location = new System.Drawing.Point(266, 3);
            this.Cancel_Bt.Name = "Cancel_Bt";
            this.Cancel_Bt.Size = new System.Drawing.Size(48, 29);
            this.Cancel_Bt.TabIndex = 12;
            this.Cancel_Bt.UseVisualStyleBackColor = false;
            this.Cancel_Bt.Visible = false;
            this.Cancel_Bt.Click += new System.EventHandler(this.Cancel_Bt_Click);
            // 
            // Ok_Bt
            // 
            this.Ok_Bt.BackColor = System.Drawing.Color.Transparent;
            this.Ok_Bt.FlatAppearance.BorderSize = 0;
            this.Ok_Bt.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.Ok_Bt.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.Ok_Bt.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Ok_Bt.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Ok_Bt.ForeColor = System.Drawing.Color.Black;
            this.Ok_Bt.Image = global::DSI_CRM.Properties.Resources.icons8_approval_24px;
            this.Ok_Bt.Location = new System.Drawing.Point(212, 3);
            this.Ok_Bt.Name = "Ok_Bt";
            this.Ok_Bt.Size = new System.Drawing.Size(48, 29);
            this.Ok_Bt.TabIndex = 11;
            this.Ok_Bt.UseVisualStyleBackColor = false;
            this.Ok_Bt.Click += new System.EventHandler(this.Ok_Bt_Click);
            // 
            // FrmAlert
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(322, 123);
            this.Controls.Add(this.flowLayoutPanel3);
            this.Controls.Add(this.flowLayoutPanel2);
            this.Controls.Add(this.Top_Pn);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FrmAlert";
            this.Text = "Alert";
            this.Top_Pn.ResumeLayout(false);
            this.Top_Pn.PerformLayout();
            this.flowLayoutPanel2.ResumeLayout(false);
            this.flowLayoutPanel2.PerformLayout();
            this.flowLayoutPanel3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel Top_Pn;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel2;
        private System.Windows.Forms.Label Message_Lb;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel3;
        private System.Windows.Forms.Button Ok_Bt;
        private System.Windows.Forms.Button Cancel_Bt;
    }
}