using Microsoft.Extensions.Configuration;
using Otus.Teaching.Concurrency.Import.Handler.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Threading;

namespace Otus.Teaching.Concurrency.Import.Core.Loaders
{
    public class DataLoaderToDatabase
        : IDataLoader<Customer>
    {
        private static IConfigurationRoot configuration = new ConfigurationBuilder().AddJsonFile("appSettings.json").Build();
        private string _dbConnection = configuration["DbConnection"];
        private List<Customer> _customers;
        private int _countEntitisInThread = 10;
		private int _countRetriesOnError;

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
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
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
            stopwatch.Stop();
            Console.WriteLine($"Count entitys = {_customers.Count}, loading time = {stopwatch.ElapsedMilliseconds / 1000} second");
        }

		private void SaveInDataBase(object array)
		{
            foreach (var item in (IEnumerable<Customer>)array)
            {
                var countRetriesOnError = _countRetriesOnError;
                using SqlConnection conn = new SqlConnection(_dbConnection);
                conn.Open();
                using SqlCommand cmd = new SqlCommand(
                $@"
                        INSERT INTO [dbo].[Customers](Id, FullName, Email, Phone)
                        VALUES
                        (
                        '{item.Id}',
                        '{item.FullName.Replace("'","''")}',
                        '{item.Email}',
                        '{item.Phone}'
                        )
                    "
                , conn);
                cmd.CommandType = CommandType.Text;
                cmd.ExecuteReader();
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