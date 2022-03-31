using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Mre.Visas.Tramite.Infrastructure.Solicitante.Configurations
{
  public class SolicitanteConfiguration : IEntityTypeConfiguration<Domain.Entities.Solicitante>
  {
    public void Configure(EntityTypeBuilder<Domain.Entities.Solicitante> builder)
    {
      builder.ToTable("Solicitantes");

      builder.HasKey(e => e.Id);

      builder.Property(e => e.Identificacion)
          .HasMaxLength(50)
          .IsRequired(true);

      builder.Property(e => e.TipoIdentificacion)
          .HasMaxLength(20)
          .IsRequired(true);

      builder.Property(e => e.Ciudad)
          .HasMaxLength(50)
          .IsRequired(true);

      builder.Property(e => e.ConsuladoNombre)
          .HasMaxLength(256)
          .IsRequired(true);

      builder.Property(e => e.ConsuladoPais)
          .HasMaxLength(50)
          .IsRequired(true);

      builder.Property(e => e.Direccion)
          .HasMaxLength(int.MaxValue)
          .IsRequired(true);

      builder.Property(e => e.Id)
          .IsRequired(true);

      builder.Property(e => e.Nacionalidad)
          .HasMaxLength(50)
          .IsRequired(true);

      builder.Property(e => e.Nombres)
          .HasMaxLength(100)
          .IsRequired(true);

      builder.Property(e => e.Pais)
          .HasMaxLength(50)
          .IsRequired(true);

      builder.Property(e => e.Telefono)
          .HasMaxLength(50)
          .IsRequired(true);

      builder.Property(e => e.Correo)
                .HasMaxLength(50)
                .IsRequired(true);
    }
  }
}