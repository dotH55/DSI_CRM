using DSI_CRM.Models;
using DSI_CRM.Services;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Net;
using System.Text.RegularExpressions;

namespace DSI_CRM.Service
{
    internal static class DataStore
    {
        [System.Runtime.InteropServices.DllImport("wininet.dll")]
        private static extern bool InternetGetConnectedState(out int Description, int ReservedValue);

        public static string VAR_1 = null;
        public static string VAR_2 = null;

        private static List<User> USERS;
        private static List<Organization> ORGS;
        private static List<string> SELECTED_USERS;
        private static List<Contact> SEARCH_CONTACTS;

        private static List<Machine> SEARCHED_MACHINES;
        private static List<LeasingCompany> LEASING_COMPANIES;
        private static List<MachineDup> MACHINES_DUP;

        private static User LOGGED_USER;
        private static Configuration CONFIG;

        private static readonly Dictionary<string, int> MACHINES_DICT;
        private static readonly Dictionary<string, int> BASE_MACHINES_DICT;
        private static readonly Dictionary<string, string> TAGS_DICT;
        private static readonly Dictionary<string, string> COUNTIES_DICT;

        //private static readonly List<Record_Contact> RECORD_CONTACT;
        //private static readonly List<Record_Org> RECORD_ORGS;


        //Guid.NewGuid().ToString();

        static DataStore()
        {
            // Declare 
            USERS = new List<User>();
            ORGS = new List<Organization>();
            SEARCH_CONTACTS = new List<Contact>();
            LEASING_COMPANIES = new List<LeasingCompany>();

            MACHINES_DICT = new Dictionary<string, int>();
            TAGS_DICT = new Dictionary<string, string>();
            BASE_MACHINES_DICT = new Dictionary<string, int>();
            COUNTIES_DICT = new Dictionary<string, string>();
            Init_Configuration();
        }

        public static void Clear_DataStore()
        {
            USERS.Clear();
            ORGS.Clear();
            SEARCH_CONTACTS.Clear();
            LEASING_COMPANIES.Clear();

            MACHINES_DICT.Clear();
            TAGS_DICT.Clear();
            BASE_MACHINES_DICT.Clear();
            COUNTIES_DICT.Clear();
        }

        public static void Init_Configuration()
        {
            Process.Create_ROOT_FOLDER();

            if (Process.Exists_File(Environment_Var.Get_CONFIG_PATH()))
            {
                CONFIG = Process.Retrieve_CONFIG();
            }
            else
            {
                CONFIG = new Configuration();
            }
        }


        public static bool CHECK_NET()
        {
            return InternetGetConnectedState(out int desc, 0);
        }

        public static List<Org> Screen_Org_REST(Organization org, Address addr)
        {
            string URLString = $"{REST_API.Get_URL_PREFIX()}CRM_Organization_Check_Dup?Name={org.Name}&&Phone={org.Phone}&&Address_1={addr.Address_1}" +
                $"&&Address_2={addr.Address_2}&&City={addr.City}&&State={addr.State}&&Zip={addr.Zip}&&Location={LOGGED_USER.Location}";
            return JsonConvert.DeserializeObject<List<Org>>(REST_API_BASE(URLString));
        }

        public static string Create_Org_REST(Organization org, Address addr)
        {
            string URLString = REST_API.Get_URL_PREFIX() + "CRM_Organization_Create?Name=" + (Regex.Replace(org.Name, "[^a-zA-Z0-9]", " ")).Replace("  ", " ") + "&&Phone=" + org.Phone
                    + "&&Address_1=" + Regex.Replace(addr.Address_1, "[^a-zA-Z0-9]", " ").Replace("  ", " ") + "&&Address_2=" + addr.Address_2 + "&&City=" + addr.City + "&&State=" + addr.State
                    + "&&Zip=" + addr.Zip + "&&County=" + addr.County + "&&SalesmanInitials=" + LOGGED_USER.Initials + "&&DSICustomerNumber=0"
                    + "&&Location=" + LOGGED_USER.Location + "&&Org_Status=1";
            return REST_API_BASE(URLString);
        }

        public static void Update_Org_REST(Organization org)
        {
            string URLString = REST_API.Get_URL_PREFIX() + "CRM_Organization_Update?OrganizationNumber=" + org.Organization_Number + "&&Name="
                    + org.Name + "&&Description=" + org.Notes + "&&Phone=" + org.Phone + "&&Fax=" + org.Fax + "&&Website=" + Process.Remove_Symbols(org.Website)
                    + "&&Location=" + LOGGED_USER.Location + "&&SalesmanInitials=" + LOGGED_USER.Initials + "&&DSICustomerNumber=" + org.DSI_Customer_Number;
            REST_API_BASE(URLString);
        }

        public static Organization Get_ORG_REST(string Org_Number)
        {
            Organization org = Get_Org_REST(Org_Number);
            Get_ORG(org);
            return org;
        }

        public static Organization Get_ORG_rowguid_REST_(string rowguid)
        {
            Organization org = Get_Org_rowguid_REST(rowguid);
            Get_ORG(org);
            return org;
        }

        public static Organization Get_ORG_rowguid_REST(string rowguid)
        {
            Organization org = new Organization();
            foreach (Organization o in ORGS)
            {
                if (o.rowguid.Equals(rowguid))
                {
                    org = o;
                }
            }
            Get_ORG(org);
            return org;
        }

        private static void Get_ORG(Organization org)
        {
            Retrieve_Org_Contacts_REST(org);
            Organization_Get_Lease(org);
            Get_Task_REST(org);
            Retrieve_Addr_REST(org, new Contact());
            Retrieve_Tags_REST(org, new Contact());
        }


        public static Contact Get_Contact_rowguid_REST_(string rowguid)
        {
            Contact contact = Get_Contact_Helper_REST(rowguid);
            Retrieve_Addr_REST(new Organization(), contact);
            //Retrieve_Tags_REST(new Organization(), contact);
            return contact;
        }

        public static Contact Get_Contact_rowguid_REST(string rowguid)
        {
            //Contact contact = Get_Contact_Helper_REST(rowguid);
            foreach(Contact c in SEARCH_CONTACTS)
            {
                if (c.rowguid.Equals(rowguid))
                {
                    Contact contact = c;
                    Retrieve_Addr_REST(new Organization(), contact);
                    //Retrieve_Tags_REST(new Organization(), contact);
                    return contact;
                }
            }
            return null;
        }

