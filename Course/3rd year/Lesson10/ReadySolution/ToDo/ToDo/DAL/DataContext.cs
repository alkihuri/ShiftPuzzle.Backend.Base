using Microsoft.EntityFrameworkCore;

namespace ToDo.DAL;

public class DataContext : DbContext
{
    public DataContext(DbContextOptions<DataContext> options) : base(options) { }

    public DbSet<Task> Tasks { get; set; }
}