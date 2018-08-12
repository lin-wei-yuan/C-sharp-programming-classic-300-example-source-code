using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Exception
{
    class Program
    {
static void Main(string[] args)
{
    Console.Title = "并行计算中的异常处理";

try
{
    Parallel.Invoke(Task1, Task2);              //并行执行多个任务
}
catch (AggregateException ex)                   //捕获多个异常
{
    foreach (var single in ex.InnerExceptions)  //遍历多个异常
    {
        Console.WriteLine(single.Message);
    }
}

Console.ReadLine();
}
//任务1
static void Task1()
{
    Thread.Sleep(new Random().Next(1000));
    throw new System.Exception("任务1抛出的异常");
}
//任务2
static void Task2()
{
    Thread.Sleep(new Random().Next(1000));
    throw new System.Exception("任务2抛出的异常");
}
    }
}
