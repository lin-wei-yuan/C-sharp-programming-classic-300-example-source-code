using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.Concurrent;
using System.Diagnostics;
using System.Threading;

namespace ParallelLinq
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "利用PLinq实现集合的并行化查询";

Stopwatch watch = new Stopwatch();          //初始化时间测量器
var dataset = Enumerable.Range(1, 100);   //生成1到100的整数序列
watch.Start();                              //开始测量时间
var res1 = dataset.Where(i => i % 3 == 0);  //串行查询能整除3的整数
Console.WriteLine("利用Where方法串行查询耗时：{0}微秒\n", watch.ElapsedTicks / 10);
watch.Restart();                            //重置时间测量器
//并行查询能整除3的整数
var res2 = dataset.AsParallel().Where(i => i % 3 == 0);//并行查询能整除3的整数
Console.WriteLine("利用Where方法并行查询能整除3的整数耗时：{0}微秒\n", watch.ElapsedTicks / 10);
watch.Restart();                            //重置时间测量器
//并行查询能整除3的整数，并对结果进行排序
var res3 = dataset.AsParallel().AsOrdered().Where(i => i % 3 == 0);
Console.WriteLine("利用Where方法并行查询能整除3的整数，并对结果进行排序耗时：{0}微秒\n", watch.ElapsedTicks / 10);
watch.Restart();                            //重置时间测量器
//利用LINQ语句并行查询能整除3的整数，并对结果进行排序
var res4 = from i in dataset.AsParallel().AsOrdered() where i % 3 == 0 select i;
Console.WriteLine("利用LINQ语句并行查询能整除3的整数，并对结果进行排序耗时：{0}微秒\n", watch.ElapsedTicks / 10);
watch.Restart();                            //重置时间测量器
//串行输出查询结果
foreach (var item in res4) { Thread.Sleep(1); Console.Write("{0,3}", item); }
Console.WriteLine("\n串行输出查询结果：{0:N}微秒", watch.ElapsedTicks / 10);
watch.Restart();                            //重置时间测量器
//并行输出查询结果
res2.ForAll((item) => { Thread.Sleep(1); Console.Write("{0,3}", item); });
Console.WriteLine("\n并行输出查询结果：{0:N}微秒", watch.ElapsedTicks / 10);

            Console.ReadLine();
        }
    }
}
