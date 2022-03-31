using FluentValidation;
using MediatR;
using Microsoft.Extensions.Options;
using Mre.Visas.Tramite.Application.Shared.Handlers;
using Mre.Visas.Tramite.Application.Shared.Interfaces;
using Mre.Visas.Tramite.Application.Shared.Responses;
using Mre.Visas.Tramite.Application.Shared.Security;
using Mre.Visas.Tramite.Application.Shared.Wrappers;
using Mre.Visas.Tramite.Application.Tramite.Requests;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace Mre.Visas.Tramite.Application.Tramite.Queries
{
  public class ConsultarTramitePorFiltrosQuery : ConsultarTramitePorRolFiltrosRequest, IRequest<ApiResponseWrapper>
  {
    public ConsultarTramitePorFiltrosQuery(ConsultarTramitePorRolFiltrosRequest request)
    {
      NombreRol = request.NombreRol;
      UsuarioId = request.UsuarioId;
      NumeroRegistros = request.NumeroRegistros;
      PaginaActual = request.PaginaActual;
      OrdenColumna = request.OrdenColumna;
      OrdenForma = request.OrdenForma;
      Filtro = request.Filtro;
    }

    public class ConsultarTramitePorRolIdQueryHandler : BaseHandler, IRequestHandler<ConsultarTramitePorFiltrosQuery, ApiResponseWrapper>
    {
      public ConsultarTramitePorRolIdQueryHandler(IUnitOfWork unitOfWork, IHttpApiAutentificacion httpApiAutentificacion, IOptions<RemoteServices> remoteServices)
          : base(unitOfWork)
      {
        HttpApiAutentificacion = httpApiAutentificacion;
        this.remoteServices = remoteServices.Value;
      }

      public IHttpApiAutentificacion HttpApiAutentificacion { get; }
      private readonly RemoteServices remoteServices;

      public async Task<ApiResponseWrapper> Handle(ConsultarTramitePorFiltrosQuery query, CancellationToken cancellationToken)
      {
        try
        {
          string token = await HttpApiAutentificacion.GetAccessTokenAsync();
          if (string.IsNullOrEmpty(token))
          {
            return new ApiResponseWrapper(HttpStatusCode.Unauthorized, "El usuario no esta autenticado");
          }

          Guid unidadAdministrativaId = new Guid();
          if (query.NombreRol.Equals(Enum.GetName(typeof(Domain.Enums.FiltroRol.Rol), Domain.Enums.FiltroRol.Rol.Funcionario)) || query.NombreRol.Equals(Enum.GetName(typeof(Domain.Enums.FiltroRol.Rol), Domain.Enums.FiltroRol.Rol.Perito)))
          {
            #region Obtener Unidad Administrativa Zonal
            HttpClient Client;
            String Uri = string.Empty;
            string PlacesJson = string.Empty;
            HttpResponseMessage Response;
            Client = new HttpClient();
            Uri = remoteServices.unidadAdministrativa.BaseUrl + "api/unidad-administrativa/unidad-administrativa-funcional?usuarioId=" + query.UsuarioId + "";
            Client.DefaultRequestHeaders.Add("Authorization", "Bearer " + token);
            Response = await Client.GetAsync(Uri);
            if (Response.IsSuccessStatusCode)
            {
              PlacesJson = Response.Content.ReadAsStringAsync().Result;
              if (PlacesJson.Length > 0)
              {
                var datos = JsonConvert.DeserializeObject<Application.Tramite.Responses.UnidadAdministrativaResponse>(PlacesJson);
                unidadAdministrativaId = datos.id;
              }
              else
              {
                BasePager<Tramite.Responses.TramiteCompletoResponse> PaginacionTramites2;
                PaginacionTramites2 = new BasePager<Tramite.Responses.TramiteCompletoResponse>()
                {
                  RegistrosPorPagina = query.NumeroRegistros,
                  TotalRegistros = 0,
                  TotalPaginas = 0,
                  PaginaActual = query.PaginaActual,
                  BusquedaActual = query.Filtro,
                  OrdenActual = query.OrdenColumna,
                  TipoOrdenActual = query.OrdenForma,
                  Resultado = null
                };

                var response2 = new ApiResponseWrapper(HttpStatusCode.NotFound, PaginacionTramites2);
                return response2;
              }
            }
            else
            {
              return new ApiResponseWrapper(HttpStatusCode.BadRequest, "Error no autorizado ");
            }
            
            #endregion
          }
          var tramites1 = await UnitOfWork.TramiteRepository.GetByRolFiltros(query.NombreRol.ToString(), query.UsuarioId, unidadAdministrativaId, string.Empty);
          var tramiteCompletoResponse = new List<Tramite.Responses.TramiteCompletoResponse>();
          foreach (var item in tramites1)
          {
            tramiteCompletoResponse.Add(Shared.Util.Util.MapearTramite(item));
          }

          //aplicar paginador y orden
          BasePager<Tramite.Responses.TramiteCompletoResponse> PaginacionTramites;

          ////////////////////////
          // FILTRO DE BÚSQUEDA //
          ////////////////////////

          // Filtramos el resultado por el 'texto de búqueda'
          if (!string.IsNullOrEmpty(query.Filtro))
          {
            foreach (var item in query.Filtro.Split(new char[] { ' ' },
                     StringSplitOptions.RemoveEmptyEntries))
            {
              tramiteCompletoResponse = tramiteCompletoResponse.Where(x => x.Beneficiario.Nombres.Contains(item) ||
                                            x.Solicitante.Nombres.Contains(item) ||
                                            x.Numero.Contains(item) ||
                                            x.Fecha.Contains(item))
                                            .ToList();
            }
          }

          /////////////////////////////
          // ORDENACIÓN POR COLUMNAS //
          /////////////////////////////
          switch (query.OrdenColumna)
          {
            case "Beneficiario":
              if (query.OrdenForma.ToLower() == "desc")
                tramiteCompletoResponse = tramiteCompletoResponse.OrderByDescending(x => x.Beneficiario.Nombres).ToList();
              else if (query.OrdenForma.ToLower() == "asc")
                tramiteCompletoResponse = tramiteCompletoResponse.OrderBy(x => x.Beneficiario.Nombres).ToList();
              break;

            case "Solicitante":
              if (query.OrdenForma.ToLower() == "desc")
                tramiteCompletoResponse = tramiteCompletoResponse.OrderByDescending(x => x.Solicitante.Nombres).ToList();
              else if (query.OrdenForma.ToLower() == "asc")
                tramiteCompletoResponse = tramiteCompletoResponse.OrderBy(x => x.Solicitante.Nombres).ToList();
              break;

            case "Numero":
              if (query.OrdenForma.ToLower() == "desc")
                tramiteCompletoResponse = tramiteCompletoResponse.OrderByDescending(x => x.Numero).ToList();
              else if (query.OrdenForma.ToLower() == "asc")
                tramiteCompletoResponse = tramiteCompletoResponse.OrderBy(x => x.Numero).ToList();
              break;

            case "Fecha":
              if (query.OrdenForma.ToLower() == "desc")
                tramiteCompletoResponse = tramiteCompletoResponse.OrderByDescending(x => x.Fecha).ToList();
              else if (query.OrdenForma.ToLower() == "asc")
                tramiteCompletoResponse = tramiteCompletoResponse.OrderBy(x => x.Fecha).ToList();
              break;

              // ...
              // Aquí el resto de los campos de la tabla por los que ordenar.
              // ...

              //default:
              //  if (query.OrdenForma.ToLower() == "desc")
              //    tramites = tramites.OrderByDescending(x => x.CustomerID).ToList();
              //  else if (query.OrdenForma.ToLower() == "asc")
              //    tramites = tramites.OrderBy(x => x.CustomerID).ToList();
              //  break;
          }

          ///////////////////////////
          // SISTEMA DE PAGINACIÓN //
          ///////////////////////////
          int _TotalRegistros = 0;
          int _TotalPaginas = 0;
          // Número total de registros de la tabla Customers
          _TotalRegistros = tramiteCompletoResponse.Count();
          // Obtenemos la 'página de registros' de la tabla Customers
          tramiteCompletoResponse = tramiteCompletoResponse.Skip((query.PaginaActual - 1) * query.NumeroRegistros)
                                           .Take(query.NumeroRegistros)
                                           .ToList();
          // Número total de páginas de la tabla Customers
          _TotalPaginas = (int)Math.Ceiling((double)_TotalRegistros / query.NumeroRegistros);

          // Instanciamos la 'Clase de paginación' y asignamos los nuevos valores
          PaginacionTramites = new BasePager<Tramite.Responses.TramiteCompletoResponse>()
          {
            RegistrosPorPagina = query.NumeroRegistros,
            TotalRegistros = _TotalRegistros,
            TotalPaginas = _TotalPaginas,
            PaginaActual = query.PaginaActual,
            BusquedaActual = query.Filtro,
            OrdenActual = query.OrdenColumna,
            TipoOrdenActual = query.OrdenForma,
            Resultado = tramiteCompletoResponse
          };


          var response = new ApiResponseWrapper(HttpStatusCode.OK, PaginacionTramites);

          return response;

        }
        catch (Exception ex)
        {
          return new ApiResponseWrapper(HttpStatusCode.BadRequest, ex.Message + Environment.NewLine + ex.StackTrace);
        }

      }
    }
  }

  public class ConsultarTramitePorRolIdQueryValidator : AbstractValidator<ConsultarTramitePorFiltrosQuery>
  {
    public ConsultarTramitePorRolIdQueryValidator()
    {
      RuleFor(e => e.NombreRol)
          .IsEnumName(typeof(Domain.Enums.FiltroRol.Rol)).WithMessage("{PropertyName} Solo puede aplicar estos Roles (Funcionario, Consultor, Ciudadano, Perito).");

      RuleFor(e => e.UsuarioId)
          .NotEmpty().WithMessage("{PropertyName} es requerido.")
          .NotNull().WithMessage("{PropertyName} no puede ser nulo.");

      RuleFor(e => e.NumeroRegistros)
          .NotEmpty().WithMessage("{PropertyName} es requerido.")
          .NotNull().WithMessage("{PropertyName} no puede ser nulo.");

      RuleFor(e => e.PaginaActual)
          .NotEmpty().WithMessage("{PropertyName} es requerido.")
          .NotNull().WithMessage("{PropertyName} no puede ser nulo.");

    }
  }
}