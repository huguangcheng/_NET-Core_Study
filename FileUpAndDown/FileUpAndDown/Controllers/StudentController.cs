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
        /// 跳转到Default控制器的Index动作方法当中
        /// </summary>
        /// <returns></returns>
        public IActionResult RedirectToActionTest()
        {
            return RedirectToAction("Index", "Default");
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
            using (var st=new FileStream(filePath,FileMode.Open))//Mode  模式，方式
            {
                byte[] content = new byte[st.Length];
                st.Read(content, 0, content.Length);
                return File(content, "audio/mp3","快乐之歌.mp3");
            }
       
        }
        /// <summary>
        /// 使用文件流方式输出文件
        /// </summary>
        /// <returns></returns>
        public IActionResult OutputFileInStream()
        {
            string basePath = Directory.GetCurrentDirectory();
            string filePath = Path.Combine(basePath, "wwwroot\\Content\\快乐之歌.mp3");
            var fs = new FileStream(filePath, FileMode.Open);
            return File(fs, "audio/mp3");
        }
        #endregion


    }
}