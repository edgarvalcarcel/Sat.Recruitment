using FluentValidation;
using Sat.Recruitment.Domain.Enums;

namespace Sat.Recruitment.Application.Users.Commands.CreateUser;

public class CreateUserCommandValidator : AbstractValidator<CreateUserCommand>
{
    public CreateUserCommandValidator()
    {
        RuleFor(u => u.Name).NotNull().MinimumLength(10).MaximumLength(200)
            .NotEmpty().WithMessage("{PropertyName} is required, and max. 200 Caracters.");

        RuleFor(u => u.Email).MinimumLength(10).MaximumLength(200).NotNull()
            .NotEmpty().WithMessage("{PropertyName} is required and max. 200 Caracters");

        RuleFor(u => u.Email).NotEmpty().WithMessage("Email address is required")
                   .EmailAddress().WithMessage("A valid email is required");

        RuleFor(u => u.Address).NotNull().MinimumLength(10).MaximumLength(200)
            .NotEmpty().WithMessage("{PropertyName} is required, and max. 200 Caracters.");

        RuleFor(u => u.Phone).NotNull().MinimumLength(10).MaximumLength(50)
            .NotEmpty().WithMessage("{PropertyName} is required, and max. 50 Caracters.");

        RuleFor(u => u.Money).NotNull().GreaterThan(0)
           .NotEmpty().WithMessage("{PropertyName} is required, greater than 0.");

        RuleFor(u => u.UserType).GreaterThan(0).NotNull().NotEmpty().WithMessage("{PropertyName} is required, and 1,2 or 3.");


    }
}
