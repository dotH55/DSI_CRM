using DSI_CRM.Models;
using DSI_CRM.Service;
using DSI_CRM.Services;
using System;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace DSI_CRM
{
    public partial class FrmCreateMachine : Form
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

        public string Return_Value { get; set; }

        public FrmCreateMachine()
        {
            InitializeComponent();

            Init_Page();

            Return_Value = null;
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
            Machine_Dg.CellDoubleClick += Machine_Dg_CellDoubleClick;
        }

        private void Machine_Dg_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            Return_Value = Machine_Dg.Rows[e.RowIndex].Cells[0].Value.ToString();
            if (string.IsNullOrEmpty(Return_Value))
            {
                Close();
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
        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);

            Continue_Bt.Visible = false;
            Indicator_Pn.Visible = false;
            Machine_Dg.Visible = false;
            Size = new Size(705, 171);
            Refresh();
        }

        private bool Validate_Fields()
        {
            if (string.IsNullOrEmpty(Item_Number_Tb.Text))
            {
                return false;
            }
            else if (Item_Number_Tb.Text.Contains("="))
            {
                Process.Display_Alert("Item_Number contains an illegal character", false);
                return false;
            }
            else if (string.IsNullOrEmpty(Description_Tb.Text))
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        private void Create_Bt_Click(object sender, EventArgs e)
        {
            if (Validate_Fields())
            {
                DataStore.Retrieve_Machines_Dup(Item_Number_Tb.Text, Description_Tb.Text);
                Draw_Machines_Dup();
                Continue_Bt.Visible = true;
                Indicator_Pn.Visible = true;
                Machine_Dg.Visible = true;
                Size = new Size(705, 430);
                Refresh();
            }
        }

        private void Draw_Machines_Dup()
        {
            Machine_Dg.Rows.Clear();
            foreach (MachineDup m in DataStore.Get_Machine_Dup())
            {
                Machine_Dg.Rows.Add(m.Item_Number, m.Description);
            }
        }

        private void Continue_Bt_Click(object sender, EventArgs e)
        {
            try
            {

                Return_Value = DataStore.Create_Machine_REST(Item_Number_Tb.Text);

                Machine m = new Machine()
                {
                    Machine_Number = (int)long.Parse(Return_Value),
                    Description = Description_Tb.Text
                };

                DataStore.Update_Machine_REST(m);
            }
            catch (Exception ex)
            {
                Process.Display_Alert(ex.Message, false);
                Close();
            }

        }

        private void Close_Bt_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
