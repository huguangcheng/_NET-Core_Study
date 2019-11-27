using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.StaticFiles;

namespace FileAPI.Controllers
{
    [Route("api/[Controller]/[Action]")]
    [ApiController]
    public class DefaultController : ControllerBase
    {
        //public HttpResponseMessage FileApi()
        //{
        //    try
        //    {
        //        //string filePath = "wwwroot/Content/test.mp3";
        //        string filePath = @"wwwroot\Content\test.mp3";  //用到流的需要物理路径，使用Path.Combine 进行组合一下，且基本路径是\不是/
        //        string basePath = Path.Combine(Directory.GetCurrentDirectory(),filePath);
        //        using(var stream = new FileStream(basePath, FileMode.Open))
        //        {
        //            //byte[] datas = new byte[stream.Length];
        //            //stream.Read(datas, 0, datas.Length);
        //            //MemoryStream memoryStream = new MemoryStream(datas);
        //            HttpResponseMessage response = new HttpResponseMessage(System.Net.HttpStatusCode.OK);
        //            response.Content = new StreamContent(stream);
        //            response.Content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/octet-stream");
        //            response.Content.Headers.ContentDisposition = new System.Net.Http.Headers.ContentDispositionHeaderValue("attachment")
        //            {
        //                FileName = "快樂之歌.mp3"
        //            };
        //            return response;
        //        }
        //    }
        //    catch 
        //    {
        //        return new HttpResponseMessage(System.Net.HttpStatusCode.NoContent);
        //    }
        //}

        /// <summary>
        /// 文件流的方式输出       
        /// </summary>
        /// <returns></returns>
        public IActionResult DownLoad()
        {
            string filePath = @"wwwroot\Content\test.mp3";  //用到流的需要物理路径，使用Path.Combine 进行组合一下，且基本路径是\不是/
            string basePath = Path.Combine(Directory.GetCurrentDirectory(), filePath);
            var stream = System.IO.File.OpenRead(basePath);
            return File(stream, "audio/mp3", Path.GetFileName(basePath));
        }
    }
}