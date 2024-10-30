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
                var list = _context.StudentTables.Where(c => c.IsDeleted == false).Select(x => new StudentModel
                {
                    Id = x.Id,
                    Name = x.Name,
                    RollNumber = x.RollNumber,
                    Address = x.Address,
                    Email = x.Email,
                }).ToList();
                return list;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public int SaveStudentData(StudentModel student)
        {
            int result;
            try
            {
                var addStudent = new StudentTable
                {
                    Id = student.Id,
                    Name = student.Name,
                    Email = student.Email,
                    Address = student.Address,
                    RollNumber= student.RollNumber,
                };
                _context.StudentTables.Add(addStudent);
                _context.SaveChanges();
                result = 1;
                return result;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public StudentModel EditStudent(int id)
        {
            bool flag = false;
            var model = new StudentModel();
            try
            {
                var exist = _context.StudentTables.Find(id);
                if(exist != null)
                {
                    model.Id = exist.Id;
                    model.Name = exist.Name;
                    model.Email = exist.Email;
                    model.Address = exist.Address;
                    model.RollNumber = exist.RollNumber;
                }
                return model;
            }
            catch(Exception ex)
            {
                throw;
            }
        }

        public int EditStudent(StudentModel model)
        {
            int result = 0;
            try
            {
                var exist = _context.StudentTables.FirstOrDefault(c =>  c.Id == model.Id);
                if(exist != null)
                {
                    exist.Name = model.Name;
                    exist.Email = model.Email;
                    exist.Address = model.Address;
                    exist.RollNumber = model.RollNumber;

                    _context.StudentTables.Update(exist);
                    _context.SaveChanges();
                    result = 1;
                }
                return result;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public bool DeleteStudent(int id)
        {
            bool flag = false;
            try
            {
                var data = _context.StudentTables.Find(id);
                if(data != null)
                {
                    data.IsDeleted = true;
                    _context.Entry(data).State = EntityState.Modified;
                    _context.SaveChanges();
                    flag = true;
                }
                return flag;
            }
            catch(Exception ex)
            {
                throw;
            }
        }
    }
}
