using DSI_CRM.Models;
using DSI_CRM.Service;
using Google.Apis.Auth.OAuth2;
using Google.Apis.Calendar.v3;
using Google.Apis.Calendar.v3.Data;
using Google.Apis.Services;
using Google.Apis.Util.Store;
using MailChimp.Net;
using MailChimp.Net.Interfaces;
using MailChimp.Net.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using Contact = DSI_CRM.Models.Contact;
using Tag = DSI_CRM.Models.Tag;

namespace DSI_CRM.Services
{
    internal static class Process
    {

        //DateTime localDate = DateTime.Now;
        //DateTime utcDate = DateTime.UtcNow;
        //String[] cultureNames = { "en-US", "en-GB", "fr-FR",
        //                        "de-DE", "ru-RU" };
        //Console.WriteLine("{0}:", culture.NativeName);
        // Console.WriteLine("   Local date and time: {0}, {1:G}",
        //                   localDate.ToString(culture), localDate.Kind);

        [DllImport("KERNEL32.DLL", EntryPoint = "RtlZeroMemory")]
        public static extern bool ZeroMemory(IntPtr Destination, int Length);

        private static readonly string[] SCOPES = { CalendarService.Scope.CalendarEvents };
        private static readonly string APPLICATION_NAME = "Google Calendar API .NET Quickstart";
        private static CalendarService SERVICE;
        private static readonly string CALENDAR_ID = "primary";

        // by default, const are static

        private const string FILE_NAME = "Config.json";
        private const string ENCRYPTED_FILE = "Config.json.aes";
        private const string DECRYPPTED_FILE = "Config.json";
        private const string PWD = "ThePasswordToDecryptAndEncryptTheFile_DSI_CRM";

        public static string Read_SHA()
        {
            // For additional security Pin the password of your files
            GCHandle gch = GCHandle.Alloc(PWD, GCHandleType.Pinned);

            if (File_Exist(DECRYPPTED_FILE))
            {
                File.Delete(Path.Combine(Environment_Var.Get_ROOT_FOLDER(), DECRYPPTED_FILE));
            }
            // Decrypt the file
            FileDecrypt(Path.Combine(Environment_Var.Get_ROOT_FOLDER(), ENCRYPTED_FILE), Path.Combine(Environment_Var.Get_ROOT_FOLDER(), DECRYPPTED_FILE), PWD);

            // To increase the security of the decryption, delete the used password from the memory !
            ZeroMemory(gch.AddrOfPinnedObject(), PWD.Length * 2);
            gch.Free();

            // You can verify it by displaying its value later on the console (the password won't appear)
            //Console.WriteLine("The given password is surely nothing: " + password);
            //DataStore.Read_Configuration();

            string sha = "";
            if (File_Exist(DECRYPPTED_FILE))
            {
                //File.Decrypt(Path.Combine(ROOT_FOLDER, FILE_NAME));
                sha = System.IO.File.ReadAllText(Path.Combine(Environment_Var.Get_ROOT_FOLDER(), DECRYPPTED_FILE));
                //File.Encrypt(Path.Combine(ROOT_FOLDER, FILE_NAME));
                File.Delete(Path.Combine(Environment_Var.Get_ROOT_FOLDER(), DECRYPPTED_FILE));
            }

            return Decode(sha);
        }

        public static void Read_Configuration()
        {
            Create_ROOT_FOLDER();
            // For additional security Pin the password of your files
            GCHandle gch = GCHandle.Alloc(PWD, GCHandleType.Pinned);

            if (File_Exist(DECRYPPTED_FILE))
            {
                File.Delete(Path.Combine(Environment_Var.Get_ROOT_FOLDER(), DECRYPPTED_FILE));
            }
            // Decrypt the file
            FileDecrypt(Path.Combine(Environment_Var.Get_ROOT_FOLDER(), ENCRYPTED_FILE), Path.Combine(Environment_Var.Get_ROOT_FOLDER(), DECRYPPTED_FILE), PWD);

            // To increase the security of the decryption, delete the used password from the memory !
            ZeroMemory(gch.AddrOfPinnedObject(), PWD.Length * 2);
            gch.Free();
        }

