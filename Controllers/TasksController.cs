using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using TaskTracker.Models;

public class TasksController : Controller
{
    private readonly ITaskService _taskService;
    private readonly UserManager<IdentityUser> _userManager;

    public TasksController(ITaskService taskService, UserManager<IdentityUser> userManager)
    {
        _taskService = taskService;
        _userManager = userManager;
    }

    // GET: Tasks
    public async Task<IActionResult> Index(bool? isCompleted = null, string sortBy = null)
    {
        var user = await _userManager.GetUserAsync(User);
        var tasks = await _taskService.GetTasksByUserIdAsync(user!.Id, isCompleted, sortBy);
        return View(tasks);
    }

    // GET: Tasks/Create
    public IActionResult Create()
    {
        return View();
    }

    // POST: Tasks/Create
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(TaskItem task)
    {
        task.Id = Guid.NewGuid();
        var user = await _userManager.GetUserAsync(User);
        if (user == null)
        {
            return Unauthorized();
        }
        task.UserId = user!.Id;

        ModelState.Remove(nameof(task.UserId));
        if (ModelState.IsValid)
        {
            await _taskService.CreateAsync(task);
            return RedirectToAction(nameof(Index));
        }
        return View(task);
    }

    // GET: Tasks/Edit/5
    public async Task<IActionResult> Edit(Guid id)
    {
        var user = await _userManager.GetUserAsync(User);
        var task = await _taskService.GetByIdAsync(id);

        if (task == null || task.UserId != user!.Id)
            return NotFound();

        return View(task);
    }

    // POST: Tasks/Edit/5
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(Guid id, TaskItem task)
    {
        if (id != task.Id)
            return NotFound();

        var user = await _userManager.GetUserAsync(User);
        var existingTask = await _taskService.GetByIdAsync(id);

        if (existingTask == null || existingTask.UserId != user!.Id)
            return Unauthorized();

        existingTask.Title = task.Title;
        existingTask.Description = task.Description;
        existingTask.IsCompleted = task.IsCompleted;
        existingTask.DueDate = task.DueDate;

        ModelState.Remove(nameof(task.UserId));
        if (ModelState.IsValid)
        {
            await _taskService.UpdateAsync(existingTask);
            return RedirectToAction(nameof(Index));
        }

        return View(task);
    }


    // GET: Tasks/Delete/5
    public async Task<IActionResult> Delete(Guid id)
    {
        var user = await _userManager.GetUserAsync(User);
        var task = await _taskService.GetByIdAsync(id);

        if (task == null || task.UserId != user!.Id)
            return NotFound();

        return View(task);
    }

    // POST: Tasks/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(Guid id)
    {
        var task = await _taskService.GetByIdAsync(id);
        var user = await _userManager.GetUserAsync(User);

        if (task == null || task.UserId != user!.Id)
            return Unauthorized();

        await _taskService.DeleteAsync(id);
        return RedirectToAction(nameof(Index));
    }
}
