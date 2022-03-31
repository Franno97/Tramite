using Mre.Visas.Tramite.Domain.Enums;
using System;

namespace Mre.Visas.Tramite.Domain.Entities
{
  public class Beneficiario : BaseEntity
  {
    public TipoCiudadano.TipoCiudadanoEnum TipoCiudadano { get; set; }
    
    public string CiudadNacimiento { get; set; }

    public string CodigoMDG { get; set; }

    public string Correo { get; set; }

    public Domicilio Domicilio { get; set; }

    public Guid DomicilioId { get; set; }

    public int Edad { get; set; }

    public string EstadoCivil { get; set; }

    public DateTime FechaNacimiento { get; set; }

    public string Foto { get; set; }

    public string Genero { get; set; }

    public string Ocupacion { get; set; }

    public string NacionalidadId { get; set; }

    public string Nacionalidad { get; set; }

    public string Nombres { get; set; }

    public string PaisNacimiento { get; set; }

    public Pasaporte Pasaporte { get; set; }

    public Guid PasaporteId { get; set; }

    public bool PoseeDiscapacidad { get; set; }

    public int PorcentajeDiscapacidad { get; set; }
    
    public string CarnetConadis { get; set; }

    public DateTime FechaEmisionConadis { get; set; }

    public DateTime FechaCaducidadConadis { get; set; }

    public string PrimerApellido { get; set; }

    public string SegundoApellido { get; set; }

    public Visa Visa { get; set; }

    public Guid VisaId { get; set; }
  }
}