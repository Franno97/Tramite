using System;

namespace Mre.Visas.Tramite.Domain
{

    /// <summary>
    /// Exception para lanzar error por el incumplimiento de reglas negocios
    /// </summary>
    [Serializable]
    public class ReglaNegocioException : Exception
    {
        public string MensajeAmigable { get; }
        public ReglaNegocioException(string mensajeAmigable)
        {
            MensajeAmigable = mensajeAmigable;
        }

        public ReglaNegocioException(string mensajeAmigable, string mensajeTecnico) : base(mensajeTecnico) {
            MensajeAmigable = mensajeAmigable;
        }

        public ReglaNegocioException(string mensajeAmigable, string mensajeTecnico, Exception inner) : base(mensajeTecnico, inner) {
            MensajeAmigable = mensajeAmigable;
        }

        protected ReglaNegocioException(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context) : base(info, context) { }

       
    }
}
