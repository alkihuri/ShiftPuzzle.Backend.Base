

---
# Практика А:

1.  CОЗДАТЬ КОНТРОЛЛЕР ДЛЯ ЗАДАЧ, КОТОРЫЙ ДОЛЖЕН: 

    - Получить все таски        [HttpGet("/api/tasks/getall")]
    - Получить таск по ID       [HttpGet("/api/tasks/get/{id}")]
    - Создать таск              [HttpPost("/api/tasks/add")]
    - Удалить таск по ID        [HttpGet("/api/tasks/delete/{id}")]

 
--- 
# Практика B: 

1.  Cоздать Get запрос для генерации  случайных записей в  БД     
                                [HttpGet("/api/tasks/addrandom/{id}")]

Подсказка: 

```C#
var newTask = new TrackerTask();
            var randomName = "Task #" + (lastTaskID + x).ToString();
            newTask.ID = lastTaskID + x;       
            newTask.Name = randomName;  
            newTask.Description = "This is a random task";   
            _taskManager.AddTask(newTask); 
```

--- 
# Практика C:

1.  Cоздать Reame.md файл с описанием каждого метода АПИ. 