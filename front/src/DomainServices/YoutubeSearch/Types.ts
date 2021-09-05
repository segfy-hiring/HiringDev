export type YoutubeSearchViewModel = {
  id: string;
  youtubeId: string;
  type: string;
  title: string;
  description: string;
  publishedAt: string;
  defaultThumbnail: string;
  mediumThumbnail: string;
  highThumbnail: string;
  isSubscribed: boolean;
};

export type PagedSearchViewModel = {
  data: YoutubeSearchViewModel[],
  nextPageToken: string,
};
