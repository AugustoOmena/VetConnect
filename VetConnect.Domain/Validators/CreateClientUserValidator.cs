using FluentValidation;
using VetConnect.Domain.Commands.UserClient;

namespace VetConnect.Domain.Validators;

public sealed class CreateClientUserValidator : AbstractValidator<CreateClientUserByVetConnectCommand>
{
    public CreateClientUserValidator()
    {
        RuleFor(x => x.Email).NotEmpty().MaximumLength(50).EmailAddress();
        RuleFor(x => x.FirstName).NotEmpty().MinimumLength(3).MaximumLength(50);
        RuleFor(x => x.LastName).NotEmpty().MinimumLength(3).MaximumLength(50);
        RuleFor(x => x.Password).NotEmpty().MinimumLength(3).MaximumLength(50);
    }
}