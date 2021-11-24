using GameTheGuess.Implementation;
using System;

namespace SOLIDprincipal
{
	class Program
	{
		static void Main(string[] args)
		{
			var Game = new GuessTheNumber();
			Game.Run();
		}
	}
}
