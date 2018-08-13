using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Mediator
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "果园之间互换水果品种";
BJSHOrchardist orchardist = new BJSHOrchardist();       //创建果农实例
Orchard bjBJOrchard = new BJOrchard(orchardist);        //创建北京果园
Orchard shBJOrchard = new SHOrchard(orchardist);        //创建上海果园
orchardist.BJOrchard = bjBJOrchard;
orchardist.SHOrchard = shBJOrchard;
bjBJOrchard.PlantRemote();                              //北京果园种植上海水果
shBJOrchard.PlantRemote();                              //上海果园种植北京水果
            Console.Read();
        }
//抽象果农类
public abstract class Orchardist
{
    public abstract void PlantRemote(Orchard orchard);  //种植异地水果
}
//北京上海果农
public class BJSHOrchardist : Orchardist
{
    Orchard bjOrchard;                                  //北京果园
    Orchard shOrchard;                                  //上海果园
    public Orchard BJOrchard { set { bjOrchard = value; } }
    public Orchard SHOrchard { set { shOrchard = value; } }
    public override void PlantRemote(Orchard orchard)
    {
        if (orchard == this.bjOrchard)
        {
            Console.Write("北京果园");
            shOrchard.Plant();                          //种植上海水果
        }
        else if (orchard == this.shOrchard)
        {
            Console.Write("上海果园");
            bjOrchard.Plant();                          //种植北京水果
        }
    }
}
//抽象果园类
public abstract class Orchard
{
    protected Orchardist orchardist;                    //果农实例引用
    public Orchard(Orchardist orchardist)
    {
        this.orchardist = orchardist;
    }
    public abstract void PlantRemote();                 //种植异地水果抽象方法
    public abstract void Plant();                       //种植水果抽象方法
}
//北京果园类
public class BJOrchard : Orchard
{
    public BJOrchard(Orchardist orchardist)
        : base(orchardist) { }
    public override void PlantRemote()                  //上海果园种植异地水果方法
    {
        this.orchardist.PlantRemote(this);
    }
    public override void Plant()                        //上海果园种植水果方法
    {
        Console.WriteLine("种植北京水果");
    }
}
//上海果园类
public class SHOrchard : Orchard
{
    public SHOrchard(Orchardist orchardist)
        : base(orchardist) { }
    public override void PlantRemote()                  //上海果园种植异地水果方法
    {
        this.orchardist.PlantRemote(this);
    }
    public override void Plant()                        //上海果园种植水果方法
    {
        Console.WriteLine("种植上海水果");
    }
}


    }
}
