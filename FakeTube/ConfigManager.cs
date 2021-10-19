using System;

namespace FakeTube
{
    public class ConfigManager
    {
        //public static string DatabaseHost => Environment.GetEnvironmentVariable("RDS_HOSTNAME");
        //public static string DatabasePort => Environment.GetEnvironmentVariable("RDS_PORT");
        //public static string DatabaseSchema => Environment.GetEnvironmentVariable("RDS_DB_NAME");
        //public static string DatabaseUser => Environment.GetEnvironmentVariable("RDS_USERNAME");
        //public static string DatabasePwd => Environment.GetEnvironmentVariable("RDS_PASSWORD");

        //public static string YoutubeApiKey => Environment.GetEnvironmentVariable("YOUTUBE_API_KEY");
        //public static string YoutubeApiProject => Environment.GetEnvironmentVariable("YOUTUBE_API_PROJECT");

        // ##################################################
        // ##################################################
        // ##################################################
        // ##################################################
        public static string DatabaseHost => "localhost";
        public static string DatabasePort => "3306";
        public static string DatabaseSchema => "FakeTube";
        public static string DatabaseUser => "root";
        public static string DatabasePwd => "root";

        // main
        public static string YoutubeApiKey => "AIzaSyC1PRPMS1pILHkeyu-W38xAUflTzNSqSG0";
        public static string YoutubeApiProject => "SkillTestSegfy";

        // alt
        //public static string YoutubeApiKey => "AIzaSyD6zgYY607z8XqV-cfTKyCxrTgMLn2f9Ew";
        //public static string YoutubeApiProject => "SkillTestSegfyAlt";
    }
}
