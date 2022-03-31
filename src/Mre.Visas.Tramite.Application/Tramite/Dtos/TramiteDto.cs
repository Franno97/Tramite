using System;

namespace Mre.Visas.Tramite.Application.Tramite.Dtos
{
  public class TramiteBaseDto
  {
    public string Numero { get; set; }
    public DateTime FechaMovimiento { get; set; }
    public string Solicitante { get; set; }
    public string Beneficiario { get; set; }
    public Guid ServicioId { get; set; }
    public Guid TramiteId { get; set; }
    public Guid MovimientoId { get; set; }
    public Guid UsuarioId { get; set; }
    public Guid UnidadAdministrativaId { get; set; }
    public string NombreRol { get; set; }
    public string NombreEstado { get; set; }
  }
}
