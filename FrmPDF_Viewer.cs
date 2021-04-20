using DSI_CRM.Service;
using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace DSI_CRM
{
    public partial class FrmPDF_Viewer : Form
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

        public FrmPDF_Viewer(string path)
        {
            InitializeComponent();
            FormBorderStyle = FormBorderStyle.None;
            Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 20, 20));
            if (DataStore.Get_Theme_CONFIG())
            {
                Top_Pn.BackColor = DataStore.Get_CONFIG_Theme_Color();
            }
            Top_Pn.MouseDown += Mouse_Down;

            //Opens a URL in the default browser
            //IntPtr result = (IntPtr)ShellExecute(0, "open", @"H:\AUGUSTA.net\Credentials_Download.pdf", "", "", 1);
            webBrowser1.Navigate(path);
            //webBrowser1.Navigate("https://developers.google.com/calendar/quickstart/dotnet");
            //String openPDFFile = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + @"\Credentials_Download.pdf";//PDF DOc name
            //System.IO.File.WriteAllBytes(openPDFFile, global::DSI_CRM.Properties.Resources.Credentials_Download.pdf);//the resource automatically creates            
            //System.Diagnostics.Process.Start(openPDFFile);
        }

        private void Mouse_Down(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }

        private void Minimize_Bt_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void Close_Bt_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
