using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

//装饰者模式
namespace Decorator
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "果园改进种植方法";
Fruit myClass = new Apple();                        //创建苹果实例
FruitDecorator Loosen = new LoosenSoilDecorator(myClass);//松土装饰者装饰苹果树
FruitDecorator Manure = new ManureDecorator(Loosen);//灌溉装饰者装饰松土装饰者
Manure.Plant();                                     //实现种植、松土和灌溉
            Console.Read();
        }
//抽象水果类
public abstract class Fruit
{
    public abstract void Plant();
}
//苹果类
public class Apple : Fruit
{
    public override void Plant()                        //种植苹果树
    {
        Console.WriteLine("种植苹果树!");
    }
}
//水果抽象装饰者
public abstract class FruitDecorator : Fruit
{
    protected Fruit fruit;
    public FruitDecorator(Fruit fruit)
    {
        this.fruit = fruit;
    }
    public override void Plant()
    {
        if (this.fruit != null) this.fruit.Plant();     //种植水果
    }
}
//松土装饰者
public class LoosenSoilDecorator : FruitDecorator
{
    public LoosenSoilDecorator(Fruit fruit) : base(fruit) { }
    public override void Plant()
    {
        base.Plant();
        Loosen();
    }
    private void Loosen()                               //为果树松土
    {
        Console.WriteLine("为果树松土!");
    }
}
//灌溉装饰者
public class ManureDecorator : FruitDecorator
{
    public ManureDecorator(Fruit fruit) : base(fruit) { }
    public override void Plant()
    {
        base.Plant();
        Manure();
    }
    private void Manure()                               //为果树浇水
    {
        Console.WriteLine("为果树浇水!");
    }
}


    }
}
