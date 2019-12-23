using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreWebTest
{
    //此类是学习依赖注入IoC容器，微软源生三大注入方式
   public  interface IService
    {
        string GetGuid();
    }
}
