using MusicLibrary.Models;
using MusicLibrary.Repositories.Interfaces;

namespace MusicLibrary.Repositories
{
    public class PlaylistRepository : BaseRepository<Playlist>, IPlaylistRepository
    {
        public PlaylistRepository(SongContext songContext) : base(songContext)
        {
        }
    }
}
