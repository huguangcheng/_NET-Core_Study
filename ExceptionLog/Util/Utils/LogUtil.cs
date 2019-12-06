using log4net;
using log4net.Config;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Util
{
    public static class LogUtil
    {
        public  static void LogInit()
        {
            //初始化Create仓库
            var repository = LogManager.CreateRepository("ExceptionLog");
            //读取配置文件，完成日志相关配置
            var filePath = @"Config\log4net.config";
            var basePath = Path.Combine(Directory.GetCurrentDirectory(),filePath); 
            XmlConfigurator.Configure(repository,new FileInfo(basePath));
            //完成配置
            BasicConfigurator.Configure(repository);
        }

        public static readonly ILog log = LogManager.GetLogger("ExceptionLog", typeof(LogUtil));

        /// <summary>
        /// 异常日志的记录
        /// </summary>
        /// <param name="msg"></param>
        /// <param name="obj"></param>
        public static  void Error(string msg, object obj = null)
        {
            if (log.IsErrorEnabled && !string.IsNullOrEmpty(msg))
            {
                if (obj == null)
                {
                    log.Error(msg);
                }
                else
                {
                    log.ErrorFormat(msg, obj);
                }
            }
        }
    }
}
