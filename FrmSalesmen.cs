using DSI_CRM.Service;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace DSI_CRM
{
    public partial class FrmSalesmen : Form
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


        public FrmSalesmen()
        {
            InitializeComponent();

            // 
            FormBorderStyle = FormBorderStyle.None;
            Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 20, 20));
            if (DataStore.Get_Theme_CONFIG())
            {
                Salesman_Pn.BackColor = DataStore.Get_CONFIG_Theme_Color();
                flowLayoutPanel1.BackColor = DataStore.Get_CONFIG_Theme_Color();
            }

            // Add EventHandlers
            Salesman_Pn.MouseDown += Mouse_Down;
            flp_Pn.MouseDown += Mouse_Down;
            LostFocus += new EventHandler(Lost_Focus);
            All_Cb.CheckedChanged += All_Cb_CheckedChanged;
        }

        private void All_Cb_CheckedChanged(object sender, EventArgs e)
        {
            bool all_State = ((CheckBox)sender).Checked;
            foreach (CheckBox c in flp_Pn.Controls)
            {
                c.Checked = all_State;
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

        private void Lost_Focus(object sender, EventArgs e)

        {
            Close();
            Console.WriteLine("I lost focus");

        }

        private void FrmFilter_Load(object sender, EventArgs e)
        {

        }

        private void flowLayoutPanel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Ok_Bt_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void Close_Page_Bt_Click(object sender, EventArgs e)
        {
            List<string> salesmen = new List<string>();
            foreach (CheckBox c in flp_Pn.Controls)
            {
                if (c.Checked && !c.Text.Equals("All"))
                {
                    salesmen.Add((string)c.Tag);
                }
            }
            //Console.WriteLine("[{0}]", string.Join(", ", salesmen));
            DataStore.Set_SELECTED_USERS(salesmen);
            Close();
        }

        private void Salesman_Pn_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}
