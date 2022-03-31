using AutoMapper;
using Mre.Visas.Tramite.Application.ConfiguracionFirmaElectronica.Queries;
using Mre.Visas.Tramite.Application.Shared.Requests;
using Mre.Visas.Tramite.Application.Shared.Responses;

namespace Mre.Visas.Tramite.Application.ConfiguracionFirmaElectronica.Commands
{
    public class ConfiguracionFirmaElectronicaProfile : Profile
    {
        public ConfiguracionFirmaElectronicaProfile()
        {

            CreateMap<CrearConfiguracionFirmaElectronicaRequest, CrearConfiguracionFirmaElectronicaCommand>();

            CreateMap<CrearConfiguracionFirmaElectronicaCommand, Domain.Entities.ConfiguracionFirmaElectronica>();

            CreateMap<ActualizarConfiguracionFirmaElectronicaRequest, ActualizarConfiguracionFirmaElectronicaCommand>();

            CreateMap<ActualizarConfiguracionFirmaElectronicaCommand, Domain.Entities.ConfiguracionFirmaElectronica>();

            CreateMap<ObtenerListaConfiguracionFirmaElectronicaRequest, ObtenerListaConfiguracionFirmaElectronicaQuery>();

            

            CreateMap< Domain.Entities.ConfiguracionFirmaElectronica, ConfiguracionFirmaElectronicaResponse > ();

            CreateMap<PaginadoRequest, ObtenerListaConfiguracionFirmaElectronicaQuery>();

             
            CreateMap(typeof(ResultadoPaginadoResponse<>), typeof(ResultadoPaginadoResponse<>));

        }
    }

}
