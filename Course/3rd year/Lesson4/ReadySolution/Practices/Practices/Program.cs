namespace Practices;

class Program
    {
        static void Main(string[] args)
        {
            TaskManager taskManager = new TaskManager();

            taskManager.AddTask(new Task { Id = 1, Title = "Задача 1", DueDate = DateTime.Now.AddDays(1), Priority = Priority.High, Status = Status.InProgress });
            taskManager.AddTask(new Task { Id = 2, Title = "Задача 2", DueDate = DateTime.Now.AddDays(3), Priority = Priority.Low, Status = Status.Pending });
            taskManager.AddTask(new Task { Id = 3, Title = "Задача 3", DueDate = DateTime.Now.AddDays(-1), Priority = Priority.Medium, Status = Status.Completed });
            taskManager.AddTask(new Task { Id = 4, Title = "Задача 4", DueDate = DateTime.Now.AddDays(2), Priority = Priority.High, Status = Status.Pending });
            taskManager.AddTask(new Task { Id = 5, Title = "Задача 5", DueDate = DateTime.Now.AddDays(5), Priority = Priority.Medium, Status = Status.InProgress });

            while (true)
            {
                Console.WriteLine("1. Показать все задачи");
                Console.WriteLine("2. Фильтровать задачи");
                Console.WriteLine("3. Сортировать задачи");
                Console.WriteLine("4. Выйти");
                Console.Write("Выберите опцию: ");
                int option = int.Parse(Console.ReadLine());

                if (option == 4) break;

                switch (option)
                {
                    case 1:
                        taskManager.ShowTasks();
                        break;
                    case 2:
                        FilterTasks(taskManager);
                        break;
                    case 3:
                        SortTasks(taskManager);
                        break;
                    default:
                        Console.WriteLine("Неверная опция");
                        break;
                }

                Console.WriteLine();
            }
        }

        static void FilterTasks(TaskManager taskManager)
        {
            Console.WriteLine("1. По статусу");
            Console.WriteLine("2. По приоритету");
            Console.WriteLine("3. По дате завершения");
            Console.Write("Выберите опцию для фильтрации: ");
            int option = int.Parse(Console.ReadLine());

            List<Task> filteredTasks = null;

            switch (option)
            {
                case 1:
                    Console.WriteLine("Введите статус (Pending, InProgress, Completed): ");
                    string status = Console.ReadLine();
                    filteredTasks = taskManager.FilterByStatus(Enum.Parse<Status>(status));
                    break;
                case 2:
                    Console.WriteLine("Введите приоритет (Low, Medium, High): ");
                    string priority = Console.ReadLine();
                    filteredTasks = taskManager.FilterByPriority(Enum.Parse<Priority>(priority));
                    break;
                case 3:
                    Console.WriteLine("Введите дату (yyyy-mm-dd): ");
                    DateTime dueDate = DateTime.Parse(Console.ReadLine());
                    filteredTasks = taskManager.FilterByDueDate(dueDate);
                    break;
                default:
                    Console.WriteLine("Неверная опция");
                    break;
            }

            if (filteredTasks != null)
            {
                taskManager.ShowTasks(filteredTasks);
            }
        }

        static void SortTasks(TaskManager taskManager)
        {
            Console.WriteLine("1. По дате завершения");
            Console.WriteLine("2. По приоритету");
            Console.WriteLine("3. По статусу");
            Console.Write("Выберите опцию для сортировки: ");
            int option = int.Parse(Console.ReadLine());

            List<Task> sortedTasks = null;

            switch (option)
            {
                case 1:
                    sortedTasks = taskManager.SortByDueDate();
                    break;
                case 2:
                    sortedTasks = taskManager.SortByPriority();
                    break;
                case 3:
                    sortedTasks = taskManager.SortByStatus();
                    break;
                default:
                    Console.WriteLine("Неверная опция");
                    break;
            }

            if (sortedTasks != null)
            {
                taskManager.ShowTasks(sortedTasks);
            }
        }
    }

