using Newtonsoft.Json;
using Reflection;
using System;
using System.Diagnostics;
using System.Text;

namespace TestConsole
{
	class Program
	{
		static void Main(string[] args)
		{
			Console.WriteLine(MeasurementExecutionTime());			
		}
		private static string MeasurementExecutionTime()
		{
			int numIterations = 100000;
			StringBuilder stringBuilder = new StringBuilder();
			Stopwatch stopwatch = new Stopwatch();
			string serStr = "";
			F deserRes = null;

			stringBuilder.Append(@"Сериализуемый класс: class F { int i1, i2, i3, i4, i5;}
  код сериализации - десериализации: В  классе CsvSerealizer
  количество замеров: " + numIterations + Environment.NewLine + "мой рефлекшен: ");
			stopwatch.Start();
			for (int i = 0; i < numIterations; i++)
			{
				serStr = CsvSerealizer.SerializeFromObjectToCSV(F.Get());
			}
			stopwatch.Stop();
			stringBuilder.Append(Environment.NewLine + "Полученная строка = " + serStr);
			stringBuilder.Append(Environment.NewLine + "Время на сериализацию = " + stopwatch.ElapsedMilliseconds + " мс");
			stopwatch.Restart();
			for (int i = 0; i < numIterations; i++)
			{
				deserRes = CsvSerealizer.DeserializeFromCSVToInstance<F>(serStr);
			}
			stopwatch.Stop();
			stringBuilder.Append(Environment.NewLine + "Время на десериализацию = " + stopwatch.ElapsedMilliseconds + " мс");
			stopwatch.Restart();
			for (int i = 0; i < numIterations; i++)
			{
				serStr = JsonConvert.SerializeObject(F.Get());
			}
			stopwatch.Stop();
			stringBuilder.Append(Environment.NewLine + " стандартный механизм (NewtonsoftJson): ");
			stringBuilder.Append(Environment.NewLine + "Полученная строка = " + serStr);
			stringBuilder.Append(Environment.NewLine + "Время на сериализацию = " + stopwatch.ElapsedMilliseconds + " мс");
			stopwatch.Restart();
			for (int i = 0; i < numIterations; i++)
			{
				deserRes = JsonConvert.DeserializeObject<F>(serStr);
			}
			stopwatch.Stop();
			stringBuilder.Append(Environment.NewLine + "Время на десериализацию = " + stopwatch.ElapsedMilliseconds + " мс");

			return stringBuilder.ToString();
		}
	}
}
