using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DemoMvc.Models
{
    public class CustomDoj : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value,ValidationContext validationContext)
        {
            DateTime D = Convert.ToDateTime(value);
            DateTime TD = DateTime.Now;
            int age = (int)(TD.Subtract(D).TotalDays / 365);
            if (D > TD)
            {
                return new ValidationResult("Date Cannot be greater then today's date");
            }
            else if (age < 21 || age > 58)
            {
                return new ValidationResult("Age must be between 21 and 58");
            }
            else
            {
                return ValidationResult.Success;
            }
        }
        

    }
}