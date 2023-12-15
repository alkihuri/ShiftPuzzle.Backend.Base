
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

public class Person
{
    public string Name { get; set; }
    public int Age { get; set; }

    public Person(string name, int age)
    {
        Name = name;
        SetAge(age);
    }

    public void Introduce()
    {
        Console.WriteLine("Hello, my name is " + Name);
    }

    public void SetAge(int newAge)
    {
        if (newAge >= 0)
        {
            Age = newAge;
        }
        else
        {
            Console.WriteLine("Age cannot be negative.");
        }
    }

    public override string ToString()
    {
        return $"{Name},{Age}";
    }

    public static Person FromString(string data)
    {
        var parts = data.Split(',');
        return new Person(parts[0], int.Parse(parts[1]));
    }
}

public class Employee : Person
{
    public string Position { get; set; }

    public Employee(string name, int age, string position) : base(name, age)
    {
        Position = position;
    }

    public override string ToString()
    {
        return $"{base.ToString()},{Position}";
    }

    public static new Employee FromString(string data)
    {
        var parts = data.Split(',');
        return new Employee(parts[0], int.Parse(parts[1]), parts[2]);
    }
}

public class PersonFileService
{
    private const string FilePath = "people.txt";

    public static void WritePeopleToFile(List<Person> people)
    {
        var lines = people.Select(p => p.ToString()).ToList();  
        File.WriteAllLines(FilePath, lines);
    }

    public static List<Person> ReadPeopleFromFile()
    {
        var lines = File.ReadAllLines(FilePath);
        var people = new List<Person>();
        foreach (var line in lines)
        {
            var parts = line.Split(',');
            if (parts.Length == 3) // Assuming it's an Employee
            {
                people.Add(Employee.FromString(line));
            }
            else
            {
                people.Add(Person.FromString(line));
            }
        }
        return people;
    }
}

public class Program
{
    public static void Main()
    {
        var people = new List<Person>
        {
            new Person("Alice", 28),
            new Person("Bob", 35),
            new Employee("Charlie", 42, "Manager")
        };

        PersonFileService.WritePeopleToFile(people);

        var peopleFromFile = PersonFileService.ReadPeopleFromFile();
        foreach (var person in peopleFromFile)
        {
            person.Introduce();
        }
    }
}
