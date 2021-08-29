import {
  ThemeProvider as MuiThemeProvider,
} from '@material-ui/styles';

import { ReactNode } from 'react';
import {
  CssBaseline,
} from '@material-ui/core';
import defaultTheme from './DefaultTheme';

type ThemeProviderProps = {
  children: ReactNode;
};

const ThemeProvider = ({ children }: ThemeProviderProps) => {
  return (
    <MuiThemeProvider theme={defaultTheme}>
      <CssBaseline />
      {children}
    </MuiThemeProvider>
  );
};

export default ThemeProvider;
