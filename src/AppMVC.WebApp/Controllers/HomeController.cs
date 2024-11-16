using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using AppMVC.WebApp.Models;

namespace AppMVC.WebApp.Controllers;

public class HomeController : Controller
{
    public IActionResult Index()
    {
        if (User.Identity.IsAuthenticated)
            return RedirectToAction("Index", "Todo");
        
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
