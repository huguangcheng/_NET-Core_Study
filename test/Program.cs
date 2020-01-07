using System;
using System.Text;
using System.Linq;
using System.Diagnostics;

//diagnostics  诊断
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
        //大量的操作字符串，会造成大量的内存浪费，这个时候建议使用StringBuilder
        StringBuilder stringBuilder=new StringBuilder();
        string str=null;
        //创建了一个计时器，用来记录程序运行的时间
        Stopwatch sw=new Stopwatch ();
        sw.Start();//开始计时
        for (int i = 0; i < 100000; i++)
        {
            // str+=i;//00:00:12.1689092
            stringBuilder.Append(i);//00:00:00.0051262
        }
        sw.Stop();//结束计时
        System.Console.WriteLine(sw.Elapsed);//elapsed (时间)消逝，逝去
        string name1="C#";
        string name2="c#";

        //StringComparison.OrdinalIgnoreCase忽略大小写
        if (name1.Equals(name2,StringComparison.OrdinalIgnoreCase))
        {
            System.Console.WriteLine("ok");
        }

        //分割字符串Split
        string ss="a _ ? +=s ccdf";
        char[] chr={' ','_','+','=','?'};

        string[] str11=ss.Split(chr,StringSplitOptions.RemoveEmptyEntries);
        ss=string.Join(string.Empty,str11.Select(a=>a));
        System.Console.WriteLine(ss);

        //将2020-1-7输出2020年1月7日
        string date="2020-1-7";

        //StringSplitOptions.RemoveEmptyEntries  移除空字符串
        string[] chardate=date.Split('-',StringSplitOptions.RemoveEmptyEntries);
        System.Console.WriteLine($"{chardate[0]}年{chardate[1]}月{chardate[2]}日");


        string ss2="国家关键人物习近平";
        if (ss2.Contains("习近平"))
        {
            ss2=ss2.Replace("习近平","***");
        }
        System.Console.WriteLine(ss2);
        }
    }

    class Point
    {
        public int X{get;set;}
        public int Y{get;set;}
    }
}
