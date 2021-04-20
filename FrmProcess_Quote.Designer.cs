
namespace DSI_CRM
{
    partial class FrmProcess_Quote
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
            this.panel2 = new System.Windows.Forms.Panel();
            this.Cancel_Bt = new System.Windows.Forms.Button();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.flowLayoutPanel2 = new System.Windows.Forms.FlowLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.Print_UGA_Customer_Cb = new System.Windows.Forms.CheckBox();
            this.Print_In_HOUSE_UGA_Cb = new System.Windows.Forms.CheckBox();
            this.Create_PDF_GA_Cb = new System.Windows.Forms.CheckBox();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.flowLayoutPanel3 = new System.Windows.Forms.FlowLayoutPanel();
            this.label18 = new System.Windows.Forms.Label();
            this.Print_Sales_Copy_Cb = new System.Windows.Forms.CheckBox();
            this.Print_Customer_Cb = new System.Windows.Forms.CheckBox();
            this.Create_PDF_Open_Cb = new System.Windows.Forms.CheckBox();
            this.checkBox2 = new System.Windows.Forms.CheckBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label2 = new System.Windows.Forms.Label();
            this.Continue_Bt = new System.Windows.Forms.Button();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.panel2.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.flowLayoutPanel2.SuspendLayout();
            this.flowLayoutPanel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(35)))), ((int)(((byte)(35)))));
            this.panel2.Controls.Add(this.Cancel_Bt);
            this.panel2.Controls.Add(this.flowLayoutPanel1);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.Continue_Bt);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(637, 319);
            this.panel2.TabIndex = 174;
            // 
            // Cancel_Bt
            // 
            this.Cancel_Bt.BackColor = System.Drawing.Color.Transparent;
            this.Cancel_Bt.FlatAppearance.BorderSize = 0;
            this.Cancel_Bt.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.Cancel_Bt.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.Cancel_Bt.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Cancel_Bt.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Cancel_Bt.ForeColor = System.Drawing.Color.White;
            this.Cancel_Bt.Image = global::DSI_CRM.Properties.Resources.icons8_round_24px1;
            this.Cancel_Bt.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.Cancel_Bt.Location = new System.Drawing.Point(496, 266);
            this.Cancel_Bt.Name = "Cancel_Bt";
            this.Cancel_Bt.Size = new System.Drawing.Size(116, 29);
            this.Cancel_Bt.TabIndex = 175;
            this.Cancel_Bt.Text = "Cancel";
            this.Cancel_Bt.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.Cancel_Bt.UseVisualStyleBackColor = false;
            this.Cancel_Bt.Click += new System.EventHandler(this.button1_Click);
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.panel1);
            this.flowLayoutPanel1.Controls.Add(this.pictureBox1);
            this.flowLayoutPanel1.Location = new System.Drawing.Point(12, 51);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(613, 197);
            this.flowLayoutPanel1.TabIndex = 174;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.flowLayoutPanel2);
            this.panel1.Controls.Add(this.flowLayoutPanel3);
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(600, 189);
            this.panel1.TabIndex = 175;
            // 
            // flowLayoutPanel2
            // 
            this.flowLayoutPanel2.Controls.Add(this.label1);
            this.flowLayoutPanel2.Controls.Add(this.Print_UGA_Customer_Cb);
            this.flowLayoutPanel2.Controls.Add(this.Print_In_HOUSE_UGA_Cb);
            this.flowLayoutPanel2.Controls.Add(this.Create_PDF_GA_Cb);
            this.flowLayoutPanel2.Controls.Add(this.checkBox1);
            this.flowLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Left;
            this.flowLayoutPanel2.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.flowLayoutPanel2.Location = new System.Drawing.Point(295, 0);
            this.flowLayoutPanel2.Name = "flowLayoutPanel2";
            this.flowLayoutPanel2.Padding = new System.Windows.Forms.Padding(30, 10, 30, 30);
            this.flowLayoutPanel2.Size = new System.Drawing.Size(302, 189);
            this.flowLayoutPanel2.TabIndex = 1;
            this.flowLayoutPanel2.Paint += new System.Windows.Forms.PaintEventHandler(this.flowLayoutPanel2_Paint);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label1.Location = new System.Drawing.Point(33, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(190, 23);
            this.label1.TabIndex = 66;
            this.label1.Text = "State of GA Customer";
            // 
            // Print_UGA_Customer_Cb
            // 
            this.Print_UGA_Customer_Cb.AutoSize = true;
            this.Print_UGA_Customer_Cb.BackColor = System.Drawing.Color.Transparent;
            this.Print_UGA_Customer_Cb.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Print_UGA_Customer_Cb.ForeColor = System.Drawing.Color.Silver;
            this.Print_UGA_Customer_Cb.Image = global::DSI_CRM.Properties.Resources.icons8_print_file_24px_1;
            this.Print_UGA_Customer_Cb.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.Print_UGA_Customer_Cb.Location = new System.Drawing.Point(33, 36);
            this.Print_UGA_Customer_Cb.Name = "Print_UGA_Customer_Cb";
            this.Print_UGA_Customer_Cb.Size = new System.Drawing.Size(240, 29);
            this.Print_UGA_Customer_Cb.TabIndex = 69;
            this.Print_UGA_Customer_Cb.Text = "Print UGA Customer";
            this.Print_UGA_Customer_Cb.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.Print_UGA_Customer_Cb.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.Print_UGA_Customer_Cb.UseVisualStyleBackColor = false;
            // 
            // Print_In_HOUSE_UGA_Cb
            // 
            this.Print_In_HOUSE_UGA_Cb.AutoSize = true;
            this.Print_In_HOUSE_UGA_Cb.BackColor = System.Drawing.Color.Transparent;
            this.Print_In_HOUSE_UGA_Cb.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Print_In_HOUSE_UGA_Cb.ForeColor = System.Drawing.Color.Silver;
            this.Print_In_HOUSE_UGA_Cb.Image = global::DSI_CRM.Properties.Resources.icons8_print_file_24px_1;
            this.Print_In_HOUSE_UGA_Cb.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.Print_In_HOUSE_UGA_Cb.Location = new System.Drawing.Point(33, 71);
            this.Print_In_HOUSE_UGA_Cb.Name = "Print_In_HOUSE_UGA_Cb";
            this.Print_In_HOUSE_UGA_Cb.Size = new System.Drawing.Size(245, 29);
            this.Print_In_HOUSE_UGA_Cb.TabIndex = 70;
            this.Print_In_HOUSE_UGA_Cb.Text = "Print In HOUSE UGA";
            this.Print_In_HOUSE_UGA_Cb.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.Print_In_HOUSE_UGA_Cb.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.Print_In_HOUSE_UGA_Cb.UseVisualStyleBackColor = false;
            // 
            // Create_PDF_GA_Cb
            // 
            this.Create_PDF_GA_Cb.AutoSize = true;
            this.Create_PDF_GA_Cb.BackColor = System.Drawing.Color.Transparent;
            this.Create_PDF_GA_Cb.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Create_PDF_GA_Cb.ForeColor = System.Drawing.Color.Silver;
            this.Create_PDF_GA_Cb.Image = global::DSI_CRM.Properties.Resources.icons8_pdf_24px_1;
            this.Create_PDF_GA_Cb.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.Create_PDF_GA_Cb.Location = new System.Drawing.Point(33, 106);
            this.Create_PDF_GA_Cb.Name = "Create_PDF_GA_Cb";
            this.Create_PDF_GA_Cb.Size = new System.Drawing.Size(157, 29);
            this.Create_PDF_GA_Cb.TabIndex = 71;
            this.Create_PDF_GA_Cb.Text = "Create PDF";
            this.Create_PDF_GA_Cb.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.Create_PDF_GA_Cb.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.Create_PDF_GA_Cb.UseVisualStyleBackColor = false;
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.BackColor = System.Drawing.Color.Transparent;
            this.checkBox1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.checkBox1.ForeColor = System.Drawing.Color.Silver;
            this.checkBox1.Image = global::DSI_CRM.Properties.Resources.icons8_pdf_24px_1;
            this.checkBox1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.checkBox1.Location = new System.Drawing.Point(33, 141);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(140, 29);
            this.checkBox1.TabIndex = 72;
            this.checkBox1.Text = "Save PDF";
            this.checkBox1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.checkBox1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.checkBox1.UseVisualStyleBackColor = false;
            // 
            // flowLayoutPanel3
            // 
            this.flowLayoutPanel3.Controls.Add(this.label18);
            this.flowLayoutPanel3.Controls.Add(this.Print_Sales_Copy_Cb);
            this.flowLayoutPanel3.Controls.Add(this.Print_Customer_Cb);
            this.flowLayoutPanel3.Controls.Add(this.Create_PDF_Open_Cb);
            this.flowLayoutPanel3.Controls.Add(this.checkBox2);
            this.flowLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Left;
            this.flowLayoutPanel3.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.flowLayoutPanel3.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanel3.Name = "flowLayoutPanel3";
            this.flowLayoutPanel3.Padding = new System.Windows.Forms.Padding(30, 10, 30, 30);
            this.flowLayoutPanel3.Size = new System.Drawing.Size(295, 189);
            this.flowLayoutPanel3.TabIndex = 0;
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label18.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label18.Location = new System.Drawing.Point(33, 10);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(128, 23);
            this.label18.TabIndex = 65;
            this.label18.Text = "Open Account";
            // 
            // Print_Sales_Copy_Cb
            // 
            this.Print_Sales_Copy_Cb.AutoSize = true;
            this.Print_Sales_Copy_Cb.BackColor = System.Drawing.Color.Transparent;
            this.Print_Sales_Copy_Cb.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.Print_Sales_Copy_Cb.ForeColor = System.Drawing.Color.Silver;
            this.Print_Sales_Copy_Cb.Image = global::DSI_CRM.Properties.Resources.icons8_print_file_24px_1;
            this.Print_Sales_Copy_Cb.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.Print_Sales_Copy_Cb.Location = new System.Drawing.Point(33, 36);
            this.Print_Sales_Copy_Cb.Name = "Print_Sales_Copy_Cb";
            this.Print_Sales_Copy_Cb.Size = new System.Drawing.Size(205, 29);
            this.Print_Sales_Copy_Cb.TabIndex = 66;
            this.Print_Sales_Copy_Cb.Text = "Print Sales Copy";
            this.Print_Sales_Copy_Cb.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.Print_Sales_Copy_Cb.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.Print_Sales_Copy_Cb.UseVisualStyleBackColor = false;
            // 
            // Print_Customer_Cb
            // 
            this.Print_Customer_Cb.AutoSize = true;
            this.Print_Customer_Cb.BackColor = System.Drawing.Color.Transparent;
            this.Print_Customer_Cb.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Print_Customer_Cb.ForeColor = System.Drawing.Color.Silver;
            this.Print_Customer_Cb.Image = global::DSI_CRM.Properties.Resources.icons8_print_file_24px_1;
            this.Print_Customer_Cb.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.Print_Customer_Cb.Location = new System.Drawing.Point(33, 71);
            this.Print_Customer_Cb.Name = "Print_Customer_Cb";
            this.Print_Customer_Cb.Size = new System.Drawing.Size(192, 29);
            this.Print_Customer_Cb.TabIndex = 67;
            this.Print_Customer_Cb.Text = "Print Customer";
            this.Print_Customer_Cb.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.Print_Customer_Cb.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.Print_Customer_Cb.UseVisualStyleBackColor = false;
            // 
            // Create_PDF_Open_Cb
            // 
            this.Create_PDF_Open_Cb.AutoSize = true;
            this.Create_PDF_Open_Cb.BackColor = System.Drawing.Color.Transparent;
            this.Create_PDF_Open_Cb.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Create_PDF_Open_Cb.ForeColor = System.Drawing.Color.Silver;
            this.Create_PDF_Open_Cb.Image = global::DSI_CRM.Properties.Resources.icons8_pdf_24px_1;
            this.Create_PDF_Open_Cb.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.Create_PDF_Open_Cb.Location = new System.Drawing.Point(33, 106);
            this.Create_PDF_Open_Cb.Name = "Create_PDF_Open_Cb";
            this.Create_PDF_Open_Cb.Size = new System.Drawing.Size(157, 29);
            this.Create_PDF_Open_Cb.TabIndex = 68;
            this.Create_PDF_Open_Cb.Text = "Create PDF";
            this.Create_PDF_Open_Cb.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.Create_PDF_Open_Cb.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.Create_PDF_Open_Cb.UseVisualStyleBackColor = false;
            // 
            // checkBox2
            // 
            this.checkBox2.AutoSize = true;
            this.checkBox2.BackColor = System.Drawing.Color.Transparent;
            this.checkBox2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.checkBox2.ForeColor = System.Drawing.Color.Silver;
            this.checkBox2.Image = global::DSI_CRM.Properties.Resources.icons8_pdf_24px_1;
            this.checkBox2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.checkBox2.Location = new System.Drawing.Point(33, 141);
            this.checkBox2.Name = "checkBox2";
            this.checkBox2.Size = new System.Drawing.Size(140, 29);
            this.checkBox2.TabIndex = 69;
            this.checkBox2.Text = "Save PDF";
            this.checkBox2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.checkBox2.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.checkBox2.UseVisualStyleBackColor = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::DSI_CRM.Properties.Resources.Infinity_1s_200px;
            this.pictureBox1.Location = new System.Drawing.Point(200, 198);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(200, 3, 3, 3);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(195, 175);
            this.pictureBox1.TabIndex = 176;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Visible = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(222, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(208, 23);
            this.label2.TabIndex = 64;
            this.label2.Text = "Print / Export Quotation";
            // 
            // Continue_Bt
            // 
            this.Continue_Bt.BackColor = System.Drawing.Color.Transparent;
            this.Continue_Bt.FlatAppearance.BorderSize = 0;
            this.Continue_Bt.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.Continue_Bt.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.Continue_Bt.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Continue_Bt.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Continue_Bt.ForeColor = System.Drawing.Color.White;
            this.Continue_Bt.Image = global::DSI_CRM.Properties.Resources.icons8_Sign_Out_24px;
            this.Continue_Bt.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.Continue_Bt.Location = new System.Drawing.Point(337, 266);
            this.Continue_Bt.Name = "Continue_Bt";
            this.Continue_Bt.Size = new System.Drawing.Size(137, 29);
            this.Continue_Bt.TabIndex = 173;
            this.Continue_Bt.Text = "Continue";
            this.Continue_Bt.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.Continue_Bt.UseVisualStyleBackColor = false;
            this.Continue_Bt.Click += new System.EventHandler(this.Save_Bt_Click);
            // 
            // backgroundWorker1
            // 
            this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
            this.backgroundWorker1.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker1_RunWorkerCompleted);
            // 
            // FrmProcess_Quote
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(637, 307);
            this.Controls.Add(this.panel2);
            this.Name = "FrmProcess_Quote";
            this.Text = "FrmProcess_Quote";
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.flowLayoutPanel2.ResumeLayout(false);
            this.flowLayoutPanel2.PerformLayout();
            this.flowLayoutPanel3.ResumeLayout(false);
            this.flowLayoutPanel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button Continue_Bt;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox Print_UGA_Customer_Cb;
        private System.Windows.Forms.CheckBox Print_In_HOUSE_UGA_Cb;
        private System.Windows.Forms.CheckBox Create_PDF_GA_Cb;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel3;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.CheckBox Print_Sales_Copy_Cb;
        private System.Windows.Forms.CheckBox Print_Customer_Cb;
        private System.Windows.Forms.CheckBox Create_PDF_Open_Cb;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button Cancel_Bt;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.CheckBox checkBox2;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
    }
}