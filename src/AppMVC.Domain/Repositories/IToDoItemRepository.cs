using AppMVC.Domain.Entities;

namespace AppMVC.Domain.Repositories;

public interface IToDoItemRepository : IRepository<ToDoItem>
{
    public Task<IEnumerable<ToDoItem>> GetAllToDoItemsByUserIdAsync(Guid userId);
}