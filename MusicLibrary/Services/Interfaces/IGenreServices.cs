using MusicLibrary.Models;

namespace MusicLibrary.Services.Interfaces
{
    public interface IGenreService
    {
        IQueryable<Genre> GetGenres();

        void Delete(Genre genre);

        void Create(Genre genre);

        void Update(Genre genre);

        IQueryable<Genre> FindByCondition(string GenreType);

    }
}
