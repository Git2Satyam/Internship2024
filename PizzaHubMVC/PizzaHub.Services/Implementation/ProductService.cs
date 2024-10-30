using PizzaHub.Models;
using PizzaHub.Repository.Interface;
using PizzaHub.Services.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaHub.Services.Implementation
{
    public class ProductService : IProductService
    {
        private readonly IProductRepo _productRepo;
        public ProductService(IProductRepo repo)
        {
            _productRepo = repo;   
        }
        public IEnumerable<ProductModel> GetAllProducts()
        {
           return _productRepo.GetAllProducts();    
        }
    }
}
