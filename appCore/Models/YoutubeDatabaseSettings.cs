namespace appCore.Models
{
     public class YoutubeDatabaseSettings : IYoutubeDatabaseSettings
    {
        public string YTCollectionName { get; set; }
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
    }

    public interface IYoutubeDatabaseSettings
    {
        string YTCollectionName { get; set; }
        string ConnectionString { get; set; }
        string DatabaseName { get; set; }
    }
}