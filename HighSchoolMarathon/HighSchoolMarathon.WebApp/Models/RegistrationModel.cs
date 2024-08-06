using HighSchoolMarathon.DataAccess.Models;
using System.ComponentModel.DataAnnotations;

namespace HighSchoolMarathon.WebApp.Models
{
    public class RegistrationModel
    {
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Range(1, 12)]
        public int Grade { get; set; } = 10;

        [Required]
        [StringLength(50)]
        public string ClassName { get; set; }

        [Range(5, 20)]
        public int Age { get; set; } = 16;

        [Required]
        [StringLength(10)]
        public string Gender { get; set; }

        [StringLength(10)]
        public string? BibNumber { get; set; }

        public TimeSpan? Time { get; set; }

        public int? Ranking { get; set; }

        // Foreign key to RunningEvent
        public int RunningEventId { get; set; }

        // Navigation property
        public EventModel? RunningEvent { get; set; }
    }
}
