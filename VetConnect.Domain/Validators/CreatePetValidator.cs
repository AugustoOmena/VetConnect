using FluentValidation;
using VetConnect.Domain.Commands.Pets;

namespace VetConnect.Domain.Validators;

public sealed class CreatePetValidator : AbstractValidator<CreatePetCommand>
{
    public CreatePetValidator()
    {
        RuleFor(x => x.Name).NotEmpty().MaximumLength(3).MaximumLength(50);
        RuleFor(x => x.BirthDate).NotEmpty();
        RuleFor(x => x.Race).NotEmpty();
        RuleFor(x => x.PetType).NotEmpty();
    }
}