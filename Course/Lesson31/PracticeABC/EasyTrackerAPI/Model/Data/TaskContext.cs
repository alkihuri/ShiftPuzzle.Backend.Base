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
        modelBuilder.Entity<User>().HasKey(u => u.ID);     
        
        
        modelBuilder.Entity<TrackerTask>() // Определяем отношение 1 к 1 между задачей и пользователем
        .HasOne(t => t.AssignedUser)  // Указываем свойство навигации
        .WithMany(u => u.Tasks); // Указываем свойство навигации второго класса
    }
   
}