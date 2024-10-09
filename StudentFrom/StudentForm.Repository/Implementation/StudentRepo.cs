using Microsoft.EntityFrameworkCore;
using StudentForm.Core.Entities;
using StudentForm.Models;
using StudentForm.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentForm.Repository.Implementation
{
    public class StudentRepo: Repository<StudentTable>, IStudentRepo
    {
        StudentDBContext _context
        {
            get
            {
                return _db as StudentDBContext;
            }
        }

        public StudentRepo(DbContext DB): base(DB)
        {
        }

        public IEnumerable<StudentModel> GetAllStudent()
        {
            try
            {
                var list = _context.StudentTables.Select(x => new StudentModel
                {
                    Id = x.Id,
                    Name = x.Name,
                    RollNumber = x.RollNumber,
                    Address = x.Address,
                    Email = x.Email,
                });
                return list;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
    }
}
