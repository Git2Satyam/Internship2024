using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using PizzaHub.Core.DataModels;
using PizzaHub.Core.DB_Context;
using PizzaHub.Models;
using System.Security.Claims;
using System.Text.Json;


namespace PizzaHub.UI.Areas.Auth.Controllers
{
    [Area("Auth")]
    public class AuthenticationController : Controller
    {
        private readonly PizzaHubContext _context;
        public AuthenticationController(PizzaHubContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            ViewBag.Message = null;
            ViewBag.Message = TempData["error"];
            return View();
        }

        [HttpPost]
        public IActionResult VerifyUser(LoginFormModel model)
        {
            try
            {
                var user = _context.Users.FirstOrDefault(c => c.Email == model.Username &&  c.Password == model.Password);
                if(user == null)
                {
                    return null;
                }
                else
                {
                    var userML = new UserModel
                    {
                        FirstName = user.FirstName,
                        LastName = user.LastName,
                        Email = user.Email,
                        Password = user.Password,
                        Enabled = user.Enabled,
                        PasswordExpiryDate = user.PasswordExpiryDate,
                    };
                    GenerateTicket(userML);
                    TempData["success"] = "Login successfull";
                    return RedirectToAction("Index", "Home", new {Area=""});
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public IActionResult SaveUser(UserModel model)
        {
            bool flag = false;
            try
            {
                if (ModelState.IsValid)
                {
                    var user = new User()
                    {
                        FirstName = model.FirstName,
                        LastName = model.LastName,
                        Password = model.Password,
                        PasswordExpiryDate = DateTime.Now.AddMonths(6),
                        Enabled = true,
                        Email = model.Email,
                        CreatedDate = DateTime.Now,
                    };
                    _context.Users.Add(user);
                    _context.SaveChanges();
                    flag = true;
                }
                return RedirectToAction("Index");
            }
            catch(Exception ex)
            {
                return BadRequest(ex);
            }
        }

        void GenerateTicket(UserModel user)
        {
            string strData = JsonSerializer.Serialize(user); // claims is used to identify the user uniquely
            var claims = new List<Claim> {                    
                new Claim(ClaimTypes.UserData,strData),      
                new Claim(ClaimTypes.Email,strData),
            };
            var identtity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme); // by using Httpcontext we can find out user login datail
            HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(identtity),  // set cookie base on identity
            new AuthenticationProperties
            {
                AllowRefresh = true,
            });
        }

        public IActionResult SignUpForm()
        {
            try
            {
                return View();
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
    }

}
