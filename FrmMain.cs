using DSI_CRM.Models;
using DSI_CRM.Service;
using DSI_CRM.Services;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using Outlook = Microsoft.Office.Interop.Outlook;

namespace DSI_CRM
{
    internal partial class FrmMain : Form
    {
        // Gobal Variables
        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;

        // Dll Imports
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

        private static string SELECTED_ORG_ROWGUID;
        private static string SELECTED_CONTACT_ROWGUID;
        private static StringBuilder SELECTED_TAGS_STR;

        // Forms
        //private static FrmScreen FRM_SCREEN;
        //private static readonly FrmTags FRM_TAGS;
        private static FrmContact FRM_CONTACT;
        private static FrmSalesmen FRM_SALESMEN;

        private static StringBuilder B_STR;
        private static List<Organization> ORGS;

        private static bool SEARCH_BOOL = false;
        private static bool MAILCHIMP = false;

        public FrmMain()
        {
            // Init Components
            InitializeComponent();

            Load += new EventHandler(Load_Page);

            // Init Vars
            SELECTED_ORG_ROWGUID = null;
            SELECTED_CONTACT_ROWGUID = null;
            B_STR = new StringBuilder();
            ORGS = new List<Organization>();
            SELECTED_TAGS_STR = new StringBuilder();
        }

