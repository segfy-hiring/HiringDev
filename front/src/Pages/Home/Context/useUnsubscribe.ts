import { useMutation } from 'react-query';
import SubscriptionService from 'DomainServices/Subscription';

const useSubscribe = () => {
  const { mutate } = useMutation((id: string) => {
    return SubscriptionService.delete(id);
  });

  return {
    onUnsubscribe: mutate,
  };
};

export default useSubscribe;
