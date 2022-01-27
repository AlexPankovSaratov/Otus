using Otus.Teaching.Concurrency.Import.Handler.Entities;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading;

namespace Otus.Teaching.Concurrency.Import.Core.Loaders
{
    public class DataLoaderToDatabase
        : IDataLoader<Customer>
    {
        private string _dbConnection = "Server=DESKTOP-S9EJ5LH\\SQLEXPRESS;DataBase=CustomersDB;Integrated Security=SSPI";
        private List<Customer> _customers;
        private int _countEntitisInThread = 10;

        public IEnumerable<Customer> Entitys
        {
            get { return _customers; }
            set { _customers = (List<Customer>)value; }
        }
        public int CountEntitisInThread
        {
            get { return _countEntitisInThread; }
            set { _countEntitisInThread = value; }
        }

        public void LoadData()
        {
            using (ManualResetEvent resetEvent = new ManualResetEvent(false))
            {
                var arrays = _customers.ToArray().Split<Customer>(_countEntitisInThread);
                int toProcess = arrays.Count();
                foreach (var item in arrays)
                {
                    ThreadPool.QueueUserWorkItem(new WaitCallback(delegate (object state)
                    {
                        SaveInDataBase(item);
                        if (Interlocked.Decrement(ref toProcess) == 0)
                            resetEvent.Set();
                    }));
                }
                resetEvent.WaitOne();
            }
        }

		private void SaveInDataBase(object array)
		{
            foreach (var item in (IEnumerable<Customer>)array)
            {
                using (SqlConnection conn = new SqlConnection(_dbConnection))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(
                    $@"
                        INSERT INTO [dbo].[Customer](email)
                        VALUES
                        ('{item.Email}')
                    "
                    , conn);
                    cmd.CommandType = CommandType.Text;
                    cmd.ExecuteReader();
                }
            }
        }
	}
    public static class MyExtension
    {
        public static IEnumerable<IEnumerable<T>> Split<T>(this T[] array, int size)
        {
            for (var i = 0; i < (float)array.Length / size; i++)
            {
                yield return array.Skip(i * size).Take(size);
            }
        }
    }
}