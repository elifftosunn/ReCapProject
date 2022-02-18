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
            RuleFor(u=>u.FirstName).NotEmpty().WithMessage("İsim alanı boş geçilemez!")
                .Length(4, 20).WithMessage("İsim alanı 4 ile 20 karakter arasında olmalıdır!");
            RuleFor(u => u.LastName).NotEmpty().WithMessage("Soyisim alanı boş geçilemez.")
                .Length(4, 20).WithMessage("İsim alanı 4 ile 20 karakter arasında olmalıdır!");
            RuleFor(u => u.Email).EmailAddress().WithMessage("Geçerli bir e-posta degeri giriniz!")
                .When(u => !string.IsNullOrEmpty(u.Email));
            RuleFor(u => u.Password).NotEmpty().WithMessage("Parola alanı boş geçilemez")
                .Must(IsPasswordValid).WithMessage("Parolanız en az sekiz karakter, en az bir harf ve bir sayı içermelidir!");
        }

        private bool IsPasswordValid(string arg)
        {
            Regex regex = new Regex(@"^(?=.*[A-Za-z])(?=.*\d)[A-Za-z\d]{8,}$");
            return regex.IsMatch(arg);
        }
    }
}
