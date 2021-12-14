using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExtensionMethods
{
	public static class MyExtensions
	{
		public static T GetMax<T>(this IEnumerable e, Func<T, float> getParameter)// where T : class
		{
			var enumerator = e.GetEnumerator();
			if (!enumerator.MoveNext()) return default;
			if (typeof(T) != enumerator.Current.GetType()) 
				throw new InvalidCastException("The type of the array elements does not match the type passed as a parameter.");
			float maxValue = getParameter((T)enumerator.Current);
			T resultItem = (T)enumerator.Current;
			foreach (var item in e)
			{
				var targetValue = getParameter((T)item);
				if (targetValue > maxValue)
				{
					resultItem = (T)item;
				}
			}
			return resultItem;
		}
	}
}
