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
    public class CartService : ICartService
    {
        private readonly ICartRepo _cartRepo;
        public CartService(ICartRepo cartRepo)
        {
            _cartRepo = cartRepo;
        }
        public string AddItemotCart(int productId, Guid cartId)
        {
            return _cartRepo.AddItemotCart(productId, cartId);
        }

        public List<ProductModel> GetProductsByCartId(Guid cartid)
        {
            try
            {
                return _cartRepo.GetProductsByCartId(cartid);
            }
            catch(Exception ex)
            {
                throw ex;
            }
           
        }
    }
}