        public static void Save_Configuration()
        {
            Save_CONFIG();
            //try
            //{


            //    System.IO.File.WriteAllText(Path.Combine(DataStore.Get_ROOT_FOLDER(), FILE_NAME), info);

            //    File.Encrypt("C:/Temp/DSI_CRM/" + FILE_NAME);
            //    string password = "ThePasswordToDecryptAndEncryptTheFile";
            //    For additional security Pin the password of your files
            //   GCHandle gch = GCHandle.Alloc(PWD, GCHandleType.Pinned);

            //    if (File_Exist(ENCRYPTED_FILE))
            //    {
            //        File.Delete(Path.Combine(Environment_Var.Get_ROOT_FOLDER(), ENCRYPTED_FILE));
            //    }
            //    // Encrypt the file
            //    FileEncrypt(Path.Combine(Environment_Var.Get_ROOT_FOLDER(), FILE_NAME), PWD);

            //    // To increase the security of the encryption, delete the given password from the memory !
            //    ZeroMemory(gch.AddrOfPinnedObject(), PWD.Length * 2);
            //    gch.Free();
            //    File.Delete(Path.Combine(Environment_Var.Get_ROOT_FOLDER(), FILE_NAME));
            //}
            //catch (Exception ex)
            //{
            //    Console.WriteLine(ex.Message);
            //}
        }

        /// <summary>
        /// Creates a random salt that will be used to encrypt your file. This method is required on FileEncrypt.
        /// </summary>
        /// <returns>random salt data</returns>
        private static byte[] GenerateRandomSalt()
        {
            byte[] data = new byte[32];
            using (RNGCryptoServiceProvider rng = new RNGCryptoServiceProvider())
            {
                for (int i = 0; i < 10; i++)
                {
                    // Fill the buffer with the generated data
                    rng.GetBytes(data);
                }
            }
            return data;
        }

