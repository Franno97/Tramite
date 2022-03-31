using Mre.Visas.Tramite.Application.OrdenCedulacion.Dtos;
using Mre.Visas.Tramite.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mre.Visas.Tramite.Application.OrdenCedulacion.Commands
{

    public class CrearOrdenCedulacionRequest
    {

        public Guid PersonaId { get; set; }

        public Guid UnidadAdministrativaId { get; set; }

        public string Numero { get; set; }

        public string CodigoVerificacion { get; set; }

        public byte[] Fotografia { get; set; }

        public string Nombres { get; set; }

        public string PrimerApellido { get; set; }

        public string SegundoApellido { get; set; }

        public string NacionalidadId { get; set; }

        public string Nacionalidad { get; set; }

        public string PaisNacimiento { get; set; }

        public string CiudadNacimiento { get; set; }

        public DateTime FechaNacimiento { get; set; }

        public string Sexo { get; set; }

        public string EstadoCivil { get; set; }
        
        public string UnidadOtorgamientoVisa { get; set; }

        public DateTime FechaEmision { get; set; }

        public int Validez { get; set; }

        public DateTime FechaInicioValidez { get; set; }

        public DateTime FechaFinValidez { get; set; }

        public DateTime FechaRegistro { get; set; }

        public string TipoVisaCodigo { get; set; }

        public string TipoVisa { get; set; }

        public string CategoriaVisa { get; set; }

        public string NumeroVisa { get; set; }

        public DateTime FechaOtorgamientoVisa { get; set; }

        public int TiempoVigenciaVisa { get; set; }

        public Guid TramiteId { get; set; }

        public Guid PagoId { get; set; }

        public string IdTramiteEsigex { get; set; }

        public string NumeroTramiteEsigex { get; set; }

        public string SecuencialActuacion { get; set; }

        public EstadoOrdenCedulacion Estado { get; set; }

    }
}
