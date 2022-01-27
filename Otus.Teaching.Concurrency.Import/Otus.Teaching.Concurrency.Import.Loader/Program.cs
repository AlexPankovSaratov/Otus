using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using Microsoft.Extensions.Configuration;
using Otus.Teaching.Concurrency.Import.Core.Loaders;
using Otus.Teaching.Concurrency.Import.Core.Parsers;
using Otus.Teaching.Concurrency.Import.DataAccess.Parsers;
using Otus.Teaching.Concurrency.Import.DataGenerator.Generators;
using Otus.Teaching.Concurrency.Import.Handler.Entities;

namespace Otus.Teaching.Concurrency.Import.Loader
{
	enum AppLaunchMode
    {
        InProcess = 0,
        InMethod = 1
	}
    class Program
    {
        private static int _dataCount = 3000000;
        private static int _countEntitisInThread = 100000;
        private static string _dataFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "customers.xml");
        private static IConfigurationRoot configuration = new ConfigurationBuilder().AddJsonFile("appSettings.json").Build();
        private static AppLaunchMode _appLaunchMode = (AppLaunchMode)int.Parse(configuration["appLaunchMode"]);
        private static string _generatorPath = new DirectoryInfo(AppDomain.CurrentDomain.BaseDirectory).Parent.Parent.Parent.Parent.FullName +
                @"\Otus.Teaching.Concurrency.Import.DataGenerator.App\bin\Debug\netcoreapp3.1\Otus.Teaching.Concurrency.Import.DataGenerator.App.exe";
        private static IDataLoader<Customer> _dataLoader = new DataLoaderToDatabase();
        private static IDataParser<List<Customer>> _dataParser = new XmlParserFormFile(_dataFilePath);

        static void Main(string[] args)
        {
            Console.WriteLine($"Loader started with process Id {Process.GetCurrentProcess().Id}...");

			switch (_appLaunchMode)
			{
				case AppLaunchMode.InProcess:
					GenerateCustomersDataFileInProcess();
					break;
				case AppLaunchMode.InMethod:
					GenerateCustomersDataFile();
					break;
				default:
					return;
			}
			List<Customer> customers = _dataParser.Parse();
			_dataLoader.Entitys = customers;
			_dataLoader.CountEntitisInThread = _countEntitisInThread;
			_dataLoader.LoadData();
		}

        static void GenerateCustomersDataFile()
        {
            var xmlGenerator = new XmlGenerator(_dataFilePath, _dataCount);
            xmlGenerator.Generate();
        }
        static void GenerateCustomersDataFileInProcess()
        {
            using (Process myProcess = new Process())
            {
                myProcess.StartInfo.UseShellExecute = true;
                myProcess.StartInfo.CreateNoWindow = true;
                myProcess.StartInfo.FileName = _generatorPath;
                myProcess.StartInfo.Arguments = $"{_dataFilePath} {_dataCount}";
                myProcess.Start();
                myProcess.WaitForExit();
            }
        }
    }
}