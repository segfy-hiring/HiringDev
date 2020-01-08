import { google } from "googleapis";
var youtube = google.youtube("v3");
import config from "../../config/config";

class YoutubeController {
  async index(req, res) {
    youtube.search.list(
      {
        auth: config.API_KEY,
        part: "id,snippet",
        q: req.params.search
      },
      function(err, data) {
        if (err) {
          res.send(err);
        }
        if (data) {
          res.send(data);
        }
      }
    );
  }
}

export default new YoutubeController();
