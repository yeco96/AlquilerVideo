using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AlquilerVideo.BD
{
    public class ContextoBD
    {
        public IMongoDatabase database;
        public ContextoBD()
        {
            string connectionString = Properties.Settings.Default.mongoConnection;
            MongoClient client = new MongoClient(connectionString);
            database = client.GetDatabase(Properties.Settings.Default.databaseName);
        }
    }
}