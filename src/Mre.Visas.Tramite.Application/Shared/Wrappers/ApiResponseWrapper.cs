using System;
using System.Collections.Generic;
using System.Net;

namespace Mre.Visas.Tramite.Application.Shared.Wrappers
{
    public class ApiResponseWrapper
    {
        #region Constructors

        public ApiResponseWrapper()
        {
        }

        public ApiResponseWrapper(HttpStatusCode httpStatusCode, object result)
        {
            HttpStatusCode = httpStatusCode;
            Result = result;
        }

        public ApiResponseWrapper(HttpStatusCode httpStatusCode, string message)
        {
            HttpStatusCode = httpStatusCode;
            Message = message;
        }

        #endregion Constructors

        #region Properties

        [Obsolete("No utilizar sera eliminada. Se debe utilizar la propiedad  ErrorInfo")]
        public ICollection<string> Errors { get; set; }

        public HttpStatusCode HttpStatusCode { get; set; }

        public string Message { get; set; }

        public object Result { get; set; }

        #endregion Properties


        /// <summary>
        /// Unificar gestion errores en la UI
        /// </summary>
        public ErrorInfo Error { get; set; }


        public string ToStringErrors()
        {
            var result = "";
            if (Errors != null)
            {
                result = $"HttpStatusCode: {HttpStatusCode}. Mensaje: {Message}. errores: {string.Join(",", Errors)}";
                return result;
            }

            result = $"HttpStatusCode: {HttpStatusCode}. Mensaje: {Message}";
            return result;
        }
    }

   

    public class ApiResponseWrapper<T>
    {
        #region Constructors

        public ApiResponseWrapper()
        {
        }

        public ApiResponseWrapper(HttpStatusCode httpStatusCode, T result)
        {
            HttpStatusCode = httpStatusCode;
            Result = result;
        }

        public ApiResponseWrapper(HttpStatusCode httpStatusCode, string message)
        {
            HttpStatusCode = httpStatusCode;
            Message = message;
        }

        #endregion Constructors

        #region Properties

     
        public HttpStatusCode HttpStatusCode { get; set; }

        public string Message { get; set; }

        public T Result { get; set; }

        #endregion Properties

        /// <summary>
        /// Unificar gestion errores en la UI
        /// </summary>
        public ErrorInfo ErrorInfo { get; set; }

        public string ToStringErrors()
        {
            return  $"HttpStatusCode: {HttpStatusCode}. Mensaje: {Message}";
        }
    }

    

}