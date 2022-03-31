using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Mre.Visas.Tramite.Application.Shared;
using Mre.Visas.Tramite.Application.Shared.HttpApiClient;
using System;

namespace Mre.Visas.Tramite.Api
{
    public static class AsuntosMigratoriosServicioConfiguracionExtensions
    {
        /// <summary>
        /// Configuracion de conexion para servicios de asuntos migratorios de cancilleria
        /// </summary>
        public const string NAME_PARAMETER_SETTINGS_ASUNTOS_MIGRATORIOS_SERVICIO = "AsuntosMigratoriosServicio";


        public static void ConfigureAsuntosMigratoriosServicio(
            IServiceCollection services,
            IConfiguration configuration)
        {

            
            services.Configure<AsuntosMigratoriosServicioConfiguracion>(
                              configuration.GetSection(NAME_PARAMETER_SETTINGS_ASUNTOS_MIGRATORIOS_SERVICIO));



        }
    }

}
