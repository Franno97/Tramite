using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mre.Visas.Tramite.Application.Shared
{
    public class AsuntosMigratoriosServicioConfiguracion
    {
        /// <summary>
        /// URL del servicio a consumir
        /// </summary>
        public string Url { get; set; }

        /// <summary>
        /// Nombre del usuario del web service, se envia dentro de parametro de la peticion
        /// </summary>
        public string Usuario { get; set; }

        /// <summary>
        /// Clave del usuario del web service, se envia dentro de parametro de la peticion
        /// </summary>
        public string Clave { get; set; }

    }
}
