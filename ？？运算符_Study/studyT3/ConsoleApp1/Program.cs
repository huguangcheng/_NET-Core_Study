using System;
using System.Collections.Generic;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, string> dictionary = new Dictionary<string, string>()
            {
                {"name","hgc"},
                {"age","18"},
                {"gender","男"},
            };
            foreach (var item in dictionary.Keys)
            {
                Console.WriteLine($"{item}----------{dictionary[item]}");
            }
            Console.WriteLine(NewDemo.oldMethod(-1,-2));
            Console.WriteLine(NewDemo.newMethod(-1, -2));
            Console.WriteLine("----------");
            NullOperator.oldMethod();
            NullOperator.newMethod();

            Console.ReadKey();
        }
    }
}
