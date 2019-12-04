using log4net;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cache.Filters
{
    public class GlobalExceptionFilter : IExceptionFilter
    {
        private readonly IWebHostEnvironment _env;
        private readonly ILog log = LogManager.GetLogger("Log",nameof(GlobalExceptionFilter));
        public GlobalExceptionFilter(IWebHostEnvironment env)
        {
            _env = env;
        }
        public void OnException(ExceptionContext context)
        {
            if (!context.ExceptionHandled)
            {
                //获取出现异常的controller和action
                string strControllerName = context.RouteData.Values["controller"].ToString();
                string strActionName = context.RouteData.Values["action"].ToString();
                var json = new JsonErrorReponse();
                json.Message = context.Exception.Message;//错误信息
                //开发环境，暴露堆栈信息。
                if (_env.IsDevelopment())
                {
                    json.DevelopmentMessage = context.Exception.StackTrace;//堆栈信息
                }
                //采用log4net 进行错误日志记录：
                log.Error(json.Message + WriteLog(json.Message, context.Exception, strControllerName, strActionName));
                context.ExceptionHandled = true;
            }
           
        }
        public string WriteLog(string throwMsg, Exception ex,string strControllerName, string strActionName)
        {
            return $"\r\n【自定义错误】:{throwMsg}\r\n【异常控制器】:{strControllerName}\r\n【异常方法】" +
                $":{strActionName}\r\n【异常类型】:{ex.GetType().Name}\r\n【异常信息" +
                $"】:{ex.Message}\r\n【堆栈调用】:{ex.StackTrace}";
        }
    }

    /// <summary>
    /// 返回的错误信息
    /// </summary>
    public class JsonErrorReponse
    {
        /// <summary>
        /// 生产环境的消息
        /// </summary>
        public string Message { get; set; }
        /// <summary>
        /// 开发环境的消息
        /// </summary>
        public string DevelopmentMessage { get; set; }
    }
}
