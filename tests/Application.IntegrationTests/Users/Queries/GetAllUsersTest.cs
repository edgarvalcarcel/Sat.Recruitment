using Sat.Recruitment.Application.Users.Queries.GetUsers;
using Sat.Recruitment.Domain.Entities;
using Sat.Recruitment.Domain;
using FluentAssertions;
using NUnit.Framework;
using Sat.Recruitment.Application.Users.Queries.ExportUsers;

namespace Sat.Recruitment.Application.IntegrationTests.Users.Queries;
using static Testing;
public class GetAllUsersTest
{
    [Test]
    public async Task ShouldReturnPriorityLevels()
    {
        var query = new ExportUsersQuery();

        var result = await SendAsync(query);

        result.Content.Should().NotBeEmpty();
    }
}
