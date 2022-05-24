using System.Linq.Expressions;

namespace MusicLibrary.Repositories.Interfaces
{
    public interface IBaseRepository<T>
    {
        IQueryable<T> FindAll();
        IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression);
        void Create(T entity);
        void Update(T entity);
        void Delete(T entity);
        void SaveAsync();
    }
}
