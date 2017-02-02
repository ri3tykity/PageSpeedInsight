using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

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
                default:
                    throw new ArgumentException("Invalid database type", "type");
            }
        }
    }
}
