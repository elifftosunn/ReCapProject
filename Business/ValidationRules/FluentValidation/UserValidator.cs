using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace Business.ValidationRules.FluentValidation
{
    public class UserValidator : AbstractValidator<User>
    {
        public UserValidator()
        {
            RuleFor(u=>u.FirstName).NotEmpty().WithMessage("The name field cannot be passed blank!")
                .Length(4, 20).WithMessage("The name field should be between 4 and 20 characters ");
            RuleFor(u => u.LastName).NotEmpty().WithMessage("The surname field cannot be passed blank.")
                .Length(4, 20).WithMessage("The surname field should be between 4 and 20 characters");
            RuleFor(u => u.Email).EmailAddress().WithMessage("Please enter a valid email value!")
                .When(u => !string.IsNullOrEmpty(u.Email));
            RuleFor(u => u.Password).NotEmpty().WithMessage("The password field cannot be passed blank")
                .Must(IsPasswordValid).WithMessage("Your password must contain at least eight characters, at least one letter and a number!");
        }

        private bool IsPasswordValid(string arg)
        {
            Regex regex = new Regex(@"^(?=.*[A-Za-z])(?=.*\d)[A-Za-z\d]{8,}$");
            return regex.IsMatch(arg);
        }
    }
}
