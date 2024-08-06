using HighSchoolMarathon.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HighSchoolMarathon.DataAccess.Repositories
{
    public interface IRunnerRepository
    {
        Task<RunnerRegistration?> GetByBibNumberAsync(string bibNumber);
        Task<List<RunnerRegistration>> GetAllRunnerAsync(int eventId);
        Task RegisterEventAsync(RunnerRegistration registration);

        Task UpdateRunnerRank(RunnerRegistration registration);
    }
}
