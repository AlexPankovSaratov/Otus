using System;

namespace DelegatesApp
{
	internal class FileArgs : EventArgs
	{
		public string fileName;
		public bool unsubscribe;

		public FileArgs(string fileName, bool unsubscribe)
		{
			this.fileName = fileName;
			this.unsubscribe = unsubscribe;
		}
	}
}