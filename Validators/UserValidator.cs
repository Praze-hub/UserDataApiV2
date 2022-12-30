using WellaApi.Models;
using FluentValidation;
using System;

namespace WellaApi.Validators{
    public class UserValidator : AbstractValidator<UserData>{
        public UserValidator(){
        RuleFor(x => x.FirstName).NotEmpty().WithMessage("{PropertyName} should not be empty");
        RuleFor(x => x.LastName).NotEmpty().WithMessage("{PropertyName} should not be empty");
        RuleFor(x => x.Username).NotEmpty();
        RuleFor(x => x.Phonenumber).NotNull();
        RuleFor(x => x.Password).MinimumLength(8);
        RuleFor(x => x.EmailAddress).EmailAddress();
        
        }
    }
}
 
 