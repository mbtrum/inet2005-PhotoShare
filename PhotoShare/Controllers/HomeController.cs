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
            List<Photo> photos = await _context.Photo.Include("Tags").ToListAsync();

            return View(photos);
        }

        // Get photo details by id - ../Home/PhotoDetails/389
        public IActionResult PhotoDetails(int id)
        {
            // create a photo object
            Photo photo = new Photo();

            photo.PhotoId = id;
            photo.Description = "A picture of my parrot.";
            photo.CreatedAt = DateTime.Now;
            photo.ImageFilename = "parrot.jpg";
            photo.IsVisible = true;

            return View(photo);
        }

        // Privacy page
        public IActionResult Privacy()
        {
            return View();
        }
    }
}