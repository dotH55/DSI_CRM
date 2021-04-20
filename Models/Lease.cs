namespace DSI_CRM.Models
{
    public class Lease
    {
        public string rowguid { get; set; }
        public string Lease_Number { get; set; }
        public string Org_Number { get; set; }
        public string Provider { get; set; }
        public string Equipment { get; set; }
        public string Payment { get; set; }
        public string Lease_End_Date { get; set; }
        public string DSI_Customer_Number { get; set; }
        public string Salesman_Initials { get; set; }
        public string Location { get; set; }

        public Lease()
        {
            rowguid = null;
            Lease_Number = "";
            Org_Number = null;
            Provider = "";
            Equipment = "";
            Payment = "";
            Lease_End_Date = "";
            DSI_Customer_Number = null;
            Salesman_Initials = "";
            Location = "";
        }


        [Newtonsoft.Json.JsonConstructor]
        public Lease(string rowguid, string Lease_Number, string Org_Number, string Provider, string Equipment, string Payment,
            string Lease_End_Date, string DSI_Customer_Number, string Salesman_Initials, string Location)
        {
            this.rowguid = rowguid;
            this.Lease_Number = Lease_Number;
            this.Org_Number = Org_Number;
            this.Provider = Provider;
            this.Equipment = Equipment;
            this.Payment = Payment;
            this.Lease_End_Date = Lease_End_Date;
            this.DSI_Customer_Number = DSI_Customer_Number;
            this.Salesman_Initials = Salesman_Initials;
            this.Location = Location;
        }
    }
}
