using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ToDo.Controllers;
using ToDo.DAL;
using ToDo.Managers.Interfaces;
using Task = System.Threading.Tasks.Task;

namespace ToDo.Tests;

public class ToDoControllerTests
{
    private DataContext GetDbContext()
    {
        var options = new DbContextOptionsBuilder<DataContext>()
            .UseSqlite("Data Source=Post.db")
            .Options;

        return new DataContext(options);
    }
    
    [Fact]
    public async Task CreateTaskAsync_CreatesNewTask()
    {
        // Arrange
        using var context = GetDbContext();
        var manager = new ToDoManager(context);

        // Act
        var task = new DAL.Task { Title = "New Task", Description = "Test Task" };
        var createdTask = await manager.CreateTaskAsync(task);

        // Assert
        Assert.NotNull(createdTask);
        Assert.Equal("New Task", createdTask.Title);
        Assert.Equal(1, context.Tasks.Count());
    }
}