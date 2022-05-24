using MusicLibrary.Models;
using MusicLibrary.Repositories.Interfaces;
using MusicLibrary.Services.Interfaces;

namespace MusicLibrary.Services
{
    public class GenreService: IGenreService
    {
        private readonly IRepositoryWrapper _repository;

        public GenreService(IRepositoryWrapper _repository)
        {
            this._repository = _repository;
        }

        public void Create(Genre genre)
        {
           _repository.GenreRepository.Create(genre);
            _repository.Save();
        }

        public void Delete(Genre genre)
        {
            _repository.GenreRepository.Delete(genre);
            _repository.Save();
        }

        public IQueryable<Genre> FindByCondition(string GenreType)
        {
            var findGenre = _repository.GenreRepository.FindByCondition(GenreType);
            return findGenre;
        }

        public IQueryable<Genre> GetGenres()
        {
            return _repository.GenreRepository.FindAll();
        }


        public void Update(Genre genre)
        {
            _repository.GenreRepository.Update(genre);
            _repository.Save();
        }
    }
}
