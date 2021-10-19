using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FakeTube.Domain.Entities;
using FakeTube.Infrastructure.Database;
using FakeTube.Infrastructure.Services.Youtube;
using System.Linq;
using System.Threading.Tasks;

namespace FakeTube.Tests
{
    [TestClass]
    public class YoutubeApiServiceTests
    {
        private DatabaseContext DatabaseContext { get; set; }
        private YoutubeApiService YoutubeApiService { get; set; }

        [TestInitialize]
        public void TestInitialize()
        {
            DatabaseContext = new DatabaseContext(true);
            DatabaseContext.Database.EnsureDeleted();
            DatabaseContext.Database.EnsureCreated();

            YoutubeApiService = new YoutubeApiService(DatabaseContext);
        }

        [TestCleanup]
        public void TestCleanup()
        {
            DatabaseContext.Dispose();
        }

        [TestMethod]
        public async Task Search_with_max_results()
        {
            var maxResults = 5;
            var response = await YoutubeApiService.Search("", maxResults, null);

            Assert.IsTrue(response.Success);
            Assert.AreEqual(response.Items.Count(), maxResults);

            var repository = DatabaseContext.Set<YoutubeItem>();
            var historyCount = await repository.CountAsync();

            Assert.AreEqual(historyCount, maxResults);
        }

        [TestMethod]
        public async Task Search_only_videos()
        {
            // force using "vevo" as the search term,
            // because it is a famous music channel and it will certainly appear at the top of the list
            var response = await YoutubeApiService.Search("vevo", 5, YoutubeItemType.Video);

            Assert.IsTrue(response.Success);
            Assert.IsTrue(response.Items.All(o => o.Type == YoutubeItemType.Video));

            var repository = DatabaseContext.Set<YoutubeItem>();
            var history = await repository.ToListAsync();

            Assert.IsTrue(history.All(o => o.Type == YoutubeItemType.Video));
        }

        [TestMethod]
        public async Task Search_only_channels()
        {
            var response = await YoutubeApiService.Search("", 5, YoutubeItemType.Channel);

            Assert.IsTrue(response.Success);
            Assert.IsTrue(response.Items.All(o => o.Type == YoutubeItemType.Channel));

            var repository = DatabaseContext.Set<YoutubeItem>();
            var history = await repository.ToListAsync();

            Assert.IsTrue(history.All(o => o.Type == YoutubeItemType.Channel));
        }

        [TestMethod]
        public async Task Search_only_playlists()
        {
            var response = await YoutubeApiService.Search("", 5, YoutubeItemType.Playlist);

            Assert.IsTrue(response.Success);
            Assert.IsTrue(response.Items.All(o => o.Type == YoutubeItemType.Playlist));

            var repository = DatabaseContext.Set<YoutubeItem>();
            var history = await repository.ToListAsync();

            Assert.IsTrue(history.All(o => o.Type == YoutubeItemType.Playlist));
        }

        [TestMethod]
        public async Task Search_with_no_results()
        {
            var response = await YoutubeApiService.Search("GHUUJEDSAKOPDSASHUGYFARTDRTDASIJKLDSA", 5, null);

            Assert.IsTrue(response.Success);
            Assert.AreEqual(response.Items.Count(), 0);

            var repository = DatabaseContext.Set<YoutubeItem>();
            var historyCount = await repository.CountAsync();

            Assert.AreEqual(historyCount, 0);
        }

        [TestMethod]
        public async Task History_must_replace_repeated_items()
        {
            var response = await YoutubeApiService.Search("PSY - GANGNAM STYLE", 3, YoutubeItemType.Video);
            Assert.IsTrue(response.Success);

            response = await YoutubeApiService.Search("PSY - GANGNAM STYLE", 3, YoutubeItemType.Video);
            Assert.IsTrue(response.Success);

            var repository = DatabaseContext.Set<YoutubeItem>();
            var history = await repository.ToListAsync();

            var duplicated = history
                .GroupBy(o => o.YoutubeId)
                .Where(o => o.Count() > 1)
                .ToList();

            Assert.IsTrue(duplicated.Count == 0);
        }
    }
}
