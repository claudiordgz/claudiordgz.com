import * as graphql from './graphql'
import * as appsync from './appsync'
import * as camelCase from 'lodash.camelcase'

function* getFields (node: graphql.ObjNode, depth: number = 0): IterableIterator<graphql.Field> {
  if (node instanceof graphql.RootNode) {
    return
  }
  if (node.value.type === graphql.ObjectType.interface) {
    if (node.value.fields !== undefined) {
      for (const f of node.value.fields) {
        yield(f)
      }
    }
  }
  if (node.value.type === graphql.ObjectType.type) {
    const parentName = parent.value.name
    yield(new graphql.Field(`${parentName}Id`, 'String'))
  }
  if (node.value.fields !== undefined) {
    for (const f of node.value.fields) {
      yield(f)
    }
  }
}

function modelToMutationsAndSubscriptions (model: graphql.Tree) {
  const mutations: graphql.Field[] = []
  const subscriptions: appsync.Subscription[] = []
  const nodeProcessing = (node: graphql.ObjNode) => {
    if (node.value.type === graphql.ObjectType.type) {
      const fields = Array.from(getFields(node))
      const create = 'create'
      const update = 'update'
      const del = 'delete'
      for (const mut of [create, update, del]) {
        const mutationName = camelCase(`${mut} ${node.value.name}`)
        const inputName = `${mutationName}Input`
        const subscriptionName = camelCase(`on ${node.value.name} ${mut}`)
        const obj = new graphql.Object(inputName, graphql.ObjectType.type, fields)
        model.addObject(new graphql.ObjNode(obj))
        const mutation = new graphql.Field(mutationName,
          node.value.name,
          `${mut} type ${node.value.name}`,
          [ new graphql.Arg('obj', inputName) ])
        mutations.push(mutation)
        const subs = new graphql.Field(subscriptionName, node.value.name)
        const subscription = new appsync.Subscription(subs, mutationName)
        subscriptions.push(subscription)
      }
    }
  }
  return {
    mutations,
    subscriptions,
    nodeProcessing
  }
}
