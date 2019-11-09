using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace ViewDataPass.Controllers
{
    public class Default1Controller : Controller
    {
        public IActionResult Index()
        {
            TempData["temp"] = "1111111111";
            return RedirectToAction("Index", "Default");
        }
    }
}