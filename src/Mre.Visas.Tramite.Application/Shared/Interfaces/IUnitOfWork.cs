using System.Threading.Tasks;
using Mre.Visas.Tramite.Application.Tramite.Repositories;
using Mre.Visas.Tramite.Application.RolEstado.Repositories;
using Mre.Visas.Tramite.Application.SoporteGestion.Repositories;
using Mre.Visas.Tramite.Application.Movimiento.Repositories;
using Mre.Visas.Tramite.Application.Catalogo.Repositories;
using Mre.Visas.Tramite.Application.HistorialMigratorio.Repositories;
using Mre.Visas.Tramite.Application.Documento.Repositories;
using Mre.Visas.Tramite.Application.OrdenCedulacion.Repositories;
using Mre.Visas.Tramite.Application.ConfiguracionFirmaElectronica.Repositories;

namespace Mre.Visas.Tramite.Application.Shared.Interfaces
{
  public interface IUnitOfWork
  {
    ITramiteRepository TramiteRepository { get; }

    IRolEstadoRepository RolEstadoRepository { get; }

    IDocumentoRepository DocumentoRepository { get; }
    
    IMovimientoRepository MovimientoRepository { get; }

    ISoporteGestionRepository SoporteGestionRepository { get; }

    ICalidadMigratoriaRepository CalidadMigratoriaRepository { get; }

    ITipoConvenioRepository TipoConvenioRepository { get; }

    ITipoVisaRepository TipoVisaRepository { get; }

    IActividadDesarrollarRepository ActividadDesarrollarRepository { get; }

    IConfiguracionRepository ConfiguracionRepository { get; }
    IHistorialMigratorioRepository HistorialMigratorioRepository { get; }

    IOrdenCedulacionRepository OrdenCedulacionRepository { get; }

    IConfiguracionFirmaElectronicaRepository ConfiguracionFirmaElectronicaRepository { get; }

        Task<(bool, string)> SaveChangesAsync();
  }
}