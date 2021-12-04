using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YouTubeSearch.Core.Entities;
using YouTubeSearch.Core.Repositories;
using YouTubeSearch.Infrastructure;
using YouTubeSearch.Infrastructure.Repositories.Base;

namespace YouTubeSearch.Infrastructure.Repositories
{
    public class VideoRepository : Repository<Video>, IVideoRepository
    {
        public VideoRepository(DatabaseContext videoContext) : base(videoContext) { }

        public Video GetByName(string name)
        {
            return _context.Video.FirstOrDefault(v => v.Name == name);
        }

        public Video GetByYoutubeId(string id)
        {
            return _context.Video.FirstOrDefault(v => v.YoutubeId == id);
        }

        public List<Video> GetContainsByName(string name)
        {
            return _context.Video.Where(v => v.Name.ToLower().Contains(name.ToLower())).ToList();
        }
    }
}
