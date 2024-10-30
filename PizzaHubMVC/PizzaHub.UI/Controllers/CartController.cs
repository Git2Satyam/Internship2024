using Microsoft.AspNetCore.Mvc;
using PizzaHub.Models;
using PizzaHub.Services.Interface;
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
                    return RedirectToAction("Index", "Authentication", new { Area = "Auth" });
                    //Response.Cookies.Append("CartId", result, new CookieOptions { HttpOnly = true, Expires = DateTime.Now.AddYears(2) });
                }
                else
                {
                    var result = _cartService.AddItemotCart(productId, CartId);
                    if (result != null && result != "0")
                    {

                        if (cookie == null)
                        {


                        }

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
                var getCookies = getCookie();
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
                var cookies = HttpContext.Request.Cookies["CartId"];
                if (cookies != null) return cookies.ToString();
                else return null;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }


    }
}