        /// <summary>
        /// Encrypts a file from its path and a plain password.
        /// </summary>
        /// <param name="inputFile"> Input File: Text file</param>
        /// <param name="password"> Password</param>
        private static void FileEncrypt(string inputFile, string password)
        {
            //http://stackoverflow.com/questions/27645527/aes-encryption-on-large-files

            //generate random salt
            byte[] salt = GenerateRandomSalt();

            //create output file name
            FileStream fsCrypt = new FileStream(inputFile + ".aes", FileMode.Create);

            //convert password string to byte arrray
            byte[] passwordBytes = System.Text.Encoding.UTF8.GetBytes(password);

            //Set Rijndael symmetric encryption algorithm
            RijndaelManaged AES = new RijndaelManaged
            {
                KeySize = 256,
                BlockSize = 128,
                Padding = PaddingMode.Zeros
            };

            //http://stackoverflow.com/questions/2659214/why-do-i-need-to-use-the-rfc2898derivebytes-class-in-net-instead-of-directly
            //"What it does is repeatedly hash the user password along with the salt." High iteration counts.
            Rfc2898DeriveBytes key = new Rfc2898DeriveBytes(passwordBytes, salt, 50000);
            AES.Key = key.GetBytes(AES.KeySize / 8);
            AES.IV = key.GetBytes(AES.BlockSize / 8);

            //Cipher modes: http://security.stackexchange.com/questions/52665/which-is-the-best-cipher-mode-and-padding-mode-for-aes-encryption
            AES.Mode = CipherMode.CFB;

            // write salt to the begining of the output file, so in this case can be random every time
            fsCrypt.Write(salt, 0, salt.Length);

            CryptoStream cs = new CryptoStream(fsCrypt, AES.CreateEncryptor(), CryptoStreamMode.Write);

            FileStream fsIn = new FileStream(inputFile, FileMode.Open);

            //create a buffer (1mb) so only this amount will allocate in the memory and not the whole file
            byte[] buffer = new byte[1048576];
            int read;

            try
            {
                while ((read = fsIn.Read(buffer, 0, buffer.Length)) > 0)
                {
                    Application.DoEvents(); // -> for responsive GUI, using Task will be better!
                    cs.Write(buffer, 0, read);
                }

                // Close up
                fsIn.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
            finally
            {
                cs.Close();
                fsCrypt.Close();
            }
        }

        /// <summary>
        /// Decrypts an encrypted file with the FileEncrypt method through its path and the plain password.
        /// </summary>
        /// <param name="inputFile">Input File: Encrypted File</param>
        /// <param name="outputFile"> Output File: Decrypted File</param>
        /// <param name="password"></param>
        private static void FileDecrypt(string inputFile, string outputFile, string password)
        {
            byte[] passwordBytes = System.Text.Encoding.UTF8.GetBytes(password);
            byte[] salt = new byte[32];

            FileStream fsCrypt = new FileStream(inputFile, FileMode.Open);
            fsCrypt.Read(salt, 0, salt.Length);

            RijndaelManaged AES = new RijndaelManaged
            {
                KeySize = 256,
                BlockSize = 128,
                Padding = PaddingMode.Zeros
            };
            Rfc2898DeriveBytes key = new Rfc2898DeriveBytes(passwordBytes, salt, 50000);
            AES.Key = key.GetBytes(AES.KeySize / 8);
            AES.IV = key.GetBytes(AES.BlockSize / 8);
            //AES.Padding = PaddingMode.PKCS7;
            AES.Mode = CipherMode.CFB;

            CryptoStream cs = new CryptoStream(fsCrypt, AES.CreateDecryptor(), CryptoStreamMode.Read);

            FileStream fsOut = new FileStream(outputFile, FileMode.Create);

            int read;
            byte[] buffer = new byte[1048576];

            try
            {
                while ((read = cs.Read(buffer, 0, buffer.Length)) > 0)
                {
                    Application.DoEvents();
                    fsOut.Write(buffer, 0, read);
                }
            }
            catch (CryptographicException ex_CryptographicException)
            {
                Console.WriteLine("CryptographicException error: " + ex_CryptographicException.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }

            try
            {
                cs.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error by closing CryptoStream: " + ex.Message);
            }
            finally
            {
                fsOut.Close();
                fsCrypt.Close();
            }
        }

        public static void Accordion(object sender, EventArgs e, Panel pn)
        {
            Button button = (Button)sender;
            if (pn.Visible)
            {
                pn.Visible = false;
                button.Image = Properties.Resources.Expand_32px;
            }
            else
            {
                pn.Visible = true;
                button.Image = Properties.Resources.Collapse_32px;
            }
            button.Refresh();
        }

        public static void TB_Lost_Focus(object sender, EventArgs e)
        {
            TextBox tb = (TextBox)sender;
            if (string.IsNullOrWhiteSpace(tb.Text))
            {
                tb.Text = (string)tb.Tag;
            }
        }

        public static void TB_Got_Focus(object sender, EventArgs e)
        {
            TextBox tb = (TextBox)sender;
            if (tb.Text.Equals((string)tb.Tag))
            {
                tb.Text = "";
            }
        }

        public static void Accordion_2(object sender, EventArgs e, Panel pn)
        {
            Button button = (Button)sender;
            if (pn.Visible)
            {
                pn.Visible = false;
                button.Image = Properties.Resources.Expand_24;
            }
            else
            {
                pn.Visible = true;
                button.Image = Properties.Resources.Collapse_24;
            }
            button.Refresh();
        }

        public static void Display_Alert(string message, bool type)
        {
            FrmAlert frm = new FrmAlert(message, type)
            {
                StartPosition = FormStartPosition.Manual,
                Left = Cursor.Position.X - 250,
                Top = Cursor.Position.Y - 50
            };
            frm.ShowDialog();
        }

        private static bool File_Exist(string filename)
        {
            if (File.Exists(Path.Combine(Environment_Var.Get_ROOT_FOLDER(), filename)))
            {
                return true;
            }
            return false;
        }

        private static string Encode(string info)
        {
            string encoded = "DSI";
            foreach (char c in info)
            {
                encoded += c + "DSI";
            }

            return encoded;
        }

        private static string Decode(string encoded)
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 3; i < encoded.Length; i += 4)
            {
                sb.Append(encoded[i]);
            }
            return sb.ToString();
        }

        public static string GetCurrent_Time()
        {
            return DateTime.Now.ToString("f", CultureInfo.CreateSpecificCulture("en-US"));
        }

