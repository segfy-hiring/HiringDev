import {
  Theme,
  createTheme,
} from '@material-ui/core/styles';

const DEFAULT_FONT_FAMILY = '"Poppins", sans-serif';

const defaultTheme: Theme = createTheme({
  palette: {
    type: 'light',
    primary: {
      main: '#ed6326',
    },
  },
  overrides: {
    MuiCssBaseline: {
      '@global': {
        html: {
          fontFamily: DEFAULT_FONT_FAMILY,
        },
        body: {
          height: '100%',
          fontFamily: DEFAULT_FONT_FAMILY,
          'overscroll-behavior-y': 'none',
        },
        '#root': {
          height: '100%',
        },
        a: {
          color: 'inherit',
          textDecoration: 'none',
        },
      },
    },
  },
});

export default defaultTheme;
