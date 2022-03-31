using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Mre.Visas.Tramite.Infrastructure.Documento.Configurations
{
  public class DocumentoConfiguration : IEntityTypeConfiguration<Domain.Entities.Documento>
  {
    public void Configure(EntityTypeBuilder<Domain.Entities.Documento> builder)
    {
      builder.ToTable("Documentos");

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

      builder.Property(e => e.Observacion)
               .IsRequired(false);

      builder.Property(e => e.TipoDocumento)
        .HasMaxLength(50)
        .IsRequired(false);

      builder.Property(e => e.IconoNombre).HasMaxLength(100);
      builder.Property(e => e.ImagenNombre).HasMaxLength(100);
      builder.Property(e => e.DescripcionDocumento).HasMaxLength(100);

    }
  }
}