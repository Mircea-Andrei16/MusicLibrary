namespace MusicLibrary.Models
{
    public class Genre
    {
        public Guid GenreId { get; set; }

        public string? Type { get; set; }

        public string? Description { get; set; }

        public ICollection<Song>? Songs { get; set; }
    }
}
