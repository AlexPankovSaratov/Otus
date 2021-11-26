using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace GameTheGuess.Implementation
{
	public class GuessTheNumberServiceVersion : GuessTheNumber
	{
		static readonly HttpClient client = new HttpClient();
		public override string GetUserMessage()
		{
			var response = client.GetAsync($"https://localhost:5001/GetUserMessage");
			return JsonConvert.DeserializeObject<string>(response.Result.Content.ReadAsStringAsync().Result);
		}
		public override void ReturnUserMessage(string message)
		{
			var response = client.PostAsync($"https://localhost:5001/ReturnUserMessage",
				new StringContent(JsonConvert.SerializeObject(message),
					Encoding.UTF8, "application/json"));
		}
		public override void ClearGameHistory()
		{

		}
	}
}
