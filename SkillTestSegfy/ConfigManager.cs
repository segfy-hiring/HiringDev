using System;

namespace SkillTestSegfy
{
    public class ConfigManager
    {
        public static string DatabaseHost => Environment.GetEnvironmentVariable("RDS_HOSTNAME");
        public static string DatabasePort => Environment.GetEnvironmentVariable("RDS_PORT");
        public static string DatabaseSchema => Environment.GetEnvironmentVariable("RDS_DB_NAME");
        public static string DatabaseUser => Environment.GetEnvironmentVariable("RDS_USERNAME");
        public static string DatabasePwd => Environment.GetEnvironmentVariable("RDS_PASSWORD");

        // main
        //public static string YoutubeApiKey => Environment.GetEnvironmentVariable("YoutubeApiKey");
        //public static string YoutubeApiProject => Environment.GetEnvironmentVariable("YoutubeApiProject");

        // alt
        public static string YoutubeApiKey => Environment.GetEnvironmentVariable("YoutubeApiKeyAlt");
        public static string YoutubeApiProject => Environment.GetEnvironmentVariable("YoutubeApiProjectAlt");
    }
}
