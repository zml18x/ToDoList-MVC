namespace AppMVC.Application.Dto.ToDo;

public record CreateToDoDto(Guid UserId, string Content);