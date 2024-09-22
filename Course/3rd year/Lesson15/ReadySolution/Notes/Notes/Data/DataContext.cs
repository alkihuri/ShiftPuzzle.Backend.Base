using Microsoft.EntityFrameworkCore;
using Notes.Models;

namespace Notes.Data;

public class DataContext(DbContextOptions<DataContext> options) : DbContext(options)
{
    public DbSet<Note> Notes { get; set; }
}