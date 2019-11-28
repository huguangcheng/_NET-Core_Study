using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace SwaggerDemo.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class DefaultController : ControllerBase
    {
        /// <summary>
        /// 通过id查询学生的姓名
        /// </summary>
        /// <param name="id">需要查询的学生的id</param>
        /// <returns></returns>
        [HttpGet]
        public IActionResult GetName(int id)
        {
            return Ok("吴磊");
        }
    }
}