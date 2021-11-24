using GameTheGuess.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameTheGuess.Implementation
{
	public class GuessTheNumber : IGameTheGuess<int>, IUserInteraction
	{	
		private int _randomValue;
		private int _inputValue;
		private int _minValue;
		private int _maxValue;
		private int _numberOfAttempts;

		public GuessTheNumber()
		{
			ReturnUserMessage("Hellow! let's play.");
			MinValue = 0;
			MaxValue = 100;
			NumberOfAttempts = 5;
		}

		public int MinValue { 
			get { return _minValue; } 
			set {
				if (value < _maxValue  || (_maxValue == 0 && _minValue == 0))
				{
					_minValue = value;
					ReturnUserMessage("The minimum value is set:  " + _minValue);
				}
				else
				{
					ReturnUserMessage("The minimum value cannot be greater than the maximum");
				}
			} 
		}
		public int MaxValue
		{
			get { return _maxValue; }
			set
			{
				if (value > _minValue || (_maxValue == 0 && _minValue == 0))
				{
					_maxValue = value;
					ReturnUserMessage("The maximum value is set:  " + _maxValue);
				}
				else
				{
					ReturnUserMessage("The maximum value cannot be less than the minimum");
				}
			}
		}
		public int NumberOfAttempts { 
			get { return _numberOfAttempts; } 
			set {
				if (value < 1)
				{
					ReturnUserMessage("The number of attempts must be greater than 0");
				}
				else
				{
					_numberOfAttempts = value;
					ReturnUserMessage("The number of attempts value is set:  " + _numberOfAttempts);
				}
			} 
		}
		public ComparisonOperators CompareRandomValue()
		{
			if (_inputValue < _randomValue) return ComparisonOperators.more;
			if (_inputValue > _randomValue) return ComparisonOperators.smaller;
			return ComparisonOperators.equals;
		}
		public void GenerateNewRandomValue()
		{
			Random random = new Random();
			_randomValue = random.Next(_minValue, _maxValue);
		}
		public void Run()
		{
			bool newGame = true;
			while (newGame)
			{
				var localNumberOfAttempts = _numberOfAttempts;
				GenerateNewRandomValue();
				ReturnUserMessage(Environment.NewLine + "I thought of a number, will you try to guess it?");
				while ((CompareRandomValue() != ComparisonOperators.equals && localNumberOfAttempts > 0) || localNumberOfAttempts == _numberOfAttempts)
				{
					ReturnUserMessage("Enter your new guess:");
					int.TryParse(GetUserMessage(), out _inputValue);
					localNumberOfAttempts--;
					if (CompareRandomValue() != ComparisonOperators.equals)
					{
						ReturnUserMessage("Oh no, you didn't guess.");
						if (CompareRandomValue() != ComparisonOperators.more)
						{
							ReturnUserMessage("Your value is bigger than mine.");
						}
						if (CompareRandomValue() != ComparisonOperators.smaller)
						{
							ReturnUserMessage("Your value is less than mine.");
						}
						if (localNumberOfAttempts > 0)
						{
							ReturnUserMessage(string.Format("You have {0} attempts left", localNumberOfAttempts));
						}
						else
						{
							ReturnUserMessage("You have run out of attempts");
						}
					}
				}
				if (CompareRandomValue() == ComparisonOperators.equals)
				{
					ReturnUserMessage("Hurray! You guessed.");
				}
				ReturnUserMessage(@"Will we play again? If yes, then write  ""Yes"" ");
				if (GetUserMessage() != "yes")
				{
					newGame = false;
				}
				ClearGameHistory();
			}
		}

		public virtual string GetUserMessage()
		{
			return Console.ReadLine().Trim().ToLower();
		}
		public virtual void ReturnUserMessage(string message)
		{
			Console.WriteLine(message);
		}
		public virtual void ClearGameHistory()
		{
			Console.Clear();
		}
	}
}
