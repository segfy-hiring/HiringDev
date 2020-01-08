import Sequelize from "sequelize";

import Videos from "../app/models/Videos";

import databaseconfig from "../config/database";

const models = [Videos];

class Database {
  constructor() {
    this.init();
  }
  init() {
    this.connection = new Sequelize(databaseconfig);
    models.map(model => model.init(this.connection));
  }
}

export default new Database();
