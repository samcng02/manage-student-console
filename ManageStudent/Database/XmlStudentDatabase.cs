using ManageStudent;
using ManageStudent.Helper;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace ManageStudent.Database
{
    public class XmlStudentDatabase : IStudentDatabase
    {
        private readonly string dbname = "../../student.xml";
        public XmlStudentDatabase() { }

        public List<Student> GetAll()
        {
            var text = FileHelper.ReadFile(dbname);
            if (string.IsNullOrEmpty(text))
            {
                return new List<Student>();
            }
            return XmlHelper.Deserialize<List<Student>>(text);
        }

        public void Save(List<Student> students)
        {
            string xml = XmlHelper.Serialize(students);
            FileHelper.SaveFile(xml, dbname);
        }
    }
}
