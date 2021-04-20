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
    internal partial class FrmContact : Form
    {

        // Gobal Variables
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

        private Organization ORG;
        private Contact CONTACT;
        private readonly bool new_Contact;
        //private List<Tag> SELECTED_TAGS;
        private List<Address> NEW_ADDRESSES;

        public FrmContact(Organization ORG, Contact CONTACT, bool new_Contact)
        {
            InitializeComponent();

            Init_Page();

            this.ORG = ORG;
            this.CONTACT = CONTACT;
            this.new_Contact = new_Contact;

            Populate_Fields(CONTACT);

            string[] temp = new string[1];
            temp[0] = ORG.Name;
            Organization_Cb.DataSource = temp;

            // Auto Complet Text

        }

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);

            Auto_Complete();

        }

        private void Auto_Complete()
        {
            County_Tb.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            County_Tb.AutoCompleteSource = AutoCompleteSource.CustomSource;
            County_Tb.AutoCompleteCustomSource = Process.Generate_Counties_Auto_Complet();
        }

        private void Populate_Fields(Contact contact)
        {
            if (!string.IsNullOrWhiteSpace(contact.First_Name))
            {
                First_Name_Tb.Text = contact.First_Name;
            }
            if (!string.IsNullOrWhiteSpace(contact.Last_Name))
            {
                Last_Name_Tb.Text = contact.Last_Name;
            }
            if (!string.IsNullOrWhiteSpace(contact.Mobile_Phone))
            {
                Phone_Tb.Text = contact.Mobile_Phone;
            }
            if (!string.IsNullOrWhiteSpace(contact.Fax))
            {
                Fax_Tb.Text = contact.Fax;
            }
            if (!string.IsNullOrWhiteSpace(contact.Email))
            {
                Email_Tb.Text = contact.Email;
            }
            if (!string.IsNullOrWhiteSpace(contact.Title))
            {
                Title_Tb.Text = contact.Title;
            }
            Console.WriteLine("OFFICE_PHONE: " + contact.Office_Phone);
            Console.WriteLine(Office_Phone_Tb.Text = contact.Office_Phone);
            if (!string.IsNullOrWhiteSpace(contact.Office_Phone))
            {
                Office_Phone_Tb.Text = contact.Office_Phone;
            }

            //if (new_Contact && !string.IsNullOrWhiteSpace(ORG.Phone))
            //{
            //    Office_Phone_Tb.Text = ORG.Phone;
            //}

            Draw_Addresses();
        }

        private void Init_Page()
        {
            Top_Pn.MouseDown += Mouse_Down;
            FormBorderStyle = FormBorderStyle.None;
            Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 20, 20));
            if (DataStore.Get_Theme_CONFIG())
            {
                Top_Pn.BackColor = DataStore.Get_CONFIG_Theme_Color();
                Contact_Acc_Pn.BackColor = DataStore.Get_CONFIG_Theme_Color();
                Address_Acc_Pn.BackColor = DataStore.Get_CONFIG_Theme_Color();
                //Lease_Acc_Pn.BackColor = Color.DimGray;
            }

            // Add EventHandlers
            First_Name_Tb.GotFocus += Process.TB_Got_Focus;
            First_Name_Tb.LostFocus += Process.TB_Lost_Focus;

            Last_Name_Tb.GotFocus += Process.TB_Got_Focus;
            Last_Name_Tb.LostFocus += Process.TB_Lost_Focus;

            Phone_Tb.GotFocus += Process.TB_Got_Focus;
            Phone_Tb.LostFocus += Process.TB_Lost_Focus;

            Office_Phone_Tb.GotFocus += Process.TB_Got_Focus;
            Office_Phone_Tb.LostFocus += Process.TB_Lost_Focus;

            Fax_Tb.GotFocus += Process.TB_Got_Focus;
            Fax_Tb.LostFocus += Process.TB_Lost_Focus;

            Title_Tb.GotFocus += Process.TB_Got_Focus;
            Title_Tb.LostFocus += Process.TB_Lost_Focus;

            Email_Tb.GotFocus += Process.TB_Got_Focus;
            Email_Tb.LostFocus += Process.TB_Lost_Focus;

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
            County_Tb.KeyDown += County_Tb_KeyDown;
            County_Tb.LostFocus += County_Tb_LostFocus;

            Addr_Clb.Click += Addr_Clb_Click;

            Address_Pn.Click += Address_Pn_Click;

            ORG = new Organization();
            CONTACT = new Contact();
            NEW_ADDRESSES = new List<Address>();
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
            Draw_Addresses();
        }

        private void Addr_Clb_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            foreach (object i in Addr_Clb.CheckedItems)
            {
                foreach (Address a in CONTACT.GetAddresses())
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
            if (new_Contact)
            {
                DataStore.Contact_Create_Cancelled(CONTACT);
            }
            Close_Page();
        }

        private void Close_Page()
        {
            Close();
        }

        private void Contact_Accordion_Bt_Click(object sender, EventArgs e)
        {
            Process.Accordion(sender, e, Contact_Pn);
        }

        private void Draw_Addresses()
        {
            //DataStore.Retrieve_Tags_REST();
            Addr_Clb.Items.Clear();
            foreach (Address a in CONTACT.GetAddresses())
            {
                Addr_Clb.Items.Add(a.To_String(), false);
            }

            Org_Addr_Clb.Items.Clear();
            foreach (Address a in ORG.GetAddresses())
            {
                if (ORG.GetAddresses().Count == 1)
                {
                    Org_Addr_Clb.Items.Add(a.To_String(), true);
                }
                else
                {
                    Org_Addr_Clb.Items.Add(a.To_String(), false);
                }
            }
            Addr_1_Tb.Text = (string)Addr_1_Tb.Tag;
            Addr_2_Tb.Text = (string)Addr_2_Tb.Tag;
            City_Tb.Text = (string)City_Tb.Tag;
            State_Tb.Text = (string)State_Tb.Tag;
            Zip_Tb.Text = (string)Zip_Tb.Tag;
            County_Tb.Text = (string)County_Tb.Tag;
            Refresh();
        }

        private void FRM_FILTER_FormClosed(object sender, FormClosedEventArgs e)
        {
            Auto_Complete();
        }

        private void First_Name_Lb_Click(object sender, EventArgs e)
        {

        }

        private void Edit_Helper()
        {
            if (!Addr_1_Tb.Text.Equals((string)Addr_1_Tb.Tag) && !string.IsNullOrWhiteSpace(Addr_1_Tb.Text)
                && !City_Tb.Text.Equals((string)City_Tb.Tag) && !string.IsNullOrWhiteSpace(City_Tb.Text)
                && !State_Tb.Text.Equals((string)State_Tb.Tag) && !string.IsNullOrWhiteSpace(State_Tb.Text)
                && !Zip_Tb.Text.Equals((string)Zip_Tb.Tag) && !string.IsNullOrWhiteSpace(Zip_Tb.Text)
                && !County_Tb.Text.Equals((string)County_Tb.Tag) && !string.IsNullOrWhiteSpace(County_Tb.Text))
            {
                foreach (object i in Addr_Clb.CheckedItems)
                {
                    foreach (Address a in CONTACT.GetAddresses())
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
                Draw_Addresses();
                Edit_Addr_Bt.Visible = false;
            }
        }

        private void Update_Bt_Click(object sender, EventArgs e)
        {
            if (First_Name_Tb.Text.Equals((string)First_Name_Tb.Tag) || Office_Phone_Tb.Text.Equals((string)Office_Phone_Tb.Tag)
                || string.IsNullOrWhiteSpace(First_Name_Tb.Text) || string.IsNullOrWhiteSpace(Office_Phone_Tb.Text))
            {
                First_Name_Lb.ForeColor = Color.Crimson;
                Office_Phone_Tb.ForeColor = Color.Crimson;
                Process.Display_Alert("Error: First Name And Phone Missing", true);
                return;
            }
            else
            {
                CONTACT.First_Name = First_Name_Tb.Text;
                if (CONTACT.First_Name.Contains("&"))
                {
                    CONTACT.First_Name = CONTACT.First_Name.Replace("&", "%26");
                }
                CONTACT.Mobile_Phone = Phone_Tb.Text;
            }
            if (!Last_Name_Tb.Text.Equals((string)Last_Name_Tb.Tag) && !string.IsNullOrWhiteSpace(Last_Name_Tb.Text))
            {
                CONTACT.Last_Name = Last_Name_Tb.Text;
                if (CONTACT.Last_Name.Contains("&"))
                {
                    CONTACT.Last_Name = CONTACT.Last_Name.Replace("&", "%26");
                }
            }
            if (!Email_Tb.Text.Equals((string)Email_Tb.Tag) && !string.IsNullOrWhiteSpace(Email_Tb.Text))
            {
                CONTACT.Email = Email_Tb.Text;
            }
            if (!Fax_Tb.Text.Equals((string)Fax_Tb.Tag) && !string.IsNullOrWhiteSpace(Fax_Tb.Text))
            {
                CONTACT.Fax = Fax_Tb.Text;
            }
            if (!Title_Tb.Text.Equals((string)Title_Tb.Tag) && !string.IsNullOrWhiteSpace(Title_Tb.Text))
            {
                CONTACT.Title = Title_Tb.Text;
            }
            if (!Office_Phone_Tb.Text.Equals((string)Office_Phone_Tb.Tag) && !string.IsNullOrWhiteSpace(Office_Phone_Tb.Text))
            {
                CONTACT.Office_Phone = Office_Phone_Tb.Text;
            }

            // Update Info
            DataStore.Update_Contacts_REST(CONTACT);

            // Update Addresses
            foreach (Address a in NEW_ADDRESSES)
            {
                if (a.rowguid == null)
                {
                    DataStore.Create_Addr_Rest(new Organization(), CONTACT, a);
                }
                else
                {
                    DataStore.Address_Link_REST(new Organization(), CONTACT, a);
                }
            }

            Close();
        }

        private void Down_Bt_Click_1(object sender, EventArgs e)
        {
            foreach (object i in Org_Addr_Clb.CheckedItems)
            {
                foreach (Address a in ORG.GetAddresses())
                {
                    if (a.To_String().Equals((string)i))
                    {
                        NEW_ADDRESSES.Add(a);
                        Addr_Clb.Items.Add(a.Address_1 + " " + a.Address_2 + " " + a.City + " " + a.State + " " + a.Zip + " " + a.County, false);
                    }
                }
            }
        }

        private void Edit_Addr_Bt_Click_1(object sender, EventArgs e)
        {
            Edit_Helper();
        }

        private void Reset_Addr_Bt_Click(object sender, EventArgs e)
        {
            Draw_Addresses();
        }

        private void Add_Addr_Bt_Click_1(object sender, EventArgs e)
        {
            if (!Addr_1_Tb.Text.Equals((string)Addr_1_Tb.Tag) && !string.IsNullOrWhiteSpace(Addr_1_Tb.Text)
                && !City_Tb.Text.Equals((string)City_Tb.Tag) && !string.IsNullOrWhiteSpace(City_Tb.Text)
                && !State_Tb.Text.Equals((string)State_Tb.Tag) && !string.IsNullOrWhiteSpace(State_Tb.Text)
                && !Zip_Tb.Text.Equals((string)Zip_Tb.Tag) && !string.IsNullOrWhiteSpace(Zip_Tb.Text)
                && !County_Tb.Text.Equals((string)County_Tb.Tag) && !string.IsNullOrWhiteSpace(County_Tb.Text))
            {
                string addr_2 = "";
                if (Addr_2_Tb.Text.Equals((string)Addr_2_Tb.Tag))
                {
                    addr_2 = "";
                }
                else
                {
                    addr_2 = Addr_2_Tb.Text;
                }
                NEW_ADDRESSES.Add(new Address(Addr_1_Tb.Text, addr_2, City_Tb.Text, State_Tb.Text, Zip_Tb.Text, County_Tb.Text));
                Addr_Clb.Items.Add(Addr_1_Tb.Text + " " + addr_2 + " " + City_Tb.Text + " " + State_Tb.Text + " " + Zip_Tb.Text + " " + County_Tb.Text, false);

                Addr_1_Tb.Text = (string)Addr_1_Tb.Tag;
                Addr_2_Tb.Text = (string)Addr_2_Tb.Tag;
                City_Tb.Text = (string)City_Tb.Tag;
                State_Tb.Text = (string)State_Tb.Tag;
                Zip_Tb.Text = (string)Zip_Tb.Tag;
                County_Tb.Text = (string)County_Tb.Tag;
            }
        }

        private void Address_Accordion_Pn_Click(object sender, EventArgs e)
        {
            Process.Accordion(sender, e, Address_Pn);
        }
    }
}
