using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApplication8.Common
{
    public class CustomEmailExit : ValidationAttribute, IClientModelValidator
    {
        public void AddValidation(ClientModelValidationContext context)
        {

            if (!context.Attributes.ContainsKey("data-val-customemailexit"))

                context.Attributes.Add("data-val-customemailexit", ErrorMessage);


          

        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var d = value.ToString();   

            if(!d.Contains("weltec"))
            {
                return new ValidationResult("This is the invalid email-id ");
            }

            return ValidationResult.Success;

        }


       




    }
}
