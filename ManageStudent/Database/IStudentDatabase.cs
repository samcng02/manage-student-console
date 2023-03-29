using ManageStudent;
using ManageStudent.Helper;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace ManageStudent.Database
{
    public interface IStudentDatabase
    {
        List<Student> GetAll();
        void Save(List<Student> student);
    }
}
