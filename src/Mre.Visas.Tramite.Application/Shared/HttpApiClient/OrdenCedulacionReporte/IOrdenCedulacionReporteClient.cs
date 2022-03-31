using Mre.Visas.Tramite.Application.OrdenCedulacion;
using System.Threading.Tasks;

namespace Mre.Visas.Tramite.Application.Shared.HttpApiClient
{
    public interface IOrdenCedulacionReporteClient
    {
        Task<OrdenCedulacionReporteResponse> GenerarAsync(OrdenCedulacionReporteRequest input);

        Task<OrdenCedulacionReporteResponse> GenerarAsync(OrdenCedulacionReporteRequest input, System.Threading.CancellationToken cancellationToken);

    }
}
