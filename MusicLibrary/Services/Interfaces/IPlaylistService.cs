using MusicLibrary.Models;

namespace MusicLibrary.Services.Interfaces
{
    public interface IPlaylistService
    {
        IQueryable<Playlist> GetAllPlaylist();

        void Delete(Playlist playlist);

        void Create(Playlist playlist);

        void Update(Playlist playlist);

        IQueryable<Playlist> FindByCondition();

        void SaveAsync();

    }
}
