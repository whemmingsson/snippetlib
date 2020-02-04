using System.Collections.Generic;

namespace SnippetLib.Models
{
    public class Package
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public Author Author { get; set; }
        public List<Snippet> Snippets { get; set; } // Calculated
    }
}
