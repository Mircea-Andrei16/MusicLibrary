namespace MusicLibrary.Models
{
    public class Playlist
    {
        public Guid PlaylistId { get; set; }

        public string? PlaylistName { get; set; }

        public int? NumberOfSongs { get; set; }

        public int? TotalTime { get; set; }
    }
}
