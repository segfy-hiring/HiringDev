import { YoutubeSearchViewModel } from './Types';

interface ISubscriptionService {
  search(query: string): Promise<YoutubeSearchViewModel[]>;
}

export default ISubscriptionService;
