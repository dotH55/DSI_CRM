using DSI_CRM.Models;
using DSI_CRM.Service;
using DSI_CRM.Services;
using Google.Apis.Calendar.v3.Data;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using Task = DSI_CRM.Models.Task;

namespace DSI_CRM
{
    public partial class FrmTask_ : Form
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

        private static Organization ORG;
        private static Contact CONTACT;
        private static List<Task> TASK_TO_DISABLED;

        public FrmTask_(Organization org, DateTime dt)
        {
            InitializeComponent();

            Init_Page();
            //Init_User_Task();

            ORG = org;
            if (ORG.rowguid == null)
            {
                Org_Tb.Enabled = false;
                Org_Lb.Enabled = false;
                Contact_Lb.Enabled = false;
                Contact_Cb.Enabled = false;
            }
            else
            {
                Init_Cbs(Contact_Cb);
                Init_Cbs(Notes_Cb);
                Init_Cbs(Reminder_Cb);
                Init_Cbs(User_Task_Cb);
                Org_Tb.Text = ORG.Name;
            }

            Start_Dtp.Value = dt;
            End_Dtp.Value = dt;
        }

        private void Init_Cbs(ComboBox cb)
        {
            cb.Items.Clear();
            foreach (Contact c in ORG.GetContacts())
            {
                cb.Items.Add(c.GetContact_Name());
            }
        }

        private void Init_User_Task()
        {
            User_Tasks_Dg.Rows.Clear();
            List<Task> list = DataStore.Get_User_Task_REST();
            foreach (Task t in list)
            {
                User_Tasks_Dg.Rows.Add(t.rowguid, t.Task_Number, t.Task_Event.Summary, t.Task_Event.Description, t.Task_Event.Created, 0);
            }
        }

