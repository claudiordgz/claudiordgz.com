 module ContentManager.Models
                                {
                                export interface SiteDefaults  
                {
                thumbnailDirectory?: string ;
authors?: Author[] ;
credits?: Author[] ;
thumbnails?: Thumbnail[] ; 
                }
export interface FrontMatter  
                {
                title?: string ;
slug?: string ;
/*[YamlMember(Alias = "date_created", ApplyNamingConventions = false)]*/
created?: Date ;
/*[YamlMember(Alias = "date_published", ApplyNamingConventions = false)]*/
published?: Date ;
/*[YamlMember(Alias = "date_updated", ApplyNamingConventions = false)]*/
updated?: Date ;
tags?: string[] ;
/*[YamlMember(Alias = "draft", ApplyNamingConventions = false)]*/
isDraft?: boolean ;
author?: string ;
thumbnail?: Thumbnail ; 
                }
export interface Thumbnail  
                {
                id?: string ;
file?: string ;
type?: string ; 
                }
export interface Author  
                {
                id?: string ;
name?: string ;
email?: string ;
website?: string ;
twitter?: string ;
github?: string ; 
                }
export enum Status {
                 published,

unpublished,

draft
                 }
export interface ITease  
                {
                headline?: string ;
summary?: string ;
id?: string ;
type?: string ;
media?: Thumbnail ;
tags?: string[] ;
dateCreated?: string ;
dateUpdated?: string ;
datePublished?: string ;
author?: string[] ;
status?: Status ; 
                }
export interface BlogPost  extends ITease
                {
                headline?: string ;
summary?: string ;
id?: string ;
type?: string ;
media?: Thumbnail ;
tags?: string[] ;
dateCreated?: string ;
dateUpdated?: string ;
datePublished?: string ;
author?: string[] ;
content?: string[] ;
status?: Status ; 
                }
export interface FeedPost  extends ITease
                {
                headline?: string ;
summary?: string ;
id?: string ;
type?: string ;
media?: Thumbnail ;
tags?: string[] ;
dateCreated?: string ;
dateUpdated?: string ;
datePublished?: string ;
author?: string[] ;
feedId?: string ;
content?: string[] ;
status?: Status ; 
                }
export interface ProjectPost  extends ITease
                {
                headline?: string ;
summary?: string ;
id?: string ;
type?: string ;
media?: Thumbnail ;
tags?: string[] ;
dateCreated?: string ;
dateUpdated?: string ;
datePublished?: string ;
author?: string[] ;
projectId?: string ;
content?: string[] ;
status?: Status ; 
                }
export interface StudyPost  extends ITease
                {
                headline?: string ;
summary?: string ;
id?: string ;
type?: string ;
media?: Thumbnail ;
tags?: string[] ;
dateCreated?: string ;
dateUpdated?: string ;
datePublished?: string ;
author?: string[] ;
studyId?: string ;
content?: string[] ;
status?: Status ; 
                }
export interface Feed  extends ITease
                {
                headline?: string ;
summary?: string ;
id?: string ;
type?: string ;
media?: Thumbnail ;
tags?: string[] ;
dateCreated?: string ;
dateUpdated?: string ;
datePublished?: string ;
author?: string[] ;
sourceUrl?: string ;
status?: Status ; 
                }
export interface Project  extends ITease
                {
                headline?: string ;
summary?: string ;
id?: string ;
type?: string ;
media?: Thumbnail ;
tags?: string[] ;
dateCreated?: string ;
dateUpdated?: string ;
datePublished?: string ;
author?: string[] ;
status?: Status ; 
                }
export interface Study  extends ITease
                {
                headline?: string ;
summary?: string ;
id?: string ;
type?: string ;
media?: Thumbnail ;
tags?: string[] ;
dateCreated?: string ;
dateUpdated?: string ;
datePublished?: string ;
author?: string[] ;
status?: Status ; 
                }
                                }