using MusicLibrary.Models;

namespace MusicLibrary.Repositories.Interfaces
{
    public interface IPlaylistSongRepository:IBaseRepository<PlaylistSong>
    {
        public void removeAll(PlaylistSong playlistSong);
    }
}
