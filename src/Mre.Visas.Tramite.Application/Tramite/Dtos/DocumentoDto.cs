using System;

namespace Mre.Visas.Tramite.Application.Tramite.Dtos
{
  public class DocumentoDto
  {
    public string Nombre { get; set; }

    public string Ruta { get; set; }

    public string Observacion { get; set; }

    public string TipoDocumento { get; set; }

    public string IconoNombre { get; set; }

    public string ImagenNombre { get; set; }

    public string DescripcionDocumento { get; set; }

  }

  public class DocumentoDtoSubsanacion
  {
    public Guid Id { get; set; }
    
    public string Nombre { get; set; }

    public string Ruta { get; set; }

    public string Observacion { get; set; }

    public string TipoDocumento { get; set; }

    public string IconoNombre { get; set; }

    public string ImagenNombre { get; set; }

    public string DescripcionDocumento { get; set; }
  }
}