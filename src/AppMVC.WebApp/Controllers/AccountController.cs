using AppMVC.Infrastructure.Identity;
using AppMVC.WebApp.Models.Account;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace AppMVC.WebApp.Controllers;

public class AccountController(SignInManager<User> signInManager) : Controller
{
    [HttpGet]
    public IActionResult Register()
    {
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Register(RegisterViewModel model)
    {
        if (ModelState.IsValid)
        {
            var user = new User
            {
                UserName = model.Email,
                Email = model.Email
            };
        
            var result = await signInManager.UserManager.CreateAsync(user, model.Password);
            if (result.Succeeded)
            {
                return RedirectToAction("Login", "Account");
            }

            foreach (var error in result.Errors)
            {
                ModelState.AddModelError(string.Empty, error.Description);
            }
        }
        
        return View(model);
    }

    [HttpGet]
    public IActionResult Login()
    {
        return View();
    }
    
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Login(LoginViewModel model)
    {
        if (ModelState.IsValid)
        {
            var result = await signInManager
                .PasswordSignInAsync(model.Email, model.Password, false, false);
        
            if (result.Succeeded)
            {
                return RedirectToAction("Index", "ToDo");
            }

            ModelState.AddModelError(string.Empty, "Invalid Credentials");
        }
        
        return View(model);
    }
}