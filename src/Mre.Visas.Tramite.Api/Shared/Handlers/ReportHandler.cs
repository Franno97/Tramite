using Microsoft.Reporting.NETCore;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Mre.Visas.Tramite.Api.Shared.Handlers
{
  public class ReportHandler
  {
    public string GeneratePDFTramite(Domain.Entities.Tramite tramite)
    {
      string base64 = string.Empty;
      try
      {
        string SOLTERO = string.Empty;
        string CASADO = string.Empty;
        string VIUDO = string.Empty;
        string DIVORCIADO = string.Empty;
        string UNION_HECHO = string.Empty;
        if (tramite.Beneficiario.EstadoCivil.Equals("SOLTERO"))
          SOLTERO = "x";
        else if (tramite.Beneficiario.EstadoCivil.Equals("CASADO"))
          CASADO = "x";
        else if (tramite.Beneficiario.EstadoCivil.Equals("VIUDO"))
          VIUDO = "x";
        else if (tramite.Beneficiario.EstadoCivil.Equals("DIVORCIADO"))
          DIVORCIADO = "x";
        else if (tramite.Beneficiario.EstadoCivil.Equals("UNION DE HECHO"))
          UNION_HECHO = "x";

        string FEMENINO = string.Empty;
        string MASCULINO = string.Empty;
        if (tramite.Beneficiario.Genero.Equals("F"))
          FEMENINO = "x";
        else if (tramite.Beneficiario.Genero.Equals("M"))
          MASCULINO = "x";

        byte[] imageIzquierda = System.IO.File.ReadAllBytes(Path.Combine(Environment.CurrentDirectory, "Shared", "Images", "SolicitudVisaIzquierda.png"));
        byte[] imageDerecha = System.IO.File.ReadAllBytes(Path.Combine(Environment.CurrentDirectory, "Shared", "Images", "SolicitudVisaDerecha.png"));
        string base64ImageIzquierda = Convert.ToBase64String(imageIzquierda);
        string base64ImageDerecha = Convert.ToBase64String(imageDerecha);


        LocalReport report = new LocalReport();
        var parameters = new[]
        {
          new ReportParameter("varSolicitud", "x"),
          new ReportParameter("varCertificadoVisa",string.Empty),
          new ReportParameter("varRenovacion",string.Empty),
          new ReportParameter("varTransferencia",string.Empty),
          new ReportParameter("varCancelacion",string.Empty),
          new ReportParameter("varResidenciaTemporal","x"),
          new ReportParameter("varResidenciaPermanente",string.Empty),
          new ReportParameter("varVisitanteTemporal",string.Empty),
          new ReportParameter("varDiplomatico",string.Empty),
          new ReportParameter("varNumeroPasaporte",tramite.Beneficiario.Pasaporte.Numero),
          new ReportParameter("varTipoIdentificacion",tramite.Beneficiario.Pasaporte.TipoDocumentoIdentidadId),
          new ReportParameter("varPaisEmitido",tramite.Beneficiario.Pasaporte.PaisEmision),
          new ReportParameter("varFechaEmision",tramite.Beneficiario.Pasaporte.FechaEmision.ToString("dd/MM/yyyy")),
          new ReportParameter("varFechaExpiracion",tramite.Beneficiario.Pasaporte.FechaExpiracion.ToString("dd/MM/yyyy")),
          new ReportParameter("varApellido",tramite.Beneficiario.PrimerApellido+" "+tramite.Beneficiario.SegundoApellido),
          new ReportParameter("varNombres",tramite.Beneficiario.Nombres),
          new ReportParameter("varLugarNacimiento",tramite.Beneficiario.CiudadNacimiento),
          new ReportParameter("varFechaNacimiento",tramite.Beneficiario.FechaNacimiento.ToString("dd/MM/yyyy")),
          new ReportParameter("varNacionalidad",tramite.Beneficiario.Nacionalidad),
          new ReportParameter("varOcupacion",tramite.Beneficiario.Ocupacion),
          new ReportParameter("varSoltero",SOLTERO),
          new ReportParameter("varCasado",CASADO),
          new ReportParameter("varViudo",VIUDO),
          new ReportParameter("varDivorciado",DIVORCIADO),
          new ReportParameter("varUnionHecho",UNION_HECHO),
          new ReportParameter("varFemenino",FEMENINO),
          new ReportParameter("varMasculino",MASCULINO),
          new ReportParameter("varNumeroTramite",tramite.Numero),
          new ReportParameter("varDireccion",tramite.Beneficiario.Domicilio.Direccion),
          new ReportParameter("varCiudad",tramite.Beneficiario.Domicilio.Ciudad),
          new ReportParameter("varProvincia",tramite.Beneficiario.Domicilio.Provincia),
          new ReportParameter("varCorreoElectronico",tramite.Beneficiario.Correo),
          new ReportParameter("varTelefonoMovil",tramite.Beneficiario.Domicilio.TelefonoCelular),
          new ReportParameter("varTelefonoDomicilio",tramite.Beneficiario.Domicilio.TelefonoDomicilio),
          //datos de imagenes : foto
          new ReportParameter("varFoto",tramite.Beneficiario.Foto),
          new ReportParameter("varFotoMimeType","image/png"),
          //datos de imagenes : cabeceras
          new ReportParameter("varIzquierda",base64ImageIzquierda),
          new ReportParameter("varIzquierdaMimeType","image/png"),
          new ReportParameter("varDerecha",base64ImageDerecha),
          new ReportParameter("varDerechaMimeType","image/png"),

        };


        using var fs = new FileStream(Path.Combine(Environment.CurrentDirectory, "Shared", "Reports", "SolicitudVisa.rdlc"), FileMode.Open);
        //using var fs = new FileStream(@"Shared\Reports\SolicitudVisa.rdlc", FileMode.Open);

        report.EnableExternalImages = true;
        report.LoadReportDefinition(fs);
        report.SetParameters(parameters);

        byte[] bytes = report.Render("PDF");
        base64 = Convert.ToBase64String(bytes, 0, bytes.Length);
        return base64;
      }
      catch
      {
        throw;
      }
    }
  }
}
