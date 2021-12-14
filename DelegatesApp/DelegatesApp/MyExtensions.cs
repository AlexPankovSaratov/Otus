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
		public static T GetMax<T>(this IEnumerable e, Func<T, float> getParameter) where T : class
		{

			float maxValue = getParameter((T)e.GetEnumerator().Current);
			T resultItem = (T)e.GetEnumerator();
			foreach (var item in e)
			{
				var targetValue = getParameter((T)item);
				if (targetValue > maxValue)
				{
					resultItem = (T)e;
				}
			}
			return resultItem;
		}
	}
}
