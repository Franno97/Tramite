using System.Linq;
using System.Linq.Dynamic.Core;

namespace Mre.Visas.Tramite.Infrastructure.Shared
{
    public static class QueryableExtensions
    {
        public static  IQueryable<T> ToConsultaPaginada<T>(this IQueryable<T> consultaOrigen, int saltar, int maximoResultado) where T : class
        { 
        
            return consultaOrigen.Skip(saltar).Take(maximoResultado);
        }

        public static IQueryable<T> ToConsultaOrdenada<T>(this IQueryable<T> consultaOrigen, string orden) where T : class
        {

            return consultaOrigen.OrderBy(orden);
        }
    }
}
