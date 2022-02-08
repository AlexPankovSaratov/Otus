using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace MultithreadedProject
{
	class Program
	{
		private static object lockObj = new object();
		private static int listCountElements = 10000000;
		static void Main(string[] args)
		{
			List<int> list = new List<int>();
			long elapsedTicks;
			Random random = new Random();
			for (int i = 0; i < listCountElements; i++)
			{
				list.Add(random.Next(-100, 101));
			}
			calculateSumInSingleThread(list);
			calculateSumInMultiThread(list);
			calculateSumInParallelLinq(list);
			Console.ReadKey();
		}

		private static void calculateSumInParallelLinq(List<int> list)
		{
			Stopwatch stopWatch = new Stopwatch();
			long sumResult = 0;
			stopWatch.Start();
			sumResult = list.AsParallel().Sum();
			stopWatch.Stop();
			Console.WriteLine($"Сумма {listCountElements} элементов = {sumResult}.Вычисление в ParallelLinq. Затраченное время в тактах таймера = {stopWatch.ElapsedTicks}");
		}

		private static object qwe(int n)
		{
			throw new NotImplementedException();
		}

		private static void calculateSumInMultiThread(List<int> list)
		{
			Stopwatch stopWatch = new Stopwatch();
			long sumResult = 0;
			stopWatch.Start();
			foreach (var item in list)
			{
				Task.Run(() =>
				{
					lock (lockObj)
					{
						sumResult += item;
					}
				});
			}
			stopWatch.Stop();
			Console.WriteLine($"Сумма {listCountElements} элементов = {sumResult}.Многопоточное вычесление. Затраченное время в тактах таймера = {stopWatch.ElapsedTicks}");
		}

		private static long calculateSumInSingleThread(List<int> list)
		{
			Stopwatch stopWatch = new Stopwatch();
			long sumResult = 0;
			stopWatch.Start();
			foreach (var item in list)
			{
				sumResult += item;
			}
			stopWatch.Stop();
			Console.WriteLine($"Сумма {listCountElements} элементов = {sumResult}.Вычесление одном потоке. Затраченное время в тактах таймера = {stopWatch.ElapsedTicks}");
			return sumResult;
		}
	}
}
