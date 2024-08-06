using HighSchoolMarathon.DataAccess.Models;
using System.ComponentModel.DataAnnotations;

namespace HighSchoolMarathon.WebApp.Models
{
    public class EventModel
    {
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string EventName { get; set; }

        [Required]
        public DateTime RegistrationStartDate { get; set; }

        [Required]
        public DateTime RegistrationEndDate { get; set; }

        public int NumberOfRunners
        {
            get
            {
                return RunnerRegistrations?.Count ?? 0;
            }
        }

        [Required]
        public DateTime EventStartTime { get; set; }

        [Required]
        [StringLength(200)]
        public string Location { get; set; }

        [StringLength(500)]
        public string RouteDescription { get; set; }
   
        [StringLength(20)]
        public string? Status { get; set; }

        // Collection of RunnerRegistrations
        public ICollection<RegistrationModel>? RunnerRegistrations { get; set; }
    }
}
