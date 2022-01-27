using Otus.Teaching.Concurrency.Import.Handler.Entities;
using System.Collections.Generic;

namespace Otus.Teaching.Concurrency.Import.Core.Loaders
{
    public interface IDataLoader<T>
    {
		IEnumerable<T> Entitys { get; set; }
		int CountEntitisInThread { get; set; }

		void LoadData();
    }
}