using Data.Core;
using Data.Repository.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using System.Linq.Expressions;

namespace Data.Repository
{
    public abstract class Repository<T> : IDisposable, IRepository<T> where T : class
    {
        protected readonly IContext _context;

        protected Repository(IContext context)
        {
            _context = context;
        }

        public DbSet<T> Entity()
        {
            return _context.Set<T>();
        }

        public T Get(Expression<Func<T, bool>> predicate)
        {
            return _context.Set<T>().FirstOrDefault(predicate);
        }

        public T GetAsNoTracking(Expression<Func<T, bool>> predicate)
        {
            return _context.Set<T>().AsNoTracking().FirstOrDefault(predicate);
        }

        public Task<T> GetAsync(Expression<Func<T, bool>> predicate)
        {
            return _context.Set<T>().FirstOrDefaultAsync(predicate);
        }

        public Task<T> GetAsNoTrackingAsync(Expression<Func<T, bool>> predicate)
        {
            return _context.Set<T>().AsNoTracking().FirstOrDefaultAsync(predicate);
        }

        public IEnumerable<T> List()
        {
            return _context.Set<T>();
        }

        public IEnumerable<T> List(Expression<Func<T, bool>> predicate)
        {
            return _context.Set<T>().Where(predicate);
        }

        public IEnumerable<T> ListAsNoTracking()
        {
            return _context.Set<T>().AsNoTracking();
        }

        public IEnumerable<T> ListAsNoTracking(Expression<Func<T, bool>> predicate)
        {
            return _context.Set<T>().AsNoTracking().Where(predicate);
        }

        public async Task<List<T>> ListAsync()
        {
            return await _context.Set<T>().ToListAsync();
        }

        public async Task<List<T>> ListAsync(Expression<Func<T, bool>> predicate)
        {
            return await _context.Set<T>().Where(predicate).ToListAsync();
        }

        public async Task<List<T>> ListAsNoTrackingAsync()
        {
            return await _context.Set<T>().AsNoTracking().ToListAsync();
        }

        public Task<List<T>> ListAsNoTrackingAsync(Expression<Func<T, bool>> predicate)
        {
            return _context.Set<T>().AsNoTracking().Where(predicate).ToListAsync();
        }

        public T Add(T obj)
        {
            return _context.Add(obj).Entity;
        }

        public void AddRange(IEnumerable<T> obj)
        {
            try
            {
                _context.AddRange(obj);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void Update(T obj)
        {
            _context.Entry(obj).State = EntityState.Modified;
        }

        public T Delete(T obj)
        {
            return _context.Remove(obj).Entity;
        }


        public bool SaveChanges()
        {
            var saved = _context.SaveChanges();

            return saved > 0;
        }

        public async Task<bool> SaveChangesAsync()
        {
            var saved = await _context.SaveChangesAsync();

            return saved > 0;
        }


        public void BeginTransaction()
        {
            _context.Database
                    .BeginTransaction()
                    .GetDbTransaction();
        }

        public void Commit()
        {
            _context.Database.CommitTransaction();
        }

        public void Rollback()
        {
            _context.Database.RollbackTransaction();
        }


        public void Dispose()
        {
            _context?.Dispose();
        }
    }
}
