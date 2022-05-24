using Microsoft.EntityFrameworkCore;
using MusicLibrary.Models;
using MusicLibrary.Repositories.Interfaces;
using System.Linq.Expressions;

namespace MusicLibrary.Repositories
{
    public abstract class BaseRepository<T> : IBaseRepository<T> where T : class
    {

        protected SongContext songContext { get; set; }

        public BaseRepository(SongContext songContext)
        {
            this.songContext = songContext;
        }

        public IQueryable<T> FindAll()
        {
            return this.songContext.Set<T>().AsNoTracking();
        }

        public IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression)
        {
            return this.songContext.Set<T>().Where(expression).AsNoTracking();
        }

        public void Create(T entity)
        {
            this.songContext.Set<T>().Add(entity);
        }

        public void Update(T entity)
        {
            this.songContext.Set<T>().Update(entity);
        }

        public void Delete(T entity)
        {
            this.songContext.Set<T>().Remove(entity);
        }

        public void SaveAsync()
        {
           songContext.SaveChanges();
        }
    }
}
