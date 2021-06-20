using System;
using SegFyChallenge.Application.Interfaces.Persistence;
using SegFyChallenge.Persistence.Repositories;
using SegFyChallenge.Tests.Helpers;
using Xunit;

namespace SegFyChallenge.Tests.Persistence
{
    public class VideoRepositoryTest
    {
        private IVideoRepository _repository;

        [Fact]
        public async void Save_NewVideo_Test()
        {
            using (var context = ContextFactory.CreateApplicationContext())
            {
                _repository = new VideoRepository(context);

                var video = EntitiesFactory.CreateVideo();
                int createdId = await _repository.Save(video);
                Assert.True(createdId > 0);

                var newVid = await _repository.Get(createdId);
                Assert.NotNull(newVid);
                Assert.Equal(newVid.Id, createdId);
            }
        }

        [Fact]
        public async void Save_GetAll_Test()
        {
            using (var context = ContextFactory.CreateApplicationContext())
            {
                _repository = new VideoRepository(context);

                for (int i = 0; i < 10; i++)
                {
                    var video = EntitiesFactory.CreateVideo();
                    int createdId = await _repository.Save(video);
                    Assert.True(createdId > 0);
                }

                var items = await _repository.GetAll();
                Assert.NotNull(items);
                Assert.True(items.Count == 10);
            }
        }
    }
}