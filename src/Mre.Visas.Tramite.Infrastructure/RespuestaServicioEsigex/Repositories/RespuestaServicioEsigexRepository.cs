using Microsoft.EntityFrameworkCore;
using Mre.Visas.Tramite.Application.RespuestaServicioEsigex.Repositories;
using Mre.Visas.Tramite.Domain.Entities;
using Mre.Visas.Tramite.Infrastructure.Persistence.Contexts;
using Mre.Visas.Tramite.Infrastructure.Shared.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mre.Visas.Tramite.Infrastructure.RespuestaServicioEsigex.Repositories
{
  public class SolicitudVisaEsigexRespository : Repository<SolicitudVisaEsigex>, ISolicitudVisaEsigexRespository
  {
    #region Constructors

    public SolicitudVisaEsigexRespository(ApplicationDbContext context): base(context)
    {

    }

    public async Task<SolicitudVisaEsigex> GetSolicitudVisaExisexPorTramiteId(Guid tramiteId)
    {
      return await _context.SolicitudesVisaEsigex.FirstOrDefaultAsync(x => x.TramiteId == tramiteId && !x.IsDeleted);
    }
    #endregion

    #region Otros Métodos

    #endregion
  }

  public class VisaEsigexRespository : Repository<VisaEsigex>, IVisaEsigexRespository
  {
    #region Constructors

    public VisaEsigexRespository(ApplicationDbContext context) : base(context)
    {

    }

    public async Task<VisaEsigex> GetVisaEsigexPorTramiteId(Guid tramiteId)
    {
      return await _context.VisasEsigex.FirstOrDefaultAsync(x => x.TramiteId == tramiteId && !x.IsDeleted);
    }
    #endregion

    #region Otros Métodos

    #endregion
  }

}
