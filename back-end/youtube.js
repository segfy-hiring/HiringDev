var search = require('youtube-search')

module.exports = ytsearch = async (param) => {
    return new Promise((resolve, reject) => {
        var opts = {
            key: process.env.YTKEY
        }
        search(param, opts, (err, results) => {
            if (err) reject(err)
            else resolve(results)
        })
    }
    )
}