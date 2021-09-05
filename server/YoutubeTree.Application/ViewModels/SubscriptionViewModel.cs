using System;
using System.Collections.Generic;
using YoutubeTree.Domain;

namespace YoutubeTree.Application
{
    public class SubscriptionViewModel
    {
        public Guid Id { get; set; }
        public string YoutubeId { get; set; }
        public string Type { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime? PublishedAt { get; set; }
        public string DefaultThumbnail { get; set; }
        public string MediumThumbnail { get; set; }
        public string HighThumbnail { get; set; }
        public bool IsSubscribed { get; set; }

        public static IEnumerable<SubscriptionViewModel> ToMapMany(IEnumerable<Subscription> subscriptions)
        {
            foreach (var subscription in subscriptions)
            {
                yield return new SubscriptionViewModel
                {
                    Id = subscription.Id,
                    YoutubeId = subscription.YoutubeId,
                    Type = subscription.Type,
                    Title = subscription.Title,
                    Description = subscription.Description,
                    PublishedAt = subscription.PublishedAt,
                    DefaultThumbnail = subscription.DefaultThumbnail,
                    MediumThumbnail = subscription.MediumThumbnail,
                    HighThumbnail = subscription.HighThumbnail,
                    IsSubscribed = true
                };
            }
        }

        public static SubscriptionViewModel ToMap(Subscription subscription)
        {
            return new SubscriptionViewModel
                {
                    Id = subscription.Id,
                    YoutubeId = subscription.YoutubeId,
                    Type = subscription.Type,
                    Title = subscription.Title,
                    Description = subscription.Description,
                    PublishedAt = subscription.PublishedAt,
                    DefaultThumbnail = subscription.DefaultThumbnail,
                    MediumThumbnail = subscription.MediumThumbnail,
                    HighThumbnail = subscription.HighThumbnail,
                    IsSubscribed = true
                };
        }
    }
}