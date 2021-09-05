using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace YoutubeTree.Application
{
    public class SubscriptionViewModelComparer : IEqualityComparer<SubscriptionViewModel>
    {
        public bool Equals(SubscriptionViewModel x, SubscriptionViewModel y)
        {
            return x.YoutubeId.Equals(y.YoutubeId);
        }

        public int GetHashCode([DisallowNull] SubscriptionViewModel obj)
        {
            return obj.YoutubeId.GetHashCode();
        }
    }
}