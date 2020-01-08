import { Router } from "express";

import VideoController from "./app/controllers/VideoController";
import YoutubeController from "./app/controllers/YoutubeController";

const routes = new Router();

routes.get("/", (req, res) => {
  return res.json({ Desenvolvedor: "Natalio Silveira Jr" });
});

routes.post("/savevideo", VideoController.store);

routes.get("/listarvideos", VideoController.index);

routes.get("/busca/:search", YoutubeController.index);

routes.delete("/remover/:id", VideoController.delete);

export default routes;
