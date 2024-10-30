using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PizzaHub.Core.DB_Context;
using PizzaHub.Repository.Implementation;
using PizzaHub.Repository.Interface;
using PizzaHub.Services.Implementation;
using PizzaHub.Services.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaHub.Services
{
    public static class ConfigureService
    {
        public static void RegisterService(IServiceCollection _service, IConfiguration _config)
        {
            _service.AddDbContext<PizzaHubContext>(options =>
            {
                options.UseSqlServer(_config.GetConnectionString("DbConnection"));
            });

            
            _service.AddScoped<DbContext, PizzaHubContext>();

            //Repository
            _service.AddScoped<IProductRepo, ProdcutRepo>();
            _service.AddScoped<ICartRepo, CartRepo>();

            //Service
            _service.AddScoped<IProductService, ProductService>();
            _service.AddScoped<ICartService, CartService>();
        }
    }
}
