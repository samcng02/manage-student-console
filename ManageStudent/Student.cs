using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManageStudent
{
    public class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }

        public Student()
        {
        }

        public Student(int id, string name, int age)
        {
            Id = id;
            Name = name;
            Age = age;
        }

        public void Print()
        {
            Console.WriteLine($"id: {this.Id}");
            Console.WriteLine($"Ho ten: {this.Name}");
            Console.WriteLine($"Tuoi: {this.Age}");
            Console.WriteLine();
        }
    }
}
