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
            .Length(2, 50).WithMessage("Lenght ({TotalLength}) of {PropertyName} is invalide")
            .Must(BeAValidName).WithMessage("{PropertyName} contains invalid characters");

            RuleFor(p => p.date)
            .Must(BeAValidAge).WithMessage("Invalid {PropertyName}");
            
        }

        protected bool BeAValidName(string name)
        {
            name = name.Replace(" ", "");
            name = name.Replace("-", "");
            return Regex.IsMatch(name, @"^[a-zA-Z]+$");
        }

         protected bool BeAValidAge(DateTime date)
        {
            
            int currentYear = DateTime.Now.Year;
            int dobYear = date.Year;

            if(dobYear <= currentYear && dobYear > (currentYear - 120))
            {
                return true;
            }

            return false;
        }
    }

}