        public static void Init_Calendar_API()
        {
            UserCredential credential;

            using (FileStream stream =
                new FileStream(@"C:\DSI_CRM\credentials.json", FileMode.Open, FileAccess.Read))
            {
                // The file token.json stores the user's access and refresh tokens, and is created
                // automatically when the authorization flow completes for the first time.
                string credPath = "token" + DataStore.Get_LOGGED_USER().Initials.ToUpper() + ".json";
                credential = GoogleWebAuthorizationBroker.AuthorizeAsync(
                    GoogleClientSecrets.Load(stream).Secrets, SCOPES, "user", CancellationToken.None,
                    new FileDataStore(credPath, true)).Result;
            }

            // Create Google Calendar API service.
            SERVICE = new CalendarService(new BaseClientService.Initializer()
            {
                HttpClientInitializer = credential,
                ApplicationName = APPLICATION_NAME,
            });
        }

        public static Events Retrieve_Events()
        {
            // Init Calendar
            Init_Calendar_API();
            // Define parameters of request.
            EventsResource.ListRequest request = GetService().Events.List("primary");
            request.TimeMin = DateTime.Now;
            request.ShowDeleted = false;
            request.SingleEvents = true;
            request.MaxResults = 20;
            request.OrderBy = EventsResource.ListRequest.OrderByEnum.StartTime;

            // List events.
            return request.Execute();
        }

        public static void Create_Calendar_Entry(DateTime Date_Dt, string summary, string Description)
        {
            if (Exists_File("credentials.json"))
            {
                Init_Calendar_API();
                Create_Entry(Date_Dt, summary, Description);
            }
        }

        public static void Create_Entry(DateTime Date_Dt, string summary, string Description)
        {
            try
            {
                Google.Apis.Calendar.v3.Data.Event ev = new Google.Apis.Calendar.v3.Data.Event();
                EventDateTime start = new EventDateTime
                {
                    DateTime = new DateTime(Date_Dt.Year, Date_Dt.Month, Date_Dt.Day, 11, 0, 0)
                };

                EventDateTime end = new EventDateTime
                {
                    DateTime = new DateTime(Date_Dt.Year, Date_Dt.Month, Date_Dt.Day, 12, 0, 0)
                };

                ev.Start = start;
                ev.End = end;
                ev.Summary = summary;
                ev.Description = Description;
                Google.Apis.Calendar.v3.Data.Event recurringEvent = GetService().Events.Insert(ev, "primary").Execute();
            }
            catch (Exception ex)
            {
                Process.Display_Alert(ex.Message, true);
            }
        }


        public static void Create_Event(Google.Apis.Calendar.v3.Data.Event ev)
        {
            try
            {
                Init_Calendar_API();
                Google.Apis.Calendar.v3.Data.Event recurringEvent = GetService().Events.Insert(ev, "primary").Execute();
            }
            catch (Exception ex)
            {
                Process.Display_Alert(ex.Message, true);
            }
        }


        public static bool Exists_File(string filename)
        {
            return File.Exists(Environment_Var.Get_ROOT_FOLDER() + filename);
        }

        public static CalendarService GetService()
        {
            return SERVICE;
        }

        public static void Delete_Event(string event_ID)
        {
            try
            {
                //Init_Calendar_API();
                SERVICE.Events.Delete(CALENDAR_ID, event_ID).Execute();
            }
            catch (Exception ex)
            {
                Display_Alert(ex.Message, true);
            }
        }

        public static void Update_Event(string event_ID, string summary, string description)
        {
            try
            {
                //Init_Calendar_API();
                Events E = Process.Retrieve_Events();
                foreach (Google.Apis.Calendar.v3.Data.Event e in E.Items)
                {
                    if (e.Id.Equals(event_ID))
                    {
                        e.Summary = summary;
                        e.Description = description;
                        SERVICE.Events.Update(e, CALENDAR_ID, event_ID).Execute();
                    }
                }
            }
            catch (Exception ex)
            {
                Display_Alert(ex.Message, true);
            }
        }

        //public static void create_Event(Event e)
        //{
        //    SERVICE.Events.Insert(e, CALENDAR_ID).Execute();
        //    //Console.WriteLine("Event created: %s\n", e.HtmlLink);
        //}

        public static bool Does_List_Contains(List<Tag> tags, Tag tag)
        {
            foreach (Tag t in tags)
            {
                if (t.rowguid.Equals(tag.rowguid))
                {
                    return true;
                }
            }
            return false;
        }

        public static void Create_ROOT_FOLDER()
        {
            try
            {
                if (!Directory.Exists(Environment_Var.Get_ROOT_FOLDER()))
                {
                    Directory.CreateDirectory(Environment_Var.Get_ROOT_FOLDER());
                }
            }
            catch (IOException ioex)
            {
                Console.WriteLine(ioex.Message);
            }
        }

