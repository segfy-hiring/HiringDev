using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace YoutubeTree.Domain
{
    public interface ISubscriptionRepository
    {
        Task<IEnumerable<Subscription>> GetAll();
        Task<IEnumerable<Subscription>> GetByTerm(string term);
        Task<Subscription> GetById(Guid id);
        Task Create(Subscription subscription);
        Task Delete(Guid id);
    }
}