using Microsoft.EntityFrameworkCore;
using TodoTracker.Models;

namespace TodoTracker.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options) { }

        public DbSet<TaskModel> Tasks { get; set; }
        public DbSet<TaskCategory> Categories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Seed Task Categories
            modelBuilder.Entity<TaskCategory>().HasData(
                new TaskCategory { Id = 1, CategoryName = "Work" },
                new TaskCategory { Id = 2, CategoryName = "Personal" },
                new TaskCategory { Id = 3, CategoryName = "Urgent" },
                new TaskCategory { Id = 4, CategoryName = "Health" },
                new TaskCategory { Id = 5, CategoryName = "Learning" }
            );

            // Seed Task Models
            modelBuilder.Entity<TaskModel>().HasData(
                new TaskModel
                {
                    Id = 1,
                    TaskTitle = "Finish report",
                    TaskDescription = "Complete the annual financial report",
                    IsCompleted = false,
                    TaskAssignDate = new DateTime(2025, 5, 1)
                },
                new TaskModel
                {
                    Id = 2,
                    TaskTitle = "Buy groceries",
                    TaskDescription = "Milk, eggs, bread",
                    IsCompleted = false,
                    TaskAssignDate = new DateTime(2025, 5, 2)
                },
                new TaskModel
                {
                    Id = 3,
                    TaskTitle = "Doctor appointment",
                    TaskDescription = "Routine check-up",
                    IsCompleted = false,
                    TaskAssignDate = new DateTime(2025, 5, 3)
                },
                new TaskModel
                {
                    Id = 4,
                    TaskTitle = "Study EF Core",
                    TaskDescription = "Go through the Microsoft EF Core documentation",
                    IsCompleted = false,
                    TaskAssignDate = new DateTime(2025, 5, 4)
                },
                new TaskModel
                {
                    Id = 5,
                    TaskTitle = "Fix bugs in project",
                    TaskDescription = "Resolve issues in the API endpoints",
                    IsCompleted = false,
                    TaskAssignDate = new DateTime(2025, 5, 4)
                }
            );

            // Configure and seed many-to-many relationship
            modelBuilder.Entity<TaskModel>()
                .HasMany(t => t.Categories)
                .WithMany(c => c.Tasks)
                .UsingEntity<Dictionary<string, object>>(
                    "TaskModelTaskCategory",
                    j => j.HasOne<TaskCategory>().WithMany().HasForeignKey("CategoriesId"),
                    j => j.HasOne<TaskModel>().WithMany().HasForeignKey("TasksId"),
                    j =>
                    {
                        j.HasKey("TasksId", "CategoriesId");

                        j.HasData(
                            new { TasksId = 1, CategoriesId = 1 }, // Finish report - Work
                            new { TasksId = 1, CategoriesId = 3 }, // Finish report - Urgent
                            new { TasksId = 2, CategoriesId = 2 }, // Buy groceries - Personal
                            new { TasksId = 3, CategoriesId = 4 }, // Doctor appointment - Health
                            new { TasksId = 4, CategoriesId = 5 }, // Study EF Core - Learning
                            new { TasksId = 5, CategoriesId = 1 }, // Fix bugs - Work
                            new { TasksId = 5, CategoriesId = 3 }  // Fix bugs - Urgent
                        );
                    }
                );
        }
    }
}
