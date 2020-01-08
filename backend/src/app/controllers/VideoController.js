import Videos from "../models/Videos";

class VideoController {
  async store(req, res) {
    const videoexiste = await Videos.findOne({
      where: { videoid: req.body.videoid }
    });

    if (videoexiste) {
      return res.status(400).json({ error: "video já cadastrado" });
    }

    const video = await Videos.create(req.body);

    return res.json(video);
  }

  async index(req, res) {
    const videos = await Videos.findAll({
      attributes: [
        "id",
        "tipo",
        "videoid",
        "canal",
        "titulo",
        "descricao",
        "thumbnail"
      ]
    });

    return res.json(videos);
  }

  async delete(req, res) {
    //const videos = await Videos.findByPk(req.params.id);

    const videos = await Videos.destroy({ where: { id: req.params.id } });

    //await videos.delete({ where: req.params.id });

    return res.status(200).json({ messagem: "video removido com sucesso" });
  }
}

export default new VideoController();
