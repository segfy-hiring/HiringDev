import YoutubeSearchService from 'DomainServices/YoutubeSearch';
import { useRef, useState } from 'react';
import { QueryFunctionContext, QueryKey, useQuery } from 'react-query';

type Search = {
  term: string;
  nextPage: string;
};

const useSearch = () => {
  const searchFilter = useRef<Search>({
    term: '',
    nextPage: '',
  });

  const {
    refetch,
    isFetching,
    error,
    data,
  } = useQuery('search_youtube',
    () => {
      const { term, nextPage } = searchFilter.current;
      return YoutubeSearchService.search(term, nextPage);
    },
    {
      enabled: false,
    });

  const handleFilter = (filter: Search) => {
    searchFilter.current = filter;
  };

  return {
    isLoading: isFetching,
    error,
    data,
    filter: searchFilter.current,
    handleFilter,
    onSearch: refetch,
  };
};

export default useSearch;
