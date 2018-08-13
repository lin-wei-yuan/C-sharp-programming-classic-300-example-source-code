using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Composite
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "水果的分级采摘和销售";
Area bjArea = new ConcreteArea("--北京水果总部--");       //创建北京水果总部实例
Area hzSeller = new ConcreteArea("---北京水果销售分部---");//创建北京水果销售分部实例
Area hzOrchardist = new ConcreteArea("---北京水果采摘分部---");//创建北京水果采摘分部
bjArea.Add(hzSeller);                                   //添加北京水果销售分部
bjArea.Add(hzOrchardist);                               //添加北京水果采摘分部
hzSeller.Add(new FruitSeller("东城区"));                   //添加东城区
hzSeller.Add(new FruitSeller("西城区"));                   //添加西城区
hzOrchardist.Add(new Orchardist("海淀区"));                //添加海淀区
hzOrchardist.Add(new Orchardist("朝阳区"));                //添加朝阳区
bjArea.Perform();
            Console.Read();
        }
//抽象区域类
public abstract class Area
{
    protected string name;
    public Area(string name) { this.name = name; }
    public abstract void Add(Area area);                //抽象添加区域
    public abstract void Remove(Area area);             //抽象删除区域
    public abstract void Perform();                     //抽象执行方法
}
//果农类
public class Orchardist : Area
{
    public Orchardist(string name) : base(name) { }
    public override void Add(Area area) { }             //添加区域
    public override void Remove(Area area) { }          //删除区域
    public override void Perform()                      //执行方法
    {
        Console.WriteLine("{0}的果农采摘水果!", name);
    }
}
//水果销售商类
public class FruitSeller : Area
{
    public FruitSeller(string name) : base(name) { }
    public override void Add(Area area) { }             //添加区域
    public override void Remove(Area area) { }          //删除区域
    public override void Perform()                      //执行方法
    {
        Console.WriteLine("{0}的水果销售者销售水果!", name);
    }
}
//具体区域类
public class ConcreteArea : Area
{
    List<Area> areas = new List<Area>();                //区域列表
    public ConcreteArea(string name) : base(name) { }
    public override void Add(Area area)                 //添加区域
    {
        areas.Add(area);
    }
    public override void Remove(Area area)              //删除区域
    {
        areas.Remove(area);
    }
    public override void Perform()                      //执行所有区域的执行方法
    {
        Console.WriteLine(name);
        foreach (var area in areas)
        {
            area.Perform();
        }
    }
}


    }
}
