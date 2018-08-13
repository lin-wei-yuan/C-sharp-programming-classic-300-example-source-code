using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

//原型模式
namespace Prototype
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "建造同样的果园";
Orchard bjOrchard = new Orchard();                      //建造北京果园
bjOrchard.Name = "北京";                                  //给果园名称赋值
bjOrchard.Apple = "北京苹果";                               //给苹果赋值
bjOrchard.Orange = "北京桔子";                              //给桔子赋值
bjOrchard.Plant();                                            //北京果园种植水果
Orchard shOrchard = bjOrchard.Clone() as Orchard;       //通过复制北京果园创建上海果园实例
shOrchard.Name = "上海";                                  //给果园名称赋值
shOrchard.Plant();                                      //上海果园种植水果
            Console.Read();
        }
//果园接口
public interface IOrchard
{
    IOrchard Clone();                                   //复制果园接口方法
}
//果园类继承果园接口
public class Orchard : IOrchard
{
    public string Name { get; set; }                    //果园名称
    public string Apple { get; set; }                   //苹果
    public string Orange { get; set; }                  //桔子
    public IOrchard Clone()                             //实例克隆接口
    {
        return new Orchard()                            //创建一个新的果园实例
        {
            Name = this.Name,
            Apple = this.Apple,
            Orange = this.Orange
        };
    }
    public void Plant()                                 //果园种植水果方法
    {
        Console.WriteLine("{0}果园种植了{1}和{2}!", this.Name, this.Apple, this.Orange);
    }
}

    }
}
