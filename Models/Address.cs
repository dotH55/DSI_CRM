namespace DSI_CRM.Models
{
    public class Address
    {
        public string rowguid { get; set; }
        public string Address_Number { get; set; }
        public string Address_1 { get; set; }
        public string Address_2 { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Zip { get; set; }
        public string County { get; set; }

        [Newtonsoft.Json.JsonConstructor]
        public Address(string Address_Number, string rowguid, string Address_1, string Address_2, string City, string State, string Zip, string County)
        {
            this.rowguid = rowguid;
            this.Address_Number = Address_Number;
            this.Address_1 = Address_1;
            this.Address_2 = Address_2;
            this.City = City;
            this.State = State;
            this.Zip = Zip;
            this.County = County;
        }

        public Address(string Address_1, string Address_2, string City, string State, string Zip, string County)
        {
            rowguid = null;
            Address_Number = null;
            this.Address_1 = Address_1;
            this.Address_2 = Address_2;
            this.City = City;
            this.State = State;
            this.Zip = Zip;
            this.County = County;
        }


        public string To_String()
        {
            return Address_1 + " " + Address_2 + " " + City + " " + State + " " + Zip + " " + County;
        }
    }
}
