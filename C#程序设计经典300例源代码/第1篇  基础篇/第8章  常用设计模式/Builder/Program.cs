using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

//建造者模式
namespace Builder
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "建造不同的果园";
//创建北京果园建造指导者
OrchardDirector bjOrchardDirector = new OrchardDirector(new BJOrchardBuilder());
Orchard bjOrchard = bjOrchardDirector.Construct();      //北京果园指导者建造北京果园
bjOrchard.Plant();                                      //北京果园种植水果
//创建上海果园建造指导者
OrchardDirector shOrchardDirector = new OrchardDirector(new SHOrchardBuilder());
Orchard shOrchard = shOrchardDirector.Construct();      //上海果园指导者建造上海果园
shOrchard.Plant();                                      //上海果园种植水果
            Console.Read();
        }
//果园
public class Orchard
{
    string name;                                        //果园名称
    public string Apple { get; set; }                   //苹果
    public string Orange { get; set; }                  //桔子
    public Orchard(string name)                         //构造函数
    {
        this.name = name;
        Console.WriteLine("建造{0}果园！", name);
    }
    public void Plant()                                   //果园种植水果方法
    {
        Console.WriteLine("{0}果园种植{1}和{2}！", name, Apple, Orange);
    }
}
//果园建造指导者
public class OrchardDirector
{
    OrchardBuilder orchardBuilder;                      //果园建造者
    public OrchardDirector(OrchardBuilder myClassBuilder)
    {
        this.orchardBuilder = myClassBuilder;           //为果园建造者赋值
    }
    public Orchard Construct()
    {
        orchardBuilder.BuildApple();                    //创建苹果
        orchardBuilder.BuildOrange();                   //创建桔子
        return orchardBuilder.GetOrchard();             //返回果园实例
    }
}
//果园抽象建造者
public abstract class OrchardBuilder
{
    public abstract void BuildApple();
    public abstract void BuildOrange();
    public abstract Orchard GetOrchard();
}
//北京果园建造者
public class BJOrchardBuilder : OrchardBuilder
{
    Orchard bjOrchard = new Orchard("北京");            //北京果园
    public override void BuildApple()                   //创建北京苹果
    {
        bjOrchard.Apple = "北京苹果";
    }
    public override void BuildOrange()                  //创建北京桔子
    {
        bjOrchard.Orange = "北京桔子";
    }
    public override Orchard GetOrchard()                //获取北京果园实例
    {
        return bjOrchard;
    }
}
//上海果园建造者
public class SHOrchardBuilder : OrchardBuilder
{
    Orchard shOrchard = new Orchard("上海");            //上海果园
    public override void BuildApple()                   //创建上海苹果
    {
        shOrchard.Apple = "上海苹果";
    }
    public override void BuildOrange()                  //创建上海桔子
    {
        shOrchard.Orange = "上海桔子";
    }
    public override Orchard GetOrchard()                //获取上海果园实例
    {
        return shOrchard;
    }
}
    }
}
