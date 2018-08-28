using System;
using System.Collections.Generic;
using System.Text;

namespace ContentManager.Models
{
    // so far image, video... audio maybe?
    public class Thumbnail
    {
        public string Id { get; set; }
        public string File { get; set; }
        public string Type { get; set; }
    }

    public class Author
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
    }

    public enum Status
    {
        published,
        unpublished,
        draft
    }

    public interface ITease
    {
        string Headline { get; set; }
        string Summary { get; set; }
        string Id { get; set; }
        string Thumbnail { get; set; }
        List<string> Tags { get; set; }
        string CreationDate { get; set; }
        string UpdateDate { get; set; }
        List<Author> Author { get; set; }
    }

    public class BlogPost : ITease
    {
        public string Headline { get; set; }
        public string Summary { get; set; }
        public string Id { get; set; }
        public string Thumbnail { get; set; }
        public List<string> Tags { get; set; }
        public string CreationDate { get; set; }
        public string UpdateDate { get; set; }
        public List<Author> Author { get; set; }
        public Status Status { get; set; }
        public List<string> Content { get; set; }
    }

    public class FeedPost : ITease
    {
        public string Headline { get; set; }
        public string Summary { get; set; }
        public string Id { get; set; }
        public string Thumbnail { get; set; }
        public List<string> Tags { get; set; }
        public string CreationDate { get; set; }
        public string UpdateDate { get; set; }
        public List<Author> Author { get; set; }
        public string FeedId { get; set; }
        public List<string> Content { get; set; }
    }

    public class ProjectPost : ITease
    {
        public string Headline { get; set; }
        public string Summary { get; set; }
        public string Id { get; set; }
        public string Thumbnail { get; set; }
        public List<string> Tags { get; set; }
        public string CreationDate { get; set; }
        public string UpdateDate { get; set; }
        public List<Author> Author { get; set; }
        public string ProjectId { get; set; }
        public Status Status { get; set; }
        public List<string> Content { get; set; }
    }

    public class StudyPost : ITease
    {
        public string Headline { get; set; }
        public string Summary { get; set; }
        public string Id { get; set; }
        public string Thumbnail { get; set; }
        public List<string> Tags { get; set; }
        public string CreationDate { get; set; }
        public string UpdateDate { get; set; }
        public List<Author> Author { get; set; }
        public string StudyId { get; set; }
        public Status Status { get; set; }
        public List<string> Content { get; set; }
    }

    public class Feed : ITease
    {
        public string Headline { get; set; }
        public string Summary { get; set; }
        public string Id { get; set; }
        public string Thumbnail { get; set; }
        public List<string> Tags { get; set; }
        public string CreationDate { get; set; }
        public string UpdateDate { get; set; }
        public List<Author> Author { get; set; }
        public string SourceUrl { get; set; }
    }

    public class Project : ITease
    {
        public string Headline { get; set; }
        public string Summary { get; set; }
        public string Id { get; set; }
        public string Thumbnail { get; set; }
        public List<string> Tags { get; set; }
        public string CreationDate { get; set; }
        public string UpdateDate { get; set; }
        public List<Author> Author { get; set; }
    }

    public class Study : ITease
    {
        public string Headline { get; set; }
        public string Summary { get; set; }
        public string Id { get; set; }
        public string Thumbnail { get; set; }
        public List<string> Tags { get; set; }
        public string CreationDate { get; set; }
        public string UpdateDate { get; set; }
        public List<Author> Author { get; set; }
    }
}
