using Dapper.Contrib.Extensions;

namespace SnippetLib.Models
{
    public class Author
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
    }
}
