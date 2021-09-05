import { createStyles, makeStyles } from '@material-ui/core/styles';

const useStyles = makeStyles((theme) => createStyles({
  root: {
    background: '#fff',
    color: '#333',
    padding: theme.spacing(8),
    display: 'flex',
    alignItems: 'center',
    justifyContent: 'center',

    [theme.breakpoints.only('xs')]: {
      padding: theme.spacing(2),
    },
  },
  button: {
    padding: theme.spacing(2, 4),
    marginLeft: theme.spacing(2),
  },
  input: {
    width: '345px',
  },
}));

export default useStyles;
