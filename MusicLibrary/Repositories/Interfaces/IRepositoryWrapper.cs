namespace MusicLibrary.Repositories.Interfaces
{
    public interface IRepositoryWrapper
    {
        ISongRepository SongRepository { get; }

        IGenreRepository GenreRepository { get; }

        IReviewRepository ReviewRepository { get; }

        IPlaylistRepository PlaylistRepository { get; }

        IPlaylistSongRepository PlaylistSongRepository { get; }

        void Save();
    }
}
