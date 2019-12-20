using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace CoreWebTest
{
    //中间件   名字后缀以Middleware结尾
    public class RequestSetOptionMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly IOptions<CommonOption> _options;

        public RequestSetOptionMiddleware(RequestDelegate next ,IOptions<CommonOption> options)
        {
            //这个IOptions<class> 这个东西，可以认为是一个公共的对象，
            //它可以从头传到尾，供中间件使用
            _next = next;
            _options = options;
        }

        public async Task Invoke(HttpContext httpContext)
        {
            Console.WriteLine("RequestSetOptionMiddleware.Invoke");
            string option = httpContext.Request.Query["option"];
            if (!string.IsNullOrWhiteSpace(option))
            {
                //_options.Value.Options = WebUtility.HtmlEncode(option);
                var a = WebUtility.HtmlEncode(option);
                var b = option;
                httpContext.Response.ContentType = "text/html;charset=utf-8";
                _options.Value.Options = option;
                await httpContext.Response.WriteAsync(_options.Value.Options);
                //使用WebUtility.HtmlEncode  
                //对客户端发送的请求字符串进行编码，
                //以防止非法字符串
                //http://localhost:5000/Home/Index?option=111
            }
            else
            {
                await _next(httpContext);//调用下一个中间件。
            }
        }
    }
}
