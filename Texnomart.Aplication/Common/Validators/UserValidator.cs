using FluentValidation;
using Texnomart.Domain.Entities;

namespace Texnomart.Aplication.Common.Validators;

public class UserValidator : AbstractValidator<User>
{
    public UserValidator()
    {
        RuleFor(x => x.FrisName)
            .NotEmpty()
            .WithMessage("Ism kiritilishi shart!")
            .Length(3, 30)
            .WithMessage("Ism 3  va 30 ta belgidan iborat bo'lishi lozim!");
        RuleFor(x => x.LastName)
            .NotEmpty()
            .WithMessage("Familya kiritilishi shart!")
            .Length(3, 30)
            .WithMessage("Familya 3  va 30 ta belgidan iborat bo'lishi lozim!");
        RuleFor(x => x.Email)
             .NotEmpty()
             .WithMessage("Email kiritilishi shart!")
             .Length(3, 30)
             .EmailAddress()
             .WithMessage("Email 3 va 30 ta belgidan iborat bolishi lozim!");
        RuleFor(x => x.Password)
             .NotEmpty()
             .WithMessage("Password kiritish shart!")
             .Length(6, 12)
             .WithMessage("Password 6 va 12 orasida bolishi kerak!!!");
        RuleFor(x => x.Address)
            .NotEmpty()
            .WithMessage("Addres kiritilishi shart!")
            .Length(3, 30)
            .WithMessage("Addres 3  va 30 ta belgidan iborat bo'lishi lozim!");
    }
}
