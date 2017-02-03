using MongoDB.Driver;
using System;

namespace PSA.DataRepository
{
    public class MongoDbConnection
    {
        //volatile: ensure that assignment to the instance variable
        //is completed before the instance variable can be accessed
        private static volatile MongoDbConnection instance;
        private static object syncLock = new System.Object();


        //TODO: put connection string in web.config - for ease use - Deepak
        const string connectionString = "mongodb://localhost:27017";
        private static MongoDatabase db = null;


        private MongoDbConnection()
        {
            try
            {
                var client = new MongoClient();
                MongoServer server = client.GetServer();
                server.Connect();
                // TODO: put db name in web.config file. - Deepak
                db = server.GetDatabase("nature");
            }
            catch (Exception ex)
            {
               // TODO
            }

        }

        public static MongoDatabase GetMongoDatabase
        {
            get
            {
                if (instance == null)
                {
                    lock (syncLock)
                    {
                        if (instance == null)
                            instance = new MongoDbConnection();
                    }
                }

                return db;
            }
        }
    }

}