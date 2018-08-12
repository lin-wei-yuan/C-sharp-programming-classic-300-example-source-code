using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Diagnostics;
namespace PrimeNumber
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "利用并行技术判断素数";

int n = 100;                                                    //定义素数的范围
Console.WriteLine("串行计算0到{0}之间的素数为：", n);
Stopwatch watch = Stopwatch.StartNew();                         //创建测量代码运行时间类
watch.Start();                                                  //开始测量
//串行遍历0到100之间的正整数
for (uint i = 0; i < n; i++)
{
    if (SerialPrimeNumber(i)) Console.Write("{0}\t", i);        //如果i为素数就输出i
}
//以毫秒为单位输出串行处理时间
Console.WriteLine("\n\n串行For循环运行时长：{0}毫秒。\n\n", watch.ElapsedMilliseconds);
watch.Restart();                                                //开始测量
Console.WriteLine("并行计算0到{0}之间的素数为：", n);
//并行遍历0到100之间的正整数
Parallel.For(0, n, (i) =>
{
    if (ParallelPrimeNumber((uint)i)) Console.Write("{0}\t", i);//如果i为素数就输出i
});
//以毫秒为单位输出并行处理时间
Console.WriteLine("\n\n并行For循环运行时长：{0}毫秒。", watch.ElapsedMilliseconds);

            Console.ReadLine();
        }

/// 串行处理，判断一个正数是否为素数
/// <param name="n">需要判断的正整数</param>
/// <returns>是否为素数</returns>
static public bool SerialPrimeNumber(uint n)
{
    if (n < 4) return true;             //如果n小于4则则为素数
    int root = (int)Math.Sqrt(n);       //计算n的平方根
    //串行遍历2至root之间的正整数
    for (int i = 2; i <= root; i++)
    {
        Thread.Sleep(10);               //为了做算法对比引入一定的时间消耗
        if (n % i == 0) return false;   //如果n能整除i,则n为合数
    }
    return true;                        //n为素数
}

/// 并行处理，行判断一个正数是否为素数
/// <param name="n">需要判断的正整数</param>
/// <returns>是否为素数</returns>
static public bool ParallelPrimeNumber(uint n)
{
    if (n < 4) return true;             //如果n小于4则则为素数
    int root = (int)Math.Sqrt(n) + 1;   //计算n的平方根
    bool isPrime = true;                //定义布尔变量，标记n是否为素数
    //并行遍历2至root之间的正整数
    Parallel.For(2, root, (i, state) =>
    {
        Thread.Sleep(10);               //为了做算法对比引入一定的时间消耗
        if (n % i == 0)                 
        {
            isPrime = false;            //如果n能整除i,则n为合数
            state.Stop();               //中断并行循环
        }
    });
    return isPrime;
}


    }
}
