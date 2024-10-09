using StudentForm.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentForm.Services.Interface
{
    public interface IStudentService
    {
        IEnumerable<StudentModel> GetAllStudent();
    }
}
