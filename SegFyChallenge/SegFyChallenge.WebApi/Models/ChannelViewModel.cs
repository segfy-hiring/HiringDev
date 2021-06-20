using System;
using System.Collections.Generic;
using SegFyChallenge.Domain.Models;

namespace SegFyChallenge.WebApi.Models
{
    public class ChannelViewModel
    {
        public int Id { get; set; }
        public string ChannelId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime PublishedAt { get; set; }

        public static List<ChannelViewModel> FromChannels(List<Channel> items)
        {
            var viewModels = new List<ChannelViewModel>();
            foreach (var item in items)
            {
                viewModels.Add(new ChannelViewModel {
                    ChannelId = item.ChannelId,
                    Description = item.Description,
                    Id = item.Id,
                    PublishedAt = item.PublishedAt,
                    Title = item.Title
                });
            }

            return viewModels;
        }
    }
}