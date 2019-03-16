 namespace ContentManager.Models {
  export type ContentSection = {
    section: string
    html: string
    customElements: string[]
  }
  export type Thumbnail = {
    id: string
    file?: string
    type: string
  }
  export type Author = {
    id: string
    name: string
    email?: string
    website?: string
    twitter?: string
    github?: string
  }
  export enum Status {
    published,
    unpublished,
    draft
  }
  export interface ITease {
    headline: string
    id: string
    type: string
    media?: Thumbnail
    tags: string[]
    dateCreated: string
    dateUpdated?: string
    datePublished?: string
    author: string[]
    status: Status
  }
  export interface BlogPost extends ITease {
    headline: string
    id: string
    type: string
    media?: Thumbnail
    tags: string[]
    dateCreated: string
    dateUpdated?: string
    datePublished?: string
    author: string[]
    content: ContentSection[]
    status: Status
  }
  export interface FeedPost extends ITease {
    headline: string
    id: string
    type: string
    media?: Thumbnail
    tags: string[]
    dateCreated: string
    dateUpdated?: string
    datePublished?: string
    author: string[]
    feedid: string
    content: ContentSection[]
    status: Status
  }
  export interface ProjectPost extends ITease {
    headline: string
    id: string
    type: string
    media?: Thumbnail
    tags: string[]
    dateCreated: string
    dateUpdated?: string
    datePublished?: string
    author: string[]
    projectid: string
    content: ContentSection[]
    status: Status
  }
  export interface StudyPost extends ITease {
    headline: string
    id: string
    type: string
    media?: Thumbnail
    tags: string[]
    dateCreated: string
    dateUpdated?: string
    datePublished?: string
    author: string[]
    studyid: string
    content: ContentSection[]
    status: Status
  }
  export interface Feed extends ITease {
    headline: string
    id: string
    type: string
    media?: Thumbnail
    tags: string[]
    dateCreated: string
    dateUpdated?: string
    datePublished?: string
    author: string[]
    sourceUrl?: string
    status: Status
  }
  export interface Project extends ITease {
    headline: string
    id: string
    type: string
    media?: Thumbnail
    tags: string[]
    dateCreated: string
    dateUpdated?: string
    datePublished?: string
    author: string[]
    status: Status
  }
  export interface Study extends ITease {
    headline: string
    id: string
    type: string
    media?: Thumbnail
    tags: string[]
    dateCreated: string
    dateUpdated?: string
    datePublished?: string
    author: string[]
    status: Status
  }
}
