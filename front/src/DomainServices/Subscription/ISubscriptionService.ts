import { SubscriptionRequest } from './Types';

interface ISubscriptionService {
  create(request: SubscriptionRequest): Promise<void>;
}

export default ISubscriptionService;
