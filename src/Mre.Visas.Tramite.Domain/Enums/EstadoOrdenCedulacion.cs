using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mre.Visas.Tramite.Domain.Enums
{

    public enum EstadoOrdenCedulacion
    {
        //La orden de cedulacion se crea con los datos provenientes del tramite
        [Display(Name = "Creada")]
        Creada = 1,

        //La orden de cedulacion ha sido facturada y se ha guardado la clave de acceso de la factura
        [Display(Name = "Facturada")]
        Facturada = 2,

        //La orden de cedulacion ha sido creada en esigex
        [Display(Name = "Creada Esigex")]
        CreadaEsigex = 3,

        //La orden de cedulacion ha sido generada, firmada y guardada en la base de datos
        [Display(Name = "Firmada")]
        Firmada = 4,

        //La orden de cedulacion esta finalizada
        [Display(Name = "Finalizada")]
        Finalizada = 5

    }
}
