import * as graphql from '../graphql'

export const Tease = new graphql.Object('Tease', graphql.ObjectType.interface, [
  new graphql.Field('id', 'ID!'),
  new graphql.Field('headline', 'String', 'Main title of Tease'),
  new graphql.Field('summary', 'String', 'Short summary made out of truncating full text'),
  new graphql.Field('thumbnail', 'Thumbnail', 'Thumbnail object'),
  new graphql.Field('tags', '[String]', 'Tease tags'),
  new graphql.Field('creationDate', 'String', 'UTC Date'),
  new graphql.Field('updateDate', 'String', 'UTC Date'),
  new graphql.Field('author', '[Author]', 'List of contributors to Tease'),
  new graphql.Field('status', 'String', 'Published | Pending'),
  new graphql.Field('slug', 'String', 'Path to route')
])

export const Thumbnail = new graphql.Object('Thumbnail', graphql.ObjectType.type, [
  new graphql.Field('id', 'ID!'),
  new graphql.Field('url', 'String'),
  new graphql.Field('caption', 'String'),
  new graphql.Field('credit', 'String'),
  new graphql.Field('type', 'String')
])

export const Author = new graphql.Object('Author', graphql.ObjectType.type, [
  new graphql.Field('id', 'ID!'),
  new graphql.Field('firstName', 'String'),
  new graphql.Field('lastName', 'String'),
  new graphql.Field('website', 'String'),
  new graphql.Field('website', 'String')
])

export const commonPostFields = [
  new graphql.Field('content', 'ContentConnection', 'Path to route', [
    new graphql.Arg('first', 'Int', 1),
    new graphql.Arg('nextToken', 'String')
  ])
]

export const BlogPost = new graphql.Object('BlogPost',
  graphql.ObjectType.type,
  commonPostFields)

export const FeedPost = new graphql.Object('FeedPost',
  graphql.ObjectType.type,
  commonPostFields)

export const StudyPost = new graphql.Object('StudyPost',
  graphql.ObjectType.type,
  commonPostFields)

export const ProjectPost = new graphql.Object('ProjectPost',
  graphql.ObjectType.type,
  commonPostFields)

export const Feed = new graphql.Object('Feed',
  graphql.ObjectType.type,
  [
    new graphql.Field('sourceUrl', 'ID!')
  ])

export const Project = new graphql.Object('Project', graphql.ObjectType.type)
export const Study = new graphql.Object('Study', graphql.ObjectType.type)
export const Page = new graphql.Object('Page', graphql.ObjectType.type, commonPostFields)
