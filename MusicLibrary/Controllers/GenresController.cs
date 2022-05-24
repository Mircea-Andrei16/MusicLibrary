using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MusicLibrary.Models;
using MusicLibrary.Services.Interfaces;

namespace MusicLibrary.Controllers
{
    public class GenresController : Controller
    {
        private readonly IGenreService _genreService;

        public GenresController(IGenreService _genreService)
        {
           this._genreService = _genreService;
        }

        [AllowAnonymous]
        // GET: Genres
        public IActionResult Index(string GenreType)
        {
            if (GenreType != null) { 
                var genres = _genreService.FindByCondition(GenreType);

                return View(genres);
            }
            else
            {
                return View(_genreService.GetGenres());
            }

            
        }

        // GET: Genres/Details/5
        [Authorize(Roles = "Admin")]
        public IActionResult Details(Guid id)
        {
            if (id == null )
            {
                return NotFound();
            }

            var genre = _genreService.GetGenres()
                .FirstOrDefault(genre => genre.GenreId == id);

            if (genre == null)
            {
                return NotFound();
            }

            return View(genre);
        }

        [Authorize(Roles = "Admin")]
        public IActionResult Create()
        {
            return View();
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("GenreId,Type,Description")] Genre genre)
        {
            if (ModelState.IsValid)
            {
                _genreService.Create(genre);
                return RedirectToAction(nameof(Index));
            }
            return View(genre);
        }

        // GET: Genres/Edit/5
        [Authorize(Roles = "Admin")]
        public IActionResult Edit(Guid id)
        {
            var genre = _genreService.GetGenres().FirstOrDefault(genre => genre.GenreId == id);
            
            if (genre == null)
            {
                return NotFound();
            }
            return View(genre);
        }

        // POST: Genres/Edit/5
        [Authorize(Roles = "Admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Guid id, [Bind("GenreId,Type,Description")] Genre genre)
        {
            if (id != genre.GenreId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _genreService.Update(genre);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!GenreExists(genre.GenreId))
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
            return View(genre);
        }

        // GET: Genres/Delete/5
        [Authorize(Roles = "Admin")]
        public IActionResult Delete(Guid id)
        {
            var genre = _genreService.GetGenres().FirstOrDefault(genre => genre.GenreId == id);
            
            if (genre == null)
            {
                return NotFound();
            }

            return View(genre);
        }

        // POST: Genres/Delete/5
        [Authorize(Roles = "Admin")]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(Guid id)
        {
            var genre = _genreService.GetGenres().FirstOrDefault(genre => genre.GenreId == id);
            
            if (genre != null)
            {
                _genreService.Delete(genre);
            }
            
            return RedirectToAction(nameof(Index));
        }

        private bool GenreExists(Guid id)
        {
          return _genreService.GetGenres().Any(genre => id == genre.GenreId);
        }
    }
}
