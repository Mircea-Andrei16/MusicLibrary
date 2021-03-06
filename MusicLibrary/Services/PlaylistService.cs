using MusicLibrary.Models;
using MusicLibrary.Repositories.Interfaces;
using MusicLibrary.Services.Interfaces;
using System.Linq.Expressions;

namespace MusicLibrary.Services
{
    public class PlaylistService : IPlaylistService
    {
        private readonly IRepositoryWrapper RepositoryWrapper;

        public PlaylistService(IRepositoryWrapper repositoryWrapper)
        {
            RepositoryWrapper = repositoryWrapper;
        }

        public void Create(Playlist playlist)
        {
           RepositoryWrapper.PlaylistRepository.Create(playlist);
        }

        public void Delete(Playlist playlist)
        {
            RepositoryWrapper.PlaylistRepository.Delete(playlist);
        }

        public IQueryable<Playlist> FindByCondition(Expression<Func<Playlist, bool>> expression)
        {
           return RepositoryWrapper.PlaylistRepository.FindByCondition(expression);
        }

        public IQueryable<Playlist> GetAllPlaylist()
        {
            return RepositoryWrapper.PlaylistRepository.FindAll();
        }

        public void SaveAsync()
        {
            RepositoryWrapper.PlaylistRepository.SaveAsync();
        }

        public void Update(Playlist playlist)
        {
            RepositoryWrapper.PlaylistRepository.Update(playlist);
        }
    }
}
