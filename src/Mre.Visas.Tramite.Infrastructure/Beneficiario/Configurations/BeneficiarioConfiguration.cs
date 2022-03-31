using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Mre.Visas.Tramite.Infrastructure.Beneficiario.Configurations
{
  public class BeneficiarioConfiguration : IEntityTypeConfiguration<Domain.Entities.Beneficiario>
  {
    public void Configure(EntityTypeBuilder<Domain.Entities.Beneficiario> builder)
    {
      builder.ToTable("Beneficiarios");

      builder.HasKey(e => e.Id);

      builder.Ignore(e => e.Edad);

      builder.Property(e => e.TipoCiudadano)
          .IsRequired(true);

      builder.Property(e => e.CiudadNacimiento)
          .HasMaxLength(256)
          .IsRequired(true);

      builder.Property(e => e.CodigoMDG)
          .HasMaxLength(50)
          .IsRequired(true);

      builder.Property(e => e.Correo)
          .HasMaxLength(50)
          .IsRequired(true);

      builder.Property(e => e.DomicilioId)
          .IsRequired(true);

      builder.Property(e => e.EstadoCivil)
          .HasMaxLength(50)
          .IsRequired(true);

      builder.Property(e => e.FechaNacimiento)
          .IsRequired(true);

      builder.Property(e => e.Foto)
          .HasMaxLength(int.MaxValue)
          .IsRequired(true);

      builder.Property(e => e.Genero)
          .HasMaxLength(50)
          .IsRequired(true);

      builder.Property(e => e.Ocupacion)
               .HasMaxLength(50)
               .IsRequired(true);

      builder.Property(e => e.Id)
                .IsRequired(true);

      builder.Property(e => e.NacionalidadId)
         .HasMaxLength(50)
        .IsRequired(true);

      builder.Property(e => e.Nacionalidad)
                .HasMaxLength(50)
                .IsRequired(true);

      builder.Property(e => e.Nombres)
          .HasMaxLength(100)
          .IsRequired(true);

      builder.Property(e => e.PaisNacimiento)
          .HasMaxLength(50)
          .IsRequired(true);

      builder.Property(e => e.PasaporteId)
          .IsRequired(true);

      builder.Property(e => e.PoseeDiscapacidad)
          .IsRequired(true);

      builder.Property(e => e.PorcentajeDiscapacidad)
          .IsRequired(true);

      builder.Property(e => e.CarnetConadis)
          .HasMaxLength(50)
          .IsRequired(true);

      builder.Property(e => e.FechaEmisionConadis)
          .IsRequired(true);


      builder.Property(e => e.FechaCaducidadConadis)
          .IsRequired(true);



      builder.Property(e => e.PrimerApellido)
          .HasMaxLength(50)
          .IsRequired(true);

      builder.Property(e => e.SegundoApellido)
          .HasMaxLength(50)
          .IsRequired(true);

      builder.Property(e => e.VisaId)
          .IsRequired(true);
    }
  }
}