using System;

namespace prj1.Model
{
    public class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public double GPA { get; set; }

        public Student(int id, string name, int age, double gpa)
        {
            Id = id;
            Name = name;
            Age = age;
            GPA = gpa;
        }

        public void DisplayStudentInfo()
        {
            Console.WriteLine(
                $"ID: {Id}, Name: {Name}, Age: {Age}, GPA: {GPA:F2}"
            );
        }
    }
}