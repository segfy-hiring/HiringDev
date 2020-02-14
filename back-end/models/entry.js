const mongoose = require('mongoose')

const entrySchema = new mongoose.Schema({
    _id: { type: String, alias: 'id' },
    link: String,
    kind: String,
    publishedAt: Date,
    channelId: String,
    channelTitle: String,
    title: String,
    description: String,
    thumbnails: {
        default: {
            url: String
        },
        medium: {
            url: String
        },
        high: {
            url: String
        }
    }
}, { _id: false })

global.entrySchema = global.entrySchema || mongoose.model('Entry', entrySchema)
module.exports = global.entrySchema