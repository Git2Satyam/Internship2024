using PizzaHub.Core.DB_Context;
using PizzaHub.Models;
using PizzaHub.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaHub.Repository.Implementation
{
    public class ProdcutRepo : IProductRepo
    {
        private readonly PizzaHubContext _context;
        public ProdcutRepo(PizzaHubContext context)
        {
                _context = context;
        }
        public IEnumerable<ProductModel> GetAllProducts()
        {
            try
            {
                var products = _context.Products.Where(p => p.Enabled == true).Select(p => new ProductModel
                {
                    Id = p.Id,
                    ProductName = p.ProductName,
                    ProdcutDescription = p.ProdcutDescription,
                    UnitPrice = p.UnitPrice,
                    Quantity = p.Quantity,
                    ImageUrl = p.ImageUrl,
                    Currency = p.Currency,
                }).ToList();
                return products;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
    }
}
