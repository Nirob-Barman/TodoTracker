using System.ComponentModel.DataAnnotations;

namespace TodoTracker.ViewModels
{
    public class TaskCategoryViewModel
    {
        public int Id { get; set; }
        [Required]
        [Display(Name = "Category Name")]
        public string? CategoryName { get; set; }
    }
}
