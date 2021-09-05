using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using YoutubeTree.Infra.YoutubeService;

namespace YoutubeTree.Tests
{
    public class YoutubeFakeService : IYoutubeService
    {
        readonly List<YoutubeResponse> _datasource;
        
        public YoutubeFakeService(List<YoutubeResponse> dataSource)
        {
            _datasource = dataSource;
        }

        public Task<IEnumerable<YoutubeResponse>> Search(YoutubeRequest request)
        {
            return Task.FromResult(_datasource.AsEnumerable());
        }
    }
}