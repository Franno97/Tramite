using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using Mre.Visas.Tramite.Application.OrdenCedulacion.Dtos;
using Mre.Visas.Tramite.Application.OrdenCedulacion.Responses;
using Mre.Visas.Tramite.Application.Shared.Handlers;
using Mre.Visas.Tramite.Application.Shared.Interfaces;
using Mre.Visas.Tramite.Application.Shared.Util;
using Mre.Visas.Tramite.Application.Shared.Wrappers;
using System;
using System.Net;
using System.Threading;
using System.Threading.Tasks;

namespace Mre.Visas.Tramite.Application.OrdenCedulacion.Commands
{
    public class CrearOrdenCedulacionCommand : CrearOrdenCedulacionRequest, IRequest<ApiResponseWrapper<Guid>>
    {
        public CrearOrdenCedulacionCommand()
        {

        }
    }

    public class CrearOrdenCedulacionHandler : BaseHandler, IRequestHandler<CrearOrdenCedulacionCommand, ApiResponseWrapper<Guid>>
    {
        private readonly ILogger<CrearOrdenCedulacionHandler> logger;

        public CrearOrdenCedulacionHandler(IUnitOfWork unitOfWork,
            IMapper mapper,
            ILogger<CrearOrdenCedulacionHandler> logger)
            : base(unitOfWork)
        {
            this.Mapper = mapper;
            this.logger = logger;
        }

        public async Task<ApiResponseWrapper<Guid>> Handle(CrearOrdenCedulacionCommand command, CancellationToken cancellationToken)
        {
            var ordenCedulacion = Mapper.Map<Domain.Entities.OrdenCedulacion>(command);

            ordenCedulacion.AssignId();

            //Enviar a guardar la orden de cedulacion
            var resultado = await GuardarOrdenCedulacionAsync(ordenCedulacion);

            return resultado;
        }

        //private async Task<Domain.Entities.OrdenCedulacion> MapearOrdenCedulacionAsync(CrearOrdenCedulacionCommand command)
        //{
        //    //Convertir la fotografia a byte array
        //    var conversionFoto = Util.ConvetirBase64AByteArray(command.Tramite.Beneficiario.Foto);
        //    //Si existieron errores en la conversion registrar en el log
        //    if (!string.IsNullOrEmpty(conversionFoto.Mensaje))
        //    {
        //        logger.LogWarning(conversionFoto.Mensaje);
        //    }

        //    var ordenCedulacion = new Domain.Entities.OrdenCedulacion()
        //    {
        //        PersonaId = command.Tramite.PersonaId,
        //        UnidadAdministrativaId = command.Tramite.UnidadAdministrativaIdCEV,
        //        //Numero = command.NumeroOrden,
        //        //CodigoVerificacion = command.CodigoVerificacion,
        //        Fotografia = conversionFoto.Resultado,
        //        Nombres = command.Tramite.Beneficiario.Nombres,
        //        PrimerApellido = command.Tramite.Beneficiario.PrimerApellido,
        //        SegundoApellido = command.Tramite.Beneficiario.SegundoApellido,
        //        NacionalidadId = command.Tramite.Beneficiario.NacionalidadId,
        //        Nacionalidad = command.Tramite.Beneficiario.Nacionalidad,
        //        PaisNacimiento = command.Tramite.Beneficiario.PaisNacimiento,
        //        //No existe ciudad de nacimiento
        //        CiudadNacimiento = "Caracas", //"Obtener ciudad nacimiento",
        //        FechaNacimiento = command.Tramite.Beneficiario.FechaNacimiento,
        //        Sexo = command.Tramite.Beneficiario.Genero,
        //        EstadoCivil = command.Tramite.Beneficiario.EstadoCivil,
        //        //ConyugePrimerApellido = command.ConyugePrimerApellido,
        //        //ConyugeSegundoApellido = command.ConyugeSegundoApellido,
        //        //ConyugeNombres = command.ConyugeNombres,
        //        //ConyugeNacionalidadCodigo = command.ConyugeNacionalidadCodigo,
        //        //ConyugeNacionalidad = command.ConyugeNacionalidad,
        //        //ConyugeCorreoElectronico = command.ConyugeCorreoElectronico,
        //        //Observacion = command.Observacion,
        //        UnidadOtorgamientoVisa = command.Tramite.UnidadAdministrativaIdCEV.ToString(),
        //        FechaEmision = DateTime.Now,
        //        Validez = command.DiasVigencia,
        //        //SignatarioUsuarioId = command.Signatario.UsuarioId,
        //        //SignatarioApellido = command.Signatario.Apellido,
        //        //SignatarioNombre = command.Signatario.Nombre,
        //        //SignatarioCargo = command.Signatario.Cargo,
        //        //SignatarioCiudad = command.Signatario.Ciudad,
        //        ///
        //        //NumeroTransaccion = command.NumeroTransaccion,
        //        //PagoId = command.PagoId,
        //        TramiteId = command.Tramite.Id,
        //        //RutaAlmacenamientoFactura = command.RutaAlmacenamientoFactura,
        //        //RutaAlmacenamientoOrdenCedulacion = "", //Se llena luego de generar el pdf
        //        ///
        //        TipoVisaCodigo = command.Visa.TipoVisaCodigo,
        //        TipoVisa = command.Visa.TipoVisa,
        //        CategoriaVisa = command.Visa.CategoriaVisa,
        //        NumeroVisa = command.Visa.Numero,
        //        FechaOtorgamientoVisa = command.Visa.FechaOtorgamiento,
        //        TiempoVigenciaVisa = command.Visa.TiempoVigencia
        //    };
        //    ordenCedulacion.AssignId();

        //    return ordenCedulacion;
        //}
    
        private async Task<ApiResponseWrapper<Guid>> GuardarOrdenCedulacionAsync(Domain.Entities.OrdenCedulacion ordenCedulacion)
        {
            var resultado = await UnitOfWork.OrdenCedulacionRepository.InsertAsync(ordenCedulacion);

            if (!resultado.Item1)
                return new ApiResponseWrapper<Guid>(HttpStatusCode.BadRequest, resultado.Item2);

            var resultSaveChanges = await UnitOfWork.SaveChangesAsync();
            if (!resultSaveChanges.Item1)
                return new ApiResponseWrapper<Guid>(HttpStatusCode.BadRequest, resultSaveChanges.Item2);

            return new ApiResponseWrapper<Guid>(HttpStatusCode.OK, ordenCedulacion.Id);
        }

    }
}
