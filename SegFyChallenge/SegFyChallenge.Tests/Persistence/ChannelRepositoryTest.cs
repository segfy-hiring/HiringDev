using SegFyChallenge.Application.Interfaces.Persistence;
using SegFyChallenge.Persistence.Repositories;
using SegFyChallenge.Tests.Helpers;
using Xunit;

namespace SegFyChallenge.Tests.Persistence
{
    public class ChannelRepositoryTest
    {
        private IChannelRepository _repository;

        [Fact]
        public async void Save_NewChannel_Test()
        {
            using (var context = ContextFactory.CreateApplicationContext())
            {
                _repository = new ChannelRepository(context);

                var channel = EntitiesFactory.CreateChannel();
                int createdId = await _repository.Save(channel);
                Assert.True(createdId > 0);

                var newChan = await _repository.Get(createdId);
                Assert.NotNull(newChan);
                Assert.Equal(newChan.Id, createdId);
            }
        }

        [Fact]
        public async void Save_GetAll_Test()
        {
            using (var context = ContextFactory.CreateApplicationContext())
            {
                _repository = new ChannelRepository(context);

                for (int i = 0; i < 10; i++)
                {
                    var channel = EntitiesFactory.CreateChannel();
                    int createdId = await _repository.Save(channel);
                    Assert.True(createdId > 0);
                }

                var items = await _repository.GetAll();
                Assert.NotNull(items);
                Assert.True(items.Count == 10);
            }
        }
    }
}