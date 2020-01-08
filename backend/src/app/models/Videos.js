import Sequelize, { Model } from "sequelize";

class Videos extends Model {
  static init(sequelize) {
    super.init(
      {
        tipo: Sequelize.STRING,
        videoid: Sequelize.STRING,
        canal: Sequelize.STRING,
        titulo: Sequelize.STRING,
        descricao: Sequelize.STRING,
        thumbnail: Sequelize.STRING
      },
      {
        sequelize
      }
    );
  }
}

export default Videos;
