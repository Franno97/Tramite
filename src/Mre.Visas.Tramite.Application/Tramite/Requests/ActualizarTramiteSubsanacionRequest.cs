using Mre.Visas.Tramite.Application.Movimiento.Request;
using Mre.Visas.Tramite.Application.Tramite.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mre.Visas.Tramite.Application.Tramite.Requests
{
  public class ActualizarTramiteSubsanacionRequest
  {

    /// <summary>
    /// Guid del trámite
    /// </summary>
    public Guid TramiteId { get; set; }

    /// <summary>
    /// Usuario que actualiza la información
    /// </summary>
    public Guid UsuarioId { get; set; }


    /// <summary>
    /// Datos Beneficiario
    /// </summary>
    public BeneficiarioDtoSubsanacion BeneficiarioDtoSubsanacion { get; set; }

    /// <summary>
    /// Datos documentos
    /// </summary>
    public List<DocumentoDtoSubsanacion> Documentos { get; set; }

    /// <summary>
    /// Datos crear movimiento
    /// </summary>
    public CrearMovimientoRequest CrearMovimientoRequest { get; set; }
  }
}
