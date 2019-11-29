using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace Util
{
    public class Config
    {
        public static IConfiguration Configuration;
        public static IServiceProvider ServiceProvider;


        #region -------当前页面-------
        public static HttpContext HttpCurrent
        {
            get
            {
                object factory = ServiceProvider.GetService(typeof(IHttpContextAccessor));
                HttpContext context = ((IHttpContextAccessor)factory).HttpContext;
                return context; 
            }
        }
        #endregion
    }
}
