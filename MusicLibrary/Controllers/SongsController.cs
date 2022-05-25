using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MusicLibrary.Models;
using MusicLibrary.Services.Interfaces;

namespace MusicLibrary.Controllers
{
    public class SongsController : Controller
    {
        private readonly ISongService _songService;
        private readonly IPlaylistService _playlistService;
        private readonly IPlaylistSongService _playlistSongService;
        private readonly SongContext _context;

        public SongsController(ISongService _songService, IPlaylistService playlistService, IPlaylistSongService _playlistSongService, SongContext _context)
        {
            this._songService = _songService;
            _playlistService = playlistService;
            this._playlistSongService = _playlistSongService;
            this._context = _context;
        }

        //List all the song in the database
        [Authorize]
        public IActionResult Index(string songName)
        {
            if(songName != null)
            {
                var songs = _songService.GetByCondition(songName);

                return View(songs);
            }
            else
            {
                return View(_songService.GetAllSongs());
            }
        }

        [Authorize(Roles ="User")]
        public IActionResult AddSongPlaylist(Guid id)
        {
            var userId = User.FindFirstValue(ClaimTypes.Email);

            var allPlaylist = _playlistService.FindByCondition(playlist => playlist.UserMail == userId);

            if (allPlaylist.Any())
            {
                PlaylistSong playlistSong = new PlaylistSong{ UserMail = userId, SongId = id};
                _playlistSongService.Create(playlistSong);
                return View(allPlaylist);
            }
            else
            {
                return RedirectToAction("Index");
            }
        }

        [Authorize(Roles = "User")]
        public IActionResult AddPlaylist(Guid id)
        {
            var userId = User.FindFirstValue(ClaimTypes.Email);

            var playlist = _playlistSongService.FindByCondition(playlist => playlist.UserMail == userId);
            PlaylistSong? found = null;
            foreach (PlaylistSong playlistSong in playlist)
            {
                if(playlistSong.PlaylistId == Guid.Empty)
                {
                    found = playlistSong;
                    break;
                }
            }

            if (found != null)
            {
                found.PlaylistId = id;
                _playlistSongService.Update(found);
            }
            return RedirectToAction("Index");
        }

        // GET: Songs/Details/5
        [Authorize(Roles = "User")]
        public IActionResult Details(Guid id)
        {
            var song = _songService.FindByCondition(song => song.SongId == id);

            return View(song);
        }

        // GET: Songs/Create
        [Authorize(Roles = "User")]
        public IActionResult Create()
        {
            ViewData["GenreId"] = new SelectList(_songService.GetGenres(), "GenreId", "Type");
            return View();
        }

        // POST: Songs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize(Roles = "User")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("SongId,Title,Duration,MusicContent,GenreId")] Song song)
        {
            if (ModelState.IsValid)
            {
                _songService.Create(song);
                return RedirectToAction(nameof(Index));
            }
            ViewData["GenreId"] = new SelectList(_songService.GetGenres(), "GenreId", "Type", song.GenreId);
            return View(song);
        }

        // GET: Songs/Edit/5
        [Authorize(Roles = "Admin")]
        public IActionResult Edit(Guid id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var song = _songService.GetAllSongs().FirstOrDefault(song => song.SongId == id);
            if (song == null)
            {
                return NotFound();
            }
            ViewData["GenreId"] = new SelectList(_songService.GetGenres(), "GenreId", "Type", song.GenreId);
            return View(song);
        }

        // POST: Songs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize(Roles = "Admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Guid id, [Bind("SongId,Title,Duration,MusicContent,UserId,GenreId")] Song song)
        {
            if (id != song.SongId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _songService.Update(song);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SongExists(song.SongId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["GenreId"] = new SelectList(_songService.GetGenres(), "GenreId", "Type", song.GenreId);
            return View(song);
        }

        // GET: Songs/Delete/5
        [Authorize(Roles = "Admin")]
        public IActionResult Delete(Guid id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var song = _songService.GetAllSongs()
                .Include(s => s.Genre)
                .FirstOrDefault(m => m.SongId == id);

            if (song == null)
            {
                return NotFound();
            }

            return View(song);
        }

        // POST: Songs/Delete/5
        [Authorize(Roles = "Admin")]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(Guid id)
        {
            var song = _songService.GetAllSongs().FirstOrDefault(song => song.SongId == id);

            if (song != null)
            {
                _songService.Delete(song);
            }

            return RedirectToAction(nameof(Index));
        }

        private bool SongExists(Guid id)
        {
            return _songService.GetAllSongs().Any(song => song.SongId.Equals(id));
        }
    }
}
