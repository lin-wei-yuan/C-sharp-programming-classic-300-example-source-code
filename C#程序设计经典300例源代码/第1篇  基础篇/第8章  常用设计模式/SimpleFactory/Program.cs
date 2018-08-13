using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

//简单工厂模式
namespace SimpleFactory
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "果园种植水果";
Orchard factory = new Orchard();                        //创建果园实例
Fruit apple = factory.CreateFruit("Apple");                  //创建苹果实例
apple.Plant();                                          //种植苹果
Fruit orange = factory.CreateFruit("Orange");                //创建桔子实例
orange.Plant();                                         //种植桔子
            Console.Read();
        }
    }

//抽象水果类
public abstract class Fruit
{
    public abstract void Plant();                     //抽象种植方法
}
//具体苹果类
public class Apple : Fruit
{
    public override void Plant()                       //种植苹果方法
    {
        Console.WriteLine("种植苹果树!");
    }
}
//具体桔子类
public class Orange : Fruit
{
    public override void Plant()                      //种植桔子方法
    {
        Console.WriteLine("种植桔子树!");
    }
}

//果园类
public class Orchard
{
    public Fruit CreateFruit(string name)           //创建水果方法
    {
        switch (name)
        {
            case "Apple":
                return new Apple();                 //创建苹果类
            case "Orange":
                return new Orange();                //创建桔子类
            default:
                throw new Exception("水果名称错误!");
        }
    }
}
}
