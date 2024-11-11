using Microsoft.EntityFrameworkCore;
using PizzaHub.Core.DataModels;
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
    public class CartRepo : ICartRepo
    {
        private readonly PizzaHubContext _context;
        public CartRepo( PizzaHubContext context)
        {
            _context = context;
        }
        public string AddItemotCart(int productId, Guid cartId)
        {
            var id = cartId;
            var product = GetProductByid(productId);
            try
            {
                var cartExist = _context.Carts.Include(c => c.CartItems).FirstOrDefault(c => c.Id == cartId);
                if (cartExist == null)
                {
                    var addCart = new Cart
                    {
                        Id = cartId,
                        UserId = 1,
                        CreatedDate = DateTime.Now,
                        isActive = true,
                    };

                    CartItem item = new CartItem
                    {
                        CartId = cartId,
                        ProductId = product.Id,
                        Quantity = 1,
                        UnitPrice = product.UnitPrice,
                        isActive = true,
                    };

                    addCart.CartItems.Add(item);
                    _context.Carts.Add(addCart);
                    _context.SaveChanges();

                }
                else
                {
                    CartItem cartItem = cartExist.CartItems.Where(c => c.ProductId == productId).FirstOrDefault();
                    if (cartItem == null)
                    {
                        CartItem item = new CartItem
                        {
                            CartId = cartExist.Id,
                            ProductId = product.Id,
                            Quantity = 1,
                            UnitPrice = product.UnitPrice,
                            isActive = true,
                        };
                        _context.CartItems.Add(item);
                    }
                    else if (cartItem.isActive == false)
                    {
                        cartItem.isActive = true;
                        _context.CartItems.Update(cartItem);
                    }
                    else
                    {
                        return string.Format("0");
                    }
                    _context.SaveChanges();
                    id = cartExist.Id;
                }
                return id.ToString();
            }
            catch(Exception ex)
            {
                throw ex;
            }
           
        }

        public List<ProductModel> GetProductsByCartId(Guid cartid)
        {
            var model = new List<ProductModel>();
            try
            {
                var cart = _context.Carts.Include(c => c.CartItems).FirstOrDefault(c => c.Id == cartid);
                if(cart != null)
                {
                    foreach(var item in cart.CartItems)
                    {
                        var product = _context.Products.Where(c => c.Id == item.ProductId && c.Enabled == true).Select(c => new ProductModel
                        {
                            Id = c.Id,
                            ProdcutDescription = c.ProdcutDescription,
                            Currency = c.Currency,
                            ImageUrl = c.ImageUrl,  
                            ProductName = c.ProductName,
                            Quantity = item.Quantity,
                            UnitPrice = c.UnitPrice,
                        }).FirstOrDefault();
                        model.Add(product);
                    }
                }
                return model;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public int UpdateQuantity(Guid cartId, int productId, int quantity)
        {
            try
            {
                var data = _context.CartItems.FirstOrDefault(c => c.CartId == cartId && c.ProductId == productId);
                if(data != null)
                {
                    data.Quantity += quantity;   
                    _context.Entry(data).State = EntityState.Modified;
                    _context.SaveChanges();
                    return (int)data.Quantity;
                }
                else
                {
                    int qty = 0;
                    return qty;
                }
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        private Product GetProductByid(int productId)
        {
            try
            {
                return _context.Products.FirstOrDefault(c => c.Id == productId);
            }
            catch(Exception ex)
            {
                throw ex;
            }
           
        }
    }
}
