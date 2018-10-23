import { Field } from './Field'

export enum ObjectType {
  interface,
  type
}

export class Object {
  public fields?: Field[]
  public name: string
  public description?: string
  public type: ObjectType

  constructor (name: string, type: ObjectType, fields?: Field[]) {
    this.name = name
    this.fields = fields
    this.type = type
  }
}
