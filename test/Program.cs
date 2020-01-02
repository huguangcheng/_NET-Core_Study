using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
namespace test
{
    class Program
    {
        static void Main(string[] args)
        {
        //    Animal animal =new  Dog();
        //    animal.Eat();
        //    animal.Sleep();


        //字符串的不可变性
        // string s1="张三";
        // string s2=s1;
        // s2="李四";
        // System.Console.WriteLine(s1);

        Point point=new Point ();
        point.X=1;
        point.Y=2;
        Point point1 =new Point ();
        point1=point;
        point1.Y=666;
        System.Console.WriteLine(point.Y);

        //可以将字符串类型看做是char类型的一个只读数组
        string s="abcdefg";

        //既然可以将string看做是char类型的只读数组，所以我可以通过下标去访问字符串中的某一个元素
        System.Console.WriteLine(s[0]);
        //s[0]='a';  不能这样做，因为它是只读的

        // 首先将字符串转化为真正char类型数组
        char[] cha=s.ToCharArray();
        cha[0]='z';
        s=new string(cha);
        System.Console.WriteLine(s);

        //如何将字符串“Hello World”变成"World Hello并输出？"
        string str1="Hello World";
        string[] arr=str1.Split(' ').Reverse().ToArray();
        string str2=string.Join(' ',arr);
        System.Console.WriteLine(str1);
        System.Console.WriteLine(str2);


        string[] test=new string[]{"1","2"};
        test=test.Reverse().ToArray();
        foreach (var item in test)
        {
            System.Console.WriteLine(item);
        }
        }
    }

    class Point
    {
        public int X{get;set;}
        public int Y{get;set;}
    }
}
