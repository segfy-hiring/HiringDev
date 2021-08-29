import {
  AppBar,
  Box,
  Toolbar,
} from '@material-ui/core';
import { Outlet } from 'react-router-dom';

const Template = () => {
  return (
    <Box>
      <AppBar position="fixed" elevation={0}>
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
