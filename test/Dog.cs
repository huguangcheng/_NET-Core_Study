namespace test
{
    public class Dog:Animal
    {
        public Dog()
        {
           Crying(); 
        }

        //继承了抽象类，则必须要实现其抽象方法
        public override void Crying()
        {
            System.Console.WriteLine("子类的狗狗在哭");
        }

        //父类的虚方法可重写，可不重写。

        //如果重写，则父类构造函数中调用的虚方法，会执行到子类重写的方法当中

        // public override void Eat()
        // {
        //     System.Console.WriteLine("这个是子类重写的吃方法，大口的吃吧，哈哈哈");
        // }
    }
}