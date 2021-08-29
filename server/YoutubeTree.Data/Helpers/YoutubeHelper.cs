using Google.Apis.YouTube.v3.Data;

namespace YoutubeTree.Data
{
    public static class YoutubeHelper
    {
        public static string GetId(ResourceId resource)
        {
            if (!string.IsNullOrEmpty(resource.ChannelId))
            {
                return resource.ChannelId;
            }

            if (!string.IsNullOrEmpty(resource.VideoId))
            {
                return resource.VideoId;
            }

            return resource.PlaylistId;
        }

        public static string GetRsourceType(ResourceId resource)
        {
            return resource.Kind.Split("#")[1];
        }
    }
}