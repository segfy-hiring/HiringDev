import { createStyles, makeStyles } from '@material-ui/core/styles';

const useStyles = makeStyles((theme) => createStyles({
  root: {
    display: 'flex',
    flexDirection: 'column',
    height: '100%',
    boxShadow: '0 2px 10px rgba(0,0,0, 0.1)',
  },
  media: {
    height: 0,
    paddingTop: '56.25%',
  },
  content: {
    flexGrow: 1,
  },
  actions: {
    marginLeft: 'auto',
  },
  description: {
    marginTop: theme.spacing(2),
    color: '#999',
  },
}));

export default useStyles;
