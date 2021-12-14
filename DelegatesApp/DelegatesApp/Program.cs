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
			var q = new List<int>();
			q.GetMax<MyClass>(z => z.MyProperty);
		}
	}
	public class MyClass
	{
		public float MyProperty { get; set; }
	}
}
