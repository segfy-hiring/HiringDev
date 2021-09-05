import { Box, Button, TextField } from '@material-ui/core';
import SearchIcon from '@material-ui/icons/Search';
import { useState } from 'react';

import useStyles from './styles';

type SearchHeaderProps = {
  onSearch(term: string): void;
};

const SearchHeader = ({
  onSearch,
}: SearchHeaderProps) => {
  const [term, setTerm] = useState('');
  const styles = useStyles();

  const handleInputChange = (event: React.ChangeEvent<HTMLInputElement>) => {
    setTerm(event.target.value);
  };

  const handleSearchTerm = () => {
    onSearch(term);
  };

  return (
    <Box className={styles.root}>
      <TextField
        value={term}
        className={styles.input}
        id="search"
        variant="outlined"
        placeholder="Procurar"
        onChange={handleInputChange}
      />
      <Button
        disableElevation
        className={styles.button}
        variant="contained"
        color="primary"
        startIcon={<SearchIcon />}
        size="large"
        onClick={handleSearchTerm}
      >
        Buscar
      </Button>
    </Box>
  );
};

export default SearchHeader;
