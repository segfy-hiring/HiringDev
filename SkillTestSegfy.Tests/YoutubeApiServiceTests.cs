using Microsoft.VisualStudio.TestTools.UnitTesting;
using SkillTestSegfy.Infrastructure.Services.Youtube;
using System.Linq;
using System.Threading.Tasks;

namespace SkillTestSegfy.Tests
{
    [TestClass]
    public class YoutubeApiServiceTests
    {
        [TestMethod]
        public async Task Search_with_max_results()
        {
            var maxResults = 10;
            var response = await new YoutubeApiService().Search("", maxResults, null);

            Assert.IsTrue(response.Success);
            Assert.AreEqual(response.Items.Count(), maxResults);
        }

        [TestMethod]
        public async Task Search_only_videos()
        {
            // force using "vevo" as the search term,
            // because it is a famous music channel and it will certainly appear at the top of the list
            var response = await new YoutubeApiService().Search("vevo", 10, YoutubeItemType.Video);

            Assert.IsTrue(response.Success);
            Assert.IsTrue(response.Items.All(o => o.Type == YoutubeItemType.Video));
        }

        [TestMethod]
        public async Task Search_only_channels()
        {
            var response = await new YoutubeApiService().Search("", 10, YoutubeItemType.Channel);

            Assert.IsTrue(response.Success);
            Assert.IsTrue(response.Items.All(o => o.Type == YoutubeItemType.Channel));
        }

        [TestMethod]
        public async Task Search_only_playlists()
        {
            var response = await new YoutubeApiService().Search("", 10, YoutubeItemType.Playlist);

            Assert.IsTrue(response.Success);
            Assert.IsTrue(response.Items.All(o => o.Type == YoutubeItemType.Playlist));
        }

        [TestMethod]
        public async Task Search_with_no_results()
        {
            var response = await new YoutubeApiService().Search("GHUUJEDSAKOPDSASHUGYFARTDRTDASIJKLDSA", 10, null);

            Assert.IsTrue(response.Success);
            Assert.AreEqual(response.Items.Count(), 0);
        }
    }
}
