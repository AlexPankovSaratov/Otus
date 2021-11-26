using GameTheGuess.Implementation;
using System;

namespace SOLIDprincipal
{
	class Program
	{
		static void Main(string[] args)
		{
			GuessTheNumber Game = new GuessTheNumber();
			Game.Run();
			Game = new GuessTheNumberServiceVersion();
			Game.Run();
		}
	}
}
