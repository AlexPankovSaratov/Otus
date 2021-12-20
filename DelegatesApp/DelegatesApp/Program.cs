using ExtensionMethods;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace DelegatesApp
{
	public class Program
	{
		public static void Main(string[] args)
		{
			string folderParh = @"F:\Картинки";
			FileSearcher.FileFound += FileSearcher.WriteConsoleEvent;
			FileSearcher.Search(folderParh);
			var test1 = new List<MyClass>
			{
				{ new MyClass(741) },
				{ new MyClass(2) },
				{ new MyClass(3) },
				{ new MyClass(4) },
			}.GetMax<MyClass>(item => item.Value);
			var test2 = new List<int> { 1, 22, 12, 23 }.GetMax<int>(item => item);
			Console.WriteLine("Результат поиска максимального значения:");
			Console.WriteLine("test1: " + test1.Value);
			Console.WriteLine("test2: " + test2);
		}
	}
	public class MyClass
	{
		public float Value;

		public MyClass(float Value)
		{
			this.Value = Value;
		}
	}
}
