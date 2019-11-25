using System;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            int count = 18;
            Console.WriteLine(nameof(count));

            //此篇是nameof ，typeof GetType()穿插示例

            //nameof（变量）  获取变量的名称

            //typeof(具体类型)
            //a.GetType()   a是类型的实例



            //throw new ArgumentException($"您输入的{nameof(count)}有误！请重新输入！");
            //Console.WriteLine(count.GetType());
            //Console.WriteLine(typeof(int));
            FanXing.GetNum(666);
            Console.WriteLine(FanXing.GetString("你好"));  
            Console.ReadLine();
        }
    }
}
