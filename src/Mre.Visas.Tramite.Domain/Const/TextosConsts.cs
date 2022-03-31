using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mre.Visas.Tramite.Domain.Const
{
    public static class TextosConsts
    {
        public const string UsuarioNoAutenticado = "El usuario no esta autenticado";
        public const string ErrorGenerico = "No se puede procesar su solicitud en este momento";
        public const string ErrorFacturacion = "Error al consultar el servicio de facturacion";
        public const string DetallePagoNoExiste = "Detalle de pago no existe";
        public const string ErrorObtenerPdf = "Error al obtener la factura en PDF";
        public const string ErrorObtenerFactura = "Error al obtener la factura";
        public const string ErrorApiPago= "Error al obtener el pago desde el API de pagos";
        public const string ErrorConvertirFoto= "Error al convertir fotografia a byte array";
        public const string InformacionTramiteIncorrecta= "La información del trámite no corresponde a emision de orden de cedulación";
        public const string ErrorTramiteFinalizado= "El trámite ya ha sido finalizado";
        public const string TramiteFinalizadoCorrectamente= "El trámite ha sido finalizado correctamente. La orden de cedulación ha sido enviada al correo del ciudadano";


        public static class ControlErrores
        {
            public const string TituloValidaciones = "Tu Solicitud no es valida.";
            public const string TituloGenerar = "Un error interno ocurrido durante tu Solicitud!";
        }

        public static class FirmaElectronica
        {
            public const string NoExisteConfiguracionFirma = "No existe configuración de firma electrónica del signatario";
            public const string NoExisteFirmaInsumos = "No existe configuración de firma electrónica para el servicio y tipo de documento";

        }
    }
}
