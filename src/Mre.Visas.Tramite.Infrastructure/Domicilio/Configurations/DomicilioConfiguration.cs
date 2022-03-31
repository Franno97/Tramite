using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Mre.Visas.Tramite.Infrastructure.Domicilio.Configurations
{
    public class DomicilioConfiguration : IEntityTypeConfiguration<Domain.Entities.Domicilio>
    {
        public void Configure(EntityTypeBuilder<Domain.Entities.Domicilio> builder)
        {
            builder.ToTable("Domicilios");

            builder.HasKey(e => e.Id);

            builder.Property(e => e.Ciudad)
                .HasMaxLength(50)
                .IsRequired(true);

            builder.Property(e => e.Direccion)
                .HasMaxLength(int.MaxValue)
                .IsRequired(true);

            builder.Property(e => e.Id)
                .IsRequired(true);

            builder.Property(e => e.Pais)
                .HasMaxLength(50)
                .IsRequired(true);

            builder.Property(e => e.Provincia)
                .HasMaxLength(50)
                .IsRequired(true);

            builder.Property(e => e.TelefonoCelular)
                .HasMaxLength(50)
                .IsRequired(true);

            builder.Property(e => e.TelefonoDomicilio)
                .HasMaxLength(50)
                .IsRequired(true);

            builder.Property(e => e.TelefonoTrabajo)
                .HasMaxLength(50)
                .IsRequired(true);
        }
    }
}