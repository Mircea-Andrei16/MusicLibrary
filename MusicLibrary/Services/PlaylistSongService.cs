using MusicLibrary.Models;
using MusicLibrary.Repositories.Interfaces;
using MusicLibrary.Services.Interfaces;
using System.Linq.Expressions;

namespace MusicLibrary.Services
{
    public class PlaylistSongService : IPlaylistSongService
    {
        private readonly IRepositoryWrapper _repository;

        public PlaylistSongService(IRepositoryWrapper repositoryWrapper)
        {
            _repository = repositoryWrapper;
        }

        public void Create(PlaylistSong playlistSong)
        {
            _repository.PlaylistSongRepository.Create(playlistSong);
            _repository.Save();
        }

        public void Delete(PlaylistSong playlistSong)
        {
            _repository.PlaylistSongRepository.Delete(playlistSong);
            _repository.Save();
        }

        public IQueryable<PlaylistSong> FindByCondition(Expression<Func<PlaylistSong, bool>> expression)
        {
            return _repository.PlaylistSongRepository.FindByCondition(expression);
        }

        public IQueryable<PlaylistSong> GetAllPlaylistSongs()
        {
            return _repository.PlaylistSongRepository.FindAll();
        }

        public void SaveChanges()
        {
           _repository.PlaylistSongRepository.SaveAsync();
        }

        public void Update(PlaylistSong playlistSong)
        {
            _repository.PlaylistSongRepository.Update(playlistSong);
            _repository.Save();
        }
    }
}
