using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace HighSchoolMarathon.DataAccess.Models
{
    public class Organizer : IdentityUser
    {
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [StringLength(50)]
        public string Position { get; set; }
    }
}
