﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mre.Visas.Tramite.Domain.Enums
{
  public class RolEstado
  {
    public enum Codigo
    {
      Ninguno = 0,
      SolicitudVisa = 1,
      AnálisisPuntoControl = 2,
      ValidarInformacion = 3,
      SubsanacionInformacion = 4,
      GenerarCitaMenoresEdadZonal = 5,
      EfectuarCitaMenorEdad = 6,
      GenerarCitaPeritaje = 7,
      EfectuarCitaPeritaje = 8,
      VerificarNegativaInformacion = 9,
      RevisarMultasExoneracion = 10,
      ExonerarMultasMDG = 11,
      VerificarNegativaMultas = 12,
      ReconocimientoFacial = 13,
      GenerarCitaSubsanacionReconocimientoFacial = 14,
      EfectuarCitaReconocimientoFacial = 15,
      RevisionReconocimientoFacial = 16,
      VerificarNegativaReconocimientoFacial = 17,
      RealizarPago = 18,
      RegistrarPago = 19,
      ValidarPago = 20,
      SubsanarPago = 21,
      VerificarInformacion = 22,
      VerificarVisas = 23,
      Facturacion = 24,
      GenerarVisa = 25,
      ValidarInformacionNegativa = 26,
      VerificarInformacionNegativa = 27,
      ValidarInformacionDesistimientoSunsanacion = 28,
      ValidarPagoDesistimientoRealizarPago = 29,
      ValidarPagoDesistimientoRegistrarPago = 30,
      ValidarPagoDesistimientoSubsanarPago = 31,
      Terminado = 90,
      Negado = 92,
      Desistido = 93
    }
  }
}
