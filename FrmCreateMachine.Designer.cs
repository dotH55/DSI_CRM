
namespace DSI_CRM
{
    partial class FrmCreateMachine
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
            this.flowLayoutPanel3 = new System.Windows.Forms.FlowLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.Continue_Bt = new System.Windows.Forms.Button();
            this.Create_Bt = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.Description_Tb = new System.Windows.Forms.TextBox();
            this.Item_Number_Tb = new System.Windows.Forms.TextBox();
            this.label18 = new System.Windows.Forms.Label();
            this.Indicator_Pn = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.Machine_Dg = new System.Windows.Forms.DataGridView();
            this.Machine_Number = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Description = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Top_Pn.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.flowLayoutPanel2.SuspendLayout();
            this.flowLayoutPanel3.SuspendLayout();
            this.panel1.SuspendLayout();
            this.Indicator_Pn.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Machine_Dg)).BeginInit();
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
            this.Top_Pn.Size = new System.Drawing.Size(698, 30);
            this.Top_Pn.TabIndex = 2;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.Close_Bt);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Right;
            this.flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(439, 0);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.flowLayoutPanel1.Size = new System.Drawing.Size(259, 30);
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
            this.Close_Bt.Location = new System.Drawing.Point(219, 3);
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
            this.flowLayoutPanel2.Size = new System.Drawing.Size(190, 30);
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
            this.label1.Text = "Home";
            // 
            // flowLayoutPanel3
            // 
            this.flowLayoutPanel3.Controls.Add(this.panel1);
            this.flowLayoutPanel3.Controls.Add(this.Indicator_Pn);
            this.flowLayoutPanel3.Controls.Add(this.Machine_Dg);
            this.flowLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel3.Location = new System.Drawing.Point(0, 30);
            this.flowLayoutPanel3.Name = "flowLayoutPanel3";
            this.flowLayoutPanel3.Padding = new System.Windows.Forms.Padding(5);
            this.flowLayoutPanel3.Size = new System.Drawing.Size(698, 349);
            this.flowLayoutPanel3.TabIndex = 3;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.Continue_Bt);
            this.panel1.Controls.Add(this.Create_Bt);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.Description_Tb);
            this.panel1.Controls.Add(this.Item_Number_Tb);
            this.panel1.Controls.Add(this.label18);
            this.panel1.Location = new System.Drawing.Point(8, 8);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(682, 96);
            this.panel1.TabIndex = 0;
            // 
            // Continue_Bt
            // 
            this.Continue_Bt.BackColor = System.Drawing.Color.Transparent;
            this.Continue_Bt.FlatAppearance.BorderSize = 0;
            this.Continue_Bt.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Black;
            this.Continue_Bt.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.Continue_Bt.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Continue_Bt.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Continue_Bt.ForeColor = System.Drawing.Color.Black;
            this.Continue_Bt.Image = global::DSI_CRM.Properties.Resources.icons8_forward_button_24px1;
            this.Continue_Bt.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.Continue_Bt.Location = new System.Drawing.Point(554, 55);
            this.Continue_Bt.Name = "Continue_Bt";
            this.Continue_Bt.Size = new System.Drawing.Size(116, 26);
            this.Continue_Bt.TabIndex = 114;
            this.Continue_Bt.Text = "Continue";
            this.Continue_Bt.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.Continue_Bt.UseVisualStyleBackColor = false;
            this.Continue_Bt.Click += new System.EventHandler(this.Continue_Bt_Click);
            // 
            // Create_Bt
            // 
            this.Create_Bt.BackColor = System.Drawing.Color.Transparent;
            this.Create_Bt.FlatAppearance.BorderSize = 0;
            this.Create_Bt.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Black;
            this.Create_Bt.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.Create_Bt.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Create_Bt.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Create_Bt.ForeColor = System.Drawing.Color.Black;
            this.Create_Bt.Image = global::DSI_CRM.Properties.Resources.icons8_add_24px;
            this.Create_Bt.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.Create_Bt.Location = new System.Drawing.Point(554, 24);
            this.Create_Bt.Name = "Create_Bt";
            this.Create_Bt.Size = new System.Drawing.Size(105, 26);
            this.Create_Bt.TabIndex = 113;
            this.Create_Bt.Text = "Create";
            this.Create_Bt.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.Create_Bt.UseVisualStyleBackColor = false;
            this.Create_Bt.Click += new System.EventHandler(this.Create_Bt_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label2.Location = new System.Drawing.Point(60, 55);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(103, 23);
            this.label2.TabIndex = 110;
            this.label2.Text = "Description";
            // 
            // Description_Tb
            // 
            this.Description_Tb.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.Description_Tb.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Description_Tb.Location = new System.Drawing.Point(169, 55);
            this.Description_Tb.Name = "Description_Tb";
            this.Description_Tb.Size = new System.Drawing.Size(379, 26);
            this.Description_Tb.TabIndex = 109;
            this.Description_Tb.Tag = "";
            this.Description_Tb.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // Item_Number_Tb
            // 
            this.Item_Number_Tb.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.Item_Number_Tb.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Item_Number_Tb.Location = new System.Drawing.Point(169, 23);
            this.Item_Number_Tb.Name = "Item_Number_Tb";
            this.Item_Number_Tb.Size = new System.Drawing.Size(379, 26);
            this.Item_Number_Tb.TabIndex = 107;
            this.Item_Number_Tb.Tag = "";
            this.Item_Number_Tb.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label18.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label18.Location = new System.Drawing.Point(40, 24);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(123, 23);
            this.label18.TabIndex = 108;
            this.label18.Text = "Item Number";
            // 
            // Indicator_Pn
            // 
            this.Indicator_Pn.Controls.Add(this.label3);
            this.Indicator_Pn.Location = new System.Drawing.Point(8, 110);
            this.Indicator_Pn.Name = "Indicator_Pn";
            this.Indicator_Pn.Size = new System.Drawing.Size(682, 31);
            this.Indicator_Pn.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label3.Location = new System.Drawing.Point(257, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(169, 23);
            this.label3.TabIndex = 115;
            this.label3.Text = "Double click to edit";
            // 
            // Machine_Dg
            // 
            this.Machine_Dg.AllowUserToAddRows = false;
            this.Machine_Dg.AllowUserToDeleteRows = false;
            this.Machine_Dg.AllowUserToOrderColumns = true;
            this.Machine_Dg.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Machine_Dg.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Machine_Number,
            this.Description});
            this.Machine_Dg.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.Machine_Dg.Location = new System.Drawing.Point(8, 147);
            this.Machine_Dg.Name = "Machine_Dg";
            this.Machine_Dg.ReadOnly = true;
            this.Machine_Dg.Size = new System.Drawing.Size(682, 193);
            this.Machine_Dg.TabIndex = 2;
            // 
            // Machine_Number
            // 
            this.Machine_Number.HeaderText = "Machine Number";
            this.Machine_Number.Name = "Machine_Number";
            this.Machine_Number.ReadOnly = true;
            this.Machine_Number.Width = 200;
            // 
            // Description
            // 
            this.Description.HeaderText = "Description";
            this.Description.Name = "Description";
            this.Description.ReadOnly = true;
            this.Description.Width = 430;
            // 
            // FrmCreateMachine
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(698, 379);
            this.Controls.Add(this.flowLayoutPanel3);
            this.Controls.Add(this.Top_Pn);
            this.Name = "FrmCreateMachine";
            this.Text = "FrmCreateMachine";
            this.Top_Pn.ResumeLayout(false);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel2.ResumeLayout(false);
            this.flowLayoutPanel2.PerformLayout();
            this.flowLayoutPanel3.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.Indicator_Pn.ResumeLayout(false);
            this.Indicator_Pn.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Machine_Dg)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel Top_Pn;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Button Close_Bt;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel3;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox Description_Tb;
        private System.Windows.Forms.TextBox Item_Number_Tb;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Button Continue_Bt;
        private System.Windows.Forms.Button Create_Bt;
        private System.Windows.Forms.Panel Indicator_Pn;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridView Machine_Dg;
        private System.Windows.Forms.DataGridViewTextBoxColumn Machine_Number;
        private System.Windows.Forms.DataGridViewTextBoxColumn Description;
    }
}