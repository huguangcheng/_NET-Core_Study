namespace OOP_Test
{
    public class Student
    {
        public string  Name { get; set; }
        public int Age { get; set; }
        public string Gender { get; set; }

        //this的作用
        //（1）指当前类的对象
        //（2）在类当中显式地调用本来其他的构造函数
        public Student(string name,int age,string gender)
        {
            //这里的this可以省略
            Name=name;
            this.Age=age;
            this.Gender=gender;
        }
        public Student(string name,int age):this(name,age,"c")
        {
            
        }
        public Student(string name)
        {
            
        }
    }
}