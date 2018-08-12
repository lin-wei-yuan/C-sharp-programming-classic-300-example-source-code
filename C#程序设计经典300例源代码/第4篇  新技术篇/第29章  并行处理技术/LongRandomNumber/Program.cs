using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LongRandomNumber
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "利用并行循环生成超长随机数";

List<int> Data = new List<int>();           //创建一个列表类，用于存放随机数
Random R = new Random();                    //伪随机数生成器
//随机生成100个随机数，存放到Data列表中
Parallel.For(0, 500, i => Data.Add(R.Next(1000)));
//将所有随机数拼接成的字符串
string totalString = string.Empty;
//遍历所有数据
Parallel.For<string>(0, Data.Count,() => string.Empty,  //初始化字符串
    (i, LoopState, subString) => { return subString += Data[i].ToString(); },//返回拼接的中间结果
    (localFinally) => totalString = localFinally);    //字符串拼接的最终结果
Console.WriteLine("超长伪随机数为：\n{0}", totalString);   //输出超长伪随机数

            Console.ReadLine();
        }
    }
}
