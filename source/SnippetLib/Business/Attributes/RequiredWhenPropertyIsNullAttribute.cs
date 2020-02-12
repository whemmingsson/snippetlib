using SnippetLib.Models.ViewModels;
using System;
using System.ComponentModel.DataAnnotations;

namespace SnippetLib.Business.Attributes
{
    public class RequiredWhenPropertyIsNullAttribute : RequiredAttribute
    {
        private string _propName;

        public RequiredWhenPropertyIsNullAttribute(string propName) : base()
        {
            _propName = propName;
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var model = (SnippetForm)validationContext.ObjectInstance;
            if(model[_propName] == null)
            {
                return !base.IsValid(value) ? new ValidationResult(ErrorMessage) : ValidationResult.Success;
            }

            return ValidationResult.Success;       
        }
    }
}
