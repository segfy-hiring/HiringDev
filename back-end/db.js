const mongoose = require('mongoose')
mongoose.Promise = global.Promise
let isConnected

module.exports = connectToDatabase = () => {
  if (isConnected) {
    return Promise.resolve(true)
  }
  try {
    return mongoose.connect(process.env.DB)
      .then(db => {
        isConnected = db.connections[0].readyState
        return Promise.resolve(true)
      })
      .catch(err => {
        return Promise.reject(false)
      })
  } catch (err) {
    return Promise.reject(false)
  }
}