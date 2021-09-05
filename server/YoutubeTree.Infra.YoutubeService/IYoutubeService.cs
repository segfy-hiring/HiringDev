using System.Collections.Generic;
using System.Threading.Tasks;

namespace YoutubeTree.Infra.YoutubeService
{
    public interface IYoutubeService
    {
        Task<IEnumerable<YoutubeResponse>> Search(YoutubeRequest request);
    }
}