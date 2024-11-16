using AppMVC.Domain.Entities;
using AppMVC.Domain.Repositories;
using AppMVC.Infrastructure.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace AppMVC.Infrastructure.Repositories;

public class ToDoItemRepository(AppDbContext context) : Repository<ToDoItem>(context), IToDoItemRepository
{
    private readonly AppDbContext _context = context;

    public async Task<IEnumerable<ToDoItem>> GetAllToDoItemsByUserIdAsync(Guid userId)
        => await _context.ToDoItems.Where(x => x.UserId == userId).ToListAsync();
}