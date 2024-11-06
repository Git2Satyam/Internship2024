using PizzaHub.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaHub.Services.Interface
{
    public interface ICartService
    {
        string AddItemotCart(int productId, Guid cartId);
        List<ProductModel> GetProductsByCartId(Guid cartid);
        int UpdateQuantity(Guid cartId, int productId, int quantity);
    }
}
