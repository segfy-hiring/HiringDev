using System;
using System.Collections.Generic;
using SegFyChallenge.Domain.Models;

namespace SegFyChallenge.WebApi.Models
{
    public class VideoViewModel
    {
        public int Id { get; set; }
        public string VideoId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime PublishedAt { get; set; }
        public string ChannelId { get; set; }

        
        public static List<VideoViewModel> FromVideos(List<Video> videos)
        {
            var videosViewModel = new List<VideoViewModel>();
            foreach (var item in videos)
            {
                videosViewModel.Add(new VideoViewModel {
                    ChannelId = item.ChannelId,
                    Description = item.Description,
                    Id = item.Id,
                    PublishedAt = item.PublishedAt,
                    Title = item.Title,
                    VideoId = item.VideoId

                });
            }

            return videosViewModel;
        }


    }
}