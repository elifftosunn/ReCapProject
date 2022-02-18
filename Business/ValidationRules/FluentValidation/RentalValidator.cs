using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.ValidationRules.FluentValidation
{
    public class RentalValidator:AbstractValidator<Rental>
    {
        public RentalValidator()
        {
            RuleFor(r => r.RentDate).NotEmpty().WithMessage("Rent Date is Required");
            RuleFor(r => r.ReturnDate).NotEmpty().GreaterThan(c => c.RentDate)
                .WithMessage("Return date must after Rent date");
            
        }
    }
}
