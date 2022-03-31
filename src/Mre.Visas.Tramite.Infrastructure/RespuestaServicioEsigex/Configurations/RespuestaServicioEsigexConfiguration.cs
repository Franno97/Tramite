using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Mre.Visas.Tramite.Domain.Entities;

namespace Mre.Visas.Tramite.Infrastructure.RespuestaServicioEsigex.Configuratios
{
  public class SolicitudVisaEsigexConfiguration : IEntityTypeConfiguration<SolicitudVisaEsigex>
  {
    public void Configure(EntityTypeBuilder<SolicitudVisaEsigex> builder)
    {
      builder.ToTable("SolicitudVisaEsigex");

      builder.HasKey(e => e.Id);

      builder.Property(e => e.Id).IsRequired(true);
      builder.Property(e => e.IdSecuencialActuacion);
      builder.Property(e => e.IdTramiteSolicitud);
      builder.Property(e => e.NumeroTramite);
      builder.Property(e => e.NumeroVisaEsigex);
      builder.Property(e => e.Valor );
      builder.Property(e => e.Codigo);
      builder.Property(e => e.CodigoDescripcion);
      builder.Property(e => e.IdPersona);

      builder.Property(e => e.Created)
      .IsRequired(true);

      builder.Property(e => e.CreatorId)
      .IsRequired(true);

      builder.Property(e => e.LastModified)
      .IsRequired(true);

      builder.Property(e => e.LastModifierId)
      .IsRequired(true);
    }
  }

  public class VisaEsigexConfiguration : IEntityTypeConfiguration<VisaEsigex>
  {
    public void Configure(EntityTypeBuilder<VisaEsigex> builder)
    {
      builder.ToTable("VisaEsigex");

      builder.HasKey(e => e.Id);

      builder.Property(e => e.Id).IsRequired(true);
      builder.Property(e => e.IdTramiteVisa);
      builder.Property(e => e.NumeroTramite);
      builder.Property(e => e.Valor);
      builder.Property(e => e.Codigo);
      builder.Property(e => e.CodigoDescripcion);

      builder.Property(e => e.Created)
      .IsRequired(true);

      builder.Property(e => e.CreatorId)
      .IsRequired(true);

      builder.Property(e => e.LastModified)
      .IsRequired(true);

      builder.Property(e => e.LastModifierId)
      .IsRequired(true);
    }
  }

}
