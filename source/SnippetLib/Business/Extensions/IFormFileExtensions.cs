using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace SnippetLib.Business.Extensions
{
    public static class IFormFileExtensions
    {
        public static string ReadString(this IFormFile file)
        {
            if (file == null)
                return string.Empty;

            using (var reader = new StreamReader(file.OpenReadStream()))
            {
                return reader.ReadToEnd();
            }
        }
    }
}
