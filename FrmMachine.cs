using DSI_CRM.Models;
using DSI_CRM.Service;
using DSI_CRM.Services;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace DSI_CRM
{
    public partial class FrmMachine : Form
    {
        // Notes
        // Datagrid: The grids in this page only display data.
        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;
        [DllImportAttribute("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [DllImportAttribute("user32.dll")]
        public static extern bool ReleaseCapture();

        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        private static extern IntPtr CreateRoundRectRgn
        (
            int nLeftRect,     // x-coordinate of upper-left corner
            int nTopRect,      // y-coordinate of upper-left corner
            int nRightRect,    // x-coordinate of lower-right corner
            int nBottomRect,   // y-coordinate of lower-right corner
            int nWidthEllipse, // height of ellipse
            int nHeightEllipse // width of ellipse
        );

        private static Machine MACHINE;
        private static List<CheckBox> CHECKBOXES;
        private static bool NEW;

        public FrmMachine()
        {
            InitializeComponent();

            Init_Page();

            MACHINE = new Machine();
            CHECKBOXES = new List<CheckBox>();
            NEW = false;
            Save_Bt.Enabled = false;
        }

        private void Init_Page()
        {
            FormBorderStyle = FormBorderStyle.None;
            Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 20, 20));
            if (DataStore.Get_Theme_CONFIG())
            {
                Top_Pn.BackColor = DataStore.Get_CONFIG_Theme_Color();
                Banner_Pn.BackColor = DataStore.Get_CONFIG_Theme_Color();
            }
            Top_Pn.MouseDown += Mouse_Down;
            Banner_Pn.MouseDown += Mouse_Down;
            Item_Number_Tb.KeyDown += Item_Number_Tb_KeyDown;
            Accessory_Tb.KeyDown += Accessory_Tb_KeyDown;
            Accessories_Dg.CellClick += Accessory_Dg_CellClick;
            Accessories_Rb.CheckedChanged += Cb_CheckedChanged;
            Console_PFU_Rb.CheckedChanged += Cb_CheckedChanged;
            Digital_Acc_Rb.CheckedChanged += Cb_CheckedChanged;
            Fax_Option_Rb.CheckedChanged += Cb_CheckedChanged;
            Misc_Rb.CheckedChanged += Cb_CheckedChanged;
            Printer_Options_Rb.CheckedChanged += Cb_CheckedChanged;
            // Auto Complet Text
            Setup_Auto_Complet();
            // CheckBoxes
        }

        private void Setup_Auto_Complet()
        {
            Accessory_Tb.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            Accessory_Tb.AutoCompleteSource = AutoCompleteSource.CustomSource;
            //Base_Machine_Tb.AutoCompleteSuggest.SuggestMode = SuggestMode.Contains;
            Accessory_Tb.AutoCompleteCustomSource = Process.Generate_Machine_Numbers_Auto_Complet_All();

            Item_Number_Tb.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            Item_Number_Tb.AutoCompleteSource = AutoCompleteSource.CustomSource;
            Item_Number_Tb.AutoCompleteCustomSource = Process.Generate_Machine_Numbers_Auto_Complet_All();
        }

        private void Color_DataGrid(DataGridView dg)
        {
            foreach (DataGridViewRow r in dg.Rows)
            {
                if (((string)r.Cells[3].Value).ToUpper().Equals((string)Accessories_Rb.Tag))
                {
                    //r.DefaultCellStyle.BackColor = Color.FromArgb(192, 255, 255);
                    r.DefaultCellStyle.BackColor = Accessories_Rb.BackColor;
                }
                else if (((string)r.Cells[3].Value).ToUpper().Equals((string)Console_PFU_Rb.Tag))
                {
                    r.DefaultCellStyle.BackColor = Console_PFU_Rb.BackColor;
                }
                else if (((string)r.Cells[3].Value).ToUpper().Equals((string)Digital_Acc_Rb.Tag))
                {
                    r.DefaultCellStyle.BackColor = Digital_Acc_Rb.BackColor;
                }
                else if (((string)r.Cells[3].Value).ToUpper().Equals((string)Fax_Option_Rb.Tag))
                {
                    r.DefaultCellStyle.BackColor = Fax_Option_Rb.BackColor;
                }
                else if (((string)r.Cells[3].Value).ToUpper().Equals((string)Misc_Rb.Tag))
                {
                    r.DefaultCellStyle.BackColor = Misc_Rb.BackColor;
                }
                else if (((string)r.Cells[3].Value).ToUpper().Equals((string)Printer_Options_Rb.Tag))
                {
                    r.DefaultCellStyle.BackColor = Printer_Options_Rb.BackColor;
                }
            }
        }

        private void Cb_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton c = (RadioButton)sender;
            if (c.Checked)
            {
                foreach (DataGridViewRow r in Accessories_Dg.Rows)
                {
                    if (((string)r.Cells[3].Value).ToUpper().Equals((string)c.Tag))
                    {
                        Accessories_Dg.Rows.Insert(0, r.Cells[0].Value, r.Cells[1].Value, r.Cells[2].Value, r.Cells[3].Value, r.Cells[4].Value, r.Cells[5].Value, r.Cells[6].Value);
                        Accessories_Dg.Rows.Remove(r);
                    }
                }
            }
            Color_DataGrid(Accessories_Dg);
            Refresh();
        }

        private void Draw_Accessories(List<Machine> machines, DataGridView dg)
        {
            dg.Rows.Clear();
            foreach (Machine m in machines)
            {
                dg.Rows.Add(m.rowguid, m.Item_Number, m.Description, m.Category, m.Vendor_Description, m.Year, m.Configuration_ID);
            }
            Color_DataGrid(dg);
        }


        private void Accessory_Tb_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && !string.IsNullOrWhiteSpace(Accessory_Tb.Text) && DataStore.Get_Machine_Number_Dictionary().ContainsKey(Accessory_Tb.Text.ToUpper()))
            {
                int machine_Number = DataStore.Get_Machine_Number_Dictionary()[Accessory_Tb.Text];
                Machine temp = DataStore.Get_Machine_Number_wo_Acc_REST(machine_Number.ToString());
                if (temp.Category.Equals("BASE_MACHINE"))
                {
                    Process.Display_Alert("NO LINK CAN'T BE MADE BETWEEN BASE_MACHINE OBJECT", false);
                    return;
                }
                MACHINE.Add_Accessory(temp);
                Draw_Accessories(MACHINE.Get_Accessories(), Accessories_Dg);
            }
        }


        private void Item_Number_Tb_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && !NEW && !string.IsNullOrWhiteSpace(Item_Number_Tb.Text))
            {
                Search_Tb_Helper_();
            }
        }

        private void Search_Tb_Helper_()
        {
            if (DataStore.Get_Machine_Number_Dictionary().ContainsKey(Item_Number_Tb.Text))
            {
                int machine_Number = DataStore.Get_Machine_Number_Dictionary()[Item_Number_Tb.Text];
                MACHINE = DataStore.Retrieve_Accessories_w(machine_Number.ToString());
                Search_Bt.Enabled = false;
                Save_Bt.Enabled = true;
                Populate();
            }
            else
            {
                FrmAlert frm = new FrmAlert("Create a New Machine?", true)
                {
                    StartPosition = FormStartPosition.CenterScreen
                };
                DialogResult result = frm.ShowDialog();
                if (result == DialogResult.Yes)
                {
                    Visible = false;
                    using (FrmCreateMachine form = new FrmCreateMachine())
                    {
                        form.ShowDialog();
                        string return_Value = form.Return_Value;
                        if (return_Value != null)
                        {
                            MACHINE = DataStore.Get_Machine_Number_wo_Acc_REST(return_Value);
                            Search_Bt.Enabled = false;
                            Save_Bt.Enabled = true;
                            Populate();
                        }
                    }
                    Visible = true;
                }
            }
        }

        private void Populate()
        {
            Description_Tb.Text = MACHINE.Description;
            Make_Tb.Text = MACHINE.Make;
            Year_Tb.Text = MACHINE.Year.ToString();
            Vendor_Description_Tb.Text = MACHINE.Vendor_Description;
            Category_Cb.Text = MACHINE.Category;
            Model_Cost_Tb.Text = MACHINE.Model_Cost;
            Selling_Price_Tb.Text = MACHINE.Selling_Price;
            US_Comm_Tb.Text = MACHINE.US_Comm;
            Configuration_ID_Tb.Text = MACHINE.Configuration_ID;
            Date_Created_Tb.Text = MACHINE.Created_Datetime.ToString();
            if (MACHINE.Obsolete.Equals("1"))
            {
                Obsolete_Cb.Checked = true;
            }
            Purchase_Tb.Text = MACHINE.Purchase;
            Months_24_FMV_Tb.Text = MACHINE.FMV_24_Months;
            Months_36_FMV_Tb.Text = MACHINE.FMV_36_Months;
            Months_48_FMV_Tb.Text = MACHINE.FMV_48_Months;
            Months_60_FMV_Tb.Text = MACHINE.FMV_60_Months;
            Months_24_Out_Tb.Text = MACHINE.Buyout_24_Months;
            Months_36_Out_Tb.Text = MACHINE.Buyout_36_Months;
            Months_48_Out_Tb.Text = MACHINE.Buyout_48_Months;
            Months_60_Out_Tb.Text = MACHINE.Buyout_60_Months;
            Overage_Tb.Text = MACHINE.Overage;
            Install_Comp_Tb.Text = MACHINE.Install_Comp;
            Order_Comp_Tb.Text = MACHINE.Order_Comp;
            Addtl_Comments_Tb.Text = MACHINE.St_Addt_Comments;
            Draw_Accessories(MACHINE.Get_Accessories(), Accessories_Dg);
        }



        private void Accessory_Dg_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Draw Machines
            if (e.RowIndex == -1)
            {
                return;
            }
            string SELECTED_MACHINE = Accessories_Dg.Rows[e.RowIndex].Cells[1].Value.ToString();
            if (e.ColumnIndex == Accessories_Dg.Columns["Delete_Column"].Index)
            {
                foreach (Machine m in MACHINE.Get_Accessories())
                {
                    if (m.Item_Number.Equals(SELECTED_MACHINE))
                    {
                        MACHINE.Get_Accessories().Remove(m);
                        Draw_Accessories(MACHINE.Get_Accessories(), Accessories_Dg);
                        return;
                    }
                }
            }
        }

        private void Mouse_Down(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }


        private void Close_Bt_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void Reset_Bt_Click(object sender, EventArgs e)
        {
            Draw_Accessories(MACHINE.Get_Accessories(), Accessories_Dg);
        }



        private bool Check_Tb()
        {
            if (string.IsNullOrEmpty(Description_Tb.Text))
            {
                Process.Display_Alert("Invalid Description", false);
                return false;
                //}else if (string.IsNullOrEmpty(Make_Tb.Text))
                //{
                //    Process.Display_Alert("Invalid Make", false);
                //    return false;
                //}else if (string.IsNullOrEmpty(Year_Tb.Text))
                //{
                //    Process.Display_Alert("Invalid Year", false);
                //    return false;
            }
            else if (string.IsNullOrEmpty(Vendor_Description_Tb.Text))
            {
                Process.Display_Alert("Invalid Vendor Decription", false);
                return false;
            }
            else if (string.IsNullOrEmpty(Category_Cb.Text))
            {
                Process.Display_Alert("Invalid Category", false);
                return false;
            }
            else if (string.IsNullOrEmpty(Model_Cost_Tb.Text))
            {
                Process.Display_Alert("Invalid Model Cost", false);
                return false;
            }
            else if (string.IsNullOrEmpty(Selling_Price_Tb.Text))
            {
                Process.Display_Alert("Invalid Selling Price", false);
                return false;
            }
            else if (string.IsNullOrEmpty(US_Comm_Tb.Text))
            {
                Process.Display_Alert("Invalid US_Comm", false);
                return false;
            }
            //else if (string.IsNullOrEmpty(Configuration_ID_Tb.Text))
            //{
            //    Process.Display_Alert("Invalid Configuration", false);
            //    return false;
            //}
            else
            {
                return true;
            }
        }

        private void Search_Bt_Click_1(object sender, EventArgs e)
        {
            Search_Tb_Helper_();
        }

        private void Save_Bt_Click_1(object sender, EventArgs e)
        {
            try
            {
                //Check Tb
                if (!Check_Tb())
                {
                    return;
                }
                //Update MACHINE
                MACHINE.Item_Number = Item_Number_Tb.Text;
                MACHINE.Description = Description_Tb.Text;
                MACHINE.Make = Make_Tb.Text;
                MACHINE.Year = (int)long.Parse(Year_Tb.Text);
                MACHINE.Vendor_Description = Vendor_Description_Tb.Text;
                MACHINE.Category = Category_Cb.Text;
                MACHINE.Model_Cost = Model_Cost_Tb.Text;
                MACHINE.Selling_Price = Selling_Price_Tb.Text;
                MACHINE.US_Comm = US_Comm_Tb.Text;
                MACHINE.Configuration_ID = Configuration_ID_Tb.Text;

                // Obsolete
                if (Obsolete_Cb.Checked)
                {
                    MACHINE.Obsolete = "1";
                }
                else
                {
                    MACHINE.Obsolete = "0";
                }
                MACHINE.Purchase = Purchase_Tb.Text;
                MACHINE.FMV_24_Months = Months_24_FMV_Tb.Text;
                MACHINE.FMV_36_Months = Months_36_FMV_Tb.Text;
                MACHINE.FMV_48_Months = Months_48_FMV_Tb.Text;
                MACHINE.FMV_60_Months = Months_60_FMV_Tb.Text;
                MACHINE.Buyout_24_Months = Months_24_Out_Tb.Text;
                MACHINE.Buyout_36_Months = Months_36_Out_Tb.Text;
                MACHINE.Buyout_48_Months = Months_48_Out_Tb.Text;
                MACHINE.Buyout_60_Months = Months_60_Out_Tb.Text;
                MACHINE.Overage = Overage_Tb.Text;
                MACHINE.Install_Comp = Install_Comp_Tb.Text;
                MACHINE.Order_Comp = Order_Comp_Tb.Text;
                MACHINE.St_Addt_Comments = Addtl_Comments_Tb.Text;
                //Update
                DataStore.Update_Machine_REST(MACHINE);
                // Clear all Links && Make new ones
                DataStore.Delete_Machine_Links_REST(MACHINE);
                foreach (Machine m in MACHINE.Get_Accessories())
                {
                    DataStore.Add_Machine_Links_REST(MACHINE, m);
                }

                MACHINE = new Machine();
                Item_Number_Tb.Text = "";
                Populate();
                Search_Bt.Enabled = true;
                Save_Bt.Enabled = false;
                //Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private void Individual_Items_Tab_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void Reset_Bt_Click_1(object sender, EventArgs e)
        {
            MACHINE = new Machine();
            Item_Number_Tb.Text = "";
            Populate();
            Search_Bt.Enabled = true;
            Save_Bt.Enabled = false;
            Date_Created_Tb.Text = "";
        }

        private void Accessories_Dg_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void tabPage3_Click(object sender, EventArgs e)
        {

        }
    }
}
