using System.ComponentModel.DataAnnotations;

namespace PhotoShare.Models
{
    public class Photo
    {
        public int PhotoId { get; set; }

        public string Title { get; set; } = string.Empty;

        public string Description { get; set; } = string.Empty;

        [Display(Name = "Created")]
        public DateTime CreatedAt { get; set; }

        [Display(Name = "Filename")]
        public string ImageFilename { get; set; } = string.Empty;

        public bool isPublic { get; set; } = false;

        // Navigation property
        public List<Tag>? Tags { get; set; } = new();
    }
}
