using AutoMapper;
using MediatR;
using Mre.Visas.Tramite.Application.OrdenCedulacion.Requests;
using Mre.Visas.Tramite.Application.Shared.Handlers;
using Mre.Visas.Tramite.Application.Shared.Interfaces;
using Mre.Visas.Tramite.Application.Shared.Wrappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Mre.Visas.Tramite.Application.OrdenCedulacion.Commands
{
    public class ActualizarOrdenCedulacionCommand : ActualizarOrdenCedulacionRequest, IRequest<ApiResponseWrapper>
    {

        public ActualizarOrdenCedulacionCommand()
        {

        }

    }

    public class ActualizarOrdenCedulacionHandler : BaseHandler, IRequestHandler<ActualizarOrdenCedulacionCommand, ApiResponseWrapper>
    {
        private readonly IMediator mediator;

        public ActualizarOrdenCedulacionHandler(IUnitOfWork unitOfWork, IMapper mapper, IMediator mediator)
            : base(unitOfWork)
        {
            this.Mapper = mapper;
            this.mediator = mediator;
        }

        public async Task<ApiResponseWrapper> Handle(ActualizarOrdenCedulacionCommand command, CancellationToken cancellationToken)
        {
            var ordenCedulacion = await UnitOfWork.OrdenCedulacionRepository.GetByIdAsync(command.Id);
            if (ordenCedulacion == null)
            {
                return new ApiResponseWrapper(HttpStatusCode.NotFound, "Orden de cedulacion no encontrada");
            }


            Mapper.Map(command, ordenCedulacion);


            var resultado = UnitOfWork.OrdenCedulacionRepository.Update(ordenCedulacion);
            if (!resultado.Item1)
                return new ApiResponseWrapper(HttpStatusCode.BadRequest, resultado.Item2);


            var resultSaveChanges = await UnitOfWork.SaveChangesAsync();
            if (!resultSaveChanges.Item1)
                return new ApiResponseWrapper(HttpStatusCode.BadRequest, resultSaveChanges.Item2);


            return new ApiResponseWrapper(HttpStatusCode.OK, null);

        }
    }
}