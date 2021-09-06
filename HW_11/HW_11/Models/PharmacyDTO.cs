using HW_11.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace HW_11.Models
{
    [ClassValidation(".com")]
    public class PharmacyDTO : IValidatableObject
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string Address { get; set; }
        public int EmployeeNumber { get; set; }
        [Required]
        public string Email{ get; set; }
        [Required]
        [DataType(DataType.Date)]
        [ValidDate( ErrorMessage = "Creation date can not be greater than current date")]
        public DateTime CreationDate { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            var result = new List<ValidationResult>();

            if (EmployeeNumber > 10)
            {
                result.Add(new ValidationResult($"Value {EmployeeNumber} is not valid"));
            }
            return result;
        }
    }
}
