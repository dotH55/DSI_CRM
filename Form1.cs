using DSI_CRM.Service;
using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace DSI_CRM
{
    public partial class Form1 : Form
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

        public Form1()
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
            //webBrowser1.Navigate(@"H:\AUGUSTA.net\Credentials_Download.pdf");
            //webBrowser1.Navigate(@"C:/Users/Doth55/Documents/About.html");
            //string html = File.ReadAllText(@"C:\Users\habi.DUPLICATINGSYST\Documents\Web.html");


            //webBrowser1.DocumentText = File.ReadAllText(@"C:\Users\habi.DUPLICATINGSYST\Documents\Web.html");


            //PdfDocument pdf = PdfGenerator.GeneratePdf(@html, PageSize.A4);
            //pdf.Save("C:/Users/Doth55/Documents/Web.pdf");

            //string html = File.ReadAllText("input.htm");
            //PdfDocument pdf = PdfGenerator.GeneratePdf(html, PageSize.Letter);
            //pdf.Save("document.pdf");
            webBrowser1.DocumentText = getStr();
            webBrowser1.Navigating +=
                new WebBrowserNavigatingEventHandler(webBrowser1_Navigating);
            //webBrowser1.Navigate("https://developers.google.com/calendar/quickstart/dotnet");
            //String openPDFFile = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + @"\Credentials_Download.pdf";//PDF DOc name
            //System.IO.File.WriteAllBytes(openPDFFile, global::DSI_CRM.Properties.Resources.Credentials_Download.pdf);//the resource automatically creates            
            //System.Diagnostics.Process.Start(openPDFFile);

        }

        private string getStr()
        {
            string temp = "<html>" +

                "<body>Please enter your name:<br/>" +
                            "<input type='text' name='userName'/><br/>" +
                                "<a href='http://www.microsoft.com'>continue</a>" +
                                "</body>" +
                                "</html>";
            return temp;
        }

        private void webBrowser1_Navigating(object sender, WebBrowserNavigatingEventArgs e)
        {
            System.Windows.Forms.HtmlDocument document =
                webBrowser1.Document;

            if (document != null && document.All["userName"] != null &&
                string.IsNullOrEmpty(
                document.All["userName"].GetAttribute("value")))
            {
                e.Cancel = true;
                System.Windows.Forms.MessageBox.Show(
                    "You must enter your name before you can navigate to " +
                    e.Url.ToString());
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

        private void Form1_Load(object sender, System.EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Close_Bt_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void Minimize_Bt_Click(object sender, EventArgs e)
        {

        }

        private void Resize_Bt_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
            //webBrowser1.Print();
            //webBrowser1.
            //webBrowser1.DocumentContent = YOUR_FILE_NAME;
            //mshtml.IHTMLDocument2 doc = webBrowser1.Document as mshtml.IHTMLDocument2;
            //doc.execCommand("Print", true, null);
            //using TheArtOfDev.HtmlRenderer.PdfSharp.PdfGenerator;

            //string html = File.ReadAllText(@"C:\Users\habi.DUPLICATINGSYST\Documents\Web.html");
            //PdfDocument pdf = PdfGenerator.GeneratePdf(html, PageSize.Letter);
            //pdf.Save("C:\\Users\\habi.DUPLICATINGSYST\\Documents\\document.pdf");

            //PdfDocument pdf = PdfGenerator.GeneratePdf("<p><h1>Hello World</h1>This is html rendered text</p>", PageSize.A4);
            //pdf.Save("document.pdf");
        }
    }
}
