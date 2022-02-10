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
		private static int listCountElements = 100000000;
		static void Main(string[] args)
		{
			List<int> list = new List<int>();
			long elapsedTicks;
			Random random = new Random();
			for (int i = 0; i < listCountElements; i++)
			{
				list.Add(random.Next(-1000, 1001));
			}
			СalculateSumInSingleThread(list);
			СalculateSumInMultiThread(list);
			СalculateSumInParallelLinq(list);
			Console.ReadKey();
		}

		private static void СalculateSumInParallelLinq(List<int> list)
		{
			Stopwatch stopWatch = new Stopwatch();
			long sumResult = 0;
			stopWatch.Start();
			sumResult = list.AsParallel().Sum();
			stopWatch.Stop();
			Console.WriteLine($"Сумма {listCountElements} элементов = {sumResult}.Вычисление в ParallelLinq. Затраченное время в тактах таймера = {stopWatch.ElapsedTicks}");
		}

		private static void СalculateSumInMultiThread(List<int> list)
		{
			Stopwatch stopWatch = new Stopwatch();
			var countTasks = 10000;
			long sumResult = 0;
			List<Task<int>> tasks = new List<Task<int>>();
			var arrays = list.ToArray().Split<int>(countTasks);
			stopWatch.Start();
			foreach (var item in arrays)
			{
				tasks.Add(Task.Run(() =>
				{
					return  item.Sum();
				}));
			}
			Task.WaitAll(tasks.ToArray());
			foreach (var item in tasks)
			{
				sumResult += item.Result;
			}
			stopWatch.Stop();
			Console.WriteLine($"Сумма {listCountElements} элементов = {sumResult}.Многопоточное вычесление. Затраченное время в тактах таймера = {stopWatch.ElapsedTicks}");
		}

		private static long СalculateSumInSingleThread(List<int> list)
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
