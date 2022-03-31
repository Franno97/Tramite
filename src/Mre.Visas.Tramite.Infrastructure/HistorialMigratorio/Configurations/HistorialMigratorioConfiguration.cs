using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Mre.Visas.Tramite.Infrastructure.HistorialMigratorio.Configurations
{
    public class HistorialMigratorioConfiguration : IEntityTypeConfiguration<Domain.Entities.HistorialMigratorio>
    {

        public void Configure(EntityTypeBuilder<Domain.Entities.HistorialMigratorio> builder)
        {
            builder.ToTable("HistorialMigratorio");

            builder.HasKey(e => e.Id);

            builder.Property(e => e.Id).IsRequired(true);

            builder.Property(e => e.ApellidosNombres).HasMaxLength(250).IsRequired(true);
            builder.Property(e => e.CategoriaMigratoria).HasMaxLength(50).IsRequired(true);
            builder.Property(e => e.CodigoError).HasMaxLength(50).IsRequired(true);
            builder.Property(e => e.FechaHoraMovimiento).HasMaxLength(50).IsRequired(true);
            builder.Property(e => e.FechaNacimiento).HasMaxLength(50).IsRequired(true);
            builder.Property(e => e.Genero).HasMaxLength(50).IsRequired(true);
            builder.Property(e => e.Medio).HasMaxLength(50).IsRequired(true);
            builder.Property(e => e.MotivoViaje).HasMaxLength(50).IsRequired(true);
            builder.Property(e => e.NacionalidadDocumentoMovMigra).HasMaxLength(50).IsRequired(true);
            builder.Property(e => e.NumeroDocumentoMovMigra).HasMaxLength(50).IsRequired(true);
            builder.Property(e => e.PaisDestino).HasMaxLength(50).IsRequired(true);
            builder.Property(e => e.PaisNacimiento).HasMaxLength(50).IsRequired(true);
            builder.Property(e => e.PaisOrigen).HasMaxLength(50).IsRequired(true);
            builder.Property(e => e.PaisResidencia).HasMaxLength(50).IsRequired(true);
            builder.Property(e => e.PuertoRegistro).HasMaxLength(150).IsRequired(true);
            builder.Property(e => e.TarjetaAndina).HasMaxLength(50).IsRequired(true);
            builder.Property(e => e.TiempoDeclarado).HasMaxLength(50).IsRequired(true);
            builder.Property(e => e.TipoDocumentoMovMigra).HasMaxLength(50).IsRequired(true);
            builder.Property(e => e.TipoMovimiento).HasMaxLength(50).IsRequired(true);
            builder.Property(e => e.Created).IsRequired(true);
            builder.Property(e => e.CreatorId).IsRequired(true);
            builder.Property(e => e.LastModified).IsRequired(true);
            builder.Property(e => e.LastModifierId).IsRequired(true);

        }
    }
}