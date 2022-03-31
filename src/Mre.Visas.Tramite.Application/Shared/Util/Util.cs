using Mre.Visas.Tramite.Domain.Const;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Mre.Visas.Tramite.Application.Shared.Util
{
  public static class Util
  {
    public static ResultadoConversion ConvetirBase64AByteArray(string base64String)
    {
      var conversion = new ResultadoConversion();

      var base64 = QuitarPrefijoBase64(base64String);
      try
      {
        conversion.Resultado = Convert.FromBase64String(base64);
      }
      catch (Exception ex)
      {
        conversion.Resultado = null;
        conversion.Mensaje = string.Format("{0}, {1}", TextosConsts.ErrorConvertirFoto, ex);
      }

      return conversion;
    }

    public static string QuitarPrefijoBase64(string base64String)
    {
      if (string.IsNullOrEmpty(base64String))
      {
        return string.Empty;
      }
      return Regex.Replace(base64String, @"^data:image\/[a-zA-Z]+;base64,", string.Empty);
    }
    public static string ObtenerDescripcion(string tipoDocumento)
    {
      switch (tipoDocumento)
      {
        case TipoDocumentoConst.PASP:
          return "Pasaporte";
        case TipoDocumentoConst.CEDU:
          return "Cédula";
        case TipoDocumentoConst.RCON:
          return "Registro consultar";
        case TipoDocumentoConst.APEN:
          return "Antecedentes penales";
        case TipoDocumentoConst.PAGO1:
          return "Comprobante de pago solicitud visa";
        case TipoDocumentoConst.PAGO2:
          return "Comprobante de pago orden cedulación";
        case TipoDocumentoConst.PNAC:
          return "Partida de nacimiento";
        case TipoDocumentoConst.COND:
          return "Carnet conadis";
        case TipoDocumentoConst.FOTO:
          return "Fotografía";
        default:
          return "Tipo no definido";
      }
    }
    public static string ObtenerNombreBiblioteca(string tipoDocumento)
    {
      switch (tipoDocumento)
      {
        case TipoDocumentoConst.PASP:
          return "Pasaporte/";
        case TipoDocumentoConst.CEDU:
          return "Cedula/";
        case TipoDocumentoConst.RCON:
          return "RegistroConsular/";
        case TipoDocumentoConst.APEN:
          return "AntecedentesPenales/";
        case TipoDocumentoConst.PAGO1:
          return "PagoComprobante/";
        case TipoDocumentoConst.PAGO2:
          return "PagoComprobante/";
        case TipoDocumentoConst.PNAC:
          return "PartidaNacimiento/";
        case TipoDocumentoConst.COND:
          return "CarnetDiscapacidad/";
        case TipoDocumentoConst.FOTO:
          return "Foto/";
        default:
          return "Ninguno/";//tipo no definicdo
      }
    }
    public static string ObtenerUrlDocumento(string url,string tipoDocumento, string nombre)
    {
      return System.IO.Path.Combine(url, ObtenerNombreBiblioteca(tipoDocumento), nombre);
    }
    public static Tramite.Responses.TramiteCompletoResponse MapearTramite(Domain.Entities.Tramite tramite)
    {
      var tramiteCompleto = new Tramite.Responses.TramiteCompletoResponse
      {
        Id = tramite.Id,
        TipoConvenioId = tramite.TipoConvenioId,
        ActividadId = tramite.ActividadId,
        BeneficiarioId = tramite.BeneficiarioId,
        CalidadMigratoriaId = tramite.CalidadMigratoriaId,
        CodigoPais = tramite.CodigoPais,
        Fecha = tramite.Fecha,
        ServicioId = tramite.ServicioId,
        Numero = tramite.Numero,
        SolicitanteId = tramite.SolicitanteId,
        TipoTramite = tramite.TipoTramite,
        PersonaId = tramite.PersonaId,
        OrigenId = tramite.OrigenId,
        TipoVisaId = tramite.TipoVisaId,
        UnidadAdministrativaIdCEV = tramite.UnidadAdministrativaIdCEV,
        UnidadAdministrativaIdZonal = tramite.UnidadAdministrativaIdZonal,
        Solicitante = new Tramite.Responses.TramiteCompletoResponse.SolicitanteResponse
        {
          Id = tramite.Solicitante.Id,
          TipoIdentificacion = tramite.Solicitante.TipoIdentificacion,
          Nombres = tramite.Solicitante.Nombres,
          Ciudad = tramite.Solicitante.Ciudad,
          ConsuladoNombre = tramite.Solicitante.ConsuladoNombre,
          ConsuladoPais = tramite.Solicitante.ConsuladoPais,
          Correo = tramite.Solicitante.Correo,
          Direccion = tramite.Solicitante.Direccion,
          Edad = tramite.Solicitante.Edad,
          Identificacion = tramite.Solicitante.Identificacion,
          Nacionalidad = tramite.Solicitante.Nacionalidad,
          Pais = tramite.Solicitante.Pais,
          Telefono = tramite.Solicitante.Telefono
        },
        Beneficiario = new Tramite.Responses.TramiteCompletoResponse.BeneficiarioResponse
        {
          Id = tramite.Beneficiario.Id,
          CarnetConadis = tramite.Beneficiario.CarnetConadis,
          CiudadNacimiento = tramite.Beneficiario.CiudadNacimiento,
          CodigoMDG = tramite.Beneficiario.CodigoMDG,
          Correo = tramite.Beneficiario.Correo,
          DomicilioId = tramite.Beneficiario.DomicilioId,
          Edad = tramite.Beneficiario.Edad,
          EstadoCivil = tramite.Beneficiario.EstadoCivil,
          Foto = tramite.Beneficiario.Foto,
          FechaCaducidadConadis = tramite.Beneficiario.FechaCaducidadConadis,
          FechaEmisionConadis = tramite.Beneficiario.FechaEmisionConadis,
          FechaNacimiento = tramite.Beneficiario.FechaNacimiento,
          Genero = tramite.Beneficiario.Genero,
          Nacionalidad = tramite.Beneficiario.Nacionalidad,
          NacionalidadId = tramite.Beneficiario.NacionalidadId,
          Nombres = tramite.Beneficiario.Nombres,
          Ocupacion = tramite.Beneficiario.Ocupacion,
          PaisNacimiento = tramite.Beneficiario.PaisNacimiento,
          PasaporteId = tramite.Beneficiario.PasaporteId,
          PorcentajeDiscapacidad = tramite.Beneficiario.PorcentajeDiscapacidad,
          PoseeDiscapacidad = tramite.Beneficiario.PoseeDiscapacidad,
          PrimerApellido = tramite.Beneficiario.PrimerApellido,
          SegundoApellido = tramite.Beneficiario.SegundoApellido,
          TipoCiudadano = tramite.Beneficiario.TipoCiudadano,
          VisaId = tramite.Beneficiario.VisaId,
          Pasaporte = new Tramite.Responses.TramiteCompletoResponse.BeneficiarioResponse.PasaporteResponse
          {
            Id = tramite.Beneficiario.Pasaporte.Id,
            Nombres = tramite.Beneficiario.Pasaporte.Nombres,
            CiudadEmision = tramite.Beneficiario.Pasaporte.CiudadEmision,
            FechaEmision = tramite.Beneficiario.Pasaporte.FechaEmision,
            FechaExpiracion = tramite.Beneficiario.Pasaporte.FechaExpiracion,
            FechaNacimiento = tramite.Beneficiario.Pasaporte.FechaNacimiento,
            Numero = tramite.Beneficiario.Pasaporte.Numero,
            PaisEmision = tramite.Beneficiario.Pasaporte.PaisEmision,
            TipoDocumentoIdentidadId = tramite.Beneficiario.Pasaporte.TipoDocumentoIdentidadId
          },
          Domicilio = new Tramite.Responses.TramiteCompletoResponse.BeneficiarioResponse.DomicilioResponse
          {
            Id = tramite.Beneficiario.Domicilio.Id,
            Ciudad = tramite.Beneficiario.Domicilio.Ciudad,
            Direccion = tramite.Beneficiario.Domicilio.Direccion,
            Pais = tramite.Beneficiario.Domicilio.Pais,
            Provincia = tramite.Beneficiario.Domicilio.Provincia,
            TelefonoCelular = tramite.Beneficiario.Domicilio.TelefonoCelular,
            TelefonoDomicilio = tramite.Beneficiario.Domicilio.TelefonoDomicilio,
            TelefonoTrabajo = tramite.Beneficiario.Domicilio.TelefonoTrabajo
          },
          Visa = new Tramite.Responses.TramiteCompletoResponse.BeneficiarioResponse.VisaResponse
          {
            Id = tramite.Beneficiario.Visa.Id,
            ConfirmacionVisa = tramite.Beneficiario.Visa.ConfirmacionVisa,
            EstadoVisa = tramite.Beneficiario.Visa.EstadoVisa,
            FechaCaducidad = tramite.Beneficiario.Visa.FechaCaducidad,
            FechaConcesion = tramite.Beneficiario.Visa.FechaConcesion,
            IdActoConsularVisa = tramite.Beneficiario.Visa.IdActoConsularVisa,
            IdCentroAdministrativo = tramite.Beneficiario.Visa.IdCentroAdministrativo,
            IdPersona = tramite.Beneficiario.Visa.IdPersona,
            IdTramite = tramite.Beneficiario.Visa.IdTramite,
            NombreActoConsularVisa = tramite.Beneficiario.Visa.NombreActoConsularVisa,
            NombreCentroAdministrativo = tramite.Beneficiario.Visa.NombreCentroAdministrativo,
            Nombres = tramite.Beneficiario.Visa.Nombres,
            NumeroPasaporte = tramite.Beneficiario.Visa.NumeroPasaporte,
            NumeroVisa = tramite.Beneficiario.Visa.NumeroVisa,
            PoseeVisa = tramite.Beneficiario.Visa.PoseeVisa,
            PrimerApellido = tramite.Beneficiario.Visa.PrimerApellido,
            SegundoApellido = tramite.Beneficiario.Visa.SegundoApellido
          }


        }
      };
      foreach (var item in tramite.Movimientos)
      {
        tramiteCompleto.Movimientos.Add(
          new Tramite.Responses.TramiteCompletoResponse.MovimientoResponse
          {
            Id = item.Id,
            NombreEstado = item.NombreEstado,
            DiasTranscurridos = item.DiasTranscurridos,
            Estado = item.Estado,
            FechaHoraCita = item.FechaHoraCita,
            NombreRol = item.NombreRol,
            ObservacionDatosPersonales = item.ObservacionDatosPersonales,
            ObservacionDomicilios = item.ObservacionDomicilios,
            Orden = item.Orden,
            ObservacionMovimientoMigratorio = item.ObservacionMovimientoMigratorio,
            ObservacionMultas = item.ObservacionMultas,
            ObservacionSoportesGestion = item.ObservacionSoportesGestion,
            TramiteId = item.TramiteId,
            UsuarioId = item.UsuarioId,
            UnidadAdministrativaId = item.UnidadAdministrativaId,
            Vigente = item.Vigente
          }
          );
      }
      foreach (var item in tramite.SoporteGestiones)
      {
        tramiteCompleto.SoporteGestiones.Add(new Tramite.Responses.TramiteCompletoResponse.SoporteGestionResponse
        {
          Id = item.Id,
          Descripcion = item.Descripcion,
          Nombre = item.Nombre,
          Ruta = item.Ruta,
          TramiteId = item.TramiteId
        });
      }
      foreach (var item in tramite.Documentos)
      {
        tramiteCompleto.Documentos.Add(new Tramite.Responses.TramiteCompletoResponse.DocumentoResponse
        {
          Id = item.Id,
          EstadoProceso = item.EstadoProceso,
          DescripcionDocumento = item.DescripcionDocumento,
          Observacion = item.Observacion,
          Ruta = item.Ruta,
          Nombre = item.Nombre,
          IconoNombre = item.IconoNombre,
          TramiteId = item.TramiteId,
          ImagenNombre = item.ImagenNombre,
          TipoDocumento = item.TipoDocumento,
          TipoDocumentoDescripcion = ObtenerDescripcion(item.TipoDocumento)
        });
      }

      return tramiteCompleto;
    }

  }

  public class ResultadoConversion
  {
    public byte[] Resultado { get; set; }

    public string Mensaje { get; set; }

  }
}
