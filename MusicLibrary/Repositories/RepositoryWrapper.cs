using MusicLibrary.Models;
using MusicLibrary.Repositories.Interfaces;

namespace MusicLibrary.Repositories
{

    public class RepositoryWrapper : IRepositoryWrapper 
    { 

        private SongContext _songContext;
        private IGenreRepository? _genreRepository;
        private IPlaylistRepository? _playlistRepository;
        private ISongRepository? _songRepository;
        private IReviewRepository? _reviewRepository;


        public IPlaylistRepository PlaylistRepository
        {
            get 
            { 
                if(_playlistRepository == null)
                {
                    _playlistRepository = new PlaylistRepository(_songContext);
                }

                return _playlistRepository;
            }
        }

        public ISongRepository SongRepository
        {
            get 
            { 
                if(_songRepository == null)
                {
                    _songRepository = new SongRepository(_songContext);
                }

                return _songRepository; 
            }
        }

        public IReviewRepository ReviewRepository
        {
            get 
            {
                if(_reviewRepository == null)
                {
                    _reviewRepository = new ReviewRepository(_songContext);
                }

                return _reviewRepository; 
            }
        }

        public  IGenreRepository GenreRepository
        {
            get 
            { 
                if(_genreRepository == null)
                {
                    _genreRepository = new GenreRepository(_songContext);
                }

                return _genreRepository; 
            }
        }

        public RepositoryWrapper(SongContext songContext)
        {
            this._songContext = songContext;    
        }

        public void Save()
        {
            _songContext.SaveChanges();
        }
    }
}
