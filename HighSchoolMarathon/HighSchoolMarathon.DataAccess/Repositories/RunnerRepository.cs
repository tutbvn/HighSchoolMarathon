using HighSchoolMarathon.DataAccess.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HighSchoolMarathon.DataAccess.Repositories
{
    public class RunnerRepository : IRunnerRepository
    {
        private readonly HighSchoolMarathonContext _context;

        public RunnerRepository(HighSchoolMarathonContext context)
        {
            _context = context;
        }

        public Task<List<RunnerRegistration>> GetAllRunnerAsync(int eventId)
        {
            return _context.RunnerRegistrations.Where(r => r.RunningEventId == eventId).OrderBy(r => r.Ranking).ToListAsync();
        }

        public Task<RunnerRegistration?> GetByBibNumberAsync(string bibNumber)
        {
            return _context.RunnerRegistrations.FirstOrDefaultAsync(r => r.BibNumber == bibNumber);
        }

        public Task RegisterEventAsync(RunnerRegistration registration)
        {
            _context.RunnerRegistrations.Add(registration);
            return _context.SaveChangesAsync();
        }

        public async Task UpdateRunnerRank(RunnerRegistration registration)
        {
            var current = await _context.RunnerRegistrations.FindAsync(registration.Id);
            if (current != null)
            {
                current.Ranking = registration.Ranking;
                await _context.SaveChangesAsync();
            }
        }
    }
}
