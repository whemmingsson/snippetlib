using Dapper.Contrib.Extensions;
using System;
using System.Collections.Generic;

namespace SnippetLib.Models
{
    public class Snippet
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        [Computed]
        public Language Language { get; set; }
        public int Size { get; set; } // Calculated, in bytes
        public string Path { get; set; } // Relative path to actual snippet file
        public string PreviewImagePath { get; set; }

        [Computed]
        public List<Tag> Tags { get; set; }

        [Computed]
        public Author Author { get; set; }
        public DateTime PublishDate { get; set; }
        //public int Version { get; set; } For later versions of this app
        public string SourcePath { get; set; } // If the snippet was taken from an online source
        public int? PackageId { get; set; } // Optional, set if the snippet is part of a package
    }
}
