using DSI_CRM.Models;
using DSI_CRM.Service;
using DSI_CRM.Services;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace DSI_CRM
{
    public partial class FrmQuoteArchive : Form
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

        private static List<Quote> QUOTES;
        private static string QUOTE_NUMBER;
        private static string ORG_ROWGUID;

        public FrmQuoteArchive(string rowguid)
        {
            InitializeComponent();
            FormBorderStyle = FormBorderStyle.None;
            Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 20, 20));
            if (DataStore.Get_Theme_CONFIG())
            {
                Top_Pn_.BackColor = DataStore.Get_CONFIG_Theme_Color();
                Top_Pn.BackColor = DataStore.Get_CONFIG_Theme_Color();
            }
            Top_Pn_.MouseDown += Mouse_Down;
            Top_Pn.MouseDown += Mouse_Down;

            Quote_Number_Tb.KeyDown += Quote_Number_Tb_KeyDown;
            Quote_Number_Tb.GotFocus += Process.Got_Focus_Main;
            Quote_Number_Tb.LostFocus += Process.Lost_Focus_Main;
            Org_Name_Tb.KeyDown += Quote_Number_Tb_KeyDown;
            Org_Name_Tb.GotFocus += Process.Got_Focus_Main;
            Org_Name_Tb.LostFocus += Process.Lost_Focus_Main;
            Contact_Name_Tb.KeyDown += Quote_Number_Tb_KeyDown;
            Contact_Name_Tb.GotFocus += Process.Got_Focus_Main;
            Contact_Name_Tb.LostFocus += Process.Lost_Focus_Main;

            Quotes_Dg.CellDoubleClick += Quotes_Dg_DoubleClick;
            Quotes_Dg.CellClick += Quotes_Dg_CellClick;

            ORG_ROWGUID = rowguid;
        }

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);

            if (ORG_ROWGUID != null)
            {
                Organization o = DataStore.Get_ORG_rowguid_REST(ORG_ROWGUID);
                Org_Name_Tb.Text = o.Name;
                Key_Down_Helper();
            }
        }

        private void Quotes_Dg_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1)
            {
                return;
            }
            QUOTE_NUMBER = (string)Quotes_Dg.Rows[e.RowIndex].Cells[1].Value;
        }

        private void Quotes_Dg_DoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1)
            {
                return;
            }
            QUOTE_NUMBER = (string)Quotes_Dg.Rows[e.RowIndex].Cells[1].Value;
            Get_Quote();
        }

        private void Get_Quote()
        {
            try
            {
                Quote quote = DataStore.Get_Quote_Number_REST(QUOTE_NUMBER);
                FrmQuote frm = new FrmQuote(quote);
                frm.Show();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private void Quote_Number_Tb_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                Key_Down_Helper();
            }
        }

        private void Key_Down_Helper()
        {
            // To search quote, pass in zero if there is no quote_Number
            string quote_Number = Quote_Number_Tb.Text;
            if (string.IsNullOrWhiteSpace(quote_Number) || quote_Number.Equals((string)Quote_Number_Tb.Tag))
            {
                quote_Number = "0";
            }
            string org = Org_Name_Tb.Text;
            if (org.Equals((string)Org_Name_Tb.Tag))
            {
                org = "";
            }

            string contact = Contact_Name_Tb.Text;
            if (contact.Equals((string)Contact_Name_Tb.Tag))
            {
                contact = "";
            }

            try
            {
                QUOTES = DataStore.Search_Quote_REST(quote_Number, org, contact);
                Draw_Quotes();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private void Draw_Quotes()
        {
            Quotes_Dg.Rows.Clear();
            foreach (Quote q in QUOTES)
            {
                Quotes_Dg.Rows.Add(q.rowguid, q.Quote_Number, q.Org_Name, q.Contact_Name, q.Created_Datetime);
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

        private void Save_Bt_Click(object sender, EventArgs e)
        {
            Close();
        }


        private void Edit_Bt_Click_1(object sender, EventArgs e)
        {
            Get_Quote();
        }

        private void Cancel_Bt_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void Copy_Bt_Click_1(object sender, EventArgs e)
        {
            //foreach (Quote q in QUOTES)
            //{
            //    if (q.rowguid.Equals(ROWGUID))
            //    {
            //        Quote quote = JsonConvert.DeserializeObject<Quote>(q.Quote_Obj_Json);
            //        quote.rowguid = Guid.NewGuid().ToString();
            //        quote.Quote_Number = DataStore.Create_Quote_REST(quote.Org_Number);
            //        DataStore.Update_Quote_REST(quote);
            //        FrmQuote frm = new FrmQuote(quote);
            //    }
            //}

            Visible = false;
            FrmSelectOrgC frm = new FrmSelectOrgC();
            frm.ShowDialog();
            Visible = true;
        }

        private void Quotes_Dg_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Close_Bt_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
