using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AlquilerVideo.Models
{
    public class ContextoMongo
    {

        public IMongoDatabase database;
        public ContextoMongo()
        {
            string connectionString = Properties.Settings.Default.mongoConnection;
            MongoClient client = new MongoClient(connectionString);
            database = client.GetDatabase(Properties.Settings.Default.databaseName);
        }


        //public IMongoCollection<Animales> LosAnimales
        //{
        //    get
        //    {
        //        return (database.GetCollection<Animales>("animales"));
        //    }
        //    set
        //    {
        //    }
        //}

    }
}