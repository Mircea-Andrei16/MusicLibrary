using MusicLibrary.Models;
using MusicLibrary.Repositories.Interfaces;

namespace MusicLibrary.Repositories
{
    public class GenreRepository : BaseRepository<Genre>, IGenreRepository
    {
        public GenreRepository(SongContext songContext) : base(songContext)
        {
        }

        public IQueryable<Genre> FindByCondition(String GenreType)
        {
            if(!string.IsNullOrEmpty(GenreType) == true)
            {
                return songContext.Genre.Where(genre => genre.Type == GenreType);
            }
            else
            {
                return FindAll();
            }
        }
    }
}
