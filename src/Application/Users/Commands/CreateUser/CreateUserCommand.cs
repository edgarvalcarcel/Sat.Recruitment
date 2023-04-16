using Sat.Recruitment.Application.Common.Interfaces;
using Sat.Recruitment.Domain.Entities;
using Sat.Recruitment.Domain.Events;
using MediatR;
using Sat.Recruitment.Domain.Enums;

namespace Sat.Recruitment.Application.Users.Commands.CreateUser;

public record CreateUserCommand : IRequest<int>
{
    public string? Name { get; init; }
    public string? Email { get; init; }
    public string? Address { get; init; }
    public string? Phone { get; init; }
    public int UserType { get; init; }
    public float Money { get; init; }
}

public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, int>
{
    private readonly IApplicationDbContext _context;

    public CreateUserCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<int> Handle(CreateUserCommand request, CancellationToken cancellationToken)
    { 
        var entity = new User
        {
            Name = request.Name,
            Email = request.Email,
            Address = request.Address,
            Phone = request.Phone,
            UserType = (UserType)Enum.Parse(typeof(UserType), value: request.UserType.ToString()),
            Money = request.Money
        };
        entity.Money += (float)CreateUserRulesExtensions.IncreaseValue((int)entity.UserType, (float)entity.Money);

        entity.AddDomainEvent(new UserCreatedEvent(entity));

        _context.User.Add(entity);

        await _context.SaveChangesAsync(cancellationToken);

        return entity.Id;
    }
}
