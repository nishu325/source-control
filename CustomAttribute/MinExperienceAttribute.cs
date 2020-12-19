using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Assignment.CustomAttribute
{
    public class MinExperienceAttribute : ValidationAttribute
    {
        private int minExp;
        /*Here, we assign pre-defined value*/
        public MinExperienceAttribute(int value)
        {
            minExp = value;
        }

        /*
         Here, user entered value is checked if it is valid then go for further operation,
         otherwise it will show error
         */
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value != null)
            {
                if (value is int)
                {
                    int minimumExp = (int)value;
                    if (minimumExp < minExp)
                    {
                        return new ValidationResult("Minimum experience should be " + minExp + " years !");
                    }
                }
            }
            return ValidationResult.Success;
        }
    }
}