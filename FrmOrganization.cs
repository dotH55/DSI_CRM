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
    internal partial class FrmOrganization : Form
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

        [DllImport("user32.dll", CharSet = CharSet.Unicode)]
        public static extern int MessageBox(IntPtr hWnd, string text, string caption, uint type);

        private Organization ORG;
        //private Record_Org RECORD_ORD;
        private List<Address> NEW_ADDRESSES;
        private List<Tag> SELECTED_TAGS;
        private DateTimePicker DTP;

        public FrmOrganization(Organization org)
        {
            InitializeComponent();
            Init_Page();

            ORG = org;
            Populate_Fields(ORG);
            Update_Bt.Visible = true;

            Lease_Dg.Columns[1].DefaultCellStyle.Format = "dd/MM/yyyy";
        }

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);

            Auto_Complete();
            Reset_Tags();
            Draw_Lease();
        }

        private void Auto_Complete()
        {
            Tag_Tb.AutoCompleteMode = AutoCompleteMode.Suggest;
            Tag_Tb.AutoCompleteSource = AutoCompleteSource.CustomSource;
            Tag_Tb.AutoCompleteCustomSource = Process.Generate_Tags_Auto_Complet();

            // Auto Complet Text
            County_Tb.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            County_Tb.AutoCompleteSource = AutoCompleteSource.CustomSource;
            County_Tb.AutoCompleteCustomSource = Process.Generate_Counties_Auto_Complet();
        }

        private void Init_Page()
        {
            FormBorderStyle = FormBorderStyle.None;
            Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 20, 20));
            if (DataStore.Get_Theme_CONFIG())
            {
                Top_Pn.BackColor = DataStore.Get_CONFIG_Theme_Color();
                Organization_Pn.BackColor = DataStore.Get_CONFIG_Theme_Color();
                Tags_Pn.BackColor = DataStore.Get_CONFIG_Theme_Color();
                Address_Lease_Accordion.BackColor = DataStore.Get_CONFIG_Theme_Color();
                Lease_Acc_Pn.BackColor = DataStore.Get_CONFIG_Theme_Color();
                //Organization_Pn.BackColor = Color.DimGray;
            }

            Top_Pn.MouseDown += Mouse_Down;

            Name_1_Tb.GotFocus += Process.TB_Got_Focus;
            Name_1_Tb.LostFocus += Process.TB_Lost_Focus;

            Description_Tb.GotFocus += Process.TB_Got_Focus;
            Description_Tb.LostFocus += Process.TB_Lost_Focus;

            Phone_1_Tb.GotFocus += Process.TB_Got_Focus;
            Phone_1_Tb.LostFocus += Process.TB_Lost_Focus;

            Fax_Tb.GotFocus += Process.TB_Got_Focus;
            Fax_Tb.LostFocus += Process.TB_Lost_Focus;

            Website_Tb.GotFocus += Process.TB_Got_Focus;
            Website_Tb.LostFocus += Process.TB_Lost_Focus;

            Dsi_Customer_number_Tb.GotFocus += Process.TB_Got_Focus;
            Dsi_Customer_number_Tb.LostFocus += Process.TB_Lost_Focus;

            Addr_1_Tb.GotFocus += Process.TB_Got_Focus;
            Addr_1_Tb.LostFocus += Process.TB_Lost_Focus;

            Addr_2_Tb.GotFocus += Process.TB_Got_Focus;
            Addr_2_Tb.LostFocus += Process.TB_Lost_Focus;

            City_Tb.GotFocus += Process.TB_Got_Focus;
            City_Tb.LostFocus += Process.TB_Lost_Focus;

            State_Tb.GotFocus += Process.TB_Got_Focus;
            State_Tb.LostFocus += Process.TB_Lost_Focus;

            Zip_Tb.GotFocus += Process.TB_Got_Focus;
            Zip_Tb.LostFocus += Process.TB_Lost_Focus;

            County_Tb.GotFocus += Process.TB_Got_Focus;
            County_Tb.LostFocus += County_Tb_LostFocus;
            County_Tb.KeyDown += County_Tb_KeyDown;

            Addr_Clb.Click += Addr_Clb_Click;

            Tag_Tb.KeyDown += Tag_Tb_KeyDown;

            Address_Pn.Click += Address_Pn_Click;

            Lease_Dg.CellClick += dataGridView1_CellClick;

            NEW_ADDRESSES = new List<Address>();
            SELECTED_TAGS = new List<Tag>();
            ORG = new Organization();
            //RECORD_ORD = null;
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

        private void Addr_Clb_Click(object sender, EventArgs e)
        {
            foreach (object i in Addr_Clb.CheckedItems)
            {
                foreach (Address a in ORG.GetAddresses())
                {
                    if (a.To_String().Equals((string)i))
                    {
                        Addr_1_Tb.Text = a.Address_1;
                        Addr_2_Tb.Text = a.Address_2;
                        City_Tb.Text = a.City;
                        State_Tb.Text = a.State;
                        Zip_Tb.Text = a.Zip;
                        County_Tb.Text = a.County;
                        Edit_Addr_Bt.Visible = true;
                    }
                }
            }
            Refresh();
            Refresh();
            Addr_Clb_Helper();
        }

        private void Addr_Clb_Helper()
        {
            foreach (object i in Addr_Clb.CheckedItems)
            {
                foreach (Address a in ORG.GetAddresses())
                {
                    if (a.To_String().Equals((string)i))
                    {
                        Addr_1_Tb.Text = a.Address_1;
                        Addr_2_Tb.Text = a.Address_2;
                        City_Tb.Text = a.City;
                        State_Tb.Text = a.State;
                        Zip_Tb.Text = a.Zip;
                        County_Tb.Text = a.County;
                        Edit_Addr_Bt.Visible = true;
                    }
                }
            }
            Refresh();
            Refresh();
        }

        private void Address_Pn_Click(object sender, EventArgs e)
        {
            Edit_Addr_Bt.Visible = false;
            Draw_Addr(ORG);
        }

        private void Tag_Tb_KeyDown(object sender, KeyEventArgs e)
        {
            TextBox tb = (TextBox)sender;
            string tmp = tb.Text.ToUpper();
            if (e.KeyCode == Keys.Enter && DataStore.Get_Tags_Dict().ContainsKey(tmp) && !Contains(Selected_Tags_Pn, DataStore.Get_Tags_Dict()[tmp]))
            {
                LinkLabel lb = new LinkLabel
                {
                    Text = tmp,
                    Tag = DataStore.Get_Tags_Dict()[tmp],
                    BorderStyle = BorderStyle.FixedSingle
                };
                lb.LinkClicked += Lb_LinkClicked;
                lb.AutoSize = true;
                Selected_Tags_Pn.Controls.Add(lb);
                tb.Text = "";
            }

        }

        private bool Contains(FlowLayoutPanel flp, string tag)
        {
            foreach (Control c in flp.Controls)
            {
                if (tag.Equals((string)c.Tag))
                {
                    return true;
                }
            }
            return false;
        }


        // Delete Tag
        private void Lb_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                LinkLabel lb = (LinkLabel)sender;
                Selected_Tags_Pn.Controls.Remove(lb);
                Console.WriteLine("DEL: " + lb.Text + " #: " + (string)lb.Tag);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.StackTrace);
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

        private void Populate_Fields(Organization org)
        {
            if (!string.IsNullOrWhiteSpace(org.Name))
            {
                Name_1_Tb.Text = org.Name;
            }
            if (!string.IsNullOrWhiteSpace(org.Notes))
            {
                Description_Tb.Text = org.Notes;
            }
            if (!string.IsNullOrWhiteSpace(org.Phone))
            {
                Phone_1_Tb.Text = org.Phone;
            }
            if (!string.IsNullOrWhiteSpace(org.Fax))
            {
                Fax_Tb.Text = org.Fax;
            }
            if (!string.IsNullOrWhiteSpace(org.Website))
            {
                Website_Tb.Text = org.Website;
            }
            if (!string.IsNullOrWhiteSpace(org.DSI_Customer_Number))
            {
                Dsi_Customer_number_Tb.Text = org.DSI_Customer_Number;
            }

            Draw_Addr(org);
        }

        private void Draw_Addr(Organization org)
        {
            if (org.hasAddr())
            {
                // Clear
                Addr_Clb.Items.Clear();
                foreach (Address addr in org.GetAddresses())
                {
                    Addr_Clb.Items.Add(addr.Address_1 + " " + addr.Address_2 + " " + addr.City + " " + addr.State + " " + addr.Zip + " " + addr.County, false);
                }
            }
            Clear_Address_Tb();
        }

        private void Org_Accordion_Bt_Click(object sender, EventArgs e)
        {
            Process.Accordion(sender, e, Org_Pn);
        }

        private void Tag_Accordion_Bt_Click(object sender, EventArgs e)
        {
            Process.Accordion(sender, e, Tags_Accordion_Pn);
        }

        private void Adddress_Lease_Accordion_Bt_Click(object sender, EventArgs e)
        {
            Process.Accordion(sender, e, Address_Pn);
        }

        private void Lease_Accordion_Pn_Click(object sender, EventArgs e)
        {
            Process.Accordion(sender, e, Lease_Pn);
        }


        private void Add_Addr_Bt_Click(object sender, EventArgs e)
        {
            if (!Addr_1_Tb.Text.Equals((string)Addr_1_Tb.Tag) && !string.IsNullOrWhiteSpace(Addr_1_Tb.Text)
                && !City_Tb.Text.Equals((string)City_Tb.Tag) && !string.IsNullOrWhiteSpace(City_Tb.Text)
                && !State_Tb.Text.Equals((string)State_Tb.Tag) && !string.IsNullOrWhiteSpace(State_Tb.Text)
                && !Zip_Tb.Text.Equals((string)Zip_Tb.Tag) && !string.IsNullOrWhiteSpace(Zip_Tb.Text)
                && !County_Tb.Text.Equals((string)County_Tb.Tag) && !string.IsNullOrWhiteSpace(County_Tb.Text))
            {
                string addr_2 = "";
                if (!Addr_2_Tb.Text.Equals((string)Addr_2_Tb.Tag))
                {
                    addr_2 = Addr_2_Tb.Text;
                }
                NEW_ADDRESSES.Add(new Address(Addr_1_Tb.Text, addr_2, City_Tb.Text, State_Tb.Text, Zip_Tb.Text, County_Tb.Text));
                Addr_Clb.Items.Add(Addr_1_Tb.Text + " " + addr_2 + " " + City_Tb.Text + " " + State_Tb.Text + " " + Zip_Tb.Text + " " + County_Tb.Text, false);
                Clear_Address_Tb();
            }
        }

        private void Clear_Address_Tb()
        {
            Addr_1_Tb.Text = (string)Addr_1_Tb.Tag;
            Addr_2_Tb.Text = (string)Addr_2_Tb.Tag;
            City_Tb.Text = (string)City_Tb.Tag;
            State_Tb.Text = (string)State_Tb.Tag;
            Zip_Tb.Text = (string)Zip_Tb.Tag;
            County_Tb.Text = (string)County_Tb.Tag;
        }

        private void Reset_Tag_Bt_Click(object sender, EventArgs e)
        {
            Reset_Tags();
        }

        private void Reset_Tags()
        {
            Selected_Tags_Pn.Controls.Clear();
            foreach (string s in ORG.Get_Tags_Str())
            {
                LinkLabel lb = new LinkLabel
                {
                    Text = s,
                    Tag = DataStore.Get_Tags_Dict()[s],
                    BorderStyle = BorderStyle.FixedSingle
                };
                lb.LinkClicked += Lb_LinkClicked;
                lb.AutoSize = true;
                Selected_Tags_Pn.Controls.Add(lb);
            }
        }

        private void Update_Bt_Click(object sender, EventArgs e)
        {
            Update_Bt_Helper();
        }

        private void Update_Bt_Helper()
        {
            // Update Info
            if (Name_1_Tb.Text.Equals((string)Name_1_Tb.Tag) || Phone_1_Tb.Text.Equals((string)Phone_1_Tb.Tag)
                || string.IsNullOrWhiteSpace(Name_1_Tb.Text) || string.IsNullOrWhiteSpace(Phone_1_Tb.Text))
            {
                Name_Lb.ForeColor = Color.Crimson;
                Phone_Lb.ForeColor = Color.Crimson;
                Process.Display_Alert("Error: First Name & Phone Missing", true);
                return;
            }
            else
            {
                ORG.Name = Name_1_Tb.Text;
                if (ORG.Name.Contains("&"))
                {
                    ORG.Name = ORG.Name.Replace("&", "%26");
                }
                ORG.Phone = Phone_1_Tb.Text;
            }

            if (!Description_Tb.Text.Equals((string)Description_Tb.Tag) && !string.IsNullOrWhiteSpace(Description_Tb.Text))
            {
                ORG.Notes = Description_Tb.Text;
                if (ORG.Notes.Contains("&"))
                {
                    ORG.Notes.Replace("&", "%26");
                }
            }

            if (!Fax_Tb.Text.Equals((string)Fax_Tb.Tag) && !string.IsNullOrWhiteSpace(Fax_Tb.Text))
            {
                ORG.Fax = Fax_Tb.Text;
            }

            if (!Website_Tb.Text.Equals((string)Website_Tb.Tag) && !string.IsNullOrWhiteSpace(Website_Tb.Text))
            {
                ORG.Website = Website_Tb.Text;
            }

            if (!Dsi_Customer_number_Tb.Text.Equals((string)Dsi_Customer_number_Tb.Tag) && !string.IsNullOrWhiteSpace(Dsi_Customer_number_Tb.Text))
            {
                ORG.DSI_Customer_Number = Dsi_Customer_number_Tb.Text;
            }

            // Update ORG Info
            DataStore.Update_Org_REST(ORG);
            // Clear Tags
            DataStore.Org_Detach_Tags_REST(ORG);
            // Update Tags
            foreach (Control c in Selected_Tags_Pn.Controls)
            {
                DataStore.Org_Attach_Tag_REST(ORG, (string)c.Tag);
            }

            // Update Addresses
            foreach (Address a in NEW_ADDRESSES)
            {
                DataStore.Create_Addr_Rest(ORG, new Contact(), a);
            }

            // Update Lease
            Update_Lease();

            // Preset FrmMain
            DataStore.Clear_ORGS();
            DataStore.Add_ORGS(DataStore.Get_ORG_REST(ORG.Organization_Number));
            Close();
        }

        private void Close_Bt_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void Clear_Bt_Click(object sender, EventArgs e)
        {
            Selected_Tags_Pn.Controls.Clear();
        }

        private void Tags_Bt_Click(object sender, EventArgs e)
        {
            Tag_Tb.AutoCompleteMode = AutoCompleteMode.Suggest;
            Tag_Tb.AutoCompleteSource = AutoCompleteSource.CustomSource;
            Tag_Tb.AutoCompleteCustomSource = Process.Generate_Tags_Auto_Complet();

            using (FrmTags_ form = new FrmTags_(true))
            {
                form.ShowDialog();
                string strs = form.SELECTED_TAGS.ToString();
                if (!string.IsNullOrEmpty(strs))
                {
                    string[] tmp_ = strs.Split('|');
                    Console.WriteLine("TEST: " + strs);

                    foreach (string s in tmp_)
                    {
                        if (!Contains(Selected_Tags_Pn, DataStore.Get_Tags_Dict()[s]))
                        {
                            LinkLabel lb = new LinkLabel
                            {
                                Text = s,
                                Tag = DataStore.Get_Tags_Dict()[s],
                                BorderStyle = BorderStyle.FixedSingle
                            };
                            lb.LinkClicked += Lb_LinkClicked;
                            lb.AutoSize = true;
                            Selected_Tags_Pn.Controls.Add(lb);
                        }
                    }
                }

            }
        }

        public void Draw_Lease()
        {
            Lease_Dg.Rows.Clear();
            foreach (Lease l in ORG.Get_LEASES())
            {
                Lease_Dg.Rows.Add(l.rowguid, l.Lease_Number, l.Provider, l.Equipment, l.Payment, l.Lease_End_Date);
            }
        }

        private void Update_Lease()
        {
            Lease lease = new Lease();
            foreach (DataGridViewRow row in Lease_Dg.Rows)
            {
                if (row.Cells[0].Value != null && row.Cells[2].Value != null)
                {
                    lease = new Lease
                    {
                        rowguid = (string)row.Cells[0].Value,
                        Provider = (string)row.Cells[2].Value,
                        Equipment = (string)row.Cells[3].Value,
                        Payment = (string)row.Cells[4].Value,
                        Lease_End_Date = (string)row.Cells[5].Value
                    };
                    DataStore.Update_Lease_REST(lease);
                    Console.WriteLine("Update: " + lease.Provider);
                }
                else if (row.Cells[2].Value != null)
                {
                    lease = new Lease
                    {
                        Org_Number = ORG.Organization_Number,
                        Provider = (string)row.Cells[2].Value,
                        Equipment = (string)row.Cells[3].Value,
                        Payment = (string)row.Cells[4].Value,
                        Lease_End_Date = (string)row.Cells[5].Value
                    };
                    DataStore.Create_Lease_REST(lease);
                    Console.WriteLine("Create: " + lease.Provider);

                    // TODO: Create a Calendar Entry
                    //DateTime dt = DateTime.ParseExact(lease.Lease_End_Date, "mm/dd/yyyy", CultureInfo.InvariantCulture);
                    // TODO: Check to see if Datetime - 6 months is valid 
                    //Process.Create_Calendar_Entry(dt, lease.Contact_Name + "_LEASE_END", "Name: " + lease.Contact_Name + " Equipment: " + lease.Equipment);
                }
            }
        }

        private void Reset_Lease_Bt_Click(object sender, EventArgs e)
        {
            Draw_Lease();
        }

        private void Top_Pn_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Edit_Addr_Bt_Click(object sender, EventArgs e)
        {
            if (!Addr_1_Tb.Text.Equals((string)Addr_1_Tb.Tag) && !string.IsNullOrWhiteSpace(Addr_1_Tb.Text)
                && !City_Tb.Text.Equals((string)City_Tb.Tag) && !string.IsNullOrWhiteSpace(City_Tb.Text)
                && !State_Tb.Text.Equals((string)State_Tb.Tag) && !string.IsNullOrWhiteSpace(State_Tb.Text)
                && !Zip_Tb.Text.Equals((string)Zip_Tb.Tag) && !string.IsNullOrWhiteSpace(Zip_Tb.Text)
                && !County_Tb.Text.Equals((string)County_Tb.Tag) && !string.IsNullOrWhiteSpace(County_Tb.Text))
            {
                foreach (object i in Addr_Clb.CheckedItems)
                {
                    foreach (Address a in ORG.GetAddresses())
                    {
                        if (a.To_String().Equals((string)i))
                        {
                            a.Address_1 = Addr_1_Tb.Text;
                            a.Address_2 = Addr_2_Tb.Text;
                            a.City = City_Tb.Text;
                            a.State = State_Tb.Text;
                            a.Zip = Zip_Tb.Text;
                            a.County = County_Tb.Text;
                            DataStore.Update_Addr_Rest(a);
                        }
                    }
                }
                Draw_Addr(ORG);
                Edit_Addr_Bt.Visible = false;
            }
        }

        private void Reset_Addr_Bt_Click(object sender, EventArgs e)
        {
            Draw_Addr(ORG);
            Edit_Addr_Bt.Visible = false;
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridView datagrid = (DataGridView)sender;

            // determine if click was on our date column
            if (e.ColumnIndex == 5 && e.RowIndex != -1)
            {
                // initialize DateTimePicker
                DTP = new DateTimePicker
                {
                    Format = DateTimePickerFormat.Short,
                    //string format = DateTimePickerFormat.Short.;
                    //Console.WriteLine("\n\nFormat: " + format);
                    Visible = true
                };
                //DTP.Value = DateTime.Parse((string)dataGridView1.CurrentCell.Value);
                // set size and location
                Rectangle rect = datagrid.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, true);
                DTP.Size = new Size(rect.Width, rect.Height);
                DTP.Location = new Point(rect.X, rect.Y);

                // attach events
                DTP.CloseUp += new EventHandler(dtp_CloseUp);
                DTP.TextChanged += new EventHandler(dtp_OnTextChange);

                datagrid.Controls.Add(DTP);
            }
        }

        // on text change of dtp, assign back to cell
        private void dtp_OnTextChange(object sender, EventArgs e)
        {
            try
            {
                Lease_Dg.CurrentCell.Value = DTP.Text.ToString();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        // on close of cell, hide dtp
        private void dtp_CloseUp(object sender, EventArgs e)
        {
            DTP.Visible = false;

            //try
            //{
            //    string str = (string)Lease_Dg.CurrentCell.Value;
            //    Console.WriteLine("Str: " + str);

            //    var dt = DateTime.ParseExact(str, "mm/dd/yyyy", CultureInfo.InvariantCulture);
            //    var dt_ = DateTime.Now;

            //    DateTimePicker t = new DateTimePicker();
            //    t.Value = dt;

            //    double daysUntil = dt.Subtract(DateTime.Today.Date).TotalDays;
            //    Console.WriteLine("Total Days: " + daysUntil);

            //    //Console.WriteLine("Now: " + dt_.Date.ToString());
            //    //Console.WriteLine("Total Days: " + (dt.Date - dt_.Date).Days);
            //}
            //catch (Exception ex)
            //{
            //    Console.WriteLine(ex.Message);
            //}
        }

        private void Save_Leases_Bt_Click(object sender, EventArgs e)
        {
            // Update Lease
            Update_Lease();
        }
    }
}
