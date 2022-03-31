using System;

namespace Mre.Visas.Tramite.Application.Tramite.Dtos
{
    public class DomicilioDto
    {
        public string Ciudad { get; set; }

        public string Direccion { get; set; }

        public string Pais { get; set; }

        public string Provincia { get; set; }

        public string TelefonoCelular { get; set; }

        public string TelefonoDomicilio { get; set; }

        public string TelefonoTrabajo { get; set; }
    }


  public class DomicilioDtoSubsanacion
  {
    public Guid  Id{ get; set; }
    
    public string TelefonoCelular { get; set; }

    public string TelefonoDomicilio { get; set; }

    public string TelefonoTrabajo { get; set; }

    public string Pais { get; set; }
  }
}