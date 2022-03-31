using System.ComponentModel.DataAnnotations;

namespace Mre.Visas.Tramite.Application.Shared.HttpApiClient
{
    public interface IFirmaElectronicaClient
    {
        /// <returns>Success</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        System.Threading.Tasks.Task<FirmaElectronicaOutput> FirmarAsync(FirmaElectronicaInput input);

        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>Success</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        System.Threading.Tasks.Task<FirmaElectronicaOutput> FirmarAsync(FirmaElectronicaInput input, System.Threading.CancellationToken cancellationToken);

    }



    public class FirmaElectronicaOutput
    {
        public byte[] DocumentoFirmado { get; set; }


    }

    public class InsumosFirmaDto
    {
        /// <summary>
        /// Clave firma electronica
        /// </summary>
        [Required]
        public string Pass { get; set; }

        [Required]
        public string ModeloFirma { get; set; }

        public string Cargo { get; set; }

        public string Ubicacion { get; set; }

        [Required]
        public string TamanoFirma { get; set; }

        [Required]
        public string PosicionX { get; set; }

        [Required]
        public string PosicionY { get; set; }

        [Required]
        public string PaginaAFirmar { get; set; }
    }

    public class FirmaElectronicaInput
    {

        [Required]
        public byte[] Documento { get; set; }

        [Required]
        public byte[] Firma { get; set; }

        [Required]
        public InsumosFirmaDto InsumosFirma { get; set; }

    }


}
