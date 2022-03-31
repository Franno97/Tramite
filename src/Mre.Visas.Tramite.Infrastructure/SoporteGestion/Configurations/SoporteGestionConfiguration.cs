using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Mre.Visas.Tramite.Infrastructure.SoporteGestion.Configurations
{
  public class SoporteGestionConfiguration : IEntityTypeConfiguration<Domain.Entities.SoporteGestion>
  {
    public void Configure(EntityTypeBuilder<Domain.Entities.SoporteGestion> builder)
    {
      builder.ToTable("SoporteGestiones");

      builder.HasKey(e => e.Id);

      builder.Property(e => e.Created)
          .IsRequired(true);

      builder.Property(e => e.CreatorId)
          .IsRequired(true);

      builder.Property(e => e.Id)
          .IsRequired(true);

      builder.Property(e => e.Nombre)
          .HasMaxLength(256)
          .IsRequired(true);

      builder.Property(e => e.Ruta)
          .HasMaxLength(int.MaxValue)
          .IsRequired(true);

      builder.Property(e => e.Descripcion)
          .HasMaxLength(250)
          .IsRequired(true);

    }
  }
}