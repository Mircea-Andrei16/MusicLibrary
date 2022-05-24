using MusicLibrary.Models;
using MusicLibrary.Repositories.Interfaces;

namespace MusicLibrary.Repositories
{
    public class SongRepository : BaseRepository<Song>, ISongRepository
    {
        public SongRepository(SongContext songContext) : base(songContext)
        {
        }

        public IQueryable<Song> GetByCondition(string songName)
        {
            if (!string.IsNullOrEmpty(songName) == true)
            {
                return songContext.Song.Where(song => song.Title == songName );
            }
            else
            {
                return FindAll();
            }
        }
    }
}
