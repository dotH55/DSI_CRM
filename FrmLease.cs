using DSI_CRM.Models;
using DSI_CRM.Service;
using DSI_CRM.Services;
using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace DSI_CRM
{
    public partial class FrmLease : Form
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

        private static LeasingCompany LEASING_COMPANY;

        public FrmLease()
        {
            InitializeComponent();

            Init_Page();

            LEASING_COMPANY = new LeasingCompany();
        }

        private void Init_Page()
        {
            FormBorderStyle = FormBorderStyle.None;
            Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 20, 20));
            if (DataStore.Get_Theme_CONFIG())
            {
                Banner_Pn.BackColor = DataStore.Get_CONFIG_Theme_Color();
            }

            //Top_Pn.MouseDown += Mouse_Down;
            Banner_Pn.MouseDown += Mouse_Down;
            Leasing_Company_Tb.KeyDown += Leasing_Company_Tb_KeyDown;

            Setup_Auto_Complete();
        }

        private void Setup_Auto_Complete()
        {
            Leasing_Company_Tb.AutoCompleteMode = AutoCompleteMode.Suggest;
            Leasing_Company_Tb.AutoCompleteSource = AutoCompleteSource.CustomSource;
            Leasing_Company_Tb.AutoCompleteCustomSource = Process.Generate_Leasing_Company_Auto_Complet();
        }

        private void Leasing_Company_Tb_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                bool found = false;
                foreach (LeasingCompany L in DataStore.Get_Leasing_Companies())
                {
                    if (L.Name.ToUpper().Equals(Leasing_Company_Tb.Text.ToUpper()))
                    {
                        LEASING_COMPANY = L;
                        Populate();
                        found = true;
                    }
                }

                if (!found)
                {
                    FrmAlert frm = new FrmAlert("Create a New Leasing Company?", true)
                    {
                        StartPosition = FormStartPosition.CenterScreen
                    };
                    DialogResult result = frm.ShowDialog();
                    if (result == DialogResult.Yes)
                    {
                        // New Leasing Company
                        Add_Helper();
                        //Add_Bt.Enabled = false;
                    }
                }
            }
        }

        private void Populate()
        {
            Buyout_1_Rate_Tb.Text = LEASING_COMPANY.Dollar_24_Rate;
            Buyout_2_Rate_Tb.Text = LEASING_COMPANY.Dollar_36_Rate;
            Buyout_3_Rate_Tb.Text = LEASING_COMPANY.Dollar_48_Rate;
            Buyout_4_Rate_Tb.Text = LEASING_COMPANY.Dollar_60_Rate;
            FMV_1_Rate_Tb.Text = LEASING_COMPANY.FMV_24_Rate;
            FMV_2_Rate_Tb.Text = LEASING_COMPANY.FMV_36_Rate;
            FMV_3_Rate_Tb.Text = LEASING_COMPANY.FMV_48_Rate;
            FMV_4_Rate_Tb.Text = LEASING_COMPANY.FMV_60_Rate;
        }

        private void Save_Bt_Click(object sender, EventArgs e)
        {
            if (Validate_Tb())
            {
                LEASING_COMPANY.Name = Leasing_Company_Tb.Text;
                LEASING_COMPANY.Dollar_24_Rate = Buyout_1_Rate_Tb.Text;
                LEASING_COMPANY.Dollar_36_Rate = Buyout_2_Rate_Tb.Text;
                LEASING_COMPANY.Dollar_48_Rate = Buyout_3_Rate_Tb.Text;
                LEASING_COMPANY.Dollar_60_Rate = Buyout_4_Rate_Tb.Text;
                LEASING_COMPANY.FMV_24_Rate = FMV_1_Rate_Tb.Text;
                LEASING_COMPANY.FMV_36_Rate = FMV_2_Rate_Tb.Text;
                LEASING_COMPANY.FMV_48_Rate = FMV_3_Rate_Tb.Text;
                LEASING_COMPANY.FMV_60_Rate = FMV_4_Rate_Tb.Text;

                if (LEASING_COMPANY.rowguid == null)
                {
                    DataStore.Create_Leasing_Company_REST(LEASING_COMPANY);
                }
                else
                {
                    DataStore.Update_Leasing_Companies_REST(LEASING_COMPANY);
                }

                Close();
            }
        }

        private bool Validate_Tb()
        {
            if (string.IsNullOrEmpty(Leasing_Company_Tb.Text) || !Process.IsNumeric(Leasing_Company_Tb.Text))
            {
                Process.Display_Alert("Invalid Leasing Company", false);
                return false;
            }
            else if (string.IsNullOrEmpty(Buyout_1_Rate_Tb.Text) || !Process.IsNumeric(Buyout_1_Rate_Tb.Text))
            {
                Process.Display_Alert("Invalid Buyout 1 Rate", false);
                return false;
            }
            else if (string.IsNullOrEmpty(Buyout_2_Rate_Tb.Text) || !Process.IsNumeric(Buyout_2_Rate_Tb.Text))
            {
                Process.Display_Alert("Invalid Buyout 2 Rate", false);
                return false;
            }
            else if (string.IsNullOrEmpty(Buyout_3_Rate_Tb.Text) || !Process.IsNumeric(Buyout_3_Rate_Tb.Text))
            {
                Process.Display_Alert("Invalid Buyout 3 Rate", false);
                return false;
            }
            else if (string.IsNullOrEmpty(Buyout_4_Rate_Tb.Text) || !Process.IsNumeric(Buyout_4_Rate_Tb.Text))
            {
                Process.Display_Alert("Invalid Buyout 4", false);
                return false;
            }
            else if (string.IsNullOrEmpty(FMV_1_Rate_Tb.Text) || !Process.IsNumeric(FMV_1_Rate_Tb.Text))
            {
                Process.Display_Alert("Invalid FMV 1 Rate", false);
                return false;
            }
            else if (string.IsNullOrEmpty(FMV_2_Rate_Tb.Text) || !Process.IsNumeric(FMV_2_Rate_Tb.Text))
            {
                Process.Display_Alert("Invalid FMV 2 Rate", false);
                return false;
            }
            else if (string.IsNullOrEmpty(FMV_3_Rate_Tb.Text) || !Process.IsNumeric(FMV_3_Rate_Tb.Text))
            {
                Process.Display_Alert("Invalid FMV 3 Rate", false);
                return false;
            }
            else if (string.IsNullOrEmpty(FMV_4_Rate_Tb.Text) || !Process.IsNumeric(FMV_4_Rate_Tb.Text))
            {
                Process.Display_Alert("Invalid FMV 4 Rate", false);
                return false;
            }
            else
            {
                return true;
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

        private void Close_Bt_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void Resize_Bt_Click(object sender, EventArgs e)
        {

        }



        private void Add_Helper()
        {
            LEASING_COMPANY = new LeasingCompany();
            Populate();
        }

        private void Cancel_Tb_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void label18_Click(object sender, EventArgs e)
        {

        }
    }
}
