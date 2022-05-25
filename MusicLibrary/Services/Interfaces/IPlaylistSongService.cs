using MusicLibrary.Models;
using System.Linq.Expressions;

namespace MusicLibrary.Services.Interfaces
{
    public interface IPlaylistSongService
    {
        IQueryable<PlaylistSong> GetAllPlaylistSongs();

        void Delete(PlaylistSong playlistSong);

        void Create(PlaylistSong playlistSong);

        void Update(PlaylistSong playlistSong);

        IQueryable<PlaylistSong> FindByCondition(Expression<Func<PlaylistSong, bool>> expression);

        void SaveChanges();

        public void removeAll(PlaylistSong playlistSong);
    }
}
