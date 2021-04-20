using System;
using System.Collections.Generic;

namespace DSI_CRM.Models
{
    public class Quote
    {

        //Notes
        // Each quote object will be converted to JsonObj and saved on the database
        // guids
        public string rowguid { get; set; }
        public string Quote_Number { get; set; }
        public string Org_Number { get; set; }
        public string Contact_Number { get; set; }
        public string Org_Name { get; set; }
        public string Contact_Name { get; set; }

        public string Man_Rebate { get; set; }
        public string Less_Disc_Trade { get; set; }
        public string Addt_Lease_Fees { get; set; }

        public string BW { get; set; }
        public string BW_Excess { get; set; }
        public string Color { get; set; }
        public string Color_Excess { get; set; }
        public string Terms { get; set; }
        public string Maint_Type { get; set; }
        public string Maint_Total_Cost { get; set; }

        public string Lease_Fees { get; set; }
        public string Lease_Type { get; set; }
        public string Leasing_Company { get; set; }

        public string Month_1 { get; set; }
        public string Month_2 { get; set; }
        public string Month_3 { get; set; }
        public string Month_4 { get; set; }

        public string Payment_1 { get; set; }
        public string Payment_2 { get; set; }
        public string Payment_3 { get; set; }
        public string Payment_4 { get; set; }

        public string Lease_Rate_1 { get; set; }
        public string Lease_Rate_2 { get; set; }
        public string Lease_Rate_3 { get; set; }
        public string Lease_Rate_4 { get; set; }

        public string Addt_Info { get; set; }

        public DateTime Created_Datetime { get; set; }
        public string Salesman_Initials { get; set; }

        public Location Install_Location { get; set; }
        public Location Quote_To_Location { get; set; }
        public List<Machine> Machines { get; set; }

        [Newtonsoft.Json.JsonConstructor]
        public Quote(string rowguid, string Quote_Number, string Org_Number, string Contact_Number, string Org_Name, string Contact_Name,
            string Man_Rebate, string Less_Disc_Trade, string Addt_Lease_Fees, string BW, string BW_Excess, string Color, string Color_Excess,
            string Terms, string Maint_Type, string Maint_Total_Cost, string Lease_Fees, string Lease_Type, string Leasing_Company, string Month_1,
            string Month_2, string Month_3, string Month_4, string Payment_1, string Payment_2, string Payment_3, string Payment_4, string Lease_Rate_1, string Lease_Rate_2,
            string Lease_Rate_3, string Lease_Rate_4, string Additional_Info, DateTime Created_Datetime, string Salesman_Initials, string Install_Name, string Install_Phone, 
            string Install_Addr_1, string Install_Addr_2, string Install_City, string Install_State, string Install_Zip, string Install_County)
        {

            this.rowguid = rowguid;
            this.Quote_Number = Quote_Number;
            this.Org_Number = Org_Number;
            this.Contact_Number = Contact_Number;
            this.Org_Name = Org_Name;
            this.Contact_Name = Contact_Name;
            this.Man_Rebate = Man_Rebate;
            this.Less_Disc_Trade = Less_Disc_Trade;
            this.Addt_Lease_Fees = Addt_Lease_Fees;
            this.BW = BW;
            this.BW_Excess = BW_Excess;
            this.Color = Color;
            this.Color_Excess = Color_Excess;
            this.Terms = Terms;
            this.Maint_Type = Maint_Type;
            this.Maint_Total_Cost = Maint_Total_Cost;
            this.Lease_Type = Lease_Type;
            this.Lease_Fees = Lease_Fees;
            this.Leasing_Company = Leasing_Company;
            this.Month_1 = Month_1;
            this.Month_2 = Month_2;
            this.Month_3 = Month_3;
            this.Month_4 = Month_4;
            this.Payment_1 = Payment_1;
            this.Payment_2 = Payment_2;
            this.Payment_3 = Payment_3;
            this.Payment_4 = Payment_4;
            this.Lease_Rate_1 = Lease_Rate_1;
            this.Lease_Rate_2 = Lease_Rate_2;
            this.Lease_Rate_3 = Lease_Rate_3;
            this.Lease_Rate_4 = Lease_Rate_4;
            this.Addt_Info = Additional_Info;
            this.Created_Datetime = Created_Datetime;
            this.Salesman_Initials = Salesman_Initials;

            Install_Location = new Location();
            Install_Location.Name = Install_Name;
            Install_Location.Phone = Install_Phone;
            Install_Location.Addr_1 = Install_Addr_1;
            Install_Location.Addr_2 = Install_Addr_2;
            Install_Location.City = Install_City;
            Install_Location.State = Install_State;
            Install_Location.Zip = Install_Zip;
            Install_Location.County = Install_County;
        }

        public Quote(string Org_Number, string Contact_Number)
        {
            //rowguid = Guid.NewGuid().ToString();
            Machines = new List<Machine>();

            rowguid = null;
            Quote_Number = null;
            this.Org_Number = Org_Number;
            this.Contact_Number = Contact_Number;
            Org_Name = null;
            Terms = "MONTLY";
            Lease_Type = "FMV";
            Maint_Type = "UNLIMITED_SERVICE_SUPPLIES";
            Addt_Info = null;
            Month_1 = null;
            Month_2 = null;
            Month_3 = null;
            Month_4 = null;
            Payment_1 = "0.0";
            Payment_2 = "0.0";
            Payment_3 = "0.0";
            Payment_4 = "0.0";
            Lease_Rate_1 = "0.0";
            Lease_Rate_2 = "0.0";
            Lease_Rate_3 = "0.0";
            Lease_Rate_4 = "0.0";
            Lease_Fees = "0.0";
            Leasing_Company = "CFS ADMIN FEE INCLUSIVE";
            Created_Datetime = DateTime.Now;
            Salesman_Initials = null;
            Man_Rebate = "0.0";
            Less_Disc_Trade = "0.0";
            Addt_Lease_Fees = "0.0";
            BW = "0.0";
            BW_Excess = "0.0";
            Color = "0.0";
            Color_Excess = "0.0";
            Maint_Total_Cost = "0.0";
        }


        public void Set_Install_Location(Location Install_Location)
        {
            this.Install_Location = Install_Location;
        }

        public void Set_Quote_To_Location(Location Quote_To_Location)
        {
            this.Quote_To_Location = Quote_To_Location;
        }

        public void Quote_Add_Machine(Machine m)
        {
            Machines.Add(m);
        }

        public void Quote_Set_Machines(List<Machine> machines)
        {
            Machines = machines;
        }

        public List<Machine> Get_Machines()
        {
            return Machines;
        }

    }
}
