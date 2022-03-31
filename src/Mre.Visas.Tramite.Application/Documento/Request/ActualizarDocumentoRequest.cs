using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mre.Visas.Tramite.Application.Documento.Request
{
  public class ActualizarDocumentoRequest
  {

    public List<Documento> Documentos { get; set; }

    public class Documento
    {
      /// <summary>
      /// Numero de Orden como ingresa el proceso
      /// </summary>
      public Guid TramiteId { get; set; }

      /// <summary>
      /// codigo de Documento
      /// </summary>
      public Guid DocumentoId { get; set; }

      /// <summary>
      /// Usuario que va a gestionar el tramite 
      /// Ejemplo puede ser Consultor, Funcionario, Perito, otros
      /// </summary>
      public string Descripcion { get; set; }
    }
  }
}
