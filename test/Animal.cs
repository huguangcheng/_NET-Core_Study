namespace test
{
    public abstract class Animal
    {
        public Animal()
        {
            Eat();
            Crying();
        }
        public void  Sleep()
        {
            
        }
        public virtual void Eat(){System.Console.WriteLine("父类呵呵");}

        //抽象方法必须在抽象类当中，而抽象类当中不一定全部都是抽象方法
        public abstract void Crying();
    }
}