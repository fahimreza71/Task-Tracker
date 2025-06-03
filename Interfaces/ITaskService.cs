using TaskTracker.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

public interface ITaskService
{
    Task<IEnumerable<TaskItem>> GetTasksByUserIdAsync(string userId, bool? isCompleted = null, string sortBy = null);
    Task<TaskItem> GetByIdAsync(Guid id);
    Task CreateAsync(TaskItem task);
    Task UpdateAsync(TaskItem task);
    Task DeleteAsync(Guid id);
}