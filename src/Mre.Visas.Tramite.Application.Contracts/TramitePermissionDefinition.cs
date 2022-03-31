using System;
using System.Collections.Generic;
using System.Text;

namespace Mre.Visas.Tramite.Application.Contracts
{
  public class TramitePermissionDefinition
  {
    public const string Crear = "Crear";
    public const string Actualizar = "Actualizar";
    public const string Eliminar = "Eliminar";
    public const string Lectura = "Lectura";

    public const string Tramite = "Tramite";
    public const string GrupoTramite = "Tramite.Tramites";
    public const string TramiteCrear = GrupoTramite + "." + Crear;
    public const string TramiteActualizar = GrupoTramite + "." + Actualizar;
    public const string TramiteEliminar = GrupoTramite + "." + Eliminar;

    public const string Movimiento = "Movimiento";
    public const string GrupoMovimiento = "Tramite." + Movimiento;
    public const string MovimientoCrear = GrupoMovimiento + "." + Crear;
    public const string MovimientoActualizar = GrupoMovimiento + "." + Actualizar;
    public const string MovimientoEliminar = GrupoMovimiento + "." + Eliminar;

    public const string Documento = "Documento";
    public const string GrupoDocumento = "Tramite." + Documento;
    public const string DocumentoCrear = GrupoDocumento + "." + Crear;
    public const string DocumentoActualizar = GrupoDocumento + "." + Actualizar;
    public const string DocumentoEliminar = GrupoDocumento + "." + Eliminar;

    public const string RolEstado = "RolEstado";
    public const string GrupoRolEstado = "Tramite." + RolEstado;
    public const string RolEstadoCrear = GrupoRolEstado + "." + Crear;
    public const string RolEstadoActualizar = GrupoRolEstado + "." + Actualizar;
    public const string RolEstadoEliminar = GrupoRolEstado + "." + Eliminar;

    public const string ActividadDesarrollar = "ActividadDesarrollar";
    public const string GrupoActividadDesarrollar = "Tramite." + ActividadDesarrollar;
    public const string ActividadDesarrollarCrear = GrupoActividadDesarrollar + "." + Crear;
    public const string ActividadDesarrollarActualizar = GrupoActividadDesarrollar + "." + Actualizar;
    public const string ActividadDesarrollarEliminar = GrupoActividadDesarrollar + "." + Eliminar;

    public const string CalidadMigratoria = "CalidadMigratoria";
    public const string GrupoCalidadMigratoria = "Tramite." + CalidadMigratoria;
    public const string CalidadMigratoriaCrear = GrupoCalidadMigratoria + "." + Crear;
    public const string CalidadMigratoriaActualizar = GrupoCalidadMigratoria + "." + Actualizar;
    public const string CalidadMigratoriaEliminar = GrupoCalidadMigratoria + "." + Eliminar;

    public const string Configuracion = "Configuracion";
    public const string GrupoConfiguracion = "Tramite." + Configuracion;
    public const string ConfiguracionCrear = GrupoConfiguracion + "." + Crear;
    public const string ConfiguracionActualizar = GrupoConfiguracion + "." + Actualizar;
    public const string ConfiguracionEliminar = GrupoConfiguracion + "." + Eliminar;

    public const string SoporteGestion = "SoporteGestion";
    public const string GrupoSoporteGestion = "Tramite." + SoporteGestion;
    public const string SoporteGestionCrear = GrupoSoporteGestion + "." + Crear;
    public const string SoporteGestionActualizar = GrupoSoporteGestion + "." + Actualizar;
    public const string SoporteGestionEliminar = GrupoSoporteGestion + "." + Eliminar;

    public const string HistorialMigratorio = "HistorialMigratorio";
    public const string GrupoHistorialMigratorio = "Tramite." + HistorialMigratorio;
    public const string HistorialMigratorioCrear = GrupoHistorialMigratorio + "." + Crear;
    public const string HistorialMigratorioActualizar = GrupoHistorialMigratorio + "." + Actualizar;
    public const string HistorialMigratorioEliminar = GrupoHistorialMigratorio + "." + Eliminar;

    public const string FirmaElectronica = "FirmaElectronica";
    public const string GrupoFirmaElectronica = "Tramite." + FirmaElectronica;
    public const string FirmaElectronicaCrear = GrupoFirmaElectronica + "." + Crear;
    public const string FirmaElectronicaActualizar = GrupoFirmaElectronica + "." + Actualizar;
    public const string FirmaElectronicaEliminar = GrupoFirmaElectronica + "." + Eliminar;

    public const string OrdenCedulacion = "OrdenCedulacion";
    public const string GrupoOrdenCedulacion = "Tramite." + OrdenCedulacion;
    public const string OrdenCedulacionCrear = GrupoOrdenCedulacion + "." + Crear;
    public const string OrdenCedulacionActualizar = GrupoOrdenCedulacion + "." + Actualizar;
    public const string OrdenCedulacionEliminar = GrupoOrdenCedulacion + "." + Eliminar;

    public const string TipoConvenio = "TipoConvenio";
    public const string GrupoTipoConvenio = "Tramite." + TipoConvenio;
    public const string TipoConvenioCrear = GrupoTipoConvenio + "." + Crear;
    public const string TipoConvenioActualizar = GrupoTipoConvenio + "." + Actualizar;
    public const string TipoConvenioEliminar = GrupoTipoConvenio + "." + Eliminar;

    public const string TipoVisa = "TipoVisa";
    public const string GrupoTipoVisa = "Tramite." + TipoVisa;
    public const string TipoVisaCrear = GrupoTipoVisa + "." + Crear;
    public const string TipoVisaActualizar = GrupoTipoVisa + "." + Actualizar;
    public const string TipoVisaEliminar = GrupoTipoVisa + "." + Eliminar;

    public const string Funcionario = "Funcionario";
    public const string GrupoFuncionario = "Tramite." + Funcionario;
    public const string FuncionarioCrear = GrupoFuncionario + "." + Crear;
    public const string FuncionarioActualizar = GrupoFuncionario + "." + Actualizar;
    public const string FuncionarioEliminar = GrupoFuncionario + "." + Eliminar;
  }
}
