using System.ComponentModel.DataAnnotations;

namespace TodoTracker.Models
{
    public class TaskCategory
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "Category Name")]
        public string? CategoryName { get; set; }

        public virtual ICollection<TaskModel>? Tasks { get; set; }
    }
}
