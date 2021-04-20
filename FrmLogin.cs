using DSI_CRM.Models;
using DSI_CRM.Service;
using Syroot.Windows.IO;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;

namespace DSI_CRM
{
    public partial class FrmLogin : Form
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


        public FrmLogin()
        {
            InitializeComponent();

            // Init Path Variables
            Init_Frm();

            if (DataStore.CHECK_NET())
            {
                DataStore.Retrieve_User_REST();
                Error_Lb.Visible = false;
            }
            else
            {
                Error_Lb.Visible = true;
                Login_Bt.BackColor = Color.Black;
                Login_Bt.Enabled = false;
            }

        }

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);

            try
            {
                try
                {
                    Username_Tb.Text = DataStore.Get_Username_Config();
                    Password_Tb.Text = DataStore.Get_Password_Config();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }


        private void Init_Frm()
        {
            FormBorderStyle = FormBorderStyle.None;
            Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 20, 20));
            Top_Pn.MouseDown += Mouse_Down;
            panel1.MouseDown += Mouse_Down;
            panel3.MouseDown += Mouse_Down;
            Username_Tb.KeyDown += Password_Tb_KeyDown;
            Password_Tb.KeyDown += Password_Tb_KeyDown;
        }


        private void Password_Tb_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                Login_Bt_Click_Helper(sender, e);
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

        private void Login_Bt_Click(object sender, EventArgs e)
        {
            Login_Bt_Click_Helper(sender, e);
        }

        private void Login_Bt_Click_Helper(object sender, EventArgs e)
        {
            try
            {
                Error_Lb.Text = "";
                Error_Lb.Visible = false;
                if (!string.IsNullOrWhiteSpace(Username_Tb.Text) && !string.IsNullOrWhiteSpace(Password_Tb.Text))
                {
                    if (DataStore.Verify_User(Username_Tb.Text, Password_Tb.Text))
                    {
                        panel3.Visible = true;
                        panel1.Visible = false;
                        // Start background worker
                        backgroundWorker1.RunWorkerAsync();
                        // Save Credenttials
                        if (Save_Credentials.Checked)
                        {
                            DataStore.Set_Username_Password_Config(Username_Tb.Text, Password_Tb.Text);
                        }
                    }
                    else
                    {
                        Error_Lb.Text = "Error: Incorrect Crudentials!";
                        Error_Lb.Visible = true;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("*****************************Error: " + ex.Message);
            }

        }

        private void Terminate_Bt_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            FrmMain frm = new FrmMain();
            Hide();
            frm.Show();
        }

        /// <summary>
        /// This method is in charge of retrieving all necessary data
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            DataStore.Retrieve_COUNTIES();
            Thread.Sleep(200);

            DataStore.Retrieve_Tags_REST(new Organization(), new Contact());
            Thread.Sleep(200);

            DataStore.Retrieve_Leasing_Companies_REST();
            Thread.Sleep(200);
        }

    }
}
