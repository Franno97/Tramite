using Mre.Visas.Tramite.Domain.Entities;
using Mre.Visas.Tramite.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mre.Visas.Tramite.Application.Tramite.Responses
{
  public class TramiteCompletoResponse 
  {
    /// <summary>
    /// Id 
    /// </summary>
    public Guid Id { get; set; }
    /// <summary>
    /// Numero del tramite se compone de la fecha en formato yyyyMMdd-contador
    /// </summary>
    public string Numero { get; set; }

    /// <summary>
    /// Fecha del tramite
    /// </summary>
    public string Fecha { get; set; }

    /// <summary>
    /// Datos del Beneficiario
    /// </summary>
    public BeneficiarioResponse Beneficiario { get; set; }

    /// <summary>
    /// Id del Beneficiario
    /// </summary>
    public Guid BeneficiarioId { get; set; }

    /// <summary>
    /// Los documentos adjuntos
    /// </summary>
    public List<DocumentoResponse> Documentos { get; set; }

    /// <summary>
    /// Calidad migratoria
    /// </summary>
    public Guid CalidadMigratoriaId { get; set; }

    /// <summary>
    /// Datos del grupo que pertenece
    /// </summary>
    public Guid TipoConvenioId { get; set; }

    /// <summary>
    /// Tipo de visas
    /// </summary>
    public Guid TipoVisaId { get; set; }

    /// <summary>
    /// Nombre d la actividad
    /// </summary>
    public Guid ActividadId { get; set; }

    /// <summary>
    /// Datos del solciitante
    /// </summary>
    public SolicitanteResponse Solicitante { get; set; }

    /// <summary>
    /// Id del solicitante
    /// </summary>
    public Guid SolicitanteId { get; set; }

    /// <summary>
    /// Unidad Administrativa entro de Emision de Visas
    /// </summary>
    public Guid UnidadAdministrativaIdCEV { get; set; }

    /// <summary>
    /// Unidad Administrativa de la Zonal
    /// </summary>
    public Guid UnidadAdministrativaIdZonal { get; set; }

    /// <summary>
    /// Los documentos adjuntos
    /// </summary>
    public List<SoporteGestionResponse> SoporteGestiones { get; set; }

    /// <summary>
    /// Los documentos adjuntos
    /// </summary>
    public List<MovimientoResponse> Movimientos { get; set; }

    /// <summary>
    /// Servicio Id
    /// </summary>
    public Guid ServicioId { get; set; }

    /// <summary>
    /// Codigo de Pais
    /// </summary>
    public string CodigoPais { get; set; }

    /// <summary>
    /// Persona Id
    /// </summary>
    public Guid PersonaId { get; set; }

    /// <summary>
    /// Persona Id
    /// </summary>
    public Guid OrigenId { get; set; }

    /// <summary>
    /// Fecha del tramite
    /// </summary>
    public string TipoTramite { get; set; }

    public class BeneficiarioResponse 
    {
      public BeneficiarioResponse()
      {
        Domicilio = new DomicilioResponse();
        Pasaporte = new PasaporteResponse();
        Visa = new  VisaResponse();
      }
      /// <summary>
      /// Id 
      /// </summary>
      public Guid Id { get; set; }

      public TipoCiudadano.TipoCiudadanoEnum TipoCiudadano { get; set; }

      public string CiudadNacimiento { get; set; }

      public string CodigoMDG { get; set; }

      public string Correo { get; set; }

      public DomicilioResponse Domicilio { get; set; }

      public Guid DomicilioId { get; set; }

      public int Edad { get; set; }

      public string EstadoCivil { get; set; }

      public DateTime FechaNacimiento { get; set; }

      public string Foto { get; set; }

      public string Genero { get; set; }

      public string Ocupacion { get; set; }

      public string NacionalidadId { get; set; }

      public string Nacionalidad { get; set; }

      public string Nombres { get; set; }

      public string PaisNacimiento { get; set; }

      public PasaporteResponse Pasaporte { get; set; }

      public Guid PasaporteId { get; set; }

      public bool PoseeDiscapacidad { get; set; }

      public int PorcentajeDiscapacidad { get; set; }

      public string CarnetConadis { get; set; }

      public DateTime FechaEmisionConadis { get; set; }

      public DateTime FechaCaducidadConadis { get; set; }

      public string PrimerApellido { get; set; }

      public string SegundoApellido { get; set; }

      public VisaResponse Visa { get; set; }

      public Guid VisaId { get; set; }

      public class DomicilioResponse
      {
        /// <summary>
        /// Id 
        /// </summary>
        public Guid Id { get; set; }
        public string Ciudad { get; set; }

        public string Direccion { get; set; }

        public string Pais { get; set; }

        public string Provincia { get; set; }

        public string TelefonoCelular { get; set; }

        public string TelefonoDomicilio { get; set; }

        public string TelefonoTrabajo { get; set; }
      }
      public class PasaporteResponse
      {
        /// <summary>
        /// Id 
        /// </summary>
        public Guid Id { get; set; }
        public string CiudadEmision { get; set; }

        public DateTime FechaEmision { get; set; }

        public DateTime FechaExpiracion { get; set; }

        public DateTime FechaNacimiento { get; set; }

        public string Nombres { get; set; }

        public string Numero { get; set; }

        public string PaisEmision { get; set; }

        public string TipoDocumentoIdentidadId { get; set; }
      }
      public class VisaResponse 
      {
        /// <summary>
        /// Id 
        /// </summary>
        public Guid Id { get; set; }
        public bool PoseeVisa { get; set; }
        public bool ConfirmacionVisa { get; set; }
        public string EstadoVisa { get; set; }//>ACTIVA</a:EstadoVisa>
        public DateTime FechaCaducidad { get; set; }//>2022-03-12</a:FechaCaducidad>
        public DateTime FechaConcesion { get; set; }//>2020-03-12</a:FechaConcesion>
        public string IdActoConsularVisa { get; set; }//>2751</a:IdActoConsularVisa>
        public string IdCentroAdministrativo { get; set; }//>9237</a:IdCentroAdministrativo>
        public string IdPersona { get; set; }//>3841021</a:IdPersona>
        public string IdTramite { get; set; }//>6751048</a:IdTramite>
        public string NombreActoConsularVisa { get; set; }//>RESIDENTE TEMPORAL - EXCEPCIÓN POR AUTORIDAD DE M.H. - RAZONES HUMANITARIAS - ECUADOR</a:NombreActoConsularVisa>
        public string NombreCentroAdministrativo { get; set; }//>UNIDAD DE VISADO HUMANITARIO</a:NombreCentroAdministrativo>
        public string Nombres { get; set; }//>JOHANNA LISBETH</a:Nombres>
        public string NumeroPasaporte { get; set; }///>
        public string NumeroVisa { get; set; }//>WB8PNBUW</a:NumeroVisa>
        public string PrimerApellido { get; set; }//>HERRERA</a:PrimerApellido>
        public string SegundoApellido { get; set; }//>TORREALBA</a:SegundoApellido>

      }
    }
    public class DocumentoResponse 
    {
      /// <summary>
      /// Id 
      /// </summary>
      public Guid Id { get; set; }
      /// <summary>
      /// Id
      /// </summary>
      public Guid TramiteId { get; set; }

      public Domain.Entities.Tramite Tramite { get; set; }

      /// <summary>
      /// Nombre del archivo
      /// </summary>
      public string Nombre { get; set; }

      /// <summary>
      /// Ruta del documentoa almancenado el sharepoint
      /// </summary>
      public string Ruta { get; set; }

      /// <summary>
      /// Observacion del documento
      /// </summary>
      public string Observacion { get; set; }

      /// <summary>
      /// Campo para el Tipo de Documento
      /// </summary>
      public string TipoDocumento { get; set; }

      /// <summary>
      /// IconoNombre
      /// </summary>
      public string IconoNombre { get; set; }

      /// <summary>
      /// ImagenNombre
      /// </summary>
      public string ImagenNombre { get; set; }

      /// <summary>
      /// DescripcionDocumento
      /// </summary>
      public string DescripcionDocumento { get; set; }

      /// <summary>
      /// Estado del proceso cuando pasa por datacap
      /// </summary>
      public string EstadoProceso { get; set; }
      
      /// <summary>
      /// Campo para el Tipo de Documento
      /// </summary>
      public string TipoDocumentoDescripcion { get; set; }

    }
    public class SolicitanteResponse 
    {
      /// <summary>
      /// Id 
      /// </summary>
      public Guid Id { get; set; }
      public string Identificacion { get; set; }
      public string TipoIdentificacion { get; set; }

      public string Ciudad { get; set; }

      public string ConsuladoNombre { get; set; }

      public string ConsuladoPais { get; set; }

      public string Direccion { get; set; }

      public int Edad { get; set; }

      public string Nacionalidad { get; set; }

      public string Nombres { get; set; }

      public string Pais { get; set; }

      public string Telefono { get; set; }

      public string Correo { get; set; }
    }
    public class MovimientoResponse 
    {
      /// <summary>
      /// Id 
      /// </summary>
      public Guid Id { get; set; }
      /// <summary>
      /// Tramite Id 
      /// </summary>
      public Guid TramiteId { get; set; }

      public Domain.Entities.Tramite Tramite { get; set; }

      /// <summary>
      /// Numero de Orden como ingresa el proceso
      /// </summary>
      public int Orden { get; set; }

      /// <summary>
      /// Usuario que va a gestionar el tramite
      /// Ejemplo puede ser Consultor, Funcionario, Perito, otros
      /// </summary>
      public Guid UsuarioId { get; set; }

      /// <summary>
      /// El estado del flujo de proceso
      /// </summary>
      public string Estado { get; set; }

      /// <summary>
      /// El nombre estado del flujo de proceso
      /// </summary>
      public string NombreEstado { get; set; }

      /// <summary>
      /// Vigente se considera al ultimo como True y los anteres al orden como False
      /// </summary>
      public bool Vigente { get; set; }

      /// <summary>
      /// Nombre del rol del usuario en ese momento
      /// </summary>
      public string NombreRol { get; set; }

      /// <summary>
      /// Unidad Administrativa de la Zonal
      /// </summary>
      public Guid UnidadAdministrativaId { get; set; }

      /// <summary>
      /// observacion del tramite
      /// </summary>
      public string ObservacionDatosPersonales { get; set; }

      /// <summary>
      /// Observaciones de beneficiarios
      /// </summary>
      public string ObservacionDomicilios { get; set; }

      /// <summary>
      /// Observaciones de soportes de gestion
      /// </summary>
      public string ObservacionSoportesGestion { get; set; }

      /// <summary>
      /// Las observaciones al tab de movimientos migratorios
      /// </summary>
      public string ObservacionMovimientoMigratorio { get; set; }

      /// <summary>
      /// La observacion del tab de multas
      /// </summary>
      public string ObservacionMultas { get; set; }

      /// <summary>
      /// Este campo solo aplica para los movimientos de ciudadano
      /// </summary>
      public int DiasTranscurridos { get; set; }

      /// <summary>
      /// Formato de fecha desde para la cita ejemplo 2022-10-10 10:00:00
      /// </summary>
      public DateTime? FechaHoraCita { get; set; }

    }
    public class SoporteGestionResponse 
    {
      /// <summary>
      /// Id 
      /// </summary>
      public Guid Id { get; set; }
      /// <summary>
      /// Id de tramite
      /// </summary>
      public Guid TramiteId { get; set; }

      public Domain.Entities.Tramite Tramite { get; set; }

      /// <summary>
      /// Nombre del archivo con extension
      /// </summary>
      public string Nombre { get; set; }

      /// <summary>
      /// Descripción del documento que se está adjuntando
      /// </summary>
      public string Descripcion { get; set; }

      /// <summary>
      /// Ruta del archivo de sharepoint
      /// </summary>
      public string Ruta { get; set; }
    }


    public TramiteCompletoResponse()
    {
      Beneficiario = new BeneficiarioResponse();
      Solicitante = new SolicitanteResponse();
      Documentos = new List<DocumentoResponse>();
      SoporteGestiones = new List<SoporteGestionResponse>();
      Movimientos = new List<MovimientoResponse>();
    }

  }
}
