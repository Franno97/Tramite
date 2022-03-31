
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Mre.Visas.Tramite.Api.Extensions
{
    public static class ServiceExtensions
    {
        public static void AddSwaggerExtension(this IServiceCollection services,
            IConfiguration configuration,
            string title, string version)
        {
            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc(version, new OpenApiInfo
                {
                    Title = title,
                    Version = version
                });
                 
                // Define the OAuth2.0 scheme that's in use 
                var authority = configuration["AuthServer:Authority"];

                var scopes = configuration.GetSection("AuthServer:Scopes").GetChildren()
                  .ToDictionary(x => x.Key, x => x.Value);

                options.AddSecurityDefinition("oauth2", new OpenApiSecurityScheme
                {
                    Type = SecuritySchemeType.OAuth2,
                    Flows = new OpenApiOAuthFlows
                    {
                        AuthorizationCode = new OpenApiOAuthFlow
                        {
                            AuthorizationUrl = new Uri($"{authority.EnsureEndsWith('/')}connect/authorize"),
                            Scopes = scopes,
                            TokenUrl = new Uri($"{authority.EnsureEndsWith('/')}connect/token")
                        }
                    }
                });

                options.AddSecurityRequirement(new OpenApiSecurityRequirement
                    {
                            {
                                new OpenApiSecurityScheme
                                {
                                    Reference = new OpenApiReference
                                    {
                                        Type = ReferenceType.SecurityScheme,
                                        Id = "oauth2"
                                    }
                                },
                                Array.Empty<string>()
                            }
                    });
            });
        }
    }
}