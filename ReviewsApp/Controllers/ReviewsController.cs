using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ReviewsApp.Data;
using ReviewsApp.Models;

namespace ReviewsApp.Controllers
{
    public class ReviewsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<IdentityUser> _userManager;

        public ReviewsController(ApplicationDbContext context , UserManager<IdentityUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }


        // GET: Reviews/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var review = await _context.Reviews
                .Include(r => r.CREATEDBY)
                .FirstOrDefaultAsync(m => m.ID == id);

            var reviewViewModel = ReviewViewModel.FromEntity(review);
            reviewViewModel.HasEditAndDeletePermissions = review.CREATEDBY?.Id == _userManager.GetUserId(User);

            if (review == null)
            {
                return NotFound();
            }

            return View(reviewViewModel);
        }

        // GET: Reviews/Create
        [Authorize]
        public IActionResult Create()
        {
            return View();
        }

        // POST: Reviews/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ReviewViewModel reviewViewModel)
        {
            if (ModelState.IsValid)
            {
                var user = await _userManager.GetUserAsync(User);

                var review = reviewViewModel.ToEntity();
                review.ID = Guid.NewGuid();
                review.CREATED = DateTime.Now;
                review.MODIFIED = DateTime.Now;
                review.CREATEDBY = user;

                _context.Add(review);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index" , "Home");
            }
            return View(reviewViewModel);
        }

        // GET: Reviews/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var review = await _context.Reviews.FindAsync(id);

            if (review == null)
            {
                return NotFound();
            }
            
            var reviewViewModel = ReviewViewModel.FromEntity(review);
            return View(reviewViewModel);
        }

        // POST: Reviews/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, ReviewViewModel reviewViewModel)
        {

            if (id != reviewViewModel.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var review = reviewViewModel.ToEntity();
                    review.MODIFIED = DateTime.Now;
                    _context.Update(review);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ReviewExists(reviewViewModel.ID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("Index", "Home");
            }
            return View(reviewViewModel);
        }

        // GET: Reviews/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var review = await _context.Reviews
                .FirstOrDefaultAsync(m => m.ID == id);
            if (review == null)
            {
                return NotFound();
            }

            var reviewViewModel = ReviewViewModel.FromEntity(review);
            return View(reviewViewModel);
        }

        // POST: Reviews/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var review = await _context.Reviews.FindAsync(id);
            if (review != null)
            {
                _context.Reviews.Remove(review);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction("Index", "Home");
        }

        private bool ReviewExists(Guid id)
        {
            return _context.Reviews.Any(e => e.ID == id);
        }
    }
}
