using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Visitor
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "果农培育果树";
Orchard orchard = new Orchard();                             //创建果园实例
orchard.Attach(new Apple());                                 //向果园中添加苹果树
orchard.Attach(new Orange());                                //向果园中添加桔子树
orchard.Accept(new LoosenOrchardist());                      //松土果农为果树松土
orchard.Accept(new ManureOrchardist());                      //浇水果农为果树浇水
            Console.Read();
        }
//抽象果农类
public abstract class Orchardist
{
    public abstract void VisitApple(Apple apple);       //果农种植苹果树抽象方法
    public abstract void VisitOrange(Orange orange);    //果农种植桔子树抽象方法
}
//负责松土的果农
public class LoosenOrchardist : Orchardist
{
    public override void VisitApple(Apple apple)        //果农为苹果树松土
    {
        apple.PlantApple();
        Console.WriteLine("果农为苹果树松土！");
    }
    public override void VisitOrange(Orange orange)     //果农为桔子树松土
    {
        orange.PlantOrange();
        Console.WriteLine("果农为桔子树松土");
    }
}
//负责浇水的果农
public class ManureOrchardist : Orchardist
{
    public override void VisitApple(Apple myClassA)     //果农为苹果树浇水
    {
        myClassA.PlantApple();
        Console.WriteLine("果农为苹果树浇水");
    }
    public override void VisitOrange(Orange myClassB)   //果农为桔子树浇水
    {
        myClassB.PlantOrange();
        Console.WriteLine("果农为桔子树浇水");
    }
}
//抽象水果类
public abstract class Fruit
{
    public abstract void Accept(Orchardist orchardist);
}
//抽象苹果类
public class Apple : Fruit
{
    public override void Accept(Orchardist orchardist)     //果农种植苹果树
    {
        orchardist.VisitApple(this);
    }
    public void PlantApple()                            //种植苹果树
    {
        Console.WriteLine("培育苹果树!");
    }
}
//抽象桔子类
public class Orange : Fruit
{
    public override void Accept(Orchardist orchardist)
    {
        orchardist.VisitOrange(this);
    }
    public void PlantOrange()                           //种植桔子树
    {
        Console.WriteLine("培育桔子树!");
    }
}
//果园
public class Orchard
{
    List<Fruit> fruits = new List<Fruit>();             //果园种植的果树
    public void Attach(Fruit fruit)                     //添加果树
    {
        fruits.Add(fruit);
    }
    public void Detach(Fruit fruit)                     //移除果树
    {
        fruits.Remove(fruit);
    }
    public void Accept(Orchardist orchardist)           //果树接受果农的培育
    {
        foreach (Fruit fruit in fruits)
        {
            fruit.Accept(orchardist);
        }
    }
}
    }
}
