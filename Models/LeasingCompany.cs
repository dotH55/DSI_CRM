namespace DSI_CRM.Models
{
    public class LeasingCompany
    {
        public string rowguid { get; set; }
        public string Name { get; set; }
        public string Dollar_24_Rate { get; set; }
        public string Dollar_36_Rate { get; set; }
        public string Dollar_48_Rate { get; set; }
        public string Dollar_60_Rate { get; set; }
        public string FMV_24_Rate { get; set; }
        public string FMV_36_Rate { get; set; }
        public string FMV_48_Rate { get; set; }
        public string FMV_60_Rate { get; set; }

        [Newtonsoft.Json.JsonConstructor]
        public LeasingCompany(string rowguid, string Name, string Dollar_24_Rate, string Dollar_36_Rate, string Dollar_48_Rate, string Dollar_60_Rate
            , string FMV_24_Rate, string FMV_36_Rate, string FMV_48_Rate, string FMV_60_Rate)
        {
            this.rowguid = rowguid;
            this.Name = Name;
            this.Dollar_24_Rate = Dollar_24_Rate;
            this.Dollar_36_Rate = Dollar_36_Rate;
            this.Dollar_48_Rate = Dollar_48_Rate;
            this.Dollar_60_Rate = Dollar_60_Rate;
            this.FMV_24_Rate = FMV_24_Rate;
            this.FMV_36_Rate = FMV_36_Rate;
            this.FMV_48_Rate = FMV_48_Rate;
            this.FMV_60_Rate = FMV_60_Rate;
        }

        public LeasingCompany()
        {
            rowguid = null;
            Name = null;
            Dollar_24_Rate = "0";
            Dollar_36_Rate = "0";
            Dollar_48_Rate = "0";
            Dollar_60_Rate = "0";
            FMV_24_Rate = "0";
            FMV_36_Rate = "0";
            FMV_48_Rate = "0";
            FMV_60_Rate = "0";
        }
    }
}
