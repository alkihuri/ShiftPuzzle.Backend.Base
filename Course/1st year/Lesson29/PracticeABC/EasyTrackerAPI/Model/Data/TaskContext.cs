using Microsoft.EntityFrameworkCore;

public class TaskContext : DbContext
{
 
    public TaskContext(DbContextOptions<TaskContext> options) : base(options)
    {
    }

    public DbSet<TrackerTask> TrackerTasks { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<TrackerTask>().HasKey(t => t.ID);   
    }
}