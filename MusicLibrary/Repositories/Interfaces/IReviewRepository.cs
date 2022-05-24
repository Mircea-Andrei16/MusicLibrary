using MusicLibrary.Models;

namespace MusicLibrary.Repositories.Interfaces
{
    public interface IReviewRepository: IBaseRepository<Review>
    {
        public IQueryable<Review> GetReviewsSongs();
    }
}