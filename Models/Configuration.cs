using System.Drawing;

namespace DSI_CRM.Models
{
    internal class Configuration
    {
        public bool Theme { get; set; }
        public string Email_Addr { get; set; }
        public string Email_Password { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public Color Theme_Color { get; set; }

        [Newtonsoft.Json.JsonConstructor]
        public Configuration(bool theme, string Email_Addr, string Email_Password, string Username, string Password, Color Theme_Color)
        {
            Theme = theme;
            this.Email_Addr = Email_Addr;
            this.Email_Password = Email_Password;
            this.Username = Username;
            this.Password = Password;
            this.Theme_Color = Theme_Color;
        }

        public Configuration()
        {
            Theme = false;
            Email_Addr = "";
            Email_Password = "";
            Username = "";
            Password = "";
            Theme_Color = Color.DimGray;
        }

        public string Get_Username()
        {
            return Username;
        }

        public string Get_Password()
        {
            return Password;
        }

        public void Set_Username(string Username)
        {
            this.Username = Username;
        }

        public void Set_Password(string Password)
        {
            this.Password = Password;
        }

        public void Set_Username_Password(string username, string password)
        {
            Set_Username(username);
            Set_Password(password);
        }

        public bool Get_Theme()
        {
            return Theme;
        }

        public void Set_Theme(bool theme)
        {
            Theme = theme;
        }

    }
}
