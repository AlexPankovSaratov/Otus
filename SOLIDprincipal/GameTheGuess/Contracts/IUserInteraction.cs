using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameTheGuess.Contracts
{
	public interface IUserInteraction
	{
		void ReturnUserMessage(string message);
		string GetUserMessage();
		void ClearGameHistory();
	}
}
