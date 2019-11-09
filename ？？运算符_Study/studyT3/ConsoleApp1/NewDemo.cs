using System;
using System.Collections.Generic;
using System.Text;
using static System.Math;

namespace ConsoleApp1
{
    /// <summary>
    /// static声明静态类的引用
    /// </summary>
    class NewDemo
    {
        //以前的用法：两个数的绝对值相加
        public static int oldMethod(int a, int b)
        {
            return Math.Abs(a) + Math.Abs(b);
        }
        //现在用法，使用using static System.Math;提前引用静态类，避免每次使用Math类
        public static int newMethod(int a, int b) => Abs(a) + Abs(b);
    }
}
