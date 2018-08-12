using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Diagnostics;
using System.Threading.Tasks;
using System.Threading;

namespace MatrixMultiply
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "利用并行技术实现矩阵运算";

//二维矩阵1和二维矩阵2的行数和列数
int rowM1 = 10, columnM1 = 15, rowM2 = 15, columnM2 = 19;
//创建二维矩阵1和二维矩阵2
int[,] matrix1 = new int[rowM1, columnM1];
int[,] matrix2 = new int[rowM2, columnM2];
Random R = new Random();                    //伪随机数发生器
for (int r = 0; r < rowM1; r++)
    for (int c = 0; c < columnM1; c++)
        matrix1[r, c] = R.Next(10);         //给矩阵1赋值
for (int r = 0; r < rowM2; r++)
    for (int c = 0; c < columnM2; c++)
        matrix2[r, c] = R.Next(10);         //给矩阵2赋值

Stopwatch watch = Stopwatch.StartNew();     //初始化时间测量器
int[,] matrix3;                             //矩阵1和矩阵2相乘的结果矩阵
watch.Start();                              //开始测量
matrix3 = SerialMultiply(matrix1, matrix2); //串行计算矩阵相乘
Console.WriteLine("\n\n串行化矩阵乘法运行时长：{0}毫秒。\n\n", watch.ElapsedMilliseconds);

Console.ReadLine();
Console.Clear();

watch.Restart();                            //重置时间测量器
matrix3 = ParallelMultiply(matrix1, matrix2);//并行计算矩阵相乘
Console.WriteLine("\n\n并行化矩阵乘法运行时长：{0}毫秒。\n\n", watch.ElapsedMilliseconds);

Console.ReadLine();
        }

/// 串行计算矩阵相乘
/// <param name="m1">矩阵1</param>
/// <param name="m2">矩阵2</param>
/// <returns>矩阵1和矩阵2相乘后的矩阵</returns>
static int[,] SerialMultiply(int[,] m1, int[,] m2)
{
    int rowM1 = m1.GetLength(0),                //矩阵1行数
        columnM1 = m1.GetLength(1),             //矩阵1列数
        rowM2 = m2.GetLength(0),                //矩阵2行数
        columnM2 = m2.GetLength(1);             //矩阵2列数
    //如果矩阵1的列数与矩阵2的行数不等，则无法计算
    if (columnM1 != rowM2) return null;
    //初始化运算结果矩阵
    int[,] result = new int[rowM1, columnM2];
    for (int r = 0; r < rowM1; r++)
    {//串行遍历结果矩阵的每一行
        for (int c = 0; c < columnM2; c++)
        {//串行遍历结果矩阵的每一列
            int sum = 0;                        //结果矩阵第r行第c列的元素值
            for (int n = 0; n < columnM1; n++)
            {//串行遍历矩阵1第r行和矩阵2第c列的columnM1个元素
                Thread.Sleep(1);                //为作对比实例适当延长算法时间
                //矩阵1第r行元素与矩阵2第c列元素分别相乘求和
                sum += m1[r, n] * m2[n, c];
            }
            //求和结果sum即为结果矩阵第r行第c列的元素值
            result[r, c] = sum;
            Console.Write("{0} ", result[r, c]);//输出结果矩阵r行c列的元素值
        }
        Console.WriteLine();
    }
    return result;                              //返回结果矩阵
}

/// 并行计算矩阵相乘
/// <param name="m1">矩阵1</param>
/// <param name="m2">矩阵2</param>
/// <returns>矩阵1和矩阵2相乘后的矩阵</returns>
static int[,] ParallelMultiply(int[,] m1, int[,] m2)
{
    int rowM1 = m1.GetLength(0),                //矩阵1行数
        columnM1 = m1.GetLength(1),             //矩阵1列数
        rowM2 = m2.GetLength(0),                //矩阵2行数
        columnM2 = m2.GetLength(1);             //矩阵2列数
    //如果矩阵1的列数与矩阵2的行数不等，则无法计算
    if (columnM1 != rowM2) return null;
    //初始化运算结果矩阵
    int[,] result = new int[rowM1, columnM2];
Parallel.For(0, rowM1, r =>
{//并行遍历结果矩阵的每一行
    Parallel.For(0, columnM2, c =>
    {//并行遍历结果矩阵的每一列
        int sum = 0;
        //并行遍历矩阵1第r行和矩阵2第c列的columnM1个元素
        Parallel.For<int>(0, columnM1, () => 0,
            (n, state, subSum) =>
            {
                Thread.Sleep(1);            //为作对比实例适当延长算法时间
                //矩阵1第r行元素与矩阵2第c列元素分别相乘求和
                subSum += m1[r, n] * m2[n, c];
                return subSum;              //返回中间迭代值
            },
            //将求和结果赋值给sum
            (final) => Interlocked.Add(ref sum, final)
        );
        //求和结果sum即为结果矩阵第r行第c列的元素值
        result[r, c] = sum;
        Console.Write("{0} ", result[r, c]);//输出结果矩阵r行c列的元素值
    });
    Console.WriteLine();
});

    return result;
}


    }
}
