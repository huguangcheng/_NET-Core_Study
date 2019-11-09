using System;
using System.Collections.Generic;
using System.Linq;
namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Student> list = new List<Student>() {
                new Student (){ ID=1,Name="aaaa",Age=15},
                new Student (){ ID=2,Name="bbb",Age=17},
                new Student (){ ID=3,Name="cccc",Age=16},
            };
            var list2 = list.Select(a => a.Name).ToList();

            list.ForEach(a => a.deptid = 2);//批量给list集合对象的某个字段赋相同的值
            foreach (var item in list)
            {
                Console.WriteLine(item.deptid);
            }
        }
    }

    public class Student
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public int deptid { get; set; }
    }
}
