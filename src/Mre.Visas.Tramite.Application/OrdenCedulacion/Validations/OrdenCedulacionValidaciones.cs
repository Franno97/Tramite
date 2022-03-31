using Microsoft.Extensions.Logging;
using Mre.Visas.Tramite.Application.OrdenCedulacion.Dtos;
using Mre.Visas.Tramite.Application.Shared.Wrappers;
using Mre.Visas.Tramite.Application.Tramite.Responses;
using Mre.Visas.Tramite.Domain.Const;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Mre.Visas.Tramite.Application.OrdenCedulacion.Validations
{
    public class OrdenCedulacionValidaciones<T>
    {
        private readonly ILogger<T> logger;

        public OrdenCedulacionValidaciones(ILogger<T> logger)
        {
            this.logger = logger;
        }

        public ApiResponseWrapper ValidarInformacionTramite(TramiteCompletoResponse tramite)
        {
            if (tramite.TipoTramite != OrdenCedulacionConsts.CodigoTipoTramiteOrdenCedulacion)
            {
                logger.LogError("{mensajeError}, tramiteId: {tramiteId}", TextosConsts.InformacionTramiteIncorrecta, tramite.Id);
                return new ApiResponseWrapper(HttpStatusCode.BadRequest, TextosConsts.InformacionTramiteIncorrecta);
            }

            if (!tramite.Movimientos.OrderBy(x => x.Orden).LastOrDefault().Estado.Equals(OrdenCedulacionConsts.EstadoGenerarOrden.ToString()))
            {
                logger.LogError("{mensajeError}, tramiteId: {tramiteId}", TextosConsts.InformacionTramiteIncorrecta, tramite.Id);
                return new ApiResponseWrapper(HttpStatusCode.BadRequest, TextosConsts.InformacionTramiteIncorrecta);
            }

            return new ApiResponseWrapper(HttpStatusCode.OK, string.Empty);
        }
    }
}