        public static Contact Get_Contact_Contact_Number_REST(string contact_Number)
        {
            Contact contact = Get_Contact_Contact_Helper_REST(contact_Number);
            Retrieve_Addr_REST(new Organization(), contact);
            Retrieve_Tags_REST(new Organization(), contact);
            return contact;
        }

        private static Contact Get_Contact_Helper_REST(string rowguid)
        {
            string URLString = REST_API.Get_URL_PREFIX() + "CRM_Contact_Get_Rowguid?rowguid=" + rowguid;
            List<Contact> temp = JsonConvert.DeserializeObject<List<Contact>>(REST_API_BASE(URLString));

            return temp[0];
        }

        private static Contact Get_Contact_Contact_Helper_REST(string contact_Number)
        {
            string URLString = REST_API.Get_URL_PREFIX() + "CRM_Contact_Get_Contact_Number?Contact_Number=" + contact_Number;
            List<Contact> temp = JsonConvert.DeserializeObject<List<Contact>>(REST_API_BASE(URLString));

            return temp[0];
        }

        public static Organization Get_Org_REST(string Organization_Number)
        {
            string URLString = REST_API.Get_URL_PREFIX() + "CRM_Organization_Get?OrganizationNumber=" + Organization_Number + "&&Salesman_Initials=" + LOGGED_USER.Initials;
            List<Organization> temp = JsonConvert.DeserializeObject<List<Organization>>(REST_API_BASE(URLString));
            return temp[0];
        }

        public static Organization Get_Org_rowguid_REST(string rowguid)
        {
            string URLString = REST_API.Get_URL_PREFIX() + "CRM_Organization_Get_Rowguid?rowguid=" + rowguid;
            List<Organization> temp = JsonConvert.DeserializeObject<List<Organization>>(REST_API_BASE(URLString));

            return temp[0];
        }

        public static void Desactivate_Org_REST(Organization org)
        {
            string URLString = REST_API.Get_URL_PREFIX() + "CRM_Organization_Deactivate?Organization_Number=" + org.Organization_Number;
            REST_API_BASE(URLString);
        }

        public static void Update_Contacts_REST(Contact contact)
        {
            string URLString = REST_API.Get_URL_PREFIX() + "CRM_Contact_Update?Contact_Number=" + contact.Contact_Number + "&&First_Name=" + contact.First_Name + "&&Last_Name=" + contact.Last_Name
                    + "&&Title=" + contact.Title + "&&Email=" + contact.Email + "&&Fax=" + contact.Fax + "&&Mobile_Phone="
                    + contact.Mobile_Phone + "&&Location=" + LOGGED_USER.Location + "&&Salesman_Initials=" + LOGGED_USER.Initials + "&&Office_Phone=" + contact.Office_Phone;
            REST_API_BASE(URLString);
        }

        public static void Retrieve_User_REST()
        {
            string URLString = $"{REST_API.Get_URL_PREFIX()}CRM_Users_Get";
            USERS = JsonConvert.DeserializeObject<List<User>>(REST_API_BASE(URLString));
        }

        public static void Create_Note_Rest(Organization org, Note note)
        {
            string URLString = $"{REST_API.Get_URL_PREFIX()}CRM_Org_Notes_Create?Contact_Number={note.Contact_Number}&&Contact_Name={note.Contact_Name}&&Type={note.Type}" +
                $"&&Description={note.Description}&&Salesman_Initials={note.Salesman_Initials}&&Action_Status={note.Action_Status}&&Action_Date={note.Action_Date}" +
                $"&&Location={LOGGED_USER.Location}&&Org_Number={org.Organization_Number}";
            REST_API_BASE(URLString);
        }

        public static void Retrieve_Notes_Rest(Organization org)
        {
            string URLString = REST_API.Get_URL_PREFIX() + "CRM_Org_Notes_Get?Organization_Number=" + org.Organization_Number;
            org.SetNotes(JsonConvert.DeserializeObject<List<Note>>(REST_API_BASE(URLString)));
        }

        // Return Newly Created Address Number
        public static string Create_Addr_Rest(Organization org, Contact contact, Address addr)
        {
            string URLString = "";
            if (org.rowguid == null)
            {
                URLString = REST_API.Get_URL_PREFIX() + "CRM_AddressCreate?Organization_Number=0&&Contact_Number=" + contact.Contact_Number + "&&Address_1="
                + addr.Address_1 + "&&Address_2=" + addr.Address_2 + "&&City=" + addr.City + "&&State=" + addr.State + "&&Zip=" + addr.Zip
                + "&&County=" + addr.County + "&&Location=" + LOGGED_USER.Location;
            }
            else
            {
                URLString = REST_API.Get_URL_PREFIX() + "CRM_AddressCreate?Organization_Number=" + org.Organization_Number + "&&Contact_Number=0&&Address_1="
                + addr.Address_1 + "&&Address_2=" + addr.Address_2 + "&&City=" + addr.City + "&&State=" + addr.State + "&&Zip=" + addr.Zip
                + "&&County=" + addr.County + "&&Location=" + LOGGED_USER.Location;
            }
            return REST_API_BASE(URLString);
        }

        public static void Update_Addr_Rest(Address addr)
        {
            string URLString = REST_API.Get_URL_PREFIX() + "CRM_Address_Update?rowguid=" + addr.rowguid + "&&Address_1=" + addr.Address_1 + "&&Address_2="
                    + addr.Address_2 + "&&City=" + addr.City + "&&State=" + addr.State + "&&Zip=" + addr.Zip + "&&County=" + addr.County
                    + "&&Location=" + LOGGED_USER.Location;
            REST_API_BASE(URLString);
        }

        public static void Retrieve_Addr_REST(Organization org, Contact contact)
        {
            string URLString = "";

            if (org.rowguid == null)
            {
                URLString = REST_API.Get_URL_PREFIX() + "CRM_Address_Get?OrganizationNumber=0&&ContactNumber=" + contact.Contact_Number;
                contact.SetAddresses(JsonConvert.DeserializeObject<List<Address>>(REST_API_BASE(URLString)));
            }
            else
            {
                URLString = REST_API.Get_URL_PREFIX() + "CRM_Address_Get?OrganizationNumber=" + org.Organization_Number + "&&ContactNumber=0";
                org.SetAddresses(JsonConvert.DeserializeObject<List<Address>>(REST_API_BASE(URLString)));
            }
        }

