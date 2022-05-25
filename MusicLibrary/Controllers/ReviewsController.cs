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
    public class ReviewsController : Controller
    {
        private readonly IReviewService _reviewService;
        private readonly ISongService _songService;
        public ReviewsController(IReviewService _reviewService, ISongService _songService)
        {
            this._reviewService = _reviewService;
            this._songService = _songService;
        }

        // GET: Reviews
        public IActionResult Index()
        {
            var songContext = _reviewService.GetReviewsSongs();
               
            return View(songContext);

        }

        // GET: Reviews/Details/5
        public async Task<IActionResult> Details(Guid id)
        {
            var review = _reviewService.GetAllReviews().Include(r => r.Song).FirstOrDefault(review => review.ReviewId == id);
            if (review == null)
            {
                return NotFound();
            }

            return View(review);
        }

        // GET: Reviews/Create
        public IActionResult Create(Guid id)
        {
            ViewData["SongId"] = new SelectList(_songService.FindByCondition(song => song.SongId == id), "SongId", "Title");

            return View();
        }

        // POST: Reviews/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ReviewId,Text,Grade,DateCreated,SongId")] Review review)
        {
            if (ModelState.IsValid)
            {
                _reviewService.Create(review);
                return RedirectToAction(nameof(Index));
            }
            ViewData["SongId"] = new SelectList(_reviewService.GetSongs(), "SongId", "SongId", review.SongId);
            return View(review);
        }

        // GET: Reviews/Edit/5
        public async Task<IActionResult> Edit(Guid id)
        {
            var review = _reviewService.GetAllReviews().FirstOrDefault(review => review.ReviewId == id);
            if (review == null)
            {
                return NotFound();
            }

            ViewData["SongId"] = new SelectList(_reviewService.GetSongs(), "SongId", "SongId", review.SongId);
            return View(review);
        }

        // POST: Reviews/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("ReviewId,Text,Grade,DateCreated,SongId")] Review review)
        {
            if (id != review.ReviewId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _reviewService.Update(review);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ReviewExists(review.ReviewId))
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
            ViewData["SongId"] = new SelectList(_reviewService.GetSongs(), "SongId", "SongId", review.SongId);
            return View(review);
        }

        // GET: Reviews/Delete/5
        public async Task<IActionResult> Delete(Guid id)
        {
            var review = await _reviewService.GetAllReviews()
                .Include(r => r.Song)
                .FirstOrDefaultAsync(m => m.ReviewId == id);
           
            if (review == null)
            {
                return NotFound();
            }

            return View(review);
        }

        // POST: Reviews/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var review = await _reviewService.GetAllReviews().FirstOrDefaultAsync(review => review.ReviewId == id);
            
            if (review != null)
            {
                _reviewService.Delete(review);
            }

            return RedirectToAction(nameof(Index));
        }

        private bool ReviewExists(Guid id)
        {
            return (_reviewService.GetAllReviews().Any(e => e.ReviewId == id));
        }
    }
}
