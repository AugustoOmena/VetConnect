using FluentValidation;
using VetConnect.Domain.Commands.Pets.Backoffice;

namespace VetConnect.Domain.Validators;

public sealed class CreateServiceHistoryValidator : AbstractValidator<CreateServiceByBackofficeCommand>
{
    public CreateServiceHistoryValidator()
    {
        RuleFor(x => x.Name).NotEmpty().MinimumLength(3).MaximumLength(50);
        RuleFor(x => x.Description).NotEmpty().MinimumLength(3).MaximumLength(50);
        RuleFor(x => x.Price).NotEmpty();
    }
}