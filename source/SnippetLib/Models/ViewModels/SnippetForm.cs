using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;
using SnippetLib.Business.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace SnippetLib.Models.ViewModels
{
    public class SnippetForm
    {
        public object this[string propertyName] => typeof(SnippetForm).GetProperty(propertyName).GetValue(this, null);

        [Required]
        public string Name { get; set; }
        public string Description { get; set; }

        [RequiredWhenPropertyIsNull("SnippetFile")]
        public string Snippet { get; set; }

        [DataType(DataType.Upload)]
        [RequiredWhenPropertyIsNull("Snippet")]
        public IFormFile SnippetFile { get; set; }

        [Required]
        public int Language { get; set; }
        public string PreviewImagePath { get; set; }
        public string TagsIds { get; set; }
        public string AuthorEmail { get; set; }
        public int? PackageId { get; set; }

        public IEnumerable<SelectListItem> Languages
        {
            get
            {
                foreach(var l in Enum.GetValues(typeof(Language)).Cast<Language>())
                {
                    yield return new SelectListItem() { Text = l.ToString(), Value = ((int)l).ToString() };
                }
            }
        }
    }
}
