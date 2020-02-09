using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SnippetLib.Business
{
    public interface ISnippetFileService
    {
        public void SaveSnippet(string snippet, int id);
        public string ReadSnippet(int id);
    }
}
