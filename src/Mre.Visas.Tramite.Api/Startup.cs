using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using Mre.Sb.Auditar;
using Mre.Sb.PermisoRemoto;
using Mre.Visas.Tramite.Api.Extensions;
using Mre.Visas.Tramite.Application;
using Mre.Visas.Tramite.Application.OrdenCedulacion;
using Mre.Visas.Tramite.Application.OrdenCedulacion.Mappings;
using Mre.Visas.Tramite.Application.Shared.Requests;
using Mre.Visas.Tramite.Application.Shared.Responses;
using Mre.Visas.Tramite.Application.Shared.Security;
using Mre.Visas.Tramite.Application.Tramite.Dtos;
using Mre.Visas.Tramite.Domain.Const;
using Mre.Visas.Tramite.Infrastructure;
using Mre.Visas.Tramite.Infrastructure.Persistence.Contexts;
using Newtonsoft.Json;
using System;
using Tramite.Abp.Replica;
using static Mre.Visas.Tramite.Application.RemoteServices;
using HttpApiAutentificacion = Mre.Visas.Tramite.Application.Shared.Security.HttpApiAutentificacion;
using IDistributedCacheSerializer = Mre.Visas.Tramite.Application.Shared.Security.IDistributedCacheSerializer;
using IHttpApiAutentificacion = Mre.Visas.Tramite.Application.Shared.Security.IHttpApiAutentificacion;
using Utf8JsonDistributedCacheSerializer = Mre.Visas.Tramite.Application.Shared.Security.Utf8JsonDistributedCacheSerializer;

namespace Mre.Visas.Tramite.Api
{
  public class Startup
  {
    public Startup(IConfiguration configuration)
    {
      Configuration = configuration;
    }

    public IConfiguration Configuration { get; }

    public void ConfigureServices(IServiceCollection services)
    {
      services.AddInfrastructureLayer(Configuration);
      services.AddApplicationLayer();

      services.AddControllers().AddNewtonsoftJson(options =>
      {
        options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
        options.SerializerSettings.NullValueHandling = NullValueHandling.Ignore;
      });

      //Agregar servicios para autentificacion
      services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
      .AddJwtBearer(options =>
      {
        options.Authority = Configuration["AuthServer:Authority"];
        options.Audience = Configuration["AuthServer:Audience"];
        options.RequireHttpsMetadata = Convert.ToBoolean(Configuration["AuthServer:RequireHttpsMetadata"]);

      });

      //ADD CROSS
      services.AddCors();

            services.AddSwaggerExtension(Configuration, "Mre.Visas.Tramite.Api", "v1");

      //Servicios remotos
      RemoteServicesExtensions.ConfigureHttpClient(services, Configuration);
      AsuntosMigratoriosServicioConfiguracionExtensions.ConfigureAsuntosMigratoriosServicio(services, Configuration);


      services.Configure<AbpIdentityClientOptions>(Configuration);

      services.AddTransient<IHttpContextAccessor, HttpContextAccessor>();
      services.AddTransient<Application.Shared.Security.ITokenAcceso, Application.Shared.Security.TokenAcceso>();
      services.AddTransient<IDistributedCacheSerializer, Utf8JsonDistributedCacheSerializer>();
      services.AddTransient<IHttpApiAutentificacion, HttpApiAutentificacion>();
      services.AddTransient<IOrdenCedulacionMapper, OrdenCedulacionMapper>();


      services.AddTransient<IPaginadoRequest, PaginadoRequest>();

      services.Configure<OrdenCedulacionConfiguracion>(
                        Configuration.GetSection("Tramite:OrdenCedulacion"));

      services.Configure<VisaVirteConfiguracion>(
                        Configuration.GetSection("Tramite:VisaVirte"));

      services.Configure<RemoteServices>(
                              Configuration.GetSection("RemoteServices"));

      //cache redis
      services.AddStackExchangeRedisCache(options =>
            {
              options.Configuration = Configuration.GetConnectionString("Redis");
              options.InstanceName = "Mre.Visas.Tramite:";
            });

      services.AgregarPermisoRemoto(Configuration);
      services.AgregarAuditoria(Configuration);
    }

    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
      if (env.IsDevelopment())
      {
        app.UseDeveloperExceptionPage();
      }

            app.UseRouting();
            app.UseSwaggerExtension(Configuration, "Mre.Visas.Tramite.Api");
            app.UseApiExceptionMiddleware();

      //ADD CROSS
      // global cors policy
      app.UseCors(x => x
          .AllowAnyMethod()
          .AllowAnyHeader()
          .SetIsOriginAllowed(origin => true) // allow any origin
                                              //Permitir  indica que cabeceras pueden ser expuestas
          .WithExposedHeaders(GestionErroresConsts.NombreCabeceraEstablecerFormatoErrorAbp)
          .AllowCredentials()); // allow credentials

      app.UseAuthentication();
      app.UseAuthorization();

      app.UseEndpoints(endpoints =>
      {
        endpoints.MapControllers();
      });

      app.UsarAuditoria<ApplicationDbContext>();

    }
  }
}