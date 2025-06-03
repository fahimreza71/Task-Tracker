using Microsoft.AspNetCore.Identity;
using TaskTracker.Models;

public interface IAdminService
{
    Task<IEnumerable<IdentityUser>> GetAllUsersAsync();
    Task<IdentityUser?> GetUserByIdAsync(string userId);
    Task<IEnumerable<TaskItem>> GetUserTasksAsync(string userId);
    Task UpdateUserAsync(IdentityUser user);
    Task DeleteUserAsync(string userId);
}
