using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using System.IO;
using System.Text;

namespace FileUpAndDown.Controllers
{
    public class StudentController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// 返回视图
        /// </summary>
        /// <returns></returns>
        public ViewResult ViewTest()
        {
            return View();
        }
        /// <summary>
        /// 返回简单文本内容
        /// </summary>
        /// <returns></returns>
        public ContentResult ContentTest()
        {
            return Content("<h1>呵呵<h1>");
        }
        public JsonResult JsonTest()
        {
            var obj = new { code = 200, msg = "请求成功！"};
            return Json(obj);
        }
        #region -------重定向--------
        /// <summary>
        /// 重定向页面跳转
        /// </summary>
        public IActionResult RedirectTest()
        {
            return Redirect("/Default/Index");
        }
        /// <summary>
        /// 跳转到指定的Action
        /// </summary>
        /// <returns></returns>
        public IActionResult RedirectToActionTest()
        {
            return RedirectToAction("Default", "Index");
        }
        /// <summary>
        /// 使用指定的路由值跳转到指定的路由
        /// </summary>
        /// <returns></returns>
        public IActionResult RedirectToRouteTest()
        {
            return RedirectToRoute(new
            {
                controller = "Default",
                action = "Index"
            }) ;
        }
        #endregion

        #region -------文件输出--------
        /// <summary>
        /// 按照文件路径，来输出文件。
        /// </summary>
        /// <returns></returns>
        public IActionResult OutputFileInPath()
        {
            string filePath = "~/Content/21天学会JavaScript.pdf";
            return File(filePath, "application/pdf");
        }
        /// <summary>
        /// 使用字节数组输出文件
        /// </summary>
        /// <returns></returns>
        public IActionResult OutputFileInByte()
        {
            string basePath = Directory.GetCurrentDirectory();
            string filePath = Path.Combine(basePath, "wwwroot\\Content\\快乐之歌.mp3");
            using (var fs=new FileStream(filePath,FileMode.Open,FileAccess.Read))
            {
                byte[] content = new byte[fs.Length];
                fs.Read(content, 0, (int)fs.Length);
                return File(content, "audio/mp3");
            }
        }
        #endregion


    }
}