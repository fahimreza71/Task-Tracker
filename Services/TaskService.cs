using TaskTracker.Data;
using TaskTracker.Models;
using Microsoft.EntityFrameworkCore;

public class TaskService : ITaskService
{
    private readonly ApplicationDbContext _context;

    public TaskService(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<TaskItem>> GetTasksByUserIdAsync(string userId, bool? isCompleted = null, string sortBy = null)
    {
        var query = _context.TaskItems.Where(t => t.UserId == userId);

        if (isCompleted.HasValue)
            query = query.Where(t => t.IsCompleted == isCompleted.Value);

        if (sortBy == "duedate")
            query = query.OrderBy(t => t.DueDate);

        return await query.ToListAsync();
    }

    public async Task<TaskItem> GetByIdAsync(Guid id)
    {
        return await _context.TaskItems.FindAsync(id);
    }

    public async Task CreateAsync(TaskItem task)
    {
        _context.TaskItems.Add(task);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(TaskItem task)
    {
        _context.TaskItems.Update(task);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(Guid id)
    {
        var task = await _context.TaskItems.FindAsync(id);
        if (task != null)
        {
            _context.TaskItems.Remove(task);
            await _context.SaveChangesAsync();
        }
    }
}