        public static AutoCompleteStringCollection Generate_Tags_Auto_Complet()
        {
            AutoCompleteStringCollection auto_Text = new AutoCompleteStringCollection();
            foreach (KeyValuePair<string, string> k in DataStore.Get_Tags_Dict())
            {
                auto_Text.Add(k.Key);
            }
            return auto_Text;
        }

        public static AutoCompleteStringCollection Generate_Leasing_Company_Auto_Complet()
        {
            AutoCompleteStringCollection auto_Text = new AutoCompleteStringCollection();
            foreach (LeasingCompany L in DataStore.Get_Leasing_Companies())
            {
                auto_Text.Add(L.Name);
            }
            return auto_Text;
        }

        public static AutoCompleteStringCollection Generate_Machine_Numbers_Auto_Complet(string type)
        {
            DataStore.Retrieve_Machine_Numbers_REST(type);
            AutoCompleteStringCollection auto_Text = new AutoCompleteStringCollection();
            foreach (KeyValuePair<string, int> k in DataStore.Get_Base_Machine_Dictionary())
            {

                auto_Text.Add(k.Key);
            }
            return auto_Text;
        }

        public static AutoCompleteStringCollection Generate_Machine_Numbers_Auto_Complet_All()
        {
            DataStore.Retrieve_Machine_Numbers_ALL_REST();
            AutoCompleteStringCollection auto_Text = new AutoCompleteStringCollection();
            foreach (KeyValuePair<string, int> k in DataStore.Get_Machine_Number_Dictionary())
            {

                auto_Text.Add(k.Key);
            }
            return auto_Text;
        }


        public static AutoCompleteStringCollection Generate_Counties_Auto_Complet()
        {
            AutoCompleteStringCollection auto_Text = new AutoCompleteStringCollection();
            foreach (KeyValuePair<string, string> k in DataStore.Get_Counties_Dict())
            {
                auto_Text.Add(k.Key);
            }
            return auto_Text;
        }

        public static string Read_Json(string path)
        {
            using (StreamReader r = new StreamReader(path))
            {
                return r.ReadToEnd();
            }
        }

        public static void Write_Json(string path, string str)
        {
            using (StreamWriter w = new StreamWriter(path, true))
            {
                w.WriteLine(str);
                w.Close();
            }
        }

        public static Configuration Retrieve_CONFIG()
        {
            return JsonConvert.DeserializeObject<Configuration>(Read_Json(Environment_Var.CONFIG_FULL_PATH));
        }

        public static string Get_Json(object x)
        {
            return JsonConvert.SerializeObject(x);
        }

