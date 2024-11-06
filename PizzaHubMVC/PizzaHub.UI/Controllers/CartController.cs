using Microsoft.AspNetCore.Mvc;
using PizzaHub.Models;
using PizzaHub.Services.Implementation;
using PizzaHub.Services.Interface;
using System.Net;
using System.Web;

namespace PizzaHub.UI.Controllers
{
    public class CartController : Controller
    {
        private readonly ICartService _cartService;
        public CartController(ICartService cartService)
        {
            _cartService = cartService; 
        }

        [Route("Cart/AddItemtoCart/{productId}")]
        public IActionResult AddItemtoCart(int productId)
        {
            try
            {
                var cookie = getCookie();
                if(cookie == null)
                {
                    TempData["error"] = "Login First";
                    return RedirectToAction("Index", "Authentication", new { Area = "Auth" });
                }
                else
                {
                    var result = _cartService.AddItemotCart(productId, CartId);
                    if (result != null && result != "0")
                    {
                        Response.Cookies.Append("CartId", result, new CookieOptions { HttpOnly = true, Expires = DateTime.Now.AddMonths(2) });
                        TempData["success"] = "Item added to cart successfully!";
                    }
                    else if (result != null && result == "0")
                    {
                        TempData["success"] = "Item already exist in your cart";
                    }
                    return RedirectToAction("Index", "Home");
                }
               
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }


        [HttpGet]
        public IActionResult DisplayCartItems()
        {
            try
            {
                var getCookies = HttpContext.Request.Cookies["CartId"];
                var id = new Guid(getCookies);
                var cartData = _cartService.GetProductsByCartId(id);
                Console.WriteLine(cartData);
                return View(cartData);
            }
            catch(Exception ex)
            {
                throw ex;
            }
          
        }

        Guid CartId
        {
            get
            {
                return Guid.NewGuid();
            }
        }

        private string getCookie()
        {
            try
            {
                var cookies = HttpContext.Request.Cookies[".AspNetCore.Antiforgery.KjaqY92YEmw"];
                if (cookies != null) return cookies.ToString();
                else return null;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        [Route("Cart/UpdateQuantity/{Id}/{Quantity}")]
        public IActionResult UpdateQuantity(int Id, int Quantity)
        {
            var cookie = HttpContext.Request.Cookies["CartId"];
            var cartid = new Guid(cookie);
            int count = _cartService.UpdateQuantity(cartid, Id, Quantity);
            return Json(count);
        }

    }
}
