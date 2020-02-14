'use strict';

const connectToDatabase = require('./db')
const ytsearch = require('./youtube')
const Entry = require('./models/entry')

module.exports.search = async (event, context) => {
  context.callbackWaitsForEmptyEventLoop = false;
  return connectToDatabase().then(() => {
    return event.queryStringParameters && event.queryStringParameters.q  ? ytsearch(event.queryStringParameters.q).then(
      (result, err) => {
        if (err) {
          return Promise.reject(err)
        } else {
          return Entry.find({ '_id': { $in: result.map(value => value.id) } }).then(values => {
            let ids = values.map(value => value.id)
            let entries = result.filter(item => !ids.includes(item.id))
            return Entry.create(entries).then(() => Promise.resolve(result))
          })
        }
      }).catch(err => Promise.reject(err)): Promise.reject("Query is missing")
  }).then(result => {
    return {
      statusCode: 200,
      headers: {
        'Access-Control-Allow-Origin': '*',
        'Access-Control-Allow-Credentials': true,
      },
      body: JSON.stringify(result)
    }
  }).catch(err => {
    return {
      statusCode: err.statusCode || 500,
      headers: {
        'Access-Control-Allow-Origin': '*',
        'Access-Control-Allow-Credentials': true,
        'Content-Type': 'text/plain' 
      },
      body: 'Could not fetch from YouTube.'
    }
  })
}
