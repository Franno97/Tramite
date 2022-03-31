using Microsoft.EntityFrameworkCore;
using Mre.Visas.Tramite.Application.Shared.Repositories;
using Mre.Visas.Tramite.Infrastructure.Persistence.Contexts;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Mre.Visas.Tramite.Infrastructure.Shared.Repositories
{
  public class Repository<T> : IRepository<T> where T : class
  {
    #region Constructors

    public Repository(ApplicationDbContext context)
    {
      _context = context;
    }

    #endregion Constructors

    #region Attributes

    protected readonly ApplicationDbContext _context;

    #endregion Attributes

    #region Methods

    public async Task<(bool, string)> DeleteAsync(Guid id)
    {
      var entity = await GetByIdAsync(id).ConfigureAwait(false);
      if (entity is null)
      {
        return (false, null);
      }

      try
      {
        _context.Set<T>().Remove(entity);

        return (true, null);
      }
      catch (Exception ex)
      {
        return (false, ex.InnerException is null ? ex.Message : ex.InnerException.Message);
      }
    }

    public async Task<IEnumerable<T>> GetAllAsync()
    {
      return await _context.Set<T>()
          .AsNoTracking()
          .ToArrayAsync()
          .ConfigureAwait(false);
    }

    public async Task<T> GetByIdAsync(Guid id)
    {
      return await _context.Set<T>()
          .FindAsync(id)
          .ConfigureAwait(false);
    }

    public async Task<(bool, string)> InsertAsync(T entity)
    {
      //var transaction = _context.Database.BeginTransaction();
      try
      {
        await _context.Set<T>()
                    .AddAsync(entity)
                    .ConfigureAwait(false);
        //transaction.Commit();
        return (true, null);
      }
      catch (Exception ex)
      {
        //transaction.Rollback();
        return (false, ex.InnerException is null ? ex.Message : ex.InnerException.Message);
      }
    }

    public async Task<(bool, string)> InsertRangeAsync(IReadOnlyCollection<T> entities)
    {
      try
      {
        await _context.Set<T>()
            .AddRangeAsync(entities)
            .ConfigureAwait(false);

        return (true, null);
      }
      catch (Exception ex)
      {
        return (false, ex.InnerException is null ? ex.Message : ex.InnerException.Message);
      }
    }

    public (bool, string) Update(T entity)
    {
      try
      {
        _context.Entry(entity).State = EntityState.Modified;

        return (true, null);
      }
      catch (Exception ex)
      {
        return (false, ex.InnerException is null ? ex.Message : ex.InnerException.Message);
      }
    }

    public void BeginTransaction()
    {
      try
      {
         _context.Database.BeginTransaction();
      }
      catch
      {
        throw;
      }
    }
    public void CommitTransaction()
    {
      try
      {
        _context.Database.CommitTransaction();
      }
      catch
      {
        throw;
      }
    }
    public void RollbackTransaction()
    {
      try
      {
        _context.Database.RollbackTransaction();
      }
      catch
      {
        throw;
      }
    }
    #endregion Methods
  }
}