using System;

namespace FakeTube
{
    public class ConfigManager
    {
        public static string DatabaseHost => Environment.GetEnvironmentVariable("RDS_HOSTNAME");
        public static string DatabasePort => Environment.GetEnvironmentVariable("RDS_PORT");
        public static string DatabaseSchema => Environment.GetEnvironmentVariable("RDS_DB_NAME");
        public static string DatabaseUser => Environment.GetEnvironmentVariable("RDS_USERNAME");
        public static string DatabasePwd => Environment.GetEnvironmentVariable("RDS_PASSWORD");

        public static string YoutubeApiKey => Environment.GetEnvironmentVariable("YOUTUBE_API_KEY");
        public static string YoutubeApiProject => Environment.GetEnvironmentVariable("YOUTUBE_API_PROJECT");
    }
}
