using Mre.Visas.Tramite.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mre.Visas.Tramite.Application.OrdenCedulacion.Responses
{
    public class OrdenCedulacionResponse
    {
        /// <summary>
        /// Identificador de la orden de cedulacion
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Identificador del beneficiario de la orden de cedulacion
        /// </summary>
        public Guid PersonaId { get; set; }

        /// <summary>
        /// Identificador de la unidad administrativa que emite la orden de cedulacion
        /// </summary>
        public Guid UnidadAdministrativaId { get; set; }

        /// <summary>
        /// Codigo del tipo de visa emitida que genera esta orden de cedulacion
        /// </summary>
        public string TipoVisaCodigo { get; set; }

        /// <summary>
        /// Nombre del tipo de visa emitida que genera esta orden de cedulacion
        /// </summary>
        public string TipoVisa { get; set; }

        /// <summary>
        /// Numero de orden de cedulacion
        /// </summary>
        public string Numero { get; set; }

        /// <summary>
        /// Codigo unico de orden de cedulacion
        /// </summary>
        public string CodigoVerificacion { get; set; }

        /// <summary>
        /// Fotografia del beneficiario de la orden de cedulacíon
        /// </summary>
        public byte[] Fotografia { get; set; }

        /// <summary>
        /// Nombres del beneficiario de la orden de cedulacíon
        /// </summary>
        public string Nombres { get; set; }

        /// <summary>
        /// Primer apellido del beneficiario de la orden de cedulacion
        /// </summary>
        public string PrimerApellido { get; set; }

        /// <summary>
        /// Segundo apellido del beneficiario de la orden de cedulacion
        /// </summary>
        public string SegundoApellido { get; set; }

        /// <summary>
        /// Identificador de la nacionalidad del beneficiario de la orden de cedulacion
        /// </summary>
        public string NacionalidadId { get; set; }

        /// <summary>
        /// Nacionalidad del beneficiario de la orden de cedulacion
        /// </summary>
        public string Nacionalidad { get; set; }

        /// <summary>
        /// Pais de nacimiento del beneficiario de la orden de cedulacion
        /// </summary>
        public string PaisNacimiento { get; set; }

        /// <summary>
        /// Ciudad de nacimiento del beneficiario de la orden de cedulacion
        /// </summary>
        public string CiudadNacimiento { get; set; }

        /// <summary>
        /// Fecha de nacimiento del beneficiario de la orden de cedulacion
        /// </summary>
        public DateTime FechaNacimiento { get; set; }

        /// <summary>
        /// Sexo del beneficiario de la orden de cedulacion
        /// </summary>
        public string Sexo { get; set; }

        /// <summary>
        /// Estado civil del beneficiario de la orden de cedulacion
        /// </summary>
        public string EstadoCivil { get; set; }

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
        /// Nacionalidad del conyuge, si aplica
        /// </summary>
        public string ConyugeCorreoElectronico { get; set; }

        /// <summary>
        /// Categoria de la visa
        /// </summary>
        public string CategoriaVisa { get; set; }

        /// <summary>
        /// Numero de visa
        /// </summary>
        public string NumeroVisa { get; set; }

        /// <summary>
        /// Fecha de otorgamiento de visa
        /// </summary>
        public DateTime FechaOtorgamientoVisa { get; set; }

        /// <summary>
        /// Tiempo de vigencia de la visa
        /// </summary>
        public int TiempoVigenciaVisa { get; set; }

        /// <summary>
        /// Unidad de otorgamiento de la visa
        /// </summary>
        public string UnidadOtorgamientoVisa { get; set; }

        /// <summary>
        /// Fecha de emision de la orden de cedulacion
        /// </summary>
        public DateTime FechaEmision { get; set; }

        /// <summary>
        /// Periodo de validez de la orden de cedulacion en dias
        /// </summary>
        public int Validez { get; set; }

        /// <summary>
        /// Fecha de inicio de validez de la orden de cedulacion
        /// </summary>
        public DateTime FechaInicioValidez { get; set; }

        /// <summary>
        /// Fecha de fin de validez de la orden de cedulacion
        /// </summary>
        public DateTime FechaFinValidez { get; set; }

        /// <summary>
        /// Fecha de registro de la orden de cedulacion
        /// </summary>
        public DateTime FechaRegistro { get; set; }

        /// <summary>
        /// Identificador del usuario que firma la orden de cedulacion
        /// </summary>
        public Guid SignatarioUsuarioId { get; set; }

        // <summary>
        /// Nombre del usuario que firma la orden de cedulacion
        /// </summary>
        public string SignatarioNombre { get; set; }

        // <summary>
        /// Apellido del usuario que firma la orden de cedulacion
        /// </summary>
        public string SignatarioApellido { get; set; }

        // <summary>
        /// Cargo del usuario que firma la orden de cedulacion
        /// </summary>
        public string SignatarioCargo { get; set; }

        // <summary>
        /// Ciudad obtenida de la unidad administrativa donde se encuentra asociado el usuario que firma la orden de cedulacion
        /// </summary>
        public string SignatarioCiudad { get; set; }

        /// <summary>
        /// Observacion del funcionario acerca de la orden de cedulacion
        /// </summary>
        public string Observacion { get; set; }



        /// <summary>
        /// Identificador del tramite de orden de cedulacion
        /// </summary>
        public Guid TramiteId { get; set; }

        /// <summary>
        /// Identificador del pago por concepto de orden de cedulacion
        /// </summary>
        public Guid PagoId { get; set; }

        /// <summary>
        /// Id tramite de la orden de cedulacion devuelto por Esigex
        /// </summary>
        public string IdTramiteEsigex { get; set; }

        /// <summary>
        /// Numero tramite de la orden de cedulacion devuelto por Esigex
        /// </summary>
        public string NumeroTramiteEsigex { get; set; }

        /// <summary>
        /// Secuencial de actuacion de la orden de cedulacion devuelto por Esigex
        /// </summary>
        public string SecuencialActuacion { get; set; }

        /// <summary>
        /// Documento de la orden de cedulacion
        /// </summary>
        public byte[] OrdenCedulacionPdf { get; set; }

        /// <summary>
        /// Ruta donde se guarda en el expediente unico el documento de la factura
        /// </summary>
        public string RutaAlmacenamientoFactura { get; set; }

        /// <summary>
        /// Ruta donde se guarda en el expediente unico el documento de orden de cedulacion
        /// </summary>
        public string RutaAlmacenamientoOrdenCedulacion { get; set; }

        /// <summary>
        /// Clave de acceso devuelto por el servicio de facturacion electronica
        /// </summary>
        public string ClaveAccesoFactura { get; set; }

        /// <summary>
        /// Estado del flujo de orden de cedulacion
        /// </summary>
        public EstadoOrdenCedulacion Estado { get; set; }

    }
}
