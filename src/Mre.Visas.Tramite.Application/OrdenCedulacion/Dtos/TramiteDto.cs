using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mre.Visas.Tramite.Application.OrdenCedulacion.Dtos
{
    public class TramiteDto
    {
        /// <summary>
        /// Identificador del tramite
        /// </summary>
        public virtual Guid Id { get; set; }

        /// <summary>
        /// Numero del tramite se compone de la fecha en formato yyyyMMdd-contador
        /// </summary>
        public virtual string Numero { get; set; }

        /// <summary>
        /// Fecha del tramite
        /// </summary>
        public virtual string Fecha { get; set; }

        /// <summary>
        /// Nombre d la actividad
        /// </summary>
        public virtual string Actividad { get; set; }

        /// <summary>
        /// Id del Beneficiario
        /// </summary>
        public virtual Guid BeneficiarioId { get; set; }

        /// <summary>
        /// Calidad migratoria
        /// </summary>
        public virtual string CalidadMigratoria { get; set; }

        /// <summary>
        /// Datos del grupo que pertenece
        /// </summary>
        public virtual string Grupo { get; set; }

        /// <summary>
        /// Id del solicitante
        /// </summary>
        public virtual Guid SolicitanteId { get; set; }

        /// <summary>
        /// Tipo de visas
        /// </summary>
        public virtual string TipoVisa { get; set; }

        /// <summary>
        /// Identificador de la Unidad Administrativa centro de Emision de Visas
        /// </summary>
        public virtual Guid UnidadAdministrativaIdCEV { get; set; }

        /// <summary>
        /// Identificador de la Unidad Administrativa de la Zonal
        /// </summary>
        public virtual Guid UnidadAdministrativaIdZonal { get; set; }

        /// <summary>
        /// Identificador del servicio
        /// </summary>
        public virtual Guid ServicioId { get; set; }

        /// <summary>
        /// Codigo de Pais
        /// </summary>
        public virtual string CodigoPais { get; set; }

        /// <summary>
        /// Persona Id
        /// </summary>
        public virtual Guid PersonaId { get; set; }

        /// <summary>
        /// Origen Id
        /// </summary>
        public virtual Guid OrigenId { get; set; }

        /// <summary>
        /// Tipo tramite
        /// </summary>
        public virtual string TipoTramite { get; set; }

    }
}
