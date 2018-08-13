using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

//工厂方法模式
namespace FactoryMethod
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "果园引进新品种";
Orchard appleOrchard = new AppleOrchard();              //创建苹果园实例
Fruit apple = appleOrchard.CreateFruit();               //苹果园创建苹果实例
apple.Plant();                                          //种植苹果
Orchard orangeOrchard = new OrangeOrchard();            //创建桔子园实例
Fruit orange = orangeOrchard.CreateFruit();             //桔子园创建桔子实例
orange.Plant();                                         //种植桔子
Orchard bananaOrchard = new BananaOrchard();            //创建香蕉园实例
Fruit banana = bananaOrchard.CreateFruit();             //香蕉园创建香蕉实例
banana.Plant();                                         //种植香蕉

            Console.Read();
        }
    }
//抽象水果类
public abstract class Fruit
{
    public abstract void Plant();                         //抽象种植水果方法
}
//具体苹果类
public class Apple : Fruit
{
    public override void Plant()                          //种植苹果方法
    {
        Console.WriteLine("种植又红又粉的苹果!");
    }
}
//具体桔子类
public class Orange : Fruit
{
    public override void Plant()                          //种植桔子方法
    {
        Console.WriteLine("种植又大又圆的桔子!");
    }
}
//具体香蕉类
public class Banana : Fruit
{
    public override void Plant()                          //种植香蕉方法
    {
        Console.WriteLine("种植又软又甜的香蕉!");
    }
}
//抽象水果园类
public abstract class Orchard
{
    public abstract Fruit CreateFruit();                //抽象创建水果方法
}
//苹果园类
public class AppleOrchard : Orchard
{
    public override Fruit CreateFruit()
    {
        return new Apple();                             //创建苹果实例
    }
}
//桔子园类
public class OrangeOrchard : Orchard
{
    public override Fruit CreateFruit()
    {
        return new Orange();                            //创建桔子实例
    }
}
//香蕉园类
public class BananaOrchard : Orchard
{
    public override Fruit CreateFruit()
    {
        return new Banana();                            //创建香蕉实例
    }
}
}
