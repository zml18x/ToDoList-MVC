namespace AppMVC.WebApp.Models.ToDo;

public record ToDoItemViewModel(Guid Id, string Content, DateTime CreatedAt, bool IsCompleted);