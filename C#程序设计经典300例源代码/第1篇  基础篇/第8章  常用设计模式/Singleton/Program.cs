using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

//单例模式
namespace Singleton
{
    class Program
    {
static void Main(string[] args)
{
    Console.Title = "果园喷洒杀虫剂";
Helicopter bjHelicopter = Helicopter.Instance;          //获取北京直升飞机
bjHelicopter.SprayInsecticide("北京");                    //为北京果园喷洒杀虫剂
Helicopter shHelicopter = Helicopter.Instance;          //获取上海直升飞机
bjHelicopter.SprayInsecticide("上海");                    //为上海果园喷洒杀虫剂

Console.Read();
}
//直升飞机类
class Helicopter
{
    static Helicopter helicopter;                       //直升飞机实例
    public static Helicopter Instance
    {
        get
        {
            if (helicopter == null)                     //如果直升飞机未创建
                helicopter = new Helicopter();          //延迟创建直升飞机实例
            return helicopter;
        }
    }
    protected Helicopter() { }                          //直升飞机受保护的构造方法
    int insecticide = 100;                              //杀虫剂
    //为指定城市的果园喷洒杀虫剂
    public void SprayInsecticide(string city)
    {
        this.insecticide -= 50;
        Console.WriteLine("为{0}的果园喷洒杀虫剂！", city);
        if (this.insecticide == 0)
            Console.WriteLine("杀虫剂已用完！");
        else
            Console.WriteLine("杀虫剂还剩{0}吨!", this.insecticide);
    }
}
    }
}
