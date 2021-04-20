using DSI_CRM.Models;
using DSI_CRM.Service;
using DSI_CRM.Services;
using System;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;

namespace DSI_CRM
{
    public partial class FrmSelectOrgC : Form
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

        private static string SELECTED_ORG_ROWGUID;
        private static string SELECTED_CONTACT_ROWGUID;
        private static bool SEARCH_BOOL = false;
        private static StringBuilder SELECTED_TAGS_STR;


        public FrmSelectOrgC()
        {
            InitializeComponent();

            Init_Page();

            // Init Vars
            SELECTED_ORG_ROWGUID = null;
            SELECTED_CONTACT_ROWGUID = null;
            SELECTED_TAGS_STR = new StringBuilder();
        }

        private void Init_Page()
        {
            FormBorderStyle = FormBorderStyle.None;
            if (DataStore.Get_Theme_CONFIG())
            {
                Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 20, 20));
                //Top_Pn.BackColor = DataStore.Get_CONFIG_Theme_Color();
            }
            Top_Pn.MouseDown += Mouse_Down;
            Org_Pn.MouseDown += Mouse_Down;
            Org_Flp.MouseDown += Mouse_Down;
            Contact_Pn.MouseDown += Mouse_Down;
            Contact_Flp.MouseDown += Mouse_Down;
            Organization_Dg.CellClick += Organization_Dg_Cell_Click;
            Contact_Dg.CellClick += Contact_Dg_Cell_Click;
            Org_Name_Search_Tb.GotFocus += Process.Got_Focus_Main;
            Org_Name_Search_Tb.LostFocus += Process.Lost_Focus_Main;
            Org_Name_Search_Tb.KeyDown += Search_Org_Tb_KeyDown;
            Org_City_Search_Tb.GotFocus += Process.Got_Focus_Main;
            Org_City_Search_Tb.LostFocus += Process.Lost_Focus_Main;
            Org_City_Search_Tb.KeyDown += Search_Org_Tb_KeyDown;
            Org_Addr_Search_Tb.GotFocus += Process.Got_Focus_Main;
            Org_Addr_Search_Tb.LostFocus += Process.Lost_Focus_Main;
            Org_Addr_Search_Tb.KeyDown += Search_Org_Tb_KeyDown;
            Contact_Search_Tb.GotFocus += Process.Got_Focus_Main;
            Contact_Search_Tb.LostFocus += Process.Lost_Focus_Main;
            Contact_Search_Tb.KeyDown += Search_Contact_Tb_KeyDown;
            Org_Count_Lb.Click += Org_Count_Lb_Click;
            Contact_Count_Lb.Click += Contact_Count_Lb_Click;
            Process.Style_DataGridView(Organization_Dg);
            Process.Style_DataGridView(Contact_Dg);
        }

        private void Contact_Dg_Cell_Click(object sender, DataGridViewCellEventArgs e)
        {
            if (Contact_Dg.Rows.Count > 0)
            {
                try
                {
                    SELECTED_CONTACT_ROWGUID = Contact_Dg.Rows[e.RowIndex].Cells[0].Value.ToString();
                    if (SEARCH_BOOL)
                    {
                        DataStore.Clear_ORGS();
                        DataStore.Add_ORGS(DataStore.Get_ORG_REST(Contact_Dg.Rows[e.RowIndex].Cells[4].Value.ToString()));
                        Load_ORGS();
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error: " + ex.StackTrace);
                }
            }
        }

        private void Organization_Dg_Cell_Click(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (Organization_Dg.Rows.Count == 0)
                {
                    Load_ORGS();
                }
                SELECTED_ORG_ROWGUID = Organization_Dg.Rows[e.RowIndex].Cells[0].Value.ToString();
                Organization_Dg_Cell_Clicked_Helper();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private void Org_Count_Lb_Click(object sender, EventArgs e)
        {
            // Clear 
            DataStore.Clear_ORGS();
            Load_ORGS();
        }

        private void Contact_Count_Lb_Click(object sender, EventArgs e)
        {
            // Clear
            DataStore.Clear_SEARCHED_CONTACT();
            Contact_Dg.Rows.Clear();

        }
        private void Search_Org_Tb_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                Search_Org_Tb_KeyDown_Helper();
                SEARCH_BOOL = false;
            }
        }

        private void Search_Org_Tb_KeyDown_Helper()
        {
            try
            {
                string name = "";
                string city = "";
                string addr = "";

                if (!Org_Name_Search_Tb.Text.Equals((string)Org_Name_Search_Tb.Tag))
                {
                    name = Org_Name_Search_Tb.Text;
                }
                if (!Org_City_Search_Tb.Text.Equals((string)Org_City_Search_Tb.Tag))
                {
                    city = Org_City_Search_Tb.Text;
                }
                if (!Org_Addr_Search_Tb.Text.Equals((string)Org_Addr_Search_Tb.Tag))
                {
                    addr = Org_Addr_Search_Tb.Text;
                }

                if (!(SELECTED_TAGS_STR.ToString().Equals("") && name.Equals("") && city.Equals("") && addr.Equals("")))
                {
                    if (SELECTED_TAGS_STR.Length > 0)
                    {
                        //tags_str = tags_str.Remove(tags_str.Length - 1, 1);
                        SELECTED_TAGS_STR.Remove(SELECTED_TAGS_STR.Length - 1, 1);
                    }
                    //Console.WriteLine("**" + tags_str.ToString());
                    DataStore.Retrieve_Orgs_Filtered_REST(name, city, addr, SELECTED_TAGS_STR.ToString());
                    Load_ORGS();
                    if (Organization_Dg.Rows.Count > 0)
                    {
                        SELECTED_ORG_ROWGUID = Organization_Dg.Rows[0].Cells[0].Value.ToString();
                        Organization_Dg_Cell_Clicked_Helper();
                    }

                    if (Contact_Dg.Rows.Count > 0)
                    {
                        SELECTED_CONTACT_ROWGUID = Contact_Dg.Rows[0].Cells[0].Value.ToString();
                    }

                    SELECTED_TAGS_STR = new StringBuilder();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.StackTrace);
            }

        }

        private void Organization_Dg_Cell_Clicked_Helper()
        {
            Contact_Dg.Rows.Clear();
            DataStore.Retrieve_Org_Contacts_REST(DataStore.Get_Org_rowguid_REST(SELECTED_ORG_ROWGUID));
            foreach (Contact contact in DataStore.Get_SEARCH_CONTACTS())
            {
                Contact_Dg.Rows.Add(new string[] { contact.rowguid, contact.GetContact_Name(), contact.Title, contact.Mobile_Phone, contact.Organization_Number });
            }

            if (Contact_Dg.Rows.Count > 0)
            {
                SELECTED_CONTACT_ROWGUID = Contact_Dg.Rows[0].Cells[0].Value.ToString();
                Contact_Count_Lb.Text = Contact_Dg.Rows.Count.ToString();
            }
            else
            {
                SELECTED_CONTACT_ROWGUID = null;
                Contact_Count_Lb.Text = "0";
            }
        }

        private void Load_ORGS()
        {
            SELECTED_CONTACT_ROWGUID = null;
            SELECTED_ORG_ROWGUID = null;
            Organization_Dg.Rows.Clear();
            foreach (Organization org in DataStore.Get_ORGS())
            {
                Organization_Dg.Rows.Add(new string[] { org.rowguid, org.Name, org.Phone });
            }
            if (Organization_Dg.Rows.Count > 0)
            {
                SELECTED_ORG_ROWGUID = Organization_Dg.Rows[0].Cells[0].Value.ToString();
                Org_Count_Lb.Text = Organization_Dg.Rows.Count.ToString();
            }
            else
            {
                SELECTED_ORG_ROWGUID = null;
                Org_Count_Lb.Text = "0";
            }
        }

        private void Search_Contact_Tb_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && !Contact_Search_Tb.Text.Equals((string)Contact_Search_Tb.Tag))
            {
                DataStore.Retrieve_Contact_Filtered_REST(Contact_Search_Tb.Text);
                Contact_Dg.Rows.Clear();
                foreach (Contact c in DataStore.Get_SEARCH_CONTACTS())
                {
                    Contact_Dg.Rows.Add(new string[] { c.rowguid, c.GetContact_Name(), c.Title, c.Mobile_Phone, c.Organization_Number });
                }
                if (Contact_Dg.Rows.Count > 0)
                {
                    SELECTED_CONTACT_ROWGUID = Contact_Dg.Rows[0].Cells[0].Value.ToString();
                }
                SEARCH_BOOL = true;
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

        private void Select_Bt_Click(object sender, EventArgs e)
        {

        }

        private void Cancel_Bt_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void Clear_Grids_Bt_Click(object sender, EventArgs e)
        {
            DataStore.Clear_ORGS();
            Load_ORGS();
            DataStore.Clear_SEARCHED_CONTACT();
            Contact_Dg.Rows.Clear();
        }

        private void Salesmen_Bt_Click(object sender, EventArgs e)
        {
            FrmSalesmen frm = new FrmSalesmen();
            frm.FormClosed += FRM_FILTER_FormClosed;
            frm.ShowDialog();
        }

        private void FRM_FILTER_FormClosed(object sender, FormClosedEventArgs e)
        {
            Load_ORGS();
        }

        private void Tags_Bt_Click(object sender, EventArgs e)
        {
            //this.Visible = false;
            using (FrmTags_ form = new FrmTags_(false))
            {
                form.ShowDialog();
                SELECTED_TAGS_STR = form.SELECTED_TAGS;
                if (SELECTED_TAGS_STR != null)
                {
                    Search_Org_Tb_KeyDown_Helper();
                }
            }
            //this.Visible = true;
        }

        private void FRM_TAGS_FormClosed(object sender, FormClosedEventArgs e)
        {
            Search_Org_Tb_KeyDown_Helper();
        }
    }
}
