namespace ToDo.Managers.Implemantations;

public interface IToDoManager
{
    public Task<IEnumerable<DAL.Task>> GetTasksAsync();
    public Task<DAL.Task> GetTaskByIdAsync(int id);
    public Task<DAL.Task> CreateTaskAsync(DAL.Task task);
    public Task<bool> UpdateTaskAsync(DAL.Task task);
    public Task<bool> DeleteTaskAsync(int id);
}