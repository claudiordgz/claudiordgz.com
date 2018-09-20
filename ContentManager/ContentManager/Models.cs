using System;
using System.Collections.Generic;
using System.Text;

namespace ContentManager.Models
{
    public class Thumbnail
    {
        public string Id { get; set; }
        public string File { get; set; } // path to file in github, to move to cloudinary
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
        string CreationDate { get; set; }
        string UpdateDate { get; set; }
        List<string> Author { get; set; }
    }

    public class BlogPost : ITease
    {
        public string Headline { get; set; }
        public string Summary { get; set; }
        public string Id { get; set; }
        public string Type { get; } = "BlogPost";
        public Thumbnail Media { get; set; }
        public List<string> Tags { get; set; }
        public string CreationDate { get; set; }
        public string UpdateDate { get; set; }
        public List<string> Author { get; set; }
        public Status Status { get; set; }
        public List<string> Content { get; set; }
    }

    public class FeedPost : ITease
    {
        public string Headline { get; set; }
        public string Summary { get; set; }
        public string Id { get; set; }
        public string Type { get; } = "FeedPost";
        public Thumbnail Media { get; set; }
        public List<string> Tags { get; set; }
        public string CreationDate { get; set; }
        public string UpdateDate { get; set; }
        public List<string> Author { get; set; }
        public string FeedId { get; set; }
        public List<string> Content { get; set; }
    }

    public class ProjectPost : ITease
    {
        public string Headline { get; set; }
        public string Summary { get; set; }
        public string Id { get; set; }
        public string Type { get; } = "ProjectPost";
        public Thumbnail Media { get; set; }
        public List<string> Tags { get; set; }
        public string CreationDate { get; set; }
        public string UpdateDate { get; set; }
        public List<string> Author { get; set; }
        public string ProjectId { get; set; }
        public Status Status { get; set; }
        public List<string> Content { get; set; }
    }

    public class StudyPost : ITease
    {
        public string Headline { get; set; }
        public string Summary { get; set; }
        public string Id { get; set; }
        public string Type { get; } = "StudyPost";
        public Thumbnail Media { get; set; }
        public List<string> Tags { get; set; }
        public string CreationDate { get; set; }
        public string UpdateDate { get; set; }
        public List<string> Author { get; set; }
        public string StudyId { get; set; }
        public Status Status { get; set; }
        public List<string> Content { get; set; }
    }

    public class Feed : ITease
    {
        public string Headline { get; set; }
        public string Summary { get; set; }
        public string Id { get; set; }
        public string Type { get; } = "Feed";
        public Thumbnail Media { get; set; }
        public List<string> Tags { get; set; }
        public string CreationDate { get; set; }
        public string UpdateDate { get; set; }
        public List<string> Author { get; set; }
        public string SourceUrl { get; set; }
    }

    public class Project : ITease
    {
        public string Headline { get; set; }
        public string Summary { get; set; }
        public string Id { get; set; }
        public string Type { get; } = "Project";
        public Thumbnail Media { get; set; }
        public List<string> Tags { get; set; }
        public string CreationDate { get; set; }
        public string UpdateDate { get; set; }
        public List<string> Author { get; set; }
    }

    public class Study : ITease
    {
        public string Headline { get; set; }
        public string Summary { get; set; }
        public string Id { get; set; }
        public string Type { get; } = "Study";
        public Thumbnail Media { get; set; }
        public List<string> Tags { get; set; }
        public string CreationDate { get; set; }
        public string UpdateDate { get; set; }
        public List<string> Author { get; set; }
    }
}