        private void Contact_Cb_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox cb = (ComboBox)sender;
            CONTACT = ORG.GetContacts()[cb.SelectedIndex];
        }

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);

            Remind_Me_Dtp.Enabled = false;
            Start_Dtp.Enabled = false;
            End_Dtp.Enabled = false;
            Summary_Tb.Enabled = false;
            Full_Description_Tb.Enabled = false;
            Save_Bt.Enabled = false;
            Contact_Cb.Enabled = false;
        }

        private void Init_Page()
        {
            FormBorderStyle = FormBorderStyle.None;
            Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 20, 20));
            if (DataStore.Get_Theme_CONFIG())
            {
                Top_Pn.BackColor = DataStore.Get_CONFIG_Theme_Color();
            }
            Top_Pn.MouseDown += Mouse_Down;
            Banner_Pn.MouseDown += Mouse_Down;
            Type_Cb.SelectedValueChanged += Type_Cb_SelectedValueChanged;

            ORG = new Organization();
            CONTACT = new Contact();
            TASK_TO_DISABLED = new List<Task>();

            Contact_Cb.SelectedIndexChanged += Contact_Cb_SelectedIndexChanged;
            Task_Pn.Selected += Task_Pn_Selected;
            Notes_Cb.SelectedIndexChanged += Cb_SelectedIndexChanged;
            Reminder_Cb.SelectedIndexChanged += Cb_SelectedIndexChanged;

            Start_Dtp.CustomFormat = "hh:mm tt dddd MMMM dd, yyyy";
            End_Dtp.CustomFormat = "hh:mm tt dddd MMMM dd, yyyy";
            Remind_Me_Dtp.CustomFormat = "hh:mm tt dddd MMMM dd, yyyy";
        }

        private void Cb_SelectedIndexChanged(object sender, EventArgs e)
        {
            Clear_Flp();
            ComboBox cb = (ComboBox)sender;
            foreach (Task t in ORG.Get_Tasks())
            {
                if (t.Contact_Number.Equals(Get_Contact_Number(cb.Text)) && t.Type.Equals((string)cb.Tag))
                {
                    Draw_Task(t, (string)cb.Tag);
                }
            }
        }

        private void Clear_Flp()
        {
            Flp_Pn.Controls.Clear();
            Reminder_Flp_Pn.Controls.Clear();
            User_Tasks_Dg.Rows.Clear();
        }

        private string Get_Contact_Number(string contact_Name)
        {
            string contact_Number = "";
            foreach (Contact c in ORG.GetContacts())
            {
                if (c.GetContact_Name().Equals(contact_Name))
                {
                    contact_Number = c.Contact_Number;
                }
            }
            return contact_Number;
        }

        private void Task_Pn_Selected(object sender, TabControlEventArgs e)
        {
            // Clear
            Clear_Flp();
            TabControl tab = (TabControl)sender;
            foreach (Task t in ORG.Get_Tasks())
            {
                if (t.Type.Equals((string)tab.SelectedTab.Tag))
                {
                    //Console.WriteLine("PANEL: " + "[" + (string)tab.Tag + "]" );
                    Draw_Task(t, (string)tab.SelectedTab.Tag);
                }
            }
        }

        private void Draw_Task(Task task, string panel)
        {
            TextBox tb = new TextBox
            {
                Multiline = true,
                Size = new Size(1000, 100),
                Text = "[" + task.Task_Event.Summary + "]" + Environment.NewLine + task.Task_Event.Summary
            };
            //Input_Tb.Text = "";

            Label lb = new Label
            {
                Width = 250,
                Text = task.Task_Event.Created.ToString()
            };

            FlowLayoutPanel flp = new FlowLayoutPanel
            {
                Size = new Size(1040, 130)
            };
            flp.Controls.Add(tb);
            flp.Controls.Add(lb);

            if (panel.Equals("NOTE"))
            {
                Flp_Pn.Controls.Add(flp);
            }
            else if (panel.Equals("REMINDER"))
            {
                Reminder_Flp_Pn.Controls.Add(flp);
            }
        }

        private void Type_Cb_SelectedValueChanged(object sender, EventArgs e)
        {
            ComboBox cb = (ComboBox)sender;
            Console.WriteLine(cb.Text);
            if (cb.Text.Equals("NOTE"))
            {
                Remind_Me_Dtp.Enabled = false;
                Start_Dtp.Enabled = false;
                End_Dtp.Enabled = false;
                Summary_Tb.Enabled = true;
                Full_Description_Tb.Enabled = true;
                Save_Bt.Enabled = true;
                Remind_Me_Lb.Visible = false;
                Remind_Me_Dtp.Visible = false;
                Contact_Cb.Enabled = true;

                if (ORG.rowguid == null)
                {
                    Contact_Cb.Enabled = false;
                    Summary_Tb.Enabled = false;
                    Full_Description_Tb.Enabled = false;
                }
            }
            else if (cb.Text.Equals("REMINDER"))
            {
                Remind_Me_Dtp.Enabled = true;
                Start_Dtp.Enabled = true;
                End_Dtp.Enabled = true;
                Summary_Tb.Enabled = true;
                Full_Description_Tb.Enabled = true;
                Save_Bt.Enabled = true;

                Remind_Me_Lb.Visible = true;
                Remind_Me_Dtp.Visible = true;
                Contact_Cb.Enabled = true;
                if (ORG.rowguid == null)
                {
                    Contact_Cb.Enabled = false;
                }
            }
            else if (cb.Text.Equals("LEASE_END_DATE"))
            {
                Remind_Me_Dtp.Enabled = true;
                Start_Dtp.Enabled = true;
                End_Dtp.Enabled = true;
                Summary_Tb.Enabled = true;
                Full_Description_Tb.Enabled = true;
                Save_Bt.Enabled = true;

                Remind_Me_Lb.Visible = true;
                Remind_Me_Dtp.Visible = true;
                Contact_Cb.Enabled = true;

                if (ORG.rowguid == null)
                {
                    Contact_Cb.Enabled = false;
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

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void Close_Bt_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Resize_Bt_Click(object sender, EventArgs e)
        {
        }

        private void Cancel_Bt_Click(object sender, EventArgs e)
        {
            //Console.WriteLine("SELECTED INDEX" + Contact_Cb.SelectedIndex);
            Close();
        }

        private void Save_Bt_Click_1(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(Summary_Tb.Text))
            {
                Process.Display_Alert("Missing Summary", true);
                return;
            }
            else if (string.IsNullOrWhiteSpace(Full_Description_Tb.Text))
            {
                Process.Display_Alert("Missing Summary", true);
                return;
            }
            else
            {
                Task task = new Task
                {
                    Type = Type_Cb.Text,
                    Salesman_Initials = DataStore.Get_LOGGED_USER().Initials
                };
                DateTime dt = DateTime.Now;


                if (Type_Cb.Text.Equals("NOTE"))
                {
                    if (ORG.rowguid == null)
                    {
                        Process.Display_Alert("Select an Organization first!", true);
                        return;
                    }
                    task.Status = "1";
                    EventDateTime start = new EventDateTime { DateTime = dt };
                    EventDateTime end = new EventDateTime { DateTime = dt };
                    task.Task_Event = new Event { Created = dt, Start = start, End = end, Description = Full_Description_Tb.Text, Summary = Summary_Tb.Text };
                }
                else if (Type_Cb.Text.Equals("REMINDER"))
                {
                    task.Status = "0";
                    EventDateTime start = new EventDateTime { DateTime = Start_Dtp.Value };
                    EventDateTime end = new EventDateTime { DateTime = End_Dtp.Value };
                    task.Task_Event = new Event { Created = dt, Start = start, End = end, Description = Full_Description_Tb.Text, Summary = "RMD: " + Summary_Tb.Text };
                    // Calendar Entry
                    Process.Create_Event(task.Task_Event);

                    if (Remind_Me_Dtp.Value != DateTime.Now)
                    {
                        EventDateTime start_ = new EventDateTime { DateTime = Remind_Me_Dtp.Value };
                        EventDateTime end_ = new EventDateTime { DateTime = Remind_Me_Dtp.Value };
                        Event ev = new Event { Created = dt, Start = start_, End = end_, Description = Full_Description_Tb.Text, Summary = "RMD: " + Summary_Tb.Text };
                        Process.Create_Event(ev);
                    }
                }
                else if (Type_Cb.Text.Equals("LEASE_END_DATE"))
                {
                    task.Status = "0";
                    EventDateTime start = new EventDateTime { DateTime = Start_Dtp.Value };
                    EventDateTime end = new EventDateTime { DateTime = End_Dtp.Value };
                    task.Task_Event = new Event { Created = dt, Start = start, End = end, Description = Full_Description_Tb.Text, Summary = "LED: " + Summary_Tb.Text };
                    // Calendar Entry
                    Process.Create_Event(task.Task_Event);

                    if (Remind_Me_Dtp.Value != DateTime.Now)
                    {
                        EventDateTime start_ = new EventDateTime { DateTime = Remind_Me_Dtp.Value };
                        EventDateTime end_ = new EventDateTime { DateTime = Remind_Me_Dtp.Value };
                        Event ev = new Event { Created = dt, Start = start_, End = end_, Description = Full_Description_Tb.Text, Summary = "LED: " + Summary_Tb.Text };
                        Process.Create_Event(ev);
                    }
                }

                task.Task_Event.ETag = task.rowguid;

                if (CONTACT.rowguid == null)
                {
                    task.Contact_Number = "-1";
                }
                else
                {
                    task.Contact_Number = CONTACT.Contact_Number;
                }

                if (ORG.rowguid != null)
                {
                    task.Org_Number = ORG.Organization_Number;
                    task.Org_Name = ORG.Name;
                    DataStore.Create_Task_REST(task);
                }
            }
            Close();
        }

        private void Close_Bt__Click(object sender, EventArgs e)
        {
            Close();
        }

        private void Disabled_Task_Bt_Click(object sender, EventArgs e)
        {
            try
            {
                foreach (DataGridViewRow r in User_Tasks_Dg.Rows)
                {
                    if (r.Cells[5].Value.Equals(true))
                    {
                        DataStore.Disabled_Task_REST((string)r.Cells[0].Value);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            Init_User_Task();
        }

        private void Minimize_Bt_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }
    }
}
