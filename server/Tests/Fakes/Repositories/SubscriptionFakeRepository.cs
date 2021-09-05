using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using YoutubeTree.Domain;

namespace YoutubeTree.Tests
{
    public class SubscriptionFakeRepository : ISubscriptionRepository
    {
        private static List<Subscription> _fakeList;
        public SubscriptionFakeRepository()
        {
            _fakeList = new();
        }

        public Task Create(Subscription subscription)
        {
            _fakeList.Add(subscription);
            return Task.CompletedTask;
        }

        public Task Delete(Guid id)
        {
            var subs = _fakeList.Where(s => s.Id == id).FirstOrDefault();
            _fakeList.Remove(subs);

            return Task.CompletedTask;
        }

        public Task<IEnumerable<Subscription>> GetAll()
        {
            return Task.FromResult(_fakeList.AsEnumerable());
        }

        public Task<Subscription> GetById(Guid id)
        {
            return Task.FromResult(_fakeList.Where(s => s.Id == id).FirstOrDefault());
        }

        public Task<IEnumerable<Subscription>> GetByTerm(string term)
        {
            var sub = _fakeList.Where(s => s.Title.ToLower().Contains(term));

            return Task.FromResult(sub);
        }
    }
}