const mockedEnv = require('mocked-env')
const connectToDatabase = require('../db')

describe('DB Tests', () => {
    test('DB Connection failed', () => {
        return expect(connectToDatabase()).rejects.toEqual(false)
    })

    test('DB Connection stablished', () => {
        let restore = mockedEnv({
            YTKEY: 'AIzaSyBhzXohZHWtPuZFsiFNogNi6L6VfpRG4aw',
            DB: 'mongodb+srv://dbUser:reallystrongpassword@cluster0-tpiyu.mongodb.net/test?retryWrites=true&w=majority'
        })
        expect(connectToDatabase()).resolves.toEqual(true)
        restore()
    })
})