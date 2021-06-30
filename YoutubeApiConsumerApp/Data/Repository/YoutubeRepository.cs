using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using YoutubeApiConsumerApp.Data.Repository.Interfaces;
using YoutubeApiConsumerApp.Models;

namespace YoutubeApiConsumerApp.Data
{
    public class YoutubeRepository : IYoutubeRepository, IDisposable
    {
        private readonly Context _context;
        private bool disposedValue = false;

        public YoutubeRepository(Context context)
        {
            _context = context;
        }
        public SearchResponseModel GetAllVideosAndChannels()
        {
            var videos = _context.Video.ToList();
            var channels = _context.Channel.ToList();

            return new SearchResponseModel(videos, channels);
        }

        public async Task<int> SaveSearchedVideos(YoutubeVideoModel youtubeVideoViewModel)
        {
            _context.Video.Add(youtubeVideoViewModel);
            return await _context.SaveChangesAsync();
        }

        public async Task<int> SaveSearchedChannels(YoutubeChannelModel youtubeChannelViewModel)
        {
            _context.Channel.Add(youtubeChannelViewModel);
            return await _context.SaveChangesAsync();
        }

        public Boolean IsVideoAlreadySaved(string Id)
        {
            var video = _context.Video.Find(Id);

            if (video == null)
            {
                return false;
            }
            return true;
        }

        public Boolean IsChannelAlreadySaved(string Id)
        {
            var channel = _context.Channel.Find(Id);

            if (channel == null)
            {
                return false;
            }
            return true;
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    _context.Dispose();
                }

                disposedValue = true;
            }
        }

        public void Dispose()
        {
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }
    }
}
