using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Mre.Visas.Tramite.Application.Shared.Requests
{
    



    /// <inheritdoc />
    [Serializable]
    public class PaginadoRequest : IValidatableObject, IPaginadoRequest
    {

        public static int MaximoResultadoDefault { get; set; } = 10;


        public static int MaximoResultadoMax { get; set; } = 1000;


        /// <inheritdoc />
        [Range(1, int.MaxValue)]
        public virtual int MaximoResultado { get; set; } = MaximoResultadoDefault;


        /// <inheritdoc />
        [Range(0, int.MaxValue)]
        public virtual int Saltar { get; set; } = 0;


        public virtual IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (MaximoResultado > MaximoResultadoMax)
            {
                yield return new ValidationResult(string.Format("El valor Maximo Resultado {0}, sobrepasa el Maximo permitido {1}", MaximoResultado, MaximoResultadoMax));
            }
        }
    }
}
