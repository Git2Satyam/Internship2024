using Microsoft.AspNetCore.Mvc;
using StudentForm.Models;
using StudentForm.Services.Interface;
using StudentFrom.Models;
using System.Diagnostics;

namespace StudentFrom.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IStudentService _studentService;
        public HomeController(ILogger<HomeController> logger, IStudentService studentService)
        {
            _logger = logger;
            _studentService = studentService;
        }


        public IActionResult Index()
        {
            var result = _studentService.GetAllStudent();  
            return View(result);
        }

        
        public IActionResult DisplayStudentForm()
        {
            return View();
        }

        [HttpPost]
        public IActionResult DisplayStudentForm(StudentModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var result = _studentService.SaveStudentData(model);
                }
                else
                {
                    return null;
                }
                return RedirectToAction("Index");
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public IActionResult EditStudent(int id)
        {
            return View();
        }

        [HttpPost]
        public IActionResult EditStudent(StudentModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var result = _studentService.EditStudent(model);
                    if (result)
                    {
                        return RedirectToAction("Index");
                    }
                    else
                    {
                        return null;
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
