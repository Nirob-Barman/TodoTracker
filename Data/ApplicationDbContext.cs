using Microsoft.EntityFrameworkCore;
using TodoTracker.Models;

namespace TodoTracker.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options) { }

        public DbSet<TaskModel> Tasks { get; set; }
        public DbSet<TaskCategory> Categories { get; set; }
    }
}
