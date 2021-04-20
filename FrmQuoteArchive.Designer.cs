
namespace DSI_CRM
{
    partial class FrmQuoteArchive
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
            this.Close_Bt = new System.Windows.Forms.Button();
            this.Top_Pn_ = new System.Windows.Forms.FlowLayoutPanel();
            this.label2 = new System.Windows.Forms.Label();
            this.Quote_Number_Tb = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.Org_Name_Tb = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.Contact_Name_Tb = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.Edit_Bt = new System.Windows.Forms.Button();
            this.Copy_Bt = new System.Windows.Forms.Button();
            this.Quotes_Dg = new System.Windows.Forms.DataGridView();
            this.rowguid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Quote = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Org_Name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Contact_Name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Date_Created = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Top_Pn.SuspendLayout();
            this.Top_Pn_.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Quotes_Dg)).BeginInit();
            this.SuspendLayout();
            // 
            // Top_Pn
            // 
            this.Top_Pn.BackColor = System.Drawing.Color.Black;
            this.Top_Pn.Controls.Add(this.Close_Bt);
            this.Top_Pn.Controls.Add(this.Top_Pn_);
            this.Top_Pn.Dock = System.Windows.Forms.DockStyle.Top;
            this.Top_Pn.Location = new System.Drawing.Point(0, 0);
            this.Top_Pn.Name = "Top_Pn";
            this.Top_Pn.Size = new System.Drawing.Size(804, 60);
            this.Top_Pn.TabIndex = 2;
            // 
            // Close_Bt
            // 
            this.Close_Bt.BackColor = System.Drawing.Color.Transparent;
            this.Close_Bt.FlatAppearance.BorderSize = 0;
            this.Close_Bt.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(219)))), ((int)(((byte)(6)))), ((int)(((byte)(44)))));
            this.Close_Bt.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.Close_Bt.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Close_Bt.Image = global::DSI_CRM.Properties.Resources.New_Close_Bt;
            this.Close_Bt.Location = new System.Drawing.Point(769, 3);
            this.Close_Bt.Name = "Close_Bt";
            this.Close_Bt.Size = new System.Drawing.Size(32, 24);
            this.Close_Bt.TabIndex = 3;
            this.Close_Bt.UseVisualStyleBackColor = false;
            this.Close_Bt.Click += new System.EventHandler(this.Close_Bt_Click);
            // 
            // Top_Pn_
            // 
            this.Top_Pn_.Controls.Add(this.label2);
            this.Top_Pn_.Controls.Add(this.Quote_Number_Tb);
            this.Top_Pn_.Controls.Add(this.label1);
            this.Top_Pn_.Controls.Add(this.Org_Name_Tb);
            this.Top_Pn_.Controls.Add(this.label3);
            this.Top_Pn_.Controls.Add(this.Contact_Name_Tb);
            this.Top_Pn_.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Top_Pn_.Location = new System.Drawing.Point(12, 26);
            this.Top_Pn_.Name = "Top_Pn_";
            this.Top_Pn_.Size = new System.Drawing.Size(759, 26);
            this.Top_Pn_.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(3, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(60, 23);
            this.label2.TabIndex = 65;
            this.label2.Text = "Quote";
            // 
            // Quote_Number_Tb
            // 
            this.Quote_Number_Tb.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.Quote_Number_Tb.Location = new System.Drawing.Point(69, 3);
            this.Quote_Number_Tb.Name = "Quote_Number_Tb";
            this.Quote_Number_Tb.Size = new System.Drawing.Size(75, 23);
            this.Quote_Number_Tb.TabIndex = 64;
            this.Quote_Number_Tb.Tag = "#";
            this.Quote_Number_Tb.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(150, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(170, 23);
            this.label1.TabIndex = 63;
            this.label1.Text = "Organization Name";
            // 
            // Org_Name_Tb
            // 
            this.Org_Name_Tb.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.Org_Name_Tb.Location = new System.Drawing.Point(326, 3);
            this.Org_Name_Tb.Name = "Org_Name_Tb";
            this.Org_Name_Tb.Size = new System.Drawing.Size(75, 23);
            this.Org_Name_Tb.TabIndex = 60;
            this.Org_Name_Tb.Tag = "Search";
            this.Org_Name_Tb.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(407, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(128, 23);
            this.label3.TabIndex = 61;
            this.label3.Text = "Contact Name";
            // 
            // Contact_Name_Tb
            // 
            this.Contact_Name_Tb.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.Contact_Name_Tb.Location = new System.Drawing.Point(541, 3);
            this.Contact_Name_Tb.Name = "Contact_Name_Tb";
            this.Contact_Name_Tb.Size = new System.Drawing.Size(75, 23);
            this.Contact_Name_Tb.TabIndex = 62;
            this.Contact_Name_Tb.Tag = "Search";
            this.Contact_Name_Tb.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Controls.Add(this.Quotes_Dg);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel1.Location = new System.Drawing.Point(0, 60);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(804, 391);
            this.panel1.TabIndex = 3;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.Edit_Bt);
            this.panel2.Controls.Add(this.Copy_Bt);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 346);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(804, 45);
            this.panel2.TabIndex = 61;
            // 
            // Edit_Bt
            // 
            this.Edit_Bt.BackColor = System.Drawing.Color.Transparent;
            this.Edit_Bt.FlatAppearance.BorderSize = 0;
            this.Edit_Bt.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Black;
            this.Edit_Bt.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.Edit_Bt.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Edit_Bt.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Edit_Bt.ForeColor = System.Drawing.Color.Black;
            this.Edit_Bt.Image = global::DSI_CRM.Properties.Resources.icons8_ok_24px1;
            this.Edit_Bt.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.Edit_Bt.Location = new System.Drawing.Point(685, 4);
            this.Edit_Bt.Name = "Edit_Bt";
            this.Edit_Bt.Size = new System.Drawing.Size(116, 29);
            this.Edit_Bt.TabIndex = 177;
            this.Edit_Bt.Text = "Edit";
            this.Edit_Bt.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.Edit_Bt.UseVisualStyleBackColor = false;
            this.Edit_Bt.Click += new System.EventHandler(this.Edit_Bt_Click_1);
            // 
            // Copy_Bt
            // 
            this.Copy_Bt.BackColor = System.Drawing.Color.Transparent;
            this.Copy_Bt.FlatAppearance.BorderSize = 0;
            this.Copy_Bt.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Black;
            this.Copy_Bt.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.Copy_Bt.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Copy_Bt.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Copy_Bt.ForeColor = System.Drawing.Color.Black;
            this.Copy_Bt.Image = global::DSI_CRM.Properties.Resources.icons8_copyright_24px;
            this.Copy_Bt.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.Copy_Bt.Location = new System.Drawing.Point(542, 4);
            this.Copy_Bt.Name = "Copy_Bt";
            this.Copy_Bt.Size = new System.Drawing.Size(137, 29);
            this.Copy_Bt.TabIndex = 176;
            this.Copy_Bt.Text = "Copy Quote";
            this.Copy_Bt.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.Copy_Bt.UseVisualStyleBackColor = false;
            this.Copy_Bt.Visible = false;
            this.Copy_Bt.Click += new System.EventHandler(this.Copy_Bt_Click_1);
            // 
            // Quotes_Dg
            // 
            this.Quotes_Dg.AllowUserToAddRows = false;
            this.Quotes_Dg.AllowUserToDeleteRows = false;
            this.Quotes_Dg.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.Quotes_Dg.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.Quotes_Dg.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.Quotes_Dg.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Quotes_Dg.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.rowguid,
            this.Quote,
            this.Org_Name,
            this.Contact_Name,
            this.Date_Created});
            this.Quotes_Dg.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Quotes_Dg.GridColor = System.Drawing.Color.White;
            this.Quotes_Dg.Location = new System.Drawing.Point(0, 0);
            this.Quotes_Dg.MultiSelect = false;
            this.Quotes_Dg.Name = "Quotes_Dg";
            this.Quotes_Dg.ReadOnly = true;
            this.Quotes_Dg.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.Quotes_Dg.RowHeadersVisible = false;
            this.Quotes_Dg.Size = new System.Drawing.Size(804, 391);
            this.Quotes_Dg.TabIndex = 60;
            this.Quotes_Dg.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.Quotes_Dg_CellContentClick);
            // 
            // rowguid
            // 
            this.rowguid.HeaderText = "rowguid";
            this.rowguid.Name = "rowguid";
            this.rowguid.ReadOnly = true;
            this.rowguid.Visible = false;
            // 
            // Quote
            // 
            this.Quote.HeaderText = "Quote";
            this.Quote.Name = "Quote";
            this.Quote.ReadOnly = true;
            this.Quote.Width = 70;
            // 
            // Org_Name
            // 
            this.Org_Name.HeaderText = "Org_Name";
            this.Org_Name.Name = "Org_Name";
            this.Org_Name.ReadOnly = true;
            this.Org_Name.Width = 300;
            // 
            // Contact_Name
            // 
            this.Contact_Name.HeaderText = "Contact Name";
            this.Contact_Name.Name = "Contact_Name";
            this.Contact_Name.ReadOnly = true;
            this.Contact_Name.Width = 225;
            // 
            // Date_Created
            // 
            this.Date_Created.HeaderText = "Date Created";
            this.Date_Created.Name = "Date_Created";
            this.Date_Created.ReadOnly = true;
            this.Date_Created.Width = 215;
            // 
            // FrmQuoteArchive
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(804, 451);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.Top_Pn);
            this.Name = "FrmQuoteArchive";
            this.Text = "FrmQuoteArchive";
            this.Top_Pn.ResumeLayout(false);
            this.Top_Pn_.ResumeLayout(false);
            this.Top_Pn_.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Quotes_Dg)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel Top_Pn;
        private System.Windows.Forms.FlowLayoutPanel Top_Pn_;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox Contact_Name_Tb;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox Org_Name_Tb;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridView Quotes_Dg;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox Quote_Number_Tb;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button Edit_Bt;
        private System.Windows.Forms.Button Copy_Bt;
        private System.Windows.Forms.Button Close_Bt;
        private System.Windows.Forms.DataGridViewTextBoxColumn rowguid;
        private System.Windows.Forms.DataGridViewTextBoxColumn Quote;
        private System.Windows.Forms.DataGridViewTextBoxColumn Org_Name;
        private System.Windows.Forms.DataGridViewTextBoxColumn Contact_Name;
        private System.Windows.Forms.DataGridViewTextBoxColumn Date_Created;
    }
}