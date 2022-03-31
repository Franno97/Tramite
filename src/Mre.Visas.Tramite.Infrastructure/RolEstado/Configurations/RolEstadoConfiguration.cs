using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Mre.Visas.Tramite.Infrastructure.RolEstado.Configurations
{
  public class RolEstadoConfiguration : IEntityTypeConfiguration<Domain.Entities.RolEstado>
  {
    public void Configure(EntityTypeBuilder<Domain.Entities.RolEstado> builder)
    {
      builder.ToTable("RolEstado");

      builder.HasKey(e => e.Id);

      builder.Property(e => e.Id)
          .IsRequired(true);

      builder.Property(e => e.NombreRol)
          .HasMaxLength(50)
          .IsRequired(true);

      builder.Property(e => e.EsZonal)
         .IsRequired(true);

      builder.Property(e => e.NombreEstado)
          .HasMaxLength(50)
          .IsRequired(true);

      builder.Property(e => e.CodigoEstado)
          .HasMaxLength(50)
          .IsRequired(true);

      builder.Property(e => e.CodigosEstadoSiguiente)
          .HasMaxLength(50)
          .IsRequired(true);

      builder.Property(e => e.CodigoDesistir)
               .HasMaxLength(50)
               .IsRequired(true);

      builder.Property(e => e.TieneNotificacion)
               .IsRequired(true);

      builder.Property(e => e.AgregarObservaciones)
         .IsRequired(true);

      builder.Property(e => e.Created)
          .IsRequired(true);

      builder.Property(e => e.CreatorId)
          .IsRequired(true);

      builder.Property(e => e.LastModified)
      .IsRequired(true);

      builder.Property(e => e.LastModifierId)
      .IsRequired(true);


    }

    //add-migration AddEstadoToTramite -s Mre.Visas.Tramite.Infrastructure
    //update-database -s Mre.Visas.Tramite.Infrastructure
  }
}