namespace Practices;

public class TaskManager
{
    private List<Task> tasks = new List<Task>();

    public void AddTask(Task task)
    {
        tasks.Add(task);
    }
    
    public void ShowTasks()
    {
        foreach (var task in tasks)
        {
            Console.WriteLine($"ID: {task.Id}, Title: {task.Title}, Body: {task.Body} Due Date: {task.DueDate.ToShortDateString()}, Priority: {task.Priority}, Status: {task.Status}");
        }
    }

    public List<Task> FilterByStatus(Status status)
    {
        return tasks.Where(t => t.Status == status).ToList();
    }

    public List<Task> FilterByPriority(Priority priority)
    {
        return tasks.Where(t => t.Priority == priority).ToList();
    }

    public List<Task> FilterByDueDate(DateTime dueDate)
    {
        return tasks.Where(t => t.DueDate.Date == dueDate.Date).ToList();
    }

    public List<Task> SortByDueDate()
    {
        return tasks.OrderBy(t => t.DueDate).ToList();
    }

    public List<Task> SortByPriority()
    {
        return tasks.OrderBy(t => t.Priority).ToList();
    }

    public List<Task> SortByStatus()
    {
        return tasks.OrderBy(t => t.Status).ToList();
    }

    public List<Task> SearchTaskByPriorityAndDueDate(Priority priority, DateTime dueDate)
    {
        return tasks.Where(t => t.Priority == priority).Max(t => t.DueDate)
    }

}