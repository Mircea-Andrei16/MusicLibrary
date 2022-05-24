using MusicLibrary.Models;
using MusicLibrary.Repositories.Interfaces;
using MusicLibrary.Services.Interfaces;
using System.Linq.Expressions;

namespace MusicLibrary.Services
{
    public class SongService: ISongService
    {

        private IRepositoryWrapper _repository;

        public SongService(IRepositoryWrapper repositoryWrapper)
        {
            _repository = repositoryWrapper;
        }

        public void Create(Song song)
        {
           _repository.SongRepository.Create(song);
           _repository.Save();
        }

        public void Delete(Song song)
        {
           _repository.SongRepository.Delete(song);
           _repository.Save();
        }

        public IQueryable<Song> GetByCondition(string songName)
        {
            var findGenre = _repository.SongRepository.GetByCondition(songName);


            return findGenre;
        }

        public IQueryable<Song> GetAllSongs()
        {
            return _repository.SongRepository.FindAll();
        }

        public void Update(Song song)
        {
            _repository.SongRepository.Update(song);
            _repository.Save();
        }

        public IEnumerable<Genre> GetGenres()
        {
            return _repository.GenreRepository.FindAll();
        }

        public IQueryable<Song> FindByCondition(Expression<Func<Song, bool>> expression)
        {
            return _repository.SongRepository.FindByCondition(expression);
        }
    }
}
