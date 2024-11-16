using FluentValidation;
using VetConnect.Domain.Commands.Scheduling;

namespace VetConnect.Domain.Validators;

public class CreateSchedulingValidator: AbstractValidator<CreateSchedulingByUserCommand>
{
    public CreateSchedulingValidator()
    {
        RuleFor(x => x.Description).NotEmpty().MinimumLength(3).MaximumLength(45);
        RuleFor(x => x.InitialDate).NotEmpty();
        RuleFor(x => x.EndDate).NotEmpty();
    }
}