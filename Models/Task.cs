using Google.Apis.Calendar.v3.Data;
using System;

namespace DSI_CRM.Models
{
    public class Task
    {
        public string rowguid { get; set; }
        public string Contact_Number { get; set; }
        public string Org_Number { get; set; }
        public int Task_Number { get; set; }
        public string Org_Name { get; set; }
        public string Org_Website { get; set; }
        public string Org_Phone_Number { get; set; }
        public Event Task_Event { get; set; }
        public string Type { get; set; }
        public string Salesman_Initials { get; set; }
        public string Location { get; set; }
        public string Status { get; set; }

        [Newtonsoft.Json.JsonConstructor]
        public Task(string rowguid, string Org_Number, string Contact_Number, int Task_Number, string Type, string Task_Summary, string Task_Description, string Org_Name, string Org_Website
            , string Org_Phone_Number, DateTime Created_Datetime, DateTime Start_Datetime, DateTime End_Datetime, string Salesman_Initials, string Status, string Location)
        {
            this.rowguid = rowguid;
            this.Contact_Number = Contact_Number;
            this.Org_Number = Org_Number;
            this.Org_Name = Org_Name;
            this.Task_Number = Task_Number;
            this.Org_Website = Org_Website;
            EventDateTime start = new EventDateTime { DateTime = Start_Datetime };
            EventDateTime end = new EventDateTime { DateTime = End_Datetime };
            Task_Event = new Event { Created = Created_Datetime, Start = start, End = end, Description = Task_Description, Summary = Task_Summary };
            this.Org_Phone_Number = Org_Phone_Number;
            this.Type = Type;
            this.Salesman_Initials = Salesman_Initials;
            this.Status = Status;
            this.Location = Location;

        }

        public Task()
        {
            rowguid = Guid.NewGuid().ToString();
            Contact_Number = null;
            Org_Number = null;
            Org_Name = null;
            Task_Number = 0;
            Org_Website = null;
            Task_Event = null;
            Org_Phone_Number = null;
            Type = null;
            Salesman_Initials = null;
            Location = null;
            Status = null;
        }
    }
}
