using ManageStudent;
using ManageStudent.Helper;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace ManageStudent.Database
{
    public class CsvStudentDatabase : IStudentDatabase
    {
        private readonly string dbname = "../../student.csv";
        public CsvStudentDatabase() { }

        public List<Student> GetAll()
        {
            var lines = FileHelper.ReadFileReturnArrayString(dbname);
            var students = new List<Student>();
            if (lines == null)
                return students;

            foreach (var item in lines)
            {
                var student = ParseDataStudent(item);
                students.Add(student);
            }

            return students;
        }

        public void Save(List<Student> students)
        {
            string xml = XmlHelper.Serialize(students);
            FileHelper.SaveFile(xml, dbname);
        }

        private Student ParseDataStudent(string lineData)
        {
            //todo check valid data
            //format: "1,sang,22"
            var data = lineData.Split(',');

            var id = Int32.Parse(data[0]);
            var name = data[1];
            var age = Int32.Parse(data[2]);

            return new Student(id, name, age);
        }
    }
}
