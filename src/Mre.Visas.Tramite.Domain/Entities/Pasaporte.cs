using System;

namespace Mre.Visas.Tramite.Domain.Entities
{
    public class Pasaporte : BaseEntity
    {
        public string CiudadEmision { get; set; }

        public DateTime FechaEmision { get; set; }

        public DateTime FechaExpiracion { get; set; }

        public DateTime FechaNacimiento { get; set; }

        public string Nombres { get; set; }

        public string Numero { get; set; }

        public string PaisEmision { get; set; }

    public string TipoDocumentoIdentidadId { get; set; }
  }
}