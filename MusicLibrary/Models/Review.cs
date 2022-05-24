namespace MusicLibrary.Models
{
    public class Review
    {
        public Guid ReviewId { get; set; }
        
        public string? Text { get; set; }

        public int? Grade { get; set; }

        public DateTime? DateCreated { get; set; }

        public Guid SongId { get; set; }

        public Song? Song { get; set; }
    }
}
