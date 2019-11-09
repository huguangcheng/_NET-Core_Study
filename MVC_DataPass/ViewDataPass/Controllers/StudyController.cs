using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace ViewDataPass.Controllers
{
    public class StudyController : Controller
    {

        public IActionResult Index()
        {
            return View();
        }
        //---------------视图和控制器之间的数据传递
        //------ViewBag/ViewData/TempData
        public IActionResult ViewBagPass()
        {
            ViewData["User"] = "Admin";
            var data =getData();
            ViewBag.data = data;//可直接在前端用
            ViewData["list"] = getData();//需在前端转换数据类型
            //ViewData已验证，只能在当前视图可用   返回其他视图，如果其他视图的控制器里面没有逻辑传输数据可以用，但是有数据传输的话就会失效
            //所以返回其他视图，一般不传model，可以用redirectToaction
            return View(getData());
        }
        public IActionResult ViewDataPass()
        {
            //返回 别的视图并不能传model给别的视图

            //ViewData、ViewBag传输数据仅限当前action对应的当前视图
            //model也只能传给当前的控制器或者视图
            //return View("ViewBagPass", model:1);//这种写法不行，返回的那个视图中的数据会丢失
            return RedirectToAction("ViewBagPass");//路径发生变化



        }
        public IActionResult TempDataPass()
        {
            

            return View();
        }

        //实际业务部分也不会写在控制器中，解耦，方便维护
        public List<Student> getData()
        {
            List<Student> list = new List<Student>() {
                new Student (){ ID=1,Name="aaaa",Age=15},
                new Student (){ ID=2,Name="bbb",Age=17},
                new Student (){ ID=3,Name="cccc",Age=16},
            };
            return list;
        }
    }
    //这里为了学习方便直接把model定义在了控制器中，实际是不可以的，要放在Model实体类下
    public class Student
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public int deptid { get; set; }
    }

}