        public static void Create_Tags_REST(Tag tag)
        {
            string URLString = REST_API.Get_URL_PREFIX() + "CRM_Tags_Create?Tag_Name=" + tag.Name + "&&Salesman_Initials=" + tag.Salesman;
            REST_API_BASE(URLString);
        }

        public static void Retrieve_Tags_REST(Organization org, Contact contact)
        {
            string URLString = "";
            if (org.rowguid != null && contact.rowguid == null)
            {
                URLString = REST_API.Get_URL_PREFIX() + "CRM_Tag_Get?OrgNumber=" + org.Organization_Number + "&&ContactNumber=0";
                org.SetTAGS(JsonConvert.DeserializeObject<List<Tag>>(REST_API_BASE(URLString)));
            }
            else if (org.rowguid == null && contact.rowguid != null)
            {
                URLString = REST_API.Get_URL_PREFIX() + "CRM_Tag_Get?OrgNumber=0&&ContactNumber= " + contact.Contact_Number;
                contact.SetTAGS(JsonConvert.DeserializeObject<List<Tag>>(REST_API_BASE(URLString)));
            }
            else if (org.rowguid == null && contact.rowguid == null)
            {
                URLString = REST_API.Get_URL_PREFIX() + "CRM_Tag_Get?OrgNumber=0&&ContactNumber=0";
                List<Tag> tmp = JsonConvert.DeserializeObject<List<Tag>>(REST_API_BASE(URLString));
                foreach (Tag t in tmp)
                {
                    if (!TAGS_DICT.ContainsKey(t.Name))
                    {
                        TAGS_DICT.Add(t.Name, t.Tag_Number);
                    }
                }

            }
        }

        public static Dictionary<string, string> Get_Tags_Dict()
        {
            return TAGS_DICT;
        }

        public static bool Verify_User(string username, string pwd)
        {
            foreach (User u in USERS)
            {
                if (u.Initials.ToUpper().Equals(username.ToUpper()) && "DSI".Equals(pwd.ToUpper()))
                {
                    LOGGED_USER = u;
                    return true;
                }
            }
            return false;
        }

        public static void Org_Attach_Tag_REST(Organization org, string tag)
        {
            string URLString = REST_API.Get_URL_PREFIX() + "CRM_Organization_Attach_Tag?Organization_Number=" + org.Organization_Number + "&&Tag_Number="
                + tag + "&&Location=" + LOGGED_USER.Location;
            REST_API_BASE(URLString);
        }

        public static void Address_Link_REST(Organization org, Contact contact, Address addr)
        {
            string URLString = "";
            if (org.rowguid == null)
            {
                URLString = REST_API.Get_URL_PREFIX() + "CRM_Address_Link?Organization_Number=0&&Contact_Number=" + contact.Contact_Number + "&&Addr_Number="
                    + addr.Address_Number + "&&Location=" + LOGGED_USER.Location;
            }
            else
            {
                URLString = REST_API.Get_URL_PREFIX() + "CRM_Address_Link?Organization_Number=" + org.Organization_Number + "&&Contact_Number=0&&Addr_Number="
                    + addr.Address_Number + "&&Location=" + LOGGED_USER.Location;
            }
            REST_API_BASE(URLString);
        }

        public static void Org_Detach_Tags_REST(Organization org)
        {
            string URLString = REST_API.Get_URL_PREFIX() + "CRM_Organization_Detach_Tags?Org_Number=" + org.Organization_Number;
            REST_API_BASE(URLString);
        }

        public static Contact Contact_Create_New_REST(Organization org)
        {
            string URLString = REST_API.Get_URL_PREFIX() + "CRM_Contact_Create_New?Org_Number=" + org.Organization_Number + "&&Salesman_Initials=" + LOGGED_USER.Initials
                + "&&Location=" + LOGGED_USER.Location;
            Contact contact = new Contact
            {
                Contact_Number = Regex.Replace(REST_API_BASE(URLString), "[^0-9]", "")
            };
            return contact;
        }


        public static void Retrieve_Orgs_Filtered_REST(string name, string city, string addr, string tags)
        {
            string URLString = REST_API.Get_URL_PREFIX() + "CRM_Organization_Filtered?Name=" + name + "&&City=" + city + "&&Address=" + addr + "&&Tags=" + tags;
            ORGS = JsonConvert.DeserializeObject<List<Organization>>(REST_API_BASE(URLString));
        }

        public static void Retrieve_Contact_Filtered_REST(string name)
        {
            string URLString = REST_API.Get_URL_PREFIX() + "CRM_Contact_Filtered?Name=" + name;
            SEARCH_CONTACTS = JsonConvert.DeserializeObject<List<Contact>>(REST_API_BASE(URLString));
        }

        public static void Contact_Create_Cancelled(Contact contact)
        {
            string URLString = REST_API.Get_URL_PREFIX() + "CRM_Contact_Create_Cancelled?Contact_Number=" + contact.Contact_Number + "&&Location=" + LOGGED_USER.Location;
            REST_API_BASE(URLString);
        }

        public static List<Contact> Get_SEARCH_CONTACTS()
        {
            return SEARCH_CONTACTS;
        }

        public static void Retrieve_Org_Contacts_REST(Organization org)
        {
            string URLString = REST_API.Get_URL_PREFIX() + "CRM_Contact_Get?Organization_Number=" + org.Organization_Number;
            SEARCH_CONTACTS = JsonConvert.DeserializeObject<List<Contact>>(REST_API_BASE(URLString));
            org.SetContacts(SEARCH_CONTACTS);
        }

        public static void Retrieve_Orgs_Contacts_All_REST_2(List<Organization> orgs)
        {
            foreach (Organization o in orgs)
            {
                Retrieve_Org_Contacts_REST(o);
            }
        }

