using Mre.Visas.Tramite.Application.ConfiguracionFirmaElectronica.Queries;
using Mre.Visas.Tramite.Application.Shared.Repositories;
using Mre.Visas.Tramite.Application.Shared.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mre.Visas.Tramite.Application.ConfiguracionFirmaElectronica.Repositories
{
    public interface IConfiguracionFirmaElectronicaRepository : IRepository<Domain.Entities.ConfiguracionFirmaElectronica>
    {

        Task<ResultadoPaginadoResponse<Domain.Entities.ConfiguracionFirmaElectronica>> ObtenerListaAsync(ObtenerListaConfiguracionFirmaElectronicaRequest input);

    }
}
