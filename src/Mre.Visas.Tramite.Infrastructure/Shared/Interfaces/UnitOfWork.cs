using Mre.Visas.Tramite.Application.Catalogo.Repositories;
using Mre.Visas.Tramite.Application.ConfiguracionFirmaElectronica.Repositories;
using Mre.Visas.Tramite.Application.Documento.Repositories;
using Mre.Visas.Tramite.Application.HistorialMigratorio.Repositories;
using Mre.Visas.Tramite.Application.Movimiento.Repositories;
using Mre.Visas.Tramite.Application.OrdenCedulacion.Repositories;
using Mre.Visas.Tramite.Application.RolEstado.Repositories;
using Mre.Visas.Tramite.Application.Shared.Interfaces;
using Mre.Visas.Tramite.Application.SoporteGestion.Repositories;
using Mre.Visas.Tramite.Application.Tramite.Repositories;
using Mre.Visas.Tramite.Application.RespuestaServicioEsigex.Repositories;
using Mre.Visas.Tramite.Infrastructure.HistorialMigratorio.Repositories;
using Mre.Visas.Tramite.Infrastructure.Persistence.Contexts;
using Mre.Visas.Tramite.Infrastructure.SoporteGestion.Repositories;
using System;
using System.Threading.Tasks;
using Mre.Visas.Tramite.Infrastructure.RespuestaServicioEsigex.Repositories;

namespace Mre.Visas.Tramite.Infrastructure.Shared.Interfaces
{
  public class UnitOfWork : IUnitOfWork
  {
    #region Constructors

    public UnitOfWork(
        ApplicationDbContext context,
        ITramiteRepository tramiteRepository,
        IRolEstadoRepository rolEstadoRepository,
        IMovimientoRepository movimientoRepository,
        ISoporteGestionRepository soporteGestionRepository,
        ICalidadMigratoriaRepository calidadMigratoriaRepository,
        ITipoConvenioRepository tipoConvenioRepository,
        ITipoVisaRepository tipoVisaRepository,
        IActividadDesarrollarRepository actividadDesarrollarRepository,
        IConfiguracionRepository configuracionRepository,
        IHistorialMigratorioRepository historialMigratorioRepository,
        IDocumentoRepository documentoRepository,
        IOrdenCedulacionRepository ordenCedulacionRepository,
        IConfiguracionFirmaElectronicaRepository configuracionFirmaElectronicaRepository,
        ISolicitudVisaEsigexRespository solicitudVisaEsigexRespository,
        IVisaEsigexRespository visaEsigexRespository
        )
    {
      _context = context;
      TramiteRepository = tramiteRepository;
      RolEstadoRepository = rolEstadoRepository;
      MovimientoRepository = movimientoRepository;
      SoporteGestionRepository = soporteGestionRepository;
      CalidadMigratoriaRepository = calidadMigratoriaRepository;
      TipoConvenioRepository = tipoConvenioRepository;
      TipoVisaRepository = tipoVisaRepository;
      ActividadDesarrollarRepository = actividadDesarrollarRepository;
      ConfiguracionRepository = configuracionRepository;
      HistorialMigratorioRepository = historialMigratorioRepository;
      DocumentoRepository = documentoRepository;
      OrdenCedulacionRepository = ordenCedulacionRepository;
      ConfiguracionFirmaElectronicaRepository = configuracionFirmaElectronicaRepository;
      SolicitudVisaEsigexRespository = solicitudVisaEsigexRespository;
      VisaEsigexRespository = visaEsigexRespository;
    }

    #endregion Constructors

    #region Attributes

    protected readonly ApplicationDbContext _context;

    #endregion Attributes

    #region Properties

    public ITramiteRepository TramiteRepository { get; }
    public IMovimientoRepository MovimientoRepository { get; }
    public IRolEstadoRepository RolEstadoRepository { get; }
    public ISoporteGestionRepository SoporteGestionRepository { get; }
    public ICalidadMigratoriaRepository CalidadMigratoriaRepository { get; }
    public ITipoConvenioRepository TipoConvenioRepository { get; }
    public ITipoVisaRepository TipoVisaRepository { get; }
    public IActividadDesarrollarRepository ActividadDesarrollarRepository { get; }
    public IConfiguracionRepository ConfiguracionRepository { get; }
    public IHistorialMigratorioRepository HistorialMigratorioRepository { get; }
    public IDocumentoRepository DocumentoRepository { get; }
    public IOrdenCedulacionRepository OrdenCedulacionRepository { get; }

    public IConfiguracionFirmaElectronicaRepository ConfiguracionFirmaElectronicaRepository { get; }

    public ISolicitudVisaEsigexRespository SolicitudVisaEsigexRespository { get; }

    public IVisaEsigexRespository VisaEsigexRespository { get;}

    #endregion Properties

    #region Methods

    public async Task<(bool, string)> SaveChangesAsync()
    {
      try
      {
        await _context.SaveChangesAsync().ConfigureAwait(false);

        return (true, null);
      }
      catch (Exception ex)
      {
        return (false, ex.InnerException is null ? ex.Message : ex.InnerException.Message);
      }
    }

    #endregion Methods
  }
}