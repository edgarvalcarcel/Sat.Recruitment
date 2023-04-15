using Sat.Recruitment.Application.Common.Behaviours;
using Sat.Recruitment.Application.Common.Interfaces;
using Microsoft.Extensions.Logging;
using Moq;
using NUnit.Framework;
using Azure.Core;
using Sat.Recruitment.Domain.Enums;
using Sat.Recruitment.Application.Users.Commands.CreateUser;

namespace Sat.Recruitment.Application.UnitTests.Common.Behaviours;

public class RequestLoggerTests
{
    private Mock<ILogger<CreateUserCommand>> _logger = null!;
    private Mock<ICurrentUserService> _currentUserService = null!;
    private Mock<IIdentityService> _identityService = null!;

    [SetUp]
    public void Setup()
    {
        _logger = new Mock<ILogger<CreateUserCommand>>();
        _currentUserService = new Mock<ICurrentUserService>();
        _identityService = new Mock<IIdentityService>();
    }

    [Test]
    public async Task ShouldCallGetUserNameAsyncOnceIfAuthenticated()
    {
        _currentUserService.Setup(x => x.UserId).Returns(Guid.NewGuid().ToString());

        var requestLogger = new LoggingBehaviour<CreateUserCommand>(_logger.Object, _currentUserService.Object, _identityService.Object);

        await requestLogger.Process(new CreateUserCommand
        { 
            Name = "Test",
            Email = "test@yopmail.com",
            Address = "6198 Bailey Ports",
            Phone = "524.232.8003",
            UserType = (int)(UserType)Enum.Parse(typeof(UserType),"1"),
            Money = (float?)25.00,
        }, new CancellationToken());

        _identityService.Verify(i => i.GetUserNameAsync(It.IsAny<string>()), Times.Once);
    }

    [Test]
    public async Task ShouldNotCallGetUserNameAsyncOnceIfUnauthenticated()
    {
        var requestLogger = new LoggingBehaviour<CreateUserCommand>(_logger.Object, _currentUserService.Object, _identityService.Object);

        await requestLogger.Process(new CreateUserCommand
        {
            Name = "Test owner",
            Email = "testowner@yopmail.com",
            Address = "810 Stroman Bridge",
            Phone = "95419-0807",
            UserType = (int)(UserType)Enum.Parse(typeof(UserType), "1"),
            Money = (float?)25.00,
        }, new CancellationToken());

        _identityService.Verify(i => i.GetUserNameAsync(It.IsAny<string>()), Times.Never);
    }
}
