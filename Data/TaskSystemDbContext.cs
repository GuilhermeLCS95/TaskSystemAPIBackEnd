using Microsoft.EntityFrameworkCore;
using TaskSystemAPIBackEnd.Data.Map;
using TaskSystemAPIBackEnd.Models;

namespace TaskSystemAPIBackEnd.Data
{
    public class TaskSystemDbContext : DbContext
    {
        public TaskSystemDbContext(DbContextOptions<TaskSystemDbContext> options)
            :base(options) 
        {
            
        }

        public DbSet<UserModel> Users { get; set; }
        public DbSet<TaskModel> Tasks { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UserMap());
            modelBuilder.ApplyConfiguration(new TaskMap());
            base.OnModelCreating(modelBuilder);
        }
    }
}
