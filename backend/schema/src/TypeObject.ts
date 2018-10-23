import { GqlObject } from './GqlObject'
import { InterfaceObject } from './InterfaceObject'
import { Field } from './GqlField'

export class TypeObject extends GqlObject {
  private interfaceO?: InterfaceObject
  private paginationO?: GqlObject

  constructor (name, fields: Field[], interfaceO?: InterfaceObject, paginationO?: GqlObject) {
    super(name, fields)
    this.interfaceO = interfaceO
    this.paginationO = paginationO
  }

  getQueries () {
    let paginationReturnType = this.paginationO !== undefined ? this.paginationO.name : `${this.name}Connection`
    const listQ = `get${name}List(first: Int = 20, nextToken: String): [${paginationReturnType}]`
    const getByIdQ = `get${name}(id: ID!): ${name}`
  }

  getMutations () {
    const getSubscriptions = (createM, updateM, deleteM) => {
      const createdM = `onCreate${name}(input: ${inputName}!): ${name}`
      const updatedM = `onUpdate${name}(input: ${inputName}!): ${name}`
      const deletedM = `onDelete${name}(input: ${inputName}!): ${name}`
    }
    const inputName = `${name}Input`
    const createM = `create${name}(input: create${inputName}!): ${name}`
    const updateM = `update${name}(input: update${inputName}!): ${name}`
    const deleteM = `delete${name}(input: delete${inputName}!): ${name}`
  }

  toString () {
    return `type ${this.name} ${this.interfaceO !== undefined ? `implements ${this.interfaceO.name} ` : ''}{
    ${this.fields.join('\n  ')}
}`
  }
}

export const makeType = (name, fields: Field[], interfaceO?: InterfaceObject, paginationObject?: GqlObject) =>
new TypeObject(name, fields, interfaceO, paginationObject)
