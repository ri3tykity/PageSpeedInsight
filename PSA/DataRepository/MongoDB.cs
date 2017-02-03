using MongoDB.Driver;
using MongoDB.Driver.Builders;
using PSA.DataModel;
using MongoDB.Bson;

namespace PSA.DataRepository
{
    public class MongoDB : IDatabaseRepo
    {
        // connection string to mongodb
        const string connectionString = "mongodb://localhost:27017";
        public void SaveResult(PageSpeedData data)
        {
            SaveToMongoDB(data);
        }
        static void SaveToMongoDB(PageSpeedData data)
        {
            // Create a MongoClient object by using the connection string: get access to database using client.
            //var client = new MongoClient(connectionString);

            //Use the MongoClient to access the server : database name that contains number of tables.
            var database = MongoDbConnection.GetMongoDatabase;

            //get mongodb collection: similar as sqltable
            var collection = database.GetCollection<PageSpeedData>("tblPageSpeed");

            var query = Query.EQ("Domain", data.Domain);
            var sortBy = SortBy.Null;
            var update = Update.Set("Result", data.Result);

            var foundData = collection.Find(query);
            var totalResults = foundData.Count();
            // update element
            if (totalResults > 0)
            {
                //var arg = F
                try
                {
                    collection.FindAndModify(new FindAndModifyArgs() { Query = query, SortBy = sortBy, Update = update });
                }
                catch (System.Exception)
                {
                    // TODO
                }
            }
            else
            {
                try
                {
                    collection.Insert(data);
                }
                catch (System.Exception)
                {
                    // TODO
                }
            }
        }
    }
}
