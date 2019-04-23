using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson.Serialization.IdGenerators;
using System;

namespace AlquilerVideo.Models
{
    public class UsuarioRegistra
    {
        public string cedula { get; set; }
        public string nombreCompleto { get; set; }
       
    }
}