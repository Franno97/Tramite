using Microsoft.EntityFrameworkCore;
using Mre.Visas.Tramite.Application.Tramite.Dtos;
using Mre.Visas.Tramite.Application.Tramite.Repositories;
using Mre.Visas.Tramite.Infrastructure.Persistence.Contexts;
using Mre.Visas.Tramite.Infrastructure.Shared.Repositories;
using Mre.Visas.Tramite.Infrastructure.Movimiento.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Transactions;

namespace Mre.Visas.Tramite.Infrastructure.Tramite.Repositories
{
  public class TramiteRepository : Repository<Domain.Entities.Tramite>, ITramiteRepository
  {
    #region Constructors

    public TramiteRepository(ApplicationDbContext context)
        : base(context)
    {
    }

    #endregion Constructors

    #region Metodos Others 
    public async Task<List<Domain.Entities.Tramite>> GetByCiudadanoId(string usuarioId)
    {
      var resutado = new List<Domain.Entities.Tramite>();
      resutado = await _context.Tramites
        .Include(x => x.Solicitante)
        .Include(x => x.Beneficiario).ThenInclude(x => x.Domicilio)
        .Include(x => x.Beneficiario).ThenInclude(x => x.Pasaporte)
        .Include(x => x.Beneficiario).ThenInclude(x => x.Visa)
        .Include(x => x.SoporteGestiones)
        .Include(x => x.Movimientos)
        .Include(x => x.Documentos)
        .Where(x => x.CreatorId.ToString() == usuarioId && !x.IsDeleted).ToListAsync();

      if (resutado != null)
      {
        foreach (var item in resutado)
        {
          item.Beneficiario.Edad = DateTime.Now.Year - item.Beneficiario.FechaNacimiento.Year;
          item.Movimientos = item.Movimientos.OrderBy(r => r.Orden).ToList();
        }
      }

      return resutado;
    }
    public async Task<Domain.Entities.Tramite> GetByIdTramiteCompleto(Guid TramiteId)
    {

      var resutado = new Domain.Entities.Tramite();
      resutado = await _context.Tramites
        .Include(x => x.Solicitante)
        .Include(x => x.Beneficiario).ThenInclude(x => x.Domicilio)
        .Include(x => x.Beneficiario).ThenInclude(x => x.Pasaporte)
        .Include(x => x.Beneficiario).ThenInclude(x => x.Visa)
        .Include(x => x.SoporteGestiones)
        .Include(x => x.Movimientos)
        .Include(x => x.Documentos)
        .Where(x => x.Id.ToString() == TramiteId.ToString()).FirstOrDefaultAsync();

      resutado.Beneficiario.Edad = DateTime.Now.Year - resutado.Beneficiario.FechaNacimiento.Year;

      resutado.Movimientos = resutado.Movimientos.OrderBy(r => r.Orden).ToList();
      return resutado;
    }

    public async Task<List<Domain.Entities.Tramite>> GetByRolFiltros(string nombreRol, Guid usuarioId, Guid unidadAdministrativaId, string codigoEstado)
    {
      var resutado = new List<Domain.Entities.Tramite>();
      List<Domain.Entities.RolEstado> Estados = new List<Domain.Entities.RolEstado>();
      if (string.IsNullOrEmpty(codigoEstado))
        Estados = await _context.RolEstados.Where(x => x.NombreRol == nombreRol).ToListAsync();
      else
        Estados.Add(new Domain.Entities.RolEstado { CodigoEstado = codigoEstado });

      if (nombreRol.Equals(Enum.GetName(Domain.Enums.FiltroRol.Rol.Consultor)))
      {
        resutado = await _context.Tramites
        .Include(x => x.Solicitante)
        .Include(x => x.Beneficiario).ThenInclude(x => x.Domicilio)
        .Include(x => x.Beneficiario).ThenInclude(x => x.Pasaporte)
        .Include(x => x.Beneficiario).ThenInclude(x => x.Visa)
        .Include(x => x.SoporteGestiones)
        .Include(x => x.Movimientos)
        .Include(x => x.Documentos).
        Where(x => x.Movimientos.Any(y => y.Vigente.Equals(true)
                                  && y.UsuarioId.Equals(usuarioId)
                                  && Estados.Select(y => y.CodigoEstado.ToString()).Contains(y.Estado))
              && !x.IsDeleted).ToListAsync();

      }
      else if (nombreRol.Equals(Enum.GetName(Domain.Enums.FiltroRol.Rol.Perito)) || nombreRol.Equals(Enum.GetName(Domain.Enums.FiltroRol.Rol.Funcionario)))
      {
        resutado = await _context.Tramites
        .Include(x => x.Solicitante)
        .Include(x => x.Beneficiario).ThenInclude(x => x.Domicilio)
        .Include(x => x.Beneficiario).ThenInclude(x => x.Pasaporte)
        .Include(x => x.Beneficiario).ThenInclude(x => x.Visa)
        .Include(x => x.SoporteGestiones)
        .Include(x => x.Movimientos)
        .Include(x => x.Documentos).
        Where(x => x.Movimientos.Any(y => y.Vigente.Equals(true)
                                  && y.UnidadAdministrativaId.Equals(unidadAdministrativaId)
                                  && (y.UsuarioId.Equals(usuarioId) || y.UsuarioId.Equals(Guid.Empty))
                                  && Estados.Select(y => y.CodigoEstado.ToString()).Contains(y.Estado))
              && !x.IsDeleted).ToListAsync();
      }
      else
      {
        throw new ArgumentException("Rol 'Ciudadano' no permitido para consulta", "Original");
      }
      //filtros adicionales
      //if (Domain.Enums.FiltroTipo.Tipo.NombreBeneficiario.ToString().Equals(filtroTipo))
      //{
      //  resutado = resutado.Where(x => x.Beneficiario.Nombres.StartsWith(filtroTexto)).ToList();
      //}
      //else if (Domain.Enums.FiltroTipo.Tipo.NombreSolicitante.ToString().Equals(filtroTipo))
      //{
      //  resutado = resutado.Where(x => x.Solicitante.Nombres.StartsWith(filtroTexto)).ToList();
      //}
      //else if (Domain.Enums.FiltroTipo.Tipo.NumeroTramite.ToString().Equals(filtroTipo))
      //{
      //  resutado = resutado.Where(x => x.Fecha.StartsWith(filtroTexto)).ToList();
      //}
      //else if (Domain.Enums.FiltroTipo.Tipo.FechaEmision.ToString().Equals(filtroTipo))
      //{
      //  //formato de fecha culture yyyy-MM-dd
      //  resutado = resutado.Where(x => x.Fecha.Equals(filtroTexto)).ToList();
      //}
      resutado.ToList().ForEach(e => e.Movimientos = e.Movimientos.OrderBy(r => r.Orden).ToList());
      return resutado;
    }
    public async Task<string> GetNumeroTramite(string tipoTramite)
    {
      string Secuencial = string.Empty;
      try
      {
        string FechaControl = DateTime.Now.ToString("yyyy-MM-dd");

        var datos = await _context.Tramites.Where(x => x.Fecha.Equals(FechaControl) && x.TipoTramite.Equals(tipoTramite)).ToListAsync();
        if (datos.Count > 0)
        {
          int secuencial = datos.Count + 1;
          Secuencial = String.Format("{0}{1}{2}", tipoTramite, FechaControl.Replace("-", ""), (secuencial.ToString("D4")).ToString());
        }
        else
          Secuencial = String.Format("{0}{1}{2}", tipoTramite, FechaControl.Replace("-", ""), "0001");
      }
      catch (Exception ex)
      {
        Console.WriteLine(ex.Message);
      }
      return Secuencial;
    }

    public async Task<bool> GetByCodigoMDGTramiteVigente(string codigoMDG)
    {
      bool resultado = false;
      var tramite = new Domain.Entities.Tramite();

      tramite = await _context.Tramites
        .Include(x => x.Solicitante)
        .Include(x => x.Beneficiario).ThenInclude(x => x.Domicilio)
        .Include(x => x.Beneficiario).ThenInclude(x => x.Pasaporte)
        .Include(x => x.Beneficiario).ThenInclude(x => x.Visa)
        .Include(x => x.SoporteGestiones)
        .Include(x => x.Movimientos)
        .Include(x => x.Documentos)
        .Where(x => x.Beneficiario.CodigoMDG.Equals(codigoMDG)
              && x.Movimientos.Any(y => y.Vigente.Equals(true))).FirstOrDefaultAsync();

      if (tramite == null)
        resultado = false;
      else if (tramite.Id.Equals(Guid.Empty))
        resultado = false;
      else if (Convert.ToInt32(tramite.Movimientos.Where(x => x.Vigente.Equals(true)).FirstOrDefault().Estado) >= 90)
        resultado = false;
      else
        resultado = true;

      return resultado;


    }

