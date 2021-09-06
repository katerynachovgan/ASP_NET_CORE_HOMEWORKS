using HW_11.Models;
using System;
using System.ComponentModel.DataAnnotations;

namespace HW_11.Validation
{
    [AttributeUsage(AttributeTargets.Class)]
    public class ClassValidation : ValidationAttribute
    {
        public ClassValidation(string text)
        {
            Text = text;
        }

        public string Text { get; set; }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var pharmacy = (PharmacyDTO)value;

            if (pharmacy != null)
            {
                string phEmail = pharmacy.ToString();

                if (phEmail.Contains(Text))
                {
                    return ValidationResult.Success;
                }
            }
         
            return new ValidationResult(ErrorMessage ?? "Email does not contain the desired value");
        }
    }
}
