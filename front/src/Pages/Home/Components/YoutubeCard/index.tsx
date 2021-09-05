import { useState } from 'react';
import {
  Box,
  Chip,
  Typography,
  Button,
  CardMedia,
  CardContent,
  CardActions,
  Card,
} from '@material-ui/core';

import useStyles from './styles';

type YoutubeCardProps = {
  title: string;
  thumbnail: string;
  publishedAt: string;
  isSubscribed: boolean;
  description: string;
  type: string;
  onSubscribe(): void;
  onUnsubscribe(): void;
};

const YoutubeCard = ({
  title,
  thumbnail,
  publishedAt,
  isSubscribed,
  description,
  type,
  onSubscribe,
  onUnsubscribe,
}: YoutubeCardProps) => {
  const [subscribed, setSubscribed] = useState<boolean>(isSubscribed);
  const styles = useStyles();

  const handleSubscribe = () => {
    setSubscribed(true);
    onSubscribe();
  };

  const handleUnsubscribe = () => {
    setSubscribed(false);
    onUnsubscribe();
  };

  return (
    <Card className={styles.root}>
      <CardMedia
        className={styles.media}
        image={thumbnail}
      />
      <CardContent className={styles.content}>
        <Typography gutterBottom variant="h6">
          {title}
        </Typography>
        <Box my={2}>
          <Chip label={type} color="primary" />
        </Box>
        <Typography gutterBottom variant="body2">
          {Intl.DateTimeFormat('pt-BR', { dateStyle: 'long' }).format(new Date(publishedAt))}
        </Typography>
        <Typography gutterBottom variant="body2" className={styles.description}>
          {description}
        </Typography>
      </CardContent>
      <CardActions className={styles.actions}>
        <Button size="small" color="primary" onClick={subscribed ? handleUnsubscribe : handleSubscribe}>
          { subscribed ? 'Cancelar Inscrição' : 'Inscrever' }
        </Button>
      </CardActions>
    </Card>
  );
};

export default YoutubeCard;
