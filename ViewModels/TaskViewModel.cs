using System.ComponentModel.DataAnnotations;
using TodoTracker.Models;

namespace TodoTracker.ViewModels
{
    public class TaskViewModel
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "Task Title")]
        public string? TaskTitle { get; set; }

        [Display(Name = "Description")]
        public string? TaskDescription { get; set; }

        [Display(Name = "Completed")]
        public bool IsCompleted { get; set; }

        [Required]
        [Display(Name = "Assign Date")]
        public DateTime TaskAssignDate { get; set; } = DateTime.Now;

        [Display(Name = "Categories")]
        public List<int>? SelectedCategoryIds { get; set; }

        public IEnumerable<TaskCategory>? AvailableCategories { get; set; }
    }
}
