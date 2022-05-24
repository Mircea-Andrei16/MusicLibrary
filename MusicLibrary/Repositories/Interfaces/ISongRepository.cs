using MusicLibrary.Models;

namespace MusicLibrary.Repositories.Interfaces
{
    public interface ISongRepository: IBaseRepository<Song>
    {
        IQueryable<Song> GetByCondition(String songName);
    }
}