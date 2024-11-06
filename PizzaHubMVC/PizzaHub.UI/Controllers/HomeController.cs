using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using PizzaHub.Models;
using PizzaHub.Services.Interface;
using PizzaHub.UI.Models;
using System.Diagnostics;

namespace PizzaHub.UI.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IWebHostEnvironment _env;
        private readonly IProductService _productService;
        public HomeController(ILogger<HomeController> logger, IWebHostEnvironment env, IProductService service)
        {
            _logger = logger;
            _env = env;
            _productService = service;
        }

        public IActionResult Index()
        {
            try
            {
                var images =  this.GetSliderImage();  // get images for slider
                ViewBag.Images = images;   // store images into viewbag
                var result = _productService.GetAllProducts();
                return View(result);
            }
            catch(Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                return BadRequest(ex.Message);
            }
           
        }
      
        public IActionResult About()
        {
            return View();
        }

        public IActionResult Contact()
        {
            return View();
        }
        public IActionResult Privacy()
        {
            return View();
        }

       

        private List<string> GetSliderImage()
        {
            var imageList = new List<string>();
            var imagePath = Path.Combine(_env.WebRootPath, "Images/Slider");
            var imageFiles = Directory.GetFiles(imagePath).Select(Path.GetFileName).ToList();
            foreach (var imageFile in imageFiles)
            {
                var img = string.Format("~/Images/Slider/" + imageFile);
                imageList.Add(img);
            }
            return imageList;
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
