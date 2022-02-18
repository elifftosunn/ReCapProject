using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.ValidationRules.FluentValidation
{
    public class BrandValidator:AbstractValidator<Brand>
    {
        public BrandValidator()
        {
            RuleFor(b => b.BrandName).NotEmpty().WithMessage("the brand name can not be empty");
            RuleFor(b => b.BrandName).Length(3, 15).WithMessage("the brand name should be between 3 to 15");

        }
    }
}
