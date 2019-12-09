using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Util;
using Newtonsoft.Json;

namespace ExceptionLog.Filters
{
    public class GlobalExceptionFilter : IExceptionFilter
    {
        public void OnException(ExceptionContext context)
        {
            if (!context.ExceptionHandled)//如果错误没有被处理
            {
                
                //获取出错的控制器及动作方法
                string controllerName = context.RouteData.Values["controller"].ToString();
                string actionName = context.RouteData.Values["action"].ToString();
                var Message = context.Exception.Message;
                //使用log4net日志框架和自定义方法记录日志
                LogUtil.Error(Message+ WriteLog(Message,context.Exception,controllerName,actionName));

                HttpClient client = new HttpClient();
                //使用接口发送消息
                var data = $"?text=【XXX系统错误】&desp={SendMessage(Message, context.Exception, controllerName, actionName)}";
                var uri = "http://sc.ftqq.com/【自己的SCKEY】.send";
                client.GetAsync(uri+data);
                var json = new { code="500",msg="系统异常，请联系管理员"};
                var res = JsonConvert.SerializeObject(json);
                context.ExceptionHandled = true;
            }
        }
        /// <summary>
        /// 自定义输出日志
        /// </summary>
        /// <param name="thorwMessage"></param>
        /// <param name="ex"></param>
        /// <param name="controllerName"></param>
        /// <param name="actionName"></param>
        /// <returns></returns>
        public string WriteLog(string thorwMessage,Exception ex,string controllerName,string actionName)
        {
            return $"\r\n【自定义错误】:{thorwMessage}\r\n【异常控制器】:{controllerName}" +
                $"\r\n【异常方法】:{actionName}\r\n【异常类型】:{ex.GetType().FullName}" +
                $"\r\n【异常信息】:{ex.Message}\r\n【堆栈调用】:{ex.StackTrace}";
        }
        //发送信息的格式化方法，server酱，换行需要两次换行符号
        public string SendMessage(string throwMsg, Exception ex, string strControllerName, string strActionName)
        {
            return $"【自定义错误】:{throwMsg}\r\n\r\n【异常控制器】:{strControllerName}\r\n\r\n【异常方法】" +
                $":{strActionName}\r\n\r\n【异常类型】:{ex.GetType().Name}\r\n\r\n【异常信息" +
                $"】:{ex.Message}\r\n\r\n【堆栈调用】:{ex.StackTrace}";
        }
    }

}
