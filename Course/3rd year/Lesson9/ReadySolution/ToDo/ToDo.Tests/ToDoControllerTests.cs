using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ToDo.Controllers;
using ToDo.DAL;
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
    public async Task GetTasks_ReturnsTasks()
    {
        // Arrange
        using var context = GetDbContext();
        context.Tasks.Add(new DAL.Task { Title = "Test Task 1", Description = "Description 1" });
        context.Tasks.Add(new DAL.Task { Title = "Test Task 2", Description = "Description 2" });
        await context.SaveChangesAsync();

        var controller = new ToDoController(context);

        // Act
        var result = await controller.GetTasks();

        // Assert
        var actionResult = Assert.IsType<ActionResult<IEnumerable<DAL.Task>>>(result);
        var returnValue = Assert.IsType<OkObjectResult>(actionResult.Result);
        var tasks = Assert.IsAssignableFrom<IEnumerable<DAL.Task>>(returnValue.Value);
        Assert.Equal(2, tasks.Count());
    }
}