import HttpClientService from 'Infra/HttpClientService';
import IYoutubeSearchService from './IYoutubeSearchService';
import { YoutubeSearchViewModel } from './Types';

class SubscriptionService implements IYoutubeSearchService {
  private http;

  constructor() {
    this.http = HttpClientService;
  }

  async search(query: string): Promise<YoutubeSearchViewModel[]> {
    try {
      const result = await this.http.client.get(`/api/v1/search?query=${query}`);

      return result.data as YoutubeSearchViewModel[];
    } catch (error) {
      throw error;
    }
  }
}

export default SubscriptionService;
