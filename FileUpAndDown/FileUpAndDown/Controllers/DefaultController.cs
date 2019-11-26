using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace FileUpAndDown.Controllers
{
    [Controller]
    [Route("[Controller]/[Action]")]
    public class DefaultController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public ContentResult Content()
        {
            return Content("这个是ContentResult");
        }
        public string Content2()
        {
            return "这个是Content2";
        }
        //按照文件路径输出文件
        public ActionResult FilePathTest()
        {
            return File("~/Content/test.mp3","audio/mp3");
        }
        //点击按钮下载文件
        //public ActionResult Upload()
        //{
        //    string fileName = "快乐之歌.mp3";
        //    //Directory.GetCurrentDirectory()
        //    string filePath = Path.Combine(AppContext.BaseDirectory,"Content/test.mp3");

        //    //以字符流的方式下载文件
        //    FileStream fs = new FileStream(filePath,FileMode.Open);//通关文件流打开文件，参数是文件的路径，文件模型的打开
        //    //byte[] bytes = new byte[(int)fs.Length];
        //    //fs.Read(bytes, 0, bytes.Length);
        //    //fs.Close();
        //    //.*（ 二进制流，不知道下载文件类型） application/octet-stream
        //    //Response.ContentType = "application/octet-stream";
        //    //return File



        //}

    }
}