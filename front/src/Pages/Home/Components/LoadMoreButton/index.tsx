import { Box, Button } from '@material-ui/core';

type LoadMorebuttonProps = {
  onLoad(): void;
};

const LoadMoreButton = ({ onLoad }: LoadMorebuttonProps) => {
  return (
    <Box
      display="flex"
      alignItems="center"
      justifyContent="center"
      padding={5}
    >
      <Button
        disableElevation
        variant="contained"
        color="primary"
        size="large"
        onClick={onLoad}
      >
        Carregar mais
      </Button>
    </Box>
  );
};

export default LoadMoreButton;
