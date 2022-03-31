using System;
using System.Collections.Generic;
using System.Text;

namespace Mre.Visas.Tramite.Domain.Const
{
    public class OrdenCedulacionConsts
    {
        public const string CodigoDiasVigencia = "DiasVigenciaOrdenCedulacion";
        public const string CodigoTipoTramiteOrdenCedulacion = "OC";
        public const int EstadoGenerarOrden = 101;
        public const int EstadoFinalizado = 102;
        public const string ExtensionArchivo = ".pdf";
        public const string RespuestaOk = "OK";


        public static class Notificaciones
        {
            public const string AsuntoFactura = "Factura orden cedulacion";
            public const string MensajeFactura = "Documento de factura electrónica por concepto de servicio de orden de cedulación";

            public const string AsuntoOrdenCedulacion = "Orden cedulacion";
            public const string MensajeOrdenCedulacion = "Documento de orden de cedulación";

            public const string NombreAdjuntoFactura = "Factura.pdf";
            public const string NombreAdjuntoOrdenCedulacion = "Orden-cedulacion.pdf";

            public const string NotificacionGeneral01 = "NOTIFICACION.GENERAL.01";

            public const string PdfMimeType = "application/pdf";
        }

        public static class Facturacion
        {
            public const string CodigoOficina = "C-ZNL9-A";
            public const string CodigoUsuario = "usuariofe";

            public const string Referencia = "Orden de cedulacion";
            public const string Origen = "ORDENCEDULACION";
            public const string DescripcionGeneral = "Ninguna";
            
        }

        public static class ExpedienteUnico
        {
            public const string BibliotecaFactura = "Factura";
            public const string BibliotecaOrdenCedulacion = "Cedulacion";
            public const string NombreArchivoFactura = "Factura";
            public const string NombreArchivoOrdenCedulacion = "Orden-cedulacion";
        }
        
    }
}
