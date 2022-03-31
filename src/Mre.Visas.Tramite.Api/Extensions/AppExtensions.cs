using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Mre.Visas.Tramite.Api.Middlewares;
using System.Linq;

namespace Mre.Visas.Tramite.Api.Extensions
{
    public static class AppExtensions
    {
        public static void UseSwaggerExtension(this IApplicationBuilder app,
            IConfiguration configuration, string name)
        {

            var scopes = configuration.GetSection("AuthServer:Scopes").GetChildren()
                 .ToDictionary(x => x.Key, x => x.Value);


            app.UseSwagger();
            app.UseSwaggerUI(options =>
            {
                options.SwaggerEndpoint("/swagger/v1/swagger.json", name);
                options.RoutePrefix = string.Empty;

                options.OAuthClientId(configuration["AuthServer:SwaggerClientId"]);
                options.OAuthClientSecret(configuration["AuthServer:SwaggerClientSecret"]);

                options.OAuthScopes(scopes.Keys.ToArray());
            });
        }

        public static void UseApiExceptionMiddleware(this IApplicationBuilder app)
        {
            app.UseMiddleware<ApiExceptionMiddleware>();
        }
    }
}