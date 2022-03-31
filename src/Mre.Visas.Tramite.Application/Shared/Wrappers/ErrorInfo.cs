using System;

namespace Mre.Visas.Tramite.Application.Shared.Wrappers
{
    /// <summary>
    /// Unificar gestion errores en la UI
    /// </summary>
    [Serializable]
    public class ErrorInfo
    {
    

        /// <summary>
        /// Error message.
        /// </summary>
        public string Message { get; set; }

        /// <summary>
        /// Error details.
        /// </summary>
        public string Details { get; set; }


        /// <summary>
        /// Validation errors if exists.
        /// </summary>
        public ErrorInfoValidation[] ValidationErrors { get; set; }

        /// <summary>
        /// Creates a new instance of <see cref="ErrorInfo"/>.
        /// </summary>
        public ErrorInfo()
        {

        }

        /// <summary>
        ///  Creates a new instance of <see cref="ErrorInfo"/>.
        /// </summary>
        /// <param name="message"></param>
        /// <param name="details"></param>
        public ErrorInfo(string message, string details = null)
        {
            Message = message;
            Details = details;
        }
    }

    /// <summary>
    /// Used to store information about a validation error.
    /// </summary>
    [Serializable]
    public class ErrorInfoValidation
    {
        /// <summary>
        /// Validation error message.
        /// </summary>
        public string Message { get; set; }

        /// <summary>
        /// Relate invalid members (fields/properties).
        /// </summary>
        public string[] Members { get; set; }

        /// <summary>
        /// Creates a new instance of <see cref="ErrorInfoValidation"/>.
        /// </summary>
        public ErrorInfoValidation()
        {

        }

        /// <summary>
        /// Creates a new instance of <see cref="ErrorInfoValidation"/>.
        /// </summary>
        /// <param name="message">Validation error message</param>
        public ErrorInfoValidation(string message)
        {
            Message = message;
        }

        /// <summary>
        /// Creates a new instance of <see cref="ErrorInfoValidation"/>.
        /// </summary>
        /// <param name="message">Validation error message</param>
        /// <param name="members">Related invalid members</param>
        public ErrorInfoValidation(string message, string[] members)
            : this(message)
        {
            Members = members;
        }

        /// <summary>
        /// Creates a new instance of <see cref="ErrorInfoValidation"/>.
        /// </summary>
        /// <param name="message">Validation error message</param>
        /// <param name="member">Related invalid member</param>
        public ErrorInfoValidation(string message, string member)
            : this(message, new[] { member })
        {

        }
    }

}