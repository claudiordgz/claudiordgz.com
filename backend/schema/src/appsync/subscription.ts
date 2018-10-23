import { Field } from '../graphql'

export class Subscription {
  public field: Field
  public mutationName: string

  constructor (f: Field, mutationName: string) {
    this.field = f
    this.mutationName = mutationName
  }

}
