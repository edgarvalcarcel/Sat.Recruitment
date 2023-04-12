using Sat.Recruitment.Application.Common.Mappings;
using Sat.Recruitment.Domain.Entities;

namespace Sat.Recruitment.Application.TodoLists.Queries.ExportTodos;

public class TodoItemRecord : IMapFrom<TodoItem>
{
    public string? Title { get; set; }

    public bool Done { get; set; }
}
