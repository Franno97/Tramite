using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mre.Visas.Tramite.Application.Documento.Request
{
  public class CrearDocumentoRequest
  {
    public Guid TramiteId { get; set; }
    public Guid CreatedId { get; set; }
    public List<DocumentoRequest> Documentos { get; set; }
    public class DocumentoRequest
    {
      /// <summary>
      /// Nombre del archivo
      /// </summary>
      public string Nombre { get; set; }

      /// <summary>
      /// Observacion del documento
      /// </summary>
      public string Observacion { get; set; }

      /// <summary>
      /// Campo para el Tipo de Documento
      /// </summary>
      public string TipoDocumento { get; set; }

    }
  }
}
