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
            try
            {
                var result = _studentService.GetAllStudent();
                return View(result);
            }
            catch(Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                return BadRequest(ex.Message);
            }
           
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

        [HttpGet]
        public IActionResult EditStudent(int id)
        {
            var data = _studentService.EditStudent(id);
            if(data != null)
            {
                return View(data);
            }
            else
            {
                return View("~/Shared/Error.cshtml");
            }
           
        }

        [HttpPost]
        public IActionResult EditStudent(StudentModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var result = _studentService.EditStudent(model);
                    if(result == 1)
                        return RedirectToAction("Index");
                }
                return View("EditStudent");
              
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            try
            {
                var result = _studentService.DeleteStudent(id);
                if(result)
                    return RedirectToAction("Index");
                return View();
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
