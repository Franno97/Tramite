﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mre.Visas.Tramite.Domain.Enums
{
    public enum CodigoRespuestaEsigex
    {
        [Display(Name = "Dato encontrado")]
        DatoEncontrado = 0,

        [Display(Name = "Tiempo de espera")]
        TiempoEspera = 1,

        [Display(Name = "ServicioCaido")]
        SerivicioCaido = 2,

        [Display(Name = "Errores propios del desarrollo")]
        ErrorDesarrollo = 3,

        [Display(Name = "Falta parametros obligatorios")]
        FaltaParametroObligatorio = 4,

        [Display(Name = "No se encontraron datos")]
        DatoNoEncontrado = 5,

        [Display(Name = "Error en servicio web")]
        ErrorServicioWeb = -1
    }
}
