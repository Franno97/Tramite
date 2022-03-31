using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Mre.Visas.Tramite.Infrastructure.Pasaporte.Configurations
{
  public class PasaporteConfiguration : IEntityTypeConfiguration<Domain.Entities.Pasaporte>
  {
    public void Configure(EntityTypeBuilder<Domain.Entities.Pasaporte> builder)
    {
      builder.ToTable("Pasaportes");

      builder.HasKey(e => e.Id);

      builder.Property(e => e.CiudadEmision)
          .HasMaxLength(100)
          .IsRequired(true);

      builder.Property(e => e.FechaEmision)
          .IsRequired(true);

      builder.Property(e => e.FechaExpiracion)
          .IsRequired(true);

      builder.Property(e => e.FechaNacimiento)
          .IsRequired(true);

      builder.Property(e => e.Id)
          .IsRequired(true);

      builder.Property(e => e.Nombres)
          .HasMaxLength(100)
          .IsRequired(true);

      builder.Property(e => e.TipoDocumentoIdentidadId)
                .HasMaxLength(10)
                .IsRequired(true);

      builder.Property(e => e.Numero)
          .HasMaxLength(50)
          .IsRequired(true);

      builder.Property(e => e.PaisEmision)
          .HasMaxLength(50)
          .IsRequired(true);

    }
  }
}