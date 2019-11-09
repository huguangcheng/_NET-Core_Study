using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
    class NullOperator
    {
        public int? age { get; set; }
        public static string[] sArray = { "bc","abc","",null};

        //旧方法：三元表达式
        public static void oldMethod()
        {
            foreach (var item in sArray)
            {
                var length = item == null ? 0 : item.Length;
                Console.WriteLine(length);
            }
            Console.WriteLine("--------");
        }
        //新方法
        public static void newMethod()
        {
            foreach (var item in sArray)
            {
                var length = item?.Length;//如果为null，直接输出null
                Console.WriteLine(length);
            }
            Console.WriteLine("--------");
            foreach (var item in sArray)
            {
                var length = item?.Length ?? 0;//a??b 当a为空时返回b，不为空，返回本身
                Console.WriteLine(length);
                //a??b??c从右往左进行组合运算。
            }

            //?的三个含义
            //1.可空修饰符  public int? age { get; set; } int是值类型，不能为null，使用？可空修饰符
            //2.三元表达式（运算符）  bool?a:b
            //3.空合并运算符 a??b



            //一般三元表达式
            // （bool逻辑运算表达式）?a:b;   表达式运算结果若为true，返回a，如果为false，则返回b

            //Null  运算符

            //a?.b    判断a是否为null   若a为null，则直接返回null，若不为null，则返回a.b（a的b属性或者字段）
            //a??b    判断a是否为null 若a为null，则返回b，若不为null，则返回a
            //a??(b??c)   从右往左算。
            //a?.b??0;




        }
    }

    }
