using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreWebTest
{
    public class MyService : IService
    {
        private readonly string guid;
        public MyService()
        {
            guid = Guid.NewGuid().ToString();
        }
        //alt+enter  快捷实现接口
        public string GetGuid()
        {
            return guid;
        }
    }
}
