using DSI_CRM.Models;
using DSI_CRM.Service;
using DSI_CRM.Services;
using System;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace DSI_CRM
{
    internal partial class FrmNotes : Form
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

        private Contact T_contact;
        private readonly Organization T_org;

        public FrmNotes(Organization org)
        {
            InitializeComponent();
            FormBorderStyle = FormBorderStyle.None;
            if (DataStore.Get_Theme_CONFIG())
            {
                Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 20, 20));
                Top_Pn.BackColor = DataStore.Get_CONFIG_Theme_Color();
                Banner_Pn.BackColor = DataStore.Get_CONFIG_Theme_Color();
                Bottom_Pn.BackColor = DataStore.Get_CONFIG_Theme_Color();
                //FrmNotes.DefaultBackColor = Color.DimGray;
            }
            Top_Pn.MouseDown += Mouse_Down;
            Banner_Pn.MouseDown += Mouse_Down;

            T_org = org;
            if (org.GetContacts().Count > 0)
            {
                T_contact = org.GetContacts()[0];
            }
            else
            {
                T_contact = null;
            }
            Org_Name_Lb.Text = T_org.Name;

            DataStore.Retrieve_Notes_Rest(T_org);
            Draw_Notes_Helper();

            foreach (Contact c in T_org.GetContacts())
            {
                Contact_Cb.Items.Add(c.Last_Name);
                Console.WriteLine("C name: " + c.Last_Name);
                Console.WriteLine("C number: " + c.Contact_Number);
            }
            Contact_Cb.SelectedIndexChanged += new System.EventHandler(Contact_Cb_SelectedIndexChanged);

            // TO DEL
            //DataStore.LOGGED_USER = new User("HAB", "Habi", "Sand", "pwd", "Athens");
        }

        public FrmNotes(Organization org, Contact contact)
        {
            InitializeComponent();
            FormBorderStyle = FormBorderStyle.None;
            Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 20, 20));
            Top_Pn.MouseDown += Mouse_Down;
            Banner_Pn.MouseDown += Mouse_Down;

            T_org = org;
            T_contact = contact;
            Org_Name_Lb.Text = T_org.Name;
            int index = 0;

            DataStore.Retrieve_Notes_Rest(T_org);
            Draw_Notes();

            int x = 0;
            foreach (Contact c in T_org.GetContacts())
            {
                Contact_Cb.Items.Add(c.Last_Name);
                Console.WriteLine("Added: " + c.Last_Name);
                if (c.Last_Name.Equals(T_contact.Last_Name))
                {
                    index = x;
                }
                x++;
            }

            Contact_Cb.SelectedIndex = index;
            Contact_Cb.SelectedIndexChanged += new System.EventHandler(Contact_Cb_SelectedIndexChanged);
        }

        private void Contact_Cb_SelectedIndexChanged(object sender, EventArgs e)
        {
            FlpNotes_Pn.Controls.Clear();
            ComboBox comboBox = (ComboBox)sender;
            string selected_contact = (string)comboBox.SelectedItem;
            Console.WriteLine(selected_contact);
            foreach (Contact contact in T_org.GetContacts())
            {
                Console.WriteLine("Last name: " + contact.Last_Name);
                if (contact.Last_Name.Equals(selected_contact))
                {
                    T_contact = contact;
                    //Console.WriteLine("Contact_Name: " + contact.Last_Name);
                    //Console.WriteLine("Contact_Number: " + contact.Contact_Number);
                    FlpNotes_Pn.Controls.Clear();
                    Draw_Notes();
                    break;
                }
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

        private void Minimize_Bt_Click(object sender, EventArgs e)
        {

        }

        private void Save_Bt_Click(object sender, EventArgs e)
        {
            string selected_contact = (string)Contact_Cb.SelectedItem;
            Console.WriteLine("Str: " + selected_contact);
            if (selected_contact != null)
            {
                if (!string.IsNullOrWhiteSpace(Input_Tb.Text))
                {
                    Note note = new Note
                    {
                        Contact_Number = T_contact.Contact_Number,
                        Contact_Name = T_contact.GetContact_Name(),
                        Type = "Note",
                        Description = Input_Tb.Text,
                        Salesman_Initials = DataStore.Get_LOGGED_USER().Initials,
                        Action_Status = "true",
                        Action_Date = Process.GetCurrent_Time(),
                        //string temp = Process.GetCurrent_Time();
                        //Console.WriteLine("Date: " + temp);
                        Creation_Date = Process.GetCurrent_Time(),
                        Location = DataStore.Get_LOGGED_USER().Location
                    };

                    DataStore.Create_Note_Rest(T_org, note);
                    T_org.AddNote(note);
                    Draw_Note(sender, e, note.Description, note.Creation_Date);
                    Input_Tb.Text = "";
                }
            }
            else
            {
                //Process.Display_Alert("Select a Contact First", false);
                if (!string.IsNullOrWhiteSpace(Input_Tb.Text))
                {
                    Note note = new Note
                    {
                        Contact_Number = "",
                        Contact_Name = T_org.Name,
                        Type = "Note",
                        Description = Input_Tb.Text,
                        Salesman_Initials = DataStore.Get_LOGGED_USER().Initials,
                        Action_Status = "true",
                        Action_Date = Process.GetCurrent_Time(),
                        //string temp = Process.GetCurrent_Time();
                        //Console.WriteLine("Date: " + temp);
                        Creation_Date = Process.GetCurrent_Time(),
                        Location = DataStore.Get_LOGGED_USER().Location
                    };

                    DataStore.Create_Note_Rest(T_org, note);
                    T_org.AddNote(note);
                    Draw_Note(sender, e, note.Description, note.Creation_Date);
                    Input_Tb.Text = "";
                }
            }
        }

        private void Draw_Note(object sender, EventArgs e, string note, string time)
        {
            Draw_Note_Helper(note, time);
        }

        private void Draw_Note_Helper(string note, string time)
        {
            TextBox tb = new TextBox
            {
                Multiline = true,
                Size = new Size(415, 70),
                Text = note
            };
            //Input_Tb.Text = "";

            Label lb = new Label
            {
                Width = 250,
                Text = time
            };

            FlowLayoutPanel flp = new FlowLayoutPanel
            {
                Size = new Size(430, 100)
            };
            flp.Controls.Add(tb);
            flp.Controls.Add(lb);
            FlpNotes_Pn.Controls.Add(flp);
        }

        private void Draw_Notes()
        {
            if (T_contact != null)
            {
                foreach (Note note in T_org.GetNote())
                {
                    if (note.Contact_Number.Equals(T_contact.Contact_Number))
                    {
                        Draw_Note_Helper(note.Description, note.Creation_Date);
                    }
                }
            }

            Console.WriteLine("Notes: " + T_org.GetNote().Count);
        }

        private void Draw_Notes_Helper()
        {
            foreach (Note note in T_org.GetNote())
            {
                Draw_Note_Helper(note.Description, note.Creation_Date);
            }
        }

        private void Close_Bt_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void Top_Pn_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
