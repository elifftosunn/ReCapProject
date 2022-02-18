using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.ValidationRules.FluentValidation
{
    public class CustomerValidator:AbstractValidator<Customer>
    {
        public CustomerValidator()
        {
            RuleFor(c => c.CompanyName).NotEmpty().MinimumLength(2)
                .WithMessage("The company name must be at least 2 characters long.");  
        }
    }
}
