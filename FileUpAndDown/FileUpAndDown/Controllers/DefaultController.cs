using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Util;

namespace FileUpAndDown.Controllers
{
    //[Controller]
    //[Route("[Controller]/[Action]")]
    public class DefaultController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }


        public ActionResult DownLoad()
        {
            //AppContext.BaseDirectory 是在下面下bin文件下下的netcore
            //string filePath = Path.Combine(AppContext.BaseDirectory, "Content/test.jpg");
            string filePath = "~/Content/test.jpg";
            return File(filePath, "image/jpeg","heh.jpg");

        }

        //请求下载文件
        //public MessageEntity RequestDownloadFile([FromBody]Dictionary<string,object>fileinfo)
        //{
        //    MessageEntity message = new MessageEntity();
        //    string fileName = string.Empty;
        //    string fileExt = string.Empty;
        //    if (fileinfo.ContainsKey("name"))
        //    {
        //        fileName = fileinfo["name"].ToString();
        //    }
        //    if (fileinfo.ContainsKey("ext"))
        //    {
        //        fileExt = fileinfo["ext"].ToString();
        //    }
        //    if (string.IsNullOrEmpty(fileName))
        //    {
        //        message.Code = -1;
        //        message.Msg = "文件名不能为空";
        //        return message;
        //    }
        //    //获取对应目录下的文件，如果有，获取文件开始准备分段下载
        //    string filePath = $".{FileUpAndDownConfig.FiledownloadPath}{DateTime.Now.ToString("yyyy-MM-dd")}/{fileName}";
        //    filePath = $"{filePath}{fileExt}";
        //    FileStream fs = null;
        //    try
        //    {
        //        if (!System.IO.File.Exists(filePath))
        //        {
        //            //文件为空，
        //            message.Code = -1;
        //            message.Msg = "文件尚未处理完";
        //            return message;
        //        }
        //        fs = new FileStream(filePath, FileMode.Open);
        //        if (fs.Length<=0)
        //        {
        //            //文件为空
        //            message.Code = -1;
        //            message.Msg = "文件尚未处理完";
        //            return message;
        //        }
        //        //计算机的储存及流量单位常用的有b字节，kb千字节，mb兆，gb千兆，太字节tb，艾字节pb
        //        int shardSize = 1 * 1024 * 1024;//一次一兆
        //        RequestFileUploadEntity
        //    }
        //    catch (Exception)
        //    {

        //        throw;
        //    }
        //}


        //分段下载文件

        public async Task<IActionResult> FileDownLoadLook()
        {
            //获取文件。
            //string filePath = $"{Path.Combine(Directory.GetCurrentDirectory(),$"{FileUpAndDownConfig.FiledownloadPath}\\test.jpg)")}";
            string filePath = Path.Combine(Directory.GetCurrentDirectory(), $"{FileUpAndDownConfig.FiledownloadPath}\\test.jpg");
            if (!System.IO.File.Exists(filePath))
            {
                return Ok(new { code = -1, msg = "文件尚未处理" });
            }
            using (var fs= new FileStream(filePath,FileMode.Open))
            {
                if (fs.Length<=0)
                {
                    return Ok(new { code = -1, msg = "文件尚未处理" });
                }
                byte[] datas = new byte[fs.Length];
                await fs.ReadAsync(datas, 0, datas.Length);
                //返回文件字节数组，供前端下载资源
                return File(datas, "image/jpeg");
            }
        }

        public IActionResult FileDownLoad()
        {
            //获取文件。
            //string filePath = $"{Path.Combine(Directory.GetCurrentDirectory(),$"{FileUpAndDownConfig.FiledownloadPath}\\test.jpg)")}";
            string filePath = Path.Combine(Directory.GetCurrentDirectory(), $"{FileUpAndDownConfig.FiledownloadPath}\\test.jpg");
            if (!System.IO.File.Exists(filePath))
            {
                return Ok(new { code = -1, msg = "文件尚未处理" });
            }
            //直接path   返回下载资源文件，不太安全。
            //直接返回path下载的时候，地址是相对路径（虚拟路径）
            //使用流读取文件的时候，需要使用绝对路径（物理路径）
            return File("~/File/download/test.jpg", "image/jpeg","美女.jpg");

        }
        static readonly HttpClient client = new HttpClient();

        private const string uri = "http://localhost:5000/api/Default/DownLoad";
        /// <summary>
        /// 请求另一个api项目，返回文件流，并读取继续返回文件流，供前端下载
        /// </summary>
        /// <returns></returns>
        public async Task<IActionResult> FileAPI()
        {
            HttpResponseMessage response = await client.GetAsync(uri);

            var stream = await response.Content.ReadAsStreamAsync();
            var mini = response.Content.Headers.ContentType.MediaType;
            return File(stream, mini, "666.mp3");

        }



    }


    }

    //返回实体
    public class MessageEntity
    {
        private int _Code = 0;
        private string _Msg = string.Empty;
        private object _Data = new object();

        /// <summary>
        /// 状态标识
        /// </summary>
        public int Code { get => _Code; set => _Code = value; }
        /// <summary>
        /// 返回消息
        /// </summary>
        public string Msg { get => _Msg; set => _Msg = value; }
        /// <summary>
        /// 返回数据
        /// </summary>
        public object Data { get => _Data; set => _Data = value; }

    }
