using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DelegatesApp
{
	internal static class FileSearcher
	{
		private static bool _subscription = true;

		public static event EventHandler FileFound;

		public static void Search(string mainFolderPath)
		{
			if (!_subscription) return;
			if (!Directory.Exists(mainFolderPath)) return;
			foreach (string fileName in Directory.GetFiles(mainFolderPath))
			{
				FileFound?.Invoke(null, new FileArgs(fileName));
			}
			foreach (var subFoldersPath in Directory.GetDirectories(mainFolderPath))
			{
				Search(subFoldersPath);
			}
		}
		public static void WriteConsoleEvent(object sender, EventArgs e)
		{
			Console.WriteLine("Найден фаил : " + ((FileArgs)e).fileName);
		}
		public static void Stop()
		{
			_subscription = false;
		}

	}
}
