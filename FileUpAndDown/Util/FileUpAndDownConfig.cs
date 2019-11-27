using Microsoft.Extensions.Configuration;
using System;

namespace Util
{
    //这个类是项目配置文件类，fileupanddown是项目的名字
    public class FileUpAndDownConfig
    {

        //public static IServiceProvider ServiceProvider;

        public static IConfiguration Configuration;

        public static void InitConfig(IConfiguration configuration)
        {
            Configuration = configuration;
        }


        private static string _filedownloadPath = string.Empty;
        public static string FiledownloadPath
        {
            get 
            {
                if (string.IsNullOrEmpty(_filedownloadPath))
                {
                    _filedownloadPath = Configuration["FileSettings:download"];
                }
                return _filedownloadPath;
            }
        }
    }
}
