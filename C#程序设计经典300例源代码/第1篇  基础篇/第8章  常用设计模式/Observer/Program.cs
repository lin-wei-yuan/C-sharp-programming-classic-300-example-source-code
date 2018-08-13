using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

namespace Observer
{
    class Program
    {
static void Main(string[] args)
{
    Console.Title = "果园的监控";
Orchard orchard = new Orchard();                        //创建果园实例
IMonitor bjMonitor = new Monitor(orchard, "北京果园监控员");//北京果园监控员
IMonitor shMonitor = new Monitor(orchard, "上海果园监控员");//上海果园监控员
orchard.State = "苹果园!";                               //将果园监控状态改为苹果园
orchard.Notify();                                       //通知监控员更新监控状态
            Console.Read();
}
//果园接口
public interface IOrchard
{
    void Add(IMonitor monitor);                        //添加监控员接口方法
    void Remove(IMonitor monitor);                     //移除监控员接口方法
    void Notify();                                      //通知监控员更新监控状态接口方法
}
//果园类
public class Orchard : IOrchard
{
    private List<IMonitor> monitors = new List<IMonitor>();//监控员列表
    public string State { get; set; }
    public void Add(IMonitor monitor)                   //添加监控员
    {
        monitors.Add(monitor);
    }
    public void Remove(IMonitor monitor)                //删除监控员
    {
        monitors.Remove(monitor);
    }
    public void Notify()
    {
        foreach (var monitor in monitors) monitor.Update();
    }
}
//果园监控员接口
public interface IMonitor
{
    void Update();                                      //更新监督状态接口方法
}
//果园监控员类
public class Monitor : IMonitor
{
    private Orchard orchard;                            //果园实例引用
    private string name;                                //监控者名称
    public Monitor(Orchard myClass, string name)
    {
        this.orchard = myClass;
        this.orchard.Add(this);                         //将自身添加到果园监控者列表中
        this.name = name;
    }
    public void Update()
    {
        Console.WriteLine("{0}监控{1}", name, orchard.State);
    }
}
    }
}
