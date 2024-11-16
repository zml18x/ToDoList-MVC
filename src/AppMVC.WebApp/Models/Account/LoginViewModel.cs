using System.ComponentModel.DataAnnotations;

namespace AppMVC.WebApp.Models.Account;

public record LoginViewModel
{
    [Required]
    [EmailAddress]
    [Display(Name = "Email")]
    public string Email { get; init; }

    [Required]
    [DataType(DataType.Password)]
    [Display(Name = "Password")]
    public string Password { get; init; }
}