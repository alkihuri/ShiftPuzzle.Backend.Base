**Практика А**

1. Создайте абстрактный класс Expression, содержащий абстрактный метод Evaluate, который принимает словарь переменных.
2. Создайте класс Constant, наследующий от Expression, который содержит одно поле Value типа double. Реализуйте метод Evaluate, чтобы он возвращал значение этого поля.
3. Создайте класс Variable, наследующий от Expression, который содержит одно поле Name типа string. Реализуйте метод Evaluate, чтобы он возвращал значение переменной из переданного словаря.

Пример кода для проверки:

`
class Program
{
    static void Main(string[] args)
    {
        Expression constant = new Constant(5);
        Expression variable = new Variable("x");

        var variables = new Dictionary<string, double>
        {
            { "x", 10 }
        };

        Console.WriteLine(constant.Evaluate(variables)); // Output: 5
        Console.WriteLine(variable.Evaluate(variables)); // Output: 10
    }
}
`

**Практика B**

1. Создайте абстрактный класс BinaryOperation, наследующий от Expression. Он должен содержать два поля Left и Right типа Expression.
2. Создайте классы Addition, Subtraction, Multiplication, Division, наследующие от BinaryOperation. Реализуйте метод Evaluate для каждого класса, чтобы он выполнял соответствующую математическую операцию.

Пример кода для проверки:

`
class Program
{
    static void Main(string[] args)
    {
        Expression addition = new Addition(new Constant(5), new Variable("x"));
        Expression multiplication = new Multiplication(new Constant(2), new Variable("y"));

        var variables = new Dictionary<string, double>
        {
            { "x", 10 },
            { "y", 3 }
        };

        Console.WriteLine(addition.Evaluate(variables)); // Output: 15
        Console.WriteLine(multiplication.Evaluate(variables)); // Output: 6
    }
}
`

**Практика С**

1. Создайте сложное выражение, например: (x + 2) * (y - 3).
2. Реализуйте в классе Division проверку на деление на ноль. Если делитель равен нулю, выбрасывайте исключение DivideByZeroException.
3. Напишите программу, которая создаст несколько сложных выражений и вычислит их, выводя результаты на экран.