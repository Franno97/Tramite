using System;

namespace Mre.Visas.Tramite.Application.ConfiguracionFirmaElectronica.Commands
{
    public class CrearConfiguracionFirmaElectronicaRequest {

       
        public  Guid ServicioId { get; set; }

        
        public  string ServicioNombre { get; set; }

        
        public  string TipoDocumentoCodigo { get; set; }

        
        public  string ModeloFirma { get; set; }

        
        public  int TamanioFirma { get; set; }

       
        public  int PosicionX { get; set; }

       
        public  int PosicionY { get; set; }

       
        public  int NumeroPagina { get; set; }

    }

}
