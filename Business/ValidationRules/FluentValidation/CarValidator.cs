using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.ValidationRules.FluentValidation
{
    public class CarValidator:AbstractValidator<Car>
    {
        public CarValidator()
        {
            RuleFor(c => c.Description).MinimumLength(2).WithMessage("Araba tanımlaması min 2 karakter olmalıdır.");
            RuleFor(c => c.Description).NotEmpty().WithMessage("Araba tanımı boş bırakılamaz");
            RuleFor(c => c.DailyPrice).NotEmpty().WithMessage("Araba günlük fiyatı boş bırakılamaz.");
            RuleFor(c => c.DailyPrice).GreaterThan(100).WithMessage("Araba günlük fiyatı 100'den büyük olmalıdır.");
        }
    }
}
