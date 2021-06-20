using System.Collections.Generic;
using System.Threading.Tasks;
using Newtonsoft.Json;
using RestSharp;
using SegFyChallenge.Presentation.Models;

namespace SegFyChallenge.Presentation.Services
{
    public class SegFyAppClient : ISegFyAppClient
    {
        private readonly RestClient _client;

        public SegFyAppClient(string apiBaseAddress)
        {
            _client = new RestClient(apiBaseAddress);
        }

        public async Task<ChannelViewModel> GetChannel(int id)
        {
            var request = new RestRequest("Channels/{id}", Method.GET);
            request.AddUrlSegment("id", id);
            
            var result = await _client.ExecuteAsync(request);
            var ret = JsonConvert.DeserializeObject<ChannelViewModel>(result.Content);

            return ret;
        }

        public async Task<List<ChannelViewModel>> GetChannels()
        {
            var request = new RestRequest("Channels", Method.GET);
            var result = await _client.ExecuteAsync(request);
            var ret = JsonConvert.DeserializeObject<List<ChannelViewModel>>(result.Content);

            return ret;
        }

        public async Task<VideoViewModel> GetVideo(int id)
        {
            var request = new RestRequest("Videos/{id}", Method.GET);
            request.AddUrlSegment("id", id);
            
            var result = await _client.ExecuteAsync(request);
            var ret = JsonConvert.DeserializeObject<VideoViewModel>(result.Content);

            return ret;
        }

        public async Task<List<VideoViewModel>> GetVideos()
        {
            var request = new RestRequest("Videos", Method.GET);
            var result = await _client.ExecuteAsync(request);
            var ret = JsonConvert.DeserializeObject<List<VideoViewModel>>(result.Content);

            return ret;
        }

        public async Task<List<ChannelViewModel>> SearchChannels(string queryText)
        {
            var request = new RestRequest("Channels/Search", Method.GET);
            request.AddQueryParameter("queryText", queryText);

            var result = await _client.ExecuteAsync(request);
            var ret = JsonConvert.DeserializeObject<List<ChannelViewModel>>(result.Content);

            return ret;
        }

        public async Task<List<VideoViewModel>> SearchVideos(string queryText)
        {
            var request = new RestRequest("Videos/Search", Method.GET);
            request.AddQueryParameter("queryText", queryText);

            var result = await _client.ExecuteAsync(request);
            var ret = JsonConvert.DeserializeObject<List<VideoViewModel>>(result.Content);

            return ret;
        }
    }
}