using Microsoft.EntityFrameworkCore;
using Mre.Visas.Tramite.Application.ConfiguracionFirmaElectronica.Queries;
using Mre.Visas.Tramite.Application.ConfiguracionFirmaElectronica.Repositories;
using Mre.Visas.Tramite.Application.Shared.Responses;
using Mre.Visas.Tramite.Infrastructure.Persistence.Contexts;
using Mre.Visas.Tramite.Infrastructure.Shared.Repositories;
using System.Linq;
using System.Threading.Tasks;
using System.Linq.Dynamic.Core;
using Mre.Visas.Tramite.Application.Shared.Requests;
using Mre.Visas.Tramite.Infrastructure.Shared;

namespace Mre.Visas.Tramite.Infrastructure.ConfiguracionFirmaElectronica.Repositories
{

    public class ConfiguracionFirmaElectronicaRepository : Repository<Domain.Entities.ConfiguracionFirmaElectronica>,
        IConfiguracionFirmaElectronicaRepository
    {

        #region Constructors

        public ConfiguracionFirmaElectronicaRepository(ApplicationDbContext context)
            : base(context)
        {
        }



        #endregion Constructors

        #region Metods Others
        public async Task<ResultadoPaginadoResponse<Domain.Entities.ConfiguracionFirmaElectronica>> ObtenerListaAsync(ObtenerListaConfiguracionFirmaElectronicaRequest input)
        {
            var consulta = _context.Set<Domain.Entities.ConfiguracionFirmaElectronica>()
                  .AsNoTracking();


            //Filtros
            if (input.ServicioId.HasValue) {
               
                consulta = consulta.Where(x => x.ServicioId == input.ServicioId.Value);
            }

            if (!string.IsNullOrWhiteSpace(input.TipoDocumentoCodigo))
            {
                consulta = consulta.Where(x => x.TipoDocumentoCodigo == input.TipoDocumentoCodigo);
            }


            long total = await consulta.LongCountAsync();

            
            if (input is IOrdenadoRequest ordenadoInput && !string.IsNullOrWhiteSpace(ordenadoInput.Orden))
            {
               consulta = consulta.ToConsultaOrdenada(ordenadoInput.Orden);
            }

            if (input is IPaginadoRequest paginadoInput)
            {
                consulta = consulta.ToConsultaPaginada(paginadoInput.Saltar, paginadoInput.MaximoResultado);
            }

            var items = await consulta.ToListAsync();

  
            return new ResultadoPaginadoResponse<Domain.Entities.ConfiguracionFirmaElectronica>(items, total);
        }

        #endregion
    }
}
