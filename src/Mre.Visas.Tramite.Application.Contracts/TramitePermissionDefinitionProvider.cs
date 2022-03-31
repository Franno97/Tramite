using Mre.Sb.Permiso;
using System;
using System.Collections.Generic;

namespace Mre.Visas.Tramite.Application.Contracts
{
  public class TramitePermissionDefinitionProvider : PermisoDefinicionProveedor
  {
    public override ICollection<PermisoDefinicionGrupo> Obtener()
    {
      var lista = new List<PermisoDefinicionGrupo>();

      var grupoModulo = new PermisoDefinicionGrupo();
      grupoModulo.Nombre = "Tramite";
      grupoModulo.Texto = "Tramites";//opcional del front

      lista.Add(grupoModulo);

      var permisoFuncionalidad = new PermisoDefinicion(TramitePermissionDefinition.GrupoTramite, TramitePermissionDefinition.Tramite);
      permisoFuncionalidad.Hijos.Add(new PermisoDefinicion(TramitePermissionDefinition.TramiteCrear, TramitePermissionDefinition.Crear));
      permisoFuncionalidad.Hijos.Add(new PermisoDefinicion(TramitePermissionDefinition.TramiteActualizar, TramitePermissionDefinition.Actualizar));
      permisoFuncionalidad.Hijos.Add(new PermisoDefinicion(TramitePermissionDefinition.TramiteEliminar, TramitePermissionDefinition.Eliminar));

      grupoModulo.Permisos.Add(permisoFuncionalidad);

      permisoFuncionalidad = new PermisoDefinicion(TramitePermissionDefinition.GrupoRolEstado, TramitePermissionDefinition.RolEstado);
      permisoFuncionalidad.Hijos.Add(new PermisoDefinicion(TramitePermissionDefinition.RolEstadoCrear, TramitePermissionDefinition.Crear));
      permisoFuncionalidad.Hijos.Add(new PermisoDefinicion(TramitePermissionDefinition.RolEstadoActualizar, TramitePermissionDefinition.Actualizar));
      permisoFuncionalidad.Hijos.Add(new PermisoDefinicion(TramitePermissionDefinition.RolEstadoEliminar, TramitePermissionDefinition.Eliminar));

      grupoModulo.Permisos.Add(permisoFuncionalidad);

      permisoFuncionalidad = new PermisoDefinicion(TramitePermissionDefinition.GrupoActividadDesarrollar, TramitePermissionDefinition.ActividadDesarrollar);
      permisoFuncionalidad.Hijos.Add(new PermisoDefinicion(TramitePermissionDefinition.ActividadDesarrollarCrear, TramitePermissionDefinition.Crear));
      permisoFuncionalidad.Hijos.Add(new PermisoDefinicion(TramitePermissionDefinition.ActividadDesarrollarActualizar, TramitePermissionDefinition.Actualizar));
      permisoFuncionalidad.Hijos.Add(new PermisoDefinicion(TramitePermissionDefinition.ActividadDesarrollarEliminar, TramitePermissionDefinition.Eliminar));

      grupoModulo.Permisos.Add(permisoFuncionalidad);

      permisoFuncionalidad = new PermisoDefinicion(TramitePermissionDefinition.GrupoCalidadMigratoria, TramitePermissionDefinition.CalidadMigratoria);
      permisoFuncionalidad.Hijos.Add(new PermisoDefinicion(TramitePermissionDefinition.CalidadMigratoriaCrear, TramitePermissionDefinition.Crear));
      permisoFuncionalidad.Hijos.Add(new PermisoDefinicion(TramitePermissionDefinition.CalidadMigratoriaActualizar, TramitePermissionDefinition.Actualizar));
      permisoFuncionalidad.Hijos.Add(new PermisoDefinicion(TramitePermissionDefinition.CalidadMigratoriaEliminar, TramitePermissionDefinition.Eliminar));

      grupoModulo.Permisos.Add(permisoFuncionalidad);

      permisoFuncionalidad = new PermisoDefinicion(TramitePermissionDefinition.GrupoConfiguracion, TramitePermissionDefinition.Configuracion);
      permisoFuncionalidad.Hijos.Add(new PermisoDefinicion(TramitePermissionDefinition.ConfiguracionCrear, TramitePermissionDefinition.Crear));
      permisoFuncionalidad.Hijos.Add(new PermisoDefinicion(TramitePermissionDefinition.ConfiguracionActualizar, TramitePermissionDefinition.Actualizar));
      permisoFuncionalidad.Hijos.Add(new PermisoDefinicion(TramitePermissionDefinition.ConfiguracionEliminar, TramitePermissionDefinition.Eliminar));

      grupoModulo.Permisos.Add(permisoFuncionalidad);

      permisoFuncionalidad = new PermisoDefinicion(TramitePermissionDefinition.GrupoFirmaElectronica, TramitePermissionDefinition.FirmaElectronica);
      permisoFuncionalidad.Hijos.Add(new PermisoDefinicion(TramitePermissionDefinition.FirmaElectronicaCrear, TramitePermissionDefinition.Crear));
      permisoFuncionalidad.Hijos.Add(new PermisoDefinicion(TramitePermissionDefinition.FirmaElectronicaActualizar, TramitePermissionDefinition.Actualizar));
      permisoFuncionalidad.Hijos.Add(new PermisoDefinicion(TramitePermissionDefinition.FirmaElectronicaEliminar, TramitePermissionDefinition.Eliminar));

      grupoModulo.Permisos.Add(permisoFuncionalidad);

      permisoFuncionalidad = new PermisoDefinicion(TramitePermissionDefinition.GrupoDocumento, TramitePermissionDefinition.Documento);
      permisoFuncionalidad.Hijos.Add(new PermisoDefinicion(TramitePermissionDefinition.DocumentoCrear, TramitePermissionDefinition.Crear));
      permisoFuncionalidad.Hijos.Add(new PermisoDefinicion(TramitePermissionDefinition.DocumentoActualizar, TramitePermissionDefinition.Actualizar));
      permisoFuncionalidad.Hijos.Add(new PermisoDefinicion(TramitePermissionDefinition.DocumentoEliminar, TramitePermissionDefinition.Eliminar));

      grupoModulo.Permisos.Add(permisoFuncionalidad);

      permisoFuncionalidad = new PermisoDefinicion(TramitePermissionDefinition.GrupoHistorialMigratorio, TramitePermissionDefinition.HistorialMigratorio);
      permisoFuncionalidad.Hijos.Add(new PermisoDefinicion(TramitePermissionDefinition.HistorialMigratorioCrear, TramitePermissionDefinition.Crear));
      permisoFuncionalidad.Hijos.Add(new PermisoDefinicion(TramitePermissionDefinition.HistorialMigratorioActualizar, TramitePermissionDefinition.Actualizar));
      permisoFuncionalidad.Hijos.Add(new PermisoDefinicion(TramitePermissionDefinition.HistorialMigratorioEliminar, TramitePermissionDefinition.Eliminar));

      grupoModulo.Permisos.Add(permisoFuncionalidad);

      permisoFuncionalidad = new PermisoDefinicion(TramitePermissionDefinition.GrupoMovimiento, TramitePermissionDefinition.Movimiento);
      permisoFuncionalidad.Hijos.Add(new PermisoDefinicion(TramitePermissionDefinition.MovimientoCrear, TramitePermissionDefinition.Crear));
      permisoFuncionalidad.Hijos.Add(new PermisoDefinicion(TramitePermissionDefinition.MovimientoActualizar, TramitePermissionDefinition.Actualizar));
      permisoFuncionalidad.Hijos.Add(new PermisoDefinicion(TramitePermissionDefinition.MovimientoEliminar, TramitePermissionDefinition.Eliminar));

      grupoModulo.Permisos.Add(permisoFuncionalidad);

      permisoFuncionalidad = new PermisoDefinicion(TramitePermissionDefinition.GrupoOrdenCedulacion, TramitePermissionDefinition.OrdenCedulacion);
      permisoFuncionalidad.Hijos.Add(new PermisoDefinicion(TramitePermissionDefinition.OrdenCedulacionCrear, TramitePermissionDefinition.Crear));
      permisoFuncionalidad.Hijos.Add(new PermisoDefinicion(TramitePermissionDefinition.OrdenCedulacionActualizar, TramitePermissionDefinition.Actualizar));
      permisoFuncionalidad.Hijos.Add(new PermisoDefinicion(TramitePermissionDefinition.OrdenCedulacionEliminar, TramitePermissionDefinition.Eliminar));

      grupoModulo.Permisos.Add(permisoFuncionalidad);

      permisoFuncionalidad = new PermisoDefinicion(TramitePermissionDefinition.GrupoSoporteGestion, TramitePermissionDefinition.SoporteGestion);
      permisoFuncionalidad.Hijos.Add(new PermisoDefinicion(TramitePermissionDefinition.SoporteGestionCrear, TramitePermissionDefinition.Crear));
      permisoFuncionalidad.Hijos.Add(new PermisoDefinicion(TramitePermissionDefinition.SoporteGestionActualizar, TramitePermissionDefinition.Actualizar));
      permisoFuncionalidad.Hijos.Add(new PermisoDefinicion(TramitePermissionDefinition.SoporteGestionEliminar, TramitePermissionDefinition.Eliminar));

      grupoModulo.Permisos.Add(permisoFuncionalidad);

      permisoFuncionalidad = new PermisoDefinicion(TramitePermissionDefinition.GrupoTipoConvenio, TramitePermissionDefinition.TipoConvenio);
      permisoFuncionalidad.Hijos.Add(new PermisoDefinicion(TramitePermissionDefinition.TipoConvenioCrear, TramitePermissionDefinition.Crear));
      permisoFuncionalidad.Hijos.Add(new PermisoDefinicion(TramitePermissionDefinition.TipoConvenioActualizar, TramitePermissionDefinition.Actualizar));
      permisoFuncionalidad.Hijos.Add(new PermisoDefinicion(TramitePermissionDefinition.TipoConvenioEliminar, TramitePermissionDefinition.Eliminar));

      grupoModulo.Permisos.Add(permisoFuncionalidad);

      permisoFuncionalidad = new PermisoDefinicion(TramitePermissionDefinition.GrupoTipoVisa, TramitePermissionDefinition.TipoVisa);
      permisoFuncionalidad.Hijos.Add(new PermisoDefinicion(TramitePermissionDefinition.TipoVisaCrear, TramitePermissionDefinition.Crear));
      permisoFuncionalidad.Hijos.Add(new PermisoDefinicion(TramitePermissionDefinition.TipoVisaActualizar, TramitePermissionDefinition.Actualizar));
      permisoFuncionalidad.Hijos.Add(new PermisoDefinicion(TramitePermissionDefinition.TipoVisaEliminar, TramitePermissionDefinition.Eliminar));

      grupoModulo.Permisos.Add(permisoFuncionalidad);

      permisoFuncionalidad = new PermisoDefinicion(TramitePermissionDefinition.GrupoFuncionario, TramitePermissionDefinition.Funcionario);
      permisoFuncionalidad.Hijos.Add(new PermisoDefinicion(TramitePermissionDefinition.FuncionarioCrear, TramitePermissionDefinition.Crear));
      permisoFuncionalidad.Hijos.Add(new PermisoDefinicion(TramitePermissionDefinition.FuncionarioActualizar, TramitePermissionDefinition.Actualizar));
      permisoFuncionalidad.Hijos.Add(new PermisoDefinicion(TramitePermissionDefinition.FuncionarioEliminar, TramitePermissionDefinition.Eliminar));

      grupoModulo.Permisos.Add(permisoFuncionalidad);

      return lista;
    }

  }
}
