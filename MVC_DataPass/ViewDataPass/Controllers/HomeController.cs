using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ViewDataPass.Models;

namespace ViewDataPass.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            TempData["temp"] = "tempdata";
            Response.Redirect("/Study/ViewBagPass");
            //return RedirectToAction("ViewBagPass", "Study");

            //两种方法都可以，不过原理不一样，
            //一个是在后端跳转控制器和action，一个是响应了一个url给前端了
            //TempData数据为空没有储存到，注意要在startup的
            //configure里面把UseCookiePolicy放在mvc的后面就可以了
            return Content("");

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
