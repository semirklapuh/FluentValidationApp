using System;
using FluentValidation;
using System.Text.RegularExpressions;

namespace testapp.Validators
{
    public class PersonValidator : AbstractValidator<Person>
    {
        public PersonValidator()
        {
            RuleFor(p => p.name)
            .Cascade(CascadeMode.StopOnFirstFailure)
            .NotEmpty().WithMessage("{PropertyName} is empty")
            .Length(2, 50).WithMessage("Lenght of {PropertyName} is invalide")
            .Must(BeAValidName).WithMessage("{PropertyName} contains invalid characters");
            
        }

        protected bool BeAValidName(string name)
        {
            name = name.Replace(" ", "");
            name = name.Replace("-", "");
            return Regex.IsMatch(name, @"^[a-zA-Z]+$");
        }
    }

}