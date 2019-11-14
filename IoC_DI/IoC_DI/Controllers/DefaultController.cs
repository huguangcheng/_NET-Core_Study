using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IoC_DI.IRepository;
//using IoC_DI.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace IoC_DI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DefaultController : ControllerBase
    {

        private readonly IUserRepository _repository;
        //private readonly UserRepository _test;

        public DefaultController(IUserRepository repository /*,UserRepository test*/)
        {
            _repository = repository;
            //_test = test;
        }

        // GET: api/Default  //api访问格式    api/控制器
        [HttpGet]
        public string Get()
        {
            //UserRepository userRepository = new UserRepository();
            //return _repository.GetUserName();
            return _repository.GetUserName();
        }
    }
}
