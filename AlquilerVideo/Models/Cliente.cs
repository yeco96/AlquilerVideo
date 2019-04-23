using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson.Serialization.IdGenerators;
using System;

namespace AlquilerVideo.Models
{
    public class Cliente
    {
        public string cedula { get; set; }
        public string nombreCompleto { get; set; }
        public bool mayorEdad { get; set; }
    }
}