using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SnippetLib.Models.ViewModels
{
    public class SnippetForm
    {
        [Required]
        public string Name { get; set; }
        public string Description { get; set; }

        [Required]
        public string Snippet { get; set; }

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
