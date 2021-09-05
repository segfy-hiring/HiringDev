import { SubscriptionRequest } from './Types';

interface ISubscriptionService {
  create(request: SubscriptionRequest): Promise<void>;
  delete(id: string): Promise<void>;
}

export default ISubscriptionService;
