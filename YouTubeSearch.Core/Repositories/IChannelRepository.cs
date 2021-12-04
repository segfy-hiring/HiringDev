using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YouTubeSearch.Core.Entities;
using YouTubeSearch.Core.Repositories.Base;

namespace YouTubeSearch.Core.Repositories
{
    public interface IChannelRepository : IRepository<Channel>
    {
        public Channel GetByName(string name);
        public List<Channel> GetContainsByName(string name);
        public Channel GetByYoutubeId(string id);

    }
}
