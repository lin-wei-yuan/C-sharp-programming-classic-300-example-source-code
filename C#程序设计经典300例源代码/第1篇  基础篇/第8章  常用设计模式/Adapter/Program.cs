using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

//适配器
namespace Adapter
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "果园改变种植方式";
IPlant target = new BJOrchard();                        //创建北京果园实例
target.Plant();                                         //在北京果园种植水果
target = new SHOrchard();                               //创建上海果园实例
target.Plant();                                         //在上海果园种植水果

Console.Read();
        }
//种植接口
public interface IPlant
{
    void Plant();                                       //种植水果
}
//果园类
public class Orchard
{
    /// 在指定城市种植指定水果
    /// <param name="city">果园所在城市</param>
    /// <param name="fruit">需要种植的水果</param>
    public void Plant(string city, string fruit)
    {
        Console.WriteLine("{0}果园种植{1}！", city, fruit);
    }
}
//类适配器：北京果园
public class BJOrchard : Orchard, IPlant
{
    public void Plant()
    {
        base.Plant("北京", "苹果");                         //在北京种植苹果
    }
}
//对象适配器：上海果园
public class SHOrchard : IPlant
{
    Orchard orchard = new Orchard();
    public void Plant()
    {
        orchard.Plant("上海", "桔子");                      //在上海种植桔子
    }
}

    }
}
