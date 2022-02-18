using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.ValidationRules.FluentValidation
{
    public class ColorValidator:AbstractValidator<Color>
    {
        public ColorValidator()
        {
            RuleFor(c=>c.ColorName).NotEmpty().WithMessage("The color space cannot be empty");
            RuleFor(c => c.ColorName).Length(2, 10).WithMessage("the color name should be between 2 to 10");
        }
    }
}
