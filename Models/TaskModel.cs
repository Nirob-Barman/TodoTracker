using System.ComponentModel.DataAnnotations;

namespace TodoTracker.Models
{
    public class TaskModel
    {
        public int Id { get; set; }

        [Required]
        public string? TaskTitle { get; set; }

        public string? TaskDescription { get; set; }

        public bool IsCompleted { get; set; } = false;

        [Display(Name = "Assign Date")]
        public DateTime TaskAssignDate { get; set; } = DateTime.Now;

        public virtual ICollection<TaskCategory>? Categories { get; set; }
    }
}
