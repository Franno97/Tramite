using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Mre.Visas.Tramite.Application.Catalogo.Repositories;
using Mre.Visas.Tramite.Application.Movimiento.Repositories;
using Mre.Visas.Tramite.Application.Documento.Repositories;
using Mre.Visas.Tramite.Application.RolEstado.Repositories;
using Mre.Visas.Tramite.Application.SoporteGestion.Repositories;
using Mre.Visas.Tramite.Application.Tramite.Repositories;
using Mre.Visas.Tramite.Application.HistorialMigratorio.Repositories;
using Mre.Visas.Tramite.Application.RespuestaServicioEsigex.Repositories;
using Mre.Visas.Tramite.Application.Shared.Interfaces;
using Mre.Visas.Tramite.Application.Shared.Repositories;

using Mre.Visas.Tramite.Infrastructure.Catalogo.Repositories;
using Mre.Visas.Tramite.Infrastructure.Movimiento.Repositories;
using Mre.Visas.Tramite.Infrastructure.Persistence.Contexts;
using Mre.Visas.Tramite.Infrastructure.RolEstado.Repositories;
using Mre.Visas.Tramite.Infrastructure.SoporteGestion.Repositories;
using Mre.Visas.Tramite.Infrastructure.Tramite.Repositories;
using Mre.Visas.Tramite.Infrastructure.HistorialMigratorio.Repositories;
using Mre.Visas.Tramite.Infrastructure.Documento.Repositories;
using Mre.Visas.Tramite.Infrastructure.RespuestaServicioEsigex.Repositories;
using Mre.Visas.Tramite.Infrastructure.Shared.Interfaces;
using Mre.Visas.Tramite.Infrastructure.Shared.Repositories;
using Mre.Visas.Tramite.Application.OrdenCedulacion.Repositories;
using Mre.Visas.Tramite.Infrastructure.OrdenCedulacion.Repositories;
using Mre.Visas.Tramite.Application.ConfiguracionFirmaElectronica.Repositories;
using Mre.Visas.Tramite.Infrastructure.ConfiguracionFirmaElectronica.Repositories;

namespace Mre.Visas.Tramite.Infrastructure
{
  public static class ServiceRegistrations
  {
    public static void AddInfrastructureLayer(this IServiceCollection services, IConfiguration configuration)
    {
      services.AddDbContext<ApplicationDbContext>(
          options => options.UseSqlServer(configuration.GetConnectionString("ApplicationDbContext"),
          options => options.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName))
          );

      services.AddScoped(typeof(IRepository<>), typeof(Repository<>));

      services.AddTransient<IUnitOfWork, UnitOfWork>();

      services.AddTransient<ITramiteRepository, TramiteRepository>();

      services.AddTransient<IRolEstadoRepository, RolEstadoRepository>();

      services.AddTransient<IMovimientoRepository, MovimientoRepository>();

      services.AddTransient<IDocumentoRepository, DocumentoRepository>();

      services.AddTransient<ISoporteGestionRepository, SoporteGestionRepository>();

      services.AddTransient<ICalidadMigratoriaRepository, CalidadMigratoriaRepository>();

      services.AddTransient<ITipoConvenioRepository, TipoConvenioRepository>();

      services.AddTransient<ITipoVisaRepository, TipoVisaRepository>();

      services.AddTransient<IActividadDesarrollarRepository, ActividadDesarrollarRepository>();

      services.AddTransient<IConfiguracionRepository, ConfiguracionRepository>();

      services.AddTransient<IHistorialMigratorioRepository, HistorialMigratorioRepository>();
      
      services.AddTransient<IOrdenCedulacionRepository, OrdenCedulacionRepository>();

      services.AddTransient<IConfiguracionFirmaElectronicaRepository, ConfiguracionFirmaElectronicaRepository>();

      services.AddTransient<ISolicitudVisaEsigexRespository, SolicitudVisaEsigexRespository>();

      services.AddTransient<IVisaEsigexRespository, VisaEsigexRespository>();

    }
  }
}