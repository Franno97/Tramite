using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mre.Visas.Tramite.Domain.Entities
{
    public class ConfiguracionFirmaElectronica : AuditableEntity
    {
        /// <summary>
        /// Identificador del servicio asociado al tipo de documento.
        /// </summary>
        public virtual Guid ServicioId { get; set; }

        /// <summary>
        /// Nombre del servicio asociado al tipo de documento.
        /// </summary>
        public virtual string ServicioNombre { get; set; }

        /// <summary>
        /// Codigo del tipo de documento
        /// </summary>
        public virtual string TipoDocumentoCodigo { get; set; }

        /// <summary>
        /// Modelo de la firma electronica
        /// </summary>
        public virtual string ModeloFirma { get; set; }

        /// <summary>
        /// Tamanio de la firma electronica
        /// </summary>
        public virtual int TamanioFirma { get; set; }

        /// <summary>
        /// Posicion en X de la firma electronica dentro de la pagina
        /// </summary>
        public virtual int PosicionX { get; set; }

        /// <summary>
        /// Posicion en Y de la firma electronica dentro de la pagina
        /// </summary>
        public virtual int PosicionY { get; set; }

        /// <summary>
        /// Numero de pagina del documento donde se debe ubicar la firma
        /// </summary>
        public virtual int NumeroPagina { get; set; }

    }

    public enum ModeloFirma {
        QR, 
        Info1, 
        Info2,
        Info3
    }

}
