using System.Linq.Expressions;

namespace Data.Repository.Model
{
    public interface IRepository<T> where T : class
    {
        T Get(Expression<Func<T, bool>> predicate);

        T GetAsNoTracking(Expression<Func<T, bool>> predicate);

        Task<T> GetAsync(Expression<Func<T, bool>> predicate);

        Task<T> GetAsNoTrackingAsync(Expression<Func<T, bool>> predicate);

        IEnumerable<T> List();

        IEnumerable<T> List(Expression<Func<T, bool>> predicate);

        IEnumerable<T> ListAsNoTracking();

        IEnumerable<T> ListAsNoTracking(Expression<Func<T, bool>> predicate);

        Task<List<T>> ListAsync();

        Task<List<T>> ListAsync(Expression<Func<T, bool>> predicate);

        Task<List<T>> ListAsNoTrackingAsync();

        Task<List<T>> ListAsNoTrackingAsync(Expression<Func<T, bool>> predicate);

        T Add(T obj);

        void AddRange(IEnumerable<T> obj);

        void Update(T obj);

        T Delete(T obj);


        public bool SaveChanges();

        public Task<bool> SaveChangesAsync();


        void BeginTransaction();

        void Commit();

        void Rollback();


        void Dispose();
    }
}