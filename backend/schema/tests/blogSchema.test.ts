import { schema } from '../src/model/blogSchema'

describe('blogSchema', () => {
  test('checkObjects', () => {
    console.log(schema())
    expect(true).toBe(true)
  })
})
