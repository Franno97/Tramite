using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mre.Visas.Tramite.Application.Shared.HttpApiClient
{
    [System.CodeDom.Compiler.GeneratedCode("NSwag", "13.15.10.0 (NJsonSchema v10.6.10.0 (Newtonsoft.Json v12.0.0.0))")]
    public partial interface IUnidadAdministrativaClient
    {

        void SetAccessToken(string accessToken);

        void AddHeaders(string name, string value);


        /// <returns>Success</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        System.Threading.Tasks.Task<PagedResultDto_1OfOfArancelDtoAndContractsAnd_0AndCulture_neutralAndPublicKeyToken_null> ArancelGetAsync(string filter, string sorting, int? skipCount, int? maxResultCount);

        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>Success</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        System.Threading.Tasks.Task<PagedResultDto_1OfOfArancelDtoAndContractsAnd_0AndCulture_neutralAndPublicKeyToken_null> ArancelGetAsync(string filter, string sorting, int? skipCount, int? maxResultCount, System.Threading.CancellationToken cancellationToken);

        /// <returns>Success</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        System.Threading.Tasks.Task<ArancelDto> ArancelPostAsync(CrearActualizarArancelDto body);

        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>Success</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        System.Threading.Tasks.Task<ArancelDto> ArancelPostAsync(CrearActualizarArancelDto body, System.Threading.CancellationToken cancellationToken);

        /// <returns>Success</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        System.Threading.Tasks.Task<ArancelDto> ArancelGetAsync(System.Guid id);

        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>Success</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        System.Threading.Tasks.Task<ArancelDto> ArancelGetAsync(System.Guid id, System.Threading.CancellationToken cancellationToken);

        /// <returns>Success</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        System.Threading.Tasks.Task<ArancelDto> ArancelPutAsync(System.Guid id, CrearActualizarArancelDto body);

        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>Success</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        System.Threading.Tasks.Task<ArancelDto> ArancelPutAsync(System.Guid id, CrearActualizarArancelDto body, System.Threading.CancellationToken cancellationToken);

        /// <returns>Success</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        System.Threading.Tasks.Task ArancelDeleteAsync(System.Guid id);

        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>Success</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        System.Threading.Tasks.Task ArancelDeleteAsync(System.Guid id, System.Threading.CancellationToken cancellationToken);

        /// <returns>Success</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        System.Threading.Tasks.Task<PagedResultDto_1OfOfBancoDtoAndContractsAnd_0AndCulture_neutralAndPublicKeyToken_null> BancoGetAsync(int? skipCount, int? maxResultCount, string sorting);

        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>Success</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        System.Threading.Tasks.Task<PagedResultDto_1OfOfBancoDtoAndContractsAnd_0AndCulture_neutralAndPublicKeyToken_null> BancoGetAsync(int? skipCount, int? maxResultCount, string sorting, System.Threading.CancellationToken cancellationToken);

        /// <returns>Success</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        System.Threading.Tasks.Task<BancoDto> BancoPostAsync(BancoDto body);

        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>Success</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        System.Threading.Tasks.Task<BancoDto> BancoPostAsync(BancoDto body, System.Threading.CancellationToken cancellationToken);

        /// <returns>Success</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        System.Threading.Tasks.Task<BancoDto> BancoGetAsync(string id);

        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>Success</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        System.Threading.Tasks.Task<BancoDto> BancoGetAsync(string id, System.Threading.CancellationToken cancellationToken);

        /// <returns>Success</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        System.Threading.Tasks.Task<BancoDto> BancoPutAsync(string id, BancoDto body);

        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>Success</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        System.Threading.Tasks.Task<BancoDto> BancoPutAsync(string id, BancoDto body, System.Threading.CancellationToken cancellationToken);

        /// <returns>Success</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        System.Threading.Tasks.Task BancoDeleteAsync(string id);

        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>Success</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        System.Threading.Tasks.Task BancoDeleteAsync(string id, System.Threading.CancellationToken cancellationToken);

        /// <returns>Success</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        System.Threading.Tasks.Task ConfigurarFirmaElectronicaGetAsync(System.Guid usuarioId);

        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>Success</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        System.Threading.Tasks.Task ConfigurarFirmaElectronicaGetAsync(System.Guid usuarioId, System.Threading.CancellationToken cancellationToken);

        /// <returns>Success</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        System.Threading.Tasks.Task<bool> ConfigurarFirmaElectronicaPutAsync(FileParameter archivoFirma, string claveFirma);

        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>Success</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        System.Threading.Tasks.Task<bool> ConfigurarFirmaElectronicaPutAsync(FileParameter archivoFirma, string claveFirma, System.Threading.CancellationToken cancellationToken);

        /// <returns>Success</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        System.Threading.Tasks.Task<bool> ConfigurarFirmaElectronicaDeleteAsync();

        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>Success</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        System.Threading.Tasks.Task<bool> ConfigurarFirmaElectronicaDeleteAsync(System.Threading.CancellationToken cancellationToken);

        /// <returns>Success</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        System.Threading.Tasks.Task<PagedResultDto_1OfOfConvenioDtoAndContractsAnd_0AndCulture_neutralAndPublicKeyToken_null> ConvenioGetAsync(string filter, string sorting, int? skipCount, int? maxResultCount);

        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>Success</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        System.Threading.Tasks.Task<PagedResultDto_1OfOfConvenioDtoAndContractsAnd_0AndCulture_neutralAndPublicKeyToken_null> ConvenioGetAsync(string filter, string sorting, int? skipCount, int? maxResultCount, System.Threading.CancellationToken cancellationToken);

        /// <returns>Success</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        System.Threading.Tasks.Task<ConvenioDto> ConvenioPostAsync(CrearActualizarConvenioDto body);

        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>Success</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        System.Threading.Tasks.Task<ConvenioDto> ConvenioPostAsync(CrearActualizarConvenioDto body, System.Threading.CancellationToken cancellationToken);

        /// <returns>Success</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        System.Threading.Tasks.Task<ConvenioDto> ConvenioGetAsync(System.Guid id);

        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>Success</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        System.Threading.Tasks.Task<ConvenioDto> ConvenioGetAsync(System.Guid id, System.Threading.CancellationToken cancellationToken);

        /// <returns>Success</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        System.Threading.Tasks.Task<ConvenioDto> ConvenioPutAsync(System.Guid id, CrearActualizarConvenioDto body);

        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>Success</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        System.Threading.Tasks.Task<ConvenioDto> ConvenioPutAsync(System.Guid id, CrearActualizarConvenioDto body, System.Threading.CancellationToken cancellationToken);

        /// <returns>Success</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        System.Threading.Tasks.Task ConvenioDeleteAsync(System.Guid id);

        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>Success</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        System.Threading.Tasks.Task ConvenioDeleteAsync(System.Guid id, System.Threading.CancellationToken cancellationToken);

        /// <returns>Success</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        System.Threading.Tasks.Task<PagedResultDto_1OfOfEntidadAuspicianteDtoAndContractsAnd_0AndCulture_neutralAndPublicKeyToken_null> EntidadAuspicianteGetAsync(int? skipCount, int? maxResultCount, string sorting);

        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>Success</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        System.Threading.Tasks.Task<PagedResultDto_1OfOfEntidadAuspicianteDtoAndContractsAnd_0AndCulture_neutralAndPublicKeyToken_null> EntidadAuspicianteGetAsync(int? skipCount, int? maxResultCount, string sorting, System.Threading.CancellationToken cancellationToken);

        /// <returns>Success</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        System.Threading.Tasks.Task<EntidadAuspicianteDto> EntidadAuspiciantePostAsync(EntidadAuspicianteDto body);

        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>Success</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        System.Threading.Tasks.Task<EntidadAuspicianteDto> EntidadAuspiciantePostAsync(EntidadAuspicianteDto body, System.Threading.CancellationToken cancellationToken);

        /// <returns>Success</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        System.Threading.Tasks.Task<EntidadAuspicianteDto> EntidadAuspicianteGetAsync(string id);

        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>Success</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        System.Threading.Tasks.Task<EntidadAuspicianteDto> EntidadAuspicianteGetAsync(string id, System.Threading.CancellationToken cancellationToken);

        /// <returns>Success</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        System.Threading.Tasks.Task<EntidadAuspicianteDto> EntidadAuspiciantePutAsync(string id, EntidadAuspicianteDto body);

        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>Success</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        System.Threading.Tasks.Task<EntidadAuspicianteDto> EntidadAuspiciantePutAsync(string id, EntidadAuspicianteDto body, System.Threading.CancellationToken cancellationToken);

        /// <returns>Success</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        System.Threading.Tasks.Task EntidadAuspicianteDeleteAsync(string id);

        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>Success</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        System.Threading.Tasks.Task EntidadAuspicianteDeleteAsync(string id, System.Threading.CancellationToken cancellationToken);

        /// <returns>Success</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        System.Threading.Tasks.Task<PagedResultDto_1OfOfJerarquiaArancelariaDtoAndContractsAnd_0AndCulture_neutralAndPublicKeyToken_null> JerarquiaArancelariaGetAsync(string filter, string sorting, int? skipCount, int? maxResultCount);

        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>Success</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        System.Threading.Tasks.Task<PagedResultDto_1OfOfJerarquiaArancelariaDtoAndContractsAnd_0AndCulture_neutralAndPublicKeyToken_null> JerarquiaArancelariaGetAsync(string filter, string sorting, int? skipCount, int? maxResultCount, System.Threading.CancellationToken cancellationToken);

        /// <returns>Success</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        System.Threading.Tasks.Task<JerarquiaArancelariaDto> JerarquiaArancelariaPostAsync(CrearActualizarJerarquiaArancelariaDto body);

        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>Success</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        System.Threading.Tasks.Task<JerarquiaArancelariaDto> JerarquiaArancelariaPostAsync(CrearActualizarJerarquiaArancelariaDto body, System.Threading.CancellationToken cancellationToken);

        /// <returns>Success</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        System.Threading.Tasks.Task<JerarquiaArancelariaDto> JerarquiaArancelariaGetAsync(System.Guid id);

        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>Success</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        System.Threading.Tasks.Task<JerarquiaArancelariaDto> JerarquiaArancelariaGetAsync(System.Guid id, System.Threading.CancellationToken cancellationToken);

        /// <returns>Success</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        System.Threading.Tasks.Task<JerarquiaArancelariaDto> JerarquiaArancelariaPutAsync(System.Guid id, CrearActualizarJerarquiaArancelariaDto body);

        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>Success</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        System.Threading.Tasks.Task<JerarquiaArancelariaDto> JerarquiaArancelariaPutAsync(System.Guid id, CrearActualizarJerarquiaArancelariaDto body, System.Threading.CancellationToken cancellationToken);

        /// <returns>Success</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        System.Threading.Tasks.Task JerarquiaArancelariaDeleteAsync(System.Guid id);

        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>Success</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        System.Threading.Tasks.Task JerarquiaArancelariaDeleteAsync(System.Guid id, System.Threading.CancellationToken cancellationToken);

        /// <returns>Success</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        System.Threading.Tasks.Task<PagedResultDto_1OfOfLibroDtoAndContractsAnd_0AndCulture_neutralAndPublicKeyToken_null> LibroGetAsync(int? skipCount, int? maxResultCount, string sorting);

        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>Success</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        System.Threading.Tasks.Task<PagedResultDto_1OfOfLibroDtoAndContractsAnd_0AndCulture_neutralAndPublicKeyToken_null> LibroGetAsync(int? skipCount, int? maxResultCount, string sorting, System.Threading.CancellationToken cancellationToken);

        /// <returns>Success</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        System.Threading.Tasks.Task<LibroDto> LibroPostAsync(LibroDto body);

        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>Success</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        System.Threading.Tasks.Task<LibroDto> LibroPostAsync(LibroDto body, System.Threading.CancellationToken cancellationToken);

        /// <returns>Success</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        System.Threading.Tasks.Task<LibroDto> LibroGetAsync(string id);

        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>Success</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        System.Threading.Tasks.Task<LibroDto> LibroGetAsync(string id, System.Threading.CancellationToken cancellationToken);

        /// <returns>Success</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        System.Threading.Tasks.Task<LibroDto> LibroPutAsync(string id, LibroDto body);

        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>Success</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        System.Threading.Tasks.Task<LibroDto> LibroPutAsync(string id, LibroDto body, System.Threading.CancellationToken cancellationToken);

        /// <returns>Success</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        System.Threading.Tasks.Task LibroDeleteAsync(string id);

        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>Success</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        System.Threading.Tasks.Task LibroDeleteAsync(string id, System.Threading.CancellationToken cancellationToken);

        /// <returns>Success</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        System.Threading.Tasks.Task<PagedResultDto_1OfOfMonedaDtoAndContractsAnd_0AndCulture_neutralAndPublicKeyToken_null> MonedaGetAsync(int? skipCount, int? maxResultCount, string sorting);

        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>Success</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        System.Threading.Tasks.Task<PagedResultDto_1OfOfMonedaDtoAndContractsAnd_0AndCulture_neutralAndPublicKeyToken_null> MonedaGetAsync(int? skipCount, int? maxResultCount, string sorting, System.Threading.CancellationToken cancellationToken);

        /// <returns>Success</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        System.Threading.Tasks.Task<MonedaDto> MonedaPostAsync(MonedaDto body);

        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>Success</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        System.Threading.Tasks.Task<MonedaDto> MonedaPostAsync(MonedaDto body, System.Threading.CancellationToken cancellationToken);

        /// <returns>Success</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        System.Threading.Tasks.Task<MonedaDto> MonedaGetAsync(string id);

        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>Success</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        System.Threading.Tasks.Task<MonedaDto> MonedaGetAsync(string id, System.Threading.CancellationToken cancellationToken);

        /// <returns>Success</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        System.Threading.Tasks.Task<MonedaDto> MonedaPutAsync(string id, MonedaDto body);

        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>Success</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        System.Threading.Tasks.Task<MonedaDto> MonedaPutAsync(string id, MonedaDto body, System.Threading.CancellationToken cancellationToken);

        /// <returns>Success</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        System.Threading.Tasks.Task MonedaDeleteAsync(string id);

        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>Success</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        System.Threading.Tasks.Task MonedaDeleteAsync(string id, System.Threading.CancellationToken cancellationToken);

        /// <returns>Success</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        System.Threading.Tasks.Task<PagedResultDto_1OfOfNivelDtoAndContractsAnd_0AndCulture_neutralAndPublicKeyToken_null> NivelGetAsync(int? skipCount, int? maxResultCount, string sorting);

        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>Success</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        System.Threading.Tasks.Task<PagedResultDto_1OfOfNivelDtoAndContractsAnd_0AndCulture_neutralAndPublicKeyToken_null> NivelGetAsync(int? skipCount, int? maxResultCount, string sorting, System.Threading.CancellationToken cancellationToken);

        /// <returns>Success</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        System.Threading.Tasks.Task<NivelDto> NivelPostAsync(NivelDto body);

        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>Success</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        System.Threading.Tasks.Task<NivelDto> NivelPostAsync(NivelDto body, System.Threading.CancellationToken cancellationToken);

        /// <returns>Success</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        System.Threading.Tasks.Task<NivelDto> NivelGetAsync(string id);

        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>Success</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        System.Threading.Tasks.Task<NivelDto> NivelGetAsync(string id, System.Threading.CancellationToken cancellationToken);

        /// <returns>Success</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        System.Threading.Tasks.Task<NivelDto> NivelPutAsync(string id, NivelDto body);

        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>Success</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        System.Threading.Tasks.Task<NivelDto> NivelPutAsync(string id, NivelDto body, System.Threading.CancellationToken cancellationToken);

        /// <returns>Success</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        System.Threading.Tasks.Task NivelDeleteAsync(string id);

        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>Success</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        System.Threading.Tasks.Task NivelDeleteAsync(string id, System.Threading.CancellationToken cancellationToken);

        /// <returns>Success</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        System.Threading.Tasks.Task<PagedResultDto_1OfOfPartidaArancelariaDtoAndContractsAnd_0AndCulture_neutralAndPublicKeyToken_null> PartidaArancelariaGetAsync(string filter, string sorting, int? skipCount, int? maxResultCount);

        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>Success</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        System.Threading.Tasks.Task<PagedResultDto_1OfOfPartidaArancelariaDtoAndContractsAnd_0AndCulture_neutralAndPublicKeyToken_null> PartidaArancelariaGetAsync(string filter, string sorting, int? skipCount, int? maxResultCount, System.Threading.CancellationToken cancellationToken);

        /// <returns>Success</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        System.Threading.Tasks.Task<PartidaArancelariaDto> PartidaArancelariaPostAsync(CrearActualizarPartidaArancelariaDto body);

        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>Success</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        System.Threading.Tasks.Task<PartidaArancelariaDto> PartidaArancelariaPostAsync(CrearActualizarPartidaArancelariaDto body, System.Threading.CancellationToken cancellationToken);

        /// <returns>Success</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        System.Threading.Tasks.Task<PartidaArancelariaDto> PartidaArancelariaGetAsync(System.Guid id);

        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>Success</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        System.Threading.Tasks.Task<PartidaArancelariaDto> PartidaArancelariaGetAsync(System.Guid id, System.Threading.CancellationToken cancellationToken);

        /// <returns>Success</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        System.Threading.Tasks.Task<PartidaArancelariaDto> PartidaArancelariaPutAsync(System.Guid id, CrearActualizarPartidaArancelariaDto body);

        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>Success</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        System.Threading.Tasks.Task<PartidaArancelariaDto> PartidaArancelariaPutAsync(System.Guid id, CrearActualizarPartidaArancelariaDto body, System.Threading.CancellationToken cancellationToken);

        /// <returns>Success</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        System.Threading.Tasks.Task PartidaArancelariaDeleteAsync(System.Guid id);

        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>Success</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        System.Threading.Tasks.Task PartidaArancelariaDeleteAsync(System.Guid id, System.Threading.CancellationToken cancellationToken);

        /// <returns>Success</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        System.Threading.Tasks.Task<ListResultDto_1OfOfPartidaArancelariaServicioDtoAndContractsAnd_0AndCulture_neutralAndPublicKeyToken_null> PartidaArancelariaServicioAsync(System.Guid servicioId);

        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>Success</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        System.Threading.Tasks.Task<ListResultDto_1OfOfPartidaArancelariaServicioDtoAndContractsAnd_0AndCulture_neutralAndPublicKeyToken_null> PartidaArancelariaServicioAsync(System.Guid servicioId, System.Threading.CancellationToken cancellationToken);

        /// <returns>Success</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        System.Threading.Tasks.Task<PagedResultDto_1OfOfSecuencialLibroDtoAndContractsAnd_0AndCulture_neutralAndPublicKeyToken_null> SecuencialLibroGetAsync(int? skipCount, int? maxResultCount, string sorting);

        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>Success</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        System.Threading.Tasks.Task<PagedResultDto_1OfOfSecuencialLibroDtoAndContractsAnd_0AndCulture_neutralAndPublicKeyToken_null> SecuencialLibroGetAsync(int? skipCount, int? maxResultCount, string sorting, System.Threading.CancellationToken cancellationToken);

        /// <returns>Success</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        System.Threading.Tasks.Task<SecuencialLibroDto> SecuencialLibroPostAsync(CrearActualizarSecuencialLibroDto body);

        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>Success</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        System.Threading.Tasks.Task<SecuencialLibroDto> SecuencialLibroPostAsync(CrearActualizarSecuencialLibroDto body, System.Threading.CancellationToken cancellationToken);

        /// <returns>Success</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        System.Threading.Tasks.Task<SecuencialLibroDto> SecuencialLibroGetAsync(System.Guid id);

        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>Success</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        System.Threading.Tasks.Task<SecuencialLibroDto> SecuencialLibroGetAsync(System.Guid id, System.Threading.CancellationToken cancellationToken);

        /// <returns>Success</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        System.Threading.Tasks.Task<SecuencialLibroDto> SecuencialLibroPutAsync(System.Guid id, CrearActualizarSecuencialLibroDto body);

        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>Success</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        System.Threading.Tasks.Task<SecuencialLibroDto> SecuencialLibroPutAsync(System.Guid id, CrearActualizarSecuencialLibroDto body, System.Threading.CancellationToken cancellationToken);

        /// <returns>Success</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        System.Threading.Tasks.Task SecuencialLibroDeleteAsync(System.Guid id);

        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>Success</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        System.Threading.Tasks.Task SecuencialLibroDeleteAsync(System.Guid id, System.Threading.CancellationToken cancellationToken);

        /// <returns>Success</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        System.Threading.Tasks.Task<PagedResultDto_1OfOfServicioDtoAndContractsAnd_0AndCulture_neutralAndPublicKeyToken_null> ServicioGetAsync(string filter, string sorting, int? skipCount, int? maxResultCount);

        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>Success</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        System.Threading.Tasks.Task<PagedResultDto_1OfOfServicioDtoAndContractsAnd_0AndCulture_neutralAndPublicKeyToken_null> ServicioGetAsync(string filter, string sorting, int? skipCount, int? maxResultCount, System.Threading.CancellationToken cancellationToken);

        /// <returns>Success</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        System.Threading.Tasks.Task<ServicioDto> ServicioPostAsync(CrearActualizarServicioDto body);

        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>Success</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        System.Threading.Tasks.Task<ServicioDto> ServicioPostAsync(CrearActualizarServicioDto body, System.Threading.CancellationToken cancellationToken);

        /// <returns>Success</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        System.Threading.Tasks.Task<ServicioDto> ServicioGetAsync(System.Guid id);

        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>Success</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        System.Threading.Tasks.Task<ServicioDto> ServicioGetAsync(System.Guid id, System.Threading.CancellationToken cancellationToken);

        /// <returns>Success</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        System.Threading.Tasks.Task<ServicioDto> ServicioPutAsync(System.Guid id, CrearActualizarServicioDto body);

        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>Success</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        System.Threading.Tasks.Task<ServicioDto> ServicioPutAsync(System.Guid id, CrearActualizarServicioDto body, System.Threading.CancellationToken cancellationToken);

        /// <returns>Success</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        System.Threading.Tasks.Task ServicioDeleteAsync(System.Guid id);

        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>Success</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        System.Threading.Tasks.Task ServicioDeleteAsync(System.Guid id, System.Threading.CancellationToken cancellationToken);

        /// <returns>Success</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        System.Threading.Tasks.Task<PagedResultDto_1OfOfTipoArancelDtoAndContractsAnd_0AndCulture_neutralAndPublicKeyToken_null> TipoArancelGetAsync(int? skipCount, int? maxResultCount, string sorting);

        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>Success</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        System.Threading.Tasks.Task<PagedResultDto_1OfOfTipoArancelDtoAndContractsAnd_0AndCulture_neutralAndPublicKeyToken_null> TipoArancelGetAsync(int? skipCount, int? maxResultCount, string sorting, System.Threading.CancellationToken cancellationToken);

        /// <returns>Success</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        System.Threading.Tasks.Task<TipoArancelDto> TipoArancelPostAsync(TipoArancelDto body);

        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>Success</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        System.Threading.Tasks.Task<TipoArancelDto> TipoArancelPostAsync(TipoArancelDto body, System.Threading.CancellationToken cancellationToken);

        /// <returns>Success</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        System.Threading.Tasks.Task<TipoArancelDto> TipoArancelGetAsync(string id);

        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>Success</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        System.Threading.Tasks.Task<TipoArancelDto> TipoArancelGetAsync(string id, System.Threading.CancellationToken cancellationToken);

        /// <returns>Success</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        System.Threading.Tasks.Task<TipoArancelDto> TipoArancelPutAsync(string id, TipoArancelDto body);

        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>Success</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        System.Threading.Tasks.Task<TipoArancelDto> TipoArancelPutAsync(string id, TipoArancelDto body, System.Threading.CancellationToken cancellationToken);

        /// <returns>Success</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        System.Threading.Tasks.Task TipoArancelDeleteAsync(string id);

        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>Success</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        System.Threading.Tasks.Task TipoArancelDeleteAsync(string id, System.Threading.CancellationToken cancellationToken);

        /// <returns>Success</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        System.Threading.Tasks.Task<PagedResultDto_1OfOfTipoExoneracionDtoAndContractsAnd_0AndCulture_neutralAndPublicKeyToken_null> TipoExoneracionGetAsync(int? skipCount, int? maxResultCount, string sorting);

        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>Success</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        System.Threading.Tasks.Task<PagedResultDto_1OfOfTipoExoneracionDtoAndContractsAnd_0AndCulture_neutralAndPublicKeyToken_null> TipoExoneracionGetAsync(int? skipCount, int? maxResultCount, string sorting, System.Threading.CancellationToken cancellationToken);

        /// <returns>Success</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        System.Threading.Tasks.Task<TipoExoneracionDto> TipoExoneracionPostAsync(TipoExoneracionDto body);

        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>Success</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        System.Threading.Tasks.Task<TipoExoneracionDto> TipoExoneracionPostAsync(TipoExoneracionDto body, System.Threading.CancellationToken cancellationToken);

        /// <returns>Success</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        System.Threading.Tasks.Task<TipoExoneracionDto> TipoExoneracionGetAsync(string id);

        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>Success</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        System.Threading.Tasks.Task<TipoExoneracionDto> TipoExoneracionGetAsync(string id, System.Threading.CancellationToken cancellationToken);

        /// <returns>Success</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        System.Threading.Tasks.Task<TipoExoneracionDto> TipoExoneracionPutAsync(string id, TipoExoneracionDto body);

        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>Success</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        System.Threading.Tasks.Task<TipoExoneracionDto> TipoExoneracionPutAsync(string id, TipoExoneracionDto body, System.Threading.CancellationToken cancellationToken);

        /// <returns>Success</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        System.Threading.Tasks.Task TipoExoneracionDeleteAsync(string id);

        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>Success</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        System.Threading.Tasks.Task TipoExoneracionDeleteAsync(string id, System.Threading.CancellationToken cancellationToken);

        /// <returns>Success</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        System.Threading.Tasks.Task<PagedResultDto_1OfOfTipoPagoDtoAndContractsAnd_0AndCulture_neutralAndPublicKeyToken_null> TipoPagoGetAsync(int? skipCount, int? maxResultCount, string sorting);

        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>Success</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        System.Threading.Tasks.Task<PagedResultDto_1OfOfTipoPagoDtoAndContractsAnd_0AndCulture_neutralAndPublicKeyToken_null> TipoPagoGetAsync(int? skipCount, int? maxResultCount, string sorting, System.Threading.CancellationToken cancellationToken);

        /// <returns>Success</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        System.Threading.Tasks.Task<TipoPagoDto> TipoPagoPostAsync(TipoPagoDto body);

        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>Success</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        System.Threading.Tasks.Task<TipoPagoDto> TipoPagoPostAsync(TipoPagoDto body, System.Threading.CancellationToken cancellationToken);

        /// <returns>Success</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        System.Threading.Tasks.Task<TipoPagoDto> TipoPagoGetAsync(string id);

        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>Success</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        System.Threading.Tasks.Task<TipoPagoDto> TipoPagoGetAsync(string id, System.Threading.CancellationToken cancellationToken);

        /// <returns>Success</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        System.Threading.Tasks.Task<TipoPagoDto> TipoPagoPutAsync(string id, TipoPagoDto body);

        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>Success</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        System.Threading.Tasks.Task<TipoPagoDto> TipoPagoPutAsync(string id, TipoPagoDto body, System.Threading.CancellationToken cancellationToken);

        /// <returns>Success</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        System.Threading.Tasks.Task TipoPagoDeleteAsync(string id);

        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>Success</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        System.Threading.Tasks.Task TipoPagoDeleteAsync(string id, System.Threading.CancellationToken cancellationToken);

        /// <returns>Success</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        System.Threading.Tasks.Task<PagedResultDto_1OfOfTipoServicioDtoAndContractsAnd_0AndCulture_neutralAndPublicKeyToken_null> ServicioTipoGetAsync(int? skipCount, int? maxResultCount, string sorting);

        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>Success</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        System.Threading.Tasks.Task<PagedResultDto_1OfOfTipoServicioDtoAndContractsAnd_0AndCulture_neutralAndPublicKeyToken_null> ServicioTipoGetAsync(int? skipCount, int? maxResultCount, string sorting, System.Threading.CancellationToken cancellationToken);

        /// <returns>Success</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        System.Threading.Tasks.Task<TipoServicioDto> ServicioTipoPostAsync(TipoServicioDto body);

        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>Success</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        System.Threading.Tasks.Task<TipoServicioDto> ServicioTipoPostAsync(TipoServicioDto body, System.Threading.CancellationToken cancellationToken);

        /// <returns>Success</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        System.Threading.Tasks.Task<TipoServicioDto> ServicioTipoGetAsync(string id);

        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>Success</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        System.Threading.Tasks.Task<TipoServicioDto> ServicioTipoGetAsync(string id, System.Threading.CancellationToken cancellationToken);

        /// <returns>Success</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        System.Threading.Tasks.Task<TipoServicioDto> ServicioTipoPutAsync(string id, TipoServicioDto body);

        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>Success</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        System.Threading.Tasks.Task<TipoServicioDto> ServicioTipoPutAsync(string id, TipoServicioDto body, System.Threading.CancellationToken cancellationToken);

        /// <returns>Success</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        System.Threading.Tasks.Task ServicioTipoDeleteAsync(string id);

        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>Success</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        System.Threading.Tasks.Task ServicioTipoDeleteAsync(string id, System.Threading.CancellationToken cancellationToken);

        /// <returns>Success</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        System.Threading.Tasks.Task<UnidadAdministrativaDto> UnidadAdministrativaPostAsync(CrearActualizarUnidadAdministrativaDto body);

        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>Success</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        System.Threading.Tasks.Task<UnidadAdministrativaDto> UnidadAdministrativaPostAsync(CrearActualizarUnidadAdministrativaDto body, System.Threading.CancellationToken cancellationToken);

        /// <returns>Success</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        System.Threading.Tasks.Task<PagedResultDto_1OfOfUnidadAdministrativaDtoAndContractsAnd_0AndCulture_neutralAndPublicKeyToken_null> UnidadAdministrativaGetAsync(string filter, string tipoUnidadAdministrativaId, string sorting, int? skipCount, int? maxResultCount);

        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>Success</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        System.Threading.Tasks.Task<PagedResultDto_1OfOfUnidadAdministrativaDtoAndContractsAnd_0AndCulture_neutralAndPublicKeyToken_null> UnidadAdministrativaGetAsync(string filter, string tipoUnidadAdministrativaId, string sorting, int? skipCount, int? maxResultCount, System.Threading.CancellationToken cancellationToken);

        /// <returns>Success</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        System.Threading.Tasks.Task<UnidadAdministrativaDto> UnidadAdministrativaGetAsync(System.Guid id);

        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>Success</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        System.Threading.Tasks.Task<UnidadAdministrativaDto> UnidadAdministrativaGetAsync(System.Guid id, System.Threading.CancellationToken cancellationToken);

        /// <returns>Success</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        System.Threading.Tasks.Task<UnidadAdministrativaDto> UnidadAdministrativaPutAsync(System.Guid id, CrearActualizarUnidadAdministrativaDto body);

        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>Success</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        System.Threading.Tasks.Task<UnidadAdministrativaDto> UnidadAdministrativaPutAsync(System.Guid id, CrearActualizarUnidadAdministrativaDto body, System.Threading.CancellationToken cancellationToken);

        /// <returns>Success</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        System.Threading.Tasks.Task UnidadAdministrativaDeleteAsync(System.Guid id);

        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>Success</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        System.Threading.Tasks.Task UnidadAdministrativaDeleteAsync(System.Guid id, System.Threading.CancellationToken cancellationToken);

        /// <returns>Success</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        System.Threading.Tasks.Task<ListResultDto_1OfOfUnidadAdministrativaInfoDtoAndContractsAnd_0AndCulture_neutralAndPublicKeyToken_null> LookupAsync();

        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>Success</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        System.Threading.Tasks.Task<ListResultDto_1OfOfUnidadAdministrativaInfoDtoAndContractsAnd_0AndCulture_neutralAndPublicKeyToken_null> LookupAsync(System.Threading.CancellationToken cancellationToken);

        /// <returns>Success</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        System.Threading.Tasks.Task<ListResultDto_1OfOfUnidadAdministrativaInfoDtoAndContractsAnd_0AndCulture_neutralAndPublicKeyToken_null> ListaIdsAsync(System.Collections.Generic.IEnumerable<System.Guid> ids);

        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>Success</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        System.Threading.Tasks.Task<ListResultDto_1OfOfUnidadAdministrativaInfoDtoAndContractsAnd_0AndCulture_neutralAndPublicKeyToken_null> ListaIdsAsync(System.Collections.Generic.IEnumerable<System.Guid> ids, System.Threading.CancellationToken cancellationToken);

        /// <returns>Success</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        System.Threading.Tasks.Task<ListResultDto_1OfOfUnidadAdministrativaInfoDtoAndContractsAnd_0AndCulture_neutralAndPublicKeyToken_null> PaisAsync(string codigoPais);

        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>Success</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        System.Threading.Tasks.Task<ListResultDto_1OfOfUnidadAdministrativaInfoDtoAndContractsAnd_0AndCulture_neutralAndPublicKeyToken_null> PaisAsync(string codigoPais, System.Threading.CancellationToken cancellationToken);

        /// <returns>Success</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        System.Threading.Tasks.Task<ListResultDto_1OfOfUnidadAdministrativaInfoDtoAndContractsAnd_0AndCulture_neutralAndPublicKeyToken_null> JurisdiccionAsync(string ciudad);

        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>Success</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        System.Threading.Tasks.Task<ListResultDto_1OfOfUnidadAdministrativaInfoDtoAndContractsAnd_0AndCulture_neutralAndPublicKeyToken_null> JurisdiccionAsync(string ciudad, System.Threading.CancellationToken cancellationToken);

        /// <returns>Success</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        System.Threading.Tasks.Task<ListResultDto_1OfOfServicioDtoAndContractsAnd_0AndCulture_neutralAndPublicKeyToken_null> TiposervicioAsync(System.Guid administrativeUnitId, string tipoServicioId);

        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>Success</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        System.Threading.Tasks.Task<ListResultDto_1OfOfServicioDtoAndContractsAnd_0AndCulture_neutralAndPublicKeyToken_null> TiposervicioAsync(System.Guid administrativeUnitId, string tipoServicioId, System.Threading.CancellationToken cancellationToken);

        /// <returns>Success</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        System.Threading.Tasks.Task StateAsync(System.Guid unidadAdministrativaId, bool isActive);

        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>Success</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        System.Threading.Tasks.Task StateAsync(System.Guid unidadAdministrativaId, bool isActive, System.Threading.CancellationToken cancellationToken);

        /// <returns>Success</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        System.Threading.Tasks.Task FuncionarioPostAsync(System.Guid unidadAdministrativaId, AgregarFuncionarioDto body);

        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>Success</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        System.Threading.Tasks.Task FuncionarioPostAsync(System.Guid unidadAdministrativaId, AgregarFuncionarioDto body, System.Threading.CancellationToken cancellationToken);

        /// <returns>Success</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        System.Threading.Tasks.Task<PagedResultDto_1OfOfUnidadAdministrativaFuncionalDtoAndContractsAnd_0AndCulture_neutralAndPublicKeyToken_null> FuncionarioGetAsync(System.Guid unidadAdministrativaId);

        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>Success</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        System.Threading.Tasks.Task<PagedResultDto_1OfOfUnidadAdministrativaFuncionalDtoAndContractsAnd_0AndCulture_neutralAndPublicKeyToken_null> FuncionarioGetAsync(System.Guid unidadAdministrativaId, System.Threading.CancellationToken cancellationToken);

        /// <returns>Success</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        System.Threading.Tasks.Task FuncionarioDeleteAsync(System.Guid unidadAdministrativaId, System.Guid userId);

        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>Success</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        System.Threading.Tasks.Task FuncionarioDeleteAsync(System.Guid unidadAdministrativaId, System.Guid userId, System.Threading.CancellationToken cancellationToken);

        /// <returns>Success</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        System.Threading.Tasks.Task UnidadAdministrativaPutAsync(System.Guid unidadAdministrativaId, System.Guid userId);

        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>Success</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        System.Threading.Tasks.Task UnidadAdministrativaPutAsync(System.Guid unidadAdministrativaId, System.Guid userId, System.Threading.CancellationToken cancellationToken);

        /// <returns>Success</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        System.Threading.Tasks.Task<PagedResultDto_1OfOfUnidadAdministrativaServicioDtoAndContractsAnd_0AndCulture_neutralAndPublicKeyToken_null> ServicioGetAsync(System.Guid unidadAdministrativaId, bool? activo, string sorting, int? skipCount, int? maxResultCount);

        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>Success</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        System.Threading.Tasks.Task<PagedResultDto_1OfOfUnidadAdministrativaServicioDtoAndContractsAnd_0AndCulture_neutralAndPublicKeyToken_null> ServicioGetAsync(System.Guid unidadAdministrativaId, bool? activo, string sorting, int? skipCount, int? maxResultCount, System.Threading.CancellationToken cancellationToken);

        /// <returns>Success</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        System.Threading.Tasks.Task<UnidadAdministrativaServicioDto> ServicioPostAsync(System.Guid unidadAdministrativaId, CrearUnidadAdministrativaServicioDto body);

        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>Success</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        System.Threading.Tasks.Task<UnidadAdministrativaServicioDto> ServicioPostAsync(System.Guid unidadAdministrativaId, CrearUnidadAdministrativaServicioDto body, System.Threading.CancellationToken cancellationToken);

        /// <returns>Success</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        System.Threading.Tasks.Task<UnidadAdministrativaServicioDto> ServicioGetAsync(System.Guid unidadAdministrativaId, System.Guid servicioId);

        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>Success</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        System.Threading.Tasks.Task<UnidadAdministrativaServicioDto> ServicioGetAsync(System.Guid unidadAdministrativaId, System.Guid servicioId, System.Threading.CancellationToken cancellationToken);

        /// <returns>Success</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        System.Threading.Tasks.Task<UnidadAdministrativaServicioDto> ServicioPutAsync(System.Guid unidadAdministrativaId, System.Guid servicioId, ActualizarUnidadAdministrativaServicioDto body);

        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>Success</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        System.Threading.Tasks.Task<UnidadAdministrativaServicioDto> ServicioPutAsync(System.Guid unidadAdministrativaId, System.Guid servicioId, ActualizarUnidadAdministrativaServicioDto body, System.Threading.CancellationToken cancellationToken);

        /// <returns>Success</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        System.Threading.Tasks.Task ServicioDeleteAsync(System.Guid unidadAdministrativaId, System.Guid servicioId);

        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>Success</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        System.Threading.Tasks.Task ServicioDeleteAsync(System.Guid unidadAdministrativaId, System.Guid servicioId, System.Threading.CancellationToken cancellationToken);

        /// <returns>Success</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        System.Threading.Tasks.Task<ListResultDto_1OfOfServicioDtoAndContractsAnd_0AndCulture_neutralAndPublicKeyToken_null> ServicioTodoAsync(System.Guid unidadAdministrativaId);

        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>Success</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        System.Threading.Tasks.Task<ListResultDto_1OfOfServicioDtoAndContractsAnd_0AndCulture_neutralAndPublicKeyToken_null> ServicioTodoAsync(System.Guid unidadAdministrativaId, System.Threading.CancellationToken cancellationToken);

        /// <returns>Success</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        System.Threading.Tasks.Task<ListResultDto_1OfOfServicioDtoAndContractsAnd_0AndCulture_neutralAndPublicKeyToken_null> RouteAsync(System.Guid unidadAdministrativaId);

        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>Success</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        System.Threading.Tasks.Task<ListResultDto_1OfOfServicioDtoAndContractsAnd_0AndCulture_neutralAndPublicKeyToken_null> RouteAsync(System.Guid unidadAdministrativaId, System.Threading.CancellationToken cancellationToken);

        /// <returns>Success</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        System.Threading.Tasks.Task<PagedResultDto_1OfOfSignatarioDtoAndContractsAnd_0AndCulture_neutralAndPublicKeyToken_null> SignatarioGetAsync(System.Guid unidadAdministrativaId);

        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>Success</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        System.Threading.Tasks.Task<PagedResultDto_1OfOfSignatarioDtoAndContractsAnd_0AndCulture_neutralAndPublicKeyToken_null> SignatarioGetAsync(System.Guid unidadAdministrativaId, System.Threading.CancellationToken cancellationToken);

        /// <returns>Success</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        System.Threading.Tasks.Task SignatarioPostAsync(System.Guid unidadAdministrativaId, CrearSignatarioDto body);

        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>Success</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        System.Threading.Tasks.Task SignatarioPostAsync(System.Guid unidadAdministrativaId, CrearSignatarioDto body, System.Threading.CancellationToken cancellationToken);

        /// <returns>Success</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        System.Threading.Tasks.Task<UnidadAdministrativaInfoDto> UnidadAdministrativaFuncionalAsync(System.Guid? usuarioId);

        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>Success</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        System.Threading.Tasks.Task<UnidadAdministrativaInfoDto> UnidadAdministrativaFuncionalAsync(System.Guid? usuarioId, System.Threading.CancellationToken cancellationToken);

        /// <returns>Success</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        System.Threading.Tasks.Task<PagedResultDto_1OfOfUnidadAdministrativaTipoDtoAndContractsAnd_0AndCulture_neutralAndPublicKeyToken_null> UnidadAdministrativaTipoGetAsync(int? skipCount, int? maxResultCount, string sorting);

        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>Success</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        System.Threading.Tasks.Task<PagedResultDto_1OfOfUnidadAdministrativaTipoDtoAndContractsAnd_0AndCulture_neutralAndPublicKeyToken_null> UnidadAdministrativaTipoGetAsync(int? skipCount, int? maxResultCount, string sorting, System.Threading.CancellationToken cancellationToken);

        /// <returns>Success</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        System.Threading.Tasks.Task<UnidadAdministrativaTipoDto> UnidadAdministrativaTipoPostAsync(UnidadAdministrativaTipoDto body);

        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>Success</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        System.Threading.Tasks.Task<UnidadAdministrativaTipoDto> UnidadAdministrativaTipoPostAsync(UnidadAdministrativaTipoDto body, System.Threading.CancellationToken cancellationToken);

        /// <returns>Success</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        System.Threading.Tasks.Task<UnidadAdministrativaTipoDto> UnidadAdministrativaTipoGetAsync(string id);

        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>Success</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        System.Threading.Tasks.Task<UnidadAdministrativaTipoDto> UnidadAdministrativaTipoGetAsync(string id, System.Threading.CancellationToken cancellationToken);

        /// <returns>Success</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        System.Threading.Tasks.Task<UnidadAdministrativaTipoDto> UnidadAdministrativaTipoPutAsync(string id, UnidadAdministrativaTipoDto body);

        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>Success</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        System.Threading.Tasks.Task<UnidadAdministrativaTipoDto> UnidadAdministrativaTipoPutAsync(string id, UnidadAdministrativaTipoDto body, System.Threading.CancellationToken cancellationToken);

        /// <returns>Success</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        System.Threading.Tasks.Task UnidadAdministrativaTipoDeleteAsync(string id);

        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>Success</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        System.Threading.Tasks.Task UnidadAdministrativaTipoDeleteAsync(string id, System.Threading.CancellationToken cancellationToken);

        /// <returns>Success</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        System.Threading.Tasks.Task<PagedResultDto_1OfOfVentanillaDtoAndContractsAnd_0AndCulture_neutralAndPublicKeyToken_null> VentanillaGetAsync(string filter, string sorting, int? skipCount, int? maxResultCount);

        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>Success</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        System.Threading.Tasks.Task<PagedResultDto_1OfOfVentanillaDtoAndContractsAnd_0AndCulture_neutralAndPublicKeyToken_null> VentanillaGetAsync(string filter, string sorting, int? skipCount, int? maxResultCount, System.Threading.CancellationToken cancellationToken);

        /// <returns>Success</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        System.Threading.Tasks.Task<VentanillaDto> VentanillaPostAsync(CrearActualizarVentanillaDto body);

        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>Success</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        System.Threading.Tasks.Task<VentanillaDto> VentanillaPostAsync(CrearActualizarVentanillaDto body, System.Threading.CancellationToken cancellationToken);

        /// <returns>Success</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        System.Threading.Tasks.Task<VentanillaDto> VentanillaGetAsync(System.Guid id);

        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>Success</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        System.Threading.Tasks.Task<VentanillaDto> VentanillaGetAsync(System.Guid id, System.Threading.CancellationToken cancellationToken);

        /// <returns>Success</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        System.Threading.Tasks.Task<VentanillaDto> VentanillaPutAsync(System.Guid id, CrearActualizarVentanillaDto body);

        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>Success</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        System.Threading.Tasks.Task<VentanillaDto> VentanillaPutAsync(System.Guid id, CrearActualizarVentanillaDto body, System.Threading.CancellationToken cancellationToken);

        /// <returns>Success</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        System.Threading.Tasks.Task VentanillaDeleteAsync(System.Guid id);

        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>Success</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        System.Threading.Tasks.Task VentanillaDeleteAsync(System.Guid id, System.Threading.CancellationToken cancellationToken);

    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "13.15.10.0 (NJsonSchema v10.6.10.0 (Newtonsoft.Json v12.0.0.0))")]
    public partial class PagedResultDto_1OfOfArancelDtoAndContractsAnd_0AndCulture_neutralAndPublicKeyToken_null
    {

        [System.Text.Json.Serialization.JsonPropertyName("items")]
        public System.Collections.Generic.ICollection<ArancelDto> Items { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("totalCount")]
        public long TotalCount { get; set; }

    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "13.15.10.0 (NJsonSchema v10.6.10.0 (Newtonsoft.Json v12.0.0.0))")]
    public partial class ArancelDto
    {

        [System.Text.Json.Serialization.JsonPropertyName("id")]
        public System.Guid Id { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("descripcion")]
        [System.ComponentModel.DataAnnotations.Required(AllowEmptyStrings = true)]
        [System.ComponentModel.DataAnnotations.StringLength(256)]
        public string Descripcion { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("monedaId")]
        [System.ComponentModel.DataAnnotations.Required(AllowEmptyStrings = true)]
        public string MonedaId { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("moneda")]
        public string Moneda { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("activo")]
        public bool Activo { get; set; }

    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "13.15.10.0 (NJsonSchema v10.6.10.0 (Newtonsoft.Json v12.0.0.0))")]
    public partial class CrearActualizarArancelDto
    {

        [System.Text.Json.Serialization.JsonPropertyName("descripcion")]
        [System.ComponentModel.DataAnnotations.Required(AllowEmptyStrings = true)]
        [System.ComponentModel.DataAnnotations.StringLength(256)]
        public string Descripcion { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("monedaId")]
        [System.ComponentModel.DataAnnotations.Required(AllowEmptyStrings = true)]
        public string MonedaId { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("activo")]
        public bool Activo { get; set; }

    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "13.15.10.0 (NJsonSchema v10.6.10.0 (Newtonsoft.Json v12.0.0.0))")]
    public partial class PagedResultDto_1OfOfBancoDtoAndContractsAnd_0AndCulture_neutralAndPublicKeyToken_null
    {

        [System.Text.Json.Serialization.JsonPropertyName("items")]
        public System.Collections.Generic.ICollection<BancoDto> Items { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("totalCount")]
        public long TotalCount { get; set; }

    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "13.15.10.0 (NJsonSchema v10.6.10.0 (Newtonsoft.Json v12.0.0.0))")]
    public partial class BancoDto
    {

        [System.Text.Json.Serialization.JsonPropertyName("id")]
        [System.ComponentModel.DataAnnotations.Required(AllowEmptyStrings = true)]
        [System.ComponentModel.DataAnnotations.StringLength(4)]
        [System.ComponentModel.DataAnnotations.RegularExpression(@"^\w+$")]
        public string Id { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("nombre")]
        [System.ComponentModel.DataAnnotations.Required(AllowEmptyStrings = true)]
        [System.ComponentModel.DataAnnotations.StringLength(80)]
        public string Nombre { get; set; }

    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "13.15.10.0 (NJsonSchema v10.6.10.0 (Newtonsoft.Json v12.0.0.0))")]
    public partial class PagedResultDto_1OfOfConvenioDtoAndContractsAnd_0AndCulture_neutralAndPublicKeyToken_null
    {

        [System.Text.Json.Serialization.JsonPropertyName("items")]
        public System.Collections.Generic.ICollection<ConvenioDto> Items { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("totalCount")]
        public long TotalCount { get; set; }

    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "13.15.10.0 (NJsonSchema v10.6.10.0 (Newtonsoft.Json v12.0.0.0))")]
    public partial class ConvenioDto
    {

        [System.Text.Json.Serialization.JsonPropertyName("id")]
        public System.Guid Id { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("descripcion")]
        [System.ComponentModel.DataAnnotations.Required(AllowEmptyStrings = true)]
        [System.ComponentModel.DataAnnotations.StringLength(256)]
        public string Descripcion { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("fechaCreacion")]
        [System.ComponentModel.DataAnnotations.Required(AllowEmptyStrings = true)]
        public System.DateTimeOffset FechaCreacion { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("fechaExpiracion")]
        public System.DateTimeOffset? FechaExpiracion { get; set; }

    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "13.15.10.0 (NJsonSchema v10.6.10.0 (Newtonsoft.Json v12.0.0.0))")]
    public partial class CrearActualizarConvenioDto
    {

        [System.Text.Json.Serialization.JsonPropertyName("descripcion")]
        [System.ComponentModel.DataAnnotations.Required(AllowEmptyStrings = true)]
        [System.ComponentModel.DataAnnotations.StringLength(256)]
        public string Descripcion { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("fechaCreacion")]
        [System.ComponentModel.DataAnnotations.Required(AllowEmptyStrings = true)]
        public System.DateTimeOffset FechaCreacion { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("fechaExpiracion")]
        public System.DateTimeOffset? FechaExpiracion { get; set; }

    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "13.15.10.0 (NJsonSchema v10.6.10.0 (Newtonsoft.Json v12.0.0.0))")]
    public partial class PagedResultDto_1OfOfEntidadAuspicianteDtoAndContractsAnd_0AndCulture_neutralAndPublicKeyToken_null
    {

        [System.Text.Json.Serialization.JsonPropertyName("items")]
        public System.Collections.Generic.ICollection<EntidadAuspicianteDto> Items { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("totalCount")]
        public long TotalCount { get; set; }

    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "13.15.10.0 (NJsonSchema v10.6.10.0 (Newtonsoft.Json v12.0.0.0))")]
    public partial class EntidadAuspicianteDto
    {

        [System.Text.Json.Serialization.JsonPropertyName("id")]
        [System.ComponentModel.DataAnnotations.Required(AllowEmptyStrings = true)]
        [System.ComponentModel.DataAnnotations.StringLength(8)]
        [System.ComponentModel.DataAnnotations.RegularExpression(@"^\w+$")]
        public string Id { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("nombre")]
        [System.ComponentModel.DataAnnotations.Required(AllowEmptyStrings = true)]
        [System.ComponentModel.DataAnnotations.StringLength(80)]
        public string Nombre { get; set; }

    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "13.15.10.0 (NJsonSchema v10.6.10.0 (Newtonsoft.Json v12.0.0.0))")]
    public partial class PagedResultDto_1OfOfJerarquiaArancelariaDtoAndContractsAnd_0AndCulture_neutralAndPublicKeyToken_null
    {

        [System.Text.Json.Serialization.JsonPropertyName("items")]
        public System.Collections.Generic.ICollection<JerarquiaArancelariaDto> Items { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("totalCount")]
        public long TotalCount { get; set; }

    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "13.15.10.0 (NJsonSchema v10.6.10.0 (Newtonsoft.Json v12.0.0.0))")]
    public partial class JerarquiaArancelariaDto
    {

        [System.Text.Json.Serialization.JsonPropertyName("id")]
        public System.Guid Id { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("arancelId")]
        [System.ComponentModel.DataAnnotations.Required(AllowEmptyStrings = true)]
        public System.Guid ArancelId { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("tipoArancelId")]
        [System.ComponentModel.DataAnnotations.Required(AllowEmptyStrings = true)]
        public string TipoArancelId { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("tipoArancel")]
        public string TipoArancel { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("descripcion")]
        [System.ComponentModel.DataAnnotations.Required(AllowEmptyStrings = true)]
        [System.ComponentModel.DataAnnotations.StringLength(256)]
        public string Descripcion { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("orden")]
        public int Orden { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("numeroJerarquia")]
        public int NumeroJerarquia { get; set; }

    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "13.15.10.0 (NJsonSchema v10.6.10.0 (Newtonsoft.Json v12.0.0.0))")]
    public partial class CrearActualizarJerarquiaArancelariaDto
    {

        [System.Text.Json.Serialization.JsonPropertyName("arancelId")]
        [System.ComponentModel.DataAnnotations.Required(AllowEmptyStrings = true)]
        public System.Guid ArancelId { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("tipoArancelId")]
        [System.ComponentModel.DataAnnotations.Required(AllowEmptyStrings = true)]
        public string TipoArancelId { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("descripcion")]
        [System.ComponentModel.DataAnnotations.Required(AllowEmptyStrings = true)]
        [System.ComponentModel.DataAnnotations.StringLength(256)]
        public string Descripcion { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("orden")]
        public int Orden { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("numeroJerarquia")]
        public int NumeroJerarquia { get; set; }

    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "13.15.10.0 (NJsonSchema v10.6.10.0 (Newtonsoft.Json v12.0.0.0))")]
    public partial class PagedResultDto_1OfOfLibroDtoAndContractsAnd_0AndCulture_neutralAndPublicKeyToken_null
    {

        [System.Text.Json.Serialization.JsonPropertyName("items")]
        public System.Collections.Generic.ICollection<LibroDto> Items { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("totalCount")]
        public long TotalCount { get; set; }

    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "13.15.10.0 (NJsonSchema v10.6.10.0 (Newtonsoft.Json v12.0.0.0))")]
    public partial class LibroDto
    {

        [System.Text.Json.Serialization.JsonPropertyName("id")]
        [System.ComponentModel.DataAnnotations.Required(AllowEmptyStrings = true)]
        [System.ComponentModel.DataAnnotations.StringLength(4)]
        [System.ComponentModel.DataAnnotations.RegularExpression(@"^\w+$")]
        public string Id { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("nombre")]
        [System.ComponentModel.DataAnnotations.Required(AllowEmptyStrings = true)]
        [System.ComponentModel.DataAnnotations.StringLength(80)]
        public string Nombre { get; set; }

    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "13.15.10.0 (NJsonSchema v10.6.10.0 (Newtonsoft.Json v12.0.0.0))")]
    public partial class PagedResultDto_1OfOfMonedaDtoAndContractsAnd_0AndCulture_neutralAndPublicKeyToken_null
    {

        [System.Text.Json.Serialization.JsonPropertyName("items")]
        public System.Collections.Generic.ICollection<MonedaDto> Items { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("totalCount")]
        public long TotalCount { get; set; }

    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "13.15.10.0 (NJsonSchema v10.6.10.0 (Newtonsoft.Json v12.0.0.0))")]
    public partial class MonedaDto
    {

        [System.Text.Json.Serialization.JsonPropertyName("id")]
        [System.ComponentModel.DataAnnotations.Required(AllowEmptyStrings = true)]
        [System.ComponentModel.DataAnnotations.StringLength(4)]
        [System.ComponentModel.DataAnnotations.RegularExpression(@"^\w+$")]
        public string Id { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("nombre")]
        [System.ComponentModel.DataAnnotations.Required(AllowEmptyStrings = true)]
        [System.ComponentModel.DataAnnotations.StringLength(80)]
        public string Nombre { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("simbolo")]
        public string Simbolo { get; set; }

    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "13.15.10.0 (NJsonSchema v10.6.10.0 (Newtonsoft.Json v12.0.0.0))")]
    public partial class PagedResultDto_1OfOfNivelDtoAndContractsAnd_0AndCulture_neutralAndPublicKeyToken_null
    {

        [System.Text.Json.Serialization.JsonPropertyName("items")]
        public System.Collections.Generic.ICollection<NivelDto> Items { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("totalCount")]
        public long TotalCount { get; set; }

    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "13.15.10.0 (NJsonSchema v10.6.10.0 (Newtonsoft.Json v12.0.0.0))")]
    public partial class PagedResultDto_1OfOfPartidaArancelariaDtoAndContractsAnd_0AndCulture_neutralAndPublicKeyToken_null
    {

        [System.Text.Json.Serialization.JsonPropertyName("items")]
        public System.Collections.Generic.ICollection<PartidaArancelariaDto> Items { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("totalCount")]
        public long TotalCount { get; set; }

    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "13.15.10.0 (NJsonSchema v10.6.10.0 (Newtonsoft.Json v12.0.0.0))")]
    public partial class PagedResultDto_1OfOfPartidaArancelariaServicioInfoDtoAndContractsAnd_0AndCulture_neutralAndPublicKeyToken_null
    {

        [System.Text.Json.Serialization.JsonPropertyName("items")]
        public System.Collections.Generic.ICollection<PartidaArancelariaServicioInfoDto> Items { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("totalCount")]
        public long TotalCount { get; set; }

    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "13.15.10.0 (NJsonSchema v10.6.10.0 (Newtonsoft.Json v12.0.0.0))")]
    public partial class PagedResultDto_1OfOfSecuencialLibroDtoAndContractsAnd_0AndCulture_neutralAndPublicKeyToken_null
    {

        [System.Text.Json.Serialization.JsonPropertyName("items")]
        public System.Collections.Generic.ICollection<SecuencialLibroDto> Items { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("totalCount")]
        public long TotalCount { get; set; }

    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "13.15.10.0 (NJsonSchema v10.6.10.0 (Newtonsoft.Json v12.0.0.0))")]
    public partial class PagedResultDto_1OfOfServicioDtoAndContractsAnd_0AndCulture_neutralAndPublicKeyToken_null
    {

        [System.Text.Json.Serialization.JsonPropertyName("items")]
        public System.Collections.Generic.ICollection<ServicioDto> Items { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("totalCount")]
        public long TotalCount { get; set; }

    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "13.15.10.0 (NJsonSchema v10.6.10.0 (Newtonsoft.Json v12.0.0.0))")]
    public partial class PagedResultDto_1OfOfTipoArancelDtoAndContractsAnd_0AndCulture_neutralAndPublicKeyToken_null
    {

        [System.Text.Json.Serialization.JsonPropertyName("items")]
        public System.Collections.Generic.ICollection<TipoArancelDto> Items { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("totalCount")]
        public long TotalCount { get; set; }

    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "13.15.10.0 (NJsonSchema v10.6.10.0 (Newtonsoft.Json v12.0.0.0))")]
    public partial class PagedResultDto_1OfOfTipoExoneracionDtoAndContractsAnd_0AndCulture_neutralAndPublicKeyToken_null
    {

        [System.Text.Json.Serialization.JsonPropertyName("items")]
        public System.Collections.Generic.ICollection<TipoExoneracionDto> Items { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("totalCount")]
        public long TotalCount { get; set; }

    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "13.15.10.0 (NJsonSchema v10.6.10.0 (Newtonsoft.Json v12.0.0.0))")]
    public partial class PagedResultDto_1OfOfTipoPagoDtoAndContractsAnd_0AndCulture_neutralAndPublicKeyToken_null
    {

        [System.Text.Json.Serialization.JsonPropertyName("items")]
        public System.Collections.Generic.ICollection<TipoPagoDto> Items { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("totalCount")]
        public long TotalCount { get; set; }

    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "13.15.10.0 (NJsonSchema v10.6.10.0 (Newtonsoft.Json v12.0.0.0))")]
    public partial class PagedResultDto_1OfOfTipoServicioDtoAndContractsAnd_0AndCulture_neutralAndPublicKeyToken_null
    {

        [System.Text.Json.Serialization.JsonPropertyName("items")]
        public System.Collections.Generic.ICollection<TipoServicioDto> Items { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("totalCount")]
        public long TotalCount { get; set; }

    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "13.15.10.0 (NJsonSchema v10.6.10.0 (Newtonsoft.Json v12.0.0.0))")]
    public partial class PagedResultDto_1OfOfSignatarioDtoAndContractsAnd_0AndCulture_neutralAndPublicKeyToken_null
    {

        [System.Text.Json.Serialization.JsonPropertyName("items")]
        public System.Collections.Generic.ICollection<SignatarioDto> Items { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("totalCount")]
        public long TotalCount { get; set; }

    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "13.15.10.0 (NJsonSchema v10.6.10.0 (Newtonsoft.Json v12.0.0.0))")]
    public partial class PagedResultDto_1OfOfUnidadAdministrativaDtoAndContractsAnd_0AndCulture_neutralAndPublicKeyToken_null
    {

        [System.Text.Json.Serialization.JsonPropertyName("items")]
        public System.Collections.Generic.ICollection<UnidadAdministrativaDto> Items { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("totalCount")]
        public long TotalCount { get; set; }

    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "13.15.10.0 (NJsonSchema v10.6.10.0 (Newtonsoft.Json v12.0.0.0))")]
    public partial class PagedResultDto_1OfOfUnidadAdministrativaFuncionalDtoAndContractsAnd_0AndCulture_neutralAndPublicKeyToken_null
    {

        [System.Text.Json.Serialization.JsonPropertyName("items")]
        public System.Collections.Generic.ICollection<UnidadAdministrativaFuncionalDto> Items { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("totalCount")]
        public long TotalCount { get; set; }

    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "13.15.10.0 (NJsonSchema v10.6.10.0 (Newtonsoft.Json v12.0.0.0))")]
    public partial class PagedResultDto_1OfOfUnidadAdministrativaServicioDtoAndContractsAnd_0AndCulture_neutralAndPublicKeyToken_null
    {

        [System.Text.Json.Serialization.JsonPropertyName("items")]
        public System.Collections.Generic.ICollection<UnidadAdministrativaServicioDto> Items { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("totalCount")]
        public long TotalCount { get; set; }

    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "13.15.10.0 (NJsonSchema v10.6.10.0 (Newtonsoft.Json v12.0.0.0))")]
    public partial class PagedResultDto_1OfOfUnidadAdministrativaTipoDtoAndContractsAnd_0AndCulture_neutralAndPublicKeyToken_null
    {

        [System.Text.Json.Serialization.JsonPropertyName("items")]
        public System.Collections.Generic.ICollection<UnidadAdministrativaTipoDto> Items { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("totalCount")]
        public long TotalCount { get; set; }

    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "13.15.10.0 (NJsonSchema v10.6.10.0 (Newtonsoft.Json v12.0.0.0))")]
    public partial class PagedResultDto_1OfOfVentanillaDtoAndContractsAnd_0AndCulture_neutralAndPublicKeyToken_null
    {

        [System.Text.Json.Serialization.JsonPropertyName("items")]
        public System.Collections.Generic.ICollection<VentanillaDto> Items { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("totalCount")]
        public long TotalCount { get; set; }

    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "13.15.10.0 (NJsonSchema v10.6.10.0 (Newtonsoft.Json v12.0.0.0))")]
    public partial class ApplicationAuthConfigurationDto
    {

        [System.Text.Json.Serialization.JsonPropertyName("policies")]
        public System.Collections.Generic.IDictionary<string, bool> Policies { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("grantedPolicies")]
        public System.Collections.Generic.IDictionary<string, bool> GrantedPolicies { get; set; }

    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "13.15.10.0 (NJsonSchema v10.6.10.0 (Newtonsoft.Json v12.0.0.0))")]
    public partial class ApplicationConfigurationDto
    {

        [System.Text.Json.Serialization.JsonPropertyName("localization")]
        public ApplicationLocalizationConfigurationDto Localization { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("auth")]
        public ApplicationAuthConfigurationDto Auth { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("setting")]
        public ApplicationSettingConfigurationDto Setting { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("currentUser")]
        public CurrentUserDto CurrentUser { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("features")]
        public ApplicationFeatureConfigurationDto Features { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("multiTenancy")]
        public MultiTenancyInfoDto MultiTenancy { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("currentTenant")]
        public CurrentTenantDto CurrentTenant { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("timing")]
        public TimingDto Timing { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("clock")]
        public ClockDto Clock { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("objectExtensions")]
        public ObjectExtensionsDto ObjectExtensions { get; set; }

    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "13.15.10.0 (NJsonSchema v10.6.10.0 (Newtonsoft.Json v12.0.0.0))")]
    public partial class ApplicationFeatureConfigurationDto
    {

        [System.Text.Json.Serialization.JsonPropertyName("values")]
        public System.Collections.Generic.IDictionary<string, string> Values { get; set; }

    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "13.15.10.0 (NJsonSchema v10.6.10.0 (Newtonsoft.Json v12.0.0.0))")]
    public partial class ApplicationLocalizationConfigurationDto
    {

        [System.Text.Json.Serialization.JsonPropertyName("values")]
        public System.Collections.Generic.IDictionary<string, System.Collections.Generic.IDictionary<string, string>> Values { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("languages")]
        public System.Collections.Generic.ICollection<LanguageInfo> Languages { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("currentCulture")]
        public CurrentCultureDto CurrentCulture { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("defaultResourceName")]
        public string DefaultResourceName { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("languagesMap")]
        public System.Collections.Generic.IDictionary<string, System.Collections.Generic.ICollection<NameValue>> LanguagesMap { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("languageFilesMap")]
        public System.Collections.Generic.IDictionary<string, System.Collections.Generic.ICollection<NameValue>> LanguageFilesMap { get; set; }

    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "13.15.10.0 (NJsonSchema v10.6.10.0 (Newtonsoft.Json v12.0.0.0))")]
    public partial class ApplicationSettingConfigurationDto
    {

        [System.Text.Json.Serialization.JsonPropertyName("values")]
        public System.Collections.Generic.IDictionary<string, string> Values { get; set; }

    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "13.15.10.0 (NJsonSchema v10.6.10.0 (Newtonsoft.Json v12.0.0.0))")]
    public partial class ClockDto
    {

        [System.Text.Json.Serialization.JsonPropertyName("kind")]
        public string Kind { get; set; }

    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "13.15.10.0 (NJsonSchema v10.6.10.0 (Newtonsoft.Json v12.0.0.0))")]
    public partial class CurrentCultureDto
    {

        [System.Text.Json.Serialization.JsonPropertyName("displayName")]
        public string DisplayName { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("englishName")]
        public string EnglishName { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("threeLetterIsoLanguageName")]
        public string ThreeLetterIsoLanguageName { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("twoLetterIsoLanguageName")]
        public string TwoLetterIsoLanguageName { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("isRightToLeft")]
        public bool IsRightToLeft { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("cultureName")]
        public string CultureName { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("name")]
        public string Name { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("nativeName")]
        public string NativeName { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("dateTimeFormat")]
        public DateTimeFormatDto DateTimeFormat { get; set; }

    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "13.15.10.0 (NJsonSchema v10.6.10.0 (Newtonsoft.Json v12.0.0.0))")]
    public partial class CurrentUserDto
    {

        [System.Text.Json.Serialization.JsonPropertyName("isAuthenticated")]
        public bool IsAuthenticated { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("id")]
        public System.Guid? Id { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("tenantId")]
        public System.Guid? TenantId { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("impersonatorUserId")]
        public System.Guid? ImpersonatorUserId { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("impersonatorTenantId")]
        public System.Guid? ImpersonatorTenantId { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("userName")]
        public string UserName { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("name")]
        public string Name { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("surName")]
        public string SurName { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("email")]
        public string Email { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("emailVerified")]
        public bool EmailVerified { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("phoneNumber")]
        public string PhoneNumber { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("phoneNumberVerified")]
        public bool PhoneNumberVerified { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("roles")]
        public System.Collections.Generic.ICollection<string> Roles { get; set; }

    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "13.15.10.0 (NJsonSchema v10.6.10.0 (Newtonsoft.Json v12.0.0.0))")]
    public partial class DateTimeFormatDto
    {

        [System.Text.Json.Serialization.JsonPropertyName("calendarAlgorithmType")]
        public string CalendarAlgorithmType { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("dateTimeFormatLong")]
        public string DateTimeFormatLong { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("shortDatePattern")]
        public string ShortDatePattern { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("fullDateTimePattern")]
        public string FullDateTimePattern { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("dateSeparator")]
        public string DateSeparator { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("shortTimePattern")]
        public string ShortTimePattern { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("longTimePattern")]
        public string LongTimePattern { get; set; }

    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "13.15.10.0 (NJsonSchema v10.6.10.0 (Newtonsoft.Json v12.0.0.0))")]
    public partial class IanaTimeZone
    {

        [System.Text.Json.Serialization.JsonPropertyName("timeZoneName")]
        public string TimeZoneName { get; set; }

    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "13.15.10.0 (NJsonSchema v10.6.10.0 (Newtonsoft.Json v12.0.0.0))")]
    public partial class EntityExtensionDto
    {

        [System.Text.Json.Serialization.JsonPropertyName("properties")]
        public System.Collections.Generic.IDictionary<string, ExtensionPropertyDto> Properties { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("configuration")]
        public System.Collections.Generic.IDictionary<string, object> Configuration { get; set; }

    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "13.15.10.0 (NJsonSchema v10.6.10.0 (Newtonsoft.Json v12.0.0.0))")]
    public partial class ExtensionEnumDto
    {

        [System.Text.Json.Serialization.JsonPropertyName("fields")]
        public System.Collections.Generic.ICollection<ExtensionEnumFieldDto> Fields { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("localizationResource")]
        public string LocalizationResource { get; set; }

    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "13.15.10.0 (NJsonSchema v10.6.10.0 (Newtonsoft.Json v12.0.0.0))")]
    public partial class ExtensionEnumFieldDto
    {

        [System.Text.Json.Serialization.JsonPropertyName("name")]
        public string Name { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("value")]
        public object Value { get; set; }

    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "13.15.10.0 (NJsonSchema v10.6.10.0 (Newtonsoft.Json v12.0.0.0))")]
    public partial class ExtensionPropertyApiCreateDto
    {

        [System.Text.Json.Serialization.JsonPropertyName("isAvailable")]
        public bool IsAvailable { get; set; }

    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "13.15.10.0 (NJsonSchema v10.6.10.0 (Newtonsoft.Json v12.0.0.0))")]
    public partial class ExtensionPropertyApiDto
    {

        [System.Text.Json.Serialization.JsonPropertyName("onGet")]
        public ExtensionPropertyApiGetDto OnGet { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("onCreate")]
        public ExtensionPropertyApiCreateDto OnCreate { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("onUpdate")]
        public ExtensionPropertyApiUpdateDto OnUpdate { get; set; }

    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "13.15.10.0 (NJsonSchema v10.6.10.0 (Newtonsoft.Json v12.0.0.0))")]
    public partial class ExtensionPropertyApiGetDto
    {

        [System.Text.Json.Serialization.JsonPropertyName("isAvailable")]
        public bool IsAvailable { get; set; }

    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "13.15.10.0 (NJsonSchema v10.6.10.0 (Newtonsoft.Json v12.0.0.0))")]
    public partial class ExtensionPropertyApiUpdateDto
    {

        [System.Text.Json.Serialization.JsonPropertyName("isAvailable")]
        public bool IsAvailable { get; set; }

    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "13.15.10.0 (NJsonSchema v10.6.10.0 (Newtonsoft.Json v12.0.0.0))")]
    public partial class ExtensionPropertyAttributeDto
    {

        [System.Text.Json.Serialization.JsonPropertyName("typeSimple")]
        public string TypeSimple { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("config")]
        public System.Collections.Generic.IDictionary<string, object> Config { get; set; }

    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "13.15.10.0 (NJsonSchema v10.6.10.0 (Newtonsoft.Json v12.0.0.0))")]
    public partial class ExtensionPropertyDto
    {

        [System.Text.Json.Serialization.JsonPropertyName("type")]
        public string Type { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("typeSimple")]
        public string TypeSimple { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("displayName")]
        public LocalizableStringDto DisplayName { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("api")]
        public ExtensionPropertyApiDto Api { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("ui")]
        public ExtensionPropertyUiDto Ui { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("attributes")]
        public System.Collections.Generic.ICollection<ExtensionPropertyAttributeDto> Attributes { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("configuration")]
        public System.Collections.Generic.IDictionary<string, object> Configuration { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("defaultValue")]
        public object DefaultValue { get; set; }

    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "13.15.10.0 (NJsonSchema v10.6.10.0 (Newtonsoft.Json v12.0.0.0))")]
    public partial class ExtensionPropertyUiDto
    {

        [System.Text.Json.Serialization.JsonPropertyName("onTable")]
        public ExtensionPropertyUiTableDto OnTable { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("onCreateForm")]
        public ExtensionPropertyUiFormDto OnCreateForm { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("onEditForm")]
        public ExtensionPropertyUiFormDto OnEditForm { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("lookup")]
        public ExtensionPropertyUiLookupDto Lookup { get; set; }

    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "13.15.10.0 (NJsonSchema v10.6.10.0 (Newtonsoft.Json v12.0.0.0))")]
    public partial class ExtensionPropertyUiFormDto
    {

        [System.Text.Json.Serialization.JsonPropertyName("isVisible")]
        public bool IsVisible { get; set; }

    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "13.15.10.0 (NJsonSchema v10.6.10.0 (Newtonsoft.Json v12.0.0.0))")]
    public partial class ExtensionPropertyUiLookupDto
    {

        [System.Text.Json.Serialization.JsonPropertyName("url")]
        public string Url { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("resultListPropertyName")]
        public string ResultListPropertyName { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("displayPropertyName")]
        public string DisplayPropertyName { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("valuePropertyName")]
        public string ValuePropertyName { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("filterParamName")]
        public string FilterParamName { get; set; }

    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "13.15.10.0 (NJsonSchema v10.6.10.0 (Newtonsoft.Json v12.0.0.0))")]
    public partial class ExtensionPropertyUiTableDto
    {

        [System.Text.Json.Serialization.JsonPropertyName("isVisible")]
        public bool IsVisible { get; set; }

    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "13.15.10.0 (NJsonSchema v10.6.10.0 (Newtonsoft.Json v12.0.0.0))")]
    public partial class LocalizableStringDto
    {

        [System.Text.Json.Serialization.JsonPropertyName("name")]
        public string Name { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("resource")]
        public string Resource { get; set; }

    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "13.15.10.0 (NJsonSchema v10.6.10.0 (Newtonsoft.Json v12.0.0.0))")]
    public partial class ModuleExtensionDto
    {

        [System.Text.Json.Serialization.JsonPropertyName("entities")]
        public System.Collections.Generic.IDictionary<string, EntityExtensionDto> Entities { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("configuration")]
        public System.Collections.Generic.IDictionary<string, object> Configuration { get; set; }

    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "13.15.10.0 (NJsonSchema v10.6.10.0 (Newtonsoft.Json v12.0.0.0))")]
    public partial class ObjectExtensionsDto
    {

        [System.Text.Json.Serialization.JsonPropertyName("modules")]
        public System.Collections.Generic.IDictionary<string, ModuleExtensionDto> Modules { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("enums")]
        public System.Collections.Generic.IDictionary<string, ExtensionEnumDto> Enums { get; set; }

    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "13.15.10.0 (NJsonSchema v10.6.10.0 (Newtonsoft.Json v12.0.0.0))")]
    public partial class TimeZone
    {

        [System.Text.Json.Serialization.JsonPropertyName("iana")]
        public IanaTimeZone Iana { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("windows")]
        public WindowsTimeZone Windows { get; set; }

    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "13.15.10.0 (NJsonSchema v10.6.10.0 (Newtonsoft.Json v12.0.0.0))")]
    public partial class TimingDto
    {

        [System.Text.Json.Serialization.JsonPropertyName("timeZone")]
        public TimeZone TimeZone { get; set; }

    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "13.15.10.0 (NJsonSchema v10.6.10.0 (Newtonsoft.Json v12.0.0.0))")]
    public partial class WindowsTimeZone
    {

        [System.Text.Json.Serialization.JsonPropertyName("timeZoneId")]
        public string TimeZoneId { get; set; }

    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "13.15.10.0 (NJsonSchema v10.6.10.0 (Newtonsoft.Json v12.0.0.0))")]
    public partial class CurrentTenantDto
    {

        [System.Text.Json.Serialization.JsonPropertyName("id")]
        public System.Guid? Id { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("name")]
        public string Name { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("isAvailable")]
        public bool IsAvailable { get; set; }

    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "13.15.10.0 (NJsonSchema v10.6.10.0 (Newtonsoft.Json v12.0.0.0))")]
    public partial class FindTenantResultDto
    {

        [System.Text.Json.Serialization.JsonPropertyName("success")]
        public bool Success { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("tenantId")]
        public System.Guid? TenantId { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("name")]
        public string Name { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("isActive")]
        public bool IsActive { get; set; }

    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "13.15.10.0 (NJsonSchema v10.6.10.0 (Newtonsoft.Json v12.0.0.0))")]
    public partial class MultiTenancyInfoDto
    {

        [System.Text.Json.Serialization.JsonPropertyName("isEnabled")]
        public bool IsEnabled { get; set; }

    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "13.15.10.0 (NJsonSchema v10.6.10.0 (Newtonsoft.Json v12.0.0.0))")]
    public partial class ActionApiDescriptionModel
    {

        [System.Text.Json.Serialization.JsonPropertyName("uniqueName")]
        public string UniqueName { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("name")]
        public string Name { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("httpMethod")]
        public string HttpMethod { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("url")]
        public string Url { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("supportedVersions")]
        public System.Collections.Generic.ICollection<string> SupportedVersions { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("parametersOnMethod")]
        public System.Collections.Generic.ICollection<MethodParameterApiDescriptionModel> ParametersOnMethod { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("parameters")]
        public System.Collections.Generic.ICollection<ParameterApiDescriptionModel> Parameters { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("returnValue")]
        public ReturnValueApiDescriptionModel ReturnValue { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("allowAnonymous")]
        public bool? AllowAnonymous { get; set; }

    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "13.15.10.0 (NJsonSchema v10.6.10.0 (Newtonsoft.Json v12.0.0.0))")]
    public partial class ApplicationApiDescriptionModel
    {

        [System.Text.Json.Serialization.JsonPropertyName("modules")]
        public System.Collections.Generic.IDictionary<string, ModuleApiDescriptionModel> Modules { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("types")]
        public System.Collections.Generic.IDictionary<string, TypeApiDescriptionModel> Types { get; set; }

    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "13.15.10.0 (NJsonSchema v10.6.10.0 (Newtonsoft.Json v12.0.0.0))")]
    public partial class ControllerApiDescriptionModel
    {

        [System.Text.Json.Serialization.JsonPropertyName("controllerName")]
        public string ControllerName { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("type")]
        public string Type { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("interfaces")]
        public System.Collections.Generic.ICollection<ControllerInterfaceApiDescriptionModel> Interfaces { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("actions")]
        public System.Collections.Generic.IDictionary<string, ActionApiDescriptionModel> Actions { get; set; }

    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "13.15.10.0 (NJsonSchema v10.6.10.0 (Newtonsoft.Json v12.0.0.0))")]
    public partial class ControllerInterfaceApiDescriptionModel
    {

        [System.Text.Json.Serialization.JsonPropertyName("type")]
        public string Type { get; set; }

    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "13.15.10.0 (NJsonSchema v10.6.10.0 (Newtonsoft.Json v12.0.0.0))")]
    public partial class MethodParameterApiDescriptionModel
    {

        [System.Text.Json.Serialization.JsonPropertyName("name")]
        public string Name { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("typeAsString")]
        public string TypeAsString { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("type")]
        public string Type { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("typeSimple")]
        public string TypeSimple { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("isOptional")]
        public bool IsOptional { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("defaultValue")]
        public object DefaultValue { get; set; }

    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "13.15.10.0 (NJsonSchema v10.6.10.0 (Newtonsoft.Json v12.0.0.0))")]
    public partial class ModuleApiDescriptionModel
    {

        [System.Text.Json.Serialization.JsonPropertyName("rootPath")]
        public string RootPath { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("remoteServiceName")]
        public string RemoteServiceName { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("controllers")]
        public System.Collections.Generic.IDictionary<string, ControllerApiDescriptionModel> Controllers { get; set; }

    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "13.15.10.0 (NJsonSchema v10.6.10.0 (Newtonsoft.Json v12.0.0.0))")]
    public partial class ParameterApiDescriptionModel
    {

        [System.Text.Json.Serialization.JsonPropertyName("nameOnMethod")]
        public string NameOnMethod { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("name")]
        public string Name { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("jsonName")]
        public string JsonName { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("type")]
        public string Type { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("typeSimple")]
        public string TypeSimple { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("isOptional")]
        public bool IsOptional { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("defaultValue")]
        public object DefaultValue { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("constraintTypes")]
        public System.Collections.Generic.ICollection<string> ConstraintTypes { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("bindingSourceId")]
        public string BindingSourceId { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("descriptorName")]
        public string DescriptorName { get; set; }

    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "13.15.10.0 (NJsonSchema v10.6.10.0 (Newtonsoft.Json v12.0.0.0))")]
    public partial class PropertyApiDescriptionModel
    {

        [System.Text.Json.Serialization.JsonPropertyName("name")]
        public string Name { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("jsonName")]
        public string JsonName { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("type")]
        public string Type { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("typeSimple")]
        public string TypeSimple { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("isRequired")]
        public bool IsRequired { get; set; }

    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "13.15.10.0 (NJsonSchema v10.6.10.0 (Newtonsoft.Json v12.0.0.0))")]
    public partial class ReturnValueApiDescriptionModel
    {

        [System.Text.Json.Serialization.JsonPropertyName("type")]
        public string Type { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("typeSimple")]
        public string TypeSimple { get; set; }

    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "13.15.10.0 (NJsonSchema v10.6.10.0 (Newtonsoft.Json v12.0.0.0))")]
    public partial class TypeApiDescriptionModel
    {

        [System.Text.Json.Serialization.JsonPropertyName("baseType")]
        public string BaseType { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("isEnum")]
        public bool IsEnum { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("enumNames")]
        public System.Collections.Generic.ICollection<string> EnumNames { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("enumValues")]
        public System.Collections.Generic.ICollection<object> EnumValues { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("genericArguments")]
        public System.Collections.Generic.ICollection<string> GenericArguments { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("properties")]
        public System.Collections.Generic.ICollection<PropertyApiDescriptionModel> Properties { get; set; }

    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "13.15.10.0 (NJsonSchema v10.6.10.0 (Newtonsoft.Json v12.0.0.0))")]
    public partial class LanguageInfo
    {

        [System.Text.Json.Serialization.JsonPropertyName("cultureName")]
        public string CultureName { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("uiCultureName")]
        public string UiCultureName { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("displayName")]
        public string DisplayName { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("flagIcon")]
        public string FlagIcon { get; set; }

    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "13.15.10.0 (NJsonSchema v10.6.10.0 (Newtonsoft.Json v12.0.0.0))")]
    public partial class NameValue
    {

        [System.Text.Json.Serialization.JsonPropertyName("name")]
        public string Name { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("value")]
        public string Value { get; set; }

    }


    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "13.15.10.0 (NJsonSchema v10.6.10.0 (Newtonsoft.Json v12.0.0.0))")]
    public partial class PartidaArancelariaServicioInfoDto
    {

        [System.Text.Json.Serialization.JsonPropertyName("servicioId")]
        public System.Guid ServicioId { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("servicio")]
        public string Servicio { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("tipoServicio")]
        public string TipoServicio { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("atencionPresencial")]
        public bool AtencionPresencial { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("atencionSemiPresencial")]
        public bool AtencionSemiPresencial { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("atencionVirtual")]
        public bool AtencionVirtual { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("activo")]
        public bool Activo { get; set; }

    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "13.15.10.0 (NJsonSchema v10.6.10.0 (Newtonsoft.Json v12.0.0.0))")]
    public partial class SecuencialLibroDto
    {

        [System.Text.Json.Serialization.JsonPropertyName("id")]
        public System.Guid Id { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("servicioId")]
        public System.Guid ServicioId { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("unidadAdministrativaId")]
        public System.Guid UnidadAdministrativaId { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("libroId")]
        public string LibroId { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("libro")]
        public string Libro { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("numeroPaginaPorVolumen")]
        public int NumeroPaginaPorVolumen { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("volumenActual")]
        public int VolumenActual { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("siguientePagina")]
        public int SiguientePagina { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("anio")]
        public int Anio { get; set; }

    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "13.15.10.0 (NJsonSchema v10.6.10.0 (Newtonsoft.Json v12.0.0.0))")]
    public partial class ServicioDto
    {

        [System.Text.Json.Serialization.JsonPropertyName("id")]
        public System.Guid Id { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("nombre")]
        public string Nombre { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("tipoServicioId")]
        public string TipoServicioId { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("tipoServicio")]
        public string TipoServicio { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("atencionPresencial")]
        public bool AtencionPresencial { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("atencionSemiPresencial")]
        public bool AtencionSemiPresencial { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("atencionVirtual")]
        public bool AtencionVirtual { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("activo")]
        public bool Activo { get; set; }

    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "13.15.10.0 (NJsonSchema v10.6.10.0 (Newtonsoft.Json v12.0.0.0))")]
    public partial class TipoArancelDto
    {

        [System.Text.Json.Serialization.JsonPropertyName("id")]
        [System.ComponentModel.DataAnnotations.Required(AllowEmptyStrings = true)]
        [System.ComponentModel.DataAnnotations.StringLength(8)]
        [System.ComponentModel.DataAnnotations.RegularExpression(@"^\w+$")]
        public string Id { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("nombre")]
        [System.ComponentModel.DataAnnotations.Required(AllowEmptyStrings = true)]
        [System.ComponentModel.DataAnnotations.StringLength(80)]
        public string Nombre { get; set; }

    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "13.15.10.0 (NJsonSchema v10.6.10.0 (Newtonsoft.Json v12.0.0.0))")]
    public partial class PartidaArancelariaDto
    {

        [System.Text.Json.Serialization.JsonPropertyName("id")]
        public System.Guid Id { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("descripcion")]
        [System.ComponentModel.DataAnnotations.Required(AllowEmptyStrings = true)]
        [System.ComponentModel.DataAnnotations.StringLength(256)]
        public string Descripcion { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("numeroPartida")]
        [System.ComponentModel.DataAnnotations.Required(AllowEmptyStrings = true)]
        [System.ComponentModel.DataAnnotations.StringLength(4)]
        public string NumeroPartida { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("valor")]
        public double Valor { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("jerarquiaArancelariaId")]
        [System.ComponentModel.DataAnnotations.Required(AllowEmptyStrings = true)]
        public System.Guid JerarquiaArancelariaId { get; set; }

    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "13.15.10.0 (NJsonSchema v10.6.10.0 (Newtonsoft.Json v12.0.0.0))")]
    public partial class PartidaArancelariaLookupDto
    {

        [System.Text.Json.Serialization.JsonPropertyName("id")]
        public System.Guid Id { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("descripcion")]
        public string Descripcion { get; set; }

    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "13.15.10.0 (NJsonSchema v10.6.10.0 (Newtonsoft.Json v12.0.0.0))")]
    public partial class PartidaArancelariaServicioDto
    {

        [System.Text.Json.Serialization.JsonPropertyName("partidaArancelariaId")]
        public System.Guid PartidaArancelariaId { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("servicioId")]
        public System.Guid ServicioId { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("servicio")]
        public string Servicio { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("partidaArancelaria")]
        public string PartidaArancelaria { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("numeroPartida")]
        public string NumeroPartida { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("valor")]
        public double Valor { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("jerarquiaArancelariaId")]
        public System.Guid JerarquiaArancelariaId { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("jerarquiaArancelaria")]
        public string JerarquiaArancelaria { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("arancelId")]
        public System.Guid ArancelId { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("arancel")]
        public string Arancel { get; set; }

    }


    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "13.15.10.0 (NJsonSchema v10.6.10.0 (Newtonsoft.Json v12.0.0.0))")]
    public partial class TipoArancelLookupDto
    {

        [System.Text.Json.Serialization.JsonPropertyName("id")]
        public string Id { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("nombre")]
        public string Nombre { get; set; }

    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "13.15.10.0 (NJsonSchema v10.6.10.0 (Newtonsoft.Json v12.0.0.0))")]
    public partial class TipoExoneracionDto
    {

        [System.Text.Json.Serialization.JsonPropertyName("id")]
        [System.ComponentModel.DataAnnotations.Required(AllowEmptyStrings = true)]
        [System.ComponentModel.DataAnnotations.StringLength(8)]
        [System.ComponentModel.DataAnnotations.RegularExpression(@"^\w+$")]
        public string Id { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("nombre")]
        [System.ComponentModel.DataAnnotations.Required(AllowEmptyStrings = true)]
        [System.ComponentModel.DataAnnotations.StringLength(80)]
        public string Nombre { get; set; }

    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "13.15.10.0 (NJsonSchema v10.6.10.0 (Newtonsoft.Json v12.0.0.0))")]
    public partial class TipoExoneracionLookupDto
    {

        [System.Text.Json.Serialization.JsonPropertyName("id")]
        public string Id { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("nombre")]
        public string Nombre { get; set; }

    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "13.15.10.0 (NJsonSchema v10.6.10.0 (Newtonsoft.Json v12.0.0.0))")]
    public partial class TipoPagoDto
    {

        [System.Text.Json.Serialization.JsonPropertyName("id")]
        [System.ComponentModel.DataAnnotations.Required(AllowEmptyStrings = true)]
        [System.ComponentModel.DataAnnotations.StringLength(8)]
        [System.ComponentModel.DataAnnotations.RegularExpression(@"^\w+$")]
        public string Id { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("nombre")]
        [System.ComponentModel.DataAnnotations.Required(AllowEmptyStrings = true)]
        [System.ComponentModel.DataAnnotations.StringLength(80)]
        public string Nombre { get; set; }

    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "13.15.10.0 (NJsonSchema v10.6.10.0 (Newtonsoft.Json v12.0.0.0))")]
    public partial class TipoServicioDto
    {

        [System.Text.Json.Serialization.JsonPropertyName("id")]
        [System.ComponentModel.DataAnnotations.Required(AllowEmptyStrings = true)]
        [System.ComponentModel.DataAnnotations.StringLength(8)]
        [System.ComponentModel.DataAnnotations.RegularExpression(@"^\w+$")]
        public string Id { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("nombre")]
        [System.ComponentModel.DataAnnotations.Required(AllowEmptyStrings = true)]
        [System.ComponentModel.DataAnnotations.StringLength(80)]
        public string Nombre { get; set; }

    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "13.15.10.0 (NJsonSchema v10.6.10.0 (Newtonsoft.Json v12.0.0.0))")]
    public partial class TipoServicioLookupDto
    {

        [System.Text.Json.Serialization.JsonPropertyName("id")]
        public string Id { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("nombre")]
        public string Nombre { get; set; }

    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "13.15.10.0 (NJsonSchema v10.6.10.0 (Newtonsoft.Json v12.0.0.0))")]
    public partial class ActualizarUnidadAdministrativaServicioDto
    {

        [System.Text.Json.Serialization.JsonPropertyName("tipoPagoId")]
        [System.ComponentModel.DataAnnotations.Required(AllowEmptyStrings = true)]
        public string TipoPagoId { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("activo")]
        public bool Activo { get; set; }

    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "13.15.10.0 (NJsonSchema v10.6.10.0 (Newtonsoft.Json v12.0.0.0))")]
    public partial class AgregarFuncionarioDto
    {

        [System.Text.Json.Serialization.JsonPropertyName("usuarioId")]
        [System.ComponentModel.DataAnnotations.Required(AllowEmptyStrings = true)]
        public System.Guid UsuarioId { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("cargoId")]
        [System.ComponentModel.DataAnnotations.Required(AllowEmptyStrings = true)]
        public string CargoId { get; set; }

    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "13.15.10.0 (NJsonSchema v10.6.10.0 (Newtonsoft.Json v12.0.0.0))")]
    public partial class BancoLookupDto
    {

        [System.Text.Json.Serialization.JsonPropertyName("id")]
        public string Id { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("nombre")]
        public string Nombre { get; set; }

    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "13.15.10.0 (NJsonSchema v10.6.10.0 (Newtonsoft.Json v12.0.0.0))")]
    public partial class CrearActualizarUnidadAdministrativaDto
    {

        [System.Text.Json.Serialization.JsonPropertyName("tipoUnidadAdministrativaId")]
        [System.ComponentModel.DataAnnotations.Required(AllowEmptyStrings = true)]
        public string TipoUnidadAdministrativaId { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("dependenciaAdministrativaId")]
        public System.Guid? DependenciaAdministrativaId { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("codigo")]
        [System.ComponentModel.DataAnnotations.Required(AllowEmptyStrings = true)]
        [System.ComponentModel.DataAnnotations.StringLength(4)]
        public string Codigo { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("nombre")]
        [System.ComponentModel.DataAnnotations.Required(AllowEmptyStrings = true)]
        [System.ComponentModel.DataAnnotations.StringLength(80)]
        public string Nombre { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("siglas")]
        [System.ComponentModel.DataAnnotations.Required(AllowEmptyStrings = true)]
        [System.ComponentModel.DataAnnotations.StringLength(4)]
        public string Siglas { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("paisId")]
        [System.ComponentModel.DataAnnotations.Required(AllowEmptyStrings = true)]
        public string PaisId { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("regionId")]
        [System.ComponentModel.DataAnnotations.Required(AllowEmptyStrings = true)]
        public string RegionId { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("ciudad")]
        public string Ciudad { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("direccion")]
        public string Direccion { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("codigoPostal")]
        public string CodigoPostal { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("bancoId")]
        [System.ComponentModel.DataAnnotations.Required(AllowEmptyStrings = true)]
        public string BancoId { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("numeroCuentaBancaria")]
        [System.ComponentModel.DataAnnotations.Required(AllowEmptyStrings = true)]
        [System.ComponentModel.DataAnnotations.StringLength(32)]
        public string NumeroCuentaBancaria { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("tipoCuentaBancariaId")]
        [System.ComponentModel.DataAnnotations.Required(AllowEmptyStrings = true)]
        public string TipoCuentaBancariaId { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("titularCuentaBancaria")]
        [System.ComponentModel.DataAnnotations.Required(AllowEmptyStrings = true)]
        [System.ComponentModel.DataAnnotations.StringLength(80)]
        public string TitularCuentaBancaria { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("monedaId")]
        [System.ComponentModel.DataAnnotations.Required(AllowEmptyStrings = true)]
        public string MonedaId { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("fechaInicioOperacion")]
        public System.DateTimeOffset? FechaInicioOperacion { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("fechaFinOperacion")]
        public System.DateTimeOffset? FechaFinOperacion { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("activo")]
        public bool Activo { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("nivelId")]
        public string NivelId { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("observaciones")]
        public string Observaciones { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("jurisdiccion")]
        [System.ComponentModel.DataAnnotations.Required]
        public System.Collections.Generic.ICollection<string> Jurisdiccion { get; set; } = new System.Collections.ObjectModel.Collection<string>();

    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "13.15.10.0 (NJsonSchema v10.6.10.0 (Newtonsoft.Json v12.0.0.0))")]
    public partial class CrearSignatarioDto
    {

        [System.Text.Json.Serialization.JsonPropertyName("servicioId")]
        [System.ComponentModel.DataAnnotations.Required(AllowEmptyStrings = true)]
        public System.Guid ServicioId { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("usuarioId")]
        [System.ComponentModel.DataAnnotations.Required(AllowEmptyStrings = true)]
        public System.Guid UsuarioId { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("porDefecto")]
        public bool PorDefecto { get; set; }

    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "13.15.10.0 (NJsonSchema v10.6.10.0 (Newtonsoft.Json v12.0.0.0))")]
    public partial class CrearUnidadAdministrativaServicioDto
    {

        [System.Text.Json.Serialization.JsonPropertyName("servicioId")]
        [System.ComponentModel.DataAnnotations.Required(AllowEmptyStrings = true)]
        public System.Guid ServicioId { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("tipoPagoId")]
        [System.ComponentModel.DataAnnotations.Required(AllowEmptyStrings = true)]
        public string TipoPagoId { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("activo")]
        public bool Activo { get; set; }

    }


    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "13.15.10.0 (NJsonSchema v10.6.10.0 (Newtonsoft.Json v12.0.0.0))")]
    public partial class MonedaLookupDto
    {

        [System.Text.Json.Serialization.JsonPropertyName("id")]
        public string Id { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("nombre")]
        public string Nombre { get; set; }

    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "13.15.10.0 (NJsonSchema v10.6.10.0 (Newtonsoft.Json v12.0.0.0))")]
    public partial class NivelDto
    {

        [System.Text.Json.Serialization.JsonPropertyName("id")]
        [System.ComponentModel.DataAnnotations.Required(AllowEmptyStrings = true)]
        [System.ComponentModel.DataAnnotations.StringLength(4)]
        [System.ComponentModel.DataAnnotations.RegularExpression(@"^\w+$")]
        public string Id { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("nombre")]
        [System.ComponentModel.DataAnnotations.Required(AllowEmptyStrings = true)]
        [System.ComponentModel.DataAnnotations.StringLength(80)]
        public string Nombre { get; set; }

    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "13.15.10.0 (NJsonSchema v10.6.10.0 (Newtonsoft.Json v12.0.0.0))")]
    public partial class NivelLookupDto
    {

        [System.Text.Json.Serialization.JsonPropertyName("id")]
        public string Id { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("nombre")]
        public string Nombre { get; set; }

    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "13.15.10.0 (NJsonSchema v10.6.10.0 (Newtonsoft.Json v12.0.0.0))")]
    public partial class SignatarioDto
    {

        [System.Text.Json.Serialization.JsonPropertyName("unidadAdministrativaId")]
        public System.Guid UnidadAdministrativaId { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("servicioId")]
        public System.Guid ServicioId { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("servicio")]
        public string Servicio { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("usuarioId")]
        public System.Guid UsuarioId { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("porDefecto")]
        public bool PorDefecto { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("poseeFirmaElectronica")]
        public bool PoseeFirmaElectronica { get; set; }

    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "13.15.10.0 (NJsonSchema v10.6.10.0 (Newtonsoft.Json v12.0.0.0))")]
    public partial class UnidadAdministrativaDto
    {

        [System.Text.Json.Serialization.JsonPropertyName("id")]
        public System.Guid Id { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("tipoUnidadAdministrativaId")]
        public string TipoUnidadAdministrativaId { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("tipoUnidadAdministrativa")]
        public string TipoUnidadAdministrativa { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("dependenciaAdministrativaId")]
        public System.Guid? DependenciaAdministrativaId { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("dependenciaAdministrativa")]
        public string DependenciaAdministrativa { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("nombre")]
        public string Nombre { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("siglas")]
        public string Siglas { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("codigo")]
        public string Codigo { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("paisId")]
        public string PaisId { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("pais")]
        public string Pais { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("regionId")]
        public string RegionId { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("region")]
        public string Region { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("ciudad")]
        public string Ciudad { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("subRegion")]
        public string SubRegion { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("direccion")]
        public string Direccion { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("codigoPostal")]
        public string CodigoPostal { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("bancoId")]
        public string BancoId { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("banco")]
        public string Banco { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("monedaId")]
        public string MonedaId { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("moneda")]
        public string Moneda { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("fechaInicioOperacion")]
        public System.DateTimeOffset? FechaInicioOperacion { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("fechaFinOperacion")]
        public System.DateTimeOffset? FechaFinOperacion { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("activo")]
        public bool Activo { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("nivelId")]
        public string NivelId { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("nivel")]
        public string Nivel { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("observaciones")]
        public string Observaciones { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("jurisdiccion")]
        public System.Collections.Generic.ICollection<string> Jurisdiccion { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("tipoCuentaBancariaId")]
        public string TipoCuentaBancariaId { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("tipoCuentaBancaria")]
        public string TipoCuentaBancaria { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("titularCuentaBancaria")]
        public string TitularCuentaBancaria { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("numeroCuentaBancaria")]
        public string NumeroCuentaBancaria { get; set; }

    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "13.15.10.0 (NJsonSchema v10.6.10.0 (Newtonsoft.Json v12.0.0.0))")]
    public partial class UnidadAdministrativaFuncionalDto
    {

        [System.Text.Json.Serialization.JsonPropertyName("usuarioId")]
        public System.Guid UsuarioId { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("nombre")]
        public string Nombre { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("apellido")]
        public string Apellido { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("cargo")]
        public string Cargo { get; set; }

    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "13.15.10.0 (NJsonSchema v10.6.10.0 (Newtonsoft.Json v12.0.0.0))")]
    public partial class UnidadAdministrativaServicioDto
    {

        [System.Text.Json.Serialization.JsonPropertyName("unidadAdministrativaId")]
        public System.Guid UnidadAdministrativaId { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("servicioId")]
        public System.Guid ServicioId { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("servicio")]
        public string Servicio { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("tipoPago")]
        public string TipoPago { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("tipoPagoId")]
        public string TipoPagoId { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("activo")]
        public bool Activo { get; set; }

    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "13.15.10.0 (NJsonSchema v10.6.10.0 (Newtonsoft.Json v12.0.0.0))")]
    public partial class UnidadAdministrativaTipoDto
    {

        [System.Text.Json.Serialization.JsonPropertyName("id")]
        [System.ComponentModel.DataAnnotations.Required(AllowEmptyStrings = true)]
        [System.ComponentModel.DataAnnotations.StringLength(4)]
        [System.ComponentModel.DataAnnotations.RegularExpression(@"^\w+$")]
        public string Id { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("nombre")]
        [System.ComponentModel.DataAnnotations.Required(AllowEmptyStrings = true)]
        [System.ComponentModel.DataAnnotations.StringLength(80)]
        public string Nombre { get; set; }

    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "13.15.10.0 (NJsonSchema v10.6.10.0 (Newtonsoft.Json v12.0.0.0))")]
    public partial class UnidadAdministrativaTipoInfoDto
    {

        [System.Text.Json.Serialization.JsonPropertyName("id")]
        public string Id { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("nombre")]
        public string Nombre { get; set; }

    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "13.15.10.0 (NJsonSchema v10.6.10.0 (Newtonsoft.Json v12.0.0.0))")]
    public partial class CrearActualizarVentanillaDto
    {

        [System.Text.Json.Serialization.JsonPropertyName("unidadAdministrativaId")]
        [System.ComponentModel.DataAnnotations.Required(AllowEmptyStrings = true)]
        public System.Guid UnidadAdministrativaId { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("nombre")]
        [System.ComponentModel.DataAnnotations.Required(AllowEmptyStrings = true)]
        [System.ComponentModel.DataAnnotations.StringLength(80)]
        public string Nombre { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("atencionPresencial")]
        public bool AtencionPresencial { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("atencionVirtual")]
        public bool AtencionVirtual { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("inicioAtencion")]
        public string InicioAtencion { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("finAtencion")]
        public string FinAtencion { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("activo")]
        public bool Activo { get; set; }

    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "13.15.10.0 (NJsonSchema v10.6.10.0 (Newtonsoft.Json v12.0.0.0))")]
    public partial class VentanillaDto
    {

        [System.Text.Json.Serialization.JsonPropertyName("id")]
        public System.Guid Id { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("administrativeUnitId")]
        public System.Guid AdministrativeUnitId { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("name")]
        public string Name { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("isPresentialAttention")]
        public bool IsPresentialAttention { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("isVirtualAttention")]
        public bool IsVirtualAttention { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("attentionStart")]
        public string AttentionStart { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("attentionEnd")]
        public string AttentionEnd { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("isActive")]
        public bool IsActive { get; set; }

    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "13.15.10.0 (NJsonSchema v10.6.10.0 (Newtonsoft.Json v12.0.0.0))")]
    public partial class CrearActualizarPartidaArancelariaDto
    {

        [System.Text.Json.Serialization.JsonPropertyName("descripcion")]
        [System.ComponentModel.DataAnnotations.Required(AllowEmptyStrings = true)]
        [System.ComponentModel.DataAnnotations.StringLength(256)]
        public string Descripcion { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("numeroPartida")]
        [System.ComponentModel.DataAnnotations.Required(AllowEmptyStrings = true)]
        [System.ComponentModel.DataAnnotations.StringLength(4)]
        public string NumeroPartida { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("valor")]
        public double Valor { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("jerarquiaArancelariaId")]
        [System.ComponentModel.DataAnnotations.Required(AllowEmptyStrings = true)]
        public System.Guid JerarquiaArancelariaId { get; set; }

    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "13.15.10.0 (NJsonSchema v10.6.10.0 (Newtonsoft.Json v12.0.0.0))")]
    public partial class ListResultDto_1OfOfPartidaArancelariaServicioDtoAndContractsAnd_0AndCulture_neutralAndPublicKeyToken_null
    {

        [System.Text.Json.Serialization.JsonPropertyName("items")]
        public System.Collections.Generic.ICollection<PartidaArancelariaServicioDto> Items { get; set; }

    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "13.15.10.0 (NJsonSchema v10.6.10.0 (Newtonsoft.Json v12.0.0.0))")]
    public partial class ListResultDto_1OfOfServicioDtoAndContractsAnd_0AndCulture_neutralAndPublicKeyToken_null
    {

        [System.Text.Json.Serialization.JsonPropertyName("items")]
        public System.Collections.Generic.ICollection<ServicioDto> Items { get; set; }

    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "13.15.10.0 (NJsonSchema v10.6.10.0 (Newtonsoft.Json v12.0.0.0))")]
    public partial class CrearActualizarSecuencialLibroDto
    {

        [System.Text.Json.Serialization.JsonPropertyName("servicioId")]
        [System.ComponentModel.DataAnnotations.Required(AllowEmptyStrings = true)]
        public System.Guid ServicioId { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("unidadAdministrativaId")]
        [System.ComponentModel.DataAnnotations.Required(AllowEmptyStrings = true)]
        public System.Guid UnidadAdministrativaId { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("libroId")]
        [System.ComponentModel.DataAnnotations.Required(AllowEmptyStrings = true)]
        public string LibroId { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("numeroPaginaPorVolumen")]
        public int NumeroPaginaPorVolumen { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("volumenActual")]
        public int VolumenActual { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("siguientePagina")]
        public int SiguientePagina { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("anio")]
        public int Anio { get; set; }

    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "13.15.10.0 (NJsonSchema v10.6.10.0 (Newtonsoft.Json v12.0.0.0))")]
    public partial class CrearActualizarServicioDto
    {

        [System.Text.Json.Serialization.JsonPropertyName("nombre")]
        [System.ComponentModel.DataAnnotations.Required(AllowEmptyStrings = true)]
        [System.ComponentModel.DataAnnotations.StringLength(80)]
        public string Nombre { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("atencionPresencial")]
        public bool AtencionPresencial { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("atencionSemiPresencial")]
        public bool AtencionSemiPresencial { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("atencionVirtual")]
        public bool AtencionVirtual { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("tipoServicioId")]
        [System.ComponentModel.DataAnnotations.Required(AllowEmptyStrings = true)]
        public string TipoServicioId { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("activo")]
        public bool Activo { get; set; }

    }


    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "13.15.10.0 (NJsonSchema v10.6.10.0 (Newtonsoft.Json v12.0.0.0))")]
    public partial class ListResultDto_1OfOfUnidadAdministrativaInfoDtoAndContractsAnd_0AndCulture_neutralAndPublicKeyToken_null
    {

        [System.Text.Json.Serialization.JsonPropertyName("items")]
        public System.Collections.Generic.ICollection<UnidadAdministrativaInfoDto> Items { get; set; }

    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "13.15.10.0 (NJsonSchema v10.6.10.0 (Newtonsoft.Json v12.0.0.0))")]
    public partial class Jurisdiccion
    {

        [System.Text.Json.Serialization.JsonPropertyName("ciudades")]
        public System.Collections.Generic.ICollection<string> Ciudades { get; set; }

    }

}
