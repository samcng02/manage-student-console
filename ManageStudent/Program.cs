using ManageStudent.Database;
using System;

namespace ManageStudent
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //load list student from file
            var manager = new ManageStudent(new JsonStudentDatabase());
            manager.FindAll();

            //menu
            Console.WriteLine("Quan li sinh vien");
            Console.WriteLine("A: Them");
            Console.WriteLine("B: Sua");
            Console.WriteLine("C: Xoa");
            Console.WriteLine("D: Tim");
            Console.WriteLine("E: Tim tat ca");
            Console.WriteLine("F: Xoa tat ca");
            Console.WriteLine("esc: exit");

            while (true)
            {
                Console.WriteLine("press to continue...");
                var key = Console.ReadKey();
                Console.WriteLine();

                switch (key.Key)
                {
                    case ConsoleKey.A:
                        manager.AddStudent();
                        break;
                    case ConsoleKey.B:
                        manager.EditStudent();
                        break;
                    case ConsoleKey.C:
                        manager.DeleteStudent();
                        break;
                    case ConsoleKey.D:
                        manager.FindStudentById();
                        break;
                    case ConsoleKey.E:
                        manager.FindAll();
                        break;
                    case ConsoleKey.F:
                        manager.DeleteAll();
                        break;
                    case ConsoleKey.Escape:
                        break;
                }
            }
            
        }

        
    }
}
