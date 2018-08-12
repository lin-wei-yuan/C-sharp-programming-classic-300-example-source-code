using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Threading;
using System.Threading.Tasks;
using System.Collections.Concurrent;

namespace SafeCollection
{
    class Program
    {

        static void Main(string[] args)
        {
            Console.Title = "并行计算中的安全集合";

//创建线程安全队列
ConcurrentQueue<int> safeQueue = new ConcurrentQueue<int>();
//并行遍历0到100之间的整数，其值赋给整型变量i
Parallel.For(0, 100, i =>
    {
        safeQueue.Enqueue(i);       //将i放入队列中
        Console.Write(i + "\t");    //输出i
    });
Console.Write("\n进队操作完成\n\n");
int retn;                           //存放出队列的数
//使安全队列中的数据逐个出队，并赋值给retn
while (safeQueue.TryDequeue(out retn))
{
    Console.Write(retn + "\t");     //输出retn
}
Console.Write("\n出队操作完成\n\n");

Console.ReadLine();

Console.Clear();

List<int> Data = new List<int>();   //创建一个列表类，用于存放随机数
Random R = new Random();            //伪随机数生成器
//随机生成30个随机数，存放到Data列表中
for (int i = 0; i < 30; i++) Data.Add(R.Next(300));
//创建线程安全栈
ConcurrentStack<int> safeStack = new ConcurrentStack<int>();
//并行遍历栈中的数据
Parallel.ForEach(Data, data =>
    {
        safeStack.Push(data);       //数据进栈
        //输出进栈数据栈的索引和数据的值
        Console.Write("Data[{0}]={1}\t", Data.IndexOf(data), data);
    });
Console.Write("\n进栈操作完成\n\n");
//使安全栈中的数据逐一出栈，并赋值给retn
while (safeStack.TryPop(out retn))
{
    //输出出栈数据栈的索引和数据的值
    Console.Write("Data[{0}]={1}\t", Data.IndexOf(retn), retn);
}
Console.Write("\n出栈操作完成\n");
Console.ReadLine();
        }
    }
}
