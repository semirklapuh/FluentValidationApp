using System;
using testapp.Validators;
using System.ComponentModel;
using FluentValidation.Results;
//using FluentValidation.ValidartionFauilure;

namespace testapp
{
    class Program
    {
        static void Main(string[] args)
        {
            BindingList<string> errors = new BindingList<string>();
            Console.WriteLine("Hello World!");
            Person person = new Person{id = 1, name = "S12", accountBalance = 0};

            PersonValidator validator = new PersonValidator();
            ValidationResult results = validator.Validate(person);

            if (results.IsValid == false)
            {
                foreach (ValidationFailure failure in results.Errors)
                {
                    errors.Add($"{failure.ErrorMessage}");
                }
            }

            Console.WriteLine(errors.Count);
            if (errors.Count > 0)
            {
                foreach (var item in errors)
                {
                    Console.WriteLine(item);
                }
            }else{
              Console.WriteLine(person);
            }

            
        }
    }
}
