using ManageStudent;
using ManageStudent.Helper;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace ManageStudent.Database
{
    internal class JsonStudentDatabase : IStudentDatabase
    {
        private readonly string dbname = "../../student.json";
        public JsonStudentDatabase() { }

        public List<Student> GetAll()
        {
            var text = FileHelper.ReadFile(dbname);
            if (string.IsNullOrEmpty(text))
            {
                return new List<Student>();
            }

            return JsonConvert.DeserializeObject<List<Student>>(text);
        }

        public void Save(List<Student> students)
        {
            string json = JsonConvert.SerializeObject(students);
            FileHelper.SaveFile(json, dbname);
        }
    }
}