    /// <summary>
    /// Método que devuelve los trámites asignados a un usuario
    /// </summary>
    /// <param name="servicioId">Id del Servicio</param>
    /// <param name="unidadAdministrativaId">Id de la unidad adminitrativa</param>
    /// <param name="usuarioId">Id del usuario</param>
    /// <returns></returns>
    public async Task<List<TramiteBaseDto>> GetTramitesBaseAsync(Guid servicioId, Guid unidadAdministrativaId, Guid usuarioId)
    {

      var resultado = await (from mov in _context.Movimientos
                             join tra in _context.Tramites on mov.TramiteId equals tra.Id
                             where !mov.IsDeleted && !tra.IsDeleted
                             && mov.Vigente
                             && tra.ServicioId == servicioId && mov.UnidadAdministrativaId == unidadAdministrativaId && mov.UsuarioId == usuarioId
                             && mov.NombreEstado != "Negado"
                             && mov.NombreEstado != "Desistido"
                             && mov.NombreEstado != "Terminado"
                             && mov.NombreRol != "Ciudadano"
                             select new TramiteBaseDto
                             {
                               Numero = tra.Numero,
                               FechaMovimiento = mov.Created,
                               Solicitante = tra.Solicitante.Nombres,
                               Beneficiario = $"{tra.Beneficiario.PrimerApellido} {tra.Beneficiario.SegundoApellido} {tra.Beneficiario.Nombres}",
                               ServicioId = tra.ServicioId,
                               TramiteId = tra.Id,
                               MovimientoId = mov.Id,
                               UsuarioId = mov.UsuarioId,
                               UnidadAdministrativaId = mov.UnidadAdministrativaId,
                               NombreRol = mov.NombreRol,
                               NombreEstado = mov.NombreEstado
                             }).ToListAsync();

      return resultado;

    }

    public List<Domain.Entities.Tramite> GetTramitesGeneral(string fechaDesde, string fechaHasta, string tipoTramite, string codigoEstado, Guid usuarioId, Guid unidadAdministrativaId)
    {
      var Desde = new DateTime(Convert.ToDateTime(fechaDesde).Year, Convert.ToDateTime(fechaDesde).Month, Convert.ToDateTime(fechaDesde).Day, 0, 0, 1);
      var Hasta = new DateTime(Convert.ToDateTime(fechaHasta).Year, Convert.ToDateTime(fechaHasta).Month, Convert.ToDateTime(fechaHasta).Day, 23, 59, 59);

      var resutado = new List<Domain.Entities.Tramite>();
      resutado = _context.Tramites
        .Include(x => x.Solicitante)
        .Include(x => x.Beneficiario).ThenInclude(x => x.Domicilio)
        .Include(x => x.Beneficiario).ThenInclude(x => x.Pasaporte)
        .Include(x => x.Beneficiario).ThenInclude(x => x.Visa)
        .Include(x => x.SoporteGestiones)
        .Include(x => x.Movimientos)
        .Include(x => x.Documentos)
        .Where(x => (x.Created >= Desde && x.Created <= Hasta)
        && x.TipoTramite == tipoTramite
        && x.Movimientos.Any(y => y.Vigente.Equals(true))
        && !x.IsDeleted).ToList();

      if (!codigoEstado.Equals(string.Empty))
        resutado = resutado.Where(x => x.Movimientos.Any(y => y.Vigente.Equals(true) && y.Estado.Equals(codigoEstado))).ToList();
      if (!usuarioId.Equals(Guid.Empty))
        resutado = resutado.Where(x => x.Movimientos.Any(y => y.Vigente.Equals(true) && y.UsuarioId.Equals(usuarioId))).ToList();
      if (!unidadAdministrativaId.Equals(Guid.Empty))
        resutado = resutado.Where(x => x.Movimientos.Any(y => y.Vigente.Equals(true) && y.UnidadAdministrativaId.Equals(unidadAdministrativaId))).ToList();

      if (resutado != null)
      {
        foreach (var item in resutado)
        {
          item.Beneficiario.Edad = DateTime.Now.Year - item.Beneficiario.FechaNacimiento.Year;
          item.Movimientos = item.Movimientos.OrderBy(r => r.Orden).ToList();
        }
      }

      return resutado;
    }
    #endregion
  }
}