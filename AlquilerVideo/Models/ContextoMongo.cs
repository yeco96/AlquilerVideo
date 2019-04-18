
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Fidelitas.NoSql.PrimerEjemplo.Models
{
    public class ContextoMongo
    {
        public IMongoDatabase database;
        public ContextoMongo()
        {
            var connectionString = AlquilerVideo.Properties.Settings.Default.mongoConnection;

            var client = new MongoClient("mongodb+srv://yeco96:k0nsum0.Respet0@cluster0-6sxzr.azure.mongodb.net/test?retryWrites=true");
            //var database = client.GetDatabase("test");


            database = client.GetDatabase(AlquilerVideo.Properties.Settings.Default.databaseName);
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