using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mre.Visas.Tramite.Application.OrdenCedulacion.Requests
{
    public class GenerarOrdenCedulacionRequest
    {
        /// <summary>
        /// Identificador del tramite
        /// </summary>
        public virtual Guid TramiteId { get; set; }

        /// <summary>
        /// Identificador del pago
        /// </summary>
        public virtual Guid PagoId { get; set; }

        /// <summary>
        /// Primer apellido del conyuge, si aplica
        /// </summary>
        public string ConyugePrimerApellido { get; set; }

        /// <summary>
        /// Segundo apellido del conyuge, si aplica
        /// </summary>
        public string ConyugeSegundoApellido { get; set; }

        /// <summary>
        /// Nombres del conyuge, si aplica
        /// </summary>
        public string ConyugeNombres { get; set; }

        /// <summary>
        /// Codigo de la nacionalidad del conyuge, si aplica
        /// </summary>
        public string ConyugeNacionalidadCodigo { get; set; }

        /// <summary>
        /// Nacionalidad del conyuge, si aplica
        /// </summary>
        public string ConyugeNacionalidad { get; set; }

        /// <summary>
        /// Correo electronico del conyuge, si aplica
        /// </summary>
        public string ConyugeCorreoElectronico { get; set; }

        /// <summary>
        /// Observacion del funcionario acerca de la orden de cedulacion
        /// </summary>
        public string Observacion { get; set; }

        /// <summary>
        /// Identificador del usuario signatario
        /// </summary>
        public virtual Guid UsuarioId { get; set; }

    }
}
