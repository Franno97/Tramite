using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mre.Visas.Tramite.Application.OrdenCedulacion.Dtos
{
    public class PagoDetalleDto
    {
        public Guid Id { get; set; }

        public bool IsDeleted { get; set; }

        public DateTime LastModified { get; set; }

        public Guid LastModifierId { get; set; }

        public DateTime Created { get; set; }

        public Guid CreatorId { get; set; }

        public Guid IdTramite { get; set; }

        public Guid IdPago { get; set; }

        public int Orden { get; set; }

        public string Descripcion { get; set; }

        public double ValorArancel { get; set; }

        public double PorcentajeDescuento { get; set; }

        public double ValorDescuento { get; set; }

        public double ValorTotal { get; set; }

        public string Estado { get; set; }

        public string OrdenPago { get; set; }

        public string NumeroTransaccion { get; set; }

        public bool EstaFacturado { get; set; }

        public string ClaveAcceso { get; set; }

        public string ComprobantePago { get; set; }

        public Guid PartidaArancelariaId { get; set; }

        public Guid ServicioId { get; set; }

        public string Servicio { get; set; }

        public string PartidaArancelaria { get; set; }

        public string NumeroPartida { get; set; }

        public Guid JerarquiaArancelariaId { get; set; }

        public string JerarquiaArancelaria { get; set; }

        public Guid ArancelId { get; set; }

        public string Arancel { get; set; }

        public Guid ConvenioId { get; set; }

        public string TipoServicio { get; set; }

        public string TipoExoneracionId { get; set; }

        public string TipoExoneracion { get; set; }

        public string FacturarEn { get; set; }
    }
}
