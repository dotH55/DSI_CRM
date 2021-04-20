using System;
using System.Collections.Generic;

namespace DSI_CRM.Models
{
    public class Contact
    {
        public string rowguid { get; set; }
        public string Contact_Number { get; set; }
        public string First_Name { get; set; }
        public string Last_Name { get; set; }
        public string Prefix { get; set; }
        public string Title { get; set; }
        public string Email { get; set; }
        public string Fax { get; set; }
        public string Mobile_Phone { get; set; }
        public string Location { get; set; }
        public string Salesman_Initials { get; set; }
        public DateTime Date_Created { get; set; }
        public string Org_Name { get; set; }
        public string Organization_Number { get; set; }
        public string Office_Phone { get; set; }

        public List<Address> Addresses = new List<Address>();
        public List<string> TAGS_STR = new List<string>();

        [Newtonsoft.Json.JsonConstructor]
        public Contact(string rowguid, string Org_Name, string Organization_Number, string Contact_Number, string First_Name, string Last_Name, string Prefix, string Title,
             string Email, string Fax, string Mobile_Phone, string Location, string Salesman_Initials, string Office_Phone)
        {
            this.rowguid = rowguid;
            this.Org_Name = Org_Name;
            this.Organization_Number = Organization_Number;
            this.Contact_Number = Contact_Number;
            this.First_Name = First_Name;
            this.Last_Name = Last_Name;
            this.Prefix = Prefix;
            this.Title = Title;
            this.Email = Email;
            this.Fax = Fax;
            this.Mobile_Phone = Mobile_Phone;
            this.Location = Location;
            this.Salesman_Initials = Salesman_Initials;
            this.Office_Phone = Office_Phone;
        }

        public Contact()
        {
            rowguid = null;
            Contact_Number = null;
            Org_Name = null;
            Organization_Number = null;
            First_Name = null;
            Last_Name = null;
            Prefix = null;
            Title = null;
            Email = null;
            Fax = null;
            Mobile_Phone = null;
            Location = null;
            Salesman_Initials = null;
            Date_Created = new DateTime();
            Office_Phone = null;
        }

        public string GetContact_Name()
        {
            return First_Name + " " + Last_Name;
        }

        public List<Address> GetAddresses()
        {
            return Addresses;
        }

        public void SetAddresses(List<Address> addresses)
        {
            Addresses = addresses;
        }

        public void SetTAGS(List<Tag> TAGS)
        {
            TAGS_STR = new List<string>();
            foreach (Tag t in TAGS)
            {
                TAGS_STR.Add(t.Name);
            }
        }

    }
}
