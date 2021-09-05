import HttpClientService from 'Infra/HttpClientService';
import IYoutubeSearchService from './IYoutubeSearchService';
import { PagedSearchViewModel } from './Types';

class SubscriptionService implements IYoutubeSearchService {
  private http;

  constructor() {
    this.http = HttpClientService;
  }

  async search(query: string, nextPage = ''): Promise<PagedSearchViewModel> {
    try {
      const result = await this.http.client.get(`/api/v1/search?query=${query}&nextPage=${nextPage}`);

      return result.data as PagedSearchViewModel;
    } catch (error) {
      throw error;
    }
  }
}

export default SubscriptionService;
