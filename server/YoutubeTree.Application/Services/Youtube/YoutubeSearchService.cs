using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using YoutubeTree.Domain;
using YoutubeTree.Infra.YoutubeService;

namespace YoutubeTree.Application
{
    public class YoutubeSearchService : IYoutubeSearchService
    {
        private readonly IYoutubeService _youtubeService;
        private readonly ISubscriptionRepository _subscriptionRepository;

        public YoutubeSearchService(
             IYoutubeService youtubeService,
             ISubscriptionRepository subscriptionRepository
        )
        {
            _youtubeService = youtubeService;
            _subscriptionRepository = subscriptionRepository; 
        }

        public async Task<PagedSearchResponse<SubscriptionViewModel>> Search(string term, string nextPageToken = "")
        {
            if (string.IsNullOrEmpty(term))
            {
                return new PagedSearchResponse<SubscriptionViewModel>();
            }

            var listResult = new List<SubscriptionViewModel>();     
            var pagedResponse = new PagedSearchResponse<SubscriptionViewModel>();       
            var subscriptions = await _subscriptionRepository.GetByTerm(term);            

            listResult.AddRange(SubscriptionViewModel.ToMapMany(subscriptions));

            var youtubeResponse = await _youtubeService.Search(new YoutubeRequest
            {
                Term = term,
                NextPageToken = nextPageToken
            });

            if (youtubeResponse.Any())
            {
                pagedResponse.NextPageToken = youtubeResponse.FirstOrDefault().NextPageToken;

                foreach (var youtubeItem in youtubeResponse)
                {
                    listResult.Add(new SubscriptionViewModel
                    {
                        Id = Guid.NewGuid(),
                        YoutubeId = youtubeItem.Id,
                        Title = youtubeItem.Title,
                        Description = youtubeItem.Description,
                        Type = youtubeItem.Type,
                        PublishedAt = youtubeItem.PublishedAt,
                        DefaultThumbnail = youtubeItem.DefaultThumbnail,
                        MediumThumbnail = youtubeItem.MediumThumbnail,
                        HighThumbnail = youtubeItem.HighThumbnail,
                        IsSubscribed = false,
                    });
                }
            }

            pagedResponse.Data = listResult.Distinct(new SubscriptionViewModelComparer());

            return pagedResponse;
        }
    }
}