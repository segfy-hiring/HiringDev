using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using SegFyChallenge.Application.Interfaces.Infra;
using SegFyChallenge.Application.Interfaces.Persistence;
using SegFyChallenge.Application.Interfaces.Services;
using SegFyChallenge.Domain.Models;

namespace SegFyChallenge.Application.Services
{
    public class VideoService : IVideoService
    {
        private readonly IVideoRepository _repository;
        private readonly IYoutubeApiClient _youtube;

        public VideoService(IVideoRepository repository, IYoutubeApiClient youtube)
        {
            _repository = repository;
            _youtube = youtube;
        }

        public async Task<Video> GetVideo(int id)
        {
            return await _repository.Get(id);
        }

        public async Task<List<Video>> GetVideos()
        {
            return await _repository.GetAll();
        }

        public async Task<List<Video>> GetVideosFromYoutube(string queryText)
        {
            List<Video> videos = new List<Video>();
            var items = await _youtube.Search(queryText, 5, SearchType.Video);
            var allVideos = await _repository.GetAll();
            if (items != null)
            {
                foreach (var item in items)
                {
                    var video = new Video()
                    {
                        ChannelId = item.ChannelId,
                        Description = item.Description,
                        PublishedAt = (DateTime)item.PublishedAt,
                        Title = item.Title,
                        VideoId = item.VideoId
                    };

                    var found = allVideos.Exists(v => v.VideoId == video.VideoId && v.ChannelId == video.ChannelId);
                    if (!found)
                    {
                        await _repository.Save(video);
                    }

                    videos.Add(video);
                }
            }

            return videos;
        }
    }
}