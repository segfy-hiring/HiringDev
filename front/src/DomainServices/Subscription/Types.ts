export type SubscriptionViewModel = {
  id: string;
  youtubeId: string;
  type: string;
  title: string;
  description: string;
  publishedAt: Date;
  defaultThumbnail: string;
  mediumThumbnail: string;
  highThumbnail: string;
};

export type SubscriptionRequest = {
  youtubeId: string;
  type: string;
  title: string;
  description: string;
  publishedAt: Date;
  defaultThumbnail: string;
  mediumThumbnail: string;
  highThumbnail: string;
};