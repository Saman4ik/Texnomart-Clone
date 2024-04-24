using FluentValidation;
using Texnomart.Domain.Entities;

namespace Texnomart.Aplication.Common.Validators;

public class CategoryValidator : AbstractValidator<Category>
{
    public CategoryValidator()
    {
        RuleFor(x => x.Name)
    .NotEmpty()
    .WithMessage("Nomi kiritilishi shart!")
    .Length(3, 30)
    .WithMessage("Nomi 3  va 30 ta belgidan iborat bo'lishi lozim!");
    }
}
