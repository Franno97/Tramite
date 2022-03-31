using AutoMapper.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mre.Visas.Tramite.Application.Movimiento.Request
{
  public class CrearMovimientoRequest
  {
    /// <summary>
    /// Numero de Orden como ingresa el proceso
    /// </summary
    public Guid TramiteId { get; set; }

    /// <summary>
    /// El estado origen o actal del flujo
    /// </summary>
    public int? EstadoOrigen
    {
      get { return _estadoOrigen; }
      set { if (value == null) _estadoOrigen = 0; else _estadoOrigen = value.Value; }
    }
    /// <summary>
    /// El estado del flujo de proceso siguiente
    /// </summary>
    public int Estado { get; set; }

    /// <summary>
    /// Observaciones del tabx
    /// </summary>
    public string ObservacionDatosPersonales { get; set; }
    /// <summary>
    /// Observaciones del tab
    /// </summary>
    public string ObservacionSoportesGestion { get; set; }
    /// <summary>
    /// Observaciones del tab
    /// </summary>
    public string ObservacionDomicilios { get; set; }
    /// <summary>
    /// Observaciones del tab
    /// </summary>
    public string ObservacionMovimientoMigratorio { get; set; }
    /// <summary>
    /// Observaciones del tab
    /// </summary>
    public string ObservacionMultas { get; set; }

    /// <summary>
    /// Formato de fecha desde para la cita ejemplo 2022-10-10 10:00:00
    /// </summary>
    public DateTime? FechaHoraCita { get; set; }

    /// <summary>
    /// Usuario que esta creando
    /// </summary>
    public Guid CreatorId { get; set; }

    private int _estadoOrigen;

  }
}

