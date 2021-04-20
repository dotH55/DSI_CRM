using DSI_CRM.Models;
using DSI_CRM.Service;
using DSI_CRM.Services;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace DSI_CRM
{
    public partial class FrmQuote : Form
    {
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

        // Global Variables
        private readonly Organization ORG;
        private readonly Contact CONTACT;
        private readonly Quote QUOTE;
        private string SELECTED_MACHINE = null;

        public FrmQuote(Quote QUOTE)
        {
            InitializeComponent();

            // Init Page
            Init_Page();

            // Initialize Global Var
            this.QUOTE = QUOTE;
            // I've switched rowguid & org_Number
            CONTACT = DataStore.Get_Contact_Contact_Number_REST(QUOTE.Contact_Number);
            // QUOTE.Org_Number will conta
            ORG = DataStore.Get_ORG_REST(QUOTE.Org_Number);

            Populate();
        }

        private void Populate()
        {
            Populate_Address();
            Populate_Quote_Info();
            Populate_Discount();
            Populate_Maint();
            Populate_Lease();
            Draw_Machines();
        }

        private void Populate_Quote_Info()
        {
            Date_Created_Tb.Text = QUOTE.Created_Datetime.ToString();
            Quote_Number_Tb.Text = QUOTE.Quote_Number;
            Organization_Tb.Text = ORG.Name;
            Contact_Tb.Text = CONTACT.GetContact_Name();
            Salesman_Tb.Text = QUOTE.Salesman_Initials;
        }

        private void Populate_Address()
        {
            Name_Tb.Text = ORG.Name;
            Phone_Tb.Text = ORG.Phone;
            Addr1_Tb.Text = ORG.GetAddresses()[0].Address_1;
            Addr2_Tb.Text = ORG.GetAddresses()[0].Address_2;
            City_Tb.Text = ORG.GetAddresses()[0].City;
            Zip_Tb.Text = ORG.GetAddresses()[0].Zip;
            County_Tb.Text = ORG.GetAddresses()[0].County;
            State_Tb.Text = ORG.GetAddresses()[0].State;

            if(QUOTE.Install_Location != null)
            {
                Name_1_Tb.Text = QUOTE.Install_Location.Name;
                Phone_1_Tb.Text = QUOTE.Install_Location.Phone;
                Addr1_1_Tb.Text = QUOTE.Install_Location.Addr_1;
                Addr2_1_Tb.Text = QUOTE.Install_Location.Addr_2;
                City_1_Tb.Text = QUOTE.Install_Location.City;
                County_1_Tb.Text = QUOTE.Install_Location.County;
                State_1_Tb.Text = QUOTE.Install_Location.State;
                Zip_1_Tb.Text = QUOTE.Install_Location.Zip;
            }
            else
            {
                Copy_Bt_Helper();
            }
            
        }
        private void Populate_Discount()
        {
            Man_Rebate_Tb.Text = QUOTE.Man_Rebate;
            Less_Disc_Trade_Tb.Text = QUOTE.Less_Disc_Trade;
            Addtl_Lease_Fees_Tb.Text = QUOTE.Addt_Lease_Fees;
        }

        private void Populate_Maint()
        {
            BW_Tb.Text = QUOTE.BW;
            BW_Excess_Tb.Text = QUOTE.BW_Excess;
            Color_Tb.Text = QUOTE.Color;
            Color_Excess_Tb.Text = QUOTE.Color_Excess;
            Billed_Terms_Cb.Text = QUOTE.Terms;
            Maint_Cost_Tb.Text = QUOTE.Maint_Total_Cost;
            Populate_Maint_Type(QUOTE.Maint_Type);
        }

        private void Draw_Machines()
        {
            Base_Machine_Dg.Rows.Clear();
            foreach (Machine m in QUOTE.Get_Machines())
            {
                // 0, new DataGridViewButtonCell(), "",  m.US_Comm, m.Total_Cost);
                Base_Machine_Dg.Rows.Add(m.rowguid, m.Machine_Number, m.Item_Number, m.Selling_Price, m.Model_Cost, m.Print_Model_Pricing);
            }
            if (QUOTE.Get_Machines().Count > 0)
            {
                SELECTED_MACHINE = (string)Base_Machine_Dg.Rows[0].Cells[0].Value;
                Draw_Accessories();
            }
        }

        private void Populate_Maint_Type(string maint_Type)
        {
            if (maint_Type.Equals((string)Unlimited_Service_Supplies_Rb.Tag) || string.IsNullOrEmpty(maint_Type))
            {
                Unlimited_Service_Supplies_Rb.Checked = true;
                QUOTE.Maint_Type = (string)Unlimited_Service_Supplies_Rb.Tag;
            }
            else if (maint_Type.Equals((string)Parts_Labor_Only_Rb.Tag))
            {
                Parts_Labor_Only_Rb.Checked = true;
            }
            else if (maint_Type.Equals((string)No_Contract_Rb.Tag))
            {
                No_Contract_Rb.Checked = true;
            }
        }

        private void Populate_Lease()
        {
            Leasing_Company_Cb.Text = QUOTE.Leasing_Company;
            Sell_Cost_Tb.Text = QUOTE.Lease_Fees;
            if (QUOTE.Lease_Type.Equals((string)FMV_Rb.Tag))
            {
                FMV_Rb.Checked = true;
            }
            else
            {
                Buyout_Rb.Checked = true;
            }

            Rate_1_Tb.Text = QUOTE.Lease_Rate_1;
            Rate_2_Tb.Text = QUOTE.Lease_Rate_2;
            Rate_3_Tb.Text = QUOTE.Lease_Rate_3;
            Rate_4_Tb.Text = QUOTE.Lease_Rate_4;

            Payment_1_Tb.Text = QUOTE.Payment_1;
            Payment_2_Tb.Text = QUOTE.Payment_2;
            Payment_3_Tb.Text = QUOTE.Payment_3;
            Payment_4_Tb.Text = QUOTE.Payment_4;

            Addtl_Info_Tb.Text = QUOTE.Addt_Info;
        }

        private string Get_Maint_Type()
        {
            if (Unlimited_Service_Supplies_Rb.Checked)
            {
                return (string)Unlimited_Service_Supplies_Rb.Tag;
            }
            else if (Parts_Labor_Only_Rb.Checked)
            {
                return (string)Parts_Labor_Only_Rb.Tag;
            }
            else
            {
                return (string)No_Contract_Rb.Tag;
            }
        }

        private string Get_Lease_Type()
        {
            if (FMV_Rb.Checked)
            {
                return (string)FMV_Rb.Tag;
            }
            else
            {
                return Buyout_Rb.Text;
            }
        }

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);

            if (Address_Pn.Visible)
            {
                Address_Pn.Visible = false;
                Address_Accordion_Bt.Image = Properties.Resources.Expand_32px;
            }
            else
            {
                Address_Pn.Visible = true;
                Address_Accordion_Bt.Image = Properties.Resources.Collapse_32px;
            }
            Address_Accordion_Bt.Refresh();
        }

        private void Init_Page()
        {
            FormBorderStyle = FormBorderStyle.None;
            Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 20, 20));
            if (DataStore.Get_Theme_CONFIG())
            {
                Top_Pn.BackColor = DataStore.Get_CONFIG_Theme_Color();
                Banner_Pn.BackColor = DataStore.Get_CONFIG_Theme_Color();
                Addition_Info_Accordion.BackColor = DataStore.Get_CONFIG_Theme_Color();
                Machine_Accordion.BackColor = DataStore.Get_CONFIG_Theme_Color();
                Address_Accordion.BackColor = DataStore.Get_CONFIG_Theme_Color();
                Maintenance_Accordion.BackColor = DataStore.Get_CONFIG_Theme_Color();
                Less_Discount_Accordion.BackColor = DataStore.Get_CONFIG_Theme_Color();
                Quote_Accordion.BackColor = DataStore.Get_CONFIG_Theme_Color();
                Less_Discount_Accordion.BackColor = DataStore.Get_CONFIG_Theme_Color();
                Lease_Accordion.BackColor = DataStore.Get_CONFIG_Theme_Color();
            }

            Top_Pn.MouseDown += Mouse_Down;
            Banner_Pn.MouseDown += Mouse_Down;
            Base_Machine_Tb.KeyDown += Base_Machine_Tb_KeyDown;
            //Base_Machine_Tb.TextChanged += Base_Machine_Tb_TextChanged;

            Name_Tb.GotFocus += Process.TB_Got_Focus;
            Name_Tb.LostFocus += Process.TB_Lost_Focus;

            Phone_Tb.GotFocus += Process.TB_Got_Focus;
            Phone_Tb.LostFocus += Process.TB_Lost_Focus;

            Addr1_Tb.GotFocus += Process.TB_Got_Focus;
            Addr1_Tb.LostFocus += Process.TB_Lost_Focus;

            Addr2_Tb.GotFocus += Process.TB_Got_Focus;
            Addr2_Tb.LostFocus += Process.TB_Lost_Focus;

            City_Tb.GotFocus += Process.TB_Got_Focus;
            City_Tb.LostFocus += Process.TB_Lost_Focus;

            County_Tb.GotFocus += County_Tb_GotFocus;

            State_Tb.GotFocus += Process.TB_Got_Focus;
            State_Tb.LostFocus += Process.TB_Lost_Focus;

            Zip_Tb.GotFocus += Process.TB_Got_Focus;
            Zip_Tb.LostFocus += Process.TB_Lost_Focus;

            Name_1_Tb.GotFocus += Process.TB_Got_Focus;
            Name_1_Tb.LostFocus += Process.TB_Lost_Focus;

            Phone_1_Tb.GotFocus += Process.TB_Got_Focus;
            Phone_1_Tb.LostFocus += Process.TB_Lost_Focus;

            Addr1_1_Tb.GotFocus += Process.TB_Got_Focus;
            Addr1_1_Tb.LostFocus += Process.TB_Lost_Focus;

            Addr2_1_Tb.GotFocus += Process.TB_Got_Focus;
            Addr2_1_Tb.LostFocus += Process.TB_Lost_Focus;

            City_1_Tb.GotFocus += Process.TB_Got_Focus;
            City_1_Tb.LostFocus += Process.TB_Lost_Focus;

            County_1_Tb.GotFocus += County_1_Tb_GotFocus;

            State_1_Tb.GotFocus += Process.TB_Got_Focus;
            State_1_Tb.LostFocus += Process.TB_Lost_Focus;

            Zip_1_Tb.GotFocus += Process.TB_Got_Focus;
            Zip_1_Tb.LostFocus += Process.TB_Lost_Focus;

            AutoComplete();

            Setup_Leasing_Companies();

            // These Eventhanders auto update QUOTE
            Quote_Number_Tb.LostFocus += Man_Rebate_Tb_LostFocus;
            Organization_Tb.LostFocus += Less_Disc_Trade_Tb_LostFocus;
            Contact_Tb.LostFocus += Addtl_Lease_Fees_Tb_LostFocus;
            BW_Tb.LostFocus += BW_Tb_LostFocus;
            BW_Excess_Tb.LostFocus += BW_Excess_Tb_LostFocus;
            Color_Tb.LostFocus += Color_Tb_LostFocus;
            Color_Excess_Tb.LostFocus += Color_Excess_Tb_LostFocus;
            Maint_Cost_Tb.LostFocus += Maint_Cost_Tb_LostFocus;
            Addtl_Info_Tb.LostFocus += Addtl_Info_Tb_LostFocus;

            Unlimited_Service_Supplies_Rb.CheckedChanged += Rb_CheckedChanged;
            Parts_Labor_Only_Rb.CheckedChanged += Rb_CheckedChanged;
            No_Contract_Rb.CheckedChanged += Rb_CheckedChanged;
            FMV_Rb.CheckedChanged += Rb_CheckedChanged_2;
            Buyout_Rb.CheckedChanged += Rb_CheckedChanged_2;

            Leasing_Company_Cb.SelectedIndexChanged += Leasing_Company_Cb_SelectedIndexChanged;
            Accessories_Rb.CheckedChanged += Cb_CheckedChanged;
            Console_PFU_Rb.CheckedChanged += Cb_CheckedChanged;
            Digital_Acc_Rb.CheckedChanged += Cb_CheckedChanged;
            Fax_Option_Rb.CheckedChanged += Cb_CheckedChanged;
            Misc_Rb.CheckedChanged += Cb_CheckedChanged;
            Printer_Options_Rb.CheckedChanged += Cb_CheckedChanged;

            Base_Machine_Dg.CellClick += Base_Machine_Dg_CellClick;
            Base_Machine_Dg.CellEndEdit += Base_Machine_Dg_CellEndEdit;
            Accessories_Dg.CellContentClick += Accessories_Dg_CellContentClick;
            Accessories_Dg.CellValueChanged += Accessories_Dg_CellValueChanged;
            Base_Machine_Dg.CellContentClick += Base_Machine_Dg_CellContentClick;
            Base_Machine_Dg.CellValueChanged += Base_Machine_Dg_CellValueChanged;
        }

        private void Accessories_Dg_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            //Console.WriteLine("CHANGED: " + Accessories_Dg.Rows[e.RowIndex].Cells[0].Value);
            string temp = (string)Accessories_Dg.Rows[e.RowIndex].Cells[1].Value;
            if ((bool)Accessories_Dg.Rows[e.RowIndex].Cells[5].Value && (bool)Accessories_Dg.Rows[e.RowIndex].Cells[4].Value)
            {
                Process.Display_Alert("SELECTED CAN'T BE OPTIONAL", false);
                return;
            }
            Machine ma = Get_Base(SELECTED_MACHINE);
            var tmp = search_Helper(ma.Get_Accessories(), (string)Accessories_Dg.Rows[e.RowIndex].Cells[0].Value);
            if(tmp != null)
            {
                tmp.Selling_Price = (string)Accessories_Dg.Rows[e.RowIndex].Cells[3].Value;
            }

            if (!(bool)Accessories_Dg.Rows[e.RowIndex].Cells[5].Value && (bool)Accessories_Dg.Rows[e.RowIndex].Cells[4].Value)
            {
                Machine m = DataStore.Get_From_Searched_Machines(temp);
                m.Selling_Price = (string)Accessories_Dg.Rows[e.RowIndex].Cells[3].Value;
                Get_Base(SELECTED_MACHINE).Add_Accessory(m);
            }
            else if ((bool)Accessories_Dg.Rows[e.RowIndex].Cells[5].Value && !(bool)Accessories_Dg.Rows[e.RowIndex].Cells[4].Value)
            {
                Machine m = DataStore.Get_From_Searched_Machines(temp);
                m.rowguid = m.rowguid + "####";
                m.Selling_Price = (string)Accessories_Dg.Rows[e.RowIndex].Cells[3].Value;
                Get_Base(SELECTED_MACHINE).Add_Accessory(m);
            }
            else
            {
                Get_Base(SELECTED_MACHINE).Remove_Accessory(temp);
            }
            Retrieve_Leasing_Company();
        }

        private void Base_Machine_Dg_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                Machine m = Get_Base(SELECTED_MACHINE);
                m.Selling_Price = (string)Base_Machine_Dg.Rows[e.RowIndex].Cells[2].Value;
                m.Model_Cost = (string)Base_Machine_Dg.Rows[e.RowIndex].Cells[3].Value;
                m.Print_Model_Pricing = (bool)Base_Machine_Dg.Rows[e.RowIndex].Cells[4].Value;
                Retrieve_Leasing_Company();
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private void Accessories_Dg_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            Accessories_Dg.CommitEdit(DataGridViewDataErrorContexts.Commit);
        }

        private void Base_Machine_Dg_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            Base_Machine_Dg.CommitEdit(DataGridViewDataErrorContexts.Commit);
        }

        private void Base_Machine_Dg_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                Machine m = Get_Base(SELECTED_MACHINE);
                m.Selling_Price = (string)Base_Machine_Dg.Rows[e.RowIndex].Cells[3].Value;
                m.Model_Cost = (string)Base_Machine_Dg.Rows[e.RowIndex].Cells[4].Value;
                m.Print_Model_Pricing = (bool)Base_Machine_Dg.Rows[e.RowIndex].Cells[5].Value;
                Retrieve_Leasing_Company();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private void Setup_Leasing_Companies()
        {
            Leasing_Company_Cb.Items.Clear();
            foreach (LeasingCompany l in DataStore.Get_Leasing_Companies())
            {
                Leasing_Company_Cb.Items.Add(l.Name);
            }
        }

        private void AutoComplete()
        {
            County_Tb.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            County_Tb.AutoCompleteSource = AutoCompleteSource.CustomSource;
            County_Tb.AutoCompleteCustomSource = Process.Generate_Counties_Auto_Complet();

            County_1_Tb.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            County_1_Tb.AutoCompleteSource = AutoCompleteSource.CustomSource;
            County_1_Tb.AutoCompleteCustomSource = County_Tb.AutoCompleteCustomSource;

            Base_Machine_Tb.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            Base_Machine_Tb.AutoCompleteSource = AutoCompleteSource.CustomSource;
            Base_Machine_Tb.AutoCompleteCustomSource = Process.Generate_Machine_Numbers_Auto_Complet("BASE_MACHINE");
        }

        private void Cb_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton c = (RadioButton)sender;
            if (c.Checked)
            {
                foreach (DataGridViewRow r in Accessories_Dg.Rows)
                {
                    if (((string)r.Cells[6].Value).ToUpper().Equals((string)c.Tag))
                    {
                        Accessories_Dg.Rows.Insert(0, r.Cells[0].Value, r.Cells[1].Value, r.Cells[2].Value, r.Cells[3].Value, r.Cells[4].Value, r.Cells[5].Value, r.Cells[6].Value);
                        Accessories_Dg.Rows.Remove(r);
                    }
                }

                foreach (DataGridViewRow r in Accessories_Dg.Rows)
                {
                    if ((bool)r.Cells[4].Value)
                    {
                        Accessories_Dg.Rows.Insert(0, r.Cells[0].Value, r.Cells[1].Value, r.Cells[2].Value, r.Cells[3].Value, r.Cells[4].Value, r.Cells[5].Value, r.Cells[6].Value);
                        Accessories_Dg.Rows.Remove(r);
                    }
                }
            }
            Color_DataGrid(Accessories_Dg);
            Refresh();
        }

        private void Base_Machine_Dg_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                // Draw Machines
                if (e.RowIndex == -1)
                {
                    return;
                }
                if (e.ColumnIndex == Base_Machine_Dg.Columns["Delete_Col"].Index)
                {
                    QUOTE.Get_Machines().Remove(Get_Base(SELECTED_MACHINE));
                    Draw_Machines();
                    if (Base_Machine_Dg.Rows.Count <= 0)
                    {
                        Accessories_Dg.Rows.Clear();
                    }
                }
                SELECTED_MACHINE = Base_Machine_Dg.Rows[e.RowIndex].Cells[0].Value.ToString();
                Base_Machine_Lb.Text = Base_Machine_Dg.Rows[e.RowIndex].Cells[2].Value.ToString();
                Draw_Accessories();
                Retrieve_Leasing_Company();
            } catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private float Calculate_Total_Cost()
        {
            try
            {
                float cost = 0;
                foreach (Machine m in QUOTE.Get_Machines())
                {
                    cost += float.Parse(m.Selling_Price);
                    foreach(Machine ma in m.Get_Accessories())
                    {
                        if (!ma.rowguid.Contains("####"))
                        {
                            cost += float.Parse(ma.Selling_Price);
                        }
                    }
                }
                return cost;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return 0;
            }
        }

        private Machine search_Helper(List<Machine> list, string rowguid)
        {
            foreach(Machine m in list)
            {
                if (m.rowguid.Contains(rowguid))
                {
                    return m;
                }
            }
            return null;
        }

        private void Draw_Accessories()
        {
            Machine ma = Get_Base(SELECTED_MACHINE);
            DataStore.Retrieve_Accessories_2_STR(ma.Item_Number);
            Base_Machine_Lb.Text = ma.Item_Number;
            Accessories_Dg.Rows.Clear();
            foreach (Machine m in DataStore.Get_Search_Machines())
            {
                var tmp = search_Helper(ma.Get_Accessories(), m.rowguid);
                if(tmp == null)
                {
                    Accessories_Dg.Rows.Add(m.rowguid, m.Item_Number, m.Description, m.Selling_Price, false, false, m.Category);
                }
                else
                {
                    if (tmp.rowguid.Contains("####"))
                    {
                        Accessories_Dg.Rows.Add(tmp.rowguid, tmp.Item_Number, tmp.Description, tmp.Selling_Price, false, true, tmp.Category);
                    }
                    else
                    {
                        Accessories_Dg.Rows.Add(tmp.rowguid, tmp.Item_Number, tmp.Description, tmp.Selling_Price, true, false, tmp.Category);
                    }
                }
            }
            foreach (DataGridViewRow r in Accessories_Dg.Rows)
            {
                if ((bool)r.Cells[4].Value)
                {
                    Accessories_Dg.Rows.Insert(0, r.Cells[0].Value, r.Cells[1].Value, r.Cells[2].Value, r.Cells[3].Value, r.Cells[4].Value, r.Cells[5].Value, r.Cells[6].Value);
                    Accessories_Dg.Rows.Remove(r);
                }
            }
            Color_DataGrid(Accessories_Dg);
        }

        private void Deselect()
        {
            foreach (DataGridViewRow row in Accessories_Dg.Rows)
            {
                row.Cells[2].Value = false;
            }
        }

        private Machine Get_Base(string rowguid)
        {
            try
            {
                foreach (Machine m in QUOTE.Get_Machines())
                {
                    if (m.rowguid.Equals(rowguid))
                    {
                        return m;
                    }
                }
            }catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return null;
        }

        public Machine Get_Acc(string rowguid, string rowguid_)
        {
            try
            {
                foreach (Machine m in Get_Base(rowguid).Get_Accessories())
                {
                    if (m.rowguid.Equals(rowguid_))
                    {
                        return m;
                    }
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return null;
        }

        private void Color_DataGrid(DataGridView dg)
        {
            foreach (DataGridViewRow r in dg.Rows)
            {
                if (((string)r.Cells[6].Value).ToUpper().Equals((string)Accessories_Rb.Tag))
                {
                    r.DefaultCellStyle.BackColor = Accessories_Rb.BackColor;
                }
                else if (((string)r.Cells[6].Value).ToUpper().Equals((string)Console_PFU_Rb.Tag))
                {
                    r.DefaultCellStyle.BackColor = Console_PFU_Rb.BackColor;
                }
                else if (((string)r.Cells[6].Value).ToUpper().Equals((string)Digital_Acc_Rb.Tag))
                {
                    r.DefaultCellStyle.BackColor = Digital_Acc_Rb.BackColor;
                }
                else if (((string)r.Cells[6].Value).ToUpper().Equals((string)Fax_Option_Rb.Tag))
                {
                    r.DefaultCellStyle.BackColor = Fax_Option_Rb.BackColor;
                }
                else if (((string)r.Cells[6].Value).ToUpper().Equals((string)Misc_Rb.Tag))
                {
                    r.DefaultCellStyle.BackColor = Misc_Rb.BackColor;
                }
                else if (((string)r.Cells[6].Value).ToUpper().Equals((string)Printer_Options_Rb.Tag))
                {
                    r.DefaultCellStyle.BackColor = Printer_Options_Rb.BackColor;
                }

                if (((bool)r.Cells[4].Value))
                {
                    r.DefaultCellStyle.BackColor = Color.DimGray;
                }
            }
        }

        private void Rb_CheckedChanged_2(object sender, EventArgs e)
        {
            RadioButton rb = (RadioButton)sender;
            if (rb.Checked)
            {
                QUOTE.Lease_Type = (string)rb.Tag;
            }

            if (!string.IsNullOrWhiteSpace(Leasing_Company_Cb.Text))
            {
                Retrieve_Leasing_Company();
            }
        }

        private void Leasing_Company_Cb_SelectedIndexChanged(object sender, EventArgs e)
        {
            Retrieve_Leasing_Company();
        }

        private void Retrieve_Leasing_Company()
        {
            float total = Calculate_Total_Cost();
            Total_Cost_M_Tb.Text = total.ToString("0.00");
            Sell_Cost_Tb.Text = total.ToString("0.00");
            foreach (LeasingCompany l in DataStore.Get_Leasing_Companies())
            {
                if (l.Name.ToUpper().Equals(Leasing_Company_Cb.Text.ToUpper()))
                {
                    if (FMV_Rb.Checked)
                    {
                        if (!Rate_1_Tb.Text.Equals("0"))
                        {
                            Rate_1_Tb.Text = l.FMV_24_Rate;
                        }
                        if (!Rate_2_Tb.Text.Equals("0"))
                        {
                            Rate_2_Tb.Text = l.FMV_36_Rate;
                        }
                        if (!Rate_3_Tb.Text.Equals("0"))
                        {
                            Rate_3_Tb.Text = l.FMV_48_Rate;
                        }
                        if (!Rate_4_Tb.Text.Equals("0"))
                        {
                            Rate_4_Tb.Text = l.FMV_60_Rate;
                        }

                        Payment_1_Tb.Text = Multiply(l.FMV_24_Rate, total);
                        Payment_2_Tb.Text = Multiply(l.FMV_36_Rate, total);
                        Payment_3_Tb.Text = Multiply(l.FMV_48_Rate, total);
                        Payment_4_Tb.Text = Multiply(l.FMV_60_Rate, total);
                    }
                    else
                    {
                        if (!Rate_1_Tb.Text.Equals("0"))
                        {
                            Rate_1_Tb.Text = l.Dollar_24_Rate;
                        }
                        if (!Rate_2_Tb.Text.Equals("0"))
                        {
                            Rate_2_Tb.Text = l.Dollar_36_Rate;
                        }
                        if (!Rate_3_Tb.Text.Equals("0"))
                        {
                            Rate_3_Tb.Text = l.Dollar_48_Rate;
                        }
                        if (!Rate_4_Tb.Text.Equals("0"))
                        {
                            Rate_4_Tb.Text = l.Dollar_60_Rate;
                        }

                        Payment_1_Tb.Text = Multiply(l.Dollar_24_Rate, total);
                        Payment_2_Tb.Text = Multiply(l.Dollar_36_Rate, total);
                        Payment_3_Tb.Text = Multiply(l.Dollar_48_Rate, total);
                        Payment_4_Tb.Text = Multiply(l.Dollar_60_Rate, total);
                    }
                }
            }
        }

        private string Multiply(string v1, float v2)
        {
            float v1_f = float.Parse(v1);
            return (v1_f * v2).ToString("0.00");
        }

        private void Rb_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton rb = (RadioButton)sender;
            if (rb.Checked)
            {
                QUOTE.Maint_Type = (string)rb.Tag;
            }
        }

        private void County_1_Tb_GotFocus(object sender, EventArgs e)
        {
            County_1_Tb.LostFocus += County_Tb_LostFocus;
            County_1_Tb.KeyDown += County_Tb_KeyDown;
        }

        private void County_Tb_GotFocus(object sender, EventArgs e)
        {
            County_Tb.LostFocus += County_Tb_LostFocus;
            County_Tb.KeyDown += County_Tb_KeyDown;
        }

        private void Addtl_Info_Tb_LostFocus(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(Addtl_Info_Tb.Text))
            {
                QUOTE.Addt_Info = Addtl_Info_Tb.Text;
            }
        }

        private void Maint_Cost_Tb_LostFocus(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(Maint_Cost_Tb.Text))
            {
                QUOTE.Maint_Total_Cost = Maint_Cost_Tb.Text;
            }
        }

        private void Color_Excess_Tb_LostFocus(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(Color_Excess_Tb.Text))
            {
                QUOTE.Color_Excess = Color_Excess_Tb.Text;
            }
        }

        private void Color_Tb_LostFocus(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(Color_Tb.Text))
            {
                QUOTE.Color = Color_Tb.Text;
            }
        }

        private void BW_Excess_Tb_LostFocus(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(BW_Excess_Tb.Text))
            {
                QUOTE.BW_Excess = BW_Excess_Tb.Text;
            }
        }

        private void Man_Rebate_Tb_LostFocus(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(Man_Rebate_Tb.Text))
            {
                QUOTE.Man_Rebate = Man_Rebate_Tb.Text;
            }
        }

        private void BW_Tb_LostFocus(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(BW_Tb.Text))
            {
                QUOTE.BW = BW_Tb.Text;
            }
        }

        private void Addtl_Lease_Fees_Tb_LostFocus(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(Addtl_Lease_Fees_Tb.Text))
            {
                QUOTE.Less_Disc_Trade = Addtl_Lease_Fees_Tb.Text;
            }
        }

        private void Less_Disc_Trade_Tb_LostFocus(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(Less_Disc_Trade_Tb.Text))
            {
                QUOTE.Less_Disc_Trade = Less_Disc_Trade_Tb.Text;
            }
        }

        private void County_Tb_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                County_Tb_LostFocus(sender, e);
            }
        }

        private void County_Tb_LostFocus(object sender, EventArgs e)
        {
            TextBox tb = (TextBox)sender;
            tb.Text = tb.Text.ToUpper();
            if (DataStore.Get_Counties_Dict().ContainsKey(tb.Text))
            {
                State_Tb.Text = DataStore.Get_Counties_Dict()[tb.Text];
            }
            else
            {
                tb.Text = "";
                State_Tb.Text = "";
            }
        }

        private void Base_Machine_Tb_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                Base_Machine_Helper();
            }
        }

        private void Base_Machine_Helper()
        {
            if (!string.IsNullOrEmpty(Base_Machine_Tb.Text) && DataStore.Get_Base_Machine_Dictionary().ContainsKey(Base_Machine_Tb.Text))
            {
                int machine_number = DataStore.Get_Base_Machine_Dictionary()[Base_Machine_Tb.Text];
                Machine m = DataStore.Get_Machine_Number_wo_Acc_REST(machine_number.ToString());
                m.rowguid = Guid.NewGuid().ToString();
                QUOTE.Quote_Add_Machine(m);
                Draw_Machines();
                Retrieve_Leasing_Company();
            }
            Base_Machine_Tb.Text = "";
        }

        private void Mouse_Down(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }

        private void Minimize_Bt_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void Items_Bt_Click(object sender, EventArgs e)
        {
            FrmMachine frm = new FrmMachine
            {
                StartPosition = FormStartPosition.CenterScreen
            };
            frm.ShowDialog();
        }

        private void Close_Bt_Click(object sender, EventArgs e)
        {
            // Delete if New Quote
            if (QUOTE.rowguid == null)
            {
                DataStore.Delete_Quote_REST(QUOTE);
            }
            Terminate_Quote();
        }

        private void Terminate_Quote()
        {
            Close();
        }

        private void Adddress_Lease_Accordion_Bt_Click(object sender, EventArgs e)
        {
            Process.Accordion(sender, e, Address_Pn);
        }

        private void Complete_Bt_Click(object sender, EventArgs e)
        {
            // Update Quote
            //Save_Quote_To_Helper();
            Save_Install_Location_Helper();
            QUOTE.Org_Number = ORG.Organization_Number;
            QUOTE.Contact_Number = CONTACT.Contact_Number;
            QUOTE.Org_Name = ORG.Name;
            QUOTE.Contact_Name = CONTACT.GetContact_Name();
            QUOTE.Man_Rebate = Man_Rebate_Tb.Text;
            QUOTE.Less_Disc_Trade = Less_Disc_Trade_Tb.Text;
            QUOTE.Addt_Lease_Fees = Addtl_Lease_Fees_Tb.Text;
            QUOTE.BW = BW_Tb.Text;
            QUOTE.BW_Excess = BW_Excess_Tb.Text;
            QUOTE.Color = Color_Tb.Text;
            QUOTE.Color_Excess = Color_Excess_Tb.Text;
            QUOTE.Terms = Billed_Terms_Cb.Text;
            QUOTE.Maint_Type = Get_Maint_Type();
            QUOTE.Maint_Total_Cost = Maint_Cost_Tb.Text;
            QUOTE.Leasing_Company = Leasing_Company_Cb.Text;
            QUOTE.Lease_Fees = Sell_Cost_Tb.Text;
            QUOTE.Lease_Type = Get_Lease_Type();
            QUOTE.Month_1 = Month_1_Tb.Text;
            QUOTE.Month_2 = Month_2_Tb.Text;
            QUOTE.Month_3 = Month_3_Tb.Text;
            QUOTE.Month_4 = Months_4_Tb.Text;
            QUOTE.Lease_Rate_1 = Rate_1_Tb.Text;
            QUOTE.Lease_Rate_2 = Rate_2_Tb.Text;
            QUOTE.Lease_Rate_3 = Rate_3_Tb.Text;
            QUOTE.Lease_Rate_4 = Rate_4_Tb.Text;
            QUOTE.Payment_1 = Payment_1_Tb.Text;
            QUOTE.Payment_2 = Payment_2_Tb.Text;
            QUOTE.Payment_3 = Payment_3_Tb.Text;
            QUOTE.Payment_4 = Payment_4_Tb.Text;
            QUOTE.Addt_Info = Addtl_Info_Tb.Text;
            QUOTE.Salesman_Initials = DataStore.Get_LOGGED_USER().Initials;

            // Save Quote
            DataStore.Update_Quote_REST(QUOTE);
            QUOTE.rowguid = Guid.NewGuid().ToString();

            // Update Quote Details
            DataStore.Clear_Quote_REST(QUOTE);

            foreach (Machine m in QUOTE.Get_Machines())
            {
                DataStore.Add_Quote_Base_REST_(QUOTE, m);
                foreach (Machine ma in m.Get_Accessories())
                {
                    DataStore.Add_Quote_Base_Detail_REST_(QUOTE, m, ma);
                }
            }

            // Open Process Form
            Visible = false;
            FrmProcess_Quote frm = new FrmProcess_Quote(QUOTE);
            frm.ShowDialog();
            Visible = true;

        }

        private void Lease_Bt_Click(object sender, EventArgs e)
        {
            FrmLease frm = new FrmLease
            {
                StartPosition = FormStartPosition.CenterScreen
            };
            frm.FormClosed += Frm_FormClosed;
            frm.ShowDialog();
        }

        private void Frm_FormClosed(object sender, FormClosedEventArgs e)
        {
            string temp = Leasing_Company_Cb.Text;
            Setup_Leasing_Companies();
            Leasing_Company_Cb.Text = temp;
        }

        private void Copy_Bt_Click(object sender, EventArgs e)
        {
            Copy_Bt_Helper();
        }

        private void Copy_Bt_Helper()
        {
            // Check Textboxes
            if (string.IsNullOrWhiteSpace(Name_Tb.Text) || Name_Tb.Text.Equals((string)Name_Tb.Tag)
                || string.IsNullOrWhiteSpace(Phone_Tb.Text) || Phone_Tb.Text.Equals((string)Phone_Tb.Tag)
                || string.IsNullOrWhiteSpace(Addr1_Tb.Text) || Addr1_Tb.Text.Equals((string)Addr1_Tb.Tag)
                || string.IsNullOrWhiteSpace(City_Tb.Text) || City_Tb.Text.Equals((string)City_Tb.Tag)
                || string.IsNullOrWhiteSpace(State_Tb.Text) || State_Tb.Text.Equals((string)State_Tb.Tag)
                || string.IsNullOrWhiteSpace(Zip_Tb.Text) || Zip_Tb.Text.Equals((string)Zip_Tb.Tag))
            {
                return;
            }

            // Create a location object
            Location loc = new Location()
            {
                rowguid = Guid.NewGuid().ToString(),
                Name = Name_Tb.Text,
                Phone = Phone_Tb.Text,
                Addr_1 = Addr1_Tb.Text,
                Addr_2 = Addr2_Tb.Text,
                City = City_Tb.Text,
                County = County_Tb.Text,
                State = State_Tb.Text,
                Zip = Zip_Tb.Text,
            };

            // Copy "QUOTE TO" -> "Install Location"
            Name_1_Tb.Text = loc.Name;
            Phone_1_Tb.Text = loc.Phone;
            Addr1_1_Tb.Text = loc.Addr_1;
            Addr2_1_Tb.Text = loc.Addr_2;
            City_1_Tb.Text = loc.City;
            County_1_Tb.Text = loc.County;
            State_1_Tb.Text = loc.State;
            Zip_1_Tb.Text = loc.State;

            Refresh();
        }

        private void Quote_Accordion_Bt_Click(object sender, EventArgs e)
        {
            Process.Accordion(sender, e, Quote_Pn);
        }

        private void Machines_Accordion_Bt_Click(object sender, EventArgs e)
        {
            Process.Accordion(sender, e, Machine_Pn);
        }

        private void Less_Discount_Accordion_Bt_Click_2(object sender, EventArgs e)
        {
            Process.Accordion(sender, e, Less_Discount_Pn);
        }

        private void Maintenance_Accordion_Bt_Click_2(object sender, EventArgs e)
        {
            Process.Accordion(sender, e, Maintenance_Pn);
        }

        private void Lease_Accordion_Bt_Click_2(object sender, EventArgs e)
        {
            Process.Accordion(sender, e, Lease_Accordion_Pn);
        }

        private void Addition_Info_Accordion_Bt_Click_2(object sender, EventArgs e)
        {
            Process.Accordion(sender, e, Addition_Info_Pn);
        }

        private void Clear_Accessory_Bt_Click(object sender, EventArgs e)
        {
            Deselect();
        }

        private void Re_Cal_Bt_Click(object sender, EventArgs e)
        {


        }

        private void Add_Base_Machine_Bt_Click(object sender, EventArgs e)
        {
            Base_Machine_Helper();
        }

        private void Save_Quote_To_Bt_Click(object sender, EventArgs e)
        {
            Save_Quote_To_Helper();
        }

        private void Save_Quote_To_Helper()
        {
            // Create a location object
            Location loc = new Location()
            {
                rowguid = Guid.NewGuid().ToString(),
                Name = Name_Tb.Text,
                Phone = Phone_Tb.Text,
                Addr_1 = Addr1_Tb.Text,
                Addr_2 = Addr2_Tb.Text,
                City = City_Tb.Text,
                County = County_Tb.Text,
                State = State_Tb.Text,
                Zip = Zip_Tb.Text,
            };
            // Add Quote to location
            QUOTE.Set_Quote_To_Location(loc);
        }

        private void Save_Install_Location_Tb_Click(object sender, EventArgs e)
        {
            Save_Install_Location_Helper();
        }

        private void Save_Install_Location_Helper()
        {
            // Create a location object
            Location loc = new Location()
            {
                rowguid = Guid.NewGuid().ToString(),
                Name = Name_1_Tb.Text,
                Phone = Phone_1_Tb.Text,
                Addr_1 = Addr1_1_Tb.Text,
                Addr_2 = Addr2_1_Tb.Text,
                City = City_1_Tb.Text,
                County = County_1_Tb.Text,
                State = State_1_Tb.Text,
                Zip = Zip_1_Tb.Text,
            };

            // Add Install location to QUOTE
            QUOTE.Set_Install_Location(loc);
        }

        private void Clear_Bt_Click(object sender, EventArgs e)
        {
            AutoComplete();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void Reset_Cal_Bt_Click(object sender, EventArgs e)
        {
            Retrieve_Leasing_Company();
        }

        private void Append_St_Com_Bt_Click(object sender, EventArgs e)
        {
            foreach(Machine m in QUOTE.Get_Machines())
            {
                Addtl_Info_Tb.Text += m.St_Addt_Comments;
            }
        }
    }
}
