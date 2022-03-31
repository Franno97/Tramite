using Mre.Visas.Tramite.Application.Tramite.Dtos;
using System;
using System.Collections.Generic;

namespace Mre.Visas.Tramite.Application.Tramite.Requests
{
  public class CrearTramiteRequest
  {
    /// <summary>
    /// Calidad migratoria
    /// </summary>
    public Guid CalidadMigratoriaId { get; set; }

    /// <summary>
    /// Grupo al que pertenece
    /// </summary>
    public Guid TipoConvenioId { get; set; }

    /// <summary>
    /// Tipo de visa
    /// </summary>
    public Guid TipoVisaId { get; set; }

    /// <summary>
    /// Actividad
    /// </summary>
    public Guid ActividadId { get; set; }

    /// <summary>
    /// Datos del Beneficiario
    /// </summary>
    public BeneficiarioDto Beneficiario { get; set; }

    /// <summary>
    /// Datos del documentos o requisitos
    /// </summary>
    public List<DocumentoDto> Documentos { get; set; }

    /// <summary>
    /// Datos del solicitante
    /// </summary>
    public SolicitanteDto Solicitante { get; set; }

    /// <summary>
    /// Usuario asignado
    /// </summary>
    public Guid UsuarioId { get; set; }
    
    /// <summary>
    /// La unidad administrativa
    /// </summary>
    public Guid UnidadAdministrativaIdCEV { get; set; }

    /// <summary>
    /// Servicio Id Visa virte u otro
    /// </summary>
    public Guid ServicioId { get; set; }
    /// <summary>
    /// Persona Id (a quien beneficia la visa)
    /// </summary>
    public Guid PersonaId { get; set; }
    /// <summary>
    /// Codigo del pais
    /// </summary>
    public string CodigoPais { get; set; }

    /// <summary>
    /// Observacion ingresada por el cuidadano al momento de crear el trámite
    /// </summary>
    public string Observacion { get; set; }
  }
}