using System;
using Data;


class Program
{
    static void Main(string[] args)
    {
        Character character = new Character();

        while (true)
        {
            Console.WriteLine("Выберите действие:");
            Console.WriteLine("1 - Перейти в состояние покоя");
            Console.WriteLine("2 - Перейти в состояние ходьбы");
            Console.WriteLine("3 - Перейти в состояние прыжка");
            Console.WriteLine("0 - Выход");

            int choice = int.Parse(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    character.ChangeState(CharacterState.Idle);
                    break;
                case 2:
                    character.ChangeState(CharacterState.Walking);
                    break;
                case 3:
                    character.ChangeState(CharacterState.Jumping);
                    break;
                case 0:
                    return;
                default:
                    Console.WriteLine("Некорректный выбор.");
                    break;
            }

            character.Update();
        }
    }
}