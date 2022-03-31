using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mre.Visas.Tramite.Application.OrdenCedulacion.Dtos
{
    public class SignatarioDto
    {
        public Guid UsuarioId { get; set; }

        public string Nombre { get; set; }

        public string Apellido { get; set; }

        public string Cargo { get; set; }

        public string Ciudad { get; set; }

    }

}
