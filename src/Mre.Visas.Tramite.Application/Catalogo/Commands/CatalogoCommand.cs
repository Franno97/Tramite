using FluentValidation;
using MediatR;
using Mre.Visas.Tramite.Application.Catalogo.Requests;
using Mre.Visas.Tramite.Application.Catalogo.Responses;
using Mre.Visas.Tramite.Application.Shared.Handlers;
using Mre.Visas.Tramite.Application.Shared.Interfaces;
using Mre.Visas.Tramite.Application.Shared.Wrappers;
using Mre.Visas.Tramite.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Mre.Visas.Tramite.Application.Catalogo.Commands
{
  #region CalidadMigratoria

  public class CrearCalidadMigratoriaCommand : CalidadMigratoriaRequest, IRequest<ApiResponseWrapper>
  {
    public CrearCalidadMigratoriaCommand(CalidadMigratoriaRequest request)
    {
      Codigo = request.Codigo;
      Descripcion = request.Descripcion;
      UsuarioId = request.UsuarioId;
    }

    public class CrearCalidadMigratoriaCommandHandler : BaseHandler, IRequestHandler<CrearCalidadMigratoriaCommand, ApiResponseWrapper>
    {

      public CrearCalidadMigratoriaCommandHandler(IUnitOfWork unitOfWork) : base(unitOfWork)
      {

      }
      public async Task<ApiResponseWrapper> Handle(CrearCalidadMigratoriaCommand request, CancellationToken cancellationToken)
      {
        var response = new CalidadMigratoriaResponse();

        try
        {
          CalidadMigratoria calidadMigratoria = new()
          {
            CalidadMigratoriaId = request.Codigo,
            Descripcion = request.Descripcion,
            CreatorId = request.UsuarioId,
            LastModifierId = request.UsuarioId
          };
          calidadMigratoria.AssignId();

          var resultado = UnitOfWork.CalidadMigratoriaRepository.InsertAsync(calidadMigratoria);
          if (!resultado.Result.Item1)
            throw new Exception(resultado.Result.Item2);

          var resultSave = await UnitOfWork.SaveChangesAsync();
          if (!resultSave.Item1)
            throw new Exception(resultSave.Item2);

          response.CalidadMigratoria = calidadMigratoria;

          return new ApiResponseWrapper(HttpStatusCode.OK, response);

        }
        catch (Exception ex)
        {
          return new ApiResponseWrapper(HttpStatusCode.BadRequest, new CalidadMigratoriaResponse { Error = ex.Message ?? ex.InnerException.ToString() });
        }
      }
    }

    public class CrearCalidadMigratoriaCommandValidator : AbstractValidator<CrearCalidadMigratoriaCommand>
    {
      public CrearCalidadMigratoriaCommandValidator()
      {
        //RuleForEach(x => x.Documentos).NotNull().WithMessage("Documentos {CollectionIndex} is required.");

        //  RuleFor(e => e.DocumentoId)
        //  .NotEmpty().WithMessage("{PropertyName} es requerido.")
        //  .NotNull().WithMessage("{PropertyName} no puede ser nulo.");

        //  RuleFor(e => e.UsuarioId)
        //  .NotEmpty().WithMessage("{PropertyName} es requerido.")
        //  .NotNull().WithMessage("{PropertyName} no puede ser nulo.");
      }
    }
  }
  #endregion

  #region TipoConvenio

  public class CrearTipoConvenioCommand : TipoConvenioRequest, IRequest<ApiResponseWrapper>
  {
    public CrearTipoConvenioCommand(TipoConvenioRequest request)
    {
      TipoConvenioCodigo = request.TipoConvenioCodigo;
      Descripcion = request.Descripcion;
      UsuarioId = request.UsuarioId;
    }

    public class CrearTipoConvenioCommandHandler : BaseHandler, IRequestHandler<CrearTipoConvenioCommand, ApiResponseWrapper>
    {
      public CrearTipoConvenioCommandHandler(IUnitOfWork unitOfWork) : base(unitOfWork)
      {

      }
      public async Task<ApiResponseWrapper> Handle(CrearTipoConvenioCommand request, CancellationToken cancellationToken)
      {
        var response = new TipoConvenioResponse();

        try
        {
          TipoConvenio TipoConvenio = new()
          {
            TipoConvenioCodigo = request.TipoConvenioCodigo,
            Descripcion = request.Descripcion,
            CreatorId = request.UsuarioId,
            LastModifierId = request.UsuarioId
          };
          TipoConvenio.AssignId();

          var resultado = UnitOfWork.TipoConvenioRepository.InsertAsync(TipoConvenio);
          if (!resultado.Result.Item1)
            throw new Exception(resultado.Result.Item2);

          var resultSave = await UnitOfWork.SaveChangesAsync();
          if (!resultSave.Item1)
            throw new Exception(resultSave.Item2);

          response.TipoConvenio = TipoConvenio;

          return new ApiResponseWrapper(HttpStatusCode.OK, response);

        }
        catch (Exception ex)
        {
          return new ApiResponseWrapper(HttpStatusCode.BadRequest, new TipoConvenioResponse { Error = ex.Message ?? ex.InnerException.ToString() });
        }
      }
    }

    public class CrearTipoConvenioCommandValidator : AbstractValidator<CrearTipoConvenioCommand>
    {
      public CrearTipoConvenioCommandValidator()
      {
        //RuleForEach(x => x.Documentos).NotNull().WithMessage("Documentos {CollectionIndex} is required.");

        //  RuleFor(e => e.DocumentoId)
        //  .NotEmpty().WithMessage("{PropertyName} es requerido.")
        //  .NotNull().WithMessage("{PropertyName} no puede ser nulo.");

        //  RuleFor(e => e.UsuarioId)
        //  .NotEmpty().WithMessage("{PropertyName} es requerido.")
        //  .NotNull().WithMessage("{PropertyName} no puede ser nulo.");
      }
    }
  }
  #endregion

  #region TipoVisa
  public class CrearTipoVisaCommand : TipoVisaRequest, IRequest<ApiResponseWrapper>
  {
    public CrearTipoVisaCommand(TipoVisaRequest request)
    {
      TipoConvenioCodigo = request.TipoConvenioCodigo;
      TipoVisaCodigo = request.TipoVisaCodigo;
      Descripcion = request.Descripcion;
      UsuarioId = request.UsuarioId;
      TipoVisaCodigo = request.TipoVisaCodigo;
      CalidadMigratoriaId = request.CalidadMigratoriaId;
      NumeroAdmisiones = request.NumeroAdmisiones;
      DiasValidez = request.DiasValidez;
      RequiereAutorizacion = request.RequiereAutorizacion;
      Categoria = request.Categoria;
      ServicioVisasId = request.ServicioVisasId;

    }

    public class CrearTipoVisaCommandHandler : BaseHandler, IRequestHandler<CrearTipoVisaCommand, ApiResponseWrapper>
    {
      public CrearTipoVisaCommandHandler(IUnitOfWork unitOfWork) : base(unitOfWork)
      {

      }
      public async Task<ApiResponseWrapper> Handle(CrearTipoVisaCommand request, CancellationToken cancellationToken)
      {
        var response = new TipoVisaResponse();

        try
        {
          TipoVisa TipoVisa = new()
          {
            TipoConvenioCodigo = request.TipoConvenioCodigo,
            TipoVisaCodigo = request.TipoVisaCodigo,
            Descripcion = request.Descripcion,
            CalidadMigratoriaId = request.CalidadMigratoriaId,
            NumeroAdmisiones = request.NumeroAdmisiones,
            DiasValidez = request.DiasValidez,
            RequiereAutorizacion = request.RequiereAutorizacion,
            Categoria = request.Categoria,
            ServicioVisasId = request.ServicioVisasId,
            CreatorId = request.UsuarioId,
            LastModifierId = request.UsuarioId
          };
          TipoVisa.AssignId();

          var resultado = UnitOfWork.TipoVisaRepository.InsertAsync(TipoVisa);
          if (!resultado.Result.Item1)
            throw new Exception(resultado.Result.Item2);

          var resultSave = await UnitOfWork.SaveChangesAsync();
          if (!resultSave.Item1)
            throw new Exception(resultSave.Item2);

          response.TipoVisa = TipoVisa;

          return new ApiResponseWrapper(HttpStatusCode.OK, response);

        }
        catch (Exception ex)
        {
          return new ApiResponseWrapper(HttpStatusCode.BadRequest, new TipoVisaResponse
          {
            Error = ex.Message ?? ex.InnerException.ToString()
          });
        }
      }
    }

    public class CrearTipoVisaCommandValidator : AbstractValidator<CrearTipoVisaCommand>
    {
      public CrearTipoVisaCommandValidator()
      {
        //RuleForEach(x => x.Documentos).NotNull().WithMessage("Documentos {CollectionIndex} is required.");

        //  RuleFor(e => e.DocumentoId)
        //  .NotEmpty().WithMessage("{PropertyName} es requerido.")
        //  .NotNull().WithMessage("{PropertyName} no puede ser nulo.");

        //  RuleFor(e => e.UsuarioId)
        //  .NotEmpty().WithMessage("{PropertyName} es requerido.")
        //  .NotNull().WithMessage("{PropertyName} no puede ser nulo.");
      }
    }
  }
  #endregion

  #region ActividadDesarrollar

  public class CrearActividadDesarrollarCommand : ActividadDesarrollarRequest, IRequest<ApiResponseWrapper>
  {
    public CrearActividadDesarrollarCommand(ActividadDesarrollarRequest request)
    {
      TipoVisaCodigo = request.TipoVisaCodigo;
      ActividadDesarrollarCodigo = request.ActividadDesarrollarCodigo;
      Descripcion = request.Descripcion;
      UsuarioId = request.UsuarioId;
    }

    public class CrearActividadDesarrollarCommandHandler : BaseHandler, IRequestHandler<CrearActividadDesarrollarCommand, ApiResponseWrapper>
    {

      public CrearActividadDesarrollarCommandHandler(IUnitOfWork unitOfWork) : base(unitOfWork)
      {

      }
      public async Task<ApiResponseWrapper> Handle(CrearActividadDesarrollarCommand command, CancellationToken cancellationToken)
      {
        var response = new ActividadDesarrollarResponse();

        try
        {
          ActividadDesarrollar ActividadDesarrollar = new()
          {
            TipoVisaCodigo = command.TipoVisaCodigo,
            ActividadDesarrollarCodigo = command.ActividadDesarrollarCodigo,
            Descripcion = command.Descripcion,
            CreatorId = command.UsuarioId,
            LastModifierId = command.UsuarioId
          };
          ActividadDesarrollar.AssignId();

          var resultado = UnitOfWork.ActividadDesarrollarRepository.InsertAsync(ActividadDesarrollar);
          if (!resultado.Result.Item1)
            throw new Exception(resultado.Result.Item2);

          var resultSave = await UnitOfWork.SaveChangesAsync();
          if (!resultSave.Item1)
            throw new Exception(resultSave.Item2);

          response.ActividadDesarrollar = ActividadDesarrollar;

          return new ApiResponseWrapper(HttpStatusCode.OK, response);

        }
        catch (Exception ex)
        {
          return new ApiResponseWrapper(HttpStatusCode.BadRequest, new ActividadDesarrollarResponse { Error = ex.Message ?? ex.InnerException.ToString() });
        }
      }
    }

    public class CrearActividadDesarrollarCommandValidator : AbstractValidator<CrearActividadDesarrollarCommand>
    {
      public CrearActividadDesarrollarCommandValidator()
      {
        //RuleForEach(x => x.Documentos).NotNull().WithMessage("Documentos {CollectionIndex} is required.");

        //  RuleFor(e => e.DocumentoId)
        //  .NotEmpty().WithMessage("{PropertyName} es requerido.")
        //  .NotNull().WithMessage("{PropertyName} no puede ser nulo.");

        //  RuleFor(e => e.UsuarioId)
        //  .NotEmpty().WithMessage("{PropertyName} es requerido.")
        //  .NotNull().WithMessage("{PropertyName} no puede ser nulo.");
      }
    }
  }
  #endregion

}