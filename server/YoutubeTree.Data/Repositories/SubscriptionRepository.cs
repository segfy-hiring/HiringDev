using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Google.Apis.YouTube.v3;
using Microsoft.EntityFrameworkCore;
using YoutubeTree.Domain;

namespace YoutubeTree.Data
{
    public class SubscriptionRepository : ISubscriptionRepository
    {
        const int MAX_RESULTS = 10;
        readonly YouTubeService _youtubeService;
        readonly DataContext _dbContext;

        public SubscriptionRepository(
            YouTubeService youtubeService,
            DataContext dbContext
        )
        {
            _youtubeService = youtubeService;
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<Subscription>> GetAll()
        {
            var subscriptions = await _dbContext.Subscriptions.AsNoTracking()
                .ToListAsync();
            
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

        // Precisa ir para um Service específico e desacoplar do Subscription
        public async Task<IEnumerable<Subscription>> Search(string query)
        {
            var subscriptions = new List<Subscription>(MAX_RESULTS);            
            var request = _youtubeService.Search.List("snippet");

            request.Q = query;
            request.MaxResults = MAX_RESULTS;
            request.Order = SearchResource.ListRequest.OrderEnum.Relevance;

            var response = await request.ExecuteAsync();

            foreach (var result in response.Items)
            {
                subscriptions.Add(
                    new Subscription(
                        YoutubeHelper.GetId(result.Id),
                        YoutubeHelper.GetRsourceType(result.Id),
                        result.Snippet.Title,
                        result.Snippet.Description,
                        result.Snippet.PublishedAt,
                        result.Snippet.Thumbnails.Default__.Url,
                        result.Snippet.Thumbnails.Medium.Url,
                        result.Snippet.Thumbnails.High.Url
                    )
                );
            }

            return subscriptions;
        }
    }
}