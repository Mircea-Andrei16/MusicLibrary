using MusicLibrary.Models;

namespace MusicLibrary.Repositories.Interfaces
{
    public class PlaylistSongRepository:BaseRepository<PlaylistSong>, IPlaylistSongRepository
    {
        public PlaylistSongRepository(SongContext songContext) : base(songContext)
        {

        }
    }
}
