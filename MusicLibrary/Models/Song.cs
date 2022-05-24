namespace MusicLibrary.Models
{
    public class Song
    {
        public Guid SongId { get; set; }

        public string? Title { get; set; }

        public int? Duration { get; set; }

        public string? MusicContent { get; set; }

        public Guid GenreId { get; set; }

        public Genre? Genre { get; set; }

        public ICollection<Review>? Reviews { get; set; }
    }
}
