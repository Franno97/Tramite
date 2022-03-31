using AutoMapper;
using Mre.Visas.Tramite.Application.OrdenCedulacion.Commands;
using Mre.Visas.Tramite.Application.OrdenCedulacion.Requests;
using Mre.Visas.Tramite.Application.OrdenCedulacion.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mre.Visas.Tramite.Application.OrdenCedulacion.Mappings
{
    public class OrdenCedulacionProfile : Profile
    {
        public OrdenCedulacionProfile()
        {

            CreateMap<CrearOrdenCedulacionRequest, CrearOrdenCedulacionCommand>();

            CreateMap<CrearOrdenCedulacionCommand, Domain.Entities.OrdenCedulacion>();

            CreateMap<Domain.Entities.OrdenCedulacion, OrdenCedulacionResponse>();



            CreateMap<ActualizarOrdenCedulacionRequest, ActualizarOrdenCedulacionCommand>();

            CreateMap<ActualizarOrdenCedulacionCommand, Domain.Entities.OrdenCedulacion>();



            CreateMap<OrdenCedulacionResponse, ActualizarOrdenCedulacionRequest>();

        }
        
    }
}
