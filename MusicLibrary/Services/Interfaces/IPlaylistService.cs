using MusicLibrary.Models;
using System.Linq.Expressions;

namespace MusicLibrary.Services.Interfaces
{
    public interface IPlaylistService
    {
        IQueryable<Playlist> GetAllPlaylist();

        void Delete(Playlist playlist);

        void Create(Playlist playlist);

        void Update(Playlist playlist);

        IQueryable<Playlist> FindByCondition(Expression<Func<Playlist, bool>> expression);

        void SaveAsync();

    }
}
