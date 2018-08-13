using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Proxy
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "水果的销售";
FruitAgent proxy = new FruitAgent();                    //创建代理商类
int money = 1234;
int fruit = proxy.Sell(ref money);                      //代理商向消费者卖水果
Console.WriteLine("消费者花费{0}元购买{1}千克水果！", 1234 - money, fruit);
            Console.Read();
        }
//水果销售者
public abstract class FruitSeller
{
    public abstract int Sell(ref int money);                        //抽象卖水果方法
}
//果农
public class Orchardist : FruitSeller
{
    int money = 0;                                      //卖水果收入：元
    int fruit = 100000000;                              //水果总量：吨
    public override int Sell(ref int money)            //果农卖水果：5000元/吨
    {
        int fruit = money / 5000;                       //卖出水果数量
        int price = fruit * 5000;                       //卖出水果收入
        money -= price;                                 //购买者支出的金额
        this.money += price;                            //果农收入
        this.fruit -= fruit;                            //果农卖出的水果
        Console.WriteLine("果农卖出{0}吨水果，还剩{1}吨水果，收入{2}元！", fruit, this.fruit, price);
        return fruit;
    }
}
//水果代理商
public class FruitAgent : FruitSeller
{
    int money = 500000;                              //卖水果收入：元
    int fruit = 0;                                      //水果总量：千克
    FruitSeller orchardist;
    public override int Sell(ref int money)            //卖水果：10元/千克
    {
        if (orchardist == null) orchardist = new Orchardist();
        int fruit = money / 10;                     //卖出的水果数量
        //如果水果总量不足则向果农购买水果
        if (fruit > this.fruit) this.fruit += this.orchardist.Sell(ref this.money) * 1000;
        this.fruit -= fruit;                        //代理商卖出的水果
        this.money += fruit * 10;                   //代理商的收入
        money -= fruit * 10;                        //购买者支出金额
        Console.WriteLine("代理商卖出水果{0}千克，还剩{1}千克水果，收入{2}元！", fruit, this.fruit, fruit * 10);
        return fruit;                               //卖出的水果数量
    }
}


    }
}
