using Microsoft.AspNetCore.Mvc;
using PhotoShare.Models;

namespace PhotoShare.Controllers
{
    public class HomeController : Controller
    {
        // Constructor
        public HomeController()
        {    
        }

        // Home page
        public IActionResult Index()
        {
            // create a list of photos
            List<Photo> photos = new List<Photo>();

            // create 3 photo objects
            Photo photo1 = new Photo();
            photo1.PhotoId = 1;
            photo1.Title = "My cat";
            photo1.Description = "A picture of my cat.";
            photo1.CreatedAt = DateTime.Now;
            photo1.ImageFilename = "cat.jpg";
            photo1.IsPublic = true;

            Photo photo2 = new Photo();
            photo2.PhotoId = 2;
            photo2.Title = "My dog";
            photo2.Description = "A picture of my dog.";
            photo2.CreatedAt = DateTime.Now;
            photo2.ImageFilename = "dog.jpg";
            photo2.IsPublic = true;

            Photo photo3 = new Photo();
            photo3.PhotoId = 3;
            photo3.Title = "My hamster";
            photo3.Description = "A picture of my hamster.";
            photo3.CreatedAt = DateTime.Now;
            photo3.ImageFilename = "hamster.jpg";
            photo3.IsPublic = true;

            // add the 3 photo objects to the list
            photos.Add(photo1);
            photos.Add(photo2);
            photos.Add(photo3);

            // a variable to store number of photos in the list
            int numPhotos = photos.Count;

            return View(photos);
        }

        // Get photo details by id
        public IActionResult PhotoDetails(int id)
        {
            // create a photo object
            Photo photo = new Photo();

            photo.PhotoId = id;
            photo.Title = "My parrot";
            photo.Description = "A picture of my parrot.";
            photo.CreatedAt = DateTime.Now;
            photo.ImageFilename = "parrot.jpg";
            photo.IsPublic = true;

            return View(photo);
        }

        // Privacy page
        public IActionResult Privacy()
        {
            return View();
        }
    }
}