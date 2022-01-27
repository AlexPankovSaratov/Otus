using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;
using Otus.Teaching.Concurrency.Import.Core.Parsers;
using Otus.Teaching.Concurrency.Import.DataGenerator.Dto;
using Otus.Teaching.Concurrency.Import.Handler.Entities;

namespace Otus.Teaching.Concurrency.Import.DataAccess.Parsers
{
    public class XmlParserFormFile
        : IDataParser<List<Customer>>
    {
        private static string _dataFilePath;

        public XmlParserFormFile(string dataFilePath)
        {
            _dataFilePath = dataFilePath;
        }
        public List<Customer> Parse()
        {
            CustomersList customers;
            using var stream = File.OpenRead(_dataFilePath);
            customers = (CustomersList)new XmlSerializer(typeof(CustomersList)).Deserialize(stream);
            return customers.Customers;
        }
    }
}