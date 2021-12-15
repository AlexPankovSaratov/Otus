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
		public static event EventHandler FileFound;

		public static void Search(string mainFolderPath, bool unsubscribe)
		{
			if (!Directory.Exists(mainFolderPath)) return;
			foreach (string fileName in Directory.GetFiles(mainFolderPath))
			{
				FileFound?.Invoke(null, new FileArgs(fileName, unsubscribe));
			}
			foreach (var subFoldersPath in Directory.GetDirectories(mainFolderPath))
			{
				Search(subFoldersPath, unsubscribe);
			}
		}
		public static void WriteConsoleEvent(object sender, EventArgs e)
		{
			Console.WriteLine("Найден фаил : " + ((FileArgs)e).fileName);
			if (((FileArgs)e).unsubscribe)
			{
				FileSearcher.FileFound -= WriteConsoleEvent;
			}
		}
	}
}
