using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
    public class FanXing
    {
        //初探  泛型。
          
        //还有一篇泛型和一个接口多个实现类的结合，看老张视频和代码实现。


        //此篇是泛型的学习
        //使用泛型可以最大限度地重用代码、保护类型安全性以及提高性能。泛型最常用的用途是创建集合类List<int>
        //泛型约束有哪些：
        //where T : class  类型参数必须是引用类型。此约束还应用于任何类、接口、委托或数组类型
        //where T:struct    类型参数必须是值类型
        //where T : unmanaged   类型参数不能是引用类型，并且任何嵌套级别均不能包含任何引用类型成员
        //where T : new()     类型参数必须具有公共无参数构造函数
        //where T : <基类名>    类型参数必须是指定的基类或派生自指定的基类
        //where T : <接口名称>  类型参数必须是指定的接口或实现指定的接口
        //where T : U 为 T 提供的类型参数必须是为 U 提供的参数或派生自为 U 提供的参数
        public static  void  GetNum<T>(T t) where T:struct
        {
            //return t;
            Console.WriteLine(t);
        }

        //泛型可以有泛型方法、泛型类，泛型接口

        //泛型类 public class FanXing<T> 
        //泛型方法 public 
        public static string GetString<T>(T t) where T:class
        {
            return t.ToString();
        }

        //泛型接口
        public interface IService<T>
        {
            
        }

        //泛型委托
        public delegate void GenericDelegate<T>(T t);
        

        //public static 
    }
}
