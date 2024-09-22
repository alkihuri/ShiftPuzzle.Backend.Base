using Microsoft.EntityFrameworkCore;
using ToDo.DAL;
using ToDo.Managers.Implemantations;
using Task = System.Threading.Tasks.Task;

namespace ToDo.Managers.Interfaces;

public class ToDoManager : IToDoManager
{
    private readonly DataContext _context;

    public ToDoManager(DataContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<DAL.Task>> GetTasksAsync()
    {
        return await _context.Tasks.ToListAsync();
    }

    public async Task<DAL.Task> GetTaskByIdAsync(int id)
    {
        return await _context.Tasks.FindAsync(id);
    }

    public async Task<DAL.Task> CreateTaskAsync(DAL.Task task)
    {
        _context.Tasks.Add(task);
        await _context.SaveChangesAsync();
        return task;
    }

    public async Task<bool> UpdateTaskAsync(DAL.Task task)
    {
        _context.Entry(task).State = EntityState.Modified;
        try
        {
            await _context.SaveChangesAsync();
            return true;
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!await TaskExistsAsync(task.Id))
            {
                return false;
            }
            else
            {
                throw;
            }
        }
    }

    public async Task<bool> DeleteTaskAsync(int id)
    {
        var task = await _context.Tasks.FindAsync(id);
        if (task == null)
        {
            return false;
        }

        _context.Tasks.Remove(task);
        await _context.SaveChangesAsync();
        return true;
    }

    private async Task<bool> TaskExistsAsync(int id)
    {
        return await _context.Tasks.AnyAsync(e => e.Id == id);
    }
}