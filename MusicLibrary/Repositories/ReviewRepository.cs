using Microsoft.EntityFrameworkCore;
using MusicLibrary.Models;
using MusicLibrary.Repositories.Interfaces;

namespace MusicLibrary.Repositories
{
    public class ReviewRepository : BaseRepository<Review>, IReviewRepository
    {
        public ReviewRepository(SongContext songContext) : base(songContext)
        {
           
        }

        public IQueryable<Review> GetReviewsSongs()
        {
            return songContext.Review.Include(m => m.Song);
        }
    }
}
