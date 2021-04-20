using System;
using System.Collections.Generic;

namespace DSI_CRM.Models
{
    public class Machine
    {
        public string rowguid { get; set; }
        public int Machine_Number { get; set; }
        public string Description { get; set; }
        public string Category { get; set; }
        public string Vendor_Description { get; set; }
        public string Make { get; set; }
        public int Year { get; set; }
        public string Selling_Price { get; set; }
        public string Model_Cost { get; set; }
        public string Configuration_ID { get; set; }
        public string St_Addt_Comments { get; set; }
        public string US_Comm { get; set; }
        public string Purchase { get; set; }
        public string FMV_24_Months { get; set; }
        public string FMV_36_Months { get; set; }
        public string FMV_48_Months { get; set; }
        public string FMV_60_Months { get; set; }
        public string Buyout_24_Months { get; set; }
        public string Buyout_36_Months { get; set; }
        public string Buyout_48_Months { get; set; }
        public string Buyout_60_Months { get; set; }
        public string Overage { get; set; }
        public string Install_Comp { get; set; }
        public string Order_Comp { get; set; }
        public string Obsolete { get; set; }
        public string Item_Number { get; set; }
        public DateTime Created_Datetime { get; set; }
        public bool Include_St_Addt_Comments { get; set; }
        public bool Print_Model_Pricing { get; set; }
        public string Total_Cost { get; set; }
        private List<Machine> Accessories;

        [Newtonsoft.Json.JsonConstructor]
        public Machine(string rowguid, int Machine_Number, string Description, string Category, string Vendor_Description, string Make, int Year
            , string Selling_Price, string Model_Cost, string Configuration_ID, string St_Addt_Comments, string US_Comm, string Purchase, string FMV_24_Months
            , string FMV_36_Months, string FMV_48_Months, string FMV_60_Months, string Buyout_24_Months, string Buyout_36_Months, string Buyout_48_Months, string Buyout_60_Months, string Overage, string Install_Comp, string Order_Comp
            , string Obsolete, string Item_Number, bool Optional, DateTime Created_Datetime)
        {
            this.rowguid = rowguid;
            this.Machine_Number = Machine_Number;
            this.Description = Description;
            this.Category = Category;
            this.Vendor_Description = Vendor_Description;
            this.Make = Make;
            this.Year = Year;
            this.Selling_Price = Selling_Price;
            this.Model_Cost = Model_Cost;
            this.Configuration_ID = Configuration_ID;
            this.St_Addt_Comments = St_Addt_Comments;
            Total_Cost = Total_Cost;
            this.US_Comm = US_Comm;
            this.Obsolete = Obsolete;
            this.Purchase = Purchase;
            this.FMV_24_Months = FMV_24_Months;
            this.FMV_36_Months = FMV_36_Months;
            this.FMV_48_Months = FMV_48_Months;
            this.FMV_60_Months = FMV_60_Months;
            this.Buyout_24_Months = Buyout_24_Months;
            this.Buyout_36_Months = Buyout_36_Months;
            this.Buyout_48_Months = Buyout_48_Months;
            this.Buyout_60_Months = Buyout_60_Months;
            this.Overage = Overage;
            this.Install_Comp = Install_Comp;
            this.Order_Comp = Order_Comp;
            this.Item_Number = Item_Number;
            this.Created_Datetime = Created_Datetime;

            //Optional = true ? Optional.Equals("1") : false;
            if (Optional)
            {
                this.rowguid = rowguid + "####";
            }

            Accessories = new List<Machine>();
        }

        public Machine()
        {
            rowguid = null;
            Machine_Number = 0;
            //this.Item_Number = Item_Number;
            Item_Number = null;
            Description = null;
            Category = null;
            Vendor_Description = null;
            Make = null;
            Year = 0;
            Selling_Price = "0.00";
            Model_Cost = "0.00";
            Configuration_ID = null;
            St_Addt_Comments = null;
            Total_Cost = "0.00";
            US_Comm = "0.00";
            Print_Model_Pricing = false;
            // Obsolete is a bit
            Obsolete = "0";
            Include_St_Addt_Comments = false;
            Purchase = "0.00";
            FMV_24_Months = "0.00";
            FMV_36_Months = "0.00";
            FMV_48_Months = "0.00";
            FMV_60_Months = "0.00";
            Buyout_24_Months = "0.00";
            Buyout_36_Months = "0.00";
            Buyout_48_Months = "0.00";
            Buyout_60_Months = "0.00";
            Overage = "0.00";
            Install_Comp = "0.00";
            Order_Comp = "0.00";
            Created_Datetime = DateTime.Now;

            Accessories = new List<Machine>();
        }

        public void Set_Accessories(List<Machine> newAccessories)
        {
            Accessories = newAccessories;
        }

        public List<Machine> Get_Accessories()
        {
            return Accessories;
        }

        public void Add_Accessory(Machine m)
        {
            bool dupl = false;
            foreach (Machine ma in Accessories)
            {
                if (ma.Item_Number.Equals(m.Item_Number))
                {
                    dupl = true;
                }
            }
            if (!dupl)
            {
                Accessories.Add(m);
            }
        }

        public void Remove_Accessory(string item_Number)
        {
            foreach (Machine ma in Accessories)
            {
                if (ma.Item_Number.Equals(item_Number))
                {
                    Accessories.Remove(ma);
                    return;
                }
            }
        }
    }
}
