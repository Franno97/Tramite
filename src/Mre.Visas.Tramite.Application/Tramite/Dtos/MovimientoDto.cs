using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mre.Visas.Tramite.Application.Tramite.Dtos
{
  public class MovimientoDto
  {
    /// <summary>
    /// Id de la unidad Organizativa
    /// </summary>
    public Guid UnidadAdministrativaId { get; set; }

    /// <summary>
    /// El nombre de la unidad Organizativa
    /// </summary>
    public string UnidadAdministrativaNombre { get; set; }

    /// <summary>
    /// Usuario que va a gestionar el tramite 
    /// Ejemplo puede ser Consultor, Funcionario, Perito, otros
    /// </summary>
    public Guid UsuarioId { get; set; }

    /// <summary>
    /// Nombre del rol
    /// </summary>
    public string NombreRol { get; set; }

  }
}
