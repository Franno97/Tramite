using AutoMapper;
using Microsoft.Extensions.Logging;
using Mre.Visas.Tramite.Application.OrdenCedulacion.Commands;
using Mre.Visas.Tramite.Application.OrdenCedulacion.Dtos;
using Mre.Visas.Tramite.Application.OrdenCedulacion.Requests;
using Mre.Visas.Tramite.Application.OrdenCedulacion.Responses;
using Mre.Visas.Tramite.Application.Shared.HttpApiClient;
using Mre.Visas.Tramite.Application.Shared.Util;
using Mre.Visas.Tramite.Application.Tramite.Responses;
using Mre.Visas.Tramite.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mre.Visas.Tramite.Application.OrdenCedulacion.Mappings
{
    public interface IOrdenCedulacionMapper
    {
        Task<CrearOrdenCedulacionRequest> MapearOrdenCedulacionAsync(TramiteCompletoResponse tramite, VisaElectronica visa, Guid pagoId, int diasVigencia);

        Task<ActualizarOrdenCedulacionRequest> MapearOrdenCedulacionAsync(OrdenCedulacionResponse ordenCedulacion);
    }

    public class OrdenCedulacionMapper : IOrdenCedulacionMapper
    {
        private readonly ILogger<OrdenCedulacionMapper> logger;
        private readonly IMapper mapper;

        public OrdenCedulacionMapper(ILogger<OrdenCedulacionMapper> logger,
            IMapper mapper)
        {
            this.logger = logger;
            this.mapper = mapper;
        }


        public async Task<CrearOrdenCedulacionRequest> MapearOrdenCedulacionAsync(TramiteCompletoResponse tramite, VisaElectronica visa, Guid pagoId, int diasVigencia)
        {
            //Convertir la fotografia a byte array
            var conversionFoto = Util.ConvetirBase64AByteArray(tramite.Beneficiario.Foto);
            //Si existieron errores en la conversion registrar en el log
            if (!string.IsNullOrEmpty(conversionFoto.Mensaje))
            {
                logger.LogError("Error al convertir foto a ByteArray tramiteId: {tramiteId}, mensaje: {mensaje}", tramite.Id, conversionFoto.Mensaje);
                return null;
            }

            var ordenCedulacionRequest = new CrearOrdenCedulacionRequest()
            {
                PersonaId = tramite.Beneficiario.Id,
                UnidadAdministrativaId = tramite.UnidadAdministrativaIdCEV,
                Numero = string.Empty,
                CodigoVerificacion = string.Empty,
                Fotografia = conversionFoto.Resultado,
                Nombres = tramite.Beneficiario.Nombres,
                PrimerApellido = tramite.Beneficiario.PrimerApellido,
                SegundoApellido = tramite.Beneficiario.SegundoApellido,
                NacionalidadId = tramite.Beneficiario.NacionalidadId,
                Nacionalidad = tramite.Beneficiario.Nacionalidad,
                PaisNacimiento = tramite.Beneficiario.PaisNacimiento,
                CiudadNacimiento = tramite.Beneficiario.CiudadNacimiento,
                FechaNacimiento = tramite.Beneficiario.FechaNacimiento,
                Sexo = tramite.Beneficiario.Genero,
                EstadoCivil = tramite.Beneficiario.EstadoCivil,
                UnidadOtorgamientoVisa = visa.UnidadAdministrativaNombre,
                FechaEmision = DateTime.Now,
                Validez = diasVigencia,
                FechaInicioValidez = DateTime.Now,
                FechaFinValidez = DateTime.Now.AddDays(diasVigencia),
                FechaRegistro = DateTime.Now,
                IdTramiteEsigex = string.Empty,
                NumeroTramiteEsigex = string.Empty,
                SecuencialActuacion = string.Empty,
                PagoId = pagoId,
                TramiteId = tramite.Id,
                TipoVisaCodigo = "10",//tramite.TipoVisaId,
                TipoVisa = "VISA VIRTE",
                CategoriaVisa = visa.Categoria,
                NumeroVisa = visa.NumeroVisa,
                FechaOtorgamientoVisa = visa.FechaEmision,
                TiempoVigenciaVisa = visa.DiasVigencia,
                Estado = EstadoOrdenCedulacion.Creada
            };

            return ordenCedulacionRequest;
        }


        public async Task<ActualizarOrdenCedulacionRequest> MapearOrdenCedulacionAsync(OrdenCedulacionResponse ordenCedulacion)
        {
            var actualizarOrdenCedulacionReq = mapper.Map<ActualizarOrdenCedulacionRequest>(ordenCedulacion);

            return actualizarOrdenCedulacionReq;
        }

    }
}
