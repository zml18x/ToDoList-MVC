using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;
using AppMVC.Infrastructure.Identity;
using AppMVC.Application.Dto.ToDo;
using AppMVC.Application.Interfaces;
using AppMVC.WebApp.Models.ToDo;

namespace AppMVC.WebApp.Controllers;

[Authorize]
public class ToDoController(UserManager<User> userManager, IToDoItemService toDoItemService) : Controller
{
    [HttpGet]
    public async Task<IActionResult> Index()
    {
        var toDoItemsDtos = await toDoItemService.GetToDosAsync(await GetCurrentUserId());
        var result = toDoItemsDtos.Select(x => new ToDoItemViewModel(x.Id, x.Content, x.CreatedAt, x.IsCompleted));
        
        return View(result);
    }
    
    [HttpGet]
    public IActionResult Create()
    {
        return View();
    }
    
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> CreateAsync(CreateToDoViewModel model)
    {
        if (ModelState.IsValid)
        {
            var todoDto = new CreateToDoDto(await GetCurrentUserId(), model.Content);

            await toDoItemService.CreateAsync(todoDto);
            
            return RedirectToAction(nameof(Index));
        }
        return View(model);
    }
    
    [HttpGet]
    public IActionResult Update(UpdateToDoViewModel model)
    {
        return View(model);
    }
    
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> UpdateAsync(UpdateToDoViewModel model)
    {
        if (ModelState.IsValid)
        {
            await toDoItemService.UpdateAsync(new UpdateToDtoDto(model.Id, model.Content));
            return RedirectToAction(nameof(Index));
        }
        return View(model);
    }
    
    [HttpPost]
    public async Task<IActionResult> MarkAsCompleted(Guid id)
    {
        try
        {
            await toDoItemService.MarkAsCompletedAsync(id);
        }
        catch (InvalidOperationException)
        {
            return NotFound();
        }
        
        return RedirectToAction(nameof(Index));
    }
    
    [HttpPost]
    public async Task<IActionResult> MarkAsIncomplete(Guid id)
    {
        try
        {
            await toDoItemService.MarkAsIncompleteAsync(id);
        }
        catch (InvalidOperationException)
        {
            return NotFound();
        }
        
        return RedirectToAction(nameof(Index));
    }
    
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteAsync(Guid id)
    {
        try
        {
            await toDoItemService.DeleteAsync(id);
        }
        catch (InvalidOperationException)
        {
            return NotFound();
        }
        
        return RedirectToAction(nameof(Index));
    }
    
    private async Task<Guid> GetCurrentUserId() =>
        (await userManager.GetUserAsync(User))!.Id;
}