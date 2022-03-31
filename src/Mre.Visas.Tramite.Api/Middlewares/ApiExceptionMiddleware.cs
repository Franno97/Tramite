using FluentValidation;
using FluentValidation.Results;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Mre.Visas.Tramite.Application.Shared.Wrappers;
using Mre.Visas.Tramite.Domain;
using Mre.Visas.Tramite.Domain.Const;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Mre.Visas.Tramite.Api.Middlewares
{
    public class ApiExceptionMiddleware
    {
        #region Constructors

        public ApiExceptionMiddleware(RequestDelegate next, ILogger<ApiExceptionMiddleware> logger)
        {
            _logger = logger;
            _next = next;
        }

        #endregion Constructors

        #region Attributes

        private readonly ILogger<ApiExceptionMiddleware> _logger;

        private readonly RequestDelegate _next;

        #endregion Attributes

        #region Methods

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context).ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                var response = context.Response;
                response.ContentType = "application/json";

                var responseModel = new ApiResponseWrapper();

                switch (ex)
                {
                    case ValidationException e:
                       
                        response.StatusCode = (int)HttpStatusCode.BadRequest;
                        responseModel.HttpStatusCode = HttpStatusCode.BadRequest;
                        //Por compatibilidad se conserva. Hasta unificar el uso de ErrorInfo
                        responseModel.Errors = e.Errors.Select(e => e.ErrorMessage).ToList();

                        response.Headers.Add(GestionErroresConsts.NombreCabeceraEstablecerFormatoErrorAbp, "true");
                        responseModel.Error = Convertir(e);
                        
                        break;

                    case ReglaNegocioException e:

                        response.StatusCode = (int)HttpStatusCode.Forbidden;
                        responseModel.HttpStatusCode = HttpStatusCode.Forbidden;
                        response.Headers.Add(GestionErroresConsts.NombreCabeceraEstablecerFormatoErrorAbp, "true");
                        responseModel.Error = Convertir(e);

                        break;

                    default:
                        response.StatusCode = (int)HttpStatusCode.InternalServerError;
                        responseModel.HttpStatusCode = HttpStatusCode.InternalServerError;

                        //Por compatibilidad se conserva. Hasta unificar el uso de ErrorInfo
                        responseModel.Errors = new List<string> { ex.InnerException is null ? ex.Message : ex.InnerException.Message };

                        responseModel.Error = Convertir(ex);

                        break;
                }

                _logger.LogError(ex, ex.InnerException is null ? ex.Message : ex.InnerException.Message);

                //JsonConvert.DefaultSettings = () => new JsonSerializerSettings
                //{
                //    ContractResolver = new CamelCasePropertyNamesContractResolver()
                //};


                DefaultContractResolver contractResolver = new DefaultContractResolver
                {
                    NamingStrategy = new CamelCaseNamingStrategy()
                };

                await response.WriteAsync(JsonConvert.SerializeObject(responseModel, new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore, ContractResolver= contractResolver })).ConfigureAwait(false);
            }
        }


        private ErrorInfo Convertir(ValidationException validationException) {

            var errorInfo = new ErrorInfo();
            errorInfo.Message = TextosConsts.ControlErrores.TituloValidaciones;
            errorInfo.Details = GetValidationErrorNarrative(validationException.Errors);
            errorInfo.ValidationErrors = GetValidationErrorInfos(validationException.Errors);

            return errorInfo;
        }

        private ErrorInfo Convertir(ReglaNegocioException reglaNegocioException)
        {
            var errorInfo = new ErrorInfo();
            errorInfo.Message = reglaNegocioException.MensajeAmigable;

            return errorInfo;
        }
        private ErrorInfo Convertir(Exception exception)
        {
            var errorInfo = new ErrorInfo();
            errorInfo.Message = TextosConsts.ControlErrores.TituloGenerar;

            return errorInfo;
        }

        protected virtual ErrorInfoValidation[] GetValidationErrorInfos(IEnumerable<ValidationFailure> validationErrors)
        {
            var validationErrorInfos = new List<ErrorInfoValidation>();

            foreach (var validationResult in validationErrors)
            {
                var validationError = new ErrorInfoValidation(validationResult.ErrorMessage);

                if (validationResult.PropertyName != null)
                {
                    validationError.Members = new string[] { validationResult.PropertyName};
                }

                validationErrorInfos.Add(validationError);
            }

            return validationErrorInfos.ToArray();
        }

        protected virtual string GetValidationErrorNarrative(IEnumerable<ValidationFailure> validationErrors)
        {
            var detailBuilder = new StringBuilder();
            detailBuilder.AppendLine("Los siguientes errores fueron detectados durante la validación.");

            foreach (var validationResult in validationErrors)
            {
                detailBuilder.AppendFormat(" - {0}", validationResult.ErrorMessage);
                detailBuilder.AppendLine();
            }

            return detailBuilder.ToString();
        }

        #endregion Methods
    }
}