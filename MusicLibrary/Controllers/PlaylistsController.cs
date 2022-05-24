using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MusicLibrary.Models;
using MusicLibrary.Services.Interfaces;

namespace MusicLibrary.Controllers
{
    public class PlaylistsController : Controller
    {
        private readonly IPlaylistService playlistService;

        public PlaylistsController(IPlaylistService playlistService)
        {
            this.playlistService = playlistService;
        }

        // GET: Playlists
        public async Task<IActionResult> Index()
        {
           var playlists = playlistService.GetAllPlaylist();

           return View(playlists);
        }

        // GET: Playlists/Details/5
        public async Task<IActionResult> Details(Guid id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var playlist = await playlistService.GetAllPlaylist()
            .FirstOrDefaultAsync(m => m.PlaylistId == id);

            if (playlist == null)
            {
                return NotFound();
            }

            return View(playlist);
        }

        // GET: Playlists/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Playlists/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("PlaylistId,PlaylistName,NumberOfSongs,TotalTime")] Playlist playlist)
        {
            if (ModelState.IsValid)
            {
               playlistService.Create(playlist);
                playlistService.SaveAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(playlist);
        }

        // GET: Playlists/Edit/5
        public async Task<IActionResult> Edit(Guid id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var playlist = await playlistService.GetAllPlaylist().FirstOrDefaultAsync(playlist => playlist.PlaylistId == id);
            if (playlist == null)
            {
                return NotFound();
            }
            return View(playlist);
        }

        // POST: Playlists/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("PlaylistId,PlaylistName,NumberOfSongs,TotalTime,UserId")] Playlist playlist)
        {
            if (id != playlist.PlaylistId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                   playlistService.Update(playlist);
                    playlistService.SaveAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PlaylistExists(playlist.PlaylistId))
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
            return View(playlist);
        }

        // GET: Playlists/Delete/5
        public async Task<IActionResult> Delete(Guid id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var playlist = await playlistService.GetAllPlaylist()
                .FirstOrDefaultAsync(m => m.PlaylistId == id);
            if (playlist == null)
            {
                return NotFound();
            }

            return View(playlist);
        }

        // POST: Playlists/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(Guid id)
        {
            
            var playlist =  playlistService.GetAllPlaylist().FirstOrDefault(m => m.PlaylistId == id);
            
            if (playlist != null)
            {
                playlistService.Delete(playlist);
            }
            
            playlistService.SaveAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PlaylistExists(Guid id)
        {
            return playlistService.GetAllPlaylist().Any(m => m.PlaylistId == id);
        }
    }
}
