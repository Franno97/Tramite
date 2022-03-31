using System;

namespace Mre.Visas.Tramite.Domain.Entities
{
  public class Visa : BaseEntity
  {
    public bool PoseeVisa { get; set; }
    public bool ConfirmacionVisa { get; set; }
    public string EstadoVisa { get; set; }//>ACTIVA</a:EstadoVisa>
    public DateTime FechaCaducidad { get; set; }//>2022-03-12</a:FechaCaducidad>
    public DateTime FechaConcesion { get; set; }//>2020-03-12</a:FechaConcesion>
    public string IdActoConsularVisa { get; set; }//>2751</a:IdActoConsularVisa>
    public string IdCentroAdministrativo { get; set; }//>9237</a:IdCentroAdministrativo>
    public string IdPersona { get; set; }//>3841021</a:IdPersona>
    public string IdTramite { get; set; }//>6751048</a:IdTramite>
    public string NombreActoConsularVisa { get; set; }//>RESIDENTE TEMPORAL - EXCEPCIÓN POR AUTORIDAD DE M.H. - RAZONES HUMANITARIAS - ECUADOR</a:NombreActoConsularVisa>
    public string NombreCentroAdministrativo { get; set; }//>UNIDAD DE VISADO HUMANITARIO</a:NombreCentroAdministrativo>
    public string Nombres { get; set; }//>JOHANNA LISBETH</a:Nombres>
    public string NumeroPasaporte { get; set; }///>
    public string NumeroVisa { get; set; }//>WB8PNBUW</a:NumeroVisa>
    public string PrimerApellido { get; set; }//>HERRERA</a:PrimerApellido>
    public string SegundoApellido { get; set; }//>TORREALBA</a:SegundoApellido>

  }
}