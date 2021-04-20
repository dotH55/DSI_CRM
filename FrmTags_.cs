using DSI_CRM.Models;
using DSI_CRM.Service;
using DSI_CRM.Services;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;

namespace DSI_CRM
{
    internal partial class FrmTags_ : Form
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

        public StringBuilder SELECTED_TAGS;
        public bool Return_Tag_Number;

        public FrmTags_(bool flag)
        {
            InitializeComponent();
            Init_Page();
            Return_Tag_Number = flag;
        }




        private void Init_Page()
        {
            FormBorderStyle = FormBorderStyle.None;
            Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 20, 20));
            if (DataStore.Get_Theme_CONFIG())
            {
                Top_Pn.BackColor = DataStore.Get_CONFIG_Theme_Color();
                Bottom_Pn.BackColor = DataStore.Get_CONFIG_Theme_Color();
                New_Tag_Pn.BackColor = DataStore.Get_CONFIG_Theme_Color();
            }
            Top_Pn.MouseDown += Mouse_Down;
            New_Tag_Tb.GotFocus += Process.TB_Got_Focus;
            New_Tag_Tb.LostFocus += Process.TB_Lost_Focus;
            Draw_Tags();
        }

        private void Mouse_Down(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }

        private void FrmSalesmen_Load(object sender, EventArgs e)
        {

        }

        private void Ok_Bt_Click(object sender, EventArgs e)
        {

        }

        private void Tag_Add_New(object sender, EventArgs e)
        {
            if (!New_Tag_Tb.Text.ToString().Equals("New Tag") && !New_Tag_Tb.Text.ToString().Equals(""))
            {
                Tag t = new Tag((New_Tag_Tb.Text).Replace(" ", "_"), DataStore.Get_LOGGED_USER().Initials);
                CheckBox cb = new CheckBox
                {
                    Text = t.Name
                };
                flp_Pn.Controls.Add(cb);
                DataStore.Create_Tags_REST(t);
                New_Tag_Tb.Text = (string)New_Tag_Tb.Tag;
            }
            DataStore.Retrieve_Tags_REST(new Organization(), new Contact());
            Draw_Tags();
            flp_Pn.Refresh();
            flp_Pn.Update();
            Refresh();
        }

        private void Draw_Tags()
        {
            flp_Pn.Controls.Clear();
            foreach (KeyValuePair<string, string> k in DataStore.Get_Tags_Dict())
            {
                CheckBox cb = new CheckBox
                {
                    Text = k.Key,
                    Tag = k.Value,
                };
                cb.Width = 300;
                //cb.AutoSize = true;
                flp_Pn.Controls.Add(cb);
            }
            Refresh();
        }

        private void Close_Frm()
        {
            DialogResult = DialogResult.Yes;
            SELECTED_TAGS = new StringBuilder();
            foreach (CheckBox c in flp_Pn.Controls)
            {
                if (c.Checked)
                {
                    if (Return_Tag_Number)
                    {
                        SELECTED_TAGS.Append(c.Text + "|");
                    }
                    else
                    {
                        SELECTED_TAGS.Append(c.Tag + "|");
                    }
                }
            }

            if (SELECTED_TAGS.Length > 0)
            {
                SELECTED_TAGS.Remove(SELECTED_TAGS.Length - 1, 1);
            }
            Close();
        }


        private void OK_Tag_Bt_Click(object sender, EventArgs e)
        {
            Close_Frm();
        }

        private void New_Tag_Bt_Click(object sender, EventArgs e)
        {
            if (!New_Tag_Tb.Text.ToString().Equals("New Tag") && !New_Tag_Tb.Text.ToString().Equals(""))
            {
                Tag t = new Tag((New_Tag_Tb.Text).Replace(" ", "_"), DataStore.Get_LOGGED_USER().Initials);
                CheckBox cb = new CheckBox
                {
                    Text = t.Name
                };
                flp_Pn.Controls.Add(cb);
                DataStore.Create_Tags_REST(t);
                New_Tag_Tb.Text = (string)New_Tag_Tb.Tag;
            }
            DataStore.Retrieve_Tags_REST(new Organization(), new Contact());
            Draw_Tags();
            flp_Pn.Refresh();
            flp_Pn.Update();
            Refresh();
        }

        private void Reset_Bt_Click_1(object sender, EventArgs e)
        {
            foreach (CheckBox c in flp_Pn.Controls)
            {
                if (c.Checked)
                {
                    c.Checked = false;
                }
            }
        }

        private void Add_Tag_Bt_Click_1(object sender, EventArgs e)
        {
            Process.Accordion_2(sender, e, New_Tag_Pn);
        }

        private void Close_Page_Bt_Click_1(object sender, EventArgs e)
        {
            Close_Frm();
        }

        private void Top_Pn_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
