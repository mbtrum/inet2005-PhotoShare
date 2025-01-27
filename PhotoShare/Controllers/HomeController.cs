using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PhotoShare.Data;
using PhotoShare.Models;

namespace PhotoShare.Controllers
{
    public class HomeController : Controller
    {
        private readonly PhotoShareContext _context;

        // Constructor
        public HomeController(PhotoShareContext context)
        {    
            _context = context;
        }

        // Home page - ../ or ../Home/Controller
        public async Task<IActionResult> Index()
        {
            // get all photo records
            var photos = await _context.Photo.Include(m => m.Tags).ToListAsync();

            return View(photos);
        }

        // Get photo details by id - ../Home/PhotoDetails/389
        public async Task<IActionResult> PhotoDetails(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            // get photo by id
            var photo = await _context.Photo.Include(m => m.Tags).FirstOrDefaultAsync(m => m.PhotoId == id);

            if (photo == null) 
            {
                return NotFound();
            }

            return View(photo);
        }

        // Privacy page
        public IActionResult Privacy()
        {
            return View();
        }
    }
}