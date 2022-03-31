using System;
using System.Collections.Generic;

namespace Mre.Visas.Tramite.Application.Shared.Responses
{
    public interface IResultadoPaginadoResponse<T>
    {
        /// <summary>
        /// Resultado devuelto por la consulta a la tabla Customers
        /// en función de todos los parámetros anteriores.
        /// </summary>
        IReadOnlyList<T> Items { get; set; }

        /// <summary>
        /// Total de registros de consulta.
        /// </summary>
        long TotalRegistros { get; set; }
    }


    [Serializable]
    public class ResultadoPaginadoResponse<T> : IResultadoPaginadoResponse<T>
    {
        public ResultadoPaginadoResponse(IReadOnlyList<T> items, long totalRegistros)
        {
            this.Items = items;
            this.TotalRegistros = totalRegistros;
        }

        /// <inheritdoc />
        public long TotalRegistros { get; set; }

        /// <inheritdoc />
        public IReadOnlyList<T> Items { get; set; }
        
    }

    
}
