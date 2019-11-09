using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
    class Nameof
    {
        //以前用法：当参数名称变化的时候，被引用的地方需要同步修改
        public void oldMethod(int account)
        {
            if (account<100)
            {
                throw new ArgumentException("参数account的值不能小于100！");
            }
            else
            {
                //其他操作
            }
        }
        //新用法：使用nameof，当参数变化时会在引用的地方同步变化，避免程序的硬编码
        //nameof里面可以是类名，方法名，参数名，属性名
        public void newMethod(int account)
        {
            if (account < 100)
            {
                throw new ArgumentException($"参数{nameof(account)}的值不能小于100！");
            }
            else
            {
                //其他操作
            }
        }
    }
}
