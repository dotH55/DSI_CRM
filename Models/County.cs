namespace DSI_CRM.Models
{
    internal class County
    {
        public string County_Name { get; set; }
        public string State { get; set; }

        [Newtonsoft.Json.JsonConstructor]
        public County(string County, string State)
        {
            County_Name = County;
            this.State = State;
        }
    }
}
