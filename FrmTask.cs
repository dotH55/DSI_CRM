using DSI_CRM.Service;
using DSI_CRM.Services;
using System;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace DSI_CRM
{
    public partial class FrmTask : Form
    {

        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;

        [DllImportAttribute("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [DllImportAttribute("user32.dll")]
        public static extern bool ReleaseCapture();

        private readonly string EVENT_ID;
        private readonly string ETAG;

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

        public FrmTask(DateTime dt)
        {
            InitializeComponent();
            FormBorderStyle = FormBorderStyle.None;
            if (DataStore.Get_Theme_CONFIG())
            {
                Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 20, 20));
                Top_Pn.BackColor = DataStore.Get_CONFIG_Theme_Color();
            }

            Top_Pn.MouseDown += Mouse_Down;

            Date_Dt.Value = dt;
            EVENT_ID = null;
            Delete_Bt.Visible = false;
            Save_Bt.Visible = true;
        }

        public FrmTask(DateTime dt, string title, string task, string ID)
        {
            InitializeComponent();
            FormBorderStyle = FormBorderStyle.None;
            Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 20, 20));
            if (DataStore.Get_Theme_CONFIG())
            {
                Top_Pn.BackColor = Color.DimGray;
            }

            Top_Pn.MouseDown += Mouse_Down;

            Date_Dt.Value = dt;
            string[] str = title.Split(';');
            Title_Tb.Text = str[0];
            ETAG = str[1];
            Task_Tb.Text = task;
            Save_Bt.Visible = false;
            EVENT_ID = ID;


            Delete_Bt.Visible = true;
            Save_Bt.Visible = true;
        }

        private void Mouse_Down(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }

        private void Save_Bt_Click(object sender, EventArgs e)
        {
            //Process.Create_Entry(Date_Dt.Value, Title_Tb.Text, Task_Tb.Text);
            if (!string.IsNullOrWhiteSpace(Title_Tb.Text) && !string.IsNullOrWhiteSpace(Task_Tb.Text))
            {
                DataStore.Update_Task_REST(ETAG, Title_Tb.Text, Task_Tb.Text);
                Process.Update_Event(EVENT_ID, Title_Tb.Text, Task_Tb.Text);
            }
            Close();
        }

        private void Close_Bt_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void Delete_Bt_Click_1(object sender, EventArgs e)
        {
            try
            {
                if (EVENT_ID != null)
                {
                    DataStore.Disabled_Task_REST(ETAG);
                    Process.Delete_Event(EVENT_ID);
                    Close();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            Close();
        }
    }
}
