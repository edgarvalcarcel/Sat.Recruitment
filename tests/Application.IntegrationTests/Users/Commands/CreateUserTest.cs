using FluentAssertions;
using NUnit.Framework;
using Sat.Recruitment.Application.Common.Exceptions;
using Sat.Recruitment.Application.Users.Commands.CreateUser;
using Sat.Recruitment.Domain.Entities;
using Sat.Recruitment.Domain.Enums;

namespace Sat.Recruitment.Application.IntegrationTests.Users.Commands;
using static Testing;
public class CreateUserTest : BaseTestFixture
{
    [Test]
    public async Task ShouldRequireMinimumFields()
    {
        var command = new CreateUserCommand();

        await FluentActions.Invoking(() =>
            SendAsync(command)).Should().ThrowAsync<ValidationException>();
    }

    [Test]
    public async Task ShouldCreateUser()
    { 
        var command = new CreateUserCommand
        {
            Name = "Ruth Donovan",
            Email = "euismod.urna@outlook.edu",
            Address = "P.O. Box 221, 1694 Quam Ave",
            Phone = "1-570-279-8614",
            UserType = 3,
            Money = 195
        };

        int itemId = await SendAsync(command);

        var item = await FindAsync<User>(itemId);

        item.Should().NotBeNull();
        item?.Name.Should().Be(command.Name);
        item?.Address.Should().Be(command.Address);
    }
}