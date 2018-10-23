import * as graphql from '../graphql'
import * as types from './mainTypes'

export function getBlogGraphqlModel () {
  const model = new graphql.Tree()
  model.addObject(new graphql.ObjNode(types.Tease))
  model.addObject(new graphql.ObjNode(types.Thumbnail))

  model.addObjectToParent('Tease', new graphql.ObjNode(types.Author))

  model.addObjectToParent('Tease', new graphql.ObjNode(types.Feed))
  model.addObjectToParent('Tease', new graphql.ObjNode(types.Project))
  model.addObjectToParent('Tease', new graphql.ObjNode(types.Study))
  model.addObjectToParent('Tease', new graphql.ObjNode(types.Page))
  model.addObjectToParent('Tease', new graphql.ObjNode(types.BlogPost))

  model.addObjectToParent('Tease', new graphql.ObjNode(types.FeedPost))
  model.addObjectToParent('Tease', new graphql.ObjNode(types.StudyPost))
  model.addObjectToParent('Tease', new graphql.ObjNode(types.ProjectPost))

  return model
}

export function getBlogTableModel () {
  const model = new graphql.Tree()
  model.addObject(new graphql.ObjNode(types.Author))
  model.addObject(new graphql.ObjNode(types.Feed))
  model.addObject(new graphql.ObjNode(types.Project))
  model.addObject(new graphql.ObjNode(types.Study))
  model.addObject(new graphql.ObjNode(types.Page))
  model.addObject(new graphql.ObjNode(types.BlogPost))
  model.addObjectToParent('Feed', new graphql.ObjNode(types.FeedPost))
  model.addObjectToParent('Study', new graphql.ObjNode(types.StudyPost))
  model.addObjectToParent('Project', new graphql.ObjNode(types.ProjectPost))
  return model
}
