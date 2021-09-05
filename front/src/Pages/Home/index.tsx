import {
  Box,
  CircularProgress,
  Backdrop,
} from '@material-ui/core';
import { unionBy } from 'lodash';
import { YoutubeSearchViewModel } from 'DomainServices/YoutubeSearch/Types';
import { useEffect, useState } from 'react';
import LoadMoreButton from './Components/LoadMoreButton';

import SearchHeader from './Components/SearchHeader';
import YoutubeList from './Components/YoutubeList';
import useSearch from './Context/useSearch';

import useStyles from './styles';

function removeDuplicates(current: YoutubeSearchViewModel[], coming: YoutubeSearchViewModel[]) {
  return unionBy(current, coming, 'youtubeId');
}

const Home = () => {
  const styles = useStyles();
  const [subscriptions, setSubscriptions] = useState<YoutubeSearchViewModel[]>([]);
  const {
    isLoading,
    data,
    onSearch,
    filter,
    handleFilter,
  } = useSearch();

  useEffect(() => {
    setSubscriptions((prev) => removeDuplicates(prev, data?.data || []));
  }, [data]);

  return (
    <Box>
      <SearchHeader onSearch={(term) => {
        setSubscriptions([]);
        handleFilter({
          term,
          nextPage: data?.nextPageToken || '',
        });
        onSearch();
      }}
      />
      <Box padding={[3, 6]}>
        { isLoading && (
          <Backdrop className={styles.backdrop} open>
            <CircularProgress color="inherit" />
          </Backdrop>
        )}
        <YoutubeList model={subscriptions} />
        { data?.nextPageToken ?
          (
            <LoadMoreButton onLoad={() => {
              handleFilter(({ ...filter, nextPage: data?.nextPageToken || '' }));
              onSearch();
            }}
            />
          ) : null}
      </Box>
    </Box>
  );
};

export default Home;
