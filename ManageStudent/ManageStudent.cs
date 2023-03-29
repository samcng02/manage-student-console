using System;
using System.Collections.Generic;
using System.Linq;
using ManageStudent.Helper;
using ManageStudent.Database;

namespace ManageStudent
{
    public class ManageStudent
    {
        private readonly IStudentDatabase _db;

        private List<Student> Students = new List<Student>();

        public ManageStudent() { }

        public ManageStudent(IStudentDatabase database)
        {
            _db = database;

            //init data
            LoadData();
        }

        public void AddStudent()
        {
            int id = IOHelper.InputNumber("Mssv");

            Console.Write("Nhap ten sinh vien: ");
            var name = Console.ReadLine();

            int age = IOHelper.InputNumber("Tuoi");

            var student = new Student(id, name, age);
            Students.Add(student);

            Save();
            Console.WriteLine("Them sinh vien thanh cong");
        }

        public void EditStudent()
        {
            int id = IOHelper.InputNumber("Mssv");

            //find
            var student = Students.FirstOrDefault(x => x.Id == id);
            if (student == null)
            {
                Console.WriteLine("Khong tim thay sinh vien");
            }
            else
            {
                Console.Write("Nhap ten sinh vien: ");
                var name = Console.ReadLine();

                int age = IOHelper.InputNumber("Tuoi");

                student.Name = name;
                student.Age = age;

                Save();
                Console.WriteLine("Sua sinh vien thanh cong");
            }
        }

        public void DeleteStudent()
        {
            int id = IOHelper.InputNumber("Mssv");

            //find
            var student = Students.FirstOrDefault(x => x.Id == id);
            if (student == null)
            {
                Console.WriteLine("Not found");
            }
            else
            {
                Students = Students.Where(s => s.Id != id)?.ToList();
                Save();
                Console.WriteLine("Da xoa sinh vien nay");
            }
        }

        public void FindStudentById()
        {
            int id = IOHelper.InputNumber("Mssv");

            //find
            var student = Students.FirstOrDefault(x => x.Id == id);
            if (student == null)
            {
                Console.WriteLine("Not found");
            }
            else
            {
                student.Print();
            }
        }

        public void FindAll()
        {
            if (Students.Count == 0)
            {
                Console.WriteLine("Chua co sinh vien nao");
            }
            else
            {
                Console.WriteLine("Danh sach sinh vien");
                foreach (var student in Students)
                {
                    student.Print();
                }
            }
        }

        public void DeleteAll()
        {
            Students.Clear();
            Save();
            Console.WriteLine("Da xoa tat ca sinh vien");
        }

        private void LoadData()
        {
            Students = _db.GetAll();
        }

        private void Save()
        {
            _db.Save(Students);
        }
    }
}
