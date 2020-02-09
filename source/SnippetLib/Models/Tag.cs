using Dapper.Contrib.Extensions;

namespace SnippetLib.Models
{
    public class Tag
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
