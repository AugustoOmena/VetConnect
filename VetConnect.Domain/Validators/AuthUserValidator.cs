using FluentValidation;
using VetConnect.Domain.Commands.Auth;

namespace VetConnect.Domain.Validators;

public sealed class AuthUserValidator : AbstractValidator<AuthorizeUserCommand>
{
    public AuthUserValidator()
    {
        RuleFor(x => x.Email).NotEmpty().MaximumLength(50).EmailAddress();
        RuleFor(x => x.Password).NotEmpty().MinimumLength(3).MaximumLength(50);
    }
}