import { SchemaType } from './types'
import { blogSchemaObjects } from './model/blogSchema'

const capitalizeFirstLetter = (str: string) => str.charAt(0).toUpperCase() + str.slice(1)

function queriesAndMutations (blogObjects: SchemaType[]) {
  return blogObjects.reduce((ctr, schemaObj: SchemaType) => {
    const name = capitalizeFirstLetter(schemaObj.gql.name)
    if (schemaObj.createMutation === true) {
      const inputName = `${name}Input`
      ctr.mutations.push(`create${name}(input: ${inputName}!): ${name}`)
      ctr.mutations.push(`update${name}(input: ${inputName}!): ${name}`)
      ctr.mutations.push(`delete${name}(input: ${inputName}!): ${name}`)
    }
    if (schemaObj.createQuery === true) {
      ctr.queries.push(`get${name}(id: ID!): ${name}`)
      ctr.queries.push(`get${name}List(first: Int = 20, nextToken: String): [${name}Connection]`)
    }
    ctr.types.push(schemaObj.gql.name)
    ctr.typeList.push(schemaObj.gql.toString())
    return ctr
  }, {
    mutations: ([] as any[]),
    queries: ([] as any[]),
    typeList: ([] as any[]),
    types: ([] as any[]),
    interfaces: ([] as any[]),
    enums: ([] as any[])
  })
}

export function schema () {
  const blogObjects = blogSchemaObjects()
  const allParts = queriesAndMutations(blogObjects)
  console.log(allParts)
  return ''
}

export function buildSchema () {
  console.log(schema)
}