        public static void Save_CONFIG()
        {
            try
            {
                if (Exists_File(Environment_Var.CONFIG_PATH))
                {
                    File.Delete(Environment_Var.CONFIG_FULL_PATH);
                }
                Write_Json(Environment_Var.CONFIG_FULL_PATH, Get_Json(DataStore.Get_CONFIG()));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public static void Style_DataGridView(DataGridView dg)
        {
            dg.BorderStyle = BorderStyle.None;
            dg.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(238, 239, 249);
            dg.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            //dg.DefaultCellStyle.SelectionBackColor = Color.SeaGreen;
            dg.DefaultCellStyle.SelectionForeColor = Color.WhiteSmoke;
            dg.BackgroundColor = Color.FromArgb(30, 30, 30);
            dg.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            dg.EnableHeadersVisualStyles = false;
            dg.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            //dg.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(37, 37, 38);
            //dg.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(30, 30, 30);
            //dg.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;

        }

        /// <summary>
        /// This methods removes symbols from a string.
        /// </summary>
        /// <param name="str">String with symbols</param>
        /// <returns>String without symbols</returns>
        public static string Remove_Symbols(string str)
        {
            if (str != null)
            {
                str = new string((from c in str
                                  where char.IsWhiteSpace(c) || char.IsLetterOrDigit(c) || char.IsPunctuation(c)
                                  select c
                   ).ToArray());
            }
            return str;
        }

        public static string Keep_Punctuation(string str)
        {
            if (str != null)
            {
                str = new string((from c in str
                                  where !char.IsPunctuation(c)
                                  select c
                   ).ToArray());
            }
            return str;
        }

        public static string Remove_SQL_Symbols(string str)
        {
            if (str != null)
            {
                str = new string((from c in str
                                  where c != '\'' && c != '[' && c != ']' && c != '"'
                                  select c
                   ).ToArray());
            }
            return str;
        }

        public static bool IsNumeric(string str)
        {
            foreach (char c in str)
            {
                if (!char.IsDigit(c) && c != '.')
                {
                    return false;
                }
            }
            return true;
        }

        public static string To_Upper(string str)
        {
            if (!string.IsNullOrWhiteSpace(str))
            {
                return str.ToUpper();
            }
            return null;
        }

        public static void Got_Focus_Main(object sender, EventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            textBox.Width = 200;
            if (textBox.Text.ToString().Equals((string)textBox.Tag))
            {
                textBox.Text = null;
            }
        }

        public static void Lost_Focus_Main(object sender, EventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            textBox.Width = 75;
            if (string.IsNullOrWhiteSpace(textBox.Text))
            {
                textBox.Text = (string)textBox.Tag;
            }
        }

        public static string Subscribe_MailChimp(string email_)
        {
            var subscribeRequest = new
            {
                apikey = REST_API.Get_MAILCHIMP_API(),
                id = REST_API.Get_MAILCHIMP_LIST_ID(),
                status = "subscribed",
                email = new
                {
                    email = email_
                },
                single_optin = true,
            };
            string requestJson = JsonConvert.SerializeObject(subscribeRequest);

            return Call_Mail_Chimp_Api("lists/subscribe.json", requestJson);
        }

        public static string Subscribe_MailChimp(Contact contact)
        {
            var subscribeRequest = new
            {
                apikey = REST_API.Get_MAILCHIMP_API(),
                id = REST_API.Get_MAILCHIMP_LIST_ID(),
                status = "subscribed",
                email = contact.Email,
                merge_fields = new
                {
                    FNAME = contact.First_Name,
                    LNAME = contact.Last_Name,
                },
                //double_optin = true,
            };
            string requestJson = JsonConvert.SerializeObject(subscribeRequest);

            return Call_Mail_Chimp_Api($"lists/<4fc07d5995>/members/", requestJson);
        }

        private static string Call_Mail_Chimp_Api(string method, string requestJson)
        {
            string endpoint = string.Format("https://{0}.api.mailchimp.com/2.0/{1}", "us19", method);
            Console.WriteLine("TEST: " + endpoint);
            WebClient wc = new WebClient();
            try
            {
                return wc.UploadString(endpoint, requestJson);
            }
            catch (WebException we)
            {
                using (StreamReader sr = new StreamReader(we.Response.GetResponseStream()))
                {
                    return sr.ReadToEnd();
                }
            }
        }

        public static async void MailChimp(Contact contact)
        {
            IMailChimpManager manager = new MailChimpManager(REST_API.Get_MAILCHIMP_API());
            ServicePointManager.SecurityProtocol = ServicePointManager.SecurityProtocol | SecurityProtocolType.Tls12;

            string listId = REST_API.Get_MAILCHIMP_LIST_ID();
            // Use the Status property if updating an existing member
            Member member = new Member
            {
                EmailAddress = contact.Email,
                StatusIfNew = Status.Subscribed
            };
            member.MergeFields.Add("FNAME", contact.First_Name);
            member.MergeFields.Add("LNAME", contact.Last_Name);
            Console.WriteLine("CONTACT: " + contact.Email);
            await manager.Members.AddOrUpdateAsync(listId, member);
        }

        public static int Bool_To_Binary(bool x)
        {
            if (x)
            {
                return 1;
            }
            return 0;
        }

        public static bool Check_TB(List<TextBox> list)
        {
            foreach (TextBox t in list)
            {
                if (t.Text.Equals((string)t.Tag) || string.IsNullOrWhiteSpace(t.Text))
                {
                    Display_Alert("Error: Missing " + (string)t.Tag, false);
                    return false;
                }
            }
            return true;
        }

        public static void Send_HTML_Mail(string to, string subject, string body, List<string> attachments)
        {
            // Create Mail
            //MailMessage mail = new MailMessage();
            //mail.Subject = subject;
            //mail.Body =  
        }

        

    }
}
