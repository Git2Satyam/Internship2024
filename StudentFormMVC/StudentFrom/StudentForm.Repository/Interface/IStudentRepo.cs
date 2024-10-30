using StudentForm.Core.Entities;
using StudentForm.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentForm.Repository.Interface
{
    public interface IStudentRepo
    {
        IEnumerable<StudentModel> GetAllStudent();

        int SaveStudentData(StudentModel student);

        StudentModel EditStudent(int id);

        int EditStudent(StudentModel model);
        bool DeleteStudent(int id);
    }
}
