using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace MusicLibrary.Models
{
    public class SongContext: IdentityDbContext<IdentityUser>
    {
        public SongContext(DbContextOptions<SongContext> options)
            : base(options)
        { }

        public DbSet<Song> Song { get; set; }
        public DbSet<Genre> Genre { get; set; }
        public DbSet<Playlist> Playlist { get; set; }
        public DbSet<Review> Review { get; set; }
        public DbSet<PlaylistSong> PlaylistSong { get; set; }
    }
}
