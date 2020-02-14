const mockedEnv = require('mocked-env')
const handler = require('../handler')

describe('Service Tests', () => {
    let restore

    beforeEach(()=>{
        restore = mockedEnv({
            YTKEY: 'AIzaSyBhzXohZHWtPuZFsiFNogNi6L6VfpRG4aw',
            DB: 'mongodb+srv://dbUser:reallystrongpassword@cluster0-tpiyu.mongodb.net/test?retryWrites=true&w=majority'
        })
    })

    test('Search empty string', async () => {
        const data = await handler.search({}, {})
        expect(data).toHaveProperty('statusCode', 500)
    })

    test("Search 'Neural Networks' string", async () => {
        const data = await handler.search({
            queryStringParameters: {
                q: 'Neural Networks'
            }
        }, {})

        expect(data).toHaveProperty('statusCode', 200)
    })

    afterEach(()=>restore())
})