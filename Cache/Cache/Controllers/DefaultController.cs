using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Cache.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class DefaultController : ControllerBase
    {
        public int testexception(int a)
        {
            try
            {
                return a / 0;
            }
            catch (Exception ex)
            {

                throw;
            }
            finally 
            {
                
            }
        }
    }
}