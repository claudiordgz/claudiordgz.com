using System;
using System.Collections.Generic;
using System.Linq;
using YamlDotNet.Serialization;

namespace ContentManager.Models
{
    public class SiteDefaults
    {
        public List<Thumbnail> _thumbnails;

        public string ThumbnailDirectory { get; set; }
        public List<Author> Authors { get; set; }
        public List<Author> Credits { get; set; }
        public List<Thumbnail> Thumbnails
        {
            get => _thumbnails.Select(thumbnail =>
             {
                 if (!thumbnail.File.StartsWith(ThumbnailDirectory))
                 {
                    thumbnail.File = $"{ThumbnailDirectory}/{thumbnail.File}";
                 }
                 return thumbnail;
             }).ToList();
            set { _thumbnails = value; }
        }
    }

    public class FrontMatter
    {
        public string Title { get; set; }
        public string Slug { get; set; }
        [YamlMember(Alias = "date_created", ApplyNamingConventions = false)]
        public DateTime? Created { get; set; }
        [YamlMember(Alias = "date_published", ApplyNamingConventions = false)]
        public DateTime? Published { get; set; }
        [YamlMember(Alias = "date_updated", ApplyNamingConventions = false)]
        public DateTime? Updated { get; set; }
        public List<string> Tags { get; set; }
        [YamlMember(Alias = "draft", ApplyNamingConventions = false)]
        public bool IsDraft { get; set; }
        public string Author { get; set; }
        public Thumbnail Thumbnail { get; set; }

        public object this[string propertyName]
        {
            get { return GetType().GetProperty(propertyName).GetValue(this, null); }
            set { GetType().GetProperty(propertyName).SetValue(this, value, null); }
        }
    }

    public class ContentSection
    {
        public string Section { get; set; }
        public string Html { get; set; }
        public List<string> CustomElements { get; set; }
    }

    public class Thumbnail
    {
        public string Id { get; set; }
        public string File { get; set; } // path to file in github, to move to cloudinary?
        public string Type { get; set; } // so far image, video... audio maybe?
    }

    public class Author
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Website { get; set; }
        public string Twitter { get; set; }
        public string Github { get; set; }
    }

    public enum Status
    {
        published,      // visibility: production, staging, dev
        unpublished,    // visibility: staging, dev
        draft           // visibility: dev
    }

    public interface ITease
    {
        string Headline { get; set; }
        string Summary { get; set; }
        string Id { get; set; }
        string Type { get; }
        Thumbnail Media { get; set; }
        List<string> Tags { get; set; }
        string DateCreated { get; set; }
        string DateUpdated { get; set; }
        string DatePublished { get; set; }
        List<string> Author { get; set; }
        Status Status { get; set; }
    }

    public class BlogPost : ITease
    {
        public string Headline { get; set; }
        public string Summary { get; set; }
        public string Id { get; set; }
        public string Type { get; } = "BlogPost";
        public Thumbnail Media { get; set; }
        public List<string> Tags { get; set; }
        public string DateCreated { get; set; }
        public string DateUpdated { get; set; }
        public string DatePublished { get; set; }
        public List<string> Author { get; set; }
        public List<ContentSection> Content { get; set; }
        public Status Status { get; set; }
    }

    public class FeedPost : ITease
    {
        public string Headline { get; set; }
        public string Summary { get; set; }
        public string Id { get; set; }
        public string Type { get; } = "FeedPost";
        public Thumbnail Media { get; set; }
        public List<string> Tags { get; set; }
        public string DateCreated { get; set; }
        public string DateUpdated { get; set; }
        public string DatePublished { get; set; }
        public List<string> Author { get; set; }
        public string FeedId { get; set; }
        public List<ContentSection> Content { get; set; }
        public Status Status { get; set; }
    }

    public class ProjectPost : ITease
    {
        public string Headline { get; set; }
        public string Summary { get; set; }
        public string Id { get; set; }
        public string Type { get; } = "ProjectPost";
        public Thumbnail Media { get; set; }
        public List<string> Tags { get; set; }
        public string DateCreated { get; set; }
        public string DateUpdated { get; set; }
        public string DatePublished { get; set; }
        public List<string> Author { get; set; }
        public string ProjectId { get; set; }
        public List<ContentSection> Content { get; set; }
        public Status Status { get; set; }
    }

    public class StudyPost : ITease
    {
        public string Headline { get; set; }
        public string Summary { get; set; }
        public string Id { get; set; }
        public string Type { get; } = "StudyPost";
        public Thumbnail Media { get; set; }
        public List<string> Tags { get; set; }
        public string DateCreated { get; set; }
        public string DateUpdated { get; set; }
        public string DatePublished { get; set; }
        public List<string> Author { get; set; }
        public string StudyId { get; set; }
        public List<ContentSection> Content { get; set; }
        public Status Status { get; set; }
    }

    public class Feed : ITease
    {
        public string Headline { get; set; }
        public string Summary { get; set; }
        public string Id { get; set; }
        public string Type { get; } = "Feed";
        public Thumbnail Media { get; set; }
        public List<string> Tags { get; set; }
        public string DateCreated { get; set; }
        public string DateUpdated { get; set; }
        public string DatePublished { get; set; }
        public List<string> Author { get; set; }
        public string SourceUrl { get; set; }
        public Status Status { get; set; }
    }

    public class Project : ITease
    {
        public string Headline { get; set; }
        public string Summary { get; set; }
        public string Id { get; set; }
        public string Type { get; } = "Project";
        public Thumbnail Media { get; set; }
        public List<string> Tags { get; set; }
        public string DateCreated { get; set; }
        public string DateUpdated { get; set; }
        public string DatePublished { get; set; }
        public List<string> Author { get; set; }
        public Status Status { get; set; }
    }

    public class Study : ITease
    {
        public string Headline { get; set; }
        public string Summary { get; set; }
        public string Id { get; set; }
        public string Type { get; } = "Study";
        public Thumbnail Media { get; set; }
        public List<string> Tags { get; set; }
        public string DateCreated { get; set; }
        public string DateUpdated { get; set; }
        public string DatePublished { get; set; }
        public List<string> Author { get; set; }
        public Status Status { get; set; }
    }
}
