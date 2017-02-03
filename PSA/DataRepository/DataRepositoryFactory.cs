using System;

namespace PSA.DataRepository
{
    public class DataRepositoryFactory
    {
        public static IDatabaseRepo FactoryMethod(string type)
        {
            switch (type)
            {
                case "SqlLite":
                    return new SQLLiteDB();
                case "MongoDB":
                    return new MongoDB();
                default:
                    throw new ArgumentException("Invalid database type", "type");
            }
        }
    }
}
