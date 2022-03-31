using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Mre.Visas.Tramite.Infrastructure.Catalogo.Configurations
{
  public class CalidadMigratoriaConfiguration : IEntityTypeConfiguration<Domain.Entities.CalidadMigratoria>
  {
    public void Configure(EntityTypeBuilder<Domain.Entities.CalidadMigratoria> builder)
    {
      builder.ToTable("CalidadMigratoria");

      builder.HasKey(e => e.Id);

      builder.Property(e => e.Id)
          .IsRequired(true);

      builder.Property(e => e.CalidadMigratoriaId).IsRequired(true);

      builder.Property(e => e.Descripcion)
          .HasMaxLength(50)
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
  }

  public class TipoConvenioConfiguration : IEntityTypeConfiguration<Domain.Entities.TipoConvenio>
  {
    public void Configure(EntityTypeBuilder<Domain.Entities.TipoConvenio> builder)
    {
      builder.ToTable("TipoConvenio");

      builder.HasKey(e => e.Id);

      builder.Property(e => e.Id)
          .IsRequired(true);

      builder.Property(e => e.TipoConvenioCodigo)
          .HasMaxLength(50)
          .IsRequired(true);

      builder.Property(e => e.Descripcion)
          .HasMaxLength(50)
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

  }

  public class TipoVisaConfiguration : IEntityTypeConfiguration<Domain.Entities.TipoVisa>
  {
    public void Configure(EntityTypeBuilder<Domain.Entities.TipoVisa> builder)
    {
      builder.ToTable("TipoVisa");

      builder.HasKey(e => e.Id);

      builder.Property(e => e.Id)
          .IsRequired(true);

      builder.Property(e => e.ServicioVisasId).IsRequired(true);

      builder.Property(e => e.TipoConvenioCodigo)
          .HasMaxLength(50)
          .IsRequired(true);

      builder.Property(e => e.TipoVisaCodigo)
          .HasMaxLength(50)
          .IsRequired(true);

      builder.Property(e => e.Descripcion)
          .HasMaxLength(50)
          .IsRequired(true);

      builder.Property(e => e.CalidadMigratoriaId).IsRequired(true);
      builder.Property(e => e.NumeroAdmisiones).HasMaxLength(50).IsRequired(true);
      builder.Property(e => e.DiasValidez).IsRequired(true);
      builder.Property(e => e.RequiereAutorizacion).IsRequired(true);
      builder.Property(e => e.Categoria).HasMaxLength(50).IsRequired(true);

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

  public class ActividadDesarrollarConfiguration : IEntityTypeConfiguration<Domain.Entities.ActividadDesarrollar>
  {
    public void Configure(EntityTypeBuilder<Domain.Entities.ActividadDesarrollar> builder)
    {
      builder.ToTable("ActividadDesarrollar");

      builder.HasKey(e => e.Id);

      builder.Property(e => e.Id)
          .IsRequired(true);

      builder.Property(e => e.TipoVisaCodigo)
          .HasMaxLength(50)
          .IsRequired(true);

      builder.Property(e => e.ActividadDesarrollarCodigo)
          .HasMaxLength(50)
          .IsRequired(true);

      builder.Property(e => e.Descripcion)
          .HasMaxLength(50)
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

  }

  public class ConfiguracionConfiguration : IEntityTypeConfiguration<Domain.Entities.Configuracion>
  {
    public void Configure(EntityTypeBuilder<Domain.Entities.Configuracion> builder)
    {
      builder.ToTable("Configuracion");

      builder.HasKey(e => e.Id);

      builder.Property(e => e.Id)
          .IsRequired(true);

      builder.Property(e => e.ConfiguracionCodigo)
          .HasMaxLength(50)
          .IsRequired(true);

      builder.Property(e => e.Descripcion)
          .HasMaxLength(200)
          .IsRequired(true);

      builder.Property(e => e.ValorCadena)
          .HasMaxLength(100)
          .IsRequired(true);

      builder.Property(e => e.ValorFecha)
          .IsRequired(true);

      builder.Property(e => e.ValorEntero)
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

  }

}

//add-migration AddEstadoToTramite -s Mre.Visas.Tramite.Infrastructure
//update-database -s Mre.Visas.Tramite.Infrastructure