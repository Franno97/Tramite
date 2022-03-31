using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mre.Visas.Tramite.Infrastructure.OrdenCedulacion.Configurations
{
    public class OrdenCedulacionConfiguration : IEntityTypeConfiguration<Domain.Entities.OrdenCedulacion>
    {
        public void Configure(EntityTypeBuilder<Domain.Entities.OrdenCedulacion> builder)
        {
            builder.ToTable("OrdenesCedulacion");

            builder.HasKey(e => e.Id);

            builder.Property(e => e.Id)
                .IsRequired(true);

            builder.Property(e => e.PersonaId)
                .IsRequired(true);

            builder.Property(e => e.UnidadAdministrativaId)
                .IsRequired(true);

            builder.Property(e => e.TipoVisaCodigo)
                .HasMaxLength(50)
                .IsRequired(true);

            builder.Property(e => e.TipoVisa)
                .HasMaxLength(50)
                .IsRequired(true);

            builder.Property(e => e.Numero)
                .HasMaxLength(100)
                .IsRequired(true);

            builder.Property(e => e.CodigoVerificacion)
                .HasMaxLength(100)
                .IsRequired(true);

            builder.Property(e => e.Nombres)
                .HasMaxLength(80)
                .IsRequired(true);

            builder.Property(e => e.PrimerApellido)
                .HasMaxLength(80)
                .IsRequired(true);

            builder.Property(e => e.SegundoApellido)
                .HasMaxLength(80)
                .IsRequired(true);

            builder.Property(e => e.NacionalidadId)
                .HasMaxLength(50)
                .IsRequired(true);

            builder.Property(e => e.Nacionalidad)
                .HasMaxLength(50)
                .IsRequired(true);

            builder.Property(e => e.PaisNacimiento)
                .HasMaxLength(50)
                .IsRequired(true);

            builder.Property(e => e.CiudadNacimiento)
                .HasMaxLength(50)
                .IsRequired(true);

            builder.Property(e => e.Sexo)
                .HasMaxLength(50)
                .IsRequired(true);

            builder.Property(e => e.EstadoCivil)
                .HasMaxLength(80)
                .IsRequired(true);

            builder.Property(e => e.ConyugeNombres)
                .HasMaxLength(80);

            builder.Property(e => e.ConyugePrimerApellido)
                .HasMaxLength(80);

            builder.Property(e => e.ConyugeSegundoApellido)
                .HasMaxLength(80);

            builder.Property(e => e.ConyugeNacionalidadCodigo)
                .HasMaxLength(50);

            builder.Property(e => e.ConyugeNacionalidad)
                .HasMaxLength(80);

            builder.Property(e => e.ConyugeCorreoElectronico)
                .HasMaxLength(50);

            builder.Property(e => e.CategoriaVisa)
                .HasMaxLength(50)
                .IsRequired(true);

            builder.Property(e => e.NumeroVisa)
                .HasMaxLength(50)
                .IsRequired(true);

            builder.Property(e => e.TiempoVigenciaVisa)
                .IsRequired(true);

            builder.Property(e => e.UnidadOtorgamientoVisa)
                .HasMaxLength(80)
                .IsRequired(true);

            builder.Property(e => e.SignatarioUsuarioId);

            builder.Property(e => e.SignatarioNombre)
                .HasMaxLength(80);

            builder.Property(e => e.SignatarioApellido)
                .HasMaxLength(80);

            builder.Property(e => e.SignatarioCargo)
                .HasMaxLength(50);

            builder.Property(e => e.SignatarioCiudad)
                .HasMaxLength(50);


            ///
            builder.Property(e => e.TramiteId)
                .IsRequired(true);

            builder.Property(e => e.PagoId)
                .IsRequired(true);

            builder.Property(e => e.IdTramiteEsigex)
                .HasMaxLength(100);

            builder.Property(e => e.NumeroTramiteEsigex)
                .HasMaxLength(100);

            builder.Property(e => e.SecuencialActuacion)
                .HasMaxLength(100);

            builder.Property(e => e.RutaAlmacenamientoFactura)
                .HasMaxLength(256);

            builder.Property(e => e.RutaAlmacenamientoOrdenCedulacion)
                .HasMaxLength(256);

            builder.Property(e => e.ClaveAccesoFactura)
                .HasMaxLength(50);


            //Indices
            builder.HasIndex(e => e.TramiteId).IsUnique();

        }
    }
}
