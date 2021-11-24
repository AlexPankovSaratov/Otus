using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameTheGuess.Contracts
{
	public enum ComparisonOperators
	{
		equals,
		more,
		smaller
	}
	public interface IGameTheGuess<T>
	{
		T MinValue { get; set; }
		T MaxValue { get; set; }
		int NumberOfAttempts { get; set; }
		void GenerateNewRandomValue();
		ComparisonOperators CompareRandomValue();
		void Run();
	}
}
