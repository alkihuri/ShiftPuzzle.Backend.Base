Обязательная часть:

Создание консольного приложения:

Создайте консольное приложение, которое загружает изображение (Bitmap) и применяет к нему два базовых фильтра:
Чёрно-белое изображение: Преобразовать изображение в оттенки серого, используя формулу для яркости пикселя.
Инверсия цветов: Инвертировать цвета изображения, заменив каждый цвет на его противоположность (например, белый станет чёрным).
Метод ConvertToGrayscale():

Напишите метод ConvertToGrayscale(), который будет преобразовывать изображение в оттенки серого, используя стандартную формулу для яркости пикселей.
Метод InvertColors():

Напишите метод InvertColors(), который инвертирует цвета изображения. Это можно сделать путём вычитания значений каждого пикселя из максимального значения (255 для RGB).
Сохранение результата:

После применения фильтров сохраните обработанное изображение в новый файл.
Дополнительная часть:

Параллельная обработка с помощью Parallel.For:

Реализуйте параллельную обработку строк изображения с помощью Parallel.For для ускорения выполнения фильтров. Это позволит обработать изображение быстрее.
Применение двух фильтров одновременно:

Измените алгоритм так, чтобы оба фильтра (чёрно-белое изображение и инверсия цветов) применялись одновременно в одном процессе, используя параллельные потоки.
Ввод параметров от пользователя:

Добавьте возможность для пользователя выбирать, какой фильтр применить к изображению (чёрно-белое изображение или инверсия цветов). Пусть пользователь вводит число, чтобы выбрать нужный фильтр.