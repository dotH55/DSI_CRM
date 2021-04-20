namespace DSI_CRM.Models
{
    public partial class Tag
    {
        public string rowguid { get; set; }
        public string Tag_Number { get; set; }
        public string Name { get; set; }
        public string Salesman { get; set; }

        [Newtonsoft.Json.JsonConstructor]
        public Tag(string rowguid, string Name, string Salesman, string Tag_Number)
        {
            this.rowguid = rowguid;
            this.Name = Name;
            this.Salesman = Salesman;
            this.Tag_Number = Tag_Number;
        }

        public Tag(string Name, string Salesman)
        {
            this.Name = Name;
            this.Salesman = Salesman;
        }
    }
}
