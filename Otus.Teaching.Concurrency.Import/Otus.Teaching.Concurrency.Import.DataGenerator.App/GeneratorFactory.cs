using Otus.Teaching.Concurrency.Import.Handler.Data;
using Otus.Teaching.Concurrency.Import.DataGenerator.Generators;

namespace Otus.Teaching.Concurrency.Import.XmlGenerator
{
    public static class GeneratorFactory
    {
        public static IDataGenerator GetGenerator(string fileName, int dataCount)
        {
            return new DataGenerator.Generators.XmlGenerator(fileName, dataCount);
        }
    }
}