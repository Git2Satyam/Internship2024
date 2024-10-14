using StudentForm.Models;
using StudentForm.Repository.Interface;
using StudentForm.Services.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentForm.Services.Implementation
{
    public class StudentService : IStudentService
    {
        private readonly IStudentRepo  _studentRepo;
        public StudentService(IStudentRepo studentRepo)
        {
            _studentRepo = studentRepo;
        }

        public bool EditStudent(StudentModel model)
        {
            try
            {
                return _studentRepo.EditStudent(model); 
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public IEnumerable<StudentModel> GetAllStudent()
        {
            try
            {
                return _studentRepo.GetAllStudent();
               
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public int SaveStudentData(StudentModel model)
        {
            try
            {
                return _studentRepo.SaveStudentData(model);
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
    }
}
