using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace SnippetLib.Business
{
    public class SnippetFileService : ISnippetFileService
    {
        private readonly string _root;
        private const string PATH = "\\wwwroot\\Data\\Snippets\\";

        public SnippetFileService(IConfiguration configuration)
        {
            _root = configuration.GetValue<string>(WebHostDefaults.ContentRootKey);
        }

        private string FilePath(int id) => _root + PATH + id + ".txt";

        public string ReadSnippet(int id)
        {
            try
            {
                return File.ReadAllText(FilePath(id));
            }
            catch(Exception e)
            {
                // log e
                return string.Empty;
            }
        }

        public void SaveSnippet(string snippet, int id)
        {
            try
            {
                File.WriteAllText(FilePath(id), snippet);
            }
            catch (Exception e)
            {
                // log e
            }
        }
    }
}
