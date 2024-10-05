using ClinicManagementSystem.Domain.Commands.UserClient;
using ClinicManagementSystem.Domain.Validators.Requests;
using FluentValidation;

namespace ClinicManagementSystem.Domain.Validators;

public sealed class CreateClientUserValidator : AbstractValidator<CreateClientUserByClinicManagementSystemCommand>
{
    public CreateClientUserValidator()
    {
        RuleFor(x => x.Email).NotEmpty().MaximumLength(50).EmailAddress();
        RuleFor(x => x.Name).NotEmpty().MinimumLength(3).MaximumLength(50);
        RuleFor(x => x.Password).NotEmpty().MinimumLength(3).MaximumLength(50);
    }
}