namespace PracticeC;

// Класс "Игра" (Game)
public class Game
{
    private Hero hero;
    private List<Monster> monsters;
    private List<Item> inventory;

    public Game()
    {
        hero = new Hero("Knight", 100, 20);
        monsters = new List<Monster>
        {
            new Monster("Goblin", 30, 5),
            new Monster("Orc", 50, 10)
        };
        inventory = new List<Item>
        {
            new HealingPotion("Small Healing Potion", "Heals 20 health points", 20)
        };
    }

    public void Play()
    {
        Console.WriteLine("Welcome to the RPG Game!");
        Console.WriteLine($"{hero.Name} starts the journey with {hero.Health} health and {hero.AttackPower} attack power.");

        foreach (var monster in monsters)
        {
            Console.WriteLine($"\nA wild {monster.Name} appears!");

            while (monster.Health > 0 && hero.Health > 0)
            {
                hero.Attack(monster);
                if (monster.Health > 0)
                {
                    monster.Attack(hero);
                }
            }

            if (hero.Health > 0)
            {
                Console.WriteLine($"{hero.Name} defeated the {monster.Name}!");
            }
            else
            {
                Console.WriteLine($"{hero.Name} was defeated by the {monster.Name}...");
                return;
            }
        }

        Console.WriteLine($"\n{hero.Name} has defeated all the monsters!");

        foreach (var item in inventory)
        {
            item.Use(hero);
        }

        Console.WriteLine($"{hero.Name} has {hero.Health} health remaining after using items.");
    }
}