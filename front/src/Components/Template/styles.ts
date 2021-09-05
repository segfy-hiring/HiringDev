import { createStyles, makeStyles } from '@material-ui/core/styles';

const useStyles = makeStyles(() => createStyles({
  appBar: {
    background: '#fff',
    color: '#333',
    boxShadow: '0 2px 8px rgb(0,0,0,0.1)',
  },
}));

export default useStyles;
