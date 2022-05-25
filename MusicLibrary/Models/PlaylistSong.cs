namespace MusicLibrary.Models
{
    public class PlaylistSong
    {
        public Guid PlaylistSongId { get; set; }

        public Guid SongId { get; set; }

        public Guid PlaylistId { get; set; }

        public string? UserMail { get; set; }
    }
}
