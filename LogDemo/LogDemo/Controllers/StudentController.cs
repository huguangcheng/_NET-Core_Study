using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using log4net;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Student.Util;

namespace LogDemo.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        public StudentController()
        {

        }

        //private ILog log = LogManager.GetLogger(Startup.repository.Name, "Student");
        public string GetName()
        {
            LogUtil.Info("测试");
            return "你好";
        }
    }
}