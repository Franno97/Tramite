using System;

namespace Mre.Visas.Tramite.Application.ConfiguracionFirmaElectronica.Queries
{
    public class ConfiguracionFirmaElectronicaResponse
    {
        public virtual Guid Id { get; set; }

       
        public virtual Guid ServicioId { get; set; }

       
        public virtual string ServicioNombre { get; set; }

      
        public virtual string TipoDocumentoCodigo { get; set; }

     
        public virtual string ModeloFirma { get; set; }

      
        public virtual int TamanioFirma { get; set; }

        
        public virtual int PosicionX { get; set; }

       
        public virtual int PosicionY { get; set; }

       
        public virtual int NumeroPagina { get; set; }
    }
}
