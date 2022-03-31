using Audit.EntityFramework;
using Microsoft.EntityFrameworkCore;
using Mre.Visas.Tramite.Domain.Entities;
using System;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;

namespace Mre.Visas.Tramite.Infrastructure.Persistence.Contexts
{
  public class ApplicationDbContext : DbContext
  {
    #region Properties

    public DbSet<Domain.Entities.Tramite> Tramites { get; set; }

    public DbSet<Domain.Entities.Movimiento> Movimientos { get; set; }
    public DbSet<Domain.Entities.Beneficiario> Beneficiarios { get; set; }
    public DbSet<Domain.Entities.Solicitante> Solicitantes { get; set; }

    public DbSet<Domain.Entities.RolEstado> RolEstados { get; set; }

    public DbSet<Domain.Entities.CalidadMigratoria> CalidadMigratorias { get; set; }

    public DbSet<Domain.Entities.TipoConvenio> TipoConvenios { get; set; }

    public DbSet<Domain.Entities.TipoVisa> TipoVisas { get; set; }

    public DbSet<Domain.Entities.ActividadDesarrollar> ActividadDesarrollares { get; set; }

    public DbSet<Domain.Entities.Configuracion> Configuraciones { get; set; }

    public DbSet<Domain.Entities.HistorialMigratorio> HistorialMigratorios { get; set; }

    public DbSet<Domain.Entities.OrdenCedulacion> OrdenCedulaciones { get; set; }

    public DbSet<Domain.Entities.ConfiguracionFirmaElectronica> ConfiguracionFirmaElectronicas { get; set; }

    public DbSet<Domain.Entities.SolicitudVisaEsigex> SolicitudesVisaEsigex { get; set; }

    public DbSet<Domain.Entities.VisaEsigex> VisasEsigex { get; set; }

    #endregion Properties

    #region Constructors

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    #endregion Constructors

    #region Methods

    // Configure Db
    //protected override void OnConfiguring(DbContextOptionsBuilder options)
    //{
    //  if (!options.IsConfigured)
    //  {
    //    options.UseSqlServer("Server=172.31.3.34; Database=Mre.Visas.Tramite; User Id=sa; Password=2xUWheya$kR7ZBJew*a5;");
    //    options.UseSqlServer("Server=HP-001; Database=Mre.Visas.Tramite; User Id = sa; Password=Maal2308; Integrated Security = True;");
    //  }
    //}

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
      optionsBuilder.AddInterceptors(new AuditSaveChangesInterceptor());
    }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
      modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

      base.OnModelCreating(modelBuilder);
    }

    public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
    {
      foreach (var entry in ChangeTracker.Entries<AuditableEntity>())
      {
        switch (entry.State)
        {
          case EntityState.Added:
            entry.Entity.Created = DateTime.Now;//DateTime.UtcNow;
            entry.Entity.LastModified = DateTime.Now;
            break;

          case EntityState.Modified:
            entry.Entity.LastModified = DateTime.Now; //DateTime.UtcNow;
            break;
        }
      }

      return base.SaveChangesAsync(cancellationToken);
    }

    #endregion Methods
  }
}