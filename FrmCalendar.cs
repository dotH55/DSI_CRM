using DSI_CRM.Models;
using DSI_CRM.Service;
using DSI_CRM.Services;
using Google.Apis.Calendar.v3.Data;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace DSI_CRM
{
    public partial class FrmCalendar : Form
    {
        // habi@duplicatingsystems.com
        // Client ID
        // 320921495390-2gckig9sf1vthvm7et58rdjq1qp5hnjt.apps.googleusercontent.com
        // Client Secret
        // uxdNuFVzwKjpFBEbiQwMLXRy
        // credentials_1.json

        // shabils56@gmail.com
        // Client ID
        // 113367659772-v3r2o2siq8tf68cg63s3nts8agf614hg.apps.googleusercontent.com
        // Client Secret
        // OtpkEOWl0i2n0dMS3LyfLpXN
        // credentials_2.json


        private readonly List<FlowLayoutPanel> Days;
        private static DateTime Current_Date;
        private static Events EVENTS = null;

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

        public FrmCalendar()
        {
            InitializeComponent();

            Init_Page();
            // Initialize Variables
            Days = new List<FlowLayoutPanel>();
            Current_Date = DateTime.Today;
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
        }

        private void Mouse_Down(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }

        private void Display_Current_Date()
        {
            Current_Date_Lb.Text = Current_Date.ToString("MMMM, yyyy");
            int first_Day = GetMonth_First_Day();
            int total_Days = GetMonth_Total_Day();
            Add_Day_Label(first_Day, total_Days);

        }

        private void Display_Previous_Date()
        {
            Current_Date = Current_Date.AddMonths(-1);
            Display_Current_Date();
        }

        private void Display_Next_Date()
        {
            Current_Date = Current_Date.AddMonths(1);
            Display_Current_Date();
        }

        private void Display_Today_Date()
        {
            Current_Date = DateTime.Today;
            Display_Current_Date();
        }

        private void Generate_Day_Panel(int total_Days)
        {
            FPDays.Controls.Clear();
            Days.Clear();
            for (int i = 1; i <= total_Days; i++)
            {
                FlowLayoutPanel flp = new FlowLayoutPanel
                {
                    Name = $"flpDay{i}",
                    Size = new Size(128, 128),
                    BackColor = Color.White,
                    BorderStyle = BorderStyle.FixedSingle,
                    AutoScroll = true,
                    Cursor = Cursors.Hand,
                    Tag = i.ToString()
                };
                flp.Click += AddNewAppointment;
                //https://www.youtube.com/watch?v=6T3xnIS8UH8
                // 50:47
                //flp.BackColor = Color.Silver;
                FPDays.Controls.Add(flp);
                Days.Add(flp);
            }
        }

        private void Add_Day_Label(int start_Day, int month_Days)
        {
            foreach (FlowLayoutPanel flp in Days)
            {
                flp.Controls.Clear();
                flp.Tag = 0;
                flp.BackColor = Color.White;
            }

            for (int i = 1; i <= month_Days; i++)
            {
                Label lb = new Label
                {
                    Name = $"lbDay{i}",
                    AutoSize = false,
                    TextAlign = ContentAlignment.MiddleRight,
                    Size = new Size(120, 23),
                    Text = i.ToString(),
                    Font = new Font("Tahoma", 14)
                };

                //Days[(i - 1) + (start_Day - 1)].Controls.Clear();
                Days[(i - 1) + (start_Day - 1)].Tag = i;
                Days[(i - 1) + (start_Day - 1)].Controls.Add(lb);

                if (new DateTime(Current_Date.Year, Current_Date.Month, i) == DateTime.Today)
                {
                    Days[(i - 1) + (start_Day - 1)].BackColor = Color.Aqua;
                }
            }
            AddTask();
        }

        private int GetMonth_First_Day()
        {
            DateTime dt = new DateTime(Current_Date.Year, Current_Date.Month, 1);
            return (int)(dt.DayOfWeek + 1);
        }

        private int GetMonth_Total_Day()
        {
            DateTime dt = new DateTime(Current_Date.Year, Current_Date.Month, 1);
            return dt.AddMonths(1).AddDays(-1).Day;
        }

        private void GetEvents()
        {
            try
            {
                // Get events.
                EVENTS = Process.Retrieve_Events();
            }
            catch (Exception)
            {
                Process.Display_Alert("Error: Missing Credentials", false);
            }
        }

        private void AddTask()
        {
            try
            {
                foreach (Event eventItem in EVENTS.Items)
                {

                    if (Current_Date.Month == eventItem.Start.DateTime.Value.Month)
                    {
                        LinkLabel lb = new LinkLabel
                        {
                            Name = eventItem.Id
                        };
                        lb.Font = Font = new Font("Tahoma", 8);
                        lb.Click += ShowAppointment;
                        lb.Text = eventItem.Summary;
                        Days[eventItem.Start.DateTime.Value.Day - 1 + (GetMonth_First_Day() - 1)].Controls.Add(lb);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private void AddNewAppointment(object sender, EventArgs e)
        {
            try
            {
                FlowLayoutPanel flp = (FlowLayoutPanel)sender;
                int x = (int)flp.Tag;
                FrmTask_ frm = new FrmTask_(new Organization(), new DateTime(Current_Date.Year, Current_Date.Month, x));
                frm.FormClosed += FrmTask_FormClosed;
                frm.ShowDialog();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private void FrmTask_FormClosed(object sender, FormClosedEventArgs e)
        {
            Today_Bt_Helper();
        }

        private void ShowAppointment(object sender, EventArgs e)
        {
            LinkLabel lb = (LinkLabel)sender;
            string id = lb.Name;
            FrmTask frm = new FrmTask(GetLinkedLabelDateTime(id), GetLinkedLabelTitle(id), GetLinkedLabelTask(id), id);
            frm.FormClosed += Frm_FormClosed;
            frm.ShowDialog();
        }

        private void Frm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Today_Bt_Helper();
        }

        private DateTime GetLinkedLabelDateTime(string lb_Id)
        {
            if (EVENTS.Items != null)
            {
                foreach (Event eventItem in EVENTS.Items)
                {

                    if (eventItem.Id.Equals(lb_Id))
                    {
                        return eventItem.Start.DateTime.Value;
                    }
                }
            }
            return new DateTime();
        }

        private string GetLinkedLabelTitle(string lb_Id)
        {
            string str = "";
            if (EVENTS.Items != null && EVENTS.Items.Count > 0)
            {
                foreach (Event eventItem in EVENTS.Items)
                {
                    if (eventItem.Id.Equals(lb_Id))
                    {
                        str = eventItem.Summary + ";" + eventItem.ETag;
                    }
                }
            }
            return str;
        }


        private string GetLinkedLabelTask(string lb_Id)
        {
            string str = "";
            if (EVENTS.Items != null && EVENTS.Items.Count > 0)
            {
                foreach (Event eventItem in EVENTS.Items)
                {
                    if (eventItem.Id.Equals(lb_Id))
                    {
                        str = eventItem.Description;
                    }
                }
            }
            return str;
        }


        private void FrmCalendar_Load(object sender, EventArgs e)
        {
            Generate_Day_Panel(42);
            GetEvents();
            Add_Day_Label(GetMonth_First_Day(), GetMonth_Total_Day());
            Display_Current_Date();
        }

        private void Close_Bt_Click_1(object sender, EventArgs e)
        {
            Close();
        }

        private void Previous_Bt_Click_1(object sender, EventArgs e)
        {
            Display_Previous_Date();
        }

        private void Today_Bt_Click_2(object sender, EventArgs e)
        {
            Today_Bt_Helper();
        }

        private void Today_Bt_Helper()
        {
            GetEvents();
            Display_Current_Date();
        }

        private void Next_Bt_Click_2(object sender, EventArgs e)
        {
            Display_Next_Date();
        }

        private void Top_Pn_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }
    }
}
