import { GqlObject } from './GqlObject'

export interface SchemaType {
  createMutation: boolean
  createQuery: boolean
  gql: GqlObject
}
