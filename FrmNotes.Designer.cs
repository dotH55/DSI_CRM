namespace DSI_CRM
{
    partial class FrmNotes
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmNotes));
            this.Top_Pn = new System.Windows.Forms.Panel();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.Close_Bt = new System.Windows.Forms.Button();
            this.flowLayoutPanel2 = new System.Windows.Forms.FlowLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.FlpNotes_Pn = new System.Windows.Forms.FlowLayoutPanel();
            this.Bottom_Pn = new System.Windows.Forms.Panel();
            this.Input_Tb = new System.Windows.Forms.TextBox();
            this.Banner_Pn = new System.Windows.Forms.FlowLayoutPanel();
            this.Org_Name_Lb = new System.Windows.Forms.Label();
            this.Contact_Cb = new System.Windows.Forms.ComboBox();
            this.Save_Bt = new System.Windows.Forms.Button();
            this.Top_Pn.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.flowLayoutPanel2.SuspendLayout();
            this.Bottom_Pn.SuspendLayout();
            this.Banner_Pn.SuspendLayout();
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
            this.Top_Pn.Size = new System.Drawing.Size(474, 30);
            this.Top_Pn.TabIndex = 1;
            this.Top_Pn.Paint += new System.Windows.Forms.PaintEventHandler(this.Top_Pn_Paint);
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.Close_Bt);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Right;
            this.flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(381, 0);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.flowLayoutPanel1.Size = new System.Drawing.Size(93, 30);
            this.flowLayoutPanel1.TabIndex = 1;
            // 
            // Close_Bt
            // 
            this.Close_Bt.BackColor = System.Drawing.Color.Transparent;
            this.Close_Bt.FlatAppearance.BorderSize = 0;
            this.Close_Bt.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.Close_Bt.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Close_Bt.Image = global::DSI_CRM.Properties.Resources.icons8_Multiply_24px_1;
            this.Close_Bt.Location = new System.Drawing.Point(21, 3);
            this.Close_Bt.Name = "Close_Bt";
            this.Close_Bt.Size = new System.Drawing.Size(64, 24);
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
            this.label1.Size = new System.Drawing.Size(56, 19);
            this.label1.TabIndex = 1;
            this.label1.Text = "Notes";
            // 
            // FlpNotes_Pn
            // 
            this.FlpNotes_Pn.AutoScroll = true;
            this.FlpNotes_Pn.BackColor = System.Drawing.Color.White;
            this.FlpNotes_Pn.Location = new System.Drawing.Point(0, 106);
            this.FlpNotes_Pn.Name = "FlpNotes_Pn";
            this.FlpNotes_Pn.Size = new System.Drawing.Size(474, 398);
            this.FlpNotes_Pn.TabIndex = 2;
            // 
            // Bottom_Pn
            // 
            this.Bottom_Pn.Controls.Add(this.Input_Tb);
            this.Bottom_Pn.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.Bottom_Pn.Location = new System.Drawing.Point(0, 560);
            this.Bottom_Pn.Name = "Bottom_Pn";
            this.Bottom_Pn.Size = new System.Drawing.Size(474, 139);
            this.Bottom_Pn.TabIndex = 3;
            // 
            // Input_Tb
            // 
            this.Input_Tb.BackColor = System.Drawing.Color.White;
            this.Input_Tb.Dock = System.Windows.Forms.DockStyle.Top;
            this.Input_Tb.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Input_Tb.Location = new System.Drawing.Point(0, 0);
            this.Input_Tb.Multiline = true;
            this.Input_Tb.Name = "Input_Tb";
            this.Input_Tb.Size = new System.Drawing.Size(474, 111);
            this.Input_Tb.TabIndex = 0;
            // 
            // Banner_Pn
            // 
            this.Banner_Pn.BackColor = System.Drawing.Color.Black;
            this.Banner_Pn.Controls.Add(this.Org_Name_Lb);
            this.Banner_Pn.Controls.Add(this.Contact_Cb);
            this.Banner_Pn.Dock = System.Windows.Forms.DockStyle.Top;
            this.Banner_Pn.Location = new System.Drawing.Point(0, 30);
            this.Banner_Pn.Name = "Banner_Pn";
            this.Banner_Pn.Padding = new System.Windows.Forms.Padding(5);
            this.Banner_Pn.Size = new System.Drawing.Size(474, 70);
            this.Banner_Pn.TabIndex = 4;
            // 
            // Org_Name_Lb
            // 
            this.Org_Name_Lb.AutoSize = true;
            this.Org_Name_Lb.Font = new System.Drawing.Font("Tahoma", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Org_Name_Lb.ForeColor = System.Drawing.Color.White;
            this.Org_Name_Lb.Location = new System.Drawing.Point(8, 5);
            this.Org_Name_Lb.Margin = new System.Windows.Forms.Padding(3, 0, 20, 0);
            this.Org_Name_Lb.Name = "Org_Name_Lb";
            this.Org_Name_Lb.Size = new System.Drawing.Size(176, 29);
            this.Org_Name_Lb.TabIndex = 0;
            this.Org_Name_Lb.Text = "Thurville, LLC";
            // 
            // Contact_Cb
            // 
            this.Contact_Cb.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Contact_Cb.ForeColor = System.Drawing.Color.DimGray;
            this.Contact_Cb.FormattingEnabled = true;
            this.Contact_Cb.Location = new System.Drawing.Point(207, 8);
            this.Contact_Cb.Name = "Contact_Cb";
            this.Contact_Cb.Size = new System.Drawing.Size(171, 27);
            this.Contact_Cb.TabIndex = 1;
            // 
            // Save_Bt
            // 
            this.Save_Bt.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.Save_Bt.FlatAppearance.BorderSize = 0;
            this.Save_Bt.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.Save_Bt.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Black;
            this.Save_Bt.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Save_Bt.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Save_Bt.ForeColor = System.Drawing.Color.White;
            this.Save_Bt.Image = global::DSI_CRM.Properties.Resources.icons8_up_squared_32px;
            this.Save_Bt.Location = new System.Drawing.Point(0, 510);
            this.Save_Bt.Name = "Save_Bt";
            this.Save_Bt.Size = new System.Drawing.Size(474, 44);
            this.Save_Bt.TabIndex = 14;
            this.Save_Bt.UseVisualStyleBackColor = false;
            this.Save_Bt.Click += new System.EventHandler(this.Save_Bt_Click);
            // 
            // FrmNotes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(474, 699);
            this.Controls.Add(this.Save_Bt);
            this.Controls.Add(this.Banner_Pn);
            this.Controls.Add(this.Bottom_Pn);
            this.Controls.Add(this.FlpNotes_Pn);
            this.Controls.Add(this.Top_Pn);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FrmNotes";
            this.Text = "Notes";
            this.Top_Pn.ResumeLayout(false);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel2.ResumeLayout(false);
            this.flowLayoutPanel2.PerformLayout();
            this.Bottom_Pn.ResumeLayout(false);
            this.Bottom_Pn.PerformLayout();
            this.Banner_Pn.ResumeLayout(false);
            this.Banner_Pn.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel Top_Pn;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Button Close_Bt;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.FlowLayoutPanel FlpNotes_Pn;
        private System.Windows.Forms.Panel Bottom_Pn;
        private System.Windows.Forms.TextBox Input_Tb;
        private System.Windows.Forms.Button Save_Bt;
        private System.Windows.Forms.FlowLayoutPanel Banner_Pn;
        private System.Windows.Forms.Label Org_Name_Lb;
        private System.Windows.Forms.ComboBox Contact_Cb;
    }
}