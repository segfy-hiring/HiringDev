import YoutubeCard from 'Components/YoutubeCard';
import YoutubeSearchService from 'DomainServices/YoutubeSearch';
import { YoutubeSearchViewModel } from 'DomainServices/YoutubeSearch/Types';
import { Grid } from '@material-ui/core';
import { useState } from 'react';
import { useEffect } from 'react';

const Home = () => {
  const [items, setItems] = useState<YoutubeSearchViewModel[]>([]);

  useEffect(() => {
    YoutubeSearchService.search('.net core')
      .then((response) => {
        setItems(response);
      }).catch((error) => {
        console.error(error);
      });
  });

  return (
    <Grid container spacing={3}>
      { items && items.map(
        (item) => (
          <Grid item xs={12}>
            <YoutubeCard
              title={item.title}
              thumbnail={item.mediumThumbnail}
              onSubscribe={() => alert('TODO: Executar Subscription/Create')}
            />
          </Grid>
        ),
      )}
    </Grid>
  );
};

export default Home;
