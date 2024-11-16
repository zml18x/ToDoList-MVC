namespace AppMVC.Application.Dto.ToDo;

public record ToDoItemDto(Guid Id, string Content, DateTime CreatedAt, bool IsCompleted);