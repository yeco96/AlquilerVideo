using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson.Serialization.IdGenerators;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
namespace AlquilerVideo.Models
{
    public class Genero
    {
        public string genero { get; set; }
    }
}