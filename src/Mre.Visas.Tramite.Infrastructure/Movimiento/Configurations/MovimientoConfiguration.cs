using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Mre.Visas.Tramite.Infrastructure.Movimiento.Configurations
{
  public class MovimientoConfiguration : IEntityTypeConfiguration<Domain.Entities.Movimiento>
  {
    public void Configure(EntityTypeBuilder<Domain.Entities.Movimiento> builder)
    {
      builder.ToTable("Movimientos");

      builder.HasKey(e => e.Id);

      builder.Property(e => e.Created)
          .IsRequired(true);

      builder.Property(e => e.CreatorId)
          .IsRequired(true);

      builder.Property(e => e.Id)
          .IsRequired(true);

      builder.Property(e => e.Orden)
          .HasMaxLength(256)
          .IsRequired(true);

      builder.Property(e => e.UsuarioId)
          .IsRequired(true);

      builder.Property(e => e.UnidadAdministrativaId)
               .IsRequired(true);

      builder.Property(e => e.Estado)
       .HasMaxLength(10)
       .IsRequired(true);

      builder.Property(e => e.Vigente)
       .IsRequired(true);

      builder.Property(e => e.NombreRol)
        .HasMaxLength(256)
        .IsRequired(true);

      builder.Property(e => e.ObservacionDatosPersonales)
        .HasMaxLength(256)
        .IsRequired(false);

      builder.Property(e => e.ObservacionDomicilios)
        .HasMaxLength(256)
        .IsRequired(false);

      builder.Property(e => e.ObservacionMovimientoMigratorio)
        .HasMaxLength(256)
        .IsRequired(false);

      builder.Property(e => e.ObservacionMultas)
        .HasMaxLength(256)
        .IsRequired(false);

      builder.Property(e => e.ObservacionSoportesGestion)
        .HasMaxLength(256)
        .IsRequired(false);

      builder.Property(e => e.DiasTranscurridos)
       .IsRequired(true);

      builder.Property(e => e.FechaHoraCita)
       .IsRequired(true);
            

    }
  }
}
