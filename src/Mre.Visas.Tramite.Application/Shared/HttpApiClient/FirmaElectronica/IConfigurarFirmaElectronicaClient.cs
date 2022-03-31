namespace Mre.Visas.Tramite.Application.Shared.HttpApiClient
{
    public interface IConfigurarFirmaElectronicaClient
    {
        /// <returns>Success</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        System.Threading.Tasks.Task<ConfigurarFirmaElectronicaOutput> ConfigurarFirmaElectronicaGetAsync(System.Guid usuarioId);

        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>Success</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        System.Threading.Tasks.Task<ConfigurarFirmaElectronicaOutput> ConfigurarFirmaElectronicaGetAsync(System.Guid usuarioId, System.Threading.CancellationToken cancellationToken);

        void SetAccessToken(string accessToken);

        void AddHeaders(string name, string value);
    }

    public class ConfigurarFirmaElectronicaOutput
    {
        public byte[] Data { get; set; }

        public string Clave { get; set; }
    }

}
