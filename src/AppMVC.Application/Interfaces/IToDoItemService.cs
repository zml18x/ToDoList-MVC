using AppMVC.Application.Dto.ToDo;

namespace AppMVC.Application.Interfaces;

public interface IToDoItemService
{
    public Task CreateAsync(CreateToDoDto model);
    public Task<IEnumerable<ToDoItemDto>> GetToDosAsync(Guid userId);
    public Task UpdateAsync(UpdateToDtoDto model);
    public Task MarkAsCompletedAsync(Guid toDoItemId);
    public Task MarkAsIncompleteAsync(Guid toDoItemId);
    public Task DeleteAsync(Guid toDoItemId);
}