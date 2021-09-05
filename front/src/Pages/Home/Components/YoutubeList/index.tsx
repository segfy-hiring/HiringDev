import React from 'react';
import { Grid } from '@material-ui/core';
import { YoutubeSearchViewModel } from 'DomainServices/YoutubeSearch/Types';
import YoutubeCard from '../YoutubeCard';
import useSubscribe from 'Pages/Home/Context/useSubscribe';
import useUnsubscribe from 'Pages/Home/Context/useUnsubscribe';

type YoutubeListProps = {
  model: YoutubeSearchViewModel[];
};

const YoutubeList = React.memo(({ model }: YoutubeListProps) => {
  const { onSubscribe } = useSubscribe();
  const { onUnsubscribe } = useUnsubscribe();

  return (
    <Grid container spacing={3}>
      { model && model.map(
        (item) => (
          <Grid item xs={12} sm={4} md={4} lg={3} xl={2}>
            <YoutubeCard
              key={item.id}
              title={item.title}
              thumbnail={item.mediumThumbnail}
              publishedAt={item.publishedAt}
              isSubscribed={item.isSubscribed}
              description={item.description}
              type={item.type}
              onSubscribe={() => {
                onSubscribe({
                  youtubeId: item.youtubeId,
                  type: item.type,
                  title: item.title,
                  description: item.description,
                  publishedAt: item.publishedAt,
                  defaultThumbnail: item.defaultThumbnail,
                  mediumThumbnail: item.mediumThumbnail,
                  highThumbnail: item.highThumbnail,
                });
              }}
              onUnsubscribe={() => onUnsubscribe(item.id)}
            />
          </Grid>
        ),
      )}
    </Grid>
  );
});

export default YoutubeList;
