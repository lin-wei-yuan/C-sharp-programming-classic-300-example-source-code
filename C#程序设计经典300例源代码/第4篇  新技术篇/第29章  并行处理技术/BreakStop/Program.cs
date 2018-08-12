using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;
using System.Collections.Concurrent;

//并行计算中的中断和跳出
namespace BreakStop
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "并行计算中的中断和跳出";

Random R = new Random();             //实例化伪随机数生成器
//并行遍历1到100之间的整数
Parallel.For(1, 100, (i, state) =>
{
    Thread.Sleep(R.Next(10));  //为了对比实验适当延长单次循环处理时间
    if (i > 50) state.Break(); //当遍历完1到50之间所有的数就跳出并行循环
    Console.Write(i + "\t");   //输出遍历的i
});
Console.Write("\nBreak跳出循环\n");
//并行遍历1到100之间的整数
Parallel.For(1, 100, (i, state) =>
{
    Thread.Sleep(R.Next(10));       //为了对比实验适当延长单次循环处理时间
    if (i > 50) state.Stop();       //当遍历到第一个大于50的数时就跳出并行循环
    Console.Write(i + "\t");        //输出遍历的i
});
Console.Write("\nStop跳出循环\n");

            Console.ReadLine();

        }

    }
}
