using System;
using System.ComponentModel.DataAnnotations;

namespace HighSchoolMarathon.DataAccess.Models
{
    public class RunnerRegistration
    {
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; } = string.Empty;

        [Required]
        [EmailAddress]
        public string Email { get; set; } = string.Empty;

        [Range(1, 12)]
        public int Grade { get; set; }

        [Required]
        [StringLength(50)]
        public string ClassName { get; set; } = string.Empty;

        [Range(5, 20)]
        public int Age { get; set; }

        [Required]
        [StringLength(10)]
        public string Gender { get; set; } = string.Empty;

        [Required]
        [StringLength(10)]
        public string BibNumber { get; set; } = string.Empty;

        public TimeSpan? Time { get; set; }

        public int? Ranking { get; set; }

        // Foreign key to RunningEvent
        public int RunningEventId { get; set; }

        // Navigation property
        public RunningEvent RunningEvent { get; set; } = null!;

    }
}
