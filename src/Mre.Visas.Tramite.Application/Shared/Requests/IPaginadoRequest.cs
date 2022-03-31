namespace Mre.Visas.Tramite.Application.Shared.Requests
{
    public interface IPaginadoRequest
    {
        /// <summary>
        /// Maximo items retornados
        /// </summary>
        int MaximoResultado { get; set; }

        /// <summary>
        /// Permite saltar un numero de items para retornar. (inicio pagina)
        /// </summary>
        int Saltar { get; set; }

    }
}
