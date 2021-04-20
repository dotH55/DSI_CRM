using DSI_CRM.Models;
using DSI_CRM.Service;
using DSI_CRM.Services;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Mail;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;

namespace DSI_CRM
{
    public partial class FrmEmail : Form
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

        private static List<string> ATTACHMENTS;

        public FrmEmail(string to)
        {
            InitializeComponent();

            Init_Page();

            ATTACHMENTS = new List<string>();
            Recipient_Tb.Text = to;
            Email_Tb.Text = DataStore.Get_Email_Config();
            Password_Tb.Text = DataStore.Get_Password_Config();
        }

        private void Init_Page()
        {
            // Border
            FormBorderStyle = FormBorderStyle.None;
            Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 20, 20));
            if (DataStore.Get_Theme_CONFIG())
            {
                Top_Pn.BackColor = DataStore.Get_CONFIG_Theme_Color();
            }
            // Add EventHandlers
            Top_Pn.MouseDown += Mouse_Down;
            Email_Tb.GotFocus += Process.TB_Got_Focus;
            Email_Tb.LostFocus += Process.TB_Lost_Focus;

            Recipient_Tb.GotFocus += Process.TB_Got_Focus;
            Recipient_Tb.LostFocus += Process.TB_Lost_Focus;

            Subject_Tb.GotFocus += Process.TB_Got_Focus;
            Subject_Tb.LostFocus += Process.TB_Lost_Focus;

            Body_Tb.GotFocus += Process.TB_Got_Focus;
            Body_Tb.LostFocus += Process.TB_Lost_Focus;
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
            Close();
        }

        private void First_Name_Tb_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void First_Name_Lb_Click(object sender, EventArgs e)
        {

        }

        private void Send_Bt_Click(object sender, EventArgs e)
        {
            Send_Bt_Helper_2();
        }

        private void Send_Bt_Helper_1()
        {
            if (string.IsNullOrWhiteSpace(Email_Tb.Text) || Email_Tb.Text.Equals(Email_Tb.Tag)
                || string.IsNullOrWhiteSpace(Password_Tb.Text) || Password_Tb.Text.Equals(Password_Tb.Tag)
                || string.IsNullOrWhiteSpace(Recipient_Tb.Text) || Recipient_Tb.Text.Equals(Recipient_Tb.Tag)
                || string.IsNullOrWhiteSpace(Subject_Tb.Text) || Subject_Tb.Text.Equals(Subject_Tb.Tag)
                || string.IsNullOrWhiteSpace(Body_Tb.Text))
            {
                Process.Display_Alert("Error: Missing Fields", true);
            }
            else
            {
                Hide();
                Thread thread = new Thread(new ParameterizedThreadStart(param => { Send_Email_ThreadProc(); }));
                thread.SetApartmentState(ApartmentState.STA);
                thread.Start();
            }
        }

        private bool Check_Textbox()
        {
            //if (string.IsNullOrWhiteSpace(Email_Tb.Text) || Email_Tb.Text.Equals(Email_Tb.Tag))
            //{
            //    Process.Display_Alert("Missing: Email", true);
            //    return false;
            //}
            //else if(string.IsNullOrWhiteSpace(Password_Tb.Text) || Password_Tb.Text.Equals(Password_Tb.Tag))
            //{
            //    Process.Display_Alert("Missing: Password", true);
            //    return false;
            //}
            if (string.IsNullOrWhiteSpace(Recipient_Tb.Text) || Recipient_Tb.Text.Equals(Recipient_Tb.Tag))
            {
                Process.Display_Alert("Missing: Recipient", true);
                return false;
            }
            else if (string.IsNullOrWhiteSpace(Subject_Tb.Text) || Subject_Tb.Text.Equals(Subject_Tb.Tag))
            {
                Process.Display_Alert("Missing: Subject", true);
                return false;
            }
            else if (string.IsNullOrWhiteSpace(Body_Tb.Text))
            {
                Process.Display_Alert("Missing: Body", true);
                return false;
            }
            else
            {
                return true;
            }
        }

        private void Send_Bt_Helper_2()
        {
            if (Check_Textbox())
            {
                System.Diagnostics.Process.Start(Environment_Var.Get_GMAIL_URL(Recipient_Tb.Text, Subject_Tb.Text, Body_Tb.Text));
                DataStore.VAR_1 = Subject_Tb.Text;
                DataStore.VAR_2 = Body_Tb.Text;
                Close();
            }
        }

        private void Send_Email_ThreadProc()
        {
            try
            {
                SmtpClient client = new SmtpClient()
                {
                    Host = "smtp.gmail.com",
                    Port = 587,
                    EnableSsl = true,
                    DeliveryMethod = SmtpDeliveryMethod.Network,
                    UseDefaultCredentials = false,
                    Credentials = new NetworkCredential()
                    {
                        UserName = Email_Tb.Text,
                        Password = Password_Tb.Text
                    }
                };

                MailMessage mail = new MailMessage()
                {
                    From = new MailAddress(Email_Tb.Text, DataStore.Get_LOGGED_USER().First_Name + " " + DataStore.Get_LOGGED_USER().Last_Name),
                    Subject = Subject_Tb.Text,
                    Body = Body_Tb.Text
                };

                // Attachment
                foreach (string s in ATTACHMENTS)
                {
                    mail.Attachments.Add(new Attachment(s));
                }

                // Recipients
                string[] temp = Recipient_Tb.Text.Split(';');
                for (int i = 0; i < temp.Length; i++)
                {
                    mail.To.Add(new MailAddress(temp[i]));
                }

                // Send Mail
                client.Send(mail);

                // Save Credentials
                DataStore.Set_Email_Config(Email_Tb.Text, Password_Tb.Text);
                Process.Save_Configuration();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private void Attach_Bt_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog
            {
                Multiselect = true
            };
            DialogResult dialogResult = dialog.ShowDialog();
            if (dialogResult == System.Windows.Forms.DialogResult.OK)
            {
                ATTACHMENTS = new List<string>();
                foreach (string s in dialog.FileNames)
                {
                    ATTACHMENTS.Add(s);
                }
                Draw_Attachments();
            }
        }

        private void Draw_Attachments()
        {
            Attachment_Flp.Controls.Clear();
            foreach (string s in ATTACHMENTS)
            {
                LinkLabel lb = new LinkLabel
                {
                    Text = s.Substring(s.LastIndexOf("\\") + 1),
                    Tag = s,
                    //BorderStyle = BorderStyle.FixedSingle
                };
                lb.LinkClicked += Lb_LinkClicked;
                lb.AutoSize = true;
                Attachment_Flp.Controls.Add(lb);
            }
            Attach_Count_Lb.Text = ATTACHMENTS.Count.ToString();
        }

        private void Lb_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                LinkLabel lb = (LinkLabel)sender;
                for (int i = 0; i < ATTACHMENTS.Count; i++)
                {
                    if (ATTACHMENTS[i].Equals(lb.Tag))
                    {
                        ATTACHMENTS.RemoveAt(i);
                    }
                }
                Draw_Attachments();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }
    }
}
