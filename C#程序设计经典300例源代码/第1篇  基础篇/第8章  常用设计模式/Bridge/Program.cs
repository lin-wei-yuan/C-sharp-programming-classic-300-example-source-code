using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

//桥接模式
namespace Bridge
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "果园实现统一的种植方法";
Orchard bjOrchard = new BJOrchard();                  //创建北京果园实例
bjOrchard.Fruit = new Apple();                        //创建苹果类实例
bjOrchard.Plant();                                    //北京果园种植苹果
bjOrchard.Fruit = new Orange();                       //创建桔子类实例
bjOrchard.Plant();                                    //北京果园种植桔子
Orchard shOrchard = new SHOrchard();                  //创建上海果园实例
shOrchard.Fruit = new Apple();                        //创建苹果类实例
shOrchard.Plant();                                    //上海果园种植苹果
shOrchard.Fruit = new Orange();                       //创建桔子类实例
shOrchard.Plant();                                    //上海果园种植桔子
            Console.Read();
        }
    }
//抽象水果类
public abstract class Fruit
{
    public abstract void Plant();                       //抽象种植方法
}
//苹果类
public class Apple : Fruit
{
    public override void Plant()                        //种植苹果
    {
        Console.WriteLine("种植苹果!");
    }
}
//桔子类
public class Orange : Fruit
{
    public override void Plant()                        //种植桔子
    {
        Console.WriteLine("种植桔子!");
    }
}
//抽象果园类
public abstract class Orchard
{
    protected Fruit fruit;                              //水果类引用
    public Fruit Fruit { set { fruit = value; } }       //将具体水果类实例赋值给抽象水果类引用
    public abstract void Plant();                       //抽象种植方法
}
//北京果园
public class BJOrchard : Orchard
{
    public override void Plant()                        //北京果园种植水果
    {
        Console.Write("北京果园");
        fruit.Plant();
    }
}
//上海果园
public class SHOrchard : Orchard
{
    public override void Plant()                        //上海果园种植水果
    {
        Console.Write("上海果园");
        fruit.Plant();
    }
}

}
