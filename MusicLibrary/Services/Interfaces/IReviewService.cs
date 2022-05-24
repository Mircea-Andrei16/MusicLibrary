using MusicLibrary.Models;
using System.Linq.Expressions;

namespace MusicLibrary.Services.Interfaces
{
    public interface IReviewService
    {
        IQueryable<Review> GetAllReviews();

        void Delete(Review review);

        void Create(Review review);

        void Update(Review review);

        IQueryable<Review> FindByCondition(Expression<Func<Review, bool>> expression);

        IQueryable<Song> GetSongs();

        public IQueryable<Review> GetReviewsSongs();

    }
}
