using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using TaskTracker.Data;
using TaskTracker.Models;

public class AdminService : IAdminService
{
    private readonly UserManager<IdentityUser> _userManager;
    private readonly ApplicationDbContext _context;

    public AdminService(UserManager<IdentityUser> userManager, ApplicationDbContext context)
    {
        _userManager = userManager;
        _context = context;
    }

    public async Task<IEnumerable<IdentityUser>> GetAllUsersAsync()
    {
        return await _userManager.Users.ToListAsync();
    }

    public async Task<IdentityUser> GetUserByIdAsync(string userId)
    {
        return await _userManager.FindByIdAsync(userId);
    }

    public async Task<IEnumerable<TaskItem>> GetUserTasksAsync(string userId)
    {
        return await _context.TaskItems.Where(t => t.UserId == userId).ToListAsync();
    }

    public async Task UpdateUserAsync(IdentityUser user)
    {
        var existing = await _userManager.FindByIdAsync(user.Id);
        if (existing != null)
        {
            existing.UserName = user.UserName;
            existing.Email = user.Email;
            // Add more fields as needed
            await _userManager.UpdateAsync(existing);
        }
    }

    public async Task DeleteUserAsync(string userId)
    {
        var user = await _userManager.FindByIdAsync(userId);
        if (user != null)
        {
            await _userManager.DeleteAsync(user);
        }
    }

}
