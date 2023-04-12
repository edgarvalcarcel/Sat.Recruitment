using Sat.Recruitment.Application.Common.Exceptions;
using Sat.Recruitment.Application.TodoLists.Commands.CreateTodoList;
using Sat.Recruitment.Application.TodoLists.Commands.DeleteTodoList;
using Sat.Recruitment.Domain.Entities;
using FluentAssertions;
using NUnit.Framework;

namespace Sat.Recruitment.Application.IntegrationTests.TodoLists.Commands;

using static Testing;

public class DeleteTodoListTests : BaseTestFixture
{
    [Test]
    public async Task ShouldRequireValidTodoListId()
    {
        var command = new DeleteTodoListCommand(99);
        await FluentActions.Invoking(() => SendAsync(command)).Should().ThrowAsync<NotFoundException>();
    }

    [Test]
    public async Task ShouldDeleteTodoList()
    {
        var listId = await SendAsync(new CreateTodoListCommand
        {
            Title = "New List"
        });

        await SendAsync(new DeleteTodoListCommand(listId));

        var list = await FindAsync<TodoList>(listId);

        list.Should().BeNull();
    }
}
