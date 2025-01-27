using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PhotoShare.Models
{
    public class Photo
    {
        // primary key
        public int PhotoId { get; set; }

        [Required(ErrorMessage = "A description is required.")]
        public string Description { get; set; } = string.Empty;

        public string Location { get; set; } = string.Empty;

        public string Camera { get; set; } = string.Empty;

        // The photo filename e.g. cat.jpg
        public string ImageFilename { get; set; } = string.Empty;

        // Property for file upload, not mapped in EF
        [NotMapped]
        [Display(Name = "Photograph")]
        public IFormFile? ImageFile { get; set; } // nullable!!!

        [Display(Name = "Visible")]
        public bool IsVisible { get; set; } = false;

        [Display(Name = "Created")]
        public DateTime CreatedAt { get; set; } = DateTime.Now;

        // Navigation property
        public List<Tag>? Tags { get; set; }  // nullable!!!
    }
}