        private void Load_Page(object sender, EventArgs e)
        {
            // Init Page
            Init_Frm();
        }

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);
            // Set Theme
            Set_Theme();
        }

        protected override void OnPaintBackground(PaintEventArgs e)
        {
            try
            {
                using (LinearGradientBrush brush = new LinearGradientBrush(ClientRectangle, Color.White, Color.Silver, 50F))
                {
                    e.Graphics.FillRectangle(brush, ClientRectangle);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private void Set_Theme()
        {
            if (DataStore.Get_CONFIG().Theme)
            {
                Gray_Them_Bt_Helper();
            }
            else
            {
                Red_Theme_Bt_Helper();
            }
        }

        private void FRM_CONTACT_FormClosed(object sender, FormClosedEventArgs e)
        {
            Organization_Dg_Cell_Clicked_Helper();
        }


        private void Init_Frm()
        {
            // Border
            FormBorderStyle = FormBorderStyle.None;
            Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 20, 20));
            //if (DataStore.Get_Theme_CONFIG())
            //{
            //    Top_Pn.BackColor = DataStore.Get_CONFIG_Theme_Color();
            //}
            Salesman_Lb.Text = "-   " + DataStore.Get_LOGGED_USER().Last_Name.ToUpper();
            // Add EventHandlers
            Top_Pn.MouseDown += Mouse_Down;
            Banner_Pn.MouseDown += Mouse_Down;
            Organization_Dg.CellClick += Organization_Dg_Cell_Click;
            Contact_Dg.CellClick += Contact_Dg_Cell_Click;
            Organization_Dg.CellDoubleClick += Organization_Dg_CellDoubleClick;
            //Contact_Dg.CellDoubleClick += Contact_Dg_CellDoubleClick;
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

            // Style Datagrids
            //Process. Style_DataGridView(Organization_Dg);
            //Process.Style_DataGridView(Contact_Dg);
        }

        private void Contact_Count_Lb_Click(object sender, EventArgs e)
        {
            // Clear
            DataStore.Clear_SEARCHED_CONTACT();
            SELECTED_CONTACT_ROWGUID = null;
            Contact_Dg.Rows.Clear();
        }

        private void Org_Count_Lb_Click(object sender, EventArgs e)
        {
            // Clear 
            DataStore.Clear_ORGS();
            Load_ORGS();
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
                    DataStore.Retrieve_Orgs_Filtered_REST(name, city, addr, SELECTED_TAGS_STR.ToString());
                    SELECTED_TAGS_STR.Clear();
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
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.StackTrace);
            }

        }

        private void Organization_Dg_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                SELECTED_ORG_ROWGUID = Organization_Dg.Rows[e.RowIndex].Cells[0].Value.ToString();
                if (SELECTED_ORG_ROWGUID != null && !SELECTED_ORG_ROWGUID.Equals(""))
                {
                    //FrmNotes frm = new FrmNotes(DataStore.Get_ORG_rowguid_REST(SELECTED_ORG_ROWGUID));
                    Organization org = DataStore.Get_ORG_rowguid_REST(SELECTED_ORG_ROWGUID);
                    FrmTask_ frm = new FrmTask_(org, DateTime.Now);
                    frm.ShowDialog();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("#Organization_Dg_Cell_Click " + ex.Message);
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
            Terminate_App();
        }

        private void Terminate_App()
        {
            //Process.Save_Configuration();
            Process.Save_CONFIG();
            Exit_Application();
        }

        private void Exit_Application()
        {
            Application.Exit();
        }

        private void Resize_Bt_Click(object sender, EventArgs e)
        {
            //if (WindowState == FormWindowState.Maximized)
            //{
            //    WindowState = FormWindowState.Normal;
            //    Control control = (Control)sender;
            //    control.Size = new Size(control.Size.Width, control.Size.Width);
            //    Button button = (Button)sender;
            //    button.Image = Properties.Resources.Expand_24px;
            //    button.Size = new Size(64, 24);
            //    button.Refresh();
            //}
            //else
            //{
            //    WindowState = FormWindowState.Maximized;
            //    Button button = (Button)sender;
            //    button.Image = Properties.Resources.Collapse_24_px;
            //    button.Size = new Size(64, 24);
            //    button.Refresh();
            //}
            Refresh();
        }

        private void Minimize_Bt_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void Org_Add_Bt_Click(object sender, EventArgs e)
        {
            Visible = false;
            FrmScreen frm = new FrmScreen();
            frm.FormClosing += FRM_SCREEN_FormClosing;
            frm.ShowDialog();
            Visible = true;
        }

        private void FRM_SCREEN_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                Load_ORGS();
            }
            catch (Exception ex)
            {
                Process.Display_Alert(ex.Message, false);
            }
        }

        private void Contact_Add_Bt_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(SELECTED_ORG_ROWGUID))
            {
                Visible = false;
                Organization org = DataStore.Get_ORG_rowguid_REST(SELECTED_ORG_ROWGUID);
                FRM_CONTACT = new FrmContact(org, DataStore.Contact_Create_New_REST(org), true);
                FRM_CONTACT.FormClosed += FRM_CONTACT_FormClosed;
                FRM_CONTACT.ShowDialog();
                Visible = true;
            }
            else
            {
                Process.Display_Alert("Please Select an Organization", false);
            }
        }

        private void Terminate_Bt_Click(object sender, EventArgs e)
        {
            Terminate_App();
        }

        private void Logout_Bt_Click(object sender, EventArgs e)
        {
            DataStore.Clear_DataStore();
            FrmLogin frm = new FrmLogin();
            frm.Show();
            Hide();
        }

        private void Calendar_Bt_Click(object sender, EventArgs e)
        {
            Visible = false;
            Open_Calendar();
            Visible = true;
        }

        private void Open_Calendar()
        {
            try
            {
                if (File.Exists(Environment_Var.CREDENTIALS_FULL_PATH))
                {

                    FrmCalendar frm = new FrmCalendar();
                    frm.ShowDialog();
                }
                else if (File.Exists(Environment_Var.Get_DOWNLOAD_FULL_PATH() + Environment_Var.CREDENTIALS_PATH))
                {
                    File.Move((Environment_Var.Get_DOWNLOAD_FULL_PATH() + Environment_Var.CREDENTIALS_PATH), Environment_Var.CREDENTIALS_FULL_PATH);
                    FrmCalendar frm = new FrmCalendar();
                    frm.ShowDialog();
                }
                else
                {
                    Process.Display_Alert("Missing: C:\\DSI_CRM\\credentials.json", false);
                    System.Diagnostics.Process.Start("https://developers.google.com/calendar/quickstart/dotnet");
                    FrmAlert frm = new FrmAlert("Open Instructions Set?", true)
                    {
                        StartPosition = FormStartPosition.CenterScreen
                    };
                    DialogResult result = frm.ShowDialog();
                    if (result == DialogResult.Yes)
                    {
                        // Show instructions
                        Form1 frm1 = new Form1();
                        frm1.ShowDialog();
                    }
                }
            }
            catch (IOException ioex)
            {
                Console.WriteLine(ioex.Message);
            }
        }

        private void Organization_Dg_Cell_Click(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1)
            {
                return;
            }
            if (Organization_Dg.Rows.Count == 0)
            {
                Load_ORGS();
            }
            SELECTED_ORG_ROWGUID = Organization_Dg.Rows[e.RowIndex].Cells[0].Value.ToString();
            Organization_Dg_Cell_Clicked_Helper();
        }

        private void Organization_Dg_Cell_Clicked_Helper()
        {
            try
            {
                Contact_Dg.Rows.Clear();
                DataStore.Retrieve_Org_Contacts_REST(DataStore.Get_Org_rowguid_REST(SELECTED_ORG_ROWGUID));
                foreach (Contact contact in DataStore.Get_SEARCH_CONTACTS())
                {
                    //Regex.Replace(contact.Mobile_Phone, "[^0-9]", "")
                    Contact_Dg.Rows.Add(new string[] { contact.rowguid, Process.To_Upper(contact.GetContact_Name()), Process.To_Upper(contact.Title), Process.Keep_Punctuation(contact.Mobile_Phone), contact.Organization_Number });
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
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private void Contact_Dg_Cell_Click(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1)
            {
                return;
            }
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

        private void Contact_Dg_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (Contact_Dg.Rows.Count > 0)
            {
                try
                {
                    SELECTED_CONTACT_ROWGUID = Contact_Dg.Rows[e.RowIndex].Cells[0].Value.ToString();
                    if (e.ColumnIndex == 1)
                    {
                        Note_Bt_Helper();
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("#Organization_Dg_Cell_Click " + ex.Message);
                }
            }
        }

        private void Org_Edit_Bt_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(SELECTED_ORG_ROWGUID))
            {
                Visible = false;
                FrmOrganization frm = new FrmOrganization(DataStore.Get_ORG_rowguid_REST(SELECTED_ORG_ROWGUID));
                frm.ShowDialog();
                Visible = true;
            }
            else
            {
                Process.Display_Alert("Select an Organization", false);
            }
        }

        private void Contact_Edit_Bt_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(SELECTED_CONTACT_ROWGUID))
            {
                Visible = false;
                Contact contact = DataStore.Get_Contact_rowguid_REST(SELECTED_CONTACT_ROWGUID);
                FRM_CONTACT = new FrmContact(DataStore.Get_ORG_REST(contact.Organization_Number), contact, false);
                FRM_CONTACT.FormClosed += FRM_CONTACT_FormClosed;
                FRM_CONTACT.ShowDialog();
                Visible = true;
            }
            else
            {
                Process.Display_Alert("Please Select a Contact", false);
            }
        }

        private void Org_Delete_Bt_Click(object sender, EventArgs e)
        {
            //TODO: Delete Organization
        }

        private void SendEmail(object sender, EventArgs e, string recipient, string subject, string body)
        {
            try
            {
                Outlook.Application oApp = new Outlook.Application();
                Outlook.MailItem oMsg = (Outlook.MailItem)oApp.CreateItem(Outlook.OlItemType.olMailItem);

                oMsg.Subject = subject;
                oMsg.BodyFormat = Microsoft.Office.Interop.Outlook.OlBodyFormat.olFormatHTML;
                oMsg.HTMLBody = body; //Here comes your body;
                oMsg.To = recipient;
                //oMsg.Attachments.Add("C:/Users/Doth55/Documents/No.txt", Microsoft.Office.Interop.Outlook.OlAttachmentType.olByValue, Type.Missing, Type.Missing);
                oMsg.Display(true); //In order to display it in modal inspector change the argument to true

                //    Outlook.MailItem mail = Application.CreateItem(
                //Outlook.OlItemType.olMailItem) as Outlook.MailItem;
                //    mail.Subject = "Quarterly Sales Report FY06 Q4";
                //    Outlook.AddressEntry currentUser =
                //        Application.Session.CurrentUser.AddressEntry;
                //    if (currentUser.Type == "EX")
                //    {
                //        Outlook.ExchangeUser manager =
                //            currentUser.GetExchangeUser().GetExchangeUserManager();
                //        // Add recipient using display name, alias, or smtp address
                //        mail.Recipients.Add(manager.PrimarySmtpAddress);
                //        mail.Recipients.ResolveAll();
                //        mail.Attachments.Add(@"c:\sales reports\fy06q4.xlsx",
                //            Outlook.OlAttachmentType.olByValue, Type.Missing,
                //            Type.Missing);
                //        mail.Send();
                //    }
            }
            catch (Exception objEx)
            {
                Console.WriteLine(objEx.ToString());
            }
        }

        private void Tags_Bt_Click(object sender, EventArgs e)
        {
            using (FrmTags_ form = new FrmTags_(false))
            {
                form.ShowDialog();
                SELECTED_TAGS_STR = form.SELECTED_TAGS;
                if (SELECTED_TAGS_STR != null)
                {
                    Search_Org_Tb_KeyDown_Helper();
                }
            }
        }

        private void Note_Bt_Click(object sender, EventArgs e)
        {
            Note_Bt_Helper();
        }

        private void Note_Bt_Helper()
        {
            if (!string.IsNullOrWhiteSpace(SELECTED_ORG_ROWGUID) && !string.IsNullOrWhiteSpace(SELECTED_CONTACT_ROWGUID))
            {
                FrmNotes frm = new FrmNotes(DataStore.Get_ORG_rowguid_REST(SELECTED_ORG_ROWGUID), DataStore.Get_Contact_rowguid_REST(SELECTED_CONTACT_ROWGUID));
                frm.ShowDialog();
            }
            else
            {
                Process.Display_Alert("Select an Organization & Contact", false);
            }
        }

        private void Salesmen_Bt_Click(object sender, EventArgs e)
        {
            FRM_SALESMEN = new FrmSalesmen();
            FRM_SALESMEN.FormClosed += FRM_FILTER_FormClosed;
            FRM_SALESMEN.ShowDialog();
        }

        private void FRM_FILTER_FormClosed(object sender, FormClosedEventArgs e)
        {
            Load_ORGS();
        }

        private void Load_ORGS()
        {
            SELECTED_CONTACT_ROWGUID = null;
            SELECTED_ORG_ROWGUID = null;
            Organization_Dg.Rows.Clear();
            foreach (Organization org in DataStore.Get_ORGS())
            {
                Organization_Dg.Rows.Add(new string[] { org.rowguid, Process.To_Upper(org.Name.ToUpper()), Process.Keep_Punctuation(org.Phone)});
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

        private void Red_Theme_Bt_Click(object sender, EventArgs e)
        {
            if (DataStore.Get_Theme_CONFIG())
            {
                Red_Theme_Bt_Helper();
                Process.Save_Configuration();
                Open_New_Form();
            }
        }

        private void Red_Theme_Bt_Helper()
        {
            Top_Pn.BackColor = Color.Black;
            //Banner_Pn.BackColor = ColorTranslator.FromHtml("#DB062C");
            Banner_Pn.BackColor = Color.Black;
            //Bottom_Pn.BackColor = Color.Black;
            //DataGrids_Flp.BackColor = Color.Silver;
            Staduim_Ring_Pn.BackColor = ColorTranslator.FromHtml("#DB062C");
            DataStore.Set_Them_CONFIG(false);
        }

        private void Gray_Theme_Bt_Click(object sender, EventArgs e)
        {
            if (!DataStore.Get_Theme_CONFIG())
            {
                Gray_Them_Bt_Helper();
                Process.Save_Configuration();
                Open_New_Form();
            }
            else
            {
                Theme_Color_Picker();
            }
        }

        private void Gray_Them_Bt_Helper()
        {
            Top_Pn.BackColor = Color.DimGray;
            Banner_Pn.BackColor = Color.Gray;
            //Bottom_Pn.BackColor = Color.DimGray;
            //DataGrids_Flp.BackColor = Color.White;
            //Staduim_Ring_Pn.Click += Stadium_Ring_Pn_Click;
            Stadium_Ring_Helper();
            DataStore.Set_Them_CONFIG(true);
        }

        private void Open_New_Form()
        {
            FrmMain frm = new FrmMain();
            Hide();
            frm.ShowDialog();
            frm.Refresh();
        }

        private void Stadium_Ring_Pn_Click(object sender, EventArgs e)
        {
            Stadium_Ring_Helper();
        }

        private void Stadium_Ring_Helper()
        {
            Staduim_Ring_Pn.BackColor = Color.Gray;
        }

        private void Quote_Bt_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(SELECTED_ORG_ROWGUID) && !string.IsNullOrWhiteSpace(SELECTED_CONTACT_ROWGUID))
            {
                Organization org = DataStore.Get_Org_rowguid_REST(SELECTED_ORG_ROWGUID);
                Contact contact = DataStore.Get_Contact_rowguid_REST(SELECTED_CONTACT_ROWGUID);

                Quote quote = new Quote(org.Organization_Number, contact.Contact_Number)
                {
                    Quote_Number = DataStore.Create_Quote_REST(org),
                    Salesman_Initials = DataStore.Get_LOGGED_USER().Initials
                };
                //Visible = false;
                FrmQuote frm = new FrmQuote(quote)
                {
                    StartPosition = FormStartPosition.CenterScreen
                };
                //frm.FormClosed += Frm_FormClosed1;
                frm.Show();
                //Visible = true;
            }
            else
            {
                Process.Display_Alert("Select an Organization & Contact", false);
            }
        }

        private void Frm_FormClosed1(object sender, FormClosedEventArgs e)
        {
            Visible = true;
        }

        private void Email_Bt_Click(object sender, EventArgs e)
        {
            //Microsoft.Office.Interop.Outlook.Application oApp = new Microsoft.Office.Interop.Outlook.Application();
            //Microsoft.Office.Interop.Outlook.MailItem oMsg = (Microsoft.Office.Interop.Outlook.MailItem)oApp.CreateItem(Microsoft.Office.Interop.Outlook.OlItemType.olMailItem);

            //oMsg.Subject = "subject something";
            //oMsg.BodyFormat = Microsoft.Office.Interop.Outlook.OlBodyFormat.olFormatHTML;
            //oMsg.HTMLBody = "text body"; //Here comes your body;
            //oMsg.Attachments.Add("C:\\Temp\\aaa.exe", Microsoft.Office.Interop.Outlook.OlAttachmentType.olByValue, Type.Missing, Type.Missing);
            ////oMsg.Sender = "Habi@duplicatingsystems.com";
            //oMsg.Display(false); //In order to display it in modal inspector change the argument to true
            ////oMsg.Send();
            backgroundWorker1.RunWorkerAsync();

        }

        private void Open_FrmEmail(string recipients)
        {
            Visible = false;
            FrmEmail frm = new FrmEmail(recipients);
            //frm.FormClosed += Frm_FormClosed;
            frm.ShowDialog();
            Visible = true;
        }

        //private void Frm_FormClosed(object sender, FormClosedEventArgs e)
        //{
        //    foreach (Organization o in ORGS)
        //    {
        //        foreach (Contact c in o.GetContacts())
        //        {
        //            Note note = new Note
        //            {
        //                Contact_Number = c.Contact_Number,
        //                Contact_Name = c.GetContact_Name(),
        //                Type = "Note",
        //                Description = "EMAIL" + Environment.NewLine + "SUBJECT: " + DataStore.VAR_1 + Environment.NewLine + "BODY: " + Environment.NewLine + DataStore.VAR_2,
        //                Salesman_Initials = DataStore.Get_LOGGED_USER().Initials,
        //                Action_Status = "true",
        //                Action_Date = Process.GetCurrent_Time(),
        //                //string temp = Process.GetCurrent_Time();
        //                //Console.WriteLine("Date: " + temp);
        //                Creation_Date = Process.GetCurrent_Time(),
        //                Location = DataStore.Get_LOGGED_USER().Location
        //            };

        //            DataStore.Create_Note_Rest(o, note);
        //        }
        //    }
        //}

        private List<Organization> Get_Selected_Orgs()
        {
            Organization org;
            List<Organization> orgs = new List<Organization>();
            // Get rowguid_list
            foreach (DataGridViewRow oneCell in Organization_Dg.SelectedRows)
            {
                Console.WriteLine("ONECELL: " + Organization_Dg.Rows[oneCell.Index].Cells[0].Value.ToString());
                org = DataStore.Retrieve_ORG(Organization_Dg.Rows[oneCell.Index].Cells[0].Value.ToString());
                orgs.Add(org);
            }
            return orgs;
        }

        private void backgroundWorker1_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            try
            {
                ORGS = Get_Selected_Orgs();
                if (ORGS.Count != 0)
                {
                    DataStore.Retrieve_Orgs_Contacts_All_REST_2(ORGS);
                }

                if (ORGS.Count > 0)
                {
                    // StringBuilder has a better computational time than string
                    B_STR = new StringBuilder();
                    // This dictionary was used to eliminate duplicates efficiently
                    IDictionary<string, int> dict = new Dictionary<string, int>();
                    // Get Recipients emails
                    foreach (Organization o in ORGS)
                    {
                        foreach (Contact c in o.GetContacts())
                        {
                            if (!string.IsNullOrEmpty(c.Email) && !c.Email.Equals("0"))
                            {
                                if (!dict.ContainsKey(c.Email))
                                {
                                    B_STR.Append(c.Email + ";");
                                    dict.Add(c.Email, 1);
                                }

                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, System.ComponentModel.RunWorkerCompletedEventArgs e)
        {
            if (MAILCHIMP)
            {
                if (B_STR.Length != 0)
                {
                    string[] emails = B_STR.Remove(B_STR.Length - 1, 1).ToString().Split(';');
                    foreach (string s in emails)
                    {
                        string response_Str = Process.Subscribe_MailChimp(s);
                        dynamic responseObject = JsonConvert.DeserializeObject(response_Str);
                        if ((responseObject.email != null) && (responseObject.euid != null))
                        {
                            // successful!
                            Console.WriteLine("EMAIL: " + responseObject.email + " - EUID: " + responseObject.euid);
                        }
                        else
                        {
                            string name = responseObject.name;
                            Process.Display_Alert($"Mailchimp Error: {responseObject.name} - {responseObject.email}", false);
                        }
                    }
                    MAILCHIMP = false;
                    B_STR.Clear();
                }
                else
                {
                    Process.Display_Alert("Select an Organization", false);
                }
            }
            else
            {
                // Open Email Form
                if (B_STR.Length == 0)
                {
                    Open_FrmEmail("");
                }
                else
                {
                    Open_FrmEmail(B_STR.Remove(B_STR.Length - 1, 1).ToString());
                }
            }
        }

        private void Theme_Color_Picker()
        {
            ColorDialog MyDialog = new ColorDialog
            {
                // Keeps the user from selecting a custom color.
                AllowFullOpen = false,
                // Allows the user to get help. (The default is false.)
                ShowHelp = true,
                // Sets the initial color select to the current text color.
                Color = Top_Pn.ForeColor
            };

            // Update the text box color if the user clicks OK 
            if (MyDialog.ShowDialog() == DialogResult.OK)
            {
                DataStore.Set_CONFIG_Theme_Color(MyDialog.Color);
                //Process.Save_CONFIG();
                Top_Pn.BackColor = MyDialog.Color;
                Banner_Pn.BackColor = MyDialog.Color;
                Refresh();
            }
        }

        private void Archives_Bt_Click(object sender, EventArgs e)
        {
            string tmp = null;
            if (!string.IsNullOrWhiteSpace(SELECTED_ORG_ROWGUID))
            {
                tmp = SELECTED_ORG_ROWGUID;
            }
            FrmQuoteArchive frm = new FrmQuoteArchive(tmp)
            {
                StartPosition = FormStartPosition.Manual,
                Left = Cursor.Position.X - 400,
                Top = Cursor.Position.Y - 150
            };
            frm.Show();
        }

        private void Clear_Grids_Bt_Click(object sender, EventArgs e)
        {
            DataStore.Clear_ORGS();
            Load_ORGS();
            DataStore.Clear_SEARCHED_CONTACT();
            Contact_Dg.Rows.Clear();
        }

        private void Contact_Delete_Bt_Click(object sender, EventArgs e)
        {

        }

        private void MailChimp_Bt_Click(object sender, EventArgs e)
        {
            MAILCHIMP = true;
            backgroundWorker1.RunWorkerAsync();
        }

        private void Items_Bt_Click(object sender, EventArgs e)
        {
            Visible = false;
            FrmMachine frm = new FrmMachine();
            frm.ShowDialog();
            Visible = true;
        }
    }
}
