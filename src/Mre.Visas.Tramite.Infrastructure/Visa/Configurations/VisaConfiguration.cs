using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Mre.Visas.Tramite.Infrastructure.Visa.Configurations
{
  public class VisaConfiguration : IEntityTypeConfiguration<Domain.Entities.Visa>
  {
    public void Configure(EntityTypeBuilder<Domain.Entities.Visa> builder)
    {
      builder.ToTable("Visas");
      builder.HasKey(e => e.Id);
      builder.Property(e => e.PoseeVisa).IsRequired(true);
      builder.Property(e => e.ConfirmacionVisa).IsRequired(true);
      builder.Property(e => e.EstadoVisa).IsRequired(true).HasMaxLength(10);//>ACTIVA</a:EstadoVisa>
      builder.Property(e => e.FechaCaducidad).IsRequired(true);//>2022-03-12</a:FechaCaducidad>
      builder.Property(e => e.FechaConcesion).IsRequired(true);//>2020-03-12</a:FechaConcesion>
      builder.Property(e => e.IdActoConsularVisa).IsRequired(true).HasMaxLength(30);//>2751</a:IdActoConsularVisa>
      builder.Property(e => e.IdCentroAdministrativo).IsRequired(true).HasMaxLength(30);//>9237</a:IdCentroAdministrativo>
      builder.Property(e => e.IdPersona).IsRequired(true).HasMaxLength(30);//>3841021</a:IdPersona>
      builder.Property(e => e.IdTramite).IsRequired(true).HasMaxLength(30);//>6751048</a:IdTramite>
      builder.Property(e => e.NombreActoConsularVisa).IsRequired(true).HasMaxLength(250);//>RESIDENTE TEMPORAL - EXCEPCIÓN POR AUTORIDAD DE M.H. - RAZONES HUMANITARIAS - ECUADOR</a:NombreActoConsularVisa>
      builder.Property(e => e.NombreCentroAdministrativo).IsRequired(true).HasMaxLength(250);//>UNIDAD DE VISADO HUMANITARIO</a:NombreCentroAdministrativo>
      builder.Property(e => e.Nombres).IsRequired(true).HasMaxLength(250);//>JOHANNA LISBETH</a:Nombres>
      builder.Property(e => e.NumeroPasaporte).IsRequired(true).HasMaxLength(50);///>
      builder.Property(e => e.NumeroVisa).IsRequired(true).HasMaxLength(50);//>WB8PNBUW</a:NumeroVisa>
      builder.Property(e => e.PrimerApellido).IsRequired(true).HasMaxLength(150);//>HERRERA</a:PrimerApellido>
      builder.Property(e => e.SegundoApellido).IsRequired(true).HasMaxLength(150);//>TORREALBA</a:SegundoApellido>


    }
  }
}