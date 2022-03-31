using System;

namespace Mre.Visas.Tramite.Application.Shared.Requests
{
    public interface IPaginadoYOrdenadoRequest: IPaginadoRequest, IOrdenadoRequest
    {
        
    }


    [Serializable]
    public class PaginadoYOrdenadoRequest : PaginadoRequest, IPaginadoYOrdenadoRequest
    {
        public string Orden { get; set; }
    }


}
