using Sat.Recruitment.Application.TodoLists.Queries.ExportTodos;

namespace Sat.Recruitment.Application.Common.Interfaces;

public interface ICsvFileBuilder
{
    byte[] BuildTodoItemsFile(IEnumerable<TodoItemRecord> records);
}
