using Microsoft.EntityFrameworkCore;

public class TaskTrackerContext : DbContext
{
 
    public TaskTrackerContext(DbContextOptions<TaskTrackerContext> options) : base(options)
    {
    }

    public DbSet<TrackerTask> TrackerTasks { get; set; }
    public DbSet<User> Users { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<TrackerTask>().HasKey(t => t.ID);  
        
        
       modelBuilder.Entity<User>()
            .HasMany(u => u.Tasks)
            .WithOne(t => t.AssignedUser)
            .HasForeignKey(t => t.ID);

    }
   
}