import {
  AppBar,
  Box,
  Toolbar,
} from '@material-ui/core';
import { Outlet } from 'react-router-dom';
import useStyles from './styles';

const Template = () => {
  const styles = useStyles();

  return (
    <Box>
      <AppBar
        position="fixed"
        elevation={0}
        className={styles.appBar}
      >
        <Toolbar>Youtube Tree</Toolbar>
      </AppBar>
      <Toolbar />
      <Box>
        <Outlet />
      </Box>
    </Box>
  );
};

export default Template;
