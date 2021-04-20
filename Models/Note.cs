namespace DSI_CRM.Models
{
    public class Note
    {
        public string rowguid { get; set; }
        public string Note_Number { get; set; }
        public string Contact_Number { get; set; }
        public string Contact_Name { get; set; }
        public string Type { get; set; }
        public string Description { get; set; }
        public string Salesman_Initials { get; set; }
        public string Action_Date { get; set; }
        public string Action_Status { get; set; }
        public string Creation_Date { get; set; }
        public string Location { get; set; }

        [Newtonsoft.Json.JsonConstructor]
        public Note(string rowguid, string Note_Number, string Contact_Number, string Contact_Name, string Type, string Description, string Salesman_Initials,
            string Action_Date, string Action_Status, string Creation_Date, string Location)
        {
            this.rowguid = rowguid;
            this.Note_Number = Note_Number;
            this.Contact_Number = Contact_Number;
            this.Contact_Name = Contact_Name;
            this.Type = Type;
            this.Description = Description;
            this.Salesman_Initials = Salesman_Initials;
            this.Action_Date = Action_Date;
            this.Action_Status = Action_Status;
            this.Creation_Date = Creation_Date;
            this.Location = Location;
        }

        public Note()
        {
            rowguid = null;
            Note_Number = null;
            Contact_Number = null;
            Contact_Name = null;
            Type = null;
            Description = null;
            Salesman_Initials = null;
            Action_Date = null;
            Action_Status = null;
            Creation_Date = null;
            Location = null;
        }
    }
}