        public static string REST_API_BASE(string URLString)
        {
            string str = null;
            HttpWebRequest request = null;
            HttpWebResponse response = null;
            try
            {
                if (CHECK_NET())
                {
                    Console.WriteLine("URL: " + URLString);

                    //This reads the file
                    request = (HttpWebRequest)WebRequest.Create(URLString);
                    request.Method = "GET";
                    request.Timeout = 12000;
                    request.Headers["APIKey"] = REST_API.Get_API_KEY();

                    try
                    {
                        HttpWebResponse resp = (HttpWebResponse)request.GetResponse();
                        using (resp)
                        {
                            if (resp.StatusCode == HttpStatusCode.OK)
                            {
                                StreamReader rd = new StreamReader(resp.GetResponseStream());
                                str = rd.ReadToEnd();
                                Console.WriteLine("Result: " + str);
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("StackTrace: " + ex.StackTrace);
                        Console.WriteLine("Message" + ex.Message);
                        Console.WriteLine("InnerException" + ex.InnerException);
                        //Process.Display_Alert("ERROR: " + ex.Message, true);
                    }
                }
                else
                {
                    Process.Display_Alert("ERROR: Network Connectivity", true);
                }
            }
            finally
            {
                if (response != null)
                {
                    response.Close();
                }
            }
            return str;
        }

        public static void Set_SELECTED_USERS(List<string> new_list)
        {
            SELECTED_USERS = new_list;
            Filter_Salesmen_REST();
        }

        public static void Filter_Salesmen_REST()
        {
            ORGS.Clear();
            foreach (string s in SELECTED_USERS)
            {
                string URLString = REST_API.Get_URL_PREFIX() + "CRM_Organization_Get?OrganizationNumber=0&&Salesman_Initials=" + s;
                List<Organization> temp = JsonConvert.DeserializeObject<List<Organization>>(REST_API_BASE(URLString));
                ORGS.AddRange(temp);
            }
        }

        public static void Add_ORGS(Organization org)
        {
            ORGS.Add(org);
        }

        public static void Clear_ORGS()
        {
            ORGS = new List<Organization>();
        }

        public static void Clear_SEARCHED_CONTACT()
        {
            SEARCH_CONTACTS = new List<Contact>();
        }

        public static void Retrieve_COUNTIES()
        {
            string URLString = REST_API.Get_URL_PREFIX() + "CRM_Counties_Get?";
            List<County> tmp = JsonConvert.DeserializeObject<List<County>>(REST_API_BASE(URLString));
            foreach (County c in tmp)
            {
                if (!COUNTIES_DICT.ContainsKey(c.County_Name))
                {
                    COUNTIES_DICT.Add(c.County_Name, c.State);
                }
            }
        }

        public static void Create_Lease_REST(Lease lease)
        {
            string URLString = $"{REST_API.Get_URL_PREFIX()}CRM_Lease_Create?Org_Number={lease.Org_Number}&&Provider={lease.Provider}&&Equipment={lease.Equipment}&&Payment={lease.Payment}" +
                $"&&Lease_End_Date={lease.Lease_End_Date}&&DSI_Customer_Number={lease.DSI_Customer_Number}&&Salesman_Initials={DataStore.LOGGED_USER.Initials}&&Location={DataStore.LOGGED_USER.Location}";
            REST_API_BASE(URLString);
        }

        public static void Update_Lease_REST(Lease lease)
        {
            string URLString = REST_API.Get_URL_PREFIX() + "CRM_Lease_Update?rowguid=" + lease.rowguid + "&&Provider=" + lease.Provider + "&&Equipment=" + lease.Equipment + "&&Payment=" + lease.Payment + "&&Lease_End_Date=" + lease.Lease_End_Date
                + "&&DSI_Customer_Number=" + lease.DSI_Customer_Number + "&&Salesman_Initials=" + DataStore.LOGGED_USER.Initials + "&&Location=" + DataStore.LOGGED_USER.Location;
            REST_API_BASE(URLString);
        }

        public static void Organization_Get_Lease(Organization org)
        {
            string URLString = $"{REST_API.Get_URL_PREFIX()}CRM_Organization_Get_Lease?Organization_Number={org.Organization_Number}";
            org.Set_LEASES(JsonConvert.DeserializeObject<List<Lease>>(REST_API_BASE(URLString)));
        }

        public static List<Organization> Get_ORGS()
        {
            return ORGS;
        }

        public static void CreateCommand(string queryString)
        {
            using (SqlConnection connection = new SqlConnection("DRIVER={ODBC Driver 13 for SQL Server}; SERVER=DSSQL-Hyper; DATABASE=DSI_CRM; UID=DSIEmployee; PWD=dsi123!!"))
            {
                SqlCommand command = new SqlCommand(queryString, connection);
                command.Connection.Open();
                command.ExecuteNonQuery();
            }
        }

        // Depreciated
        public static void Create_Record(string[] entry)
        {
            using (SqlConnection conn = new SqlConnection("Server=DSSQL-Hyper;Database=DSI_CRM;UID=DSIEmployee;Password=dsi123!!"))
            {
                // 1.  Create a command object identifying the stored procedure
                conn.Open();
                SqlCommand cmd = new SqlCommand("[Mobile].[usp_Org_Record_Create]", conn)
                {

                    // 2. Set the command object so it knows to execute a stored procedure
                    CommandType = CommandType.StoredProcedure,
                    CommandTimeout = 250
                };

                // 3. add parameter to command, which
                // will be passed to the stored procedure
                cmd.Parameters.Add("@pRecordId", SqlDbType.VarChar).Value = entry[0];
                cmd.Parameters.Add("@pOrgName", SqlDbType.VarChar).Value = entry[1];
                cmd.Parameters.Add("@pBackground", SqlDbType.VarChar).Value = entry[2];
                cmd.Parameters.Add("@pBillingAddressStreet", SqlDbType.VarChar).Value = entry[3];
                cmd.Parameters.Add("@pBillingAddressCity", SqlDbType.VarChar).Value = entry[4];
                cmd.Parameters.Add("@pBillingAddressState", SqlDbType.VarChar).Value = entry[5];
                cmd.Parameters.Add("@pBillingAddressPostalCode", SqlDbType.VarChar).Value = entry[6];
                cmd.Parameters.Add("@pBillingAddressCounty", SqlDbType.VarChar).Value = entry[7];
                cmd.Parameters.Add("@pShippingAddressStreet", SqlDbType.VarChar).Value = entry[8];
                cmd.Parameters.Add("@pShippingAddressCity", SqlDbType.VarChar).Value = entry[9];
                cmd.Parameters.Add("@pShippingAddressState", SqlDbType.VarChar).Value = entry[10];
                cmd.Parameters.Add("@pShippingAddressCounty", SqlDbType.VarChar).Value = entry[11];
                cmd.Parameters.Add("@pShippingAddressPostalCode", SqlDbType.VarChar).Value = entry[12];
                cmd.Parameters.Add("@pPhone", SqlDbType.VarChar).Value = entry[13];
                cmd.Parameters.Add("@pFax", SqlDbType.VarChar).Value = entry[14];
                cmd.Parameters.Add("@pWebsite", SqlDbType.VarChar).Value = entry[15];
                cmd.Parameters.Add("@pEmailDomain", SqlDbType.VarChar).Value = entry[16];
                cmd.Parameters.Add("@pImportantDate1Name", SqlDbType.VarChar).Value = entry[17];
                cmd.Parameters.Add("@pImportantDate1", SqlDbType.VarChar).Value = entry[18];
                cmd.Parameters.Add("@pImportantDate2Name", SqlDbType.VarChar).Value = entry[19];
                cmd.Parameters.Add("@pImportantDate2", SqlDbType.VarChar).Value = entry[20];
                cmd.Parameters.Add("@pImportantDate3Name", SqlDbType.VarChar).Value = entry[21];
                cmd.Parameters.Add("@pImportantDate3", SqlDbType.VarChar).Value = entry[22];
                cmd.Parameters.Add("@pTag1", SqlDbType.VarChar).Value = entry[23];
                cmd.Parameters.Add("@pTag2", SqlDbType.VarChar).Value = entry[24];
                cmd.Parameters.Add("@pTag3", SqlDbType.VarChar).Value = entry[25];
                cmd.Parameters.Add("@pTag4", SqlDbType.VarChar).Value = entry[26];
                cmd.Parameters.Add("@pTag5", SqlDbType.VarChar).Value = entry[27];
                cmd.Parameters.Add("@pTag6", SqlDbType.VarChar).Value = entry[28];
                cmd.Parameters.Add("@pTag7", SqlDbType.VarChar).Value = entry[29];
                cmd.Parameters.Add("@pTag8", SqlDbType.VarChar).Value = entry[30];
                cmd.Parameters.Add("@pTag9", SqlDbType.VarChar).Value = entry[31];
                cmd.Parameters.Add("@pDateOfLastActivity", SqlDbType.VarChar).Value = entry[32];
                cmd.Parameters.Add("@pDateOfNextActivity", SqlDbType.VarChar).Value = entry[33];
                cmd.Parameters.Add("@pCounty", SqlDbType.VarChar).Value = entry[34];
                cmd.Parameters.Add("@pContact", SqlDbType.VarChar).Value = entry[35];
                cmd.Parameters.Add("@pCurrentProvider", SqlDbType.VarChar).Value = entry[36];
                cmd.Parameters.Add("@pCurrentEquipment", SqlDbType.VarChar).Value = entry[37];
                cmd.Parameters.Add("@pCurrentPayment", SqlDbType.VarChar).Value = entry[38];
                cmd.Parameters.Add("@pLeaseEndDate", SqlDbType.VarChar).Value = entry[39];
                cmd.Parameters.Add("@pVertical", SqlDbType.VarChar).Value = entry[40];
                cmd.Parameters.Add("@pDSICustomerNumber", SqlDbType.VarChar).Value = entry[41];

                cmd.ExecuteNonQuery();

            } // using
        } // GenerateData

        public static void Set_Them_CONFIG(bool theme)
        {
            CONFIG.Set_Theme(theme);
        }

        public static void Set_Email_Config(string email, string password)
        {
            CONFIG.Email_Addr = email;
            CONFIG.Email_Password = password;
        }

        public static string Get_Email_Config()
        {
            return CONFIG.Email_Addr;
        }

        public static string Get_Email_Password_Config()
        {
            return CONFIG.Email_Password;
        }

        public static bool Get_Theme_CONFIG()
        {
            return CONFIG.Get_Theme();
        }

        public static Configuration Get_CONFIG()
        {
            return CONFIG;
        }

        public static string Get_Username_Config()
        {
            return CONFIG.Username;
        }

        public static string Get_Password_Config()
        {
            return CONFIG.Password;
        }

        public static void Set_Username_Password_Config(string username, string password)
        {
            CONFIG.Set_Username_Password(username, password);
            Process.Save_Configuration();
        }

        public static Dictionary<string, string> Get_Counties_Dict()
        {
            return COUNTIES_DICT;
        }

        public static User Get_LOGGED_USER()
        {
            return LOGGED_USER;
        }

        public static void Set_CONFIG_Theme_Color(Color newColor)
        {
            CONFIG.Theme_Color = newColor;
        }

        public static Color Get_CONFIG_Theme_Color()
        {
            return CONFIG.Theme_Color;
        }

        public static void Create_Task_REST(Task task)
        {
            string URLString = $"{REST_API.Get_URL_PREFIX()}CRM_Task_Create?rowguid={task.rowguid}&&Contact_Number={task.Contact_Number}&&Org_Number={task.Org_Number}&&Org_Name={task.Org_Name}"
                + $"&&Org_Website={task.Org_Website}&&Org_Phone_Number={task.Org_Phone_Number}&&Type={task.Type}&&Salesman_Initials={task.Salesman_Initials}&&Task_Summary={task.Task_Event.Summary}&&Task_Description={task.Task_Event.Description}"
                + $"&&Start_Datetime={task.Task_Event.Start.DateTime}&&End_Datetime={task.Task_Event.End.DateTime}&&Created_Datetime={task.Task_Event.Created}&&Location={LOGGED_USER.Location}&&Status={task.Status}";
            REST_API_BASE(URLString);
        }

        public static void Get_Task_REST(Organization org)
        {
            string URLString = $"{REST_API.Get_URL_PREFIX()}CRM_Task_Get?Org_Number={org.Organization_Number}";
            org.Set_Task(JsonConvert.DeserializeObject<List<Task>>(REST_API_BASE(URLString)));
        }

        public static string Create_Quote_REST(Organization org)
        {
            string URLString = $"{REST_API.Get_URL_PREFIX()}CRM_Quote_Create?Org_Number={org.Organization_Number}&&Location={LOGGED_USER.Location}";
            return Regex.Replace(REST_API_BASE(URLString), "[^0-9]", "");
        }

        public static void Get_Quote_REST(Organization org)
        {
            string URLString = $"{REST_API.Get_URL_PREFIX()}CRM_Quote_Get?Org_Number={org.Organization_Number}";
            org.Set_Quote(JsonConvert.DeserializeObject<List<Quote>>(REST_API_BASE(URLString)));
        }

        //public static Quote Get_Quote_rowguid_REST(string rowguid)
        //{
        //    string URLString = $"{REST_API.Get_URL_PREFIX()}CRM_Quote_Get_rowguid?rowguid={rowguid}";
        //    List<Quote> temp = JsonConvert.DeserializeObject<List<Quote>>(REST_API_BASE(URLString));
        //    // Get Base Machines
        //    Get_Quote_Detail_REST(temp[0]);
        //    // Get Base Machine Accessories
        //    foreach (Machine m in temp[0].Get_Machines())
        //    {
        //        Get_Quote_Base_Detail_REST(temp[0], m);
        //    }
        //    return temp[0];
        //}


        public static void Update_Quote_REST(Quote q)
        {
            string URLString = $"{REST_API.Get_URL_PREFIX()}CRM_Quote_Update?Quote_Number={q.Quote_Number}&&Org_Number={q.Org_Number}&&Contact_Number={q.Contact_Number}&&Contact_Name={q.Contact_Name}" +
                $"&&Org_Name={q.Org_Name}&&Terms={q.Terms}&&Lease_Type={q.Lease_Type}&&Maint_Type={q.Maint_Type}&&Additional_Info={'*'}&&Month_1={q.Month_1}&&Month_2={q.Month_2}&&Month_3={q.Month_3}&&Month_4={q.Month_4}" +
                $"&&Payment_1={q.Payment_1}&&Payment_2={q.Payment_2}&&Payment_3={q.Payment_3}&&Payment_4={q.Payment_4}&&Lease_Rate_1={q.Lease_Rate_1}&&Lease_Rate_2={q.Lease_Rate_2}&&Lease_Rate_3={q.Lease_Rate_3}&&Lease_Rate_4={q.Lease_Rate_4}" +
                $"&&Lease_Fees={q.Lease_Fees}&&Leasing_Company={q.Leasing_Company}&&Salesman_Initials={q.Salesman_Initials}&&Man_Rebate={q.Man_Rebate}&&Less_Disc_Trade={q.Less_Disc_Trade}&&Addt_Lease_Fees={q.Addt_Lease_Fees}&&BW={q.BW}" +
                $"&&BW_Excess={q.BW_Excess}&&Color={q.Color}&&Color_Excess={q.Color_Excess}&&Maint_Total_Cost={q.Maint_Total_Cost}&&Install_Name={q.Install_Location.Name}&&Install_Phone={q.Install_Location.Phone}" +
                $"&&Install_Addr_1={q.Install_Location.Addr_1}&&Install_Addr_2={q.Install_Location.Addr_2}&&Install_City={q.Install_Location.City}&&Install_State={q.Install_Location.State}" +
                $"&&Install_Zip={q.Install_Location.Zip}&&Install_County={q.Install_Location.County}";
            REST_API_BASE(URLString);
            Update_Additional_Info(q);
        }

        public static void Update_Additional_Info(Quote q)
        {
            string tmp = null;
            string URLString = null;
            Char[] arr = q.Addt_Info.ToCharArray();
            int x = 0;
            while (x < arr.Length)
            {
                if(x + 1000 < arr.Length)
                {
                    tmp = new string(arr, x, 1000);
                }
                else
                {
                    tmp = new string(arr, x, arr.Length - x);
                }

                if (tmp.Contains("&"))
                {
                    tmp = tmp.Replace("&", "%26");
                }
                tmp = Process.Remove_SQL_Symbols(tmp);
                URLString = $"{REST_API.Get_URL_PREFIX()}CRM_Quote_Update_Additional_Info?Quote_Number={q.Quote_Number}&&Additional_Info={tmp}";
                REST_API_BASE(URLString);
                x += 1000;
            }

        }
        private static string Utility(string str)
        {
            str = str.Replace(' ', '*');
            str = str.Replace('\n', 'D');
            str = str.Replace("$", "%26");
            return str;
        }

        public static void Add_Machine_Links_REST(Machine base_machine, Machine acc)
        {
            string URLString = $"{REST_API.Get_URL_PREFIX()}CRM_Machine_Add_Links?Base_Machine={base_machine.Item_Number}&&Accessory={acc.Item_Number}";
            REST_API_BASE(URLString);
        }

        public static void Delete_Machine_Links_REST(Machine b)
        {
            string URLString = $"{REST_API.Get_URL_PREFIX()}CRM_Machine_Delete_Links?Base_Machine={b.Machine_Number}";
            REST_API_BASE(URLString);
        }

        public static string Create_Machine_REST(string item_Numner)
        {
            string URLString = $"{REST_API.Get_URL_PREFIX()}CRM_Machine_Create?Item_Number={item_Numner}";
            return Regex.Replace(REST_API_BASE(URLString), "[^0-9]", "");
        }

        public static Machine Get_Machine_Number_REST(string machine_Number)
        {
            string URLString = $"{REST_API.Get_URL_PREFIX()}CRM_Machine_Get_Machine_Number?Machine_Number={machine_Number}";
            List<Machine> temp = JsonConvert.DeserializeObject<List<Machine>>(REST_API_BASE(URLString));
            Retrieve_Accessories_2_REST(temp[0]);
            return temp[0];
        }
        public static void Retrieve_Accessories_2_REST(Machine m)
        {
            Retrieve_Accessories_2_STR(m.Machine_Number.ToString());
            m.Set_Accessories(SEARCHED_MACHINES);
        }

        public static Machine Retrieve_Accessories_w(string machine_Number)
        {
            Machine m = Get_Machine_Number_wo_Acc_REST(machine_Number);
            string URLString = $"{REST_API.Get_URL_PREFIX()}CRM_Machine_Get_Accessories?ItemNumber={m.Item_Number}";
            m.Set_Accessories(JsonConvert.DeserializeObject<List<Machine>>(REST_API_BASE(URLString)));
            return m;
        }

        public static Machine Get_Machine_Number_wo_Acc_REST(string machine_Number)
        {
            string URLString = $"{REST_API.Get_URL_PREFIX()}CRM_Machine_Get_Machine_Number?Machine_Number={machine_Number}";
            List<Machine> temp = JsonConvert.DeserializeObject<List<Machine>>(REST_API_BASE(URLString));
            return temp[0];
        }

        

        public static void Retrieve_Accessories_2_STR(string item_Number)
        {
            string URLString = $"{REST_API.Get_URL_PREFIX()}CRM_Machine_Get_Accessories?ItemNumber={item_Number}";
            SEARCHED_MACHINES = JsonConvert.DeserializeObject<List<Machine>>(REST_API_BASE(URLString));
        }

        

        public static void Update_Machine_REST(Machine m)
        {
            string URLString = $"{REST_API.Get_URL_PREFIX()}CRM_Machine_Update?Machine_Number={m.Machine_Number}&&Description={m.Description}" +
                $"&&Category={m.Category}&&Vendor_Description={m.Vendor_Description}&&Make={m.Make}&&Year={m.Year}&&Selling_Price={m.Selling_Price}" +
                $"&&Model_Cost={m.Model_Cost}&&Configuration_ID={m.Configuration_ID}&&St_Addt_Comments={m.St_Addt_Comments}&&US_Comm={m.US_Comm}" +
                $"&&Purchase={m.Purchase}&&FMV_24_Months={m.FMV_24_Months}&&FMV_36_Months={m.FMV_36_Months}&&FMV_48_Months={m.FMV_48_Months}" +
                $"&&FMV_60_Months={m.FMV_60_Months}&&Buyout_24_Months={m.Buyout_24_Months}&&Buyout_36_Months={m.Buyout_36_Months}" +
                $"&&Buyout_48_Months={m.Buyout_48_Months}&&Buyout_60_Months={m.Buyout_60_Months}&&Overage={m.Overage}&&Install_Comp={m.Overage}" +
                $"&&Order_Comp={m.Order_Comp}&&Obsolete={m.Obsolete}&&Item_Number={m.Item_Number}";
            REST_API_BASE(URLString);
        }

        public static void Disabled_Task_REST(string rowguid)
        {
            string URLString = $"{REST_API.Get_URL_PREFIX()}CRM_Task_Disabled?rowguid={rowguid}";
            REST_API_BASE(URLString);
        }

        public static void Delete_Quote_REST(Quote q)
        {
            string URLString = $"{REST_API.Get_URL_PREFIX()}CRM_Quote_Delete?Quote_Number={q.Quote_Number}";
            REST_API_BASE(URLString);
        }

        public static List<Task> Get_User_Task_REST()
        {
            string URLString = $"{REST_API.Get_URL_PREFIX()}CRM_Task_Get_User_Task?Salesman_Initials={LOGGED_USER.Initials}";
            return JsonConvert.DeserializeObject<List<Task>>(REST_API_BASE(URLString));
        }

        public static List<Quote> Search_Quote_REST(string quote_Number, string org_Name, string contact_Name)
        {
            string URLString = $"{REST_API.Get_URL_PREFIX()}CRM_Quote_Get_Filtered?Quote_Number={quote_Number}&&Org_Name={org_Name}&&Contact_Name={contact_Name}";
            return JsonConvert.DeserializeObject<List<Quote>>(REST_API_BASE(URLString));
        }

        public static void Retrieve_Leasing_Companies_REST()
        {
            string URLString = $"{REST_API.Get_URL_PREFIX()}CRM_Leasing_Companies_Get?";
            LEASING_COMPANIES = JsonConvert.DeserializeObject<List<LeasingCompany>>(REST_API_BASE(URLString));
        }

        public static void Create_Leasing_Company_REST(LeasingCompany l)
        {
            string URLString = $"{REST_API.Get_URL_PREFIX()}CRM_Leasing_Company_Create?Name={l.Name}&&Dollar_24_Rate={l.Dollar_24_Rate}&&Dollar_36_Rate={l.Dollar_36_Rate}" +
                $"&&Dollar_48_Rate={l.Dollar_48_Rate}&&Dollar_60_Rate={l.Dollar_60_Rate}&&FMV_24_Rate={l.FMV_24_Rate}&&FMV_36_Rate={l.FMV_36_Rate}&&FMV_48_Rate={l.FMV_48_Rate}" +
                $"&&FMV_60_Rate={l.FMV_60_Rate}";
            REST_API_BASE(URLString);
            //Retrieve_Leasing_Companies_REST();
            //LEASING_COMPANIES = JsonConvert.DeserializeObject<List<LeasingCompany>>(REST_API_BASE(URLString));
        }

        public static void Update_Leasing_Companies_REST(LeasingCompany l)
        {
            string URLString = $"{REST_API.Get_URL_PREFIX()}CRM_Leasing_Companies_Update?rowguid={l.rowguid}&&Name={l.Name}&&Dollar_24_Rate={l.Dollar_24_Rate}" +
                $"&&Dollar_36_Rate={l.Dollar_36_Rate}&&Dollar_48_Rate={l.Dollar_48_Rate}&&Dollar_60_Rate={l.Dollar_60_Rate}&&FMV_24_Rate={l.FMV_24_Rate}" +
                $"&&FMV_36_Rate={l.FMV_36_Rate}&&FMV_48_Rate={l.FMV_48_Rate}&&FMV_60_Rate={l.FMV_60_Rate}";
            REST_API_BASE(URLString);
        }

        public static List<LeasingCompany> Get_Leasing_Companies()
        {
            return LEASING_COMPANIES;
        }

        public static void Retrieve_Machine_Numbers_REST(string type)
        {
            try
            {
                string URLString = $"{REST_API.Get_URL_PREFIX()}CRM_Machine_Get_Item_Numbers?Type={type}";
                string temp_2 = REST_API_BASE(URLString);
                if (temp_2.Length > 4)
                {
                    temp_2 = temp_2.Remove(0, 2);
                    temp_2 = temp_2.Remove(temp_2.Length - 2, 2);
                    string[] items = temp_2.Split(',');
                    foreach (string s in items)
                    {
                        string[] keyValue = s.Split('=');
                        if (!BASE_MACHINES_DICT.ContainsKey(keyValue[0]))
                        {
                            BASE_MACHINES_DICT.Add(keyValue[0], (int)long.Parse(keyValue[1]));
                        }
                    }
                }


                //foreach (KeyValuePair<string, int> k in DataStore.Get_Base_Machine_Dictionary())
                //{
                //    Console.WriteLine("BSM:" + "KEY: " + k.Key + " VALUE: " + k.Value);
                //}
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public static void Retrieve_Machine_Numbers_ALL_REST()
        {
            try
            {
                string URLString = $"{REST_API.Get_URL_PREFIX()}CRM_Machine_Get_Item_Numbers?Type={0}";
                string temp_2 = REST_API_BASE(URLString);
                if (temp_2.Length > 4)
                {
                    temp_2 = temp_2.Remove(0, 2);
                    temp_2 = temp_2.Remove(temp_2.Length - 2, 2);
                    string[] items = temp_2.Split(',');
                    foreach (string s in items)
                    {
                        string[] keyValue = s.Split('=');
                        if (!MACHINES_DICT.ContainsKey(keyValue[0]))
                        {
                            MACHINES_DICT.Add(keyValue[0], (int)long.Parse(keyValue[1]));
                        }
                    }
                }

                URLString = $"{REST_API.Get_URL_PREFIX()}CRM_Machine_Get_Item_Numbers?Type={"BASE_MACHINE"}";
                temp_2 = REST_API_BASE(URLString);
                if (temp_2.Length > 4)
                {
                    temp_2 = temp_2.Remove(0, 2);
                    temp_2 = temp_2.Remove(temp_2.Length - 2, 2);
                    string[] items = temp_2.Split(',');
                    foreach (string s in items)
                    {
                        string[] keyValue = s.Split('=');
                        if (!MACHINES_DICT.ContainsKey(keyValue[0]))
                        {
                            MACHINES_DICT.Add(keyValue[0], (int)long.Parse(keyValue[1]));
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public static Dictionary<string, int> Get_Machine_Number_Dictionary()
        {
            return MACHINES_DICT;
        }

        public static Dictionary<string, int> Get_Base_Machine_Dictionary()
        {
            return BASE_MACHINES_DICT;
        }

        public static List<Machine> Get_Search_Machines()
        {
            return SEARCHED_MACHINES;
        }

        public static Machine Get_From_Searched_Machines(string Item_Number)
        {
            Machine temp = null;
            foreach (Machine m in SEARCHED_MACHINES)
            {
                if (m.Item_Number.Equals(Item_Number))
                {
                    temp = m;
                }
            }
            return temp;
        }

        public static void Update_Task_REST(string rowguid, string Task_Summnary, string Task_Description)
        {
            string URLString = $"{REST_API.Get_URL_PREFIX()}CRM_Task_Update?rowguid={rowguid}&&Task_Summary={Task_Summnary}&&Task_Description={Task_Description}";
            REST_API_BASE(URLString);
        }

        public static void Retrieve_Machines_Dup(string itemNumber, string description)
        {
            string URLString = $"{REST_API.Get_URL_PREFIX()}CRM_Machine_Dups?ItemNumber={itemNumber}&&Description={description}";
            MACHINES_DUP = JsonConvert.DeserializeObject<List<MachineDup>>(REST_API_BASE(URLString));
        }

        public static List<MachineDup> Get_Machine_Dup()
        {
            return MACHINES_DUP;
        }

        public static Organization Retrieve_ORG(string rowguid)
        {
            foreach (Organization o in ORGS)
            {
                if (o.rowguid.Equals(rowguid))
                {
                    return o;
                }
            }
            return new Organization();
        }

        //################################################################################################################################################

        public static void Add_Quote_Base_REST_(Quote q, Machine m)
        {
            string URLString = $"{REST_API.Get_URL_PREFIX()}CRM_Quote_Add_Base?Quote_Number={q.Quote_Number}&&Machine_Number={m.Machine_Number}&&Model_Cost={m.Model_Cost}" +
                $"&&Selling_Price={m.Selling_Price}&&Print_MP={Process.Bool_To_Binary(m.Print_Model_Pricing)}";
            m.rowguid = Process.Remove_SQL_Symbols(REST_API_BASE(URLString));
        }

        public static void Add_Quote_Base_Detail_REST_(Quote q, Machine b, Machine m)
        {
            string URLString = $"{REST_API.Get_URL_PREFIX()}CRM_Quote_Add_Base_Detail?Quote_Number={q.Quote_Number}&&Base_Rowguid={b.rowguid}&&Accessory_Number={m.Machine_Number}&&Accessory_Price={m.Selling_Price}" +
                $"&&Optional={Process.Bool_To_Binary(m.rowguid.Contains("####"))}";
            REST_API_BASE(URLString);
        }

        public static void Clear_Quote_REST(Quote quote)
        {
            string URLString = $"{REST_API.Get_URL_PREFIX()}CRM_Quote_Clear?Quote_Number={quote.Quote_Number}";
            REST_API_BASE(URLString);
        }

        public static void Get_Quote_Bases_REST(Quote quote)
        {
            string URLString = $"{REST_API.Get_URL_PREFIX()}CRM_Quote_Get_Bases?Quote_Number={quote.Quote_Number}";
            quote.Quote_Set_Machines(JsonConvert.DeserializeObject<List<Machine>>(REST_API_BASE(URLString)));
        }

        public static void Get_Quote_Accessories_REST(Quote quote, Machine machine)
        {
            string URLString = $"{REST_API.Get_URL_PREFIX()}CRM_Quote_Get_Accessories?Quote_Number={quote.Quote_Number}&&Base_Rowguid={machine.rowguid}";
            machine.Set_Accessories(JsonConvert.DeserializeObject<List<Machine>>(REST_API_BASE(URLString)));
        }

        public static Quote Get_Quote_Number_REST(string quote_Number)
        {
            string URLString = $"{REST_API.Get_URL_PREFIX()}CRM_Quote_Get_Quote_Number?Quote_Number={quote_Number}";
            List<Quote> temp = JsonConvert.DeserializeObject<List<Quote>>(REST_API_BASE(URLString));
            Get_Quote_Bases_REST(temp[0]);
            foreach (Machine m in temp[0].Get_Machines())
            {
                Get_Quote_Accessories_REST(temp[0], m);
            }
            return temp[0];
        }
    }
}
