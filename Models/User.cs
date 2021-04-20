using System.Security.Cryptography;

namespace DSI_CRM.Models
{
    internal class User
    {
        public string rowguid { get; set; }
        public string Initials { get; set; }
        public string First_Name { get; set; }
        public string Last_Name { get; set; }
        public string Password { get; set; }
        public string Location { get; set; }

        [Newtonsoft.Json.JsonConstructor]
        public User(string rowguid, string Initials, string First_Name, string Last_Name, string Location, string Password)
        {
            this.rowguid = rowguid;
            this.Initials = Initials;
            this.First_Name = First_Name;
            this.Last_Name = Last_Name;
            this.Location = Location;
            this.Password = Password;
        }

        public bool ComparePassword(string user_pwd, string saved_pwd)
        {
            string HashPass = string.Empty;
            HashPass = CreatePasswordHash(user_pwd);

            int result = string.Compare(HashPass, saved_pwd, true);
            return result == 0;
        }

        public string Get_Contact_Name()
        {
            return First_Name + " " + Last_Name;
        }

        /// <summary>
        /// This method creates an Hash
        /// </summary>
        /// <param name="pwd">Password</param>
        /// <returns>Hash Result</returns>
        public string CreatePasswordHash(string pwd)
        {
            //Copy from Ken
            byte[] Data = System.Text.ASCIIEncoding.ASCII.GetBytes(pwd); // System.Text.UTF8Encoding.UTF8.GetBytes(pwd);
            //SHA256Manage
            SHA512Managed sha = new SHA512Managed();
            byte[] HashValue = sha.ComputeHash(Data);
            string result = string.Empty;

            foreach (byte h in HashValue)
            {
                //Have to pad, was dropping leading Zero in hex number, ie 08 was coming back as 8
                result += string.Format("{0:X}", h).PadLeft(2, '0');
            }

            return result;
        }

        public string To_String()
        {
            return Initials + " " + First_Name + " " + Last_Name + " " + Location + " " + Password;
        }
    }
}
