using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using SegFyChallenge.Application.Interfaces.Infra;
using SegFyChallenge.Application.Interfaces.Persistence;
using SegFyChallenge.Application.Interfaces.Services;
using SegFyChallenge.Domain.Models;

namespace SegFyChallenge.Application.Services
{
    public class ChannelService : IChannelService
    {
        private readonly IChannelRepository _repository;
        private readonly IYoutubeApiClient _youtube;

        public ChannelService(IChannelRepository repository, IYoutubeApiClient youtube)
        {
            _repository = repository;
            _youtube = youtube;
        }

        public async Task<Channel> GetChannel(int id)
        {
            return await _repository.Get(id);
        }

        public async Task<List<Channel>> GetChannels()
        {
            return await _repository.GetAll();
        }

        public async Task<List<Channel>> GetChannelsFromYoutube(string queryText)
        {
            List<Channel> channels = new List<Channel>();
            var items = await _youtube.Search(queryText, 5, SearchType.Channel);
            var allChannels = await _repository.GetAll();
            if (items != null)
            {
                foreach (var item in items)
                {
                    var channel = new Channel()
                    {
                        ChannelId = item.ChannelId,
                        Description = item.Description,
                        PublishedAt = (DateTime)item.PublishedAt,
                        Title = item.Title
                    };

                    var found = allChannels.Exists(c => c.ChannelId == channel.ChannelId);
                    if (!found)
                    {
                        await _repository.Save(channel);
                    }

                    channels.Add(channel);
                }
            }

            return channels;
        }
    }
}