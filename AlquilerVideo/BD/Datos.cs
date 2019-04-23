using AlquilerVideo.Models;
using AlquilerVideo.BD;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AlquilerVideo.BD
{
    public class Datos
    {

        private ContextoBD contexto = new ContextoBD();
        public IMongoCollection<Pelicula> Pelicula
        {
            get
            {
                return (contexto.database.GetCollection<Pelicula>("Pelicula"));
            }
            set
            {

            }
        }

        public IMongoCollection<Genero> Genero
        {
            get
            {
                return (contexto.database.GetCollection<Genero>("Genero"));
            }
            set
            {

            }
        }

        public IMongoCollection<Transaccion> Transaccion
        {
            get
            {
                return (contexto.database.GetCollection<Transaccion>("Transaccion"));
            }
        }

    }
}