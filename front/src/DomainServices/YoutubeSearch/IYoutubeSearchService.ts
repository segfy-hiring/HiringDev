import { PagedSearchViewModel } from './Types';

interface ISubscriptionService {
  search(query: string, nextPage: string): Promise<PagedSearchViewModel>;
}

export default ISubscriptionService;
