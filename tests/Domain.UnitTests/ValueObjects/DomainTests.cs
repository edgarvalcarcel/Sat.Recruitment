using Sat.Recruitment.Domain.Exceptions;
using FluentAssertions;
using NUnit.Framework;
using Sat.Recruitment.Domain.Entities;

namespace Sat.Recruitment.Domain.UnitTests.ValueObjects;

public class DomainTests
{
    [Test]
    public void ShouldReturnCorrectType()
    {
        var name = "Peter Sagan";
        name.Should().Be(name);
    }

}
