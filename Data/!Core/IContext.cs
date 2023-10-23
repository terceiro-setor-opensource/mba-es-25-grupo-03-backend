using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Infrastructure;
using System.Diagnostics.CodeAnalysis;

namespace Data.Core
{
    public interface IContext : IDisposable, IAsyncDisposable
    {
        DatabaseFacade Database { get; }

        EntityEntry Entry([NotNull] object entity);

        EntityEntry<TEntity> Entry<TEntity>([NotNull] TEntity entity) where TEntity : class;

        EntityEntry Add([NotNull] object entity);

        void AddRange([NotNull] IEnumerable<object> entities);

        EntityEntry<TEntity> Add<TEntity>([NotNull] TEntity entity) where TEntity : class;

        int SaveChanges();

        int SaveChanges(bool acceptAllChangesOnSuccess);
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);

        DbSet<TEntity> Set<TEntity>() where TEntity : class;

        DbSet<TEntity> Set<TEntity>([NotNull] string name) where TEntity : class;

        EntityEntry Update([NotNull] object entity);

        EntityEntry<TEntity> Remove<TEntity>([NotNull] TEntity entity) where TEntity : class;
    }
}
