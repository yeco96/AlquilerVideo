using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson.Serialization.IdGenerators;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace AlquilerVideo.Models
{
    public class Cliente
    {
        [BsonId(IdGenerator = typeof(StringObjectIdGenerator))]
        [BsonRepresentation(BsonType.ObjectId)]
        [DisplayName("Identificador")]
        public string _id { get; set; }

        [Required]
        [DisplayName("Cedula")]
        public string Cedula { get; set; }

        [Required]
        [DisplayName("Nombre")]
        public string Nombre { get; set; }

        [Required]
        [DisplayName("Primer Apellido")]
        public string Apellido1 { get; set; }

        [Required]
        [DisplayName("Segundo Apellido")]
        public string Apellido2 { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        [DisplayName("Fecha de Registro")]
        public string Fecha_Registro { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        [DisplayName("Fecha de Nacimiento")]
        public string Fecha_Nacimiento { get; set; }

        [Required]
        [DisplayName("Direccion")]
        public string Direccion { get; set; }

        //public string cedula { get; set; }
        //public string nombreCompleto { get; set; }
        //public bool mayorEdad { get; set; }
    }
}