using System;
using System.Collections.Generic;
using System.Threading;

namespace Otus.Teaching.Concurrency.Import.Core.Loaders
{
    public class FakeDataLoader
        : IDataLoader<object>
    {
		public IEnumerable<object> Entitys { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
		public int CountEntitisInThread { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

		public void LoadData()
        {
            Console.WriteLine("Loading data...");
            Thread.Sleep(10000);
            Console.WriteLine("Loaded data...");
        }
    }
}