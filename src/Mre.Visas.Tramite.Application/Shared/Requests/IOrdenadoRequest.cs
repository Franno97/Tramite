namespace Mre.Visas.Tramite.Application.Shared.Requests
{
    public interface IOrdenadoRequest {

        /// <summary>
        /// La expresion de orden que se aplicara
        /// </summary>
        string Orden { get; set; }

    }
}
