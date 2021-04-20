using Syroot.Windows.IO;

namespace DSI_CRM.Models
{
    internal class Environment_Var
    {
        public const string ROOT_FOLDER = @"C:\DSI_CRM\";
        public const string CONFIG_PATH = "Config.json";
        public const string CONFIG_FULL_PATH = ROOT_FOLDER + CONFIG_PATH;
        public const string CREDENTIALS_PATH = "credentials.json";
        public const string CREDENTIALS_FULL_PATH = ROOT_FOLDER + CREDENTIALS_PATH;

        public static string Get_GMAIL_URL(string to, string subject, string body)
        {
            return "https://mail.google.com/mail/u/0/?view=cm&fs=1&to=" + to + "&su=" + subject + "&body=" + body + "&tf=1";
        }

        public static string Get_ROOT_FOLDER()
        {
            return ROOT_FOLDER;
        }

        public static string Get_CONFIG_PATH()
        {
            return CONFIG_PATH;
        }

        public static string Get_CONFIG_FULL_PATH()
        {
            return CONFIG_FULL_PATH;
        }

        public static string Get_DOWNLOAD_FULL_PATH()
        {
            return new KnownFolder(KnownFolderType.Downloads).Path;
        }
    }
}
