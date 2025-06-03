using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using TaskTracker.Models;
using TaskTracker.Services;

[Authorize(Roles = "Admin")]
public class AdminController : Controller
{
    private readonly IAdminService _adminService;

    public AdminController(IAdminService adminService)
    {
        _adminService = adminService;
    }

    public async Task<IActionResult> Index()
    {
        var users = await _adminService.GetAllUsersAsync();
        return View(users);
    }

    public async Task<IActionResult> Details(string id)
    {
        var user = await _adminService.GetUserByIdAsync(id);
        var tasks = await _adminService.GetUserTasksAsync(id);
        ViewBag.Tasks = tasks;
        return View(user);
    }

    public async Task<IActionResult> Edit(string id)
    {
        var user = await _adminService.GetUserByIdAsync(id);
        return View(user);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(IdentityUser user)
    {
        if (ModelState.IsValid)
        {
            await _adminService.UpdateUserAsync(user);
            return RedirectToAction(nameof(Index));
        }
        return View(user);
    }

    public async Task<IActionResult> Delete(string id)
    {
        var user = await _adminService.GetUserByIdAsync(id);
        return View(user);
    }

    [HttpPost, ActionName("Delete")]
    public async Task<IActionResult> DeleteConfirmed(string id)
    {
        await _adminService.DeleteUserAsync(id);
        return RedirectToAction(nameof(Index));
    }
}
