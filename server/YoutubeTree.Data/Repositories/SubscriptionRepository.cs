using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using YoutubeTree.Domain;

namespace YoutubeTree.Data
{
    public class SubscriptionRepository : ISubscriptionRepository
    {
        private readonly DataContext _dbContext;

        public SubscriptionRepository(DataContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<Subscription>> GetAll()
        {
            var subscriptions = await _dbContext.Subscriptions.AsNoTracking()
                .ToListAsync();
            
            return subscriptions;
        }

        public async Task<IEnumerable<Subscription>> GetByTerm(string term)
        {
            var subscriptions = await _dbContext.Subscriptions.AsNoTracking().Where(s => s.Title.ToLower().Contains(term)).ToListAsync();

            return subscriptions;
        }

        public async Task<Subscription> GetById(Guid id)
        {
            var subscription = await _dbContext.Subscriptions.FirstOrDefaultAsync(
                s => s.Id == id
            );

            return subscription;
        }

        public async Task Create(Subscription subscription)
        {
            await _dbContext.Subscriptions.AddAsync(subscription);
            await _dbContext.SaveChangesAsync();
        }

        public async Task Delete(Guid id)
        {
            var subscription = await _dbContext.Subscriptions.AsNoTracking().FirstOrDefaultAsync(
                s => s.Id == id
            );

            if (subscription == null)
            {
                // TODO: Deve ser tratado sem exceção
                throw new Exception("Inscrição inválida");
            }

            _dbContext.Subscriptions.Remove(subscription);
            await _dbContext.SaveChangesAsync();
        }
    }
}