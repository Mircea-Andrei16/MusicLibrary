using MusicLibrary.Models;

namespace MusicLibrary.Repositories.Interfaces
{
    public interface IGenreRepository: IBaseRepository<Genre>
    {
       IQueryable<Genre> FindByCondition(String GenreType);
    }
}