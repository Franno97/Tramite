using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mre.Visas.Tramite.Infrastructure.ConfiguracionFirmaElectronica.Configurations
{

    public class ConfiguracionFirmaElectronicaConfiguration : IEntityTypeConfiguration<Domain.Entities.ConfiguracionFirmaElectronica>
    {
        public void Configure(EntityTypeBuilder<Domain.Entities.ConfiguracionFirmaElectronica> builder)
        {
            builder.ToTable("ConfiguracionFirmaElectronica");

            builder.HasKey(e => e.Id);

            builder.Property(e => e.Id)
                .IsRequired(true);

            builder.Property(e => e.ServicioId)
                .IsRequired(true);

            builder.Property(e => e.ServicioNombre)
                .HasMaxLength(80)
                .IsRequired(true);

            builder.Property(e => e.TipoDocumentoCodigo)
                .HasMaxLength(50)
                .IsRequired(true);

            builder.Property(e => e.ModeloFirma)
                .HasMaxLength(8)
                .IsRequired(true);

            builder.Property(e => e.TamanioFirma)
                .IsRequired(true);

            builder.Property(e => e.PosicionX)
                .IsRequired(true);

            builder.Property(e => e.PosicionY)
                .IsRequired(true);

            builder.Property(e => e.NumeroPagina)
                .IsRequired(true);

            builder.HasIndex(e => new { e.ServicioId, e.TipoDocumentoCodigo }).IsUnique();
        }
    }
}
