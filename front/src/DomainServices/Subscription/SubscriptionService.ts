import HttpClientService from 'Infra/HttpClientService';
import ISubscriptionService from './ISubscriptionService';
import { SubscriptionRequest } from './Types';

class SubscriptionService implements ISubscriptionService {
  private http;

  constructor() {
    this.http = HttpClientService;
  }

  async create(request: SubscriptionRequest): Promise<void> {
    try {
      await this.http.client.post('/api/v1/subscriptions', request);
    } catch (error) {
      throw error;
    }
  }
}

export default SubscriptionService;
