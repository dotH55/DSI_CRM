using System.Collections.Generic;

namespace DSI_CRM.Models
{
    public class Organization
    {
        public string rowguid { get; set; }
        public string Organization_Number { get; set; }
        public string Name { get; set; }
        public string Notes { get; set; }
        public string Phone { get; set; }
        public string Fax { get; set; }
        public string Website { get; set; }
        public string Location { get; set; }
        public string Salesman_Initials { get; set; }
        public string DSI_Customer_Number { get; set; }
        public string Date_Created { get; set; }
        public string Org_Status { get; set; }

        private List<Contact> Contacts = new List<Contact>();
        private List<Address> Addresses = new List<Address>();
        private List<Note> NOTES = new List<Note>();
        private List<Task> TASKS = new List<Task>();
        private List<Lease> LEASES = new List<Lease>();
        private List<Quote> QUOTE = new List<Quote>();

        //private List<Tag> TAGS = new List<Tag>();
        private List<string> TAGS_STR = new List<string>();

        [Newtonsoft.Json.JsonConstructor]
        public Organization(string rowguid, string Organization_Number, string Name, string Notes, string Phone,
            string Fax, string Website, string Location, string Salesman_Initials, string DSI_Customer_Number, string Date_Created, string Org_Status)
        {
            this.rowguid = rowguid;
            this.Organization_Number = Organization_Number;
            this.Name = Name;
            this.Notes = Notes;
            this.Phone = Phone;
            this.Fax = Fax;
            this.Website = Website;
            this.Location = Location;
            this.Salesman_Initials = Salesman_Initials;
            this.DSI_Customer_Number = DSI_Customer_Number;
            this.Date_Created = Date_Created;
            this.Org_Status = Org_Status;
        }



        public Organization(string Name, string Phone)
        {
            this.Name = Name;
            this.Phone = Phone;
            rowguid = null;
            Organization_Number = null;
            Notes = null;
            Fax = null;
            Website = null;
            Location = null;
            Salesman_Initials = null;
            DSI_Customer_Number = null;
            Date_Created = null;
        }

        public Organization()
        {
            rowguid = null;
            Organization_Number = null;
            Name = null;
            Notes = null;
            Phone = null;
            Fax = null;
            Website = null;
            Location = null;
            Salesman_Initials = null;
            DSI_Customer_Number = null;
            Date_Created = null;
        }

        private void Retrieve_Contact()
        {

        }

        public List<Contact> GetContacts()
        {
            return Contacts;
        }

        public void AddContact(Contact newContact)
        {
            Contacts.Add(newContact);
        }

        public void AddAddress(Address newAddress)
        {
            Addresses.Add(newAddress);
        }

        public void AddNote(Note note)
        {
            NOTES.Add(note);
        }

        public void SetAddresses(List<Address> Addresses)
        {
            this.Addresses = Addresses;
        }

        public void SetContacts(List<Contact> Contacts)
        {
            this.Contacts = Contacts;
        }

        public void SetNotes(List<Note> NOTES)
        {
            this.NOTES = NOTES;
        }

        public List<Note> GetNote()
        {
            return NOTES;
        }

        public List<Address> GetAddresses()
        {
            return Addresses;
        }

        public bool hasAddr()
        {
            if (Addresses.Count > 0)
            {
                return true;
            }
            return false;
        }

        public List<string> Get_Tags_Str()
        {
            return TAGS_STR;
        }

        public void SetTAGS(List<Tag> TAGS)
        {
            TAGS_STR = new List<string>();
            foreach (Tag t in TAGS)
            {
                TAGS_STR.Add(t.Name);
            }
        }

        public void AddTAG(Tag tag)
        {
            TAGS_STR.Add(tag.Name);
        }

        public List<Lease> Get_LEASES()
        {
            return LEASES;
        }

        public void Set_LEASES(List<Lease> leases)
        {
            LEASES = leases;
        }

        public void Add_Lease(Lease lease)
        {
            LEASES.Add(lease);
        }

        public void Set_Task(List<Task> tasks)
        {
            TASKS = tasks;
        }

        public List<Task> Get_Tasks()
        {
            return TASKS;
        }

        public void Add_Task(Task task)
        {
            TASKS.Add(task);
        }

        public void Set_Quote(List<Quote> quote)
        {
            QUOTE = quote;
        }

        public List<Quote> Get_Quote()
        {
            return QUOTE;
        }

        public void Add_Quote(Quote quote)
        {
            QUOTE.Add(quote);
        }
    }
}
