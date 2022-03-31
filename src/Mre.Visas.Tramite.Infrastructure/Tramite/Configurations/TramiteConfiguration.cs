using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Mre.Visas.Tramite.Infrastructure.Tramite.Configurations
{
  public class TramiteConfiguration : IEntityTypeConfiguration<Domain.Entities.Tramite>
  {
    public void Configure(EntityTypeBuilder<Domain.Entities.Tramite> builder)
    {
      builder.ToTable("Tramites");

      builder.HasKey(e => e.Id);

      builder.Property(e => e.Id)
         .IsRequired(true);

      builder.Property(e => e.Numero)
              .HasMaxLength(100)
              .IsRequired(true);

      builder.Property(e => e.Fecha)
              .HasMaxLength(10)
              .IsRequired(true);

      builder.Property(e => e.ActividadId)
          .IsRequired(true);

      builder.Property(e => e.BeneficiarioId)
          .IsRequired(true);

      builder.Property(e => e.CalidadMigratoriaId)
          .IsRequired(true);

      builder.Property(e => e.Created)
          .IsRequired(true);

      builder.Property(e => e.CreatorId)
          .IsRequired(true);

      builder.Property(e => e.TipoConvenioId)
          .IsRequired(true);

      builder.Property(e => e.SolicitanteId)
          .IsRequired(true);

      builder.Property(e => e.TipoVisaId)
          .IsRequired(true);

      builder.Property(e => e.UnidadAdministrativaIdCEV)
         .IsRequired(true);

      builder.Property(e => e.UnidadAdministrativaIdZonal)
         .IsRequired(true);

      builder.Property(e => e.ServicioId)
        .IsRequired(true);

      builder.Property(e => e.PersonaId)
       .IsRequired(true);

      builder.Property(e => e.CodigoPais)
          .HasMaxLength(20)
          .IsRequired(true);

    }
  }
}