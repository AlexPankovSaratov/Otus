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
			var myClasses = new List<MyClass>
			{
				{ new MyClass(741) },
				{ new MyClass(2) },
				{ new MyClass(3) },
				{ new MyClass(4) },
			};
			var res = myClasses.GetMax<MyClass>(item => item.Value);
			var res2 = new List<int> { 1, 22, 12, 23 }.GetMax<int>(item => item);
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
