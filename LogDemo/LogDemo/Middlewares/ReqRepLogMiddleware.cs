using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace LogDemo
{
    /// <summary>
    /// 请求和响应记录记录中间件
    /// </summary>
    public class ReqRepLogMiddleware
    {
        private readonly RequestDelegate _next;
        public ReqRepLogMiddleware(RequestDelegate next)
        {
            _next = next;
        }
        public async Task Invoke(HttpContext context)
        {
            //过滤，只有接口
            if (context.Request.Path.Value.Contains("api"))
            {
                //buffering 缓冲
                context.Request.EnableBuffering();//储存一下缓冲
                Stream originBody = context.Response.Body;
                try
                {
                    //存储请求数据

                }
                catch (Exception)
                {

                    throw;
                }


            }
        }


        private void RequestDataLog(HttpContext context)
        {
            var request = context.Request;
            var sr = new StreamReader(request.Body);
        }

    }
}
