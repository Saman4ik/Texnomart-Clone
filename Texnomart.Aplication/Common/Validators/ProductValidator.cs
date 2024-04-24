using FluentValidation;
using Texnomart.Domain.Entities;

namespace Texnomart.Aplication.Common.Validators;

public class ProductValidator : AbstractValidator<Product>
{
    public ProductValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty()
            .WithMessage("Nomi kiritilishi shart!")
            .Length(3, 30)
            .WithMessage("Nomi 3  va 30 ta belgidan iborat bo'lishi lozim!");
        RuleFor(x => x.Description)
            .NotEmpty()
            .WithMessage("Description kiritilishi shart!")
            .Length(3, 100)
            .WithMessage("Description 3  va 100 ta belgidan iborat bo'lishi lozim!");
        RuleFor(x => x.Price)
            .NotEmpty()
            .WithMessage("Narx kiritilishi shart!")
            .GreaterThan(0)
            .WithMessage("Narx musbat son bo'lishi shart!");
    }
}
