using System.ComponentModel.DataAnnotations;

namespace AppMVC.WebApp.Models.ToDo;

public record CreateToDoViewModel
{
    [Required]
    public string Content { get; init; }
}