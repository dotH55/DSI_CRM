using DSI_CRM.Models;
using DSI_CRM.Service;
using DSI_CRM.Services;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace DSI_CRM
{
    public partial class FrmScreen : Form
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

        [DllImport("user32.dll", CharSet = CharSet.Unicode)]
        public static extern int MessageBox(IntPtr hWnd, string text, string caption, uint type);

        private List<TextBox> TB_List;

        private List<Org> temp_Org;
        private Organization ORG;
        private Address ADDR;
        public FrmScreen()
        {
            InitializeComponent();

            Init_Page();


        }

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);

            Dup_Pn.Visible = false;
            Size = new System.Drawing.Size(988, 295);
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
            Dup_Dg.CellDoubleClick += Data_Grid_Doubled_Clicked;

            TB_List = new List<TextBox>
            {
                Name_Tb,
                Phone_Tb,
                Address_1_Tb,
                Address_2_Tb,
                City_Tb,
                State_Tb,
                Zip_Tb,
                County_Tb
            };

            foreach (TextBox t in TB_List)
            {
                if (t != County_Tb)
                {
                    t.GotFocus += Process.TB_Got_Focus; ;
                    t.LostFocus += Process.TB_Lost_Focus;
                }
            }

            County_Tb.LostFocus += County_Tb_LostFocus;
            County_Tb.KeyDown += County_Tb_KeyDown;

            County_Tb.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            County_Tb.AutoCompleteSource = AutoCompleteSource.CustomSource;
            County_Tb.AutoCompleteCustomSource = Process.Generate_Counties_Auto_Complet();

            //Name_Tb.GotFocus += Process.TB_Got_Focus;
            //Name_Tb.LostFocus += Process.TB_Lost_Focus;

            //Phone_Tb.GotFocus += Process.TB_Got_Focus;
            //Phone_Tb.LostFocus += Process.TB_Lost_Focus;

            //Address_1_Tb.GotFocus += Process.TB_Got_Focus;
            //Address_1_Tb.LostFocus += Process.TB_Lost_Focus;

            //Address_2_Tb.GotFocus += Process.TB_Got_Focus;
            //Address_2_Tb.LostFocus += Process.TB_Lost_Focus;

            //City_Tb.GotFocus += Process.TB_Got_Focus;
            //City_Tb.LostFocus += Process.TB_Lost_Focus;

            //State_Tb.GotFocus += Process.TB_Got_Focus;
            //State_Tb.LostFocus += Process.TB_Lost_Focus;

            //Zip_Tb.GotFocus += Process.TB_Got_Focus;
            //Zip_Tb.LostFocus += Process.TB_Lost_Focus;



        }

        private void County_Tb_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                County_Tb_LostFocus(sender, e);
            }
        }

        private void County_Tb_LostFocus(object sender, EventArgs e)
        {
            TextBox tb = (TextBox)sender;
            tb.Text = tb.Text.ToUpper();
            if (DataStore.Get_Counties_Dict().ContainsKey(tb.Text))
            {
                State_Tb.Text = DataStore.Get_Counties_Dict()[tb.Text];
            }
            else
            {
                tb.Text = "";
                State_Tb.Text = "";
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

        private void Data_Grid_Doubled_Clicked(object sender, DataGridViewCellEventArgs e)
        {
            Organization org = DataStore.Get_ORG_REST(temp_Org[e.RowIndex].Organization_Number);
            FrmOrganization frm = new FrmOrganization(org);
            frm.ShowDialog();
            //this.Close();

        }

        private void Create_Bt_Click(object sender, EventArgs e)
        {
            Indicator_Pn.Visible = false;
            if (Process.Check_TB(TB_List))
            {
                Dup_Dg.Rows.Clear();
                ORG = new Organization(Name_Tb.Text, Phone_Tb.Text);
                string str = "";
                if (!Address_2_Tb.Text.Equals((string)Address_2_Tb.Tag))
                {
                    str = Address_2_Tb.Text;
                }
                ADDR = new Address(Address_1_Tb.Text, str, City_Tb.Text, State_Tb.Text, Zip_Tb.Text, County_Tb.Text);
                temp_Org = DataStore.Screen_Org_REST(ORG, ADDR);

                if (temp_Org.Count == 0)
                {
                    Create_New();
                }
                else
                {
                    Dup_Pn.Visible = true;
                    foreach (Org org_ in temp_Org)
                    {
                        Dup_Dg.Rows.Add(new string[] { org_.Reason, org_.Organization_Number, org_.Name, org_.Phone, org_.Address_1, org_.Address_2, org_.City });
                    }
                    Continue_Bt.Visible = true;
                    Indicator_Pn.Visible = true;
                    Size = new System.Drawing.Size(988, 618);
                }
            }
        }

        private void Create_New()
        {
            string str = DataStore.Create_Org_REST(ORG, ADDR);
            if (str != null)
            {
                ORG.Organization_Number = Regex.Replace(str, "[^0-9]", "");
                ORG.AddAddress(ADDR);
                // Minor Fix
                ORG.rowguid = null;
                FrmOrganization frm = new FrmOrganization(ORG);
                frm.ShowDialog();
                Close();
            }
            else
            {
                Process.Display_Alert("Unable to create a new Org #", false);
            }
        }

        private void Close_Bt_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void Continue_Bt_Click(object sender, EventArgs e)
        {
            Create_New();
        }

        private void County_Tb_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
