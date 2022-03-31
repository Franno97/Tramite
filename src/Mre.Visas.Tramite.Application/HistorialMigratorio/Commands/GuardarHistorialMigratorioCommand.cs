using FluentValidation;
using MediatR;
using Mre.Visas.Tramite.Application.HistorialMigratorio.Requests;
using Mre.Visas.Tramite.Application.Shared.Handlers;
using Mre.Visas.Tramite.Application.Shared.Interfaces;
using Mre.Visas.Tramite.Application.Shared.Wrappers;
using System;
using System.Linq;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using System.Collections.Generic;
using AutoMapper;
using Mre.Visas.Tramite.Application.Shared.HttpApiClient;
using Mre.Visas.Tramite.Application.Shared.Security;
using Microsoft.AspNetCore.Authorization;

namespace Mre.Visas.Tramite.Application.HistorialMigratorio.Commands
{
  public class GuardarHistorialMigratorioCommand : HistorialMigratorioRequest, IRequest<ApiResponseWrapper>
  {
    public GuardarHistorialMigratorioCommand(HistorialMigratorioRequest request)
    {
      TramiteId = request.TramiteId;
      UsuarioId = request.UsuarioId;

      ListaHistorialMigratorio = new List<HistorialMigratorioDetalleRequest>();
      foreach (var detalleRequest in request.ListaHistorialMigratorio)
      {
        HistorialMigratorioDetalleRequest historialMigratorioDetalleRequest = new()
        {
          ApellidosNombres = detalleRequest.ApellidosNombres,
          CategoriaMigratoria = detalleRequest.CategoriaMigratoria,
          CodigoError = detalleRequest.CodigoError,
          FechaHoraMovimiento = detalleRequest.FechaHoraMovimiento,
          FechaNacimiento = detalleRequest.FechaNacimiento,
          Genero = detalleRequest.Genero,
          Medio = detalleRequest.Medio,
          MotivoViaje = detalleRequest.MotivoViaje,
          NacionalidadDocumentoMovMigra = detalleRequest.NacionalidadDocumentoMovMigra,
          NumeroDocumentoMovMigra = detalleRequest.NumeroDocumentoMovMigra,
          PaisDestino = detalleRequest.PaisDestino,
          PaisNacimiento = detalleRequest.PaisNacimiento,
          PaisOrigen = detalleRequest.PaisOrigen,
          PaisResidencia = detalleRequest.PaisResidencia,
          PuertoRegistro = detalleRequest.PuertoRegistro,
          TarjetaAndina = detalleRequest.TarjetaAndina,
          TiempoDeclarado = detalleRequest.TiempoDeclarado,
          TipoDocumentoMovMigra = detalleRequest.TipoDocumentoMovMigra,
          TipoMovimiento = detalleRequest.TipoMovimiento
        };

        ListaHistorialMigratorio.Add(historialMigratorioDetalleRequest);
      }
    }


    public class GuardarHistorialMigratorioHandler : BaseHandler, IRequestHandler<GuardarHistorialMigratorioCommand, ApiResponseWrapper>
    {
      public GuardarHistorialMigratorioHandler(IMapper mapper, IUnitOfWork unitOfWork, INotificadorClient notificadorClient, ITokenAcceso tokenAcceso) : base(mapper, unitOfWork, notificadorClient, tokenAcceso)
      {

      }

      [Authorize(Contracts.TramitePermissionDefinition.HistorialMigratorioCrear)]
      public async Task<ApiResponseWrapper> Handle(GuardarHistorialMigratorioCommand command, CancellationToken cancellationToken)
      {

        var mapper = new Mapper(new MapperConfiguration(cfg =>
        {
          cfg.CreateMap<HistorialMigratorioDetalleRequest, Domain.Entities.HistorialMigratorio>();
        }));

        try
        {


          foreach (var historialMigratorioDetalleRequest in command.ListaHistorialMigratorio)
          {

            Domain.Entities.HistorialMigratorio historialMigratorio = new Domain.Entities.HistorialMigratorio();
            historialMigratorio = mapper.Map<Domain.Entities.HistorialMigratorio>(historialMigratorioDetalleRequest);

            historialMigratorio.AssignId();
            historialMigratorio.TramiteId = command.TramiteId;
            historialMigratorio.Created = DateTime.Now;
            historialMigratorio.LastModified = DateTime.Now;
            historialMigratorio.CreatorId = command.UsuarioId;
            historialMigratorio.LastModifierId = command.UsuarioId;

            var resultado = UnitOfWork.HistorialMigratorioRepository.InsertAsync(historialMigratorio);

            if (!resultado.Result.Item1)
              throw new Exception(resultado.Result.Item2);

          }
          var result2 = await UnitOfWork.SaveChangesAsync();
          if (!result2.Item1)
            throw new Exception(result2.Item2);
        }
        catch (Exception ex)
        {

          return new ApiResponseWrapper(HttpStatusCode.BadRequest, ex.Message == null ? ex.InnerException : ex.Message);
        }

        return new ApiResponseWrapper(HttpStatusCode.OK, command.TramiteId);

      }

    }
  }

  public class GuardarHistorialMigratorioCommandValidator : AbstractValidator<GuardarHistorialMigratorioCommand>
  {
    public GuardarHistorialMigratorioCommandValidator()
    {
      //RuleFor(e => e.TramiteId)
      //     .NotEmpty().WithMessage("{PropertyName} es requerido.")
      //     .NotNull().WithMessage("{PropertyName} no puede ser nulo.");

      //RuleFor(e => e.Estado)
      //     .NotEmpty().WithMessage("{PropertyName} es requerido.")
      //     .NotNull().WithMessage("{PropertyName} no puede ser nulo.")
      //     .InclusiveBetween(1, 100);

      //RuleFor(e => e.CreatorId)
      //     .NotEmpty().WithMessage("{PropertyName} es requerido.")
      //     .NotNull().WithMessage("{PropertyName} no puede ser nulo.");
    }
  }

}
