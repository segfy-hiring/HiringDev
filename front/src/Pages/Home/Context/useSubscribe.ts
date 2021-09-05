import { useMutation } from 'react-query';
import SubscriptionService from 'DomainServices/Subscription';
import { SubscriptionRequest } from 'DomainServices/Subscription/Types';

const useSubscribe = () => {
  const { mutate } = useMutation((subscribe: SubscriptionRequest) => {
    return SubscriptionService.create(subscribe);
  });

  return {
    onSubscribe: mutate,
  };
};

export default useSubscribe;
