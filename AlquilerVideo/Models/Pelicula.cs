using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson.Serialization.IdGenerators;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace AlquilerVideo.Models
{
    public class Pelicula
    {
        [BsonId(IdGenerator = typeof(StringObjectIdGenerator))]
        [BsonRepresentation(BsonType.ObjectId)]
        [DisplayName("Identificador")]
        public string _id { get; set; }

        [Required]
        [DisplayName("Titulo")]
        public string titulo { get; set; }

        [Required]
        [DisplayName("Genero")]
        public string genero { get; set; }

        [Required]
        [DisplayName("Año")]
        public string anno { get; set; }

        [Required]
        [DisplayName("Precio")]
        public string precio { get; set; }

        [DisplayName("Director")]
        public string director { get; set; }

        [Required]
        [DisplayName("Calificacion")]
        public string calificacion { get; set; }
    }
}