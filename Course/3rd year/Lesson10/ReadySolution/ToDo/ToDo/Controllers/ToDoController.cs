using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ToDo.DAL;
using ToDo.Managers.Implemantations;
using Task = System.Threading.Tasks.Task;

namespace ToDo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ToDoController : ControllerBase
    {
        private readonly IToDoManager _toDoManager;

        public ToDoController(IToDoManager toDoManager)
        {
            _toDoManager = toDoManager;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<DAL.Task>>> GetTasks()
        {
            var tasks = await _toDoManager.GetTasksAsync();
            return Ok(tasks);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<DAL.Task>> GetTask(int id)
        {
            var task = await _toDoManager.GetTaskByIdAsync(id);

            if (task == null)
            {
                return NotFound();
            }

            return Ok(task);
        }

        [HttpPost]
        public async Task<ActionResult<DAL.Task>> PostTask(DAL.Task task)
        {
            var createdTask = await _toDoManager.CreateTaskAsync(task);
            return CreatedAtAction(nameof(GetTask), new { id = createdTask.Id }, createdTask);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutTask(int id, DAL.Task task)
        {
            if (id != task.Id)
            {
                return BadRequest();
            }

            var result = await _toDoManager.UpdateTaskAsync(task);

            if (!result)
            {
                return NotFound();
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTask(int id)
        {
            var result = await _toDoManager.DeleteTaskAsync(id);

            if (!result)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}
