using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Midly.Models
{
    public class Min18IfYouMember: ValidationAttribute 
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
           var customer = (Customer) validationContext.ObjectInstance;
            if (customer.MembershipTypeId == 0 || customer.MembershipTypeId == MembershipType.PayAsYouGo)
                return ValidationResult.Success;
            if (customer.BirthDate == null)
                return new ValidationResult("Birthdate is Required Please");
            var age = DateTime.Today.Year - customer.BirthDate.Value.Year;
            return
                (age >= 18) ? ValidationResult.Success
                            : new ValidationResult("Your Age is Must Be Greater than 18"); 

        }
    }
}