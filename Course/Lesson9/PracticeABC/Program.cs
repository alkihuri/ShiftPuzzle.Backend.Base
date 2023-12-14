using System;
using System.Collections.Generic;

namespace SimpleBD
{     
    class Student
    {
        public string Name { get; set; }
        public Dictionary<string, int> Grades { get; set; }
        public List<string> Attendance { get; set; }

        public Student(string name)
        {
            Name = name;
            Grades = new Dictionary<string, int>();
            Attendance = new List<string>();
        }

        public void AddGrade(string subject, int grade)
        {
            Grades[subject] = grade;
        }

        public void AddAttendance(string date)
        {
            Attendance.Add(date);
        }
    }

    class SimpleDB
    {
        private Dictionary<string, Student> students = new Dictionary<string, Student>();

        public void AddStudent(Student student)
        {
            students[student.Name] = student;
        }

        public void RemoveStudent(string name)
        {
            students.Remove(name);
        }

        public void ShowStudentInfo(string name)
        {
            if (students.ContainsKey(name))
            {
                var student = students[name];
                Console.WriteLine($"Name: {student.Name}");
                Console.WriteLine("Grades:");
                foreach (var grade in student.Grades)
                {
                    Console.WriteLine($"{grade.Key}: {grade.Value}");
                }
                Console.WriteLine("Attendance:");
                foreach (var date in student.Attendance)
                {
                    Console.WriteLine(date);
                }
            }
            else
            {
                Console.WriteLine("Student not found.");
            }
        }
    }

    class Program
    {
        static void Main()
        {
            Console.WriteLine("Hello world!")
        }
    }
}