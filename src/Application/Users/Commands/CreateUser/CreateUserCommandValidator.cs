using FluentValidation;
using Sat.Recruitment.Domain.Enums;

namespace Sat.Recruitment.Application.Users.Commands.CreateUser;

public class CreateUserCommandValidator : AbstractValidator<CreateUserCommand>
{
    public CreateUserCommandValidator()
    {
        RuleFor(u => u.Name).MinimumLength(10).MaximumLength(200)
            .NotEmpty().WithMessage("{PropertyName} is required, and max. 200 Caracters.");

        RuleFor(u => u.Email).MinimumLength(10).MaximumLength(200)
            .NotEmpty().WithMessage("{PropertyName} is required and max. 200 Caracters");

        RuleFor(u => u.Address).MinimumLength(10).MaximumLength(200)
            .NotEmpty().WithMessage("{PropertyName} is required, and max. 200 Caracters.");

        RuleFor(u => u.Phone).MinimumLength(10).MaximumLength(50)
            .NotEmpty().WithMessage("{PropertyName} is required, and max. 50 Caracters.");

        RuleFor(u => u.Money).GreaterThan(0)
           .NotEmpty().WithMessage("{PropertyName} is required, greater than 0.");
        
    }
}
