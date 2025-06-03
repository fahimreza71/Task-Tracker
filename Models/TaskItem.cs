using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace TaskTracker.Models
{
    public class TaskItem
    {
        public Guid Id { get; set; }

        [BindNever]
        public string UserId { get; set; }

        [ForeignKey("UserId")]
        public AppUser? User { get; set; }

        [Required]
        public string Title { get; set; }

        public string? Description { get; set; }

        public bool IsCompleted { get; set; } = false;

        [DataType(DataType.Date)]
        public DateTime? DueDate { get; set; }
    }
}
