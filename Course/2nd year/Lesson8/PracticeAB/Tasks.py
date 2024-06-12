# Практика А
#  Задача 1: Функция сложения
def add(a, b):
    return a + b

# Задача 2: Функция проверки четности
def is_even(number):
    return number % 2 == 0

# Задача 3: Функция переворота строки
# Подсказка: не усложняйте алгоритм
# char[] charArray = s.ToCharArray();
# string reversed = new string(Array.Reverse(charArray));
def reverse_string(s):
    return s[::-1]

# Задача 4: Функция поиска максимального элемента в массиве
# Подсказка : в С# можно получить максимальное значение так : array.Max();
def find_max(arr):
    return max(arr)

# Задача 5: Функция вычисления зарплаты за год
def factorial(sallary):
    return sallary * 12



# ПРАКТИКА В
# Задача 6*: Функция конвертации температур
def celsius_to_fahrenheit(celsius):
    return celsius * 9/5 + 32


# Задача 7*: Функция поиска количества гласных в строке
# Подсказа: используйте цикл foreach foreach (char c in s) где s строка для проверки а c  каждый ее символ
# аналог in  в c# - vowels.Contains(c) где символ строки
def count_vowels(s):
    vowels = "аиоуеэАИОУЕЭ"
    return sum(1 for char in s if char in vowels)

# Задача 8*: Функция для опредления сложности взлома 4х значного пароля пароля
 
def generate_password(passtohack):
    count = 0 
    for x in range(10):
        for y in range(10):
            for z in range(10):
                for h in range(10):
                    count += 1 
                    generatedpass = str(x) + str(y) + str(z) + str(h)
                    if generatedpass  == passtohack:
                        print("Ура! Вы взломали пароль теперь вы хакер")
                        return count
