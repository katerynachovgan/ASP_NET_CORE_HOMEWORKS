using System;
using System.ComponentModel.DataAnnotations;

namespace HW_11.Validation
{
    public class ValidDate : ValidationAttribute
    {

        protected override ValidationResult
               IsValid(object value, ValidationContext validationContext)
        {
            DateTime _dateJoin = Convert.ToDateTime(value);
            if (_dateJoin < DateTime.Now)
            {
                return ValidationResult.Success;
            }
            else
            {
                return new ValidationResult("Creation date can not be greater than current date.");
            }
        }
    }
}
