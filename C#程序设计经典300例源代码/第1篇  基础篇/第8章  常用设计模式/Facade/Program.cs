using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

//外观模式
namespace Facade
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "种植不同种类的水果";
Plant plant = new Plant();
plant.PlantAppleOrange();                               //北京果园种植苹果和桔子
plant.PlantOrangeBanana ();                             //上海果园种植桔子和香蕉
            Console.Read();
        }
//种植类
public class Plant
{
    Apple apple = new Apple();                          //创建苹果类
    Orange orange = new Orange();                       //创建桔子类
    Banana banana = new Banana();                       //创建香蕉类
    public void PlantAppleOrange()
    {
        Console.WriteLine("------北京果园------");
        apple.PlantApple();                             //种植苹果树
        orange.PlantOrange();                           //种植桔子树
    }
    public void PlantOrangeBanana()
    {
        Console.WriteLine("------上海果园------");
        orange.PlantOrange();                           //种植桔子树
        banana.PlantBanana();                           //种植香蕉树
    }
}
//苹果类
public class Apple
{
    public void PlantApple()                            //种植苹果树
    {
        Console.WriteLine("种植苹果树!");
    }
}
//桔子类
public class Orange
{
    public void PlantOrange()                           //种植桔子树
    {
        Console.WriteLine("种植桔子树!");
    }
}
//香蕉类
public class Banana
{
    public void PlantBanana()                           //种植香蕉树
    {
        Console.WriteLine("种植香蕉树!");
    }
}
    }
}
