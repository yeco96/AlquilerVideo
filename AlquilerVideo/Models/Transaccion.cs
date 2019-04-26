using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson.Serialization.IdGenerators;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace AlquilerVideo.Models
{
    public class Transaccion
    {
        [BsonId(IdGenerator = typeof(StringObjectIdGenerator))]
        [BsonRepresentation(BsonType.ObjectId)]
        public string _id { get; set; }
        public DateTime fechaTransaccion { get; set; }

        [Required]
        [DisplayName("Fecha Alquiler")]
        public DateTime? fechaRegreso { get; set; }

        [Required]
        [DisplayName("Tipo Movimiento")]
        public string tipoMovimiento { get; set; }


        public UsuarioRegistra usuarioRegistra { get; set; }
        public List<Pelicula> detallePelicula { get; set; }
        public Cliente cliente { get; set; }

        public string tempPelicula { get; set; }
        public string tempCliente { get; set; }

    }
}