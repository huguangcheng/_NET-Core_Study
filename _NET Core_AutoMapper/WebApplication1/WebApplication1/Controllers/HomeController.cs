using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;
using IService;

namespace WebApplication1.Controllers
{
    public class HomeController : Controller
    {
        
        private IStudent _studentService;
        public HomeController(IStudent studentService)
        {
            _studentService = studentService;
        }
        public IActionResult Index()
        {
            ViewData["ExerciseScore"]= _studentService.
            return View(model:_studentService.getStudentInfo());
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
