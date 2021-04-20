using DSI_CRM.Models;
using DSI_CRM.Service;
using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace DSI_CRM
{
    public partial class FrmProcess_Quote : Form
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

        private readonly Quote QUOTE;

        public FrmProcess_Quote(Quote quote)
        {
            InitializeComponent();

            QUOTE = quote;
            pictureBox1.Visible = false;

            FormBorderStyle = FormBorderStyle.None;
            if (DataStore.Get_Theme_CONFIG())
            {
                Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 20, 20));
                //panel2.BackColor = DataStore.Get_CONFIG_Theme_Color();
            }
            panel2.MouseDown += Mouse_Down;
        }

        private void Mouse_Down(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }

        private void label18_Click(object sender, EventArgs e)
        {

        }

        private void Save_Bt_Click(object sender, EventArgs e)
        {
            panel1.Visible = false;
            pictureBox1.Visible = true;
            Continue_Bt.Visible = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void flowLayoutPanel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void backgroundWorker1_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {

        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, System.ComponentModel.RunWorkerCompletedEventArgs e)
        {

        }
    }
}
