using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ToDoList.Models;
using ToDoList.Repositories;

namespace ToDoList.Controllers;

/// <summary>
/// Контроллер задач
/// </summary>
/// <param name="todoRepository"></param>
[Route("api/[controller]")]
[ApiController]
public class TodoController(ITodoRepository todoRepository) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var tasks = await todoRepository.GetAllAsync();

        return Ok(tasks);
    }

    [HttpPost]
    public async Task<IActionResult> Create(TodoItem todoItem)
    {
        await todoRepository.AddAsync(todoItem);
        return Ok();
    }
    
    [HttpPost]
    public async Task<IActionResult> Update(TodoItem todoItem)
    {
        var todoItemCurrent = await todoRepository.GetByIdAsync(todoItem.Id);
        if (todoItemCurrent == null)
        {
            return NotFound();
        }
        
        await todoRepository.UpdateAsync(todoItem);

        return Ok();
    }

    [HttpDelete]
    public async Task<IActionResult> Delete(int id)
    {
        await todoRepository.DeleteAsync(id);

        return Ok();
    }
}