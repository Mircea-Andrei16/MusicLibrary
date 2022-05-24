using MusicLibrary.Models;
using MusicLibrary.Repositories.Interfaces;
using MusicLibrary.Services.Interfaces;
using System.Linq.Expressions;

namespace MusicLibrary.Services
{
    public class ReviewService : IReviewService
    {
        private readonly IRepositoryWrapper repositoryWrapper;

        public ReviewService(IRepositoryWrapper repositoryWrapper)
        {
            this.repositoryWrapper = repositoryWrapper;
        }

        public void Create(Review review)
        {
            repositoryWrapper.ReviewRepository.Create(review);
            repositoryWrapper.Save();
        }

        public void Delete(Review review)
        {
            repositoryWrapper.ReviewRepository.Delete(review);
            repositoryWrapper.Save();
        }

        public IQueryable<Review> FindByCondition(Expression<Func<Review, bool>> expression)
        {
            return repositoryWrapper.ReviewRepository.FindByCondition(expression);
        }

        public IQueryable<Review> GetAllReviews()
        {
           return repositoryWrapper.ReviewRepository.FindAll();
        }

        public IQueryable<Review> GetReviewsSongs()
        {
            return repositoryWrapper.ReviewRepository.GetReviewsSongs();
        }

        public IQueryable<Song> GetSongs()
        {
           return repositoryWrapper.SongRepository.FindAll();
        }

        public void Update(Review review)
        {
           repositoryWrapper.ReviewRepository.Update(review);
            repositoryWrapper.Save();
        }
    }
}
