using SnippetLib.Models;
using System.Collections.Generic;

namespace SnippetLib.Business
{
    public interface ISnippetRepository
    {
        IEnumerable<Snippet> GetAll();
    }
}
