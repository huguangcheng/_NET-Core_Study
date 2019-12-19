using System;

namespace OOP_Test
{
    class Program
    {
        static void Main(string[] args)
        {
            Student student=new  Student("胡广成",20);
            System.Console.WriteLine(student.Name);
            System.Console.WriteLine(student.Age);
            System.Console.WriteLine(student.Gender);
            Console.ReadKey();
        }
    }
}
