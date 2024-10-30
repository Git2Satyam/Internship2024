using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using StudentForm.Core.Entities;
using StudentForm.Repository.Implementation;
using StudentForm.Repository.Interface;
using StudentForm.Services.Implementation;
using StudentForm.Services.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace StudentForm.Services
{
    public static class ConfigureService
    {
        public static void RegisterService(IServiceCollection _service, IConfiguration _config)
        {
            _service.AddDbContext<StudentDBContext>(options =>
            {
                options.UseSqlServer(_config.GetConnectionString("DbConnection"));
            });

            // context
            _service.AddScoped<DbContext, StudentDBContext>();

            // Repository
            _service.AddScoped<IStudentRepo, StudentRepo>();

            //Services
            _service.AddScoped<IStudentService, StudentService>();
        }
    }
}
