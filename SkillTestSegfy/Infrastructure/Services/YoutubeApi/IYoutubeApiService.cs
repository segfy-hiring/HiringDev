using System.Collections.Generic;
using System.Threading.Tasks;

namespace SkillTestSegfy.Infrastructure.Services.YoutubeApi
{
    public interface IYoutubeApiService
    {
        Task<IEnumerable<string>> Search(string term);
    }
}
