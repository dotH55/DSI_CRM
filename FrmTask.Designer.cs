namespace DSI_CRM
{
    partial class FrmTask
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmTask));
            this.Top_Pn = new System.Windows.Forms.Panel();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.Close_Bt = new System.Windows.Forms.Button();
            this.flowLayoutPanel2 = new System.Windows.Forms.FlowLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.Task_Tb = new System.Windows.Forms.TextBox();
            this.Title_Tb = new System.Windows.Forms.TextBox();
            this.Date_Dt = new System.Windows.Forms.DateTimePicker();
            this.Save_Bt = new System.Windows.Forms.Button();
            this.flowLayoutPanel3 = new System.Windows.Forms.FlowLayoutPanel();
            this.Delete_Bt = new System.Windows.Forms.Button();
            this.Top_Pn.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.flowLayoutPanel2.SuspendLayout();
            this.flowLayoutPanel3.SuspendLayout();
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
            this.Top_Pn.Size = new System.Drawing.Size(515, 30);
            this.Top_Pn.TabIndex = 1;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.Close_Bt);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Right;
            this.flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(447, 0);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.flowLayoutPanel1.Size = new System.Drawing.Size(68, 30);
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
            this.Close_Bt.Location = new System.Drawing.Point(28, 3);
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
            this.flowLayoutPanel2.Size = new System.Drawing.Size(76, 30);
            this.flowLayoutPanel2.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(8, 5);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(46, 19);
            this.label1.TabIndex = 1;
            this.label1.Text = "CRM";
            // 
            // Task_Tb
            // 
            this.Task_Tb.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Task_Tb.Location = new System.Drawing.Point(51, 106);
            this.Task_Tb.Multiline = true;
            this.Task_Tb.Name = "Task_Tb";
            this.Task_Tb.Size = new System.Drawing.Size(419, 80);
            this.Task_Tb.TabIndex = 13;
            // 
            // Title_Tb
            // 
            this.Title_Tb.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Title_Tb.Location = new System.Drawing.Point(51, 71);
            this.Title_Tb.Name = "Title_Tb";
            this.Title_Tb.Size = new System.Drawing.Size(419, 29);
            this.Title_Tb.TabIndex = 12;
            // 
            // Date_Dt
            // 
            this.Date_Dt.AccessibleName = "";
            this.Date_Dt.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Date_Dt.Location = new System.Drawing.Point(51, 36);
            this.Date_Dt.Name = "Date_Dt";
            this.Date_Dt.Size = new System.Drawing.Size(419, 29);
            this.Date_Dt.TabIndex = 11;
            // 
            // Save_Bt
            // 
            this.Save_Bt.BackColor = System.Drawing.Color.Black;
            this.Save_Bt.FlatAppearance.BorderSize = 0;
            this.Save_Bt.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.Save_Bt.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Black;
            this.Save_Bt.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Save_Bt.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Save_Bt.ForeColor = System.Drawing.Color.White;
            this.Save_Bt.Image = global::DSI_CRM.Properties.Resources.icons8_Add_New_24px_1;
            this.Save_Bt.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.Save_Bt.Location = new System.Drawing.Point(163, 3);
            this.Save_Bt.Name = "Save_Bt";
            this.Save_Bt.Size = new System.Drawing.Size(105, 29);
            this.Save_Bt.TabIndex = 42;
            this.Save_Bt.Text = "Update";
            this.Save_Bt.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.Save_Bt.UseVisualStyleBackColor = false;
            this.Save_Bt.Click += new System.EventHandler(this.Save_Bt_Click);
            // 
            // flowLayoutPanel3
            // 
            this.flowLayoutPanel3.Controls.Add(this.Save_Bt);
            this.flowLayoutPanel3.Controls.Add(this.Delete_Bt);
            this.flowLayoutPanel3.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.flowLayoutPanel3.Location = new System.Drawing.Point(199, 192);
            this.flowLayoutPanel3.Name = "flowLayoutPanel3";
            this.flowLayoutPanel3.Size = new System.Drawing.Size(271, 35);
            this.flowLayoutPanel3.TabIndex = 43;
            // 
            // Delete_Bt
            // 
            this.Delete_Bt.BackColor = System.Drawing.Color.Black;
            this.Delete_Bt.FlatAppearance.BorderSize = 0;
            this.Delete_Bt.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Crimson;
            this.Delete_Bt.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Black;
            this.Delete_Bt.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Delete_Bt.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Delete_Bt.ForeColor = System.Drawing.Color.White;
            this.Delete_Bt.Image = global::DSI_CRM.Properties.Resources.icons8_checked_checkbox_24px_2;
            this.Delete_Bt.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.Delete_Bt.Location = new System.Drawing.Point(42, 3);
            this.Delete_Bt.Name = "Delete_Bt";
            this.Delete_Bt.Size = new System.Drawing.Size(115, 29);
            this.Delete_Bt.TabIndex = 43;
            this.Delete_Bt.Text = "Complete";
            this.Delete_Bt.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.Delete_Bt.UseVisualStyleBackColor = false;
            this.Delete_Bt.Click += new System.EventHandler(this.Delete_Bt_Click_1);
            // 
            // FrmTask
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(515, 231);
            this.Controls.Add(this.flowLayoutPanel3);
            this.Controls.Add(this.Task_Tb);
            this.Controls.Add(this.Title_Tb);
            this.Controls.Add(this.Date_Dt);
            this.Controls.Add(this.Top_Pn);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FrmTask";
            this.Text = "Task";
            this.Top_Pn.ResumeLayout(false);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel2.ResumeLayout(false);
            this.flowLayoutPanel2.PerformLayout();
            this.flowLayoutPanel3.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel Top_Pn;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Button Close_Bt;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox Task_Tb;
        private System.Windows.Forms.TextBox Title_Tb;
        private System.Windows.Forms.DateTimePicker Date_Dt;
        private System.Windows.Forms.Button Save_Bt;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel3;
        private System.Windows.Forms.Button Delete_Bt;
    }
}