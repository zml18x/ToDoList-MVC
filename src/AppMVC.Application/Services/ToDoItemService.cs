using AutoMapper;
using AppMVC.Domain.Builders;
using AppMVC.Domain.Exceptions;
using AppMVC.Domain.Repositories;
using AppMVC.Domain.Specifications;
using AppMVC.Application.Dto.ToDo;
using AppMVC.Application.Extensions;
using AppMVC.Application.Interfaces;

namespace AppMVC.Application.Services;

public class ToDoItemService(ToDoItemBuilder builder, IToDoItemRepository toDoItemRepository, IMapper mapper) : IToDoItemService
{
    public async Task CreateAsync(CreateToDoDto model)
    {
        var toDoItem = builder
            .WithUserId(model.UserId)
            .WithContent(model.Content)
            .Build();

        await toDoItemRepository.CreateAsync(toDoItem);
        await toDoItemRepository.SaveChangesAsync();
    }
    
    public async Task<IEnumerable<ToDoItemDto>> GetToDosAsync(Guid userId)
    {
        var toDos = await toDoItemRepository.GetAllToDoItemsByUserIdAsync(userId);

        return mapper.Map<IEnumerable<ToDoItemDto>>(toDos);
    }

    public async Task UpdateAsync(UpdateToDtoDto model)
    {
        var toDoItem = await toDoItemRepository.GetOrThrowAsync(() => toDoItemRepository.GetByIdAsync(model.Id));

        toDoItem.Update(model.Content);
        
        var result = new ToDoItemSpec().IsSatisfiedBy(toDoItem);
        if (!result.IsValid)
            throw new DomainValidationException(
                $"Validation failed for ToDoItem with ID {model.Id}: {string.Join(", ", result.Errors)}");

        await toDoItemRepository.SaveChangesAsync();
    }
    
    public async Task MarkAsCompletedAsync(Guid toDoItemId)
    {
        var toDoItem = await toDoItemRepository.GetOrThrowAsync(() => toDoItemRepository.GetByIdAsync(toDoItemId));
        
        toDoItem.MarkAsCompleted();
        await toDoItemRepository.SaveChangesAsync();
    }
    
    public async Task MarkAsIncompleteAsync(Guid toDoItemId)
    {
        var toDoItem = await toDoItemRepository.GetOrThrowAsync(() => toDoItemRepository.GetByIdAsync(toDoItemId));
        
        toDoItem.MarkAsIncomplete();
        await toDoItemRepository.SaveChangesAsync();
    }
    
    public async Task DeleteAsync(Guid toDoItemId)
    {
        var toDoItem = await toDoItemRepository.GetOrThrowAsync(() => toDoItemRepository.GetByIdAsync(toDoItemId));

        toDoItemRepository.Delete(toDoItem);
        await toDoItemRepository.SaveChangesAsync();
    }
}