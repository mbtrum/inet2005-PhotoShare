﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
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

    // Restrict access to logged in users only
    [Authorize]
    public class TagsController : Controller
    {
        private readonly PhotoShareContext _context;
        private readonly UserManager<ApplicationUser> _userManager;

        public TagsController(PhotoShareContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        // Deleted the following actions: 
        // GET: Tags/Index
        // GET: Tags/Details/5
        // GET: Tags/Edit/5
        // POST: Tags/Edit/5
        // POST: Tags/Delete/5

        //
        // CREATE
        //

        // GET: Tags/Create
        public async Task<IActionResult> Create(int? id)
        {
            // id = PhotoId
            if (id == null)
            {
                return NotFound();
            }

            // verify photo exists for user id
            string userId = _userManager.GetUserId(User);

            var photo = await _context.Photo
                .Where(m => m.ApplicationUserId == userId) // filter by user id                
                .FirstOrDefaultAsync(m => m.PhotoId == id);

            if (photo == null)
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

        //
        // DELETE
        //

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

            _context.Tag.Remove(tag);
            await _context.SaveChangesAsync();

            // Re-direct back to /Photos/Edit/{PhotoId}
            return RedirectToAction("Edit", "Photos", new { id = tag.PhotoId });
        }

    }
}
