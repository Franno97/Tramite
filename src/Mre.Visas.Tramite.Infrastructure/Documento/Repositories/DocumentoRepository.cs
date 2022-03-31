using Mre.Visas.Tramite.Application.Documento.Repositories;
using Mre.Visas.Tramite.Infrastructure.Persistence.Contexts;
using Mre.Visas.Tramite.Infrastructure.Shared.Repositories;

namespace Mre.Visas.Tramite.Infrastructure.Documento.Repositories
{
  public class DocumentoRepository : Repository<Domain.Entities.Documento>, IDocumentoRepository
  {

    #region Constructors

    public DocumentoRepository(ApplicationDbContext context)
        : base(context)
    {
    }

    #endregion Constructors

    #region Metods Others

    #endregion
  }
}
