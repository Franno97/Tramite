using Mre.Visas.Tramite.Application.Shared.Repositories;
using Mre.Visas.Tramite.Domain.Entities;
using System;
using System.Threading.Tasks;

namespace Mre.Visas.Tramite.Application.RespuestaServicioEsigex.Repositories
{
  public interface ISolicitudVisaEsigexRespository: IRepository<SolicitudVisaEsigex>
  {
    Task<SolicitudVisaEsigex> GetSolicitudVisaExisexPorTramiteId(Guid tramiteId);
  } 

}
