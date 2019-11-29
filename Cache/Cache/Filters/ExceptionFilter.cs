using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Util;

namespace Cache.Filters
{
    public class ExceptionFilter
    {
        private readonly RequestDelegate _next;
        public ExceptionFilter(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)//发生异常
            {
                context.Response.StatusCode = 500;
                LogUtil.Error($"reponse exception:{ex.Message}");//ex.StackTrace
                await ResponseUtil.HandleExceptionAsync(500, "服务器错误。");
            }
        }
    }
}
