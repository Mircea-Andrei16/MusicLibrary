using MusicLibrary.Models;
using System.Linq.Expressions;

namespace MusicLibrary.Services.Interfaces
{
    public interface ISongService
    {
        IQueryable<Song> GetAllSongs();

        void Delete(Song song);

        void Create(Song song);

        void Update(Song song);

        IQueryable<Song> GetByCondition(string songName);

        IQueryable<Song> FindByCondition(Expression<Func<Song, bool>> expression);

        IEnumerable<Genre> GetGenres();
    }
}
