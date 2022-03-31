using System;

namespace Mre.Visas.Tramite.Application.Tramite.Dtos
{
  public class VisaDto
  {

    private bool _poseeVisa;
    private bool _confirmacionVisa;
    private string _estadoVisa;
    private DateTime? _fechaCaducidad;
    private DateTime? _fechaConcesion;
    private string _idActoConsularVisa;
    private string _idCentroAdministrativo;
    private string _idPersona;
    private string _idTramite;
    private string _nombreActoConsularVisa;
    private string _nombreCentroAdministrativo;
    private string _nombres;
    private string _numeroPasaporte;
    private string _numeroVisa;
    private string _primerApellido;
    private string _segundoApellido;


    public bool? PoseeVisa
    {
      get => _poseeVisa;
      set => _poseeVisa = value ?? false;
    }
    public bool? ConfirmacionVisa
    {
      get => _confirmacionVisa;
      set => _confirmacionVisa = value ?? false;
    }
    public string EstadoVisa
    {
      get => _estadoVisa ?? string.Empty;
      set => _estadoVisa = value ?? string.Empty;
    }

    public DateTime? FechaCaducidad
    {
      get => _fechaCaducidad ?? new DateTime(1900, 1, 1);
      set => _fechaCaducidad = value ?? new DateTime(1900, 1, 1);
    }
    public DateTime? FechaConcesion
    {
      get => _fechaConcesion ?? new DateTime(1900, 1, 1);
      set => _fechaConcesion = value ?? new DateTime(1900, 1, 1);
    }
    public string IdActoConsularVisa
    {
      get => _idActoConsularVisa ?? string.Empty;
      set => _idActoConsularVisa = value ?? string.Empty;
    }
    public string IdCentroAdministrativo
    {
      get => _idCentroAdministrativo ?? string.Empty;
      set => _idCentroAdministrativo = value ?? string.Empty;
    }
    public string IdPersona
    {
      get => _idPersona ?? string.Empty;
      set => _idPersona = value ?? string.Empty;
    }
    public string IdTramite
    {
      get => _idTramite ?? string.Empty;
      set => _idTramite = value ?? string.Empty;
    }
    public string NombreActoConsularVisa
    {
      get => _nombreActoConsularVisa ?? string.Empty;
      set => _nombreActoConsularVisa = value ?? string.Empty;
    }
    public string NombreCentroAdministrativo
    {
      get => _nombreCentroAdministrativo ?? string.Empty;
      set => _nombreCentroAdministrativo = value ?? string.Empty;
    }
    public string Nombres
    {
      get => _nombres ?? string.Empty;
      set => _nombres = value ?? string.Empty;
    }
    public string NumeroPasaporte
    {
      get => _numeroPasaporte ?? string.Empty;
      set => _numeroPasaporte = value ?? string.Empty;
    }
    public string NumeroVisa
    {
      get => _numeroVisa ?? string.Empty;
      set => _numeroVisa = value ?? string.Empty;
    }
    public string PrimerApellido
    {
      get => _primerApellido ?? string.Empty;
      set => _primerApellido = value ?? string.Empty;
    }
    public string SegundoApellido
    {
      get => _segundoApellido ?? string.Empty;
      set => _segundoApellido = value ?? string.Empty;
    }
  }
}