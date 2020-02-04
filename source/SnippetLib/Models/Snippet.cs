using System;
using System.Collections.Generic;

namespace SnippetLib.Models
{
    public class Snippet
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public Language Language { get; set; }
        public int Size { get; set; } // Calculated, in bytes
        public string Path { get; set; } // Relative path to actual snippet file
        public string PreviewImagePath { get; set; }
        public List<Tag> Tags { get; set; }
        public Author Author { get; set; }
        public DateTime PublishDate { get; set; }
        public int Version { get; set; }

        public int? PackageId { get; set; } // Optional, set if the snippet is part of a package
    }
}
