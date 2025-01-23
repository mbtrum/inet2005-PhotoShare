using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PhotoShare.Data;
using PhotoShare.Models;

namespace PhotoShare.Controllers
{
    //
    // Tags Controller : Add and remove a tag for a photo
    //

    public class TagsController : Controller
    {
        private readonly PhotoShareContext _context;

        public TagsController(PhotoShareContext context)
        {
            _context = context;
        }

        // Deleted the following actions: 

        // GET: Tags/Index
        // GET: Tags/Details/5
        // GET: Tags/Edit/5
        // POST: Tags/Edit/5


        // GET: Tags/Create
        public IActionResult Create(int? id)
        {
            // id = PhotoId
            if (id == null)
            {
                return NotFound();
            }

            ViewData["PhotoId"] = id;

            return View();
        }

        // POST: Tags/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("TagId,Name,PhotoId")] Tag tag)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tag);
                await _context.SaveChangesAsync();

                // Re-direct back to /Photos/Edit/{PhotoId}
                return RedirectToAction("Edit","Photos", new { id = tag.PhotoId });
            }

            ViewData["PhotoId"] = tag.PhotoId;

            return View(tag);
        }

        
       

        // GET: Tags/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tag = await _context.Tag
                .Include(t => t.Photo)
                .FirstOrDefaultAsync(m => m.TagId == id);
            if (tag == null)
            {
                return NotFound();
            }

            return View(tag);
        }

        // POST: Tags/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tag = await _context.Tag.FindAsync(id);
            if (tag != null)
            {
                _context.Tag.Remove(tag);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TagExists(int id)
        {
            return _context.Tag.Any(e => e.TagId == id);
        }
    }
}
