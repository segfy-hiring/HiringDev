using Google.Apis.Services;
using Google.Apis.YouTube.v3;
using Google.Apis.YouTube.v3.Data;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SkillTestSegfy.Core
{
    public enum Type
    {
        Video, Channel, Playlist
    }

    public class YoutubeHelper
    {
        public static async Task<IEnumerable<SearchResult>> Search(string term)
        {
            var youtubeService = new YouTubeService(new BaseClientService.Initializer
            {
                ApiKey = "AIzaSyBQEHRxdlcLP-tMjidzf4DE8uptV5VvFaA",
                ApplicationName = "SkillTestSegfy"
            });

            var searchListRequest = youtubeService.Search.List("snippet");
            searchListRequest.Q = term; // Replace with your search term.
            searchListRequest.MaxResults = 20;

            // Call the search.list method to retrieve results matching the specified query term.
            var searchListResponse = await searchListRequest.ExecuteAsync();

            return searchListResponse.Items;

            //var videos = new List<SearchResult>();
            ////var channels = new List<string>();
            ////var playlists = new List<string>();

            // Add each result to the appropriate list, and then display the lists of
            // matching videos, channels, and playlists.
            //foreach (var searchResult in searchListResponse.Items)
            //{
            //    switch (searchResult.Id.Kind)
            //    {
            //        case "youtube#video":
            //            videos.Add(String.Format("{0} ({1})", searchResult.Snippet.Title, searchResult.Id.VideoId));
            //            break;

            //        case "youtube#channel":
            //            channels.Add(String.Format("{0} ({1})", searchResult.Snippet.Title, searchResult.Id.ChannelId));
            //            break;

            //        case "youtube#playlist":
            //            playlists.Add(String.Format("{0} ({1})", searchResult.Snippet.Title, searchResult.Id.PlaylistId));
            //            break;
            //    }
            //}

            //Console.WriteLine(String.Format("Videos:\n{0}\n", string.Join("\n", videos)));
            //Console.WriteLine(String.Format("Channels:\n{0}\n", string.Join("\n", channels)));
            //Console.WriteLine(String.Format("Playlists:\n{0}\n", string.Join("\n", playlists)));
        }
    }
}
