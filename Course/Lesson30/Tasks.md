---
# Практика А:

1. Переименовать TaskContext в TaskTrackerContext.
2. Расширить описание класса "Задача":
    - ИД (уже есть)
    - ИМЯ
    - ОПИСАНИЕ
    - ЗАВЕРШЕНО/НЕ ЗАВЕРШЕНО
    - ДАТА ЗАВЕРШЕНИЯ
    - ЗАКРЕПЛЕННЫЙ ПОЛЬЗОВАТЕЛЬ
3. Создать класс пользователя:
    - ИД
    - ИМЯ
    - ПОЧТА
    - ПАРОЛЬ
    - ВСЕ ПРИКРЕПЛЕННЫЕ ЗАДАЧИ

--- 
# Практика B:

1. Настройка СУБД. Настроить связи:
   - 1 пользователь = Много задач
   - 1 Задача = 1 пользователь (по ключу ЗАКРЕПЛЕННЫЙ ПОЛЬЗОВАТЕЛЬ)

2. Запустить фронтенд (wwwroot => index.html) localhost:port/index.html
   Протестировать добавление и удаление. (Ничего больше не нужно)

--- 
# Практика C:

1. Создать описание изменения состояния. 

> ПОДСКАЗКА:

Нужно создать метод обработки в TaskRepository, где изменяется состояние свойства IsComplete. 